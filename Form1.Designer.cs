namespace XML_Editor
{
    partial class Form1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblpath = new System.Windows.Forms.Label();
            this.btnOpen = new ePOSOne.btnProduct.Button_WOC();
            this.label1 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnpretty = new System.Windows.Forms.Button();
            this.btnshow = new System.Windows.Forms.Button();
            this.btncheck = new System.Windows.Forms.Button();
            this.btnDecompress = new System.Windows.Forms.Button();
            this.btnminify = new System.Windows.Forms.Button();
            this.btnconvert = new System.Windows.Forms.Button();
            this.btnCompress = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.jsoncheckbox = new System.Windows.Forms.RadioButton();
            this.xmlcheckbox = new System.Windows.Forms.RadioButton();
            this.lblerror = new System.Windows.Forms.Label();
            this.lblconsistency = new System.Windows.Forms.Label();
            this.errorlist = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.lblpath);
            this.panel1.Controls.Add(this.btnOpen);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1054, 131);
            this.panel1.TabIndex = 6;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(12, 137);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 150);
            this.panel2.TabIndex = 7;
            // 
            // lblpath
            // 
            this.lblpath.AutoSize = true;
            this.lblpath.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblpath.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblpath.Location = new System.Drawing.Point(94, 86);
            this.lblpath.Name = "lblpath";
            this.lblpath.Size = new System.Drawing.Size(115, 20);
            this.lblpath.TabIndex = 8;
            this.lblpath.Text = "Path of the file";
            // 
            // btnOpen
            // 
            this.btnOpen.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.btnOpen.ButtonColor = System.Drawing.Color.MidnightBlue;
            this.btnOpen.FlatAppearance.BorderSize = 0;
            this.btnOpen.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnOpen.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpen.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpen.Location = new System.Drawing.Point(312, 23);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.OnHoverBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnOpen.OnHoverButtonColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnOpen.OnHoverTextColor = System.Drawing.Color.LightSkyBlue;
            this.btnOpen.Size = new System.Drawing.Size(125, 50);
            this.btnOpen.TabIndex = 7;
            this.btnOpen.Text = "Open File";
            this.btnOpen.TextColor = System.Drawing.Color.White;
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.button_WOC6_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(75, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 28);
            this.label1.TabIndex = 7;
            this.label1.Text = "Enter the XML file";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panel3.Controls.Add(this.btnpretty);
            this.panel3.Controls.Add(this.btnshow);
            this.panel3.Controls.Add(this.btncheck);
            this.panel3.Controls.Add(this.btnDecompress);
            this.panel3.Controls.Add(this.btnminify);
            this.panel3.Controls.Add(this.btnconvert);
            this.panel3.Controls.Add(this.btnCompress);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 131);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(238, 487);
            this.panel3.TabIndex = 7;
            // 
            // btnpretty
            // 
            this.btnpretty.FlatAppearance.BorderSize = 0;
            this.btnpretty.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnpretty.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnpretty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnpretty.Location = new System.Drawing.Point(0, 162);
            this.btnpretty.Name = "btnpretty";
            this.btnpretty.Size = new System.Drawing.Size(238, 51);
            this.btnpretty.TabIndex = 3;
            this.btnpretty.Text = "Prettifying";
            this.btnpretty.UseVisualStyleBackColor = true;
            this.btnpretty.Click += new System.EventHandler(this.btnpretty_Click);
            // 
            // btnshow
            // 
            this.btnshow.FlatAppearance.BorderSize = 0;
            this.btnshow.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnshow.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnshow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnshow.Location = new System.Drawing.Point(3, 105);
            this.btnshow.Name = "btnshow";
            this.btnshow.Size = new System.Drawing.Size(238, 54);
            this.btnshow.TabIndex = 1;
            this.btnshow.Text = "Show, Solve Errors";
            this.btnshow.UseVisualStyleBackColor = true;
            this.btnshow.Click += new System.EventHandler(this.btnshow_Click);
            // 
            // btncheck
            // 
            this.btncheck.FlatAppearance.BorderSize = 0;
            this.btncheck.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btncheck.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btncheck.Location = new System.Drawing.Point(0, 51);
            this.btncheck.Name = "btncheck";
            this.btncheck.Size = new System.Drawing.Size(238, 48);
            this.btncheck.TabIndex = 0;
            this.btncheck.Text = "Check Consistency";
            this.btncheck.UseVisualStyleBackColor = true;
            this.btncheck.Click += new System.EventHandler(this.btncheck_Click);
            // 
            // btnDecompress
            // 
            this.btnDecompress.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnDecompress.FlatAppearance.BorderSize = 0;
            this.btnDecompress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDecompress.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecompress.ForeColor = System.Drawing.Color.White;
            this.btnDecompress.Location = new System.Drawing.Point(0, 340);
            this.btnDecompress.Name = "btnDecompress";
            this.btnDecompress.Size = new System.Drawing.Size(238, 55);
            this.btnDecompress.TabIndex = 4;
            this.btnDecompress.Text = "Decompress";
            this.btnDecompress.UseVisualStyleBackColor = false;
            this.btnDecompress.Click += new System.EventHandler(this.btnDecompress_Click);
            // 
            // btnminify
            // 
            this.btnminify.FlatAppearance.BorderSize = 0;
            this.btnminify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnminify.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnminify.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnminify.Location = new System.Drawing.Point(0, 0);
            this.btnminify.Name = "btnminify";
            this.btnminify.Size = new System.Drawing.Size(238, 45);
            this.btnminify.TabIndex = 1;
            this.btnminify.Text = "Minifying";
            this.btnminify.UseVisualStyleBackColor = true;
            this.btnminify.Click += new System.EventHandler(this.btnminify_Click);
            // 
            // btnconvert
            // 
            this.btnconvert.FlatAppearance.BorderSize = 0;
            this.btnconvert.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnconvert.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnconvert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.btnconvert.Location = new System.Drawing.Point(0, 223);
            this.btnconvert.Name = "btnconvert";
            this.btnconvert.Size = new System.Drawing.Size(235, 53);
            this.btnconvert.TabIndex = 2;
            this.btnconvert.Text = "Convert To JSON";
            this.btnconvert.UseVisualStyleBackColor = true;
            this.btnconvert.Click += new System.EventHandler(this.btnconvert_Click);
            // 
            // btnCompress
            // 
            this.btnCompress.BackColor = System.Drawing.Color.MidnightBlue;
            this.btnCompress.FlatAppearance.BorderSize = 0;
            this.btnCompress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCompress.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCompress.ForeColor = System.Drawing.Color.White;
            this.btnCompress.Location = new System.Drawing.Point(0, 282);
            this.btnCompress.Name = "btnCompress";
            this.btnCompress.Size = new System.Drawing.Size(238, 58);
            this.btnCompress.TabIndex = 3;
            this.btnCompress.Text = "Compress";
            this.btnCompress.UseVisualStyleBackColor = false;
            this.btnCompress.Click += new System.EventHandler(this.button4_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.MidnightBlue;
            this.panel4.Controls.Add(this.jsoncheckbox);
            this.panel4.Controls.Add(this.xmlcheckbox);
            this.panel4.Location = new System.Drawing.Point(2, 394);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(238, 56);
            this.panel4.TabIndex = 11;
            // 
            // jsoncheckbox
            // 
            this.jsoncheckbox.AutoSize = true;
            this.jsoncheckbox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.jsoncheckbox.Location = new System.Drawing.Point(122, 8);
            this.jsoncheckbox.Name = "jsoncheckbox";
            this.jsoncheckbox.Size = new System.Drawing.Size(92, 32);
            this.jsoncheckbox.TabIndex = 11;
            this.jsoncheckbox.TabStop = true;
            this.jsoncheckbox.Text = "JSON";
            this.jsoncheckbox.UseVisualStyleBackColor = true;
            // 
            // xmlcheckbox
            // 
            this.xmlcheckbox.AutoSize = true;
            this.xmlcheckbox.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.xmlcheckbox.Location = new System.Drawing.Point(19, 7);
            this.xmlcheckbox.Name = "xmlcheckbox";
            this.xmlcheckbox.Size = new System.Drawing.Size(76, 32);
            this.xmlcheckbox.TabIndex = 12;
            this.xmlcheckbox.TabStop = true;
            this.xmlcheckbox.Text = "XML";
            this.xmlcheckbox.UseVisualStyleBackColor = true;
            // 
            // lblerror
            // 
            this.lblerror.AutoSize = true;
            this.lblerror.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblerror.Location = new System.Drawing.Point(585, 215);
            this.lblerror.Name = "lblerror";
            this.lblerror.Size = new System.Drawing.Size(106, 28);
            this.lblerror.TabIndex = 9;
            this.lblerror.Text = "Error List";
            // 
            // lblconsistency
            // 
            this.lblconsistency.AutoSize = true;
            this.lblconsistency.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblconsistency.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lblconsistency.Location = new System.Drawing.Point(504, 146);
            this.lblconsistency.Name = "lblconsistency";
            this.lblconsistency.Size = new System.Drawing.Size(254, 33);
            this.lblconsistency.TabIndex = 9;
            this.lblconsistency.Text = "Result of Consistancy";
            // 
            // errorlist
            // 
            this.errorlist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(79)))), ((int)(((byte)(99)))));
            this.errorlist.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.errorlist.ForeColor = System.Drawing.SystemColors.Menu;
            this.errorlist.Location = new System.Drawing.Point(268, 273);
            this.errorlist.Multiline = true;
            this.errorlist.Name = "errorlist";
            this.errorlist.ReadOnly = true;
            this.errorlist.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.errorlist.Size = new System.Drawing.Size(760, 308);
            this.errorlist.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1054, 618);
            this.Controls.Add(this.errorlist);
            this.Controls.Add(this.lblconsistency);
            this.Controls.Add(this.lblerror);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XML Editor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private ePOSOne.btnProduct.Button_WOC btnOpen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblpath;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnDecompress;
        private System.Windows.Forms.Button btnCompress;
        private System.Windows.Forms.Button btnconvert;
        private System.Windows.Forms.Button btnshow;
        private System.Windows.Forms.Button btncheck;
        private System.Windows.Forms.Label lblerror;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lblconsistency;
        private System.Windows.Forms.Button btnminify;
        private System.Windows.Forms.TextBox errorlist;
        private System.Windows.Forms.Button btnpretty;
        private System.Windows.Forms.RadioButton jsoncheckbox;
        private System.Windows.Forms.RadioButton xmlcheckbox;
    }
}

