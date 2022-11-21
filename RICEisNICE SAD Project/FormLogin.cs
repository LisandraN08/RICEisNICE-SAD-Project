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
    public partial class FormLoginOwner : Form
    {
        public FormLoginOwner()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(FormLoad.CreateRoundRectRgn(0, 0, Width, Height, 70, 70));
            panel1.Region = Region.FromHrgn(FormLoad.CreateRoundRectRgn(0, 0, panel1.Width, panel1.Height, 1000, 1000));
            btnLogin.Region = Region.FromHrgn(FormLoad.CreateRoundRectRgn(0, 0, btnLogin.Width, btnLogin.Height, 20, 20));
            btnSignUp.Region = Region.FromHrgn(FormLoad.CreateRoundRectRgn(0, 0, btnSignUp.Width, btnSignUp.Height, 20, 20));
        }

        private void lblLogIn_Click(object sender, EventArgs e)
        {
            garisLogin.Visible = true;
            garisSignUp.Visible = false;
            btnSignUp.Visible = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            FormOrder form2 = new FormOrder();
            form2.Show();
            this.Hide();
        }

        private void lblSignUp_Click(object sender, EventArgs e)
        {
            garisSignUp.Visible = true;
            garisLogin.Visible = false;
            btnSignUp.Visible = true;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}
