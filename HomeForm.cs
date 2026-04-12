using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
namespace SQLQuest       
{
    public partial class HomeForm : Form
    {
        // Temporary variable to track the current level
        private int currentLevel = 0; // 0 = no level selected

        public HomeForm()
        {
            InitializeComponent();
            LoadLeaderboard();
        }

        private void LoadLeaderboard()
        {
            string query = @"
                SELECT 
                    p.player_name     AS [Player],
                    p.highscore       AS [High Score],
                    p.levels_complete AS [Levels Done],
         +           CASE WHEN p.levels_complete >= 1 THEN 'Unlocked' ELSE 'Locked' END AS [Level 2],
                    CASE WHEN p.levels_complete >= 2 THEN 'Unlocked' ELSE 'Locked' END AS [Level 3]
                FROM player p
                ORDER BY p.highscore DESC";

            try
            {
                dgvLevels.DataSource = DatabaseHelper.ExecuteQuery(query);
            }
            catch (Exception ex)
            {
                MessageBox.Show("DB Error: " + ex.Message);
            }
        }

        
        private void btnPlay_Click(object sender, EventArgs e)
        {
            SoundPlayer clickSound = new SoundPlayer(Properties.Resources.level_initiate);
            clickSound.Play(); // 🔊 button click sound
            string name = txtPlayerName.Text.Trim();

            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Please enter your player name!");
                return;
            }

            if (currentLevel == 0)
            {

                MessageBox.Show("Select a level first!");
                return;
            }

            try
            {
                if (DatabaseHelper.GetPlayer(name) == null)
                    DatabaseHelper.CreatePlayer(name);

                DatabaseHelper.ResetLevel(currentLevel);

                // 🔥 OPEN SAME FORM FOR ALL LEVELS
                Level1Form gameForm = new Level1Form(name, currentLevel);

                gameForm.Show();
                this.Hide();

                gameForm.FormClosed += (s, args) =>
                {
                    LoadLeaderboard();
                    this.Show();
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void SetLevelAccess(string playerName)
        {
            try
            {
                string query = $"SELECT levels_complete FROM player WHERE player_name = '{playerName}'";
                var dt = DatabaseHelper.ExecuteQuery(query);
                int levelsComplete=0;
                if (dt.Rows.Count != 0)
                {
                 

                    levelsComplete = Convert.ToInt32(dt.Rows[0]["levels_complete"]);
                }
                // Disable all first
                button1.Enabled = false; // Level 1
                button2.Enabled = false; // Level 2
                button3.Enabled = false; // Level 3

                // Enable completed levels
                if (levelsComplete >= 0) button1.Enabled = true;
                if (levelsComplete >= 1) button2.Enabled = true;
                if (levelsComplete >= 2) button3.Enabled = true;

                // Enable next level (n + 1)
                if (levelsComplete == 0) button1.Enabled = true;
                if (levelsComplete == 1) button2.Enabled = true;
                if (levelsComplete == 2) button3.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading levels: " + ex.Message);
            }
        }

        private void HomeForm_Load(object sender, EventArgs e)
        {

        }

        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void txtPlayerName_TextChanged(object sender, EventArgs e)
        {
            string name = txtPlayerName.Text.Trim();
            if (!string.IsNullOrEmpty(name))
            {
                SetLevelAccess(name);
            }
        }

        private void ScoreDisp_Click(object sender, EventArgs e)
        {
           
        }

        private void dgvLevels_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblPlayerName_Click(object sender, EventArgs e)
        {

        }

        

        

        private void button3_Click(object sender, EventArgs e)
        {
            currentLevel = 3;
            MessageBox.Show("Level 3 Selected");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            currentLevel = 1;
            MessageBox.Show("Level 1 Selected");
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            currentLevel = 2;
            MessageBox.Show("Level 2 Selected");
        }
    }
}