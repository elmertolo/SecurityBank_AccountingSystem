using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SecurityBank_AccountingSystem.Models;
using SecurityBank_AccountingSystem.Services;

namespace SecurityBank_AccountingSystem
{
    public partial class SalesInvoiceReport : Form
    {
        frmMain frm;
        int ToTalChecks = 0;
        List<SalesInvoiceModel> salesInvoice = new List<SalesInvoiceModel>();
        DbConServices con = new DbConServices();
        
        
        List<SalesInvoiceModel> listofdata = new List<SalesInvoiceModel>();
        List<SalesInvoiceModel> d = new List<SalesInvoiceModel>();
        public SalesInvoiceReport(frmMain frm1)
        {

            InitializeComponent();
            this.frm = frm1;
        }
        private void DisplayData()
        {

            con.GetAllData(salesInvoice);

            //DataGridViewCheckBoxColumn checkColumn = new DataGridViewCheckBoxColumn();
            //checkColumn.Name = "X";
            //checkColumn.HeaderText = "..";
            //checkColumn.Width = 50;
            //checkColumn.ReadOnly = false;

            //checkColumn.FillWeight = 10; //if the datagridview is resized (on form resize) the checkbox won't take up too much; value is relative to the other columns' fill values
            //dataGridView1.Columns.Add(checkColumn);

            BindingSource checkBind = new BindingSource();
            checkBind.DataSource = salesInvoice;
            dataGridView1.DataSource = checkBind;


            //for (int i = 0; i < salesInvoice.Count; i++)
            // {

            //    dataGridView1.Rows[i].Cells[i].Value = "false";
            //    dataGridView1.Rows[i].Cells[i + 1].Value = salesInvoice[i].Batch;
            //    dataGridView1.Rows[i].Cells[i + 2].Value = salesInvoice[i].ChequeName;
            //    dataGridView1.Rows[i].Cells[i + 3].Value = salesInvoice[i].ChkType;
            //    dataGridView1.Rows[i].Cells[i + 4].Value = salesInvoice[i].Quantity;
            //    dataGridView1.Rows[i].Cells[i + 5].Value = salesInvoice[i].DeliveryDate.ToString("MM-dd-yyyy");

            // }
          //  for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
             //   dataGridView1.Rows[i].Cells["X"].Value = "false";
           // }
            //Change cell font
            foreach (DataGridViewColumn c in dataGridView1.Columns)
            {
                c.DefaultCellStyle.Font = new Font("Arial", 12F, GraphicsUnit.Pixel);
            }
            
          
        }

        private void SalesInvoiceReport_Load(object sender, EventArgs e)
        {
            DisplayData();     
    
        }
        private void SelectedData()
        {
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            int columnindex = dataGridView1.CurrentCell.ColumnIndex;
            
          

            
               // sales.Batch = dataGridView1.SelectedRows[]
          //      sales.ChequeName = dataGridView1.Rows[rowindex].Cells[columnindex + 2].Value.ToString();

         //       listofdata.Add(sales);
            
            string list = "";
            for (int i = 0; i < listofdata.Count; i++)
            {
                list += listofdata[i].Batch + "\n" + listofdata[i].ChequeName + "\n" ;
                
            }
            MessageBox.Show(list);
        }

        private void processToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // var d = new HashSet<SalesInvoiceModel>(listofdata).ToList();
            //var groupList = listofdata.GroupBy(r =>r).Where(s=>s.Count()>1).Select(f=>f.Key).ToList();
            var sort = (from c in listofdata
                        orderby c.Batch, c.ChequeName
                        ascending
                        select c).ToList();

            //Int32 index = listofdata.Count - 1;
            //while (index > 0)
            //{
            //    if (listofdata[index] == listofdata[index - 1])
            //    {
            //        if (index < listofdata.Count - 1)
            //            (listofdata[index], listofdata[listofdata.Count - 1]) = (listofdata[listofdata.Count - 1],listofdata[index]);
            //        listofdata.RemoveAt(listofdata.Count - 1);
            //        index--;
            //    }
            //    else
            //        index--;
            //}
          // var list = listofdata.Where(s=>s.ChkType == "A").Distinct().ToList();

            StreamWriter sw = new StreamWriter(Application.StartupPath + "\\Sample.txt");
            for (int i = 0; i < sort.Count; i++)
            {
                sw.WriteLine(sort[i].Batch);
                sw.WriteLine(sort[i].ChequeName);
                sw.WriteLine(sort[i].ChkType);
                sw.WriteLine(sort[i].Quantity);


            }
            sw.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
         //   SelectedData();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            processToolStripMenuItem.Enabled = true;
        //int rowCount = 0;

        //if (e.RowIndex >= 0)
        //{
        //    SalesInvoiceModel sales = new SalesInvoiceModel();
        //    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
        //    //  rowCount++;


        //    sales.Batch = row.Cells[1].Value.ToString();
        //    sales.ChequeName = row.Cells[2].Value.ToString();
        //    sales.ChkType = row.Cells[3].Value.ToString();
        //    sales.Quantity = int.Parse(row.Cells[4].Value.ToString());


        //        listofdata.Add(sales);


        //}
       
            
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            int columnindex = dataGridView1.CurrentCell.ColumnIndex;

            SalesInvoiceModel sales = new SalesInvoiceModel();
            //sales.Batch = "";
            //sales.ChequeName = "";
            //sales.ChkType = "";
            //sales.Quantity = 0;
          
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                ////  rowCount++;
               
               


