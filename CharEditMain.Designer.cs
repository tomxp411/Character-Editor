namespace CharEdit
{
    partial class CharEditMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.charViewer1 = new CharEdit.CharViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bankSelect = new System.Windows.Forms.ComboBox();
            this.BankLabel = new System.Windows.Forms.Label();
            this.ConvertButton = new System.Windows.Forms.Button();
            this.ConvertCharHeight = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CharHeight = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.editControl1 = new CharEdit.EditControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.charViewer1);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.editControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1080, 577);
            this.splitContainer1.SplitterDistance = 518;
            this.splitContainer1.TabIndex = 0;
            // 
            // charViewer1
            // 
            this.charViewer1.BackColor = System.Drawing.Color.DarkBlue;
            this.charViewer1.BytesPerCharacter = 8;
            this.charViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.charViewer1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.charViewer1.Location = new System.Drawing.Point(0, 21);
            this.charViewer1.Name = "charViewer1";
            this.charViewer1.Size = new System.Drawing.Size(518, 556);
            this.charViewer1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.bankSelect);
            this.panel1.Controls.Add(this.BankLabel);
            this.panel1.Controls.Add(this.ConvertButton);
            this.panel1.Controls.Add(this.ConvertCharHeight);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.CharHeight);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(518, 21);
            this.panel1.TabIndex = 1;
            // 
            // bankSelect
            // 
            this.bankSelect.Dock = System.Windows.Forms.DockStyle.Left;
            this.bankSelect.FormattingEnabled = true;
            this.bankSelect.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.bankSelect.Location = new System.Drawing.Point(429, 0);
            this.bankSelect.Name = "bankSelect";
            this.bankSelect.Size = new System.Drawing.Size(52, 21);
            this.bankSelect.TabIndex = 8;
            this.bankSelect.Text = "0";
            this.bankSelect.SelectedIndexChanged += new System.EventHandler(this.bankSelect_SelectedIndexChanged);
            // 
            // BankLabel
            // 
            this.BankLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.BankLabel.Location = new System.Drawing.Point(376, 0);
            this.BankLabel.Name = "BankLabel";
            this.BankLabel.Size = new System.Drawing.Size(53, 21);
            this.BankLabel.TabIndex = 7;
            this.BankLabel.Text = "Bank";
            this.BankLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ConvertButton
            // 
            this.ConvertButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.ConvertButton.Location = new System.Drawing.Point(342, 0);
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.Size = new System.Drawing.Size(34, 21);
            this.ConvertButton.TabIndex = 6;
            this.ConvertButton.Text = "Go";
            this.ConvertButton.UseVisualStyleBackColor = true;
            this.ConvertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // ConvertCharHeight
            // 
            this.ConvertCharHeight.Dock = System.Windows.Forms.DockStyle.Left;
            this.ConvertCharHeight.FormattingEnabled = true;
            this.ConvertCharHeight.Items.AddRange(new object[] {
            "8",
            "10",
            "12",
            "14",
            "16"});
            this.ConvertCharHeight.Location = new System.Drawing.Point(290, 0);
            this.ConvertCharHeight.Name = "ConvertCharHeight";
            this.ConvertCharHeight.Size = new System.Drawing.Size(52, 21);
            this.ConvertCharHeight.TabIndex = 5;
            this.ConvertCharHeight.Text = "8";
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(232, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "Convert";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CharHeight
            // 
            this.CharHeight.Dock = System.Windows.Forms.DockStyle.Left;
            this.CharHeight.FormattingEnabled = true;
            this.CharHeight.Items.AddRange(new object[] {
            "8",
            "10",
            "12",
            "14",
            "16"});
            this.CharHeight.Location = new System.Drawing.Point(180, 0);
            this.CharHeight.Name = "CharHeight";
            this.CharHeight.Size = new System.Drawing.Size(52, 21);
            this.CharHeight.TabIndex = 3;
            this.CharHeight.Text = "8";
            this.CharHeight.SelectedIndexChanged += new System.EventHandler(this.CharHeight_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(135, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "Height";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.textBox1.Location = new System.Drawing.Point(35, 0);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "$00";
            this.toolTip1.SetToolTip(this.textBox1, "Start of copy/paste. Use $ for hex numbers");
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Start";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // editControl1
            // 
            this.editControl1.BytesPerCharacter = 16;
            this.editControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editControl1.Location = new System.Drawing.Point(0, 0);
            this.editControl1.Name = "editControl1";
            this.editControl1.Size = new System.Drawing.Size(558, 577);
            this.editControl1.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1080, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.clearToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.copyToolStripMenuItem.Text = "&Copy Block";
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.pasteToolStripMenuItem.Text = "&Paste At";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
            this.clearToolStripMenuItem.Text = "Cl&ear Block";
            // 
            // CharEditMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1080, 601);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "CharEditMain";
            this.Text = "C= Character Editor";
            this.Load += new System.EventHandler(this.CharEdWindow_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private global::CharEdit.CharViewer charViewer1;
        private EditControl editControl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CharHeight;
        private System.Windows.Forms.Button ConvertButton;
        private System.Windows.Forms.ComboBox ConvertCharHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox bankSelect;
        private System.Windows.Forms.Label BankLabel;
    }
}