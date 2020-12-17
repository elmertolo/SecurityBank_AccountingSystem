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
    public partial class DeliveryReceipts : Form
    {
        frmMain frm1;
        public DeliveryReceipts(frmMain frm)
        {
            InitializeComponent();
            this.frm1 = frm;
        }
    }
}
