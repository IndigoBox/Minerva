namespace Minerva
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.mediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.rTextBox1 = new System.Windows.Forms.RichTextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.minervaResponse = new System.Windows.Forms.Label();
            this.linkToSomewhereYouSillyJoven = new System.Windows.Forms.Label();
            this.itsMinervaWoah = new System.Windows.Forms.PictureBox();
            this.gifSection = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.itsMinervaWoah)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gifSection)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Black;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Wasco Sans", 7.875F);
            this.textBox2.ForeColor = System.Drawing.Color.Plum;
            this.textBox2.Location = new System.Drawing.Point(4, 660);
            this.textBox2.Margin = new System.Windows.Forms.Padding(6);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(664, 36);
            this.textBox2.TabIndex = 1;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Indigo;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Lucida Sans Unicode", 7.25F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(566, 655);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 38);
            this.button1.TabIndex = 2;
            this.button1.Text = "Enter";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            this.button1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.button1_MouseClick);
            // 
            // mediaPlayer
            // 
            this.mediaPlayer.Enabled = true;
            this.mediaPlayer.Location = new System.Drawing.Point(643, 329);
            this.mediaPlayer.Margin = new System.Windows.Forms.Padding(6);
            this.mediaPlayer.Name = "mediaPlayer";
            this.mediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mediaPlayer.OcxState")));
            this.mediaPlayer.Size = new System.Drawing.Size(10, 10);
            this.mediaPlayer.TabIndex = 3;
            this.mediaPlayer.Visible = false;
            // 
            // rTextBox1
            // 
            this.rTextBox1.BackColor = System.Drawing.Color.Black;
            this.rTextBox1.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rTextBox1.ForeColor = System.Drawing.Color.White;
            this.rTextBox1.Location = new System.Drawing.Point(664, 243);
            this.rTextBox1.Margin = new System.Windows.Forms.Padding(6);
            this.rTextBox1.Name = "rTextBox1";
            this.rTextBox1.ReadOnly = true;
            this.rTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rTextBox1.Size = new System.Drawing.Size(53, 401);
            this.rTextBox1.TabIndex = 4;
            this.rTextBox1.Text = "";
            this.rTextBox1.Visible = false;
            this.rTextBox1.TextChanged += new System.EventHandler(this.rTextBox1_TextChanged);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            this.notifyIcon1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseUp_1);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(156, 76);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(155, 36);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(155, 36);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // minervaResponse
            // 
            this.minervaResponse.BackColor = System.Drawing.Color.Transparent;
            this.minervaResponse.Font = new System.Drawing.Font("Roboto Light", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minervaResponse.ForeColor = System.Drawing.Color.Plum;
            this.minervaResponse.Location = new System.Drawing.Point(0, 0);
            this.minervaResponse.Name = "minervaResponse";
            this.minervaResponse.Size = new System.Drawing.Size(668, 644);
            this.minervaResponse.TabIndex = 6;
            this.minervaResponse.Text = "Hello there. Please enter an item for me to review.";
            // 
            // linkToSomewhereYouSillyJoven
            // 
            this.linkToSomewhereYouSillyJoven.Font = new System.Drawing.Font("Roboto", 10.875F);
            this.linkToSomewhereYouSillyJoven.ForeColor = System.Drawing.Color.Aqua;
            this.linkToSomewhereYouSillyJoven.Location = new System.Drawing.Point(-13, 330);
            this.linkToSomewhereYouSillyJoven.Name = "linkToSomewhereYouSillyJoven";
            this.linkToSomewhereYouSillyJoven.Size = new System.Drawing.Size(695, 36);
            this.linkToSomewhereYouSillyJoven.TabIndex = 8;
            this.linkToSomewhereYouSillyJoven.Text = "Pseudo-LinkLabels, woot!";
            this.linkToSomewhereYouSillyJoven.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkToSomewhereYouSillyJoven.Visible = false;
            this.linkToSomewhereYouSillyJoven.Click += new System.EventHandler(this.linkToSomewhereYouSillyJoven_Click);
            // 
            // itsMinervaWoah
            // 
            this.itsMinervaWoah.Image = global::Minerva.Properties.Resources.Minerva820_1;
            this.itsMinervaWoah.Location = new System.Drawing.Point(4, 0);
            this.itsMinervaWoah.Name = "itsMinervaWoah";
            this.itsMinervaWoah.Size = new System.Drawing.Size(37, 41);
            this.itsMinervaWoah.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.itsMinervaWoah.TabIndex = 7;
            this.itsMinervaWoah.TabStop = false;
            // 
            // gifSection
            // 
            this.gifSection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gifSection.Location = new System.Drawing.Point(0, 0);
            this.gifSection.Name = "gifSection";
            this.gifSection.Size = new System.Drawing.Size(668, 696);
            this.gifSection.TabIndex = 9;
            this.gifSection.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(668, 696);
            this.Controls.Add(this.linkToSomewhereYouSillyJoven);
            this.Controls.Add(this.itsMinervaWoah);
            this.Controls.Add(this.minervaResponse);
            this.Controls.Add(this.rTextBox1);
            this.Controls.Add(this.mediaPlayer);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.gifSection);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Main";
            this.Text = "Minerva";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Shown += new System.EventHandler(this.Main_Shown);
            this.Resize += new System.EventHandler(this.Main_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.itsMinervaWoah)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gifSection)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;
        private AxWMPLib.AxWindowsMediaPlayer mediaPlayer;
        private System.Windows.Forms.RichTextBox rTextBox1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label minervaResponse;
        private System.Windows.Forms.PictureBox itsMinervaWoah;
        private System.Windows.Forms.Label linkToSomewhereYouSillyJoven;
        private System.Windows.Forms.PictureBox gifSection;
    }
}

