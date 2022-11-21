using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace RICEisNICE_SAD_Project
{
    public partial class FormLoad : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        public static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // height of ellipse
            int nHeightEllipse // width of ellipse
        );

        public FormLoad()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 70, 70));
            progressBar1.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, progressBar1.Width, progressBar1.Height, 30, 30));
        }
        private void FormLoad_Load(object sender, EventArgs e)
        {
            timer1.Start();
            progressBar1.BackColor = Color.FromArgb(247, 193, 75);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                progressBar1.ForeColor = Color.FromArgb(201, 29, 75);
                if (progressBar1.Value != 100)
                {
                    progressBar1.Value += 5;
                }
                else
                {
                    timer1.Stop();
                    FormChoosePosition form2 = new FormChoosePosition();
                    form2.Show();
                    this.Hide();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
