using System;
using System.Data;
using System.Drawing;
using System.Media;
using System.Windows.Forms;
using System.Xml.Schema;
namespace SQLQuest
{
    public partial class Level1Form : Form
    {
        private string playerName;
        private int playerTile;
        private int keyTile;
        private int doorTile;
        private bool keyPickedUp;
        private bool doorOpen;
        private int score;
        private int hintIndex;
        private string[] hints;

        private int TileCount;
        private int TileWidth = 150;
        private int TileHeight = 60;
        private int FloorY = 260;
        private int CharHeight = 50;
        private int CharWidth = 30;

        private int levelNumber;
        private int boxTile;
        private int plantTile;
        private bool boxOpened = false;
        private bool keyVisible = true; // for L2/L3 logic
        private bool plantVisible = true;
        public Level1Form(string playerName, int levelNumber)
        {
            InitializeComponent();
            this.playerName = playerName;
            this.levelNumber = levelNumber;

            // Load level-specific data
            switch (levelNumber)
            {
                case 1: SetupLevel1(); break;
                case 2: SetupLevel2(); break;
                case 3: SetupLevel3(); break;
                default: SetupLevel1(); break;
            }

            RefreshInventory();
            RefreshListBox();
        }

        // ───────────────────────────────
        // LEVEL SETUP FUNCTIONS
        // ───────────────────────────────

        private void SetupLevel1()
        {
            TileCount = 6;
            playerTile = 2;
            keyTile = 4;
            doorTile = 6;

            keyPickedUp = false;
            doorOpen = false;
            keyVisible = true;

            LoadHintsFromDB(1);
        }

        private void SetupLevel2()
        {
            TileCount = 6;
            playerTile = 1;

            boxTile = 4;
            plantTile = 5;
            keyTile = 0; // hidden initially
            doorTile = 6;

            keyVisible = false;
            keyPickedUp = false;
            doorOpen = false;
            boxOpened = false;

            LoadHintsFromDB(2);
        }

        private void SetupLevel3()
        {
            TileCount = 8;
            playerTile = 1;
            TileWidth = 110;
            boxTile = 4;
            plantTile = 3;
            keyTile = 0;
            doorTile = 8;
            plantVisible = true;
            keyVisible = false;
            keyPickedUp = false;
            doorOpen = false;
            boxOpened = false;
            DatabaseHelper.ExecuteNonQuery(@"
        IF NOT EXISTS (
            SELECT 1 FROM level_objects 
            WHERE object_names = 'Plant' AND level_number = 3
        )
        INSERT INTO level_objects (object_names, object_value, level_number)
        VALUES ('Plant', '0', 3)
    ");
            LoadHintsFromDB(3);
        }

        private void LoadHintsFromDB(int level)
        {
            DataTable dt = DatabaseHelper.GetHints(level);
            hints = new string[dt.Rows.Count];
            for (int i = 0; i < dt.Rows.Count; i++)
                hints[i] = dt.Rows[i]["hint_desc"].ToString();
        }
        // ─────────────────────────────────────────────────────────────
        // DRAWING
        // ─────────────────────────────────────────────────────────────
        int offsetX;
        private void pnlGame_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            offsetX = (pnlGame.Width - 970) / 2; // ✅ ONLY X CENTER

            DrawBackground(g);
            DrawFloor(g);
            DrawTileNumbers(g);
            DrawPlayer(g);

            if (levelNumber == 1)
            {
                if (!keyPickedUp)
                    DrawKey(g);
            }
            else if (levelNumber == 2)
            {
                DrawBox(g);

                if (keyVisible && !keyPickedUp)
                    DrawKey(g);
            }
            else if (levelNumber == 3)
            {
                DrawBox(g);

                if (plantVisible)
                    DrawPlant(g);

                if (keyVisible && !keyPickedUp)
                    DrawKey(g);
            }

            DrawDoor(g);
            DrawPlayer(g);
        }

        private void DrawBox(Graphics g)
        {
            if (levelNumber == 1) return;

            int x = TileToPixelX(boxTile) + offsetX + TileWidth / 2 - 20;
            int y = FloorY - 40;

            using (SolidBrush b = new SolidBrush(Color.SaddleBrown))
                g.FillRectangle(b, x, y, 40, 30);

            using (Font f = new Font("Courier New", 8, FontStyle.Bold))
                g.DrawString("BOX", f, Brushes.White, x + 2, y - 18);
        }

