namespace Elec
{
    partial class Main
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.comPortHandler = new System.IO.Ports.SerialPort(this.components);
            this.closeGuna2Button = new Guna.UI2.WinForms.Guna2Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comPortGuna2Button = new Guna.UI2.WinForms.Guna2Button();
            this.textComGuna2TextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.logsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.sendPortGuna2Button = new Guna.UI2.WinForms.Guna2Button();
            this.label3 = new System.Windows.Forms.Label();
            this.comPortGuna2ComboBox = new Guna.UI2.WinForms.Guna2ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.guna2GroupBox1 = new Guna.UI2.WinForms.Guna2GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.baudsGuna2TextBox = new Guna.UI2.WinForms.Guna2TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.guna2GroupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // comPortHandler
            // 
            this.comPortHandler.DtrEnable = true;
            this.comPortHandler.RtsEnable = true;
            this.comPortHandler.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.comPortHandler_DataReceived);
            // 
            // closeGuna2Button
            // 
            this.closeGuna2Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.closeGuna2Button.Animated = true;
            this.closeGuna2Button.CheckedState.Parent = this.closeGuna2Button;
            this.closeGuna2Button.CustomImages.Parent = this.closeGuna2Button;
            this.closeGuna2Button.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.closeGuna2Button.ForeColor = System.Drawing.Color.White;
            this.closeGuna2Button.HoverState.Parent = this.closeGuna2Button;
            this.closeGuna2Button.Location = new System.Drawing.Point(1144, 0);
            this.closeGuna2Button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.closeGuna2Button.Name = "closeGuna2Button";
            this.closeGuna2Button.ShadowDecoration.Parent = this.closeGuna2Button;
            this.closeGuna2Button.Size = new System.Drawing.Size(32, 32);
            this.closeGuna2Button.TabIndex = 3;
            this.closeGuna2Button.Text = "╳";
            this.closeGuna2Button.Click += new System.EventHandler(this.closeGuna2Button_Click);
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label1.Location = new System.Drawing.Point(4, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 36);
            this.label1.TabIndex = 5;
            this.label1.Text = "COM Port:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comPortGuna2Button
            // 
            this.comPortGuna2Button.Animated = true;
            this.comPortGuna2Button.CheckedState.Parent = this.comPortGuna2Button;
            this.comPortGuna2Button.CustomImages.Parent = this.comPortGuna2Button;
            this.comPortGuna2Button.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.comPortGuna2Button.ForeColor = System.Drawing.Color.White;
            this.comPortGuna2Button.HoverState.Parent = this.comPortGuna2Button;
            this.comPortGuna2Button.Location = new System.Drawing.Point(4, 138);
            this.comPortGuna2Button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comPortGuna2Button.Name = "comPortGuna2Button";
            this.comPortGuna2Button.ShadowDecoration.Parent = this.comPortGuna2Button;
            this.comPortGuna2Button.Size = new System.Drawing.Size(286, 36);
            this.comPortGuna2Button.TabIndex = 7;
            this.comPortGuna2Button.Text = "Connect !";
            this.comPortGuna2Button.Click += new System.EventHandler(this.comPortGuna2Button_Click);
            // 
            // textComGuna2TextBox
            // 
            this.textComGuna2TextBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.textComGuna2TextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.textComGuna2TextBox.DefaultText = "";
            this.textComGuna2TextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.textComGuna2TextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.textComGuna2TextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textComGuna2TextBox.DisabledState.Parent = this.textComGuna2TextBox;
            this.textComGuna2TextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.textComGuna2TextBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.textComGuna2TextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textComGuna2TextBox.FocusedState.Parent = this.textComGuna2TextBox;
            this.textComGuna2TextBox.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.textComGuna2TextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.textComGuna2TextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.textComGuna2TextBox.HoverState.Parent = this.textComGuna2TextBox;
            this.textComGuna2TextBox.Location = new System.Drawing.Point(6, 264);
            this.textComGuna2TextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textComGuna2TextBox.Name = "textComGuna2TextBox";
            this.textComGuna2TextBox.PasswordChar = '\0';
            this.textComGuna2TextBox.PlaceholderText = "";
            this.textComGuna2TextBox.SelectedText = "";
            this.textComGuna2TextBox.ShadowDecoration.Parent = this.textComGuna2TextBox;
            this.textComGuna2TextBox.Size = new System.Drawing.Size(294, 36);
            this.textComGuna2TextBox.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label2.Location = new System.Drawing.Point(10, 228);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 36);
            this.label2.TabIndex = 10;
            this.label2.Text = "Write to COM Port:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // logsRichTextBox
            // 
            this.logsRichTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.logsRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.logsRichTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logsRichTextBox.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logsRichTextBox.Location = new System.Drawing.Point(2, 2);
            this.logsRichTextBox.Name = "logsRichTextBox";
            this.logsRichTextBox.ReadOnly = true;
            this.logsRichTextBox.Size = new System.Drawing.Size(863, 465);
            this.logsRichTextBox.TabIndex = 11;
            this.logsRichTextBox.Text = "";
            // 
            // sendPortGuna2Button
            // 
            this.sendPortGuna2Button.Animated = true;
            this.sendPortGuna2Button.CheckedState.Parent = this.sendPortGuna2Button;
            this.sendPortGuna2Button.CustomImages.Parent = this.sendPortGuna2Button;
            this.sendPortGuna2Button.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.sendPortGuna2Button.ForeColor = System.Drawing.Color.White;
            this.sendPortGuna2Button.HoverState.Parent = this.sendPortGuna2Button;
            this.sendPortGuna2Button.Location = new System.Drawing.Point(6, 310);
            this.sendPortGuna2Button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sendPortGuna2Button.Name = "sendPortGuna2Button";
            this.sendPortGuna2Button.ShadowDecoration.Parent = this.sendPortGuna2Button;
            this.sendPortGuna2Button.Size = new System.Drawing.Size(294, 36);
            this.sendPortGuna2Button.TabIndex = 12;
            this.sendPortGuna2Button.Text = "Send !";
            this.sendPortGuna2Button.Click += new System.EventHandler(this.sendPortGuna2Button_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label3.Location = new System.Drawing.Point(307, 38);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(543, 40);
            this.label3.TabIndex = 13;
            this.label3.Text = "Logs:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comPortGuna2ComboBox
            // 
            this.comPortGuna2ComboBox.BackColor = System.Drawing.Color.Transparent;
            this.comPortGuna2ComboBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.comPortGuna2ComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.comPortGuna2ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comPortGuna2ComboBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.comPortGuna2ComboBox.FocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comPortGuna2ComboBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.comPortGuna2ComboBox.FocusedState.Parent = this.comPortGuna2ComboBox;
            this.comPortGuna2ComboBox.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.comPortGuna2ComboBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.comPortGuna2ComboBox.HoverState.Parent = this.comPortGuna2ComboBox;
            this.comPortGuna2ComboBox.ItemHeight = 30;
            this.comPortGuna2ComboBox.ItemsAppearance.Parent = this.comPortGuna2ComboBox;
            this.comPortGuna2ComboBox.Location = new System.Drawing.Point(88, 46);
            this.comPortGuna2ComboBox.Name = "comPortGuna2ComboBox";
            this.comPortGuna2ComboBox.ShadowDecoration.Parent = this.comPortGuna2ComboBox;
            this.comPortGuna2ComboBox.Size = new System.Drawing.Size(203, 36);
            this.comPortGuna2ComboBox.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label4.Location = new System.Drawing.Point(42, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(1094, 32);
            this.label4.TabIndex = 15;
            this.label4.Text = "Elec 2T TEAM C COM Binder";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.label4_MouseDown);
            // 
            // guna2GroupBox1
            // 
            this.guna2GroupBox1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.guna2GroupBox1.Controls.Add(this.label5);
            this.guna2GroupBox1.Controls.Add(this.baudsGuna2TextBox);
            this.guna2GroupBox1.Controls.Add(this.comPortGuna2ComboBox);
            this.guna2GroupBox1.Controls.Add(this.label1);
            this.guna2GroupBox1.Controls.Add(this.comPortGuna2Button);
            this.guna2GroupBox1.CustomBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.guna2GroupBox1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.guna2GroupBox1.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.guna2GroupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.guna2GroupBox1.Location = new System.Drawing.Point(6, 38);
            this.guna2GroupBox1.Name = "guna2GroupBox1";
            this.guna2GroupBox1.ShadowDecoration.Parent = this.guna2GroupBox1;
            this.guna2GroupBox1.Size = new System.Drawing.Size(294, 187);
            this.guna2GroupBox1.TabIndex = 17;
            this.guna2GroupBox1.Text = "Settings";
            // 
            // label5
            // 
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label5.Location = new System.Drawing.Point(4, 90);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 36);
            this.label5.TabIndex = 19;
            this.label5.Text = "Bauds:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // baudsGuna2TextBox
            // 
            this.baudsGuna2TextBox.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.baudsGuna2TextBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.baudsGuna2TextBox.DefaultText = "115200";
            this.baudsGuna2TextBox.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.baudsGuna2TextBox.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.baudsGuna2TextBox.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.baudsGuna2TextBox.DisabledState.Parent = this.baudsGuna2TextBox;
            this.baudsGuna2TextBox.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.baudsGuna2TextBox.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.baudsGuna2TextBox.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.baudsGuna2TextBox.FocusedState.Parent = this.baudsGuna2TextBox;
            this.baudsGuna2TextBox.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.baudsGuna2TextBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.baudsGuna2TextBox.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.baudsGuna2TextBox.HoverState.Parent = this.baudsGuna2TextBox;
            this.baudsGuna2TextBox.Location = new System.Drawing.Point(88, 92);
            this.baudsGuna2TextBox.Margin = new System.Windows.Forms.Padding(5, 7, 5, 7);
            this.baudsGuna2TextBox.Name = "baudsGuna2TextBox";
            this.baudsGuna2TextBox.PasswordChar = '\0';
            this.baudsGuna2TextBox.PlaceholderText = "";
            this.baudsGuna2TextBox.SelectedText = "";
            this.baudsGuna2TextBox.SelectionStart = 6;
            this.baudsGuna2TextBox.ShadowDecoration.Parent = this.baudsGuna2TextBox;
            this.baudsGuna2TextBox.Size = new System.Drawing.Size(203, 34);
            this.baudsGuna2TextBox.TabIndex = 18;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.label6.Location = new System.Drawing.Point(0, 554);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(315, 15);
            this.label6.TabIndex = 18;
            this.label6.Text = "Created by M. Godefroid as linking app for raspberry pico !";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.panel1.Controls.Add(this.logsRichTextBox);
            this.panel1.Location = new System.Drawing.Point(307, 84);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(2);
            this.panel1.Size = new System.Drawing.Size(867, 469);
            this.panel1.TabIndex = 19;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::Elec.Properties.Resources.shell32_13;
            this.pictureBox1.Location = new System.Drawing.Point(3, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(1180, 574);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.guna2GroupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sendPortGuna2Button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textComGuna2TextBox);
            this.Controls.Add(this.closeGuna2Button);
            this.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Main";
            this.Padding = new System.Windows.Forms.Padding(3, 32, 3, 3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Elec 2T TEAM C";
            this.Load += new System.EventHandler(this.Main_Load);
            this.guna2GroupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort comPortHandler;
        private Guna.UI2.WinForms.Guna2Button closeGuna2Button;
        private System.Windows.Forms.Label label1;
        private Guna.UI2.WinForms.Guna2Button comPortGuna2Button;
        private Guna.UI2.WinForms.Guna2TextBox textComGuna2TextBox;
        private System.Windows.Forms.Label label2;
        private Guna.UI2.WinForms.Guna2Button sendPortGuna2Button;
        private System.Windows.Forms.Label label3;
        private Guna.UI2.WinForms.Guna2ComboBox comPortGuna2ComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private Guna.UI2.WinForms.Guna2GroupBox guna2GroupBox1;
        private System.Windows.Forms.Label label5;
        private Guna.UI2.WinForms.Guna2TextBox baudsGuna2TextBox;
        private System.Windows.Forms.Label label6;
        internal System.Windows.Forms.RichTextBox logsRichTextBox;
        private System.Windows.Forms.Panel panel1;
    }
}

