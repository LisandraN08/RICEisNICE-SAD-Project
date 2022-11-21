
namespace RICEisNICE_SAD_Project
{
    partial class FormChoosePosition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChoosePosition));
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelChef = new System.Windows.Forms.Label();
            this.labelOwner = new System.Windows.Forms.Label();
            this.panelChef = new System.Windows.Forms.Panel();
            this.panelOwner = new System.Windows.Forms.Panel();
            this.pBoxOwner = new System.Windows.Forms.PictureBox();
            this.pBoxChef = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pBoxExit = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxOwner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxChef)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxExit)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Open Sans Condensed", 55.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(447, 117);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(846, 135);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "CHOOSE YOUR POSITION";
            // 
            // labelChef
            // 
            this.labelChef.AutoSize = true;
            this.labelChef.BackColor = System.Drawing.Color.Transparent;
            this.labelChef.Font = new System.Drawing.Font("Open Sans Condensed", 25.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelChef.ForeColor = System.Drawing.Color.White;
            this.labelChef.Location = new System.Drawing.Point(431, 648);
            this.labelChef.Name = "labelChef";
            this.labelChef.Size = new System.Drawing.Size(101, 62);
            this.labelChef.TabIndex = 3;
            this.labelChef.Text = "CHEF";
            this.labelChef.Click += new System.EventHandler(this.labelChef_Click);
            this.labelChef.MouseLeave += new System.EventHandler(this.labelChef_MouseLeave);
            this.labelChef.MouseHover += new System.EventHandler(this.labelChef_MouseHover);
            // 
            // labelOwner
            // 
            this.labelOwner.AutoSize = true;
            this.labelOwner.BackColor = System.Drawing.Color.Transparent;
            this.labelOwner.Font = new System.Drawing.Font("Open Sans Condensed", 25.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelOwner.ForeColor = System.Drawing.Color.White;
            this.labelOwner.Location = new System.Drawing.Point(913, 648);
            this.labelOwner.Name = "labelOwner";
            this.labelOwner.Size = new System.Drawing.Size(141, 62);
            this.labelOwner.TabIndex = 5;
            this.labelOwner.Text = "OWNER";
            this.labelOwner.Click += new System.EventHandler(this.labelOwner_Click);
            this.labelOwner.MouseLeave += new System.EventHandler(this.labelOwner_MouseLeave);
            this.labelOwner.MouseHover += new System.EventHandler(this.labelOwner_MouseHover);
            // 
            // panelChef
            // 
            this.panelChef.BackColor = System.Drawing.Color.Transparent;
            this.panelChef.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelChef.ForeColor = System.Drawing.Color.Transparent;
            this.panelChef.Location = new System.Drawing.Point(311, 374);
            this.panelChef.Name = "panelChef";
            this.panelChef.Size = new System.Drawing.Size(353, 355);
            this.panelChef.TabIndex = 6;
            this.panelChef.Visible = false;
            this.panelChef.Paint += new System.Windows.Forms.PaintEventHandler(this.panelChef_Paint);
            // 
            // panelOwner
            // 
            this.panelOwner.BackColor = System.Drawing.Color.Transparent;
            this.panelOwner.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelOwner.ForeColor = System.Drawing.Color.Transparent;
            this.panelOwner.Location = new System.Drawing.Point(810, 374);
            this.panelOwner.Name = "panelOwner";
            this.panelOwner.Size = new System.Drawing.Size(353, 355);
            this.panelOwner.TabIndex = 7;
            this.panelOwner.Visible = false;
            this.panelOwner.Paint += new System.Windows.Forms.PaintEventHandler(this.panelOwner_Paint);
            // 
            // pBoxOwner
            // 
            this.pBoxOwner.BackColor = System.Drawing.Color.Transparent;
            this.pBoxOwner.Image = global::RICEisNICE_SAD_Project.Properties.Resources.businessman;
            this.pBoxOwner.Location = new System.Drawing.Point(867, 401);
            this.pBoxOwner.Name = "pBoxOwner";
            this.pBoxOwner.Size = new System.Drawing.Size(244, 244);
            this.pBoxOwner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxOwner.TabIndex = 4;
            this.pBoxOwner.TabStop = false;
            this.pBoxOwner.Click += new System.EventHandler(this.pBoxOwner_Click);
            this.pBoxOwner.MouseLeave += new System.EventHandler(this.pBoxOwner_MouseLeave);
            this.pBoxOwner.MouseHover += new System.EventHandler(this.pBoxOwner_MouseHover);
            // 
            // pBoxChef
            // 
            this.pBoxChef.BackColor = System.Drawing.Color.Transparent;
            this.pBoxChef.Image = global::RICEisNICE_SAD_Project.Properties.Resources.chef;
            this.pBoxChef.Location = new System.Drawing.Point(370, 401);
            this.pBoxChef.Name = "pBoxChef";
            this.pBoxChef.Size = new System.Drawing.Size(244, 244);
            this.pBoxChef.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxChef.TabIndex = 2;
            this.pBoxChef.TabStop = false;
            this.pBoxChef.Click += new System.EventHandler(this.pBoxChef_Click);
            this.pBoxChef.MouseLeave += new System.EventHandler(this.pBoxChef_MouseLeave);
            this.pBoxChef.MouseHover += new System.EventHandler(this.pBoxChef_MouseHover);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(177, -26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(229, 376);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // pBoxExit
            // 
            this.pBoxExit.Image = global::RICEisNICE_SAD_Project.Properties.Resources.close;
            this.pBoxExit.Location = new System.Drawing.Point(45, 45);
            this.pBoxExit.Name = "pBoxExit";
            this.pBoxExit.Size = new System.Drawing.Size(38, 38);
            this.pBoxExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pBoxExit.TabIndex = 10;
            this.pBoxExit.TabStop = false;
            this.pBoxExit.Click += new System.EventHandler(this.pBoxExit_Click);
            // 
            // FormChoosePosition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(37)))), ((int)(((byte)(39)))));
            this.ClientSize = new System.Drawing.Size(1441, 996);
            this.Controls.Add(this.pBoxExit);
            this.Controls.Add(this.labelOwner);
            this.Controls.Add(this.pBoxOwner);
            this.Controls.Add(this.labelChef);
            this.Controls.Add(this.pBoxChef);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panelChef);
            this.Controls.Add(this.panelOwner);
            this.Name = "FormChoosePosition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormChoosePosition";
            this.Load += new System.EventHandler(this.FormChoosePosition_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pBoxOwner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxChef)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pBoxExit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.PictureBox pBoxChef;
        private System.Windows.Forms.Label labelChef;
        private System.Windows.Forms.PictureBox pBoxOwner;
        private System.Windows.Forms.Label labelOwner;
        private System.Windows.Forms.Panel panelChef;
        private System.Windows.Forms.Panel panelOwner;
        private System.Windows.Forms.PictureBox pBoxExit;
    }
}