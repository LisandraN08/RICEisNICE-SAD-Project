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
    public partial class FormChoosePosition : Form
    {
        public FormChoosePosition()
        {
            InitializeComponent();
        }

        private void FormChoosePosition_Load(object sender, EventArgs e)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(FormLoad.CreateRoundRectRgn(0, 0, Width, Height, 70, 70));
        }

        private void pBoxChef_MouseHover(object sender, EventArgs e)
        {
            panelChef.Visible = true;
        }

        private void pBoxChef_MouseLeave(object sender, EventArgs e)
        {
            panelChef.Visible = false;
        }
        private void labelChef_MouseHover(object sender, EventArgs e)
        {
            panelChef.Visible = true;
        }

        private void labelChef_MouseLeave(object sender, EventArgs e)
        {
            panelChef.Visible = false;
        }
        private void panelChef_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panelChef.ClientRectangle,
             Color.FromArgb(247, 193, 75), 3, ButtonBorderStyle.Solid, // left
             Color.FromArgb(247, 193, 75), 3, ButtonBorderStyle.Solid, // top
             Color.FromArgb(247, 193, 75), 3, ButtonBorderStyle.Solid, // right
             Color.FromArgb(247, 193, 75), 3, ButtonBorderStyle.Solid);// bottom
        }

        private void pBoxOwner_MouseHover(object sender, EventArgs e)
        {
            panelOwner.Visible = true;
        }

        private void pBoxOwner_MouseLeave(object sender, EventArgs e)
        {
            panelOwner.Visible = false;
        }
        private void labelOwner_MouseHover(object sender, EventArgs e)
        {
            panelOwner.Visible = true;
        }

        private void labelOwner_MouseLeave(object sender, EventArgs e)
        {
            panelOwner.Visible = false;
        }

        private void panelOwner_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, panelOwner.ClientRectangle,
             Color.FromArgb(247, 193, 75), 3, ButtonBorderStyle.Solid, // left
             Color.FromArgb(247, 193, 75), 3, ButtonBorderStyle.Solid, // top
             Color.FromArgb(247, 193, 75), 3, ButtonBorderStyle.Solid, // right
             Color.FromArgb(247, 193, 75), 3, ButtonBorderStyle.Solid);// bottom
        }
        private void pBoxChef_Click(object sender, EventArgs e)
        {
            FormLoginChef form3 = new FormLoginChef();
            form3.Show();
            this.Hide();
        }
        private void labelChef_Click(object sender, EventArgs e)
        {
            FormLoginChef form3 = new FormLoginChef();
            form3.Show();
            this.Hide();
        }

        private void pBoxOwner_Click(object sender, EventArgs e)
        {
            FormLoginOwner form2 = new FormLoginOwner();
            form2.Show();
            this.Hide();
        }
        private void labelOwner_Click(object sender, EventArgs e)
        {
            FormLoginOwner form2 = new FormLoginOwner();
            form2.Show();
            this.Hide();
        }

        private void pBoxExit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
