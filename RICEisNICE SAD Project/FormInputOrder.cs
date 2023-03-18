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
using System.IO;

namespace RICEisNICE_SAD_Project
{
    public partial class FormInputOrder : Form
    {
        DataTable dtMenu = new DataTable();
        DataTable dtCust = new DataTable();
        public FlowLayoutPanel FlowLayoutPanelInputOrder = new FlowLayoutPanel();
        public FlowLayoutPanel FlowLayoutPanelCartOrder = new FlowLayoutPanel();
        public List<Panel> MenuList = new List<Panel>();
        public List<Panel> CartList = new List<Panel>();
        public List<Label> LabelMenuList = new List<Label>();
        public List<string> MenuDesc = new List<string>();
        public List<int> PriceList = new List<int>();
        public List<int> PriceperMenu = new List<int>();
        public List<NumericUpDown> NumericUpDownList = new List<NumericUpDown>();
        public Label inputNewCust = new Label();
        public Label Subtotal = new Label();
        public int totalMenu = 0;
        public int sumSubtotal;
        public string simpanDate;
        public int simpanDiskon;
        public FormInputOrder()
        {
            InitializeComponent();
        }

        private void FormInputOrder_Load(object sender, EventArgs e)
        {
            panel1.Controls.Add(FlowLayoutPanelInputOrder);
            FlowLayoutPanelInputOrder.Location = new Point(70, 140);
            FlowLayoutPanelInputOrder.Size = new Size(1125, 450);
            panel1.Controls.Add(FlowLayoutPanelCartOrder);
            FlowLayoutPanelCartOrder.Location = new Point(70, 160);
            FlowLayoutPanelCartOrder.Size = new Size(1125, 200);
            FlowLayoutPanelCartOrder.Visible = false;
            string sqlQuery = $"SELECT m.MENU_IMAGE as 'Menu Image', m.MENU_NAME as 'Menu Name', m.MENU_PRICE FROM MENU m GROUP BY m.MENU_ID;";
            MySqlCommand sqlCommand = new MySqlCommand(sqlQuery, FormLoad.sqlConnect);
            MySqlDataAdapter sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtMenu);
            sqlQuery = $"SELECT CUST_NAME FROM CUSTOMER GROUP BY CUST_ID;";
            sqlCommand = new MySqlCommand(sqlQuery, FormLoad.sqlConnect);
            sqlAdapter = new MySqlDataAdapter(sqlCommand);
            sqlAdapter.Fill(dtCust);
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(FormLoad.CreateRoundRectRgn(0, 0, Width, Height, 70, 70));
            panel1.Region = Region.FromHrgn(FormLoad.CreateRoundRectRgn(0, 0, panel1.Width, panel1.Height, 70, 70));
            btnAddToCart.Region = Region.FromHrgn(FormLoad.CreateRoundRectRgn(0, 0, btnAddToCart.Width, btnAddToCart.Height, 25, 25));
            btnCheckout.Region = Region.FromHrgn(FormLoad.CreateRoundRectRgn(0, 0, btnCheckout.Width, btnCheckout.Height, 25, 25));
            btnInputCustomer.Region = Region.FromHrgn(FormLoad.CreateRoundRectRgn(0, 0, btnInputCustomer.Width, btnInputCustomer.Height, 25, 25));
            inputNewCust2.Region = Region.FromHrgn(FormLoad.CreateRoundRectRgn(0, 0, inputNewCust2.Width, inputNewCust2.Height, 25, 25));
            listMenu();
        }
        public void listMenu()
        {
            hide();
            FlowLayoutPanelInputOrder.Visible = true;
            btnAddToCart.Visible = true;
            for (int i = 0; i <= dtMenu.Rows.Count - 1; i++)
            {
                Label menuName = new Label();
                menuName.Text = dtMenu.Rows[i][1].ToString();
                menuName.Location = new Point(75, 20);
                menuName.Size = new Size(150, 45);
                menuName.Font = new Font("Passion One", 15);
                menuName.TextAlign = ContentAlignment.TopCenter;
                menuName.BackColor = Color.Transparent;
                menuName.ForeColor = Color.White;
                LabelMenuList.Add(menuName);

                byte[] image = (byte[])dtMenu.Rows[i][0];
                MemoryStream ms = new MemoryStream(image);
                PictureBox menuImage = new PictureBox();
                menuImage.Image = Image.FromStream(ms);
                menuImage.SizeMode = PictureBoxSizeMode.StretchImage;
                menuImage.Location = new Point(88, 60);
                menuImage.Size = new Size(110, 98);
                

                NumericUpDown countMenu = new NumericUpDown();
                countMenu.Location = new Point(90, 160);
                countMenu.BackColor = Color.FromArgb(247, 193, 75);
                NumericUpDownList.Add(countMenu);

                Label menuPrice = new Label();
                menuPrice.Text = dtMenu.Rows[i][2].ToString();
                int harga = Convert.ToInt32(menuPrice.Text);
                PriceList.Add(harga);

                Panel panelMenuList = new Panel();
                panelMenuList.Size = new Size(300, 200);
                panelMenuList.Name = "panel1" + i;
                MenuList.Add(panelMenuList);
                panelMenuList.BackColor = Color.FromArgb(201, 29, 75);
                panelMenuList.Region = Region.FromHrgn(FormLoad.CreateRoundRectRgn(0, 0, panelMenuList.Width, panelMenuList.Height, 70, 70));
                panelMenuList.BringToFront();
                panelMenuList.Controls.Add(menuName);
                panelMenuList.Controls.Add(menuImage);
                panelMenuList.Controls.Add(countMenu);
                countMenu.BringToFront();
                menuName.BringToFront();
                panelMenuList.AutoScroll = true;

                FlowLayoutPanelInputOrder.Controls.Add(panelMenuList);
                FlowLayoutPanelInputOrder.Invalidate();
                FlowLayoutPanelInputOrder.AutoScroll = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            hide();
            lblCustName.Visible = true;
            cBoxCustList.Visible = true;
            garis1.Visible = true;
            garis2.Visible = true;
            lblPromo.Visible = true;
            tBoxPromo.Visible = true;
            lblPaymentStatus.Visible = true;
            cBoxPaymentStatus.Visible = true;
            dateTimePicker1.Visible = true;
            lblInvDate.Visible = true;
            FlowLayoutPanelInputOrder.Visible = false;
            FlowLayoutPanelCartOrder.Visible = true;
            lblTitle.Text = "CART";
            Subtotal.Visible = true;
            Cart();
        }
        
        public void Cart()
        {
            for (int i = 0; i <= LabelMenuList.Count - 1; i++)
            {
                if (NumericUpDownList[i].Value > 0)
                {
                    Label jumlahMenu = new Label();
                    jumlahMenu.Text = NumericUpDownList[i].Value.ToString() + "x";
                    jumlahMenu.Location = new Point(5, 25);
                    jumlahMenu.Size = new Size(150, 50);
                    jumlahMenu.Font = new Font("Passion One", 15);
                    jumlahMenu.TextAlign = ContentAlignment.TopCenter;
                    jumlahMenu.BackColor = Color.Transparent;
                    jumlahMenu.ForeColor = Color.FromArgb(34, 37, 39);

                    Label menuCartName = new Label();
                    menuCartName.Text = LabelMenuList[i].Text.ToString();
                    menuCartName.Location = new Point(150, 25);
                    menuCartName.Size = new Size(350, 50);
                    menuCartName.Font = new Font("Passion One", 15);
                    menuCartName.TextAlign = ContentAlignment.TopLeft;
                    menuCartName.BackColor = Color.Transparent;
                    menuCartName.ForeColor = Color.FromArgb(34, 37, 39);

                    Label menuPrice = new Label();
                    menuPrice.Text = "IDR " + (PriceList[i] * NumericUpDownList[i].Value).ToString();
                    menuPrice.Location = new Point(600, 25);
                    menuPrice.Size = new Size(200, 20);
                    menuPrice.Font = new Font("Passion One", 15);
                    menuPrice.TextAlign = ContentAlignment.TopRight;
                    menuPrice.BackColor = Color.Transparent;
                    menuPrice.ForeColor = Color.FromArgb(34, 37, 39);
                    int totalPerMenu = Convert.ToInt32(PriceList[i] * NumericUpDownList[i].Value);
                    PriceperMenu.Add(totalPerMenu);
                    totalMenu = totalMenu + Convert.ToInt32(NumericUpDownList[i].Value);


                    Panel panelCartList = new Panel();
                    panelCartList.Size = new Size(900, 80);
                    panelCartList.Name = "panel1" + i;
                    CartList.Add(panelCartList);
                    panelCartList.BackColor = Color.FromArgb(247, 193, 75);
                    panelCartList.Region = Region.FromHrgn(FormLoad.CreateRoundRectRgn(0, 0, panelCartList.Width, panelCartList.Height, 70, 70));
                    panelCartList.BringToFront();
                    panelCartList.Controls.Add(jumlahMenu);
                    panelCartList.Controls.Add(menuCartName);
                    panelCartList.Controls.Add(menuPrice);
                    menuCartName.BringToFront();
                    menuPrice.BringToFront();
                    panelCartList.AutoScroll = true;

                    FlowLayoutPanelCartOrder.Controls.Add(panelCartList);
                    FlowLayoutPanelCartOrder.Invalidate();
                    FlowLayoutPanelCartOrder.AutoScroll = true;
                }

            }
            sumSubtotal = PriceperMenu.Sum();

            Subtotal.Text = "Subtotal: IDR " + sumSubtotal.ToString();
            Subtotal.Location = new Point(700, 80);
            Subtotal.Size = new Size(400, 50);
            Subtotal.Font = new Font("Passion One", 20);
            Subtotal.TextAlign = ContentAlignment.TopLeft;
            Subtotal.BackColor = Color.Transparent;
            Subtotal.ForeColor = Color.FromArgb(34, 37, 39);
            panel1.Controls.Add(Subtotal);


            cBoxCustList.Visible = true;
            for (int i = 0; i <= dtCust.Rows.Count - 1; i++)
            {
                cBoxCustList.Items.Add(dtCust.Rows[i][0]);
            }
            cBoxCustList.Items.Add("none of them");
            cBoxCustList.Size = new Size(250, 30);
            cBoxCustList.Font = new Font("Passion One", 14);
            cBoxCustList.BackColor = Color.FromArgb(201, 29, 75);
            cBoxCustList.ForeColor = Color.White;
            cBoxCustList.BringToFront();

            cBoxPaymentStatus.Size = new Size(250, 30);
            cBoxPaymentStatus.Font = new Font("Passion One", 14);
            cBoxPaymentStatus.BackColor = Color.FromArgb(201, 29, 75);
            cBoxPaymentStatus.ForeColor = Color.White;
            cBoxPaymentStatus.BringToFront();
        }

        private void cBoxCustList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBoxCustList.SelectedItem.ToString() == "none of them")
            {
                btnInputCustomer.Visible = true;
                btnCheckout.Visible = false;
            }
            else
            {
                btnInputCustomer.Visible = false;
                btnCheckout.Visible = true;
            }
        }
        public void hide()
        {
            btnAddToCart.Visible = false;
            btnInputCustomer.Visible = false;
            btnCheckout.Visible = false;
            lblCustName.Visible = false;
            cBoxCustList.Visible = false;
            garis1.Visible = false;
            garis2.Visible = false;
            lblPromo.Visible = false;
            tBoxPromo.Visible = false;
            lblPaymentStatus.Visible = false;
            cBoxPaymentStatus.Visible = false;
            dateTimePicker1.Visible = false;
            lblInvDate.Visible = false;
            lblName.Visible = false;
            tBoxName.Visible = false;
            lblPhoneNumber.Visible = false;
            tBoxPhoneNumber.Visible = false;
            Subtotal.Visible = false;
            inputNewCust2.Visible = false;
            FlowLayoutPanelInputOrder.Visible = false;
            FlowLayoutPanelCartOrder.Visible = false;
          
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            simpanDate = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd");
            if (tBoxPromo.Text.ToString() == "")
            {
                simpanDiskon = 0;
            }
            else
            {
                simpanDiskon = Convert.ToInt32(tBoxPromo.Text.ToString());
            }
            if (cBoxPaymentStatus.SelectedItem == null)
            {
                MessageBox.Show("Please choose the payment status first.");
            }
            else if (dateTimePicker1.Value.Date < DateTime.Now)
            {
                MessageBox.Show("Delivery Date cannot less than today.");
            }
            else if(cBoxPaymentStatus.SelectedItem.ToString() == "Pending")
            {
                try
                {
                    string sqlQuery = $"INSERT INTO INVOICE VALUES('', (SELECT CUST_ID FROM CUSTOMER WHERE CUST_NAME='" + cBoxCustList.SelectedItem.ToString() + "'), STR_TO_DATE('" + simpanDate + "','%Y-%m-%d'), " + totalMenu + ",  " + simpanDiskon + ", " + sumSubtotal + ", 0,0);";
                    MySqlCommand sqlCommand = new MySqlCommand(sqlQuery, FormLoad.sqlConnect);
                    sqlCommand.ExecuteNonQuery();
                    for (int i = 0; i <= LabelMenuList.Count - 1; i++)
                    {
                        if (NumericUpDownList[i].Value > 0)
                        {
                            sqlQuery = $"INSERT INTO INVOICE_MENU VALUES((SELECT INV_NO FROM INVOICE WHERE INV_DATE = (SELECT max(INV_DATE) FROM INVOICE)), (SELECT MENU_ID FROM MENU WHERE MENU_NAME='" + LabelMenuList[i].Text.ToString() + "'), " + NumericUpDownList[i].Value + ", " + (PriceList[i] * NumericUpDownList[i].Value) + ", 0);";
                            sqlCommand = new MySqlCommand(sqlQuery, FormLoad.sqlConnect);
                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("New order has been placed!");
                    FormOrder form2 = new FormOrder();
                    form2.Show();
                    this.Hide();

                    int rowsAffected = sqlCommand.ExecuteNonQuery();
                    //Do something post insert

                }
                catch (MySqlException ex)
                {
                    if (ex.Number == 1062)
                    {
                        //Duplicate key error.  Data already exists now do something.
                    }
                }
                
            }
            else if (cBoxPaymentStatus.SelectedItem.ToString() == "Pay in advance")
            {
                try
                {
                    string sqlQuery = $"INSERT INTO INVOICE VALUES('', (SELECT CUST_ID FROM CUSTOMER WHERE CUST_NAME='" + cBoxCustList.SelectedItem.ToString() + "'), STR_TO_DATE('" + simpanDate + "','%Y-%m-%d'), " + totalMenu + ",  " + simpanDiskon + ", " + sumSubtotal + ", 1,0);";
                    MySqlCommand sqlCommand = new MySqlCommand(sqlQuery, FormLoad.sqlConnect);
                    sqlCommand.ExecuteNonQuery();
                    for (int i = 0; i <= LabelMenuList.Count - 1; i++)
                    {
                        if (NumericUpDownList[i].Value > 0)
                        {
                            sqlQuery = $"INSERT INTO INVOICE_MENU VALUES((SELECT INV_NO FROM INVOICE WHERE INV_DATE = (SELECT max(INV_DATE) FROM INVOICE)), (SELECT MENU_ID FROM MENU WHERE MENU_NAME='" + LabelMenuList[i].Text.ToString() + "'), " + NumericUpDownList[i].Value + ", " + (PriceList[i] * NumericUpDownList[i].Value) + ", 0);";
                            sqlCommand = new MySqlCommand(sqlQuery, FormLoad.sqlConnect);
                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("New order has been placed!");
                    FormOrder form2 = new FormOrder();
                    form2.Show();
                    this.Hide();

                    int rowsAffected = sqlCommand.ExecuteNonQuery();
                    //Do something post insert

                }
                catch (MySqlException ex)
                {
                    if (ex.Number == 1062)
                    {
                        //Duplicate key error.  Data already exists now do something.
                    }
                }

            }
        }

        private void btnInputCustomer_Click(object sender, EventArgs e)
        {

            if (tBoxPromo.Text.ToString() == "")
            {
                simpanDiskon = 0;
            }
            else
            {
                simpanDiskon = Convert.ToInt32(tBoxPromo.Text.ToString());
            }
            if (cBoxPaymentStatus.SelectedItem == null)
            {
                MessageBox.Show("Please choose the payment status first.");
            }
            else if (dateTimePicker1.Value.Date < DateTime.Now)
            {
                MessageBox.Show("Delivery Date cannot less than today.");
            }
            else
            {
                lblTitle.Text = "INPUT NEW CUSTOMER";
                hide();
                lblName.Visible = true;
                tBoxName.Visible = true;
                lblPhoneNumber.Visible = true;
                tBoxPhoneNumber.Visible = true;
                inputNewCust2.Visible = true;
            }
        }

        private void tBoxAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblAddress_Click(object sender, EventArgs e)
        {

        }

        private void inputNewCust2_Click(object sender, EventArgs e)
        {
            simpanDate = dateTimePicker1.Value.Date.ToString("yyyy-MM-dd");
            if (tBoxPromo.Text == null)
            {
                simpanDiskon = 0;
            }
            else
            {
                simpanDiskon = Convert.ToInt32(tBoxPromo.Text.ToString());
            }
            string sqlQuery = $"INSERT INTO CUSTOMER VALUES('', '" + tBoxName.Text.ToString() + "', '" + tBoxPhoneNumber.Text.ToString() + "', 0);";
            MySqlCommand sqlCommand = new MySqlCommand(sqlQuery, FormLoad.sqlConnect);
            sqlCommand.ExecuteNonQuery();
            MessageBox.Show("New customer data has been inputted.");
            if (cBoxPaymentStatus.SelectedItem.ToString() == "Pending")
            {
                try
                {
                    sqlQuery = $"INSERT INTO INVOICE VALUES('', (SELECT CUST_ID FROM CUSTOMER WHERE CUST_NAME='" + tBoxName.Text.ToString() + "'), STR_TO_DATE('" + simpanDate + "','%Y-%m-%d'), " + totalMenu + ",  " + simpanDiskon + ", " + sumSubtotal + ", 0,0);";
                    sqlCommand = new MySqlCommand(sqlQuery, FormLoad.sqlConnect);
                    sqlCommand.ExecuteNonQuery();
                    for (int i = 0; i <= LabelMenuList.Count - 1; i++)
                    {
                        if (NumericUpDownList[i].Value > 0)
                        {
                            sqlQuery = $"INSERT INTO INVOICE_MENU VALUES((SELECT INV_NO FROM INVOICE WHERE INV_DATE = (SELECT max(INV_DATE) FROM INVOICE)), (SELECT MENU_ID FROM MENU WHERE MENU_NAME='" + LabelMenuList[i].Text.ToString() + "'), " + NumericUpDownList[i].Value + ", " + (PriceList[i] * NumericUpDownList[i].Value) + ", 0);";
                            sqlCommand = new MySqlCommand(sqlQuery, FormLoad.sqlConnect);
                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("New order has been placed!");

                    int rowsAffected = sqlCommand.ExecuteNonQuery();
                    //Do something post insert

                }
                catch (MySqlException ex)
                {
                    if (ex.Number == 1062)
                    {
                        //Duplicate key error.  Data already exists now do something.
                    }
                }
            }
            else if (cBoxPaymentStatus.SelectedItem.ToString() == "Pay in advance")
            {
                try
                {
                    sqlQuery = $"INSERT INTO INVOICE VALUES('', (SELECT CUST_ID FROM CUSTOMER WHERE CUST_NAME='" + tBoxName.Text.ToString() + "'), STR_TO_DATE('" + simpanDate + "','%Y-%m-%d'), " + totalMenu + ",  " + simpanDiskon + ", " + sumSubtotal + ", 1,0);";
                    sqlCommand = new MySqlCommand(sqlQuery, FormLoad.sqlConnect);
                    sqlCommand.ExecuteNonQuery();
                    for (int i = 0; i <= LabelMenuList.Count - 1; i++)
                    {
                        if (NumericUpDownList[i].Value > 0)
                        {
                            sqlQuery = $"INSERT INTO INVOICE_MENU VALUES((SELECT INV_NO FROM INVOICE WHERE INV_DATE = (SELECT max(INV_DATE) FROM INVOICE)), (SELECT MENU_ID FROM MENU WHERE MENU_NAME='" + LabelMenuList[i].Text.ToString() + "'), " + NumericUpDownList[i].Value + ", " + (PriceList[i] * NumericUpDownList[i].Value) + ", 0);";
                            sqlCommand = new MySqlCommand(sqlQuery, FormLoad.sqlConnect);
                            sqlCommand.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("New order has been placed!");

                    int rowsAffected = sqlCommand.ExecuteNonQuery();
                    //Do something post insert

                }
                catch (MySqlException ex)
                {
                    if (ex.Number == 1062)
                    {
                        //Duplicate key error.  Data already exists now do something.
                    }
                }
            }
            FormOrder form2 = new FormOrder();
            form2.Show();
            this.Hide();
                
            
        }

        private void tBoxPhoneNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void tBoxPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void tBoxPromo_TextChanged(object sender, EventArgs e)
        {

        }

        private void tBoxPromo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
