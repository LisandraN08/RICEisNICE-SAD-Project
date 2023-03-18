using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace RICEisNICE_SAD_Project
{
    public partial class FormLoginOwner : Form
    {
        DataTable dtEmployee = new DataTable();
        public FormLoginOwner()
        {
            InitializeComponent();
            tBoxPassword.PasswordChar = '*';
            tBoxPassword.MaxLength = 30;
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(FormLoad.CreateRoundRectRgn(0, 0, Width, Height, 70, 70));
            panel1.Region = Region.FromHrgn(FormLoad.CreateRoundRectRgn(0, 0, panel1.Width, panel1.Height, 1000, 1000));
            btnLogin.Region = Region.FromHrgn(FormLoad.CreateRoundRectRgn(0, 0, btnLogin.Width, btnLogin.Height, 20, 20));
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            FormOrder form2 = new FormOrder();
            string sqlQuery = $"SELECT * FROM EMPLOYEE WHERE EMPLOYEE.EMP_LEVEL = 'OWNER';";
            MySqlCommand sqlCommand = new MySqlCommand(sqlQuery, FormLoad.sqlConnect);
            MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtEmployee);
            for (int i = 0; i <= dtEmployee.Rows.Count - 1; i++)
            {
                if (tBoxUsername.Text == dtEmployee.Rows[i][2].ToString() && tBoxPassword.Text == dtEmployee.Rows[i][3].ToString())
                {
                    i = dtEmployee.Rows.Count;
                    form2.Show();
                    this.Hide();
                }
                else if (i < dtEmployee.Rows.Count - 1)
                {
                    i++;
                }
                else
                {
                    MessageBox.Show("Wrong username or password! Please try again.");
                }
            }


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void FormLoginOwner_Load(object sender, EventArgs e)
        {

        }
    }
}
