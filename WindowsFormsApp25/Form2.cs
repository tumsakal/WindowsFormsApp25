using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp25
{
    public partial class Form2 : Form
    {
        HEntities db = new HEntities();
        public Form2()
        {
            InitializeComponent();
        }

        private async void Form2_Load(object sender, EventArgs e)
        {
            db.Configuration.LazyLoadingEnabled = true;
            cboStatus.DataSource = await db.RoomStatus.ToListAsync();
            cboStatus.DisplayMember = "Name";
            cboStatus.ValueMember = "Id";
        }

        private async void CboStatus_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string id = cboStatus.SelectedValue.ToString();
            var q = from r in db.Rooms
                where r.BookingStatusCode == id
                select new {r.Id, r.Name};
            dataGridView1.DataSource = await q.ToListAsync();
        }
    }
}
