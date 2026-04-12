namespace SQLQuest
{
    partial class Level1Form
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlGame = new System.Windows.Forms.Panel();
            this.lblLevel = new System.Windows.Forms.Label();
            this.lblInventory = new System.Windows.Forms.Label();
            this.lstInventory = new System.Windows.Forms.ListBox();
            this.lblQuery = new System.Windows.Forms.Label();
            this.txtQuery = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.btnHint = new System.Windows.Forms.Button();
            this.lblFeedback = new System.Windows.Forms.Label();
            this.lblMoveLabel = new System.Windows.Forms.Label();
            this.txtMoveTile = new System.Windows.Forms.TextBox();
            this.btnMove = new System.Windows.Forms.Button();
            this.btnShowSchema = new System.Windows.Forms.Button();
            this.pnlSchema = new System.Windows.Forms.Panel();
            this.lblSchemaTitle = new System.Windows.Forms.Label();
            this.btnCloseSchema = new System.Windows.Forms.Button();
            this.rtbSchema = new System.Windows.Forms.RichTextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlSchema.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlGame
            // 
            this.pnlGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(160)))), ((int)(((byte)(110)))));
            this.pnlGame.Location = new System.Drawing.Point(10, 11);
            this.pnlGame.Name = "pnlGame";
            this.pnlGame.Size = new System.Drawing.Size(1510, 377);
            this.pnlGame.TabIndex = 0;
            this.pnlGame.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlGame_Paint);
            // 
            // lblLevel
            // 
            this.lblLevel.Font = new System.Drawing.Font("Courier New", 14F, System.Drawing.FontStyle.Bold);
            this.lblLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            this.lblLevel.Location = new System.Drawing.Point(12, 407);
            this.lblLevel.Name = "lblLevel";
            this.lblLevel.Size = new System.Drawing.Size(400, 28);
            this.lblLevel.TabIndex = 1;
            this.lblLevel.Text = "Goal: Escape the Room";
            // 
            // lblInventory
            // 
            this.lblInventory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(30)))), ((int)(((byte)(70)))));
            this.lblInventory.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
            this.lblInventory.ForeColor = System.Drawing.Color.Yellow;
            this.lblInventory.Location = new System.Drawing.Point(895, 412);
            this.lblInventory.Name = "lblInventory";
            this.lblInventory.Size = new System.Drawing.Size(355, 45);
            this.lblInventory.TabIndex = 3;
            this.lblInventory.Text = "Table_name: inventory:\r\ncolumn_name= inventory_name";
            // 
            // lstInventory
            // 
            this.lstInventory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(10)))), ((int)(((byte)(40)))));
            this.lstInventory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstInventory.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
            this.lstInventory.ForeColor = System.Drawing.Color.Yellow;
            this.lstInventory.ItemHeight = 20;
            this.lstInventory.Location = new System.Drawing.Point(1277, 407);
            this.lstInventory.Name = "lstInventory";
            this.lstInventory.Size = new System.Drawing.Size(235, 62);
            this.lstInventory.TabIndex = 4;
            this.lstInventory.SelectedIndexChanged += new System.EventHandler(this.lstInventory_SelectedIndexChanged_1);
            // 
            // lblQuery
            // 
            this.lblQuery.Font = new System.Drawing.Font("Courier New", 11F, System.Drawing.FontStyle.Bold);
            this.lblQuery.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            this.lblQuery.Location = new System.Drawing.Point(30, 546);
            this.lblQuery.Name = "lblQuery";
            this.lblQuery.Size = new System.Drawing.Size(100, 24);
            this.lblQuery.TabIndex = 8;
            this.lblQuery.Text = "Query:";
            // 
            // txtQuery
            // 
            this.txtQuery.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(14)))), ((int)(((byte)(40)))));
            this.txtQuery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQuery.Font = new System.Drawing.Font("Courier New", 11F);
            this.txtQuery.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(255)))), ((int)(((byte)(160)))));
            this.txtQuery.Location = new System.Drawing.Point(34, 577);
            this.txtQuery.Multiline = true;
            this.txtQuery.Name = "txtQuery";
            this.txtQuery.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtQuery.Size = new System.Drawing.Size(1094, 100);
            this.txtQuery.TabIndex = 9;
            this.txtQuery.TextChanged += new System.EventHandler(this.txtQuery_TextChanged);
            // 
            // btnRun
            // 
            this.btnRun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(160)))), ((int)(((byte)(80)))));
            this.btnRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRun.Font = new System.Drawing.Font("Courier New", 11F, System.Drawing.FontStyle.Bold);
            this.btnRun.ForeColor = System.Drawing.Color.White;
            this.btnRun.Location = new System.Drawing.Point(1149, 626);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(85, 38);
            this.btnRun.TabIndex = 10;
            this.btnRun.Text = "RUN";
            this.btnRun.UseVisualStyleBackColor = false;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // btnHint
            // 
            this.btnHint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(120)))), ((int)(((byte)(30)))));
            this.btnHint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHint.Font = new System.Drawing.Font("Courier New", 10F);
            this.btnHint.ForeColor = System.Drawing.Color.White;
            this.btnHint.Location = new System.Drawing.Point(1149, 680);
            this.btnHint.Name = "btnHint";
            this.btnHint.Size = new System.Drawing.Size(85, 32);
            this.btnHint.TabIndex = 11;
            this.btnHint.Text = "HINT";
            this.btnHint.UseVisualStyleBackColor = false;
            this.btnHint.Click += new System.EventHandler(this.btnHint_Click);
            // 
            // lblFeedback
            // 
            this.lblFeedback.Font = new System.Drawing.Font("Courier New", 10F);
            this.lblFeedback.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblFeedback.Location = new System.Drawing.Point(30, 680);
            this.lblFeedback.Name = "lblFeedback";
            this.lblFeedback.Size = new System.Drawing.Size(970, 50);
            this.lblFeedback.TabIndex = 13;
            this.lblFeedback.Text = "Run a SQL query to interact with the room...";
            // 
            // lblMoveLabel
            // 
            this.lblMoveLabel.Font = new System.Drawing.Font("Courier New", 10F);
            this.lblMoveLabel.ForeColor = System.Drawing.Color.White;
            this.lblMoveLabel.Location = new System.Drawing.Point(30, 494);
            this.lblMoveLabel.Name = "lblMoveLabel";
            this.lblMoveLabel.Size = new System.Drawing.Size(120, 22);
            this.lblMoveLabel.TabIndex = 5;
            this.lblMoveLabel.Text = "Move to tile:";
            // 
            // txtMoveTile
            // 
            this.txtMoveTile.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(40)))), ((int)(((byte)(80)))));
            this.txtMoveTile.Font = new System.Drawing.Font("Courier New", 11F);
            this.txtMoveTile.ForeColor = System.Drawing.Color.White;
            this.txtMoveTile.Location = new System.Drawing.Point(174, 488);
            this.txtMoveTile.Name = "txtMoveTile";
            this.txtMoveTile.Size = new System.Drawing.Size(102, 28);
            this.txtMoveTile.TabIndex = 6;
            this.txtMoveTile.TextChanged += new System.EventHandler(this.txtMoveTile_TextChanged);
            // 
            // btnMove
            // 
            this.btnMove.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(60)))), ((int)(((byte)(130)))));
            this.btnMove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMove.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold);
            this.btnMove.ForeColor = System.Drawing.Color.White;
            this.btnMove.Location = new System.Drawing.Point(304, 488);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(104, 28);
            this.btnMove.TabIndex = 7;
            this.btnMove.Text = "GO";
            this.btnMove.UseVisualStyleBackColor = false;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // btnShowSchema
            // 
            this.btnShowSchema.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(100)))), ((int)(((byte)(130)))));
            this.btnShowSchema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowSchema.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold);
            this.btnShowSchema.ForeColor = System.Drawing.Color.White;
            this.btnShowSchema.Location = new System.Drawing.Point(1149, 577);
            this.btnShowSchema.Name = "btnShowSchema";
            this.btnShowSchema.Size = new System.Drawing.Size(85, 32);
            this.btnShowSchema.TabIndex = 12;
            this.btnShowSchema.Text = "Schema";
            this.btnShowSchema.UseVisualStyleBackColor = false;
            this.btnShowSchema.Click += new System.EventHandler(this.btnShowSchema_Click);
            // 
            // pnlSchema
            // 
            this.pnlSchema.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(6)))), ((int)(((byte)(30)))));
            this.pnlSchema.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSchema.Controls.Add(this.lblSchemaTitle);
            this.pnlSchema.Controls.Add(this.btnCloseSchema);
            this.pnlSchema.Controls.Add(this.rtbSchema);
            this.pnlSchema.Location = new System.Drawing.Point(10, 10);
            this.pnlSchema.Name = "pnlSchema";
            this.pnlSchema.Size = new System.Drawing.Size(965, 318);
            this.pnlSchema.TabIndex = 14;
            this.pnlSchema.Visible = false;
            // 
            // lblSchemaTitle
            // 
            this.lblSchemaTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(20)))), ((int)(((byte)(80)))));
            this.lblSchemaTitle.Font = new System.Drawing.Font("Courier New", 11F, System.Drawing.FontStyle.Bold);
            this.lblSchemaTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(215)))), ((int)(((byte)(0)))));
            this.lblSchemaTitle.Location = new System.Drawing.Point(-1, 0);
            this.lblSchemaTitle.Name = "lblSchemaTitle";
            this.lblSchemaTitle.Size = new System.Drawing.Size(860, 30);
            this.lblSchemaTitle.TabIndex = 0;
            this.lblSchemaTitle.Text = "  DATABASE TABLES  —  Use these in your SQL queries";
            // 
            // btnCloseSchema
            // 
            this.btnCloseSchema.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.btnCloseSchema.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCloseSchema.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Bold);
            this.btnCloseSchema.ForeColor = System.Drawing.Color.White;
            this.btnCloseSchema.Location = new System.Drawing.Point(868, 2);
            this.btnCloseSchema.Name = "btnCloseSchema";
            this.btnCloseSchema.Size = new System.Drawing.Size(88, 26);
            this.btnCloseSchema.TabIndex = 1;
            this.btnCloseSchema.Text = "X CLOSE";
            this.btnCloseSchema.UseVisualStyleBackColor = false;
            this.btnCloseSchema.Click += new System.EventHandler(this.btnCloseSchema_Click);
            // 
            // rtbSchema
            // 
            this.rtbSchema.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(6)))), ((int)(((byte)(30)))));
            this.rtbSchema.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbSchema.Font = new System.Drawing.Font("Courier New", 9F);
            this.rtbSchema.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(255)))), ((int)(((byte)(160)))));
            this.rtbSchema.Location = new System.Drawing.Point(5, 35);
            this.rtbSchema.Name = "rtbSchema";
            this.rtbSchema.ReadOnly = true;
            this.rtbSchema.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbSchema.Size = new System.Drawing.Size(952, 278);
            this.rtbSchema.TabIndex = 2;
            this.rtbSchema.Text = "";
            this.rtbSchema.WordWrap = false;
            this.rtbSchema.TextChanged += new System.EventHandler(this.rtbSchema_TextChanged);
            // 
            // listBox1
            // 
            this.listBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(10)))), ((int)(((byte)(40)))));
            this.listBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox1.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
            this.listBox1.ForeColor = System.Drawing.Color.Yellow;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(1277, 488);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(170, 82);
            this.listBox1.TabIndex = 15;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(30)))), ((int)(((byte)(70)))));
            this.label1.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(891, 488);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(371, 71);
            this.label1.TabIndex = 16;
            this.label1.Text = "Table_name: level_objects\r\ncolumn_name: object_names\r\ncolumn_name (update): objec" +
    "t_value\r\n";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // Level1Form
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(20)))), ((int)(((byte)(50)))));
            this.ClientSize = new System.Drawing.Size(1532, 742);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.pnlGame);
            this.Controls.Add(this.lblLevel);
            this.Controls.Add(this.lblInventory);
            this.Controls.Add(this.lstInventory);
            this.Controls.Add(this.lblMoveLabel);
            this.Controls.Add(this.txtMoveTile);
            this.Controls.Add(this.btnMove);
            this.Controls.Add(this.lblQuery);
            this.Controls.Add(this.txtQuery);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.btnHint);
            this.Controls.Add(this.btnShowSchema);
            this.Controls.Add(this.lblFeedback);
            this.Controls.Add(this.pnlSchema);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Level1Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQL Quest — Level 1";
            this.pnlSchema.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // ── Control declarations ──────────────────────────────────────
        private System.Windows.Forms.Panel pnlGame;
        private System.Windows.Forms.Label lblLevel, lblInventory, lblQuery;
        private System.Windows.Forms.Label lblFeedback, lblMoveLabel;
        private System.Windows.Forms.ListBox lstInventory;
        private System.Windows.Forms.TextBox txtQuery, txtMoveTile;
        private System.Windows.Forms.Button btnRun, btnHint, btnMove;
        private System.Windows.Forms.Button btnShowSchema, btnCloseSchema;
        private System.Windows.Forms.Panel pnlSchema;
        private System.Windows.Forms.RichTextBox rtbSchema;     
        private System.Windows.Forms.Label lblSchemaTitle;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
    }
}