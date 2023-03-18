using MySql.Data.MySqlClient;
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
        DataTable dtOrder = new DataTable();
        DataTable dtReminder = new DataTable();
        DataTable dtReportCust = new DataTable();
        DataTable dtReportMenu = new DataTable();
        DataTable dtReportPenjualan = new DataTable();
        public FlowLayoutPanel flowLayoutPanelListOrder = new FlowLayoutPanel();
        public FlowLayoutPanel flowLayoutPanelListOffer = new FlowLayoutPanel();
        public FlowLayoutPanel flowLayoutPanelListReminder = new FlowLayoutPanel();
        public Label invNo = new Label();
        public string simpanDateAwal;
        public string simpanDateAkhir;
        public int x = 2;
        public FormOrder()
        {
            InitializeComponent();
        }

        private void FormOrder_Load(object sender, EventArgs e)
        {
            panel1.Controls.Add(flowLayoutPanelListOrder);
            panel1.Controls.Add(flowLayoutPanelListReminder);
            flowLayoutPanelListOrder.Location = new Point(70, 120);
            flowLayoutPanelListOrder.Size = new Size(1150, 450);
            flowLayoutPanelListReminder.Location = new Point(70, 150);
            flowLayoutPanelListReminder.Size = new Size(1125, 450);
            string sqlQuery = $"SELECT * FROM vListOrder;";
            MySqlCommand sqlCommand = new MySqlCommand(sqlQuery, FormLoad.sqlConnect);
            MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtOrder);
            sqlQuery = $"SELECT * FROM vReminder;";
            sqlCommand = new MySqlCommand(sqlQuery, FormLoad.sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtReminder);
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(FormLoad.CreateRoundRectRgn(0, 0, Width, Height, 70, 70));
            panel1.Region = Region.FromHrgn(FormLoad.CreateRoundRectRgn(0, 0, panel1.Width, panel1.Height, 70, 70));
            listOrder();
            listReminder();
            reportCust();
            reportMenu();
        }
        private void pBoxOrder_Click(object sender, EventArgs e)
        {
            labelTitle.Text = "INCOMING ORDER LIST";
            hide();
            flowLayoutPanelListOrder.Visible = true;
            pBoxInputNewOrder.Visible = true;
            panelWhenClick.Location = new Point(9, 196);
            
        }
        private void pBoxReminder_Click(object sender, EventArgs e)
        {
            if (dtReminder.Rows.Count > 0)
            {
                labelTitle.Text = "REMINDER FOR " + dtReminder.Rows[0][1].ToString();
            }
            else 
            {
                labelTitle.Text = "NO REMINDER FOR TODAY";
            }
            hide();
            flowLayoutPanelListReminder.Visible = true;
            panelWhenClick.Location = new Point(9, 415);
        }

        void Click_updateStatus(object sender, EventArgs e)
        {
            Button newBtn = (Button)sender;
            string sqlQuery = $"UPDATE INVOICE SET STATUS_PAYMENT=1 WHERE INV_NO='" + newBtn.Tag.ToString() + "'; ";
            MySqlCommand sqlCommand = new MySqlCommand(sqlQuery, FormLoad.sqlConnect);
            sqlCommand.ExecuteNonQuery();
            MessageBox.Show("Status Payment has been updated!");
        }

        public void listOrder()
        {

            List<Panel> orderList = new List<Panel>();
            for (int i = 0; i <= dtOrder.Rows.Count - 1; i++)
            {
                Label invNO = new Label();
                invNO.Text = "Invoice No: " + dtOrder.Rows[i][0].ToString();
                invNO.Location = new Point(50, invNO.Location.Y + 15);
                invNO.Size = new Size(600, 20);
                invNO.Font = new Font("Passion One", 15);
                invNO.BackColor = Color.Transparent;
                invNO.ForeColor = Color.White;


                invNo.Text = dtOrder.Rows[i][0].ToString();
                invNo.Location = new Point(50, invNO.Location.Y + 15);
                invNo.Size = new Size(600, 20);
                invNo.Visible = false;
                invNo.Font = new Font("Passion One", 15);
                invNo.BackColor = Color.Transparent;
                invNo.ForeColor = Color.White;
                invNo.Tag = dtOrder.Rows[i][0].ToString();

                Label customerName = new Label();
                customerName.Text = "Customer Name: " + dtOrder.Rows[i][2].ToString();
                customerName.Location = new Point(50, invNO.Location.Y + 30);
                customerName.Size = new Size(600, 20);
                customerName.Font = new Font("Passion One", 15);
                customerName.BackColor = Color.Transparent;
                customerName.ForeColor = Color.White;

                Label statusPayment = new Label();
                Button updateStatus = new Button();
                updateStatus.Name = "btnUpdateStatus" +i;
                if (dtOrder.Rows[i][3].ToString() == "1")
                {
                    statusPayment.Text = "Payment: Paid";
                    updateStatus.Visible = false;
                }
                else
                {
                    statusPayment.Text = "Payment: Pending";
                    updateStatus.Visible = true;
                    updateStatus.Text = "Update Status Payment";
                    updateStatus.Location = new Point(440, invNO.Location.Y + 51);
                    updateStatus.Size = new Size(150, 35);
                    updateStatus.Font = new Font("Passion One", 10);
                    updateStatus.BackColor = Color.FromArgb(247, 193, 75);
                    updateStatus.ForeColor = Color.Black;
                    updateStatus.Region = Region.FromHrgn(FormLoad.CreateRoundRectRgn(0, 0, updateStatus.Width, updateStatus.Height, 25, 25));
                    updateStatus.Tag = dtOrder.Rows[i][0].ToString();
                    updateStatus.Click += new EventHandler(this.Click_updateStatus);
                }
                statusPayment.Location = new Point(50, customerName.Location.Y + 30);
                statusPayment.Size = new Size(600, 20);
                statusPayment.Font = new Font("Passion One", 15);
                statusPayment.BackColor = Color.Transparent;
                statusPayment.ForeColor = Color.White;

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
                tanggalOrder.Size = new Size(600, 20);
                tanggalOrder.Font = new Font("Passion One", 15);
                tanggalOrder.BackColor = Color.Transparent;
                tanggalOrder.ForeColor = Color.Black;

                Panel panelOrderList = new Panel();
                panelOrderList.Size = new Size(610, 115);
                panelOrderList.Name = "panel1" + i;
                orderList.Add(panelOrderList);
                panelOrderList.BackColor = Color.FromArgb(201, 29, 75);

                panelOrderList.Region = Region.FromHrgn(FormLoad.CreateRoundRectRgn(0, 0, panelOrderList.Width, panelOrderList.Height, 70, 70));
                panelOrderList.BringToFront();
                panelOrderList.Controls.Add(invNO);
                panelOrderList.Controls.Add(customerName);
                panelOrderList.Controls.Add(statusPayment);
                panelOrderList.Controls.Add(updateStatus);
                updateStatus.BringToFront();
                panelOrderList.AutoScroll = false;

                Panel panelTanggal = new Panel();
                panelTanggal.Size = new Size(650, 60);
                panelTanggal.Name = "panel" + i;
                orderList.Add(panelTanggal);
                panelTanggal.BackColor = Color.Transparent;
                panelTanggal.Controls.Add(tanggalOrder);
                if (tanggalOrder.Text == "")
                {
                    panelTanggal.Size = new Size(650, 0);
                }
                panelTanggal.AutoScroll = true;

                flowLayoutPanelListOrder.Controls.Add(panelTanggal);
                flowLayoutPanelListOrder.Controls.Add(panelOrderList);
                flowLayoutPanelListOrder.Invalidate();
                flowLayoutPanelListOrder.AutoScroll = true;
            }

        }
        public void listReminder()
        {
            List<Panel> reminderList = new List<Panel>();
            for (int i = 0; i <= dtReminder.Rows.Count - 1; i++)
            {
                Label invNo = new Label();
                invNo.Text = "Invoice No: "+ dtReminder.Rows[i][0].ToString();
                invNo.Location = new Point(50, invNo.Location.Y + 20);
                invNo.Size = new Size(600, 20);
                invNo.Font = new Font("Passion One", 15);
                invNo.BackColor = Color.Transparent;
                invNo.ForeColor = Color.White;

                Label custName = new Label();
                custName.Text = "Customer Name: " + dtReminder.Rows[i][2].ToString();
                custName.Location = new Point(50, invNo.Location.Y + 50);
                custName.Size = new Size(600, 20);
                custName.Font = new Font("Passion One", 15);
                custName.BackColor = Color.Transparent;
                custName.ForeColor = Color.White;

                Label subTotal = new Label();
                subTotal.Text = "Subtotal: " + dtReminder.Rows[i][3].ToString();
                subTotal.Location = new Point(50, invNo.Location.Y + 85);
                subTotal.BringToFront();
                subTotal.Size = new Size(600, 20);
                subTotal.Font = new Font("Passion One", 15);
                subTotal.BackColor = Color.Transparent;
                subTotal.ForeColor = Color.White;

                Panel panelReminderList = new Panel();
                panelReminderList.Size = new Size(650, 150);
                panelReminderList.Name = "panel1" + i;
                reminderList.Add(panelReminderList);
                panelReminderList.BackColor = Color.FromArgb(201, 29, 75);

                panelReminderList.Region = Region.FromHrgn(FormLoad.CreateRoundRectRgn(0, 0, panelReminderList.Width, panelReminderList.Height, 70, 70));
                panelReminderList.BringToFront();
                panelReminderList.Controls.Add(invNo);
                panelReminderList.Controls.Add(custName);
                panelReminderList.Controls.Add(subTotal);
                panelReminderList.AutoScroll = true;

                flowLayoutPanelListReminder.Controls.Add(panelReminderList);
                flowLayoutPanelListReminder.Invalidate();
                flowLayoutPanelListReminder.AutoScroll = true;
            }

        }
        public void hide()
        {
            flowLayoutPanelListOrder.Visible = false;
            flowLayoutPanelListOffer.Visible = false;
            flowLayoutPanelListReminder.Visible = false;
            pBoxInputNewOrder.Visible = false;
            chartCust.Visible = false;
            chartMenu.Visible = false;
            chartPenjualan.Visible = false;
            lblTglAwal.Visible = false;
            lblTglAkhir.Visible = false;
            dtpAwal.Visible = false;
            dtpAkhir.Visible = false;
            btnProcess.Visible = false;
        }

        private void pBoxInputNewOrder_Click(object sender, EventArgs e)
        {
            FormInputOrder form2 = new FormInputOrder();
            form2.Show();
            this.Hide();
        }

        void reportCust()
        {
            chartCust.Titles.Add("Customer Report");
            string sqlQuery = $"SELECT * FROM vReportCust;";
            MySqlCommand sqlCommand = new MySqlCommand(sqlQuery, FormLoad.sqlConnect);
            MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtReportCust);
            chartCust.DataSource = dtReportCust;
            for (int i = 0; i < dtReportCust.Rows.Count; i++)
            {
                chartCust.Series["Series1"].Points.AddXY(dtReportCust.Rows[i][0].ToString(), dtReportCust.Rows[i][1].ToString());
            }     
        }
        void reportMenu()
        {
            chartMenu.Titles.Add("Menu Report");
            string sqlQuery = $"SELECT * FROM vReportMenu;";
            MySqlCommand sqlCommand = new MySqlCommand(sqlQuery, FormLoad.sqlConnect);
            MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtReportMenu);
            chartMenu.DataSource = dtReportMenu;
            for (int i = 0; i < dtReportMenu.Rows.Count; i++)
            {
                chartMenu.Series["Series1"].Points.AddXY(dtReportMenu.Rows[i][0].ToString(), dtReportMenu.Rows[i][1].ToString());
            }
        }

        void reportPenjualan()
        {
            dtReportPenjualan = new DataTable();
            chartPenjualan.Series.Clear();
            chartPenjualan.ChartAreas.Clear();
            chartPenjualan.Titles.Clear();
            chartPenjualan.Titles.Add("Sales Report");
            chartPenjualan.ChartAreas.Add("chartArea"+x);
            chartPenjualan.Series.Add("Series"+x);
            simpanDateAwal = dtpAwal.Value.Date.ToString("yyyy-MM-dd");
            simpanDateAkhir = dtpAkhir.Value.Date.ToString("yyyy-MM-dd");
            string sqlQuery = $"CALL pReportPenjualan(STR_TO_DATE('" + simpanDateAwal + "','%Y-%m-%d'), STR_TO_DATE('" + simpanDateAkhir + "','%Y-%m-%d'));";
            MySqlCommand sqlCommand = new MySqlCommand(sqlQuery, FormLoad.sqlConnect);
            MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtReportPenjualan);
            chartPenjualan.DataSource = dtReportPenjualan;
            for (int i = 0; i < dtReportPenjualan.Rows.Count; i++)
            {
                chartPenjualan.Series["Series"+x].Points.AddXY(dtReportPenjualan.Rows[i][0].ToString(), dtReportPenjualan.Rows[i][1].ToString());

            }
            x++;
        }
        private void pBoxDashboard_Click(object sender, EventArgs e)
        {
            labelTitle.Text = "DASHBOARD";
            hide();
            chartCust.Visible = true;
            chartMenu.Visible = true;
            chartPenjualan.Visible = true;
            lblTglAwal.Visible = true;
            lblTglAkhir.Visible = true;
            dtpAwal.Visible = true;
            dtpAkhir.Visible = true;
            btnProcess.Visible = true;
            panelWhenClick.Location = new Point(9, 310);
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            reportPenjualan();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
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