        private void DrawPlant(Graphics g)
        {
            if (levelNumber == 1 || !plantVisible) return;

            int centerX = TileToPixelX(plantTile) + offsetX + TileWidth / 2;
            int baseY = FloorY - 20;

            // 🌱 POT
            using (SolidBrush potBrush = new SolidBrush(Color.SaddleBrown))
                g.FillRectangle(potBrush, centerX - 15, baseY - 10, 30, 15);

            using (Pen potBorder = new Pen(Color.Black, 1))
                g.DrawRectangle(potBorder, centerX - 15, baseY - 10, 30, 15);

            // 🌱 STEM (⬆ increased height)
            using (Pen stemPen = new Pen(Color.DarkGreen, 3))
                g.DrawLine(stemPen, centerX, baseY - 10, centerX, baseY - 60);

            // 🌿 LEFT LEAF (⬆ moved up)
            using (SolidBrush leafBrush = new SolidBrush(Color.Green))
                g.FillEllipse(leafBrush, centerX - 20, baseY - 70, 20, 14);

            // 🌿 RIGHT LEAF (⬆ moved up)
            using (SolidBrush leafBrush = new SolidBrush(Color.Green))
                g.FillEllipse(leafBrush, centerX, baseY - 70, 20, 14);

            // 🌿 TOP LEAF (⬆ moved higher)
            using (SolidBrush leafBrush = new SolidBrush(Color.ForestGreen))
                g.FillEllipse(leafBrush, centerX - 7, baseY - 95, 14, 18);

            // 🏷 LABEL (⬆ adjusted position)
            using (Font f = new Font("Courier New", 8, FontStyle.Bold))
                g.DrawString("PLANT", f, Brushes.LightGreen, centerX - 20, baseY - 105);
        }
        private void DrawBackground(Graphics g)
        {
            g.Clear(Color.FromArgb(185, 148, 100));
            using (Pen p = new Pen(Color.FromArgb(160, 130, 90), 1))
            {
                for (int y = 20; y < FloorY; y += 30)
                    for (int x = (y / 30 % 2 == 0 ? 0 : 40); x < 970; x += 80)
                        g.DrawRectangle(p, x + offsetX, y, 75, 28);
            }
        }

        private void DrawFloor(Graphics g)
        {
            Rectangle floor = new Rectangle(offsetX, FloorY, 970, 60);
            using (SolidBrush b = new SolidBrush(Color.FromArgb(90, 50, 150)))
                g.FillRectangle(b, floor);

            // Tile separators + numbers drawn below
        }

        private void DrawTileNumbers(Graphics g)
        {
            using (Font f = new Font("Courier New", 14, FontStyle.Bold))
            using (SolidBrush b = new SolidBrush(Color.White))
            {
                for (int i = 1; i <= TileCount; i++)
                {
                    int x = TileToPixelX(i) + offsetX + TileWidth / 2 - 8;
                    g.DrawString(i.ToString(), f, b, x, FloorY + 15);
                }
            }
        }

        private void DrawPlayer(Graphics g)
        {
            int px = TileToPixelX(playerTile) + offsetX + TileWidth / 2 - CharWidth / 2;
            int py = FloorY - CharHeight;

            // Body (dark blue)
            using (SolidBrush b = new SolidBrush(Color.FromArgb(60, 50, 130)))
                g.FillRectangle(b, px, py + 14, CharWidth, 26);

            // Head
            using (SolidBrush b = new SolidBrush(Color.FromArgb(210, 180, 140)))
                g.FillEllipse(b, px + 5, py, 20, 20);

            // Hat
            using (SolidBrush b = new SolidBrush(Color.FromArgb(30, 20, 60)))
            {
                g.FillRectangle(b, px + 2, py - 8, 26, 10);
                g.FillRectangle(b, px + 7, py - 16, 16, 10);
            }

            // "YOU" label
            using (Font f = new Font("Courier New", 8, FontStyle.Bold))
            using (SolidBrush b = new SolidBrush(Color.Yellow))
                g.DrawString("YOU", f, b, px - 2, py - 26);
        }

