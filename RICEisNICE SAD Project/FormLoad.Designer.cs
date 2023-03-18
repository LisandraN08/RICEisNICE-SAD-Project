
namespace RICEisNICE_SAD_Project
{
    partial class FormLoad
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLoad));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.LogoRICEisNICE = new System.Windows.Forms.PictureBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.LogoRICEisNICE)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // LogoRICEisNICE
            // 
            this.LogoRICEisNICE.BackColor = System.Drawing.Color.Transparent;
            this.LogoRICEisNICE.Image = global::RICEisNICE_SAD_Project.Properties.Resources._150741_removebg_preview1;
            this.LogoRICEisNICE.InitialImage = ((System.Drawing.Image)(resources.GetObject("LogoRICEisNICE.InitialImage")));
            this.LogoRICEisNICE.Location = new System.Drawing.Point(542, 145);
            this.LogoRICEisNICE.Name = "LogoRICEisNICE";
            this.LogoRICEisNICE.Size = new System.Drawing.Size(344, 532);
            this.LogoRICEisNICE.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LogoRICEisNICE.TabIndex = 0;
            this.LogoRICEisNICE.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(193)))), ((int)(((byte)(75)))));
            this.progressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(193)))), ((int)(((byte)(75)))));
            this.progressBar1.Location = new System.Drawing.Point(437, 683);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(540, 31);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 2;
            // 
            // FormLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(37)))), ((int)(((byte)(39)))));
            this.ClientSize = new System.Drawing.Size(1441, 996);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.LogoRICEisNICE);
            this.MaximizeBox = false;
            this.Name = "FormLoad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormLoad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LogoRICEisNICE)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox LogoRICEisNICE;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}

