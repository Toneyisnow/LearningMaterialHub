using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LearningMaterialHub
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnOpenExcel_Click(object sender, EventArgs e)
        {
            var openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Excel文件(*.xlsx)|*.xlsx";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.txtExcelFilePath.Text = openFileDialog1.FileName;
            }
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            this.txtTraceLog.Clear();

            OneDriveConnector connector = new OneDriveConnector(this.txtCookie.Text, this.txtRequestDigest.Text);

            ExcelReader reader = new ExcelReader(this.txtExcelFilePath.Text);
            List<MaterialRequest> requestList = reader.RetrieveMaterialRequests();
            foreach(var request in requestList)
            {
                foreach(var materialId in request.MaterialList)
                {
                    this.txtTraceLog.AppendText(string.Format(@"Creating link for Email={0} Material={1}", request.EmailAddress, materialId));
                    this.txtTraceLog.AppendText(Environment.NewLine);

                    Task.Run(() =>
                    {
                        connector.CreateLink(materialId, request.EmailAddress);
                    }).Wait();

                    this.txtTraceLog.Text += "Completed.";
                    this.txtTraceLog.AppendText(Environment.NewLine);
                }

                // Sleep 1 second between each of the requests
                Thread.Sleep(1000);
            }
        }
    }
}
