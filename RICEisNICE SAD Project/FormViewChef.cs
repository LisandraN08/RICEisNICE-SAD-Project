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
    public partial class FormViewChef : Form
    {
        DataTable dtOrder = new DataTable();
        DataTable dtMenu = new DataTable();
        public FlowLayoutPanel FlowLayoutPanelListOrder = new FlowLayoutPanel();
        public List<Label> LabelNamaMenu = new List<Label>();
        public FormViewChef()
        {
            InitializeComponent();
        }

        private void FormViewChef_Load(object sender, EventArgs e)
        {
            panel1.Controls.Add(FlowLayoutPanelListOrder);
            FlowLayoutPanelListOrder.Location = new Point(70, 120);
            FlowLayoutPanelListOrder.Size = new Size(1125, 450);
            FlowLayoutPanelListOrder.Location = new Point(70, 150);
            FlowLayoutPanelListOrder.Size = new Size(1125, 450);
            string sqlQuery = $"SELECT * FROM vListOrder WHERE status = 1;";
            MySqlCommand sqlCommand = new MySqlCommand(sqlQuery, FormLoad.sqlConnect);
            MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtOrder);

            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(FormLoad.CreateRoundRectRgn(0, 0, Width, Height, 70, 70));
            panel1.Region = Region.FromHrgn(FormLoad.CreateRoundRectRgn(0, 0, panel1.Width, panel1.Height, 70, 70));
            listOrder();
        }

        public void listOrder()
        {

            List<Panel> orderList = new List<Panel>();
            for (int i = 0; i <= dtOrder.Rows.Count - 1; i++)
            {
                Label customerName = new Label();
                customerName.Text = "Customer Name: " + dtOrder.Rows[i][2].ToString();
                customerName.Location = new Point(50, customerName.Location.Y + 20);
                customerName.Size = new Size(600, 30);
                customerName.Font = new Font("Passion One", 15);
                customerName.BackColor = Color.Transparent;
                customerName.ForeColor = Color.White;

                dtMenu = new DataTable();
                string sqlQuery = $"SELECT m.MENU_NAME, im.QTY FROM MENU m, INVOICE_MENU im WHERE m.MENU_ID = im.MENU_ID AND im.INV_NO = '"+ dtOrder.Rows[i][0].ToString() + "'; ";
                MySqlCommand sqlCommand = new MySqlCommand(sqlQuery, FormLoad.sqlConnect);
                MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(sqlCommand);
                sqlAdapter.Fill(dtMenu);
                Label namaMenu1 = new Label();
                Label namaMenu2 = new Label();
                Label namaMenu3 = new Label();
                Label namaMenu4 = new Label();
                Label namaMenu5 = new Label();
                if(dtMenu.Rows.Count == 1)
                {
                    namaMenu1.Size = new Size(600, 20);
                    namaMenu1.Text = dtMenu.Rows[0][1].ToString()+" "+ dtMenu.Rows[0][0].ToString();
                    namaMenu1.Location = new Point(45, customerName.Location.Y + 30);
                    namaMenu1.Font = new Font("Passion One", 15);
                    namaMenu1.BackColor = Color.Transparent;
                    namaMenu1.ForeColor = Color.White;
                }
                else if (dtMenu.Rows.Count == 2)
                {
                    namaMenu1.Size = new Size(600, 20);
                    namaMenu1.Text = dtMenu.Rows[0][1].ToString() + " " + dtMenu.Rows[0][0].ToString();
                    namaMenu1.Location = new Point(45, customerName.Location.Y + 30);
                    namaMenu1.Font = new Font("Passion One", 15);
                    namaMenu1.BackColor = Color.Transparent;
                    namaMenu1.ForeColor = Color.White;

                    namaMenu2.Size = new Size(600, 20);
                    namaMenu2.Text = dtMenu.Rows[1][1].ToString() + " " + dtMenu.Rows[1][0].ToString();
                    namaMenu2.Location = new Point(45, customerName.Location.Y + 50);
                    namaMenu2.Font = new Font("Passion One", 15);
                    namaMenu2.BackColor = Color.Transparent;
                    namaMenu2.ForeColor = Color.White;
                }
                else if (dtMenu.Rows.Count == 3)
                {
                    namaMenu1.Size = new Size(600, 20);
                    namaMenu1.Text = dtMenu.Rows[0][1].ToString() + " " + dtMenu.Rows[0][0].ToString();
                    namaMenu1.Location = new Point(45, customerName.Location.Y + 30);
                    namaMenu1.Font = new Font("Passion One", 15);
                    namaMenu1.BackColor = Color.Transparent;
                    namaMenu1.ForeColor = Color.White;

                    namaMenu2.Size = new Size(600, 20);
                    namaMenu2.Text = dtMenu.Rows[1][1].ToString() + " " + dtMenu.Rows[1][0].ToString();
                    namaMenu2.Location = new Point(45, customerName.Location.Y + 50);
                    namaMenu2.Font = new Font("Passion One", 15);
                    namaMenu2.BackColor = Color.Transparent;
                    namaMenu2.ForeColor = Color.White;
                    namaMenu2.Size = new Size(600, 20);

                    namaMenu3.Size = new Size(600, 20);
                    namaMenu3.Text = dtMenu.Rows[2][1].ToString() + " " + dtMenu.Rows[2][0].ToString();
                    namaMenu3.Location = new Point(45, customerName.Location.Y + 65);
                    namaMenu3.Font = new Font("Passion One", 15);
                    namaMenu3.BackColor = Color.Transparent;
                    namaMenu3.ForeColor = Color.White;
                }
                else if (dtMenu.Rows.Count == 4)
                {
                    namaMenu1.Size = new Size(600, 20);
                    namaMenu1.Text = dtMenu.Rows[0][1].ToString() + " " + dtMenu.Rows[0][0].ToString();
                    namaMenu1.Location = new Point(45, customerName.Location.Y + 30);
                    namaMenu1.Font = new Font("Passion One", 15);
                    namaMenu1.BackColor = Color.Transparent;
                    namaMenu1.ForeColor = Color.White;

                    namaMenu2.Size = new Size(600, 20);
                    namaMenu2.Text = dtMenu.Rows[1][1].ToString() + " " + dtMenu.Rows[1][0].ToString();
                    namaMenu2.Location = new Point(45, customerName.Location.Y + 50);
                    namaMenu2.Font = new Font("Passion One", 15);
                    namaMenu2.BackColor = Color.Transparent;
                    namaMenu2.ForeColor = Color.White;
                    namaMenu2.Size = new Size(600, 20);

                    namaMenu3.Size = new Size(600, 20);
                    namaMenu3.Text = dtMenu.Rows[2][1].ToString() + " " + dtMenu.Rows[2][0].ToString();
                    namaMenu3.Location = new Point(45, customerName.Location.Y + 65);
                    namaMenu3.Font = new Font("Passion One", 15);
                    namaMenu3.BackColor = Color.Transparent;
                    namaMenu3.ForeColor = Color.White;

                    namaMenu4.Size = new Size(600, 20);
                    namaMenu4.Text = dtMenu.Rows[3][1].ToString() + " " + dtMenu.Rows[3][0].ToString();
                    namaMenu4.Location = new Point(45, customerName.Location.Y + 80);
                    namaMenu4.Font = new Font("Passion One", 15);
                    namaMenu4.BackColor = Color.Transparent;
                    namaMenu4.ForeColor = Color.White;
                }
                else if (dtMenu.Rows.Count == 5)
                {
                    namaMenu1.Size = new Size(600, 20);
                    namaMenu1.Text = dtMenu.Rows[0][1].ToString() + " " + dtMenu.Rows[0][0].ToString();
                    namaMenu1.Location = new Point(45, customerName.Location.Y + 30);
                    namaMenu1.Font = new Font("Passion One", 15);
                    namaMenu1.BackColor = Color.Transparent;
                    namaMenu1.ForeColor = Color.White;

                    namaMenu2.Size = new Size(600, 20);
                    namaMenu2.Text = dtMenu.Rows[1][1].ToString() + " " + dtMenu.Rows[1][0].ToString();
                    namaMenu2.Location = new Point(45, customerName.Location.Y + 50);
                    namaMenu2.Font = new Font("Passion One", 15);
                    namaMenu2.BackColor = Color.Transparent;
                    namaMenu2.ForeColor = Color.White;
                    namaMenu2.Size = new Size(600, 20);

                    namaMenu3.Size = new Size(600, 20);
                    namaMenu3.Text = dtMenu.Rows[2][1].ToString() + " " + dtMenu.Rows[2][0].ToString();
                    namaMenu3.Location = new Point(45, customerName.Location.Y + 65);
                    namaMenu3.Font = new Font("Passion One", 15);
                    namaMenu3.BackColor = Color.Transparent;
                    namaMenu3.ForeColor = Color.White;

                    namaMenu4.Size = new Size(600, 20);
                    namaMenu4.Text = dtMenu.Rows[3][1].ToString() + " " + dtMenu.Rows[3][0].ToString();
                    namaMenu4.Location = new Point(45, customerName.Location.Y + 80);
                    namaMenu4.Font = new Font("Passion One", 15);
                    namaMenu4.BackColor = Color.Transparent;
                    namaMenu4.ForeColor = Color.White;

                    namaMenu5.Size = new Size(600, 20);
                    namaMenu5.Text = dtMenu.Rows[4][1].ToString() + " " + dtMenu.Rows[4][0].ToString();
                    namaMenu5.Location = new Point(45, customerName.Location.Y + 95);
                    namaMenu5.Font = new Font("Passion One", 15);
                    namaMenu5.BackColor = Color.Transparent;
                    namaMenu5.ForeColor = Color.White;
                }


                Label tanggalOrder = new Label();
                if (i == 0 || dtOrder.Rows[i][1].ToString() != dtOrder.Rows[i - 1][1].ToString())
                {
                    tanggalOrder.Text = dtOrder.Rows[i][1].ToString();
                }
                else
                {
                    tanggalOrder.Text = "";
                }
                tanggalOrder.Location = new Point(50, customerName.Location.Y - 10);
                tanggalOrder.Size = new Size(600, 30);
                tanggalOrder.Font = new Font("Passion One", 15);
                tanggalOrder.BackColor = Color.Transparent;
                tanggalOrder.ForeColor = Color.Black;

                Panel panelOrderList = new Panel();
                panelOrderList.Size = new Size(650, 150);
                panelOrderList.Name = "panel1" + i;
                orderList.Add(panelOrderList);
                panelOrderList.BackColor = Color.FromArgb(201, 29, 75);

                panelOrderList.Region = Region.FromHrgn(FormLoad.CreateRoundRectRgn(0, 0, panelOrderList.Width, panelOrderList.Height, 70, 70));
                panelOrderList.BringToFront();
                panelOrderList.Controls.Add(customerName);
                panelOrderList.Controls.Add(namaMenu1);
                panelOrderList.Controls.Add(namaMenu2);
                panelOrderList.Controls.Add(namaMenu3);
                panelOrderList.Controls.Add(namaMenu4);
                panelOrderList.Controls.Add(namaMenu5);
                panelOrderList.AutoScroll = true;

                Panel panelTanggal = new Panel();
                panelTanggal.Size = new Size(650, 50);
                panelTanggal.Name = "panel" + i;
                orderList.Add(panelTanggal);
                panelTanggal.BackColor = Color.Transparent;
                panelTanggal.Controls.Add(tanggalOrder);
                if (tanggalOrder.Text == "")
                {
                    panelTanggal.Size = new Size(650, 0);
                }
                panelTanggal.AutoScroll = true;

                FlowLayoutPanelListOrder.Controls.Add(panelTanggal);
                FlowLayoutPanelListOrder.Controls.Add(panelOrderList);
                FlowLayoutPanelListOrder.Invalidate();
                FlowLayoutPanelListOrder.AutoScroll = true;
            }
        }

        private void pBoxLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure to log out?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FormChoosePosition form2 = new FormChoosePosition();
                form2.Show();
                this.Hide();
            }
            else
            {
                
            }
        }
    }
}
