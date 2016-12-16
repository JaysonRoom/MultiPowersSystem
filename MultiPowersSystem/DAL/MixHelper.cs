using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MultiPowersSystem.DAL
{
     public class MixHelper
    {
     /// <summary>
     /// 计算读取数据时间
     /// </summary>
     /// <param name="sign"></param>
     /// <param name="openCloseFlag"></param>
     /// <param name="openTime"></param>
     /// <param name="closeTime"></param>
     /// <returns></returns>
        public static int ReturnInterval(string sign, int openCloseFlag, decimal openTime, decimal closeTime, int point)
        {
            int reValue = 0;
            switch (sign)
            {
                case "小时":
                    reValue = 3600;
                    break;
                case "分钟":
                    reValue = 60;
                    break;
                case "秒":
                    reValue = 1;
                    break;
                default:
                    break;
            }
            if (openCloseFlag == 1)//打开
            {
                return (int)(openTime * reValue * 1000 / point);
            }
            else //关闭
            {
                return (int)(closeTime * reValue * 1000 / point);
            }

        }

        public static void SaveCSVFile(Chart volChart, Chart eleChart) {
            // volChart.Series[0].Points
            DataTable dt = new DataTable();
            dt.Columns.Add("序号", System.Type.GetType("System.String"));
            dt.Columns.Add("时间", System.Type.GetType("System.String"));
            dt.Columns.Add("电压", System.Type.GetType("System.String"));
            dt.Columns.Add("电流", System.Type.GetType("System.String"));


            for (int i = 0; i < volChart.Series[0].Points.Count; i++)
            {
                DataRow dr = dt.NewRow();
                dr["序号"] = i + 1;
                dr["时间"] = volChart.Series[0].Points[i].AxisLabel;
                dr["电压"] = volChart.Series[0].Points[i].YValues[0];
                dr["电流"] = eleChart.Series[0].Points[i].YValues[0];

                dt.Rows.Add(dr);
            }

            SaveToCSV(dt, "");//保存到CSV文件中
        }

        public static void SaveToCSV(DataTable dt, string fullPath)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.FileName = "电源控制测试结果" + System.DateTime.Now.ToString("yyyyMMddHHmmss");
            //saveFile.Filter = ".csv";
            saveFile.FilterIndex = 2;
            saveFile.RestoreDirectory = true;

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                fullPath = saveFile.FileName;
            }
            else
            {
                return;
            }


            FileInfo fi = new FileInfo(fullPath);
            if (!fi.Directory.Exists)
            {
                fi.Directory.Create();
            }
            FileStream fs = new FileStream(fullPath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
            string data = "";
            //写出列名称
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                data += dt.Columns[i].ColumnName.ToString();
                if (i < dt.Columns.Count - 1)
                {
                    data += ",";
                }
            }
            sw.WriteLine(data);
            //写出各行数据
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                data = "";
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string str = dt.Rows[i][j].ToString();
                    str = str.Replace("\"", "\"\"");//替换英文冒号 英文冒号需要换成两个冒号
                    if (str.Contains(',') || str.Contains('"')
                        || str.Contains('\r') || str.Contains('\n')) //含逗号 冒号 换行符的需要放到引号中
                    {
                        str = string.Format("\"{0}\"", str);
                    }

                    data += str;
                    if (j < dt.Columns.Count - 1)
                    {
                        data += ",";
                    }
                }
                sw.WriteLine(data);
            }
            sw.Close();
            fs.Close();
            DialogResult result = MessageBox.Show("CSV文件保存成功！");
            if (result == DialogResult.OK)
            {
                //System.Diagnostics.Process.Start("explorer.exe", Common.PATH_LANG);
            }
        }

        public static void SaveToExcel(DataTable dt, string fullPath) {

            string saveFileName = "";          
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.DefaultExt = "xls";
            saveDialog.Filter = "Excel文件|*.xls";
            saveDialog.FileName = "电源控制测试结果" + System.DateTime.Now.ToString("yyyyMMddHHmmss"); ;
            saveDialog.ShowDialog();
            saveFileName = saveDialog.FileName;
            if (saveFileName.IndexOf(":") < 0) return; //被点了取消 
            Microsoft.Office.Interop.Excel.Application xlApp;
            try
            {
                xlApp = new Microsoft.Office.Interop.Excel.Application();
            }
            catch (Exception)
            {
                MessageBox.Show("无法创建Excel对象，可能您的机子未安装Excel");
                return;
            }
            finally
            {
            }
            Microsoft.Office.Interop.Excel.Workbooks workbooks = xlApp.Workbooks;
            Microsoft.Office.Interop.Excel.Workbook workbook = workbooks.Add(Microsoft.Office.Interop.Excel.XlWBATemplate.xlWBATWorksheet);
            Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];//取得sheet1
                                                                                                                                  //写Title
            int titleRowCount = 0;
            //写入列标题
            for (int i = 0; i <= dt.Columns.Count - 1; i++)
            {
                worksheet.Cells[titleRowCount + 1, i + 1] = dt.Columns[i].ColumnName;
            }
            //写入数值
            for (int r = 0; r <= dt.Rows.Count - 1; r++)
            {
                for (int i = 0; i <= dt.Columns.Count - 1; i++)
                {
                    worksheet.Cells[r + titleRowCount + 2, i + 1] = dt.Rows[r][i].ToString();
                }
                System.Windows.Forms.Application.DoEvents();
            }
            worksheet.Columns.EntireColumn.AutoFit();//列宽自适应
                                                   
            if (saveFileName != "")
            {
                try
                {
                    workbook.Saved = true;
                    workbook.SaveCopyAs(saveFileName);
                    //fileSaved = true;
                }
                catch (Exception ex)
                {
                    //fileSaved = false;
                    MessageBox.Show("导出文件时出错,文件可能正被打开！n" + ex.Message);
                }
            }
          
            xlApp.Quit();
            GC.Collect();//强行销毁 
        }

    }
}