                // if (Convert.ToBoolean(dataGridView1.Rows[rowindex].Cells["X"].Value) == true)
                //  {

                         sales.Batch = row.Cells[0].Value.ToString();
                        sales.ChequeName = row.Cells[1].Value.ToString();
                        sales.ChkType = row.Cells[2].Value.ToString();
                        sales.Quantity = int.Parse(row.Cells[3].Value.ToString());
              //row.Cells.Remove()  
                //if (listofdata.Count == 0)
                //{
                    listofdata.Add(sales);
                //}
             

                //else
                //{
                    //foreach (var data in listofdata)
                    //{
                                        
                    //    if ((sales.Batch == data.Batch) && (sales.ChequeName == data.ChequeName) &&
                    //          (sales.ChkType == data.ChkType) && (sales.Quantity == data.Quantity))
                    //    {
                    //      //  break;
                    //       goto dontAdd;
                    //    }
                    //    else
                    //    {
                    //        listofdata.Add(sales);
                            
                    //    }
                    //    // }



                    //}
             //   }
          //  dontAdd:
              
                //if (listofdata.Count == 0)
                //{
                //    BindingSource checkBind = new BindingSource();
                //    checkBind.DataSource = listofdata;
                //    dataGridView2.DataSource = checkBind;
                //}
                //else
                //{
                //if (listofdata.Count > 0)
                //{
                //    for (int i = 0; i < listofdata.Count; i++)
                //    {
                //        if ((sales.Batch == listofdata[i].Batch) && (sales.ChequeName == listofdata[i].ChequeName) &&
                //               (sales.ChkType == listofdata[i].ChkType) && (sales.Quantity == listofdata[i].Quantity))
                //        //if ((sales.Batch == dataGridView2.Rows[i].Cells[0].Value.ToString()) && (sales.ChequeName == dataGridView2.Rows[i].Cells[1].Value.ToString()) &&
                //        //        (sales.ChkType == dataGridView2.Rows[i].Cells[2].Value.ToString()) && (sales.Quantity == int.Parse(dataGridView2.Rows[i].Cells[3].Value.ToString())))
                //        {
                //            MessageBox.Show("DUplicate daTA!!");
                //             break;
                //        }
                //        else
                //        {

                // dataGridView2.Rows.Add( sales.Batch, sales.ChequeName, sales.ChkType, sales.Quantity );
                //dataGridView2.Rows[addRow].Cells[0].Value = sales.Batch;
                //dataGridView2.Rows[addRow].Cells[1].Value = sales.ChequeName;
                //dataGridView2.Rows[addRow].Cells[2].Value = sales.ChkType;
                //dataGridView2.Rows[addRow].Cells[3].Value = sales.Quantity;
                //dataGridView2.Rows.Add()
                BindingSource checkBind2 = new BindingSource();
                        checkBind2.DataSource = listofdata;
                        dataGridView2.DataSource = checkBind2;
                dataGridView1.Rows.RemoveAt(e.RowIndex);
                if (e.RowIndex == 0 )
                {
                    ToTalChecks += int.Parse(dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString());
                }
                else
                {
                    ToTalChecks += int.Parse(dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString());
                }
                lblTotal.Text = ToTalChecks.ToString();
            }
            

            //for (int i = 0; i < dataGridView1.Rows.Count; i++)
            //{
            //    if (dataGridView1.Rows[i].Cells[0].Value != null)
            //    {
            //        bool isCellChecked = (bool)dataGridView1.Rows[i].Cells[0].Value;
            //        if (isCellChecked == true)
            //        {
            //         //   MessageBox.Show("Is Checked");
            //            SalesInvoiceModel sales = new SalesInvoiceModel();

            //            sales.Batch = dataGridView1.Rows[i].Cells[1].Value.ToString();
            //            sales.ChequeName = dataGridView1.Rows[i].Cells[2].Value.ToString();
            //            sales.ChkType = dataGridView1.Rows[i].Cells[3].Value.ToString();
            //            sales.Quantity = int.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString());

            //            listofdata.Add(sales);
            //        }
            //        else
            //        {
            //            MessageBox.Show("Is Not Chiked");
            //        }
            //    }
            //}


        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                SalesInvoiceModel sales = new SalesInvoiceModel();
                //sales.Batch = "";
                //sales.ChequeName = "";
                //sales.ChkType = "";
                //sales.Quantity = 0;

                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                    ////  rowCount++;




                    // if (Convert.ToBoolean(dataGridView1.Rows[rowindex].Cells["X"].Value) == true)
                    //  {

                    sales.Batch = row.Cells[0].Value.ToString();
                    sales.ChequeName = row.Cells[1].Value.ToString();
                    sales.ChkType = row.Cells[2].Value.ToString();
                    sales.Quantity = int.Parse(row.Cells[3].Value.ToString());
                    //row.Cells.Remove()  
                    //if (listofdata.Count == 0)
                    //{
                    salesInvoice.Add(sales);
                    //}
                    BindingSource checkBind2 = new BindingSource();
                    checkBind2.DataSource = salesInvoice;
                    dataGridView1.DataSource = checkBind2;
                    dataGridView2.Rows.RemoveAt(e.RowIndex);

                    ToTalChecks = int.Parse(dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString()) - int.Parse(dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString());
                    
                    lblTotal.Text = ToTalChecks.ToString();
                    ToTalChecks = 0;
                    
                }
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