        private void DrawKey(Graphics g)
        {
            int kTile = keyTile == 0 ? 5 : 5;
            keyTile = 5;
            int kx = TileToPixelX(kTile) + offsetX + TileWidth / 2 - 10;
            int ky = FloorY - 35;

            using (SolidBrush b = new SolidBrush(Color.Gold))
            {
                g.FillEllipse(b, kx, ky, 16, 16);
                g.FillRectangle(b, kx + 14, ky + 5, 22, 6);
                g.FillRectangle(b, kx + 28, ky + 2, 5, 6);
                g.FillRectangle(b, kx + 34, ky + 2, 5, 6);
            }
            using (Font f = new Font("Courier New", 8, FontStyle.Bold))
            using (SolidBrush b = new SolidBrush(Color.Gold))
                g.DrawString("KEY", f, b, kx - 4, ky - 16);
        }

        private void DrawDoor(Graphics g)
        {
            int dx = TileToPixelX(doorTile) + offsetX + TileWidth / 2 - 25;
            int dy = FloorY - 100;

            Color doorColor = doorOpen
                ? Color.FromArgb(100, 200, 100)
                : Color.FromArgb(100, 60, 160);

            using (SolidBrush b = new SolidBrush(doorColor))
                g.FillRectangle(b, dx, dy, 50, 100);

            using (Pen p = new Pen(Color.FromArgb(60, 30, 100), 2))
                g.DrawRectangle(p, dx, dy, 50, 100);

            // Doorknob
            using (SolidBrush b = new SolidBrush(Color.Gold))
                g.FillEllipse(b, dx + 36, dy + 45, 8, 8);

            // Lock icon if locked
            if (!doorOpen)
            {
                using (Font f = new Font("Courier New", 7, FontStyle.Bold))
                using (SolidBrush b = new SolidBrush(Color.Gold))
                    g.DrawString("LOCKED", f, b, dx - 2, dy - 16);
            }
            else
            {
                using (Font f = new Font("Courier New", 7, FontStyle.Bold))
                using (SolidBrush b = new SolidBrush(Color.LightGreen))
                    g.DrawString("OPEN!", f, b, dx + 4, dy - 16);
            }

            using (Font f = new Font("Courier New", 8, FontStyle.Bold))
            using (SolidBrush b = new SolidBrush(Color.White))
                g.DrawString("DOOR", f, b, dx + 6, dy - 28);
        }

        private int TileToPixelX(int tile) => (tile - 1) * TileWidth + 20;

