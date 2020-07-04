using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningMaterialHub
{
    public class ExcelReader
    {
        private static int Column_DateTime = 3;
        private static int Column_EmailAddress = 6;
        private static List<int> Column_MaterialList = new List<int>() { 7, 8, 9, 10 };

        private string excelFileFullPath = string.Empty;

        

        public ExcelReader(string file)
        {
            this.excelFileFullPath = file;
        }

        public List<MaterialRequest> RetrieveMaterialRequests()
        {
            Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            Microsoft.Office.Interop.Excel.Workbook xlWorkBook = xlApp.Workbooks.Open(this.excelFileFullPath, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);


            List<MaterialRequest> result = new List<MaterialRequest>();
            int currentIndex = 1;
            while(true)
            {
                currentIndex++;
                Range timeCell = xlWorkSheet.Cells[currentIndex, Column_DateTime];
                if (timeCell == null || timeCell.Value2 == null || string.IsNullOrEmpty(timeCell.Value2.ToString()))
                {
                    break;
                }

                string dateTimeStr = timeCell.Value.ToString();
                string dateTimeStr2 = timeCell.Value2.ToString();
                var formats = new[] { "yyyy/M/d H:mm:ss" };
                DateTime dateTime = DateTime.Now; 
                if (!DateTime.TryParseExact(dateTimeStr, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
                {
                    break;
                }

                if (dateTime.AddDays(1) < DateTime.Now)
                {
                    continue;
                }

                Range emailCell = xlWorkSheet.Cells[currentIndex, Column_EmailAddress];
                if (emailCell == null || string.IsNullOrEmpty(emailCell.Value2.ToString()))
                {
                    continue;
                }

                string emailAddress = emailCell.Value2.ToString();

                foreach (int materialType in Column_MaterialList)
                {
                    Range materialCell = xlWorkSheet.Cells[currentIndex, materialType];
                    if (materialCell == null || materialCell.Value2 == null || string.IsNullOrEmpty(materialCell.Value2.ToString()))
                    {
                        continue;
                    }

                    string materialList = materialCell.Value2.ToString();
                    if (string.IsNullOrEmpty(materialList))
                    {
                        continue;
                    }

                    string[] materials = materialList.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    List<string> materialIdList = new List<string>();
                    int maIndex = 0;
                    foreach (string material in materials)
                    {
                        if (material.Length < 3)
                        {
                            continue;
                        }

                        if (maIndex >= 3)
                        {
                            break;
                        }

                        materialIdList.Add(material.Substring(0, 3));
                        maIndex++;
                    }

                    MaterialRequest request = new MaterialRequest();
                    request.EmailAddress = emailAddress;
                    request.MaterialList = materialIdList;
                    result.Add(request);
                }
            }

            return result;

        }
    }
}
