using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RICEisNICE_SAD_Project
{
    public partial class FormOrder : Form
    {
        public FormOrder()
        {
            InitializeComponent();
        }

        private void FormOrder_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(FormLoad.CreateRoundRectRgn(0, 0, Width, Height, 70, 70));
            panel1.Region = Region.FromHrgn(FormLoad.CreateRoundRectRgn(0, 0, panel1.Width, panel1.Height, 70, 70));
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
