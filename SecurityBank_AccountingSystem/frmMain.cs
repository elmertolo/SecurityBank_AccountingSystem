using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecurityBank_AccountingSystem
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void deliveryReceiptsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new DeliveryReceipts(this);
            frm.ShowDialog();
        }

        private void salesInvoiceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form frm = new SalesInvoiceReport(this);
            frm.ShowDialog();
        }
    }
}
