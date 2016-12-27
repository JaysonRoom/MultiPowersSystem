using MultiPowersSystem.DAL;
using MultiPowersSystem.DriverCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static MultiPowersSystem.DAL.CommonMethod;

namespace MultiPowersSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;

            listViewMenu.Items.Add("N5769A", "N5769A",0);
            listViewMenu.Items.Add("N5751A", "N5751A",0);
            listViewMenu.Items.Add("N5752A", "N5752A",0);
            listViewMenu.Items.Add("N5772A", "N5772A",0);
            listViewMenu.Items.Add("N6702A", "N6702A", 0);
            listViewMenu.Items.Add("N6705B", "N6705B", 0);

            comboUnit1.SelectedIndex = 1;
            comboUnit2.SelectedIndex = 1;
            comboUnit3.SelectedIndex = 1;
            comboUnit4.SelectedIndex = 1;
            comboUnit5.SelectedIndex = 1;
            comboUnit6.SelectedIndex = 1;

            listViewMenu.Items[0].Selected = true;

            initChart();

            mainTab.TabPages.Clear();
            mainTab.TabPages.Add(tabPage1);

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //居中显示
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            //显示应用程序在任务栏中的图标
            this.ShowInTaskbar = true;

            //首先要从ini文件读取仪器的参数信息
            CommonMethod.GetAlltheInstumentsParasFromIniFile();
            ipAddress1.Text = CGloabal.g_N5769AModule.ipAdress;  
            ipAddress2.Text = CGloabal.g_N5751AModule.ipAdress;           
            ipAddress3.Text = CGloabal.g_N5752AModule.ipAdress;
            ipAddress4.Text = CGloabal.g_N5772AModule.ipAdress;

            ipAddress5.Text = CGloabal.g_N6702AModule.ipAdress;
            ipAddress6.Text = CGloabal.g_N6705AModule.ipAdress;

            comboStyle1.SelectedIndex = 0;

        }

        private void initChart()
        {
            volChart1.ChartAreas[0].AxisX.LabelStyle.Format = "mm:ss";
            volChart1.ChartAreas[0].AxisX.ScaleView.Size = 20;
            eleChart1.ChartAreas[0].AxisX.LabelStyle.Format = "mm:ss";
            eleChart1.ChartAreas[0].AxisX.ScaleView.Size = 20;

            volChart2.ChartAreas[0].AxisX.LabelStyle.Format = "mm:ss";
            volChart2.ChartAreas[0].AxisX.ScaleView.Size = 20;
            eleChart2.ChartAreas[0].AxisX.LabelStyle.Format = "mm:ss";
            eleChart2.ChartAreas[0].AxisX.ScaleView.Size = 20;

            volChart3.ChartAreas[0].AxisX.LabelStyle.Format = "mm:ss";
            volChart3.ChartAreas[0].AxisX.ScaleView.Size = 20;
            eleChart3.ChartAreas[0].AxisX.LabelStyle.Format = "mm:ss";
            eleChart3.ChartAreas[0].AxisX.ScaleView.Size = 20;

            volChart4.ChartAreas[0].AxisX.LabelStyle.Format = "mm:ss";
            volChart4.ChartAreas[0].AxisX.ScaleView.Size = 20;
            eleChart4.ChartAreas[0].AxisX.LabelStyle.Format = "mm:ss";
            eleChart4.ChartAreas[0].AxisX.ScaleView.Size = 20;

            volChart51.ChartAreas[0].AxisX.LabelStyle.Format = "mm:ss";
            volChart51.ChartAreas[0].AxisX.ScaleView.Size = 20;
            eleChart51.ChartAreas[0].AxisX.LabelStyle.Format = "mm:ss";
            eleChart51.ChartAreas[0].AxisX.ScaleView.Size = 20;

            volChart52.ChartAreas[0].AxisX.LabelStyle.Format = "mm:ss";
            volChart52.ChartAreas[0].AxisX.ScaleView.Size = 20;
            eleChart52.ChartAreas[0].AxisX.LabelStyle.Format = "mm:ss";
            eleChart52.ChartAreas[0].AxisX.ScaleView.Size = 20;

            volChart53.ChartAreas[0].AxisX.LabelStyle.Format = "mm:ss";
            volChart53.ChartAreas[0].AxisX.ScaleView.Size = 20;
            eleChart53.ChartAreas[0].AxisX.LabelStyle.Format = "mm:ss";
            eleChart53.ChartAreas[0].AxisX.ScaleView.Size = 20;

            volChart54.ChartAreas[0].AxisX.LabelStyle.Format = "mm:ss";
            volChart54.ChartAreas[0].AxisX.ScaleView.Size = 20;
            eleChart54.ChartAreas[0].AxisX.LabelStyle.Format = "mm:ss";
            eleChart54.ChartAreas[0].AxisX.ScaleView.Size = 20;

            volChart61.ChartAreas[0].AxisX.LabelStyle.Format = "mm:ss";
            volChart61.ChartAreas[0].AxisX.ScaleView.Size = 20;
            eleChart61.ChartAreas[0].AxisX.LabelStyle.Format = "mm:ss";
            eleChart61.ChartAreas[0].AxisX.ScaleView.Size = 20;

            volChart62.ChartAreas[0].AxisX.LabelStyle.Format = "mm:ss";
            volChart62.ChartAreas[0].AxisX.ScaleView.Size = 20;
            eleChart62.ChartAreas[0].AxisX.LabelStyle.Format = "mm:ss";
            eleChart62.ChartAreas[0].AxisX.ScaleView.Size = 20;

            volChart63.ChartAreas[0].AxisX.LabelStyle.Format = "mm:ss";
            volChart63.ChartAreas[0].AxisX.ScaleView.Size = 20;
            eleChart63.ChartAreas[0].AxisX.LabelStyle.Format = "mm:ss";
            eleChart63.ChartAreas[0].AxisX.ScaleView.Size = 20;

            volChart64.ChartAreas[0].AxisX.LabelStyle.Format = "mm:ss";
            volChart64.ChartAreas[0].AxisX.ScaleView.Size = 20;
            eleChart64.ChartAreas[0].AxisX.LabelStyle.Format = "mm:ss";
            eleChart64.ChartAreas[0].AxisX.ScaleView.Size = 20;
        }

        private void volteVal1_ValueChanged(object sender, EventArgs e)
        {

        }
        private void listViewMenu_ItemActivate(object sender, EventArgs e)
        {
            var list = sender as ListView;
            var selectText = list.SelectedItems[0].Text;
            switch (selectText)
            {
                case "N5769A":
                    mainTab.TabPages.Clear();
                    mainTab.TabPages.Add(tabPage1);
                    break;
                case "N5751A":
                    mainTab.TabPages.Clear();
                    mainTab.TabPages.Add(tabPage2);
                    break;
                case "N5752A":
                    mainTab.TabPages.Clear();
                    mainTab.TabPages.Add(tabPage3);
                    break;
                case "N5772A":
                    mainTab.TabPages.Clear();
                    mainTab.TabPages.Add(tabPage4);
                    break;
                case "N6702A":
                    mainTab.TabPages.Clear();
                    mainTab.TabPages.Add(tabPage5);
                    break;
                case "N6705B":
                    mainTab.TabPages.Clear();
                    mainTab.TabPages.Add(tabPage6);
                    break;
                default:
                    break;
            }
        }

        private void btnOpen1_Click(object sender, EventArgs e)
        {
            string strIP;
            UInt32 nPort;
            string resourceName;
            int error = 0;
            if (btnOpen1.Text == "打开")//用户要连接仪器
            {
                strIP = this.ipAddress1.Text;
                nPort = 8080;
                //连接设备
                resourceName = "TCPIP0::" + strIP + "::inst0::INSTR";    

                error = CommonMethod.ConnectSpecificInstrument(CGloabal.g_N5769AModule.strInstruName, resourceName);
                if (error < 0)//连接失败
                {
                    CommonMethod.ShowHintInfor(eHintInfoType.error, "电源打开失败！");
                    btnOpen1.Text = "打开";
                }
                else//连接成功,则要将当前用户输入的IP地址和端口号保存到ini文件中
                {
                    CommonMethod.SaveInputNetInforsToIniFile(CGloabal.g_N5769AModule.strInstruName, strIP, nPort);
                    btnOpen1.Text = "关闭";
                }
            }
            else//此时用户要断开连接
            {
                error = CommonMethod.CloseSpecificInstrument(CGloabal.g_N5769AModule.strInstruName);
                if (error < 0)//断开失败，则还要将switchConnect恢复为连接状态      
                {
                    btnOpen1.Text = "关闭";
                }
                else
                {
                    btnOpen1.Text = "打开";
                }
            }
        }

        private void btnStart1_Click(object sender, EventArgs e)
        {
            x1Time = DateTime.Now;
            OutSign1 = false;
            Thread t = new Thread(new ThreadStart(TestProcess));
            t.IsBackground = true;
            t.Start();
        }
        bool OutSign1 = false;//停止标志
        DateTime x1Time;
        private void TestProcess() {
            volChart1.Series[0].Points.Clear();
            eleChart1.Series[0].Points.Clear();

            double vlo = (double)volteVal1.Value;
            double ele = (double)eleVal1.Value;
            var cyc = cycleNum1.Value;
            var open = openTime1.Value;
            var close = closeTime1.Value;
            int point = (int)getPoint1.Value;          

            int error = 0;
            string strErrMsg = "";
            double reVlote = 0, reElect = 0;

            //设置电压和电流
            error = N5769ADriver.SetVolAndEle(CGloabal.g_N5769AModule.nHandle, vlo, ele, strErrMsg);
            if (error < 0)
            {
                CommonMethod.ShowHintInfor(eHintInfoType.error, strErrMsg);
                return;
            }

            //读取应该间隔多少时间取一个点
            int OpenReadtimer = MixHelper.ReturnInterval(comboUnit1.Text, 1, open, close, point);
             int CloseReadTimer = MixHelper.ReturnInterval(comboUnit1.Text, 0, open, close, point);

            while (cyc>0)
            {               
                cyc--;
                //打开命令
                error = N5769ADriver.SetOpenCommand(CGloabal.g_N5769AModule.nHandle, strErrMsg);
                if (error < 0)
                {
                    CommonMethod.ShowHintInfor(eHintInfoType.error, strErrMsg);
                    return;
                }
                for (int i = 0; i < point; i++)
                {
                    if (OutSign1)
                    {//为true时则终止测试
                        error = N5769ADriver.SetCloseCommand(CGloabal.g_N5769AModule.nHandle, strErrMsg);
                        return;
                    }

                    Thread.Sleep(OpenReadtimer);

                    TimeSpan ts = DateTime.Now - x1Time;
                    string xOpenVal = ts.Minutes + ":" + ts.Seconds;
                    //读取电压和电流        
                    N5769ADriver.ReadVolAndEleCommand(CGloabal.g_N5769AModule.nHandle, ref reVlote, ref reElect);
                    volChart1.Series[0].Points.AddXY(xOpenVal, reVlote);
                    eleChart1.Series[0].Points.AddXY(xOpenVal, reElect);
                }

                //发送关闭指令
                error = N5769ADriver.SetCloseCommand(CGloabal.g_N5769AModule.nHandle, strErrMsg);
                if (error < 0)
                {
                    CommonMethod.ShowHintInfor(eHintInfoType.error, strErrMsg);
                    return;
                }
                for (int i = 0; i < point; i++)
                {
                    if (OutSign1)
                    {//为true时则终止测试
                        error = N5769ADriver.SetCloseCommand(CGloabal.g_N5769AModule.nHandle, strErrMsg);
                        return;
                    }

                    Thread.Sleep(CloseReadTimer);
                    TimeSpan ts = DateTime.Now - x1Time;
                    string xCloseVal = ts.Minutes + ":" + ts.Seconds;
                    //读取电压和电流        
                    N5769ADriver.ReadVolAndEleCommand(CGloabal.g_N5769AModule.nHandle, ref reVlote, ref reElect);
                    volChart1.Series[0].Points.AddXY(xCloseVal, reVlote);
                    eleChart1.Series[0].Points.AddXY(xCloseVal, reElect);
                }
            }
        }

        private void btnStop1_Click(object sender, EventArgs e)
        {
            OutSign1 = true;
        }

        private void btnSave1_Click(object sender, EventArgs e)
        {
            MixHelper.SaveCSVFile(volChart1, eleChart1);
        }

        private void btnOpen2_Click(object sender, EventArgs e)
        {//N5751A
            string strIP;
            UInt32 nPort;
            string resourceName;
            int error = 0;
            if (btnOpen2.Text == "打开")//用户要连接仪器
            {
                strIP = this.ipAddress2.Text;
                nPort = 8080;
                //连接设备
                resourceName = "TCPIP0::" + strIP + "::inst0::INSTR";

                error = CommonMethod.ConnectSpecificInstrument(CGloabal.g_N5751AModule.strInstruName, resourceName);
                if (error < 0)//连接失败
                {
                    CommonMethod.ShowHintInfor(eHintInfoType.error, "电源打开失败！");
                    btnOpen2.Text = "打开";
                }
                else//连接成功,则要将当前用户输入的IP地址和端口号保存到ini文件中
                {
                    CommonMethod.SaveInputNetInforsToIniFile(CGloabal.g_N5751AModule.strInstruName, strIP, nPort);
                    btnOpen2.Text = "关闭";
                }
            }
            else//此时用户要断开连接
            {
                error = CommonMethod.CloseSpecificInstrument(CGloabal.g_N5751AModule.strInstruName);
                if (error < 0)//断开失败，则还要将switchConnect恢复为连接状态      
                {
                    btnOpen2.Text = "关闭";
                }
                else
                {
                    btnOpen2.Text = "打开";
                }
            }
        }

        private void volteVal2_ValueChanged(object sender, EventArgs e)
        {
            volChart2.ChartAreas[0].AxisY.Maximum = (double)volteVal2.Value;
        }

        private void btnStart2_Click(object sender, EventArgs e)
        {
            x2Time = DateTime.Now;
            OutSign2 = false;
            Thread t2 = new Thread(new ThreadStart(TestProcess2));
            t2.IsBackground = true;
            t2.Start();
        }
        bool OutSign2 = false;
        DateTime x2Time;
        private void TestProcess2()
        {
            volChart2.Series[0].Points.Clear();
            eleChart2.Series[0].Points.Clear();

            double vlo = (double)volteVal2.Value;
            double ele = (double)eleVal2.Value;
            var cyc = cycleNum2.Value;
            var open = openTime2.Value;
            var close = closeTime2.Value;
            int point = (int)getPoint2.Value;

            int error = 0;
            string strErrMsg = "";
            double reVlote = 0, reElect = 0;

            //设置电压和电流
            error = N5751ADriver.SetVolAndEle(CGloabal.g_N5751AModule.nHandle, vlo, ele, strErrMsg);
            if (error < 0)
            {
                CommonMethod.ShowHintInfor(eHintInfoType.error, strErrMsg);
                return;
            }

            //读取应该间隔多少时间取一个点
            int OpenReadtimer = MixHelper.ReturnInterval(comboUnit2.Text, 1, open, close, point);
            int CloseReadTimer = MixHelper.ReturnInterval(comboUnit2.Text, 0, open, close, point);

            while (cyc > 0)
            {                
                cyc--;
                //打开命令
                error = N5751ADriver.SetOpenCommand(CGloabal.g_N5751AModule.nHandle, strErrMsg);
                if (error < 0)
                {
                    CommonMethod.ShowHintInfor(eHintInfoType.error, strErrMsg);
                    return;
                }
                for (int i = 0; i < point; i++)
                {
                    if (OutSign2)
                    {//为true时则终止测试
                        error = N5751ADriver.SetCloseCommand(CGloabal.g_N5751AModule.nHandle, strErrMsg);
                        return;
                    }

                    Thread.Sleep(OpenReadtimer);
                    //读取电压和电流        
                    TimeSpan ts = DateTime.Now - x2Time;
                    string xOpenVal2 = ts.Minutes + ":" + ts.Seconds;

                    N5751ADriver.ReadVolAndEleCommand(CGloabal.g_N5751AModule.nHandle, ref reVlote, ref reElect);
                    volChart2.Series[0].Points.AddXY(xOpenVal2, reVlote);
                    eleChart2.Series[0].Points.AddXY(xOpenVal2, reElect);
                }

                //发送关闭指令
                error = N5751ADriver.SetCloseCommand(CGloabal.g_N5751AModule.nHandle, strErrMsg);
                if (error < 0)
                {
                    CommonMethod.ShowHintInfor(eHintInfoType.error, strErrMsg);
                    return;
                }
                for (int i = 0; i < point; i++)
                {
                    if (OutSign2)
                    {//为true时则终止测试
                        error = N5751ADriver.SetCloseCommand(CGloabal.g_N5751AModule.nHandle, strErrMsg);
                        return;
                    }

                    Thread.Sleep(CloseReadTimer);
                    TimeSpan ts = DateTime.Now - x2Time;
                    string xCloseVal2 = ts.Minutes + ":" + ts.Seconds;
                    //读取电压和电流        
                    N5751ADriver.ReadVolAndEleCommand(CGloabal.g_N5751AModule.nHandle, ref reVlote, ref reElect);
                    volChart2.Series[0].Points.AddXY(xCloseVal2, reVlote);
                    eleChart2.Series[0].Points.AddXY(xCloseVal2, reElect);
                }
            }
        }

        private void btnStop2_Click(object sender, EventArgs e)
        {
            OutSign2 = true;
        }

        private void btnSave2_Click(object sender, EventArgs e)
        {
            MixHelper.SaveCSVFile(volChart2, eleChart2);
        }

        private void btnOpen3_Click(object sender, EventArgs e)
        {//N5752A
            string strIP;
            UInt32 nPort;
            string resourceName;
            int error = 0;
            if (btnOpen3.Text == "打开")//用户要连接仪器
            {
                strIP = this.ipAddress3.Text;
                nPort = 8080;
                //连接设备
                resourceName = "TCPIP0::" + strIP + "::inst0::INSTR";

                error = CommonMethod.ConnectSpecificInstrument(CGloabal.g_N5752AModule.strInstruName, resourceName);
                if (error < 0)//连接失败
                {
                    CommonMethod.ShowHintInfor(eHintInfoType.error, "电源打开失败！");
                    btnOpen3.Text = "打开";
                }
                else//连接成功,则要将当前用户输入的IP地址和端口号保存到ini文件中
                {
                    CommonMethod.SaveInputNetInforsToIniFile(CGloabal.g_N5752AModule.strInstruName, strIP, nPort);
                    btnOpen3.Text = "关闭";
                }
            }
            else//此时用户要断开连接
            {
                error = CommonMethod.CloseSpecificInstrument(CGloabal.g_N5752AModule.strInstruName);
                if (error < 0)//断开失败，则还要将switchConnect恢复为连接状态      
                {
                    btnOpen3.Text = "关闭";
                }
                else
                {
                    btnOpen3.Text = "打开";
                }
            }
        }

        private void volteVal3_ValueChanged(object sender, EventArgs e)
        {
            volChart2.ChartAreas[0].AxisY.Maximum = (double)volteVal3.Value;
        }

        private void btnStart3_Click(object sender, EventArgs e)
        {
            x3Time = System.DateTime.Now;
            OutSign3 = false;
            Thread t3 = new Thread(new ThreadStart(TestProcess3));
            t3.IsBackground = true;
            t3.Start();
        }
        bool OutSign3 = false;
        DateTime x3Time;
        private void TestProcess3()
        {
            volChart3.Series[0].Points.Clear();
            eleChart3.Series[0].Points.Clear();

            double vlo = (double)volteVal3.Value;
            double ele = (double)eleVal3.Value;
            var cyc = cycleNum3.Value;
            var open = openTime3.Value;
            var close = closeTime3.Value;
            int point = (int)getPoint3.Value;

            int error = 0;
            string strErrMsg = "";
            double reVlote = 0, reElect = 0;

            //设置电压和电流
            error = N5752ADriver.SetVolAndEle(CGloabal.g_N5752AModule.nHandle, vlo, ele, strErrMsg);
            if (error < 0)
            {
                CommonMethod.ShowHintInfor(eHintInfoType.error, strErrMsg);
                return;
            }

            //读取应该间隔多少时间取一个点
            int OpenReadtimer = MixHelper.ReturnInterval(comboUnit3.Text, 1, open, close, point);
            int CloseReadTimer = MixHelper.ReturnInterval(comboUnit3.Text, 0, open, close, point);

            while (cyc > 0)
            {               
                cyc--;
                //打开命令
                error = N5752ADriver.SetOpenCommand(CGloabal.g_N5752AModule.nHandle, strErrMsg);
                if (error < 0)
                {
                    CommonMethod.ShowHintInfor(eHintInfoType.error, strErrMsg);
                    return;
                }
                for (int i = 0; i < point; i++)
                {
                    if (OutSign3)
                    {//为true时则终止测试
                        error = N5752ADriver.SetCloseCommand(CGloabal.g_N5752AModule.nHandle, strErrMsg);
                        return;
                    }
                    Thread.Sleep(OpenReadtimer);
                    TimeSpan ts = DateTime.Now - x3Time;
                    string xOpenVal3 = ts.Minutes + ":" + ts.Seconds;
                    //读取电压和电流        
                    N5752ADriver.ReadVolAndEleCommand(CGloabal.g_N5752AModule.nHandle, ref reVlote, ref reElect);
                    volChart3.Series[0].Points.AddXY(xOpenVal3, reVlote);
                    eleChart3.Series[0].Points.AddXY(xOpenVal3, reElect);
                }

                //发送关闭指令
                error = N5752ADriver.SetCloseCommand(CGloabal.g_N5752AModule.nHandle, strErrMsg);
                if (error < 0)
                {
                    CommonMethod.ShowHintInfor(eHintInfoType.error, strErrMsg);
                    return;
                }
                for (int i = 0; i < point; i++)
                {
                    if (OutSign3)
                    {//为true时则终止测试
                        error = N5752ADriver.SetCloseCommand(CGloabal.g_N5752AModule.nHandle, strErrMsg);
                        return;
                    }
                    Thread.Sleep(CloseReadTimer);
                    TimeSpan ts = DateTime.Now - x3Time;
                    string xCloseVal3 = ts.Minutes + ":" + ts.Seconds;
                    //读取电压和电流        
                    N5752ADriver.ReadVolAndEleCommand(CGloabal.g_N5752AModule.nHandle, ref reVlote, ref reElect);
                    volChart3.Series[0].Points.AddXY(xCloseVal3, reVlote);
                    eleChart3.Series[0].Points.AddXY(xCloseVal3, reElect);
                }
            }
        }

        private void btnStop3_Click(object sender, EventArgs e)
        {
            OutSign3 = true;
        }
        private void btnSave3_Click(object sender, EventArgs e)
        {
            MixHelper.SaveCSVFile(volChart3, eleChart3);
        }

        private void btnOpen4_Click(object sender, EventArgs e)
        {
            //N5772A
            string strIP;
            UInt32 nPort;
            string resourceName;
            int error = 0;
            if (btnOpen4.Text == "打开")//用户要连接仪器
            {
                strIP = this.ipAddress4.Text;
                nPort = 8080;
                //连接设备
                resourceName = "TCPIP0::" + strIP + "::inst0::INSTR";

                error = CommonMethod.ConnectSpecificInstrument(CGloabal.g_N5772AModule.strInstruName, resourceName);
                if (error < 0)//连接失败
                {
                    CommonMethod.ShowHintInfor(eHintInfoType.error, "电源打开失败！");
                    btnOpen4.Text = "打开";
                }
                else//连接成功,则要将当前用户输入的IP地址和端口号保存到ini文件中
                {
                    CommonMethod.SaveInputNetInforsToIniFile(CGloabal.g_N5772AModule.strInstruName, strIP, nPort);
                    btnOpen4.Text = "关闭";
                }
            }
            else//此时用户要断开连接
            {
                error = CommonMethod.CloseSpecificInstrument(CGloabal.g_N5772AModule.strInstruName);
                if (error < 0)//断开失败，则还要将switchConnect恢复为连接状态      
                {
                    btnOpen4.Text = "关闭";
                }
                else
                {
                    btnOpen4.Text = "打开";
                }
            }
        }

        private void volteVal4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnStart4_Click(object sender, EventArgs e)
        {
            x4Time = DateTime.Now;
            OutSign4 = false;
            Thread t = new Thread(new ThreadStart(TestProcess4));
            t.IsBackground = true;
            t.Start();
        }
        bool OutSign4 = false;
        DateTime x4Time;
        private void TestProcess4()
        {
            volChart4.Series[0].Points.Clear();
            eleChart4.Series[0].Points.Clear();

            double vlo = (double)volteVal4.Value;
            double ele = (double)eleVal4.Value;
            var cyc = cycleNum4.Value;
            var open = openTime4.Value;
            var close = closeTime4.Value;
            int point = (int)getPoint4.Value;

            int error = 0;
            string strErrMsg = "";
            double reVlote = 0, reElect = 0;

            //设置电压和电流
            error = N5751ADriver.SetVolAndEle(CGloabal.g_N5772AModule.nHandle, vlo, ele, strErrMsg);
            if (error < 0)
            {
                CommonMethod.ShowHintInfor(eHintInfoType.error, strErrMsg);
                return;
            }

            //读取应该间隔多少时间取一个点
            int OpenReadtimer = MixHelper.ReturnInterval(comboUnit4.Text, 1, open, close, point);
            int CloseReadTimer = MixHelper.ReturnInterval(comboUnit4.Text, 0, open, close, point);

            while (cyc > 0)
            {                
                cyc--;
                //打开命令
                error = N5769ADriver.SetOpenCommand(CGloabal.g_N5772AModule.nHandle, strErrMsg);
                if (error < 0)
                {
                    CommonMethod.ShowHintInfor(eHintInfoType.error, strErrMsg);
                    return;
                }
                for (int i = 0; i < point; i++)
                {
                    if (OutSign4)
                    {//为true时则终止测试
                        error = N5769ADriver.SetCloseCommand(CGloabal.g_N5772AModule.nHandle, strErrMsg);
                        return;
                    }
                    Thread.Sleep(OpenReadtimer);
                    TimeSpan ts = DateTime.Now - x4Time;
                    string xOpenVal4 = ts.Minutes + ":" + ts.Seconds;
                    //读取电压和电流        
                    N5769ADriver.ReadVolAndEleCommand(CGloabal.g_N5772AModule.nHandle, ref reVlote, ref reElect);
                    volChart4.Series[0].Points.AddXY(xOpenVal4, reVlote);
                    eleChart4.Series[0].Points.AddXY(xOpenVal4, reElect);
                }

                //发送关闭指令
                error = N5769ADriver.SetCloseCommand(CGloabal.g_N5772AModule.nHandle, strErrMsg);
                if (error < 0)
                {
                    CommonMethod.ShowHintInfor(eHintInfoType.error, strErrMsg);
                    return;
                }
                for (int i = 0; i < point; i++)
                {
                    if (OutSign4)
                    {//为true时则终止测试
                        error = N5769ADriver.SetCloseCommand(CGloabal.g_N5772AModule.nHandle, strErrMsg);
                        return;
                    }
                    Thread.Sleep(CloseReadTimer);
                    TimeSpan ts = DateTime.Now - x4Time;
                    string xCloseVal4 = ts.Minutes + ":" + ts.Seconds;
                    //读取电压和电流        
                    N5769ADriver.ReadVolAndEleCommand(CGloabal.g_N5772AModule.nHandle, ref reVlote, ref reElect);
                    volChart4.Series[0].Points.AddXY(xCloseVal4, reVlote);
                    eleChart4.Series[0].Points.AddXY(xCloseVal4, reElect);
                }
            }
        }

        private void btnStop4_Click(object sender, EventArgs e)
        {
            OutSign4 = true;
        }

        private void btnSave4_Click(object sender, EventArgs e)
        {
            MixHelper.SaveCSVFile(volChart4, eleChart4);
        }

        private void btnOpen5_Click(object sender, EventArgs e)
        {
            //N6702A
            string strIP;
            UInt32 nPort;
            string resourceName;
            int error = 0;
            if (btnOpen5.Text == "打开")//用户要连接仪器
            {
                strIP = this.ipAddress5.Text;
                nPort = 8080;
                //连接设备
                resourceName = "TCPIP0::" + strIP + "::inst0::INSTR";

                error = CommonMethod.ConnectSpecificInstrument(CGloabal.g_N6702AModule.strInstruName, resourceName);
                if (error < 0)//连接失败
                {
                    CommonMethod.ShowHintInfor(eHintInfoType.error, "电源打开失败！");
                    btnOpen5.Text = "打开";
                }
                else//连接成功,则要将当前用户输入的IP地址和端口号保存到ini文件中
                {
                    CommonMethod.SaveInputNetInforsToIniFile(CGloabal.g_N6702AModule.strInstruName, strIP, nPort);
                    btnOpen5.Text = "关闭";
                }
            }
            else//此时用户要断开连接
            {
                error = CommonMethod.CloseSpecificInstrument(CGloabal.g_N6702AModule.strInstruName);
                if (error < 0)//断开失败，则还要将switchConnect恢复为连接状态      
                {
                    btnOpen5.Text = "关闭";
                }
                else
                {
                    btnOpen5.Text = "打开";
                }
            }
        }

        private void volteVal5_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnStart_Click(object sender, EventArgs e)
        { //通道数组
            int[] pathArr = new int[4] { 0, 0, 0, 0 };
            if (btnPath61.BackColor == Color.LightGreen)
                pathArr[0] = 1;
            if (btnPath62.BackColor == Color.LightGreen)
                pathArr[1] = 1;
            if (btnPath63.BackColor == Color.LightGreen)
                pathArr[2] = 1;
            if (btnPath64.BackColor == Color.LightGreen)
                pathArr[3] = 1;

            for (int i = 0; i < pathArr.Length; i++)
            {
                if (pathArr[i] == 1)
                {
                    OutSign5 = false;
                    Thread t = new Thread(new ParameterizedThreadStart(TestProcess5));
                    t.IsBackground = true;
                    x5Time = DateTime.Now;
                    t.Start(i+1);
                }
            }
        }
        bool OutSign5 = false;
        DateTime x5Time;
        private void TestProcess5(object obj)
        {
            int chipId = Convert.ToInt32(obj.ToString());

            switch (chipId)
            {
                case 1:
                    volChart51.Series[0].Points.Clear();
                    eleChart51.Series[0].Points.Clear();
                    break;
                case 2:
                    volChart52.Series[0].Points.Clear();
                    eleChart52.Series[0].Points.Clear();
                    break;
                case 3:
                    volChart53.Series[0].Points.Clear();
                    eleChart53.Series[0].Points.Clear();
                    break;
                case 4:
                    volChart54.Series[0].Points.Clear();
                    eleChart54.Series[0].Points.Clear();
                    break;
                default: break;
            }

            double vlo = (double)volteVal5.Value;
            double ele = (double)eleVal5.Value;
            var cyc = cycleNum5.Value;
            var open = openTime5.Value;
            var close = closeTime5.Value;
            int point = (int)getPoint5.Value;

            int error = 0;
            string strErrMsg = "";
            double reVlote = 0, reElect = 0;

            //设置电压和电流
            error = N6702ADriver.SetVolAndEle(CGloabal.g_N6702AModule.nHandle, vlo, ele, strErrMsg);
            if (error < 0)
            {
                CommonMethod.ShowHintInfor(eHintInfoType.error, strErrMsg);
                return;
            }

            //读取应该间隔多少时间取一个点
            int OpenReadtimer = MixHelper.ReturnInterval(comboUnit5.Text, 1, open, close, point);
            int CloseReadTimer = MixHelper.ReturnInterval(comboUnit5.Text, 0, open, close, point);

            while (cyc > 0)
            {
                cyc--;
                //打开命令
                error = N6702ADriver.SetOpenCommand(CGloabal.g_N6702AModule.nHandle, strErrMsg);
                if (error < 0)
                {
                    CommonMethod.ShowHintInfor(eHintInfoType.error, strErrMsg);
                    return;
                }
                for (int i = 0; i < point; i++)
                {
                    if (OutSign5)
                    {//为true时则终止测试
                        error = N6702ADriver.SetCloseCommand(CGloabal.g_N6702AModule.nHandle, strErrMsg);
                        return;
                    }
                    Thread.Sleep(OpenReadtimer);
                    TimeSpan ts = DateTime.Now - x5Time;
                    string xOpenVal5 = ts.Minutes + ":" + ts.Seconds;
                    //读取电压和电流        
                    N6702ADriver.ReadVolAndEleCommand(CGloabal.g_N6702AModule.nHandle, ref reVlote, ref reElect);
                    N6702SeriesSetChart(chipId, xOpenVal5, reVlote, reElect);
                    //volChart51.Series[0].Points.AddXY(xOpenVal5, reVlote);
                    //eleChart51.Series[0].Points.AddXY(xOpenVal5, reElect);
                }

                //发送关闭指令
                error = N6702ADriver.SetCloseCommand(CGloabal.g_N6702AModule.nHandle, strErrMsg);
                if (error < 0)
                {
                    CommonMethod.ShowHintInfor(eHintInfoType.error, strErrMsg);
                    return;
                }
                for (int i = 0; i < point; i++)
                {
                    if (OutSign5)
                    {//为true时则终止测试
                        error = N6702ADriver.SetCloseCommand(CGloabal.g_N6702AModule.nHandle, strErrMsg);
                        return;
                    }
                    Thread.Sleep(CloseReadTimer);
                    TimeSpan ts = DateTime.Now - x5Time;
                    string xCloseVal5 = ts.Minutes + ":" + ts.Seconds;
                    //读取电压和电流        
                    N6702ADriver.ReadVolAndEleCommand(CGloabal.g_N6702AModule.nHandle, ref reVlote, ref reElect);
                    N6702SeriesSetChart(chipId, xCloseVal5, reVlote, reElect);
                    //volChart51.Series[0].Points.AddXY(xCloseVal5, reVlote);
                    //eleChart51.Series[0].Points.AddXY(xCloseVal5, reElect);
                }
            }
        }

        private void N6702SeriesSetChart(int chipId, string xVal, double reVlote, double reElect)
        {
            switch (chipId)
            {
                case 1:
                    volChart51.Series[0].Points.AddXY(xVal, reVlote);
                    eleChart51.Series[0].Points.AddXY(xVal, reElect);
                    break;
                case 2:
                    volChart52.Series[0].Points.AddXY(xVal, reVlote);
                    eleChart52.Series[0].Points.AddXY(xVal, reElect);
                    break;
                case 3:
                    volChart53.Series[0].Points.AddXY(xVal, reVlote);
                    eleChart53.Series[0].Points.AddXY(xVal, reElect);
                    break;
                case 4:
                    volChart54.Series[0].Points.AddXY(xVal, reVlote);
                    eleChart54.Series[0].Points.AddXY(xVal, reElect);
                    break;
                default:
                    break;

            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {

        }

        private void btnSave5_Click(object sender, EventArgs e)
        {
            MixHelper.SaveCSVFile(volChart51, eleChart51);
        }

        private void btnOpen6_Click(object sender, EventArgs e)
        {
            //N6705A
            string strIP;
            UInt32 nPort;
            string resourceName;
            int error = 0;
            if (btnOpen6.Text == "打开")//用户要连接仪器
            {
                strIP = this.ipAddress6.Text;
                nPort = 8080;
                //连接设备
                resourceName = "TCPIP0::" + strIP + "::inst0::INSTR";

                error = CommonMethod.ConnectSpecificInstrument(CGloabal.g_N6705AModule.strInstruName, resourceName);
                if (error < 0)//连接失败
                {
                    CommonMethod.ShowHintInfor(eHintInfoType.error, "电源打开失败！");
                    btnOpen6.Text = "打开";
                }
                else//连接成功,则要将当前用户输入的IP地址和端口号保存到ini文件中
                {
                    CommonMethod.SaveInputNetInforsToIniFile(CGloabal.g_N6705AModule.strInstruName, strIP, nPort);
                    btnOpen6.Text = "关闭";
                }
            }
            else//此时用户要断开连接
            {
                error = CommonMethod.CloseSpecificInstrument(CGloabal.g_N6705AModule.strInstruName);
                if (error < 0)//断开失败，则还要将switchConnect恢复为连接状态      
                {
                    btnOpen6.Text = "关闭";
                }
                else
                {
                    btnOpen6.Text = "打开";
                }
            }
        }

        private void volteVal6_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnStart6_Click(object sender, EventArgs e)
        {
            //通道数组
            int[] pathArr = new int[4] { 0,0,0,0};
            if (btnPath61.BackColor == Color.LightGreen)
                pathArr[0] = 1;
            if (btnPath62.BackColor == Color.LightGreen)
                pathArr[1] = 1;
            if (btnPath63.BackColor == Color.LightGreen)
                pathArr[2] = 1;
            if (btnPath64.BackColor == Color.LightGreen)
                pathArr[3] = 1;

            x6Time = DateTime.Now;
            for (int i = 0; i < pathArr.Length; i++)
            {
                if (pathArr[i] == 1) {
                    OutSign6 = false;
                    Thread t = new Thread(new ParameterizedThreadStart(TestProcess6));
                    t.IsBackground = true;
                    t.Start(i+1);
                }
               
            }
        }
        bool OutSign6 = false;
        DateTime x6Time;
        private void TestProcess6(object obj)
        {          
            int chipId = Convert.ToInt32(obj.ToString());
            double vlo =0 ;
            double ele =0;
            switch (chipId) {
                case 1:
                    volChart61.Series[0].Points.Clear();
                    eleChart61.Series[0].Points.Clear();
                     vlo = (double)volteVal61.Value;
                     ele = (double)eleVal61.Value;
                    break;
                case 2:
                    volChart62.Series[0].Points.Clear();
                    eleChart62.Series[0].Points.Clear();
                    vlo = (double)volteVal62.Value;
                    ele = (double)eleVal62.Value;
                    break;
                case 3:
                    volChart63.Series[0].Points.Clear();
                    eleChart63.Series[0].Points.Clear();
                    vlo = (double)volteVal63.Value;
                    ele = (double)eleVal63.Value;
                    break;
                case 4:
                    volChart64.Series[0].Points.Clear();
                    eleChart64.Series[0].Points.Clear();
                    vlo = (double)volteVal63.Value;
                    ele = (double)eleVal63.Value;
                    break;
                default:break;
            }
           

           
            var cyc = cycleNum6.Value;
            var open = openTime6.Value;
            var close = closeTime6.Value;
            int point = (int)getPoint6.Value;

            int error = 0;
            string strErrMsg = "";
            double reVlote = 0, reElect = 0;

            //设置电压和电流
            error = N6705ADriver.SetVolAndEle(CGloabal.g_N6705AModule.nHandle, vlo, ele, chipId, strErrMsg);
            if (error < 0)
            {
                CommonMethod.ShowHintInfor(eHintInfoType.error, strErrMsg);
                return;
            }

            //读取应该间隔多少时间取一个点
            int OpenReadtimer = MixHelper.ReturnInterval(comboUnit6.Text, 1, open, close, point);
            int CloseReadTimer = MixHelper.ReturnInterval(comboUnit6.Text, 0, open, close, point);

            while (cyc > 0)
            {
                cyc--;
                //打开命令
                error = N6705ADriver.SetOpenCommand(CGloabal.g_N6705AModule.nHandle, chipId, strErrMsg);
                if (error < 0)
                {
                    CommonMethod.ShowHintInfor(eHintInfoType.error, strErrMsg);
                    return;
                }
                for (int i = 0; i < point; i++)
                {
                    if (OutSign6)
                    {//为true时则发送关闭指令，终止测试
                        error = N6705ADriver.SetCloseCommand(CGloabal.g_N6705AModule.nHandle, chipId, strErrMsg);
                        if (error < 0)
                        {
                            CommonMethod.ShowHintInfor(eHintInfoType.error, strErrMsg);
                            return;
                        }

                        return;
                    }
                    Thread.Sleep(OpenReadtimer);
                    TimeSpan ts = DateTime.Now - x6Time;
                    string xOpenVal6 = ts.Minutes + ":" + ts.Seconds;
                    //读取电压和电流        
                    N6705ADriver.ReadVolAndEleCommand(CGloabal.g_N6705AModule.nHandle, chipId, ref reVlote, ref reElect);
                    N6705SeriesSetChart(chipId, xOpenVal6, reVlote, reElect);
                    //volChart61.Series[0].Points.AddXY(xOpenVal6, reVlote);
                    //eleChart61.Series[0].Points.AddXY(xOpenVal6, reElect);
                }

                //发送关闭指令
                error = N6705ADriver.SetCloseCommand(CGloabal.g_N6705AModule.nHandle, chipId, strErrMsg);
                if (error < 0)
                {
                    CommonMethod.ShowHintInfor(eHintInfoType.error, strErrMsg);
                    return;
                }
                for (int i = 0; i < point; i++)
                {
                    if (OutSign6)
                    {//为true时则终止测试
                        error = N6705ADriver.SetCloseCommand(CGloabal.g_N6705AModule.nHandle, chipId, strErrMsg);
                        if (error < 0)
                        {
                            CommonMethod.ShowHintInfor(eHintInfoType.error, strErrMsg);
                            return;
                        }
                        return;
                    }
                    Thread.Sleep(CloseReadTimer);
                    TimeSpan ts = DateTime.Now - x6Time;
                    string xCloseVal6 = ts.Minutes + ":" + ts.Seconds;
                    //读取电压和电流        
                    N6705ADriver.ReadVolAndEleCommand(CGloabal.g_N6705AModule.nHandle, chipId, ref reVlote, ref reElect);
                    N6705SeriesSetChart(chipId, xCloseVal6, reVlote, reElect);
                    //volChart61.Series[0].Points.AddXY(xCloseVal6, reVlote);
                    //eleChart61.Series[0].Points.AddXY(xCloseVal6, reElect);
                }
            }
        }

        private void N6705SeriesSetChart(int chipId,string xVal,double reVlote,double reElect) {
            switch (chipId)
            {
                case 1:
                    volChart61.Series[0].Points.AddXY(xVal, reVlote);
                    eleChart61.Series[0].Points.AddXY(xVal, reElect);
                    break;
                case 2:
                    volChart62.Series[0].Points.AddXY(xVal, reVlote);
                    eleChart62.Series[0].Points.AddXY(xVal, reElect);
                    break;
                case 3:
                    volChart63.Series[0].Points.AddXY(xVal, reVlote);
                    eleChart63.Series[0].Points.AddXY(xVal, reElect);
                    break;
                case 4:
                    volChart64.Series[0].Points.AddXY(xVal, reVlote);
                    eleChart64.Series[0].Points.AddXY(xVal, reElect);
                    break;
                default:
                    break;

            }
        }

        private void btnStop6_Click(object sender, EventArgs e)
        {
            OutSign6 = true;
        }

        private void btnSave6_Click(object sender, EventArgs e)
        {
            MixHelper.SaveCSVFile(volChart61, eleChart61);
        }

        private void btnView1_Click(object sender, EventArgs e)
        {
            ViewForm VF = new ViewForm(volChart1, eleChart1);
            VF.ShowDialog();
        }
        private void btnView2_Click(object sender, EventArgs e)
        {
            ViewForm VF = new ViewForm(volChart2, eleChart2);
            VF.ShowDialog();
        }

        private void btnView3_Click(object sender, EventArgs e)
        {
            ViewForm VF = new ViewForm(volChart3, eleChart3);
            VF.ShowDialog();
        }

        private void btnView4_Click(object sender, EventArgs e)
        {
            ViewForm VF = new ViewForm(volChart4, eleChart4);
            VF.ShowDialog();
        }

        private void btnView5_Click(object sender, EventArgs e)
        {
            if (N6702ATab.SelectedTab.Text == "通道1")
            {
                ViewForm VF = new ViewForm(volChart51, eleChart51);
                VF.ShowDialog();
            }
            else if (N6702ATab.SelectedTab.Text == "通道2")
            {
                ViewForm VF = new ViewForm(volChart52, eleChart52);
                VF.ShowDialog();
            }
            else if (N6702ATab.SelectedTab.Text == "通道3")
            {
                ViewForm VF = new ViewForm(volChart53, eleChart53);
                VF.ShowDialog();
            }
            else if (N6702ATab.SelectedTab.Text == "通道4")
            {
                ViewForm VF = new ViewForm(volChart54, eleChart54);
                VF.ShowDialog();
            }
        }
        private void btnView6_Click(object sender, EventArgs e)
        {
            if (N6705ATab.SelectedTab.Text == "通道1") {
                ViewForm VF = new ViewForm(volChart61, eleChart61);
                VF.ShowDialog();
            }
            else if (N6705ATab.SelectedTab.Text == "通道2")
            {
                ViewForm VF = new ViewForm(volChart62, eleChart62);
                VF.ShowDialog();
            }
            else if (N6705ATab.SelectedTab.Text == "通道3")
            {
                ViewForm VF = new ViewForm(volChart63, eleChart63);
                VF.ShowDialog();
            }
            else if (N6705ATab.SelectedTab.Text == "通道4")
            {
                ViewForm VF = new ViewForm(volChart64, eleChart64);
                VF.ShowDialog();
            }
        }

        private void btnPath61_Click(object sender, EventArgs e)
        {
            if (btnPath61.BackColor == Color.WhiteSmoke)
            {
                //打开通道
               // comPathClick(CGloabal.g_N6705AModule.nHandle, 0, 1);
                //改变颜色
                btnPath61.BackColor = Color.LightGreen;
            }
            else {
                //关闭通道
               // comPathClick(CGloabal.g_N6705AModule.nHandle, 1, 1);
                //改变颜色
                btnPath61.BackColor = Color.WhiteSmoke;
            }
        }

        private void btnPath62_Click(object sender, EventArgs e)
        {
            if (btnPath62.BackColor == Color.WhiteSmoke)
            {
                //打开通道
              //  comPathClick(CGloabal.g_N6705AModule.nHandle, 0, 2);
                //改变颜色
                btnPath62.BackColor = Color.LightGreen;
            }
            else
            {
                //关闭通道
             //   comPathClick(CGloabal.g_N6705AModule.nHandle, 1, 2);
                //改变颜色
                btnPath62.BackColor = Color.WhiteSmoke;
            }
        }

        private void btnPath63_Click(object sender, EventArgs e)
        {            
            if (btnPath63.BackColor == Color.WhiteSmoke)
            {
                //打开通道
              //  comPathClick(CGloabal.g_N6705AModule.nHandle, 0, 3);
                //改变颜色
                btnPath63.BackColor = Color.LightGreen;
            }
            else
            {
                //关闭通道
             //   comPathClick(CGloabal.g_N6705AModule.nHandle, 1, 3);
                //改变颜色
                btnPath63.BackColor = Color.WhiteSmoke;
            }
        }

        private void btnPath64_Click(object sender, EventArgs e)
        {           
            if (btnPath64.BackColor == Color.WhiteSmoke)
            {
                //打开通道
             //   comPathClick(CGloabal.g_N6705AModule.nHandle, 0, 4);
                //改变颜色
                btnPath64.BackColor = Color.LightGreen;
            }
            else
            {
                //关闭通道
              //  comPathClick(CGloabal.g_N6705AModule.nHandle, 1, 4);
                //改变颜色
                btnPath64.BackColor = Color.WhiteSmoke;
            }
        }

        private void btnPath51_Click(object sender, EventArgs e)
        {
            if (btnPath64.BackColor == Color.WhiteSmoke)
            {    //打开通道
               // comPathClick(CGloabal.g_N6702AModule.nHandle, 0, 1);
                //改变颜色
                btnPath51.BackColor = Color.LightGreen;
            }
            else
            {   //关闭通道
             //   comPathClick(CGloabal.g_N6702AModule.nHandle, 1, 1);
                //改变颜色
                btnPath51.BackColor = Color.WhiteSmoke;
            }
        }

        private void btnPath52_Click(object sender, EventArgs e)
        {
            if (btnPath52.BackColor == Color.WhiteSmoke)
            {    //打开通道
              //  comPathClick(CGloabal.g_N6702AModule.nHandle, 0, 2);
                //改变颜色
                btnPath52.BackColor = Color.LightGreen;
            }
            else
            {   //关闭通道
             //   comPathClick(CGloabal.g_N6702AModule.nHandle, 1, 2);
                //改变颜色
                btnPath52.BackColor = Color.WhiteSmoke;
            }
        }

        private void btnPath53_Click(object sender, EventArgs e)
        {
            if (btnPath53.BackColor == Color.WhiteSmoke)
            {    //打开通道
               // comPathClick(CGloabal.g_N6702AModule.nHandle, 0, 3);
                //改变颜色
                btnPath53.BackColor = Color.LightGreen;
            }
            else
            { //  //关闭通道
              //  comPathClick(CGloabal.g_N6702AModule.nHandle, 1, 3);
                //改变颜色
                btnPath53.BackColor = Color.WhiteSmoke;
            }
        }

        private void btnPath54_Click(object sender, EventArgs e)
        {           
            if (btnPath54.BackColor == Color.WhiteSmoke)
            {    //打开通道
                comPathClick(CGloabal.g_N6702AModule.nHandle, 0, 4);
                //改变颜色
                btnPath54.BackColor = Color.LightGreen;
            }
            else
            {   //关闭通道
                comPathClick(CGloabal.g_N6702AModule.nHandle, 1, 4);
                //改变颜色
                btnPath54.BackColor = Color.WhiteSmoke;
            }
        }

        private void comPathClick(int nInstructHandle,int btnSign,int chipId) {
            int error;string strErrMsg = "";
            switch (btnSign) {
                case 0:
                    //打开通道
                    error = N6705ADriver.SetOpenCommand(nInstructHandle, chipId, strErrMsg);
                    if (error < 0)
                    {
                        CommonMethod.ShowHintInfor(eHintInfoType.error, strErrMsg);
                        return;
                    }
                    break;
                case 1:
                    //关闭通道
                    error = N6705ADriver.SetCloseCommand(nInstructHandle, chipId, strErrMsg);
                    if (error < 0)
                    {
                        CommonMethod.ShowHintInfor(eHintInfoType.error, strErrMsg);
                        return;
                    }
                    break;
                default:break;
            }
        }

        private void comboStyle1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboStyle1.Text == "恒压")
            {
                eleVal1.Value = 15;
               // eleVal1.ReadOnly = true;
                volteVal1.Value = 0;
                volteVal1.ReadOnly = false;
            }
            else {
                volteVal1.Value = 100;
               // volteVal1.ReadOnly = true;
                eleVal1.Value = 0;
                eleVal1.ReadOnly = false;
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            volChart61.ChartAreas[0].AxisY.Maximum =(double)numericUpDown1.Value;
        }
    }
}
