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
            listViewMenu.Items.Add("N6705A", "N6705A", 0);

            comboUnit1.SelectedIndex = 1;
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
                case "N6705A":
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
            OutSign1 = false;
            Thread t = new Thread(new ThreadStart(TestProcess));
            t.IsBackground = true;
            t.Start();
        }
        bool OutSign1 = false;//停止标志
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
                if (OutSign1) {//为true时则终止测试
                    return;
                }
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
                    Thread.Sleep(OpenReadtimer);
                    //读取电压和电流        
                    N5769ADriver.ReadVolAndEleCommand(CGloabal.g_N5769AModule.nHandle, ref reVlote, ref reElect);
                    volChart1.Series[0].Points.AddXY(DateTime.Now.ToString("mm:ss"), reVlote);
                    eleChart1.Series[0].Points.AddXY(DateTime.Now.ToString("mm:ss"), reElect);
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
                    Thread.Sleep(CloseReadTimer);
                    //读取电压和电流        
                    N5769ADriver.ReadVolAndEleCommand(CGloabal.g_N5769AModule.nHandle, ref reVlote, ref reElect);
                    volChart1.Series[0].Points.AddXY(DateTime.Now.ToString("mm:ss"), reVlote);
                    eleChart1.Series[0].Points.AddXY(DateTime.Now.ToString("mm:ss"), reElect);
                }
            }
        }

        private void btnStop1_Click(object sender, EventArgs e)
        {
            OutSign1 = true;
        }

        private void btnSave1_Click(object sender, EventArgs e)
        {

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

        }

        private void btnStart2_Click(object sender, EventArgs e)
        {
            OutSign2 = false;
            Thread t = new Thread(new ThreadStart(TestProcess2));
            t.IsBackground = true;
            t.Start();
        }
        bool OutSign2 = false;
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
                if (OutSign2)
                {//为true时则终止测试
                    return;
                }
                cyc--;
                //打开命令
                error = N5769ADriver.SetOpenCommand(CGloabal.g_N5751AModule.nHandle, strErrMsg);
                if (error < 0)
                {
                    CommonMethod.ShowHintInfor(eHintInfoType.error, strErrMsg);
                    return;
                }
                for (int i = 0; i < point; i++)
                {
                    Thread.Sleep(OpenReadtimer);
                    //读取电压和电流        
                    N5769ADriver.ReadVolAndEleCommand(CGloabal.g_N5751AModule.nHandle, ref reVlote, ref reElect);
                    volChart2.Series[0].Points.AddXY(DateTime.Now.ToString("mm:ss"), reVlote);
                    eleChart2.Series[0].Points.AddXY(DateTime.Now.ToString("mm:ss"), reElect);
                }

                //发送关闭指令
                error = N5769ADriver.SetCloseCommand(CGloabal.g_N5751AModule.nHandle, strErrMsg);
                if (error < 0)
                {
                    CommonMethod.ShowHintInfor(eHintInfoType.error, strErrMsg);
                    return;
                }
                for (int i = 0; i < point; i++)
                {
                    Thread.Sleep(CloseReadTimer);
                    //读取电压和电流        
                    N5769ADriver.ReadVolAndEleCommand(CGloabal.g_N5751AModule.nHandle, ref reVlote, ref reElect);
                    volChart2.Series[0].Points.AddXY(DateTime.Now.ToString("mm:ss"), reVlote);
                    eleChart2.Series[0].Points.AddXY(DateTime.Now.ToString("mm:ss"), reElect);
                }
            }
        }

        private void btnStop2_Click(object sender, EventArgs e)
        {
            OutSign2 = true;
        }

        private void btnSave2_Click(object sender, EventArgs e)
        {

        }
    }
}
