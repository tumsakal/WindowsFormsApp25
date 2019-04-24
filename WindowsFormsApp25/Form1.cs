using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp25
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            int.TryParse(txtQty.Text.Trim(), out int qty);
            float.TryParse(txtPrice.Text.Trim(), out float price);
            float total = qty * price;
            float disc_percent = 0f;
            if (total >= 0 && total <= 200)
            {
                disc_percent = 0.0f;
            }
            else if (total >= 201 && total <= 500)
            {
                disc_percent = 0.01f;
            }
            else if (total >= 501 && total <= 1000)
            {
                disc_percent = 0.02f;
            }
            txtTotal.Text = total.ToString();
            txtDiscount.Text = (total * disc_percent).ToString();
            txtPay.Text = (total * (1 - disc_percent)).ToString();
        }
    }
}