        // ─────────────────────────────────────────────────────────────
        // MOVEMENT
        // ─────────────────────────────────────────────────────────────
        private void btnMove_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMoveTile.Text.Trim(), out int tile) || tile < 1 || tile > TileCount)
            {
                lblFeedback.ForeColor = Color.OrangeRed;
                lblFeedback.Text = $" Invalid tile. Enter a number between 1 and {TileCount}.";
                return;
            }

            // ─────────────────────────────
            // 🌱 LEVEL 3: BLOCK MOVEMENT IF PLANT EXISTS
            // ─────────────────────────────
            if (levelNumber == 3)
            {
                // Check from DB if plant still exists
                DataTable dt = DatabaseHelper.ExecuteQuery(
                    "SELECT * FROM level_objects WHERE object_names='Plant' AND level_number=3");

                bool plantExists = dt.Rows.Count > 0;

                // 🚫 Block movement beyond plant tile
                if (plantExists && tile > plantTile)
                {
                    lblFeedback.ForeColor = Color.OrangeRed;
                    lblFeedback.Text = $"🚫 Path blocked! Remove the Plant at tile {plantTile} first.";
                    return;
                }
            }

            // ✅ Allow movement
            playerTile = tile;

            lblFeedback.ForeColor = Color.LightGray;
            lblFeedback.Text = $" Moved to tile {tile}.";

            // ─────────────────────────────
            // CONTEXT HINTS
            // ─────────────────────────────
            if (levelNumber == 1)
            {
                if (tile == keyTile && !keyPickedUp)
                    lblFeedback.Text += "   You see a Key here! Use SELECT to pick it up.";

                if (tile == doorTile && keyPickedUp && !doorOpen)
                    lblFeedback.Text += "   You're at the Door! Use UPDATE to open it.";
            }

            if (levelNumber == 2 || levelNumber == 3)
            {
                if (tile == boxTile && !boxOpened)
                    lblFeedback.Text += "   You see a Box! Use UPDATE to open it.";

                if (tile == keyTile && keyVisible && !keyPickedUp)
                    lblFeedback.Text += "   A Key is here! Use SELECT to pick it up.";

                if (tile == doorTile && keyPickedUp && !doorOpen)
                    lblFeedback.Text += "   You're at the Door! Use UPDATE to open it.";
            }

            if (levelNumber == 3 && plantVisible && tile > plantTile)
            {
                lblFeedback.ForeColor = Color.OrangeRed;
                lblFeedback.Text = $"🚫 Path blocked! Remove the Plant at tile {plantTile} first.";
                return;
            }

            pnlGame.Invalidate();
        }
        private void btnShowSchema_Click(object sender, EventArgs e)
        {
            rtbSchema.Clear();

            rtbSchema.AppendText("══════════════════════════════\r\n");
            rtbSchema.AppendText($"   LEVEL {levelNumber} SCHEMA\r\n");
            rtbSchema.AppendText("══════════════════════════════\r\n\n");

            rtbSchema.AppendText("TABLE: level_objects\n");
            rtbSchema.AppendText("----------------------------------\n");
            rtbSchema.AppendText("object_names | object_value \n");
            rtbSchema.AppendText("----------------------------------\n");

            // Show actual objects from DB
            DataTable dt = DatabaseHelper.ExecuteQuery(
                $"SELECT object_names,object_value FROM level_objects WHERE level_number = {levelNumber}");

            foreach (DataRow row in dt.Rows)
            {
                rtbSchema.AppendText(
                    $"{row["object_names"]}\t\t|\t\t{row["object_value"]}\r\n");
            }

            rtbSchema.AppendText("\n══════════════════════════════\n");
            rtbSchema.AppendText("TABLE: inventory\n");
            rtbSchema.AppendText("----------------------------------\n");
            rtbSchema.AppendText("inventory_name\n");
            rtbSchema.AppendText("----------------------------------\n");
            //INVENTORY
            DataTable inventory = DatabaseHelper.ExecuteQuery(
                $"SELECT inventory_name FROM inventory WHERE level_number = {levelNumber}");

            foreach (DataRow row in inventory.Rows)
            {
                rtbSchema.AppendText(
                    $"{row["inventory_name"]}|\r\n");
            }

            rtbSchema.AppendText("\n══════════════════════════════\n");
            rtbSchema.AppendText("HINTS:\n");

            DataTable hintsDt = DatabaseHelper.GetHints(levelNumber);
            foreach (DataRow row in hintsDt.Rows)
            {
                rtbSchema.AppendText("- " + row["hint_desc"].ToString() + "\t\n");
            }

            rtbSchema.AppendText("\n══════════════════════════════\n");
            rtbSchema.AppendText("Solutions Query (Copy the query and paste it in the box!!)\n");
            rtbSchema.AppendText("----------------------------------\n");
            

            // Show actual objects from DB
            DataTable st = DatabaseHelper.ExecuteQuery(
                $"SELECT solution_query FROM solutions WHERE level_number = {levelNumber}");

            foreach (DataRow row in st.Rows)
            {
                rtbSchema.AppendText(
                    $"{row["solution_query"]}\r\n");
            }

            pnlSchema.Visible = true;
            pnlSchema.BringToFront();
        }

        private void btnCloseSchema_Click(object sender, EventArgs e)
        {
            pnlSchema.Visible = false;
        }

        // ─────────────────────────────────────────────────────────────
        // QUERY EXECUTION
        // ─────────────────────────────────────────────────────────────
        private void btnRun_Click(object sender, EventArgs e)
        {
            SoundPlayer startSound2 = new SoundPlayer(Properties.Resources.wrong_move);
            
            string tempQuery = txtQuery.Text.Trim();
            string rawQuery = tempQuery + " AND level_number = " + levelNumber;
            if (string.IsNullOrEmpty(rawQuery))
                return;

            string queryUpper = rawQuery.ToUpper();

            try
            {
                string queryType = queryUpper.Split(' ')[0];

                // ─────────────────────────────
                // 🌱 LEVEL 3 RULES (PLANT LOGIC)
                // ─────────────────────────────

                // Must stand on plant tile to delete it
                if (levelNumber == 3 &&
                    queryType == "DELETE" &&
                    queryUpper.Contains("PLANT"))
                {
                    if (playerTile != plantTile)
                    {
                        
                        startSound2.Play();
                        ShowFeedback($"🌱 Move to tile {plantTile} to remove the Plant!", false);
                        return;
                    }
                }

                // Block everything else until plant is removed
                if (levelNumber == 3 && plantVisible)
                {
                    if (!(queryType == "DELETE" && queryUpper.Contains("PLANT")))
                    {
                        
                        startSound2.Play();
                        ShowFeedback("🌱 Remove the Plant first before doing anything else!", false);
                        return;
                    }
                    else
                    {
                        SoundPlayer clickSound = new SoundPlayer(Properties.Resources.correct_better);
                        clickSound.Play(); // 🔊 button click sound
                    }
                }

                // ─────────────────────────────
                // SELECT (CHECK RESULT)
                // ─────────────────────────────
                if (queryType == "SELECT")
                {
                    DataTable dt = DatabaseHelper.ExecuteQuery(rawQuery);

                    bool keyFound = false;

                    foreach (DataRow row in dt.Rows)
                    {
                        if (row.Table.Columns.Contains("object_names") &&
                            row["object_names"].ToString().Equals("Key", StringComparison.OrdinalIgnoreCase) &&
                            Convert.ToInt32(row["level_number"]) == levelNumber)
                        {
                            keyFound = true;
                            break;
                        }
                    }

                    if (keyFound)
                    {
                        if (!keyVisible)
                        {
                           // SoundPlayer startSound = new SoundPlayer(Properties.Resources.wrong_move);
                            startSound2.Play();
                            ShowFeedback("Key is not visible yet!", false);
                            return;
                        }

                        if (playerTile != keyTile)
                        {
                            //SoundPlayer startSound = new SoundPlayer(Properties.Resources.wrong_move);
                            startSound2.Play();
                            ShowFeedback($"Go to tile {keyTile} to pick the key!", false);
                            return;
                        }

                        if (keyPickedUp)
                        {
                            ShowFeedback("Key already collected!", true);
                            return;
                        }

                        DatabaseHelper.AddToInventory("Key", levelNumber);

                        keyPickedUp = true;
                        score += 50;

                        RefreshInventory();
                        SoundPlayer clickSound = new SoundPlayer(Properties.Resources.correct_better);
                        clickSound.Play(); // 🔊 button click sound
                        ShowFeedback("✅ Key collected!", true);
                        pnlGame.Invalidate();
                    }
                    else
                    {
                        ShowFeedback($"Query ran ({dt.Rows.Count} rows) but no Key found.", false);
                    }

                    return;
                }

                // ─────────────────────────────
                // UPDATE / DELETE
                // ─────────────────────────────
                if (queryType == "UPDATE" || queryType == "DELETE")
                {
                    int rows = DatabaseHelper.ExecuteNonQuery(rawQuery);

                    if (rows == 0)
                    {
                        //SoundPlayer startSound = new SoundPlayer(Properties.Resources.wrong_move);
                        startSound2.Play();
                        ShowFeedback("⚠️ Query ran but nothing changed.", false);
                        return;
                    }

                    // ── DELETE PLANT ──
                    if (levelNumber == 3 && queryType == "DELETE" && queryUpper.Contains("PLANT"))
                    {
                        if (playerTile != plantTile)
                        {
                          //  SoundPlayer startSound = new SoundPlayer(Properties.Resources.wrong_move);
                            startSound2.Play();
                            ShowFeedback($"🌱 Go to tile {plantTile} to remove the Plant!", false);
                            return;
                        }

                        //int rows = DatabaseHelper.ExecuteNonQuery(rawQuery);

                        if (rows > 0)
                        {
                            plantVisible = false;   // ✅ UI remove
                            SoundPlayer clickSound = new SoundPlayer(Properties.Resources.correct_better);
                            clickSound.Play(); // 🔊 button click sound
                            ShowFeedback("🌱 Plant removed!", true);

                            pnlGame.Invalidate();   // ✅ redraw UI
                            return;
                        }
                    }

                    // ── BOX LOGIC (Level 2 & 3) ──
                    if ((levelNumber == 2 || levelNumber == 3) &&
                        queryUpper.Contains("BOX"))
                    {
                        if (playerTile != boxTile)
                        {
                            ShowFeedback($"Go to tile {boxTile} to open the box!", false);
                            return;
                        }

                        boxOpened = true;
                        keyVisible = true;
                        keyTile = boxTile;

                        SoundPlayer clickSound = new SoundPlayer(Properties.Resources.correct_better);
                        clickSound.Play(); // 🔊 button click sound
                        ShowFeedback("📦 Box opened! Key appeared!", true);
                        pnlGame.Invalidate();
                        return;
                    }

                    // ── DOOR LOGIC ──
                    if (queryUpper.Contains("DOOR"))
                    {
                        if (!keyPickedUp)
                        {
                            //SoundPlayer startSound = new SoundPlayer(Properties.Resources.wrong_move);
                            startSound2.Play();
                            ShowFeedback("Need key first!", false);
                            return;
                        }

                        if (playerTile != doorTile)
                        {
                            startSound2.Play();
                            ShowFeedback($"Go to tile {doorTile} to open door!", false);
                            return;
                        }

                        doorOpen = true;
                        score += 100;

                        DatabaseHelper.UpdatePlayerScore(playerName, score, levelNumber);

                        pnlGame.Invalidate();
                        SoundPlayer clickSound = new SoundPlayer(Properties.Resources.correct_better);
                        clickSound.Play(); // 🔊 button click sound
                        ShowFeedback("🚪 Door opened! Level complete!", true);

                        System.Threading.Thread.Sleep(300);
                        LevelComplete();
                        return;
                    }

                    // Generic fallback
                    ShowFeedback($"✅ Query executed. {rows} row(s) affected.", true);
                    return;
                }

                // ─────────────────────────────
                // INVALID QUERY TYPE
                // ─────────────────────────────
                startSound2.Play();
                ShowFeedback("❌ Unsupported query type.", false);
            }
            catch (Exception ex)
            {
                ShowFeedback("SQL Error: " + ex.Message, false);
            }
        }

        private bool IsPlantPresent()
        {
            DataTable dt = DatabaseHelper.ExecuteQuery(
                "SELECT * FROM level_objects WHERE object_names = 'Plant' AND level_number = 3");

            return dt.Rows.Count > 0;
        }

        private void ShowFeedback(string message, bool success)
        {
            lblFeedback.ForeColor = success ? Color.FromArgb(120, 255, 160) : Color.OrangeRed;
            lblFeedback.Text = message;
        }

        private void btnHint_Click(object sender, EventArgs e)
        {
            if (hints == null || hints.Length == 0) return;
            string hint = hints[hintIndex % hints.Length];
            hintIndex++;
            MessageBox.Show(hint, " Hint", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void RefreshInventory()
        {
            lstInventory.Items.Clear();
            DataTable dt = DatabaseHelper.ExecuteQuery(
                $"SELECT inventory_name FROM inventory WHERE level_number = {levelNumber}");
            foreach (DataRow row in dt.Rows)
                lstInventory.Items.Add(" " + row["inventory_name"].ToString());
            if (lstInventory.Items.Count == 0)
                lstInventory.Items.Add("(empty)");
        }

        private void RefreshListBox()
        {
            listBox1.Items.Clear();
            DataTable dt = DatabaseHelper.ExecuteQuery(
                $"SELECT object_names FROM level_objects WHERE level_number = {levelNumber}");
            foreach (DataRow row in dt.Rows)
                listBox1.Items.Add(" " + row["object_names"].ToString());
            if (listBox1.Items.Count == 0)
                listBox1.Items.Add("(empty)");
        }

        private void LevelComplete()
        {
            var result = MessageBox.Show(
                $"🏆 LEVEL COMPLETE!\n\nPlayer: {playerName}\nScore: {score} pts\n\nReturn to Home?",
                "SQL Quest — Level 1 Clear!",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information);

            if (result == DialogResult.Yes)
                this.Close();
        }

        private void lstInventory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtQuery_TextChanged(object sender, EventArgs e)
        {

        }

        private void lstInventory_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void rtbSchema_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMoveTile_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}