using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

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

                error = CommonMethod.ConnectSpecificInstrument(CGloabal.g_InstrPowerModule.strInstruName, resourceName);
                if (error < 0)//连接失败
                {
                    CommonMethod.ShowHintInfor(eHintInfoType.error, "电源打开失败！");
                    btnOpen1.Text = "打开";
                }
                else//连接成功,则要将当前用户输入的IP地址和端口号保存到ini文件中
                {
                    CommonMethod.SaveInputNetInforsToIniFile(CGloabal.g_InstrPowerModule.strInstruName, strIP, nPort);
                    btnOpen1.Text = "关闭";
                }
            }
            else//此时用户要断开连接
            {
                error = CommonMethod.CloseSpecificInstrument(CGloabal.g_InstrPowerModule.strInstruName);
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

        private void btnOpen2_Click(object sender, EventArgs e)
        {
           
           
        }

     
    }
}
