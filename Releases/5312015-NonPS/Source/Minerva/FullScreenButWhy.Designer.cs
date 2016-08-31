namespace Minerva
{
    partial class FullScreenButWhy
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FullScreenButWhy));
            this.panel1 = new System.Windows.Forms.Panel();
            this.mediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            this.rTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.linkToSomewhereYouSillyJoven = new System.Windows.Forms.Label();
            this.minervaResponse = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::Minerva.Properties.Resources.TheOpacityIsAlmostReal;
            this.panel1.Controls.Add(this.mediaPlayer);
            this.panel1.Controls.Add(this.rTextBox1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.linkToSomewhereYouSillyJoven);
            this.panel1.Controls.Add(this.minervaResponse);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Location = new System.Drawing.Point(-5, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1605, 899);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // mediaPlayer
            // 
            this.mediaPlayer.Enabled = true;
            this.mediaPlayer.Location = new System.Drawing.Point(795, 445);
            this.mediaPlayer.Margin = new System.Windows.Forms.Padding(6);
            this.mediaPlayer.Name = "mediaPlayer";
            this.mediaPlayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mediaPlayer.OcxState")));
            this.mediaPlayer.Size = new System.Drawing.Size(10, 10);
            this.mediaPlayer.TabIndex = 13;
            this.mediaPlayer.Visible = false;
            // 
            // rTextBox1
            // 
            this.rTextBox1.BackColor = System.Drawing.Color.Black;
            this.rTextBox1.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rTextBox1.ForeColor = System.Drawing.Color.White;
            this.rTextBox1.Location = new System.Drawing.Point(1606, 162);
            this.rTextBox1.Margin = new System.Windows.Forms.Padding(6);
            this.rTextBox1.Name = "rTextBox1";
            this.rTextBox1.ReadOnly = true;
            this.rTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rTextBox1.Size = new System.Drawing.Size(53, 401);
            this.rTextBox1.TabIndex = 12;
            this.rTextBox1.Text = "";
            this.rTextBox1.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Indigo;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Lucida Sans Unicode", 7.25F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1611, 111);
            this.button1.Margin = new System.Windows.Forms.Padding(6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 38);
            this.button1.TabIndex = 11;
            this.button1.Text = "Enter";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // linkToSomewhereYouSillyJoven
            // 
            this.linkToSomewhereYouSillyJoven.Font = new System.Drawing.Font("Wasco Sans", 10.875F);
            this.linkToSomewhereYouSillyJoven.ForeColor = System.Drawing.Color.Aqua;
            this.linkToSomewhereYouSillyJoven.Location = new System.Drawing.Point(453, 459);
            this.linkToSomewhereYouSillyJoven.Name = "linkToSomewhereYouSillyJoven";
            this.linkToSomewhereYouSillyJoven.Size = new System.Drawing.Size(695, 36);
            this.linkToSomewhereYouSillyJoven.TabIndex = 10;
            this.linkToSomewhereYouSillyJoven.Text = "Pseudo-LinkLabels, woot!";
            this.linkToSomewhereYouSillyJoven.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linkToSomewhereYouSillyJoven.Visible = false;
            // 
            // minervaResponse
            // 
            this.minervaResponse.Font = new System.Drawing.Font("Roboto Medium", 19.875F);
            this.minervaResponse.ForeColor = System.Drawing.Color.MediumOrchid;
            this.minervaResponse.Location = new System.Drawing.Point(12, 128);
            this.minervaResponse.Name = "minervaResponse";
            this.minervaResponse.Size = new System.Drawing.Size(1560, 746);
            this.minervaResponse.TabIndex = 9;
            this.minervaResponse.Text = "Hello there. Please enter an item for me to review.";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox2.BackColor = System.Drawing.Color.Black;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Roboto Medium", 16.125F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.Gainsboro;
            this.textBox2.Location = new System.Drawing.Point(26, 33);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(1561, 57);
            this.textBox2.TabIndex = 0;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.textBox2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox2_KeyDown);
            // 
            // FullScreenButWhy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 26F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::Minerva.Properties.Resources.Minerva820_Silver;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1600, 900);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Ubuntu", 7.875F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FullScreenButWhy";
            this.Text = "FullScreenButWhy";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mediaPlayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label linkToSomewhereYouSillyJoven;
        private System.Windows.Forms.Label minervaResponse;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RichTextBox rTextBox1;
        private AxWMPLib.AxWindowsMediaPlayer mediaPlayer;
    }
}