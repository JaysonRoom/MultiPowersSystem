using MultiPowersSystem.DriverCommon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace MultiPowersSystem.DAL
{
    class CommonMethod
    {
        [DllImport("kernel32")]
        //section：要读取的段落名
        // key: 要读取的键
        //defVal: 读取异常的情况下的缺省值
        //retVal: key所对应的值，如果该key不存在则返回空值
        //size: 值允许的大小
        //filePath: INI文件的完整路径和文件名
        private static extern int GetPrivateProfileString(string section, string key, string defVal, StringBuilder retVal, int size, string filePath);

        [DllImport("kernel32")]
        //section: 要写入的段落名
        //key: 要写入的键，如果该key存在则覆盖写入
        //val: key所对应的值
        //filePath: INI文件的完整路径和文件名
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        //连接设备
        public static int ConnectSpecificInstrument(string strInstruName, string resourceName)
        {
            int error = 0;
            string strError = "";
            if (strInstruName == "N5769A")
            {
                if (CGloabal.g_N5769AModule.nHandle == 0)
                {
                    error = N5769ADriver.Init(resourceName, ref CGloabal.g_N5769AModule.nHandle, strError);
                    if (error < 0)
                    {
                        CGloabal.g_N5769AModule.bInternet = false;
                        CommonMethod.ShowHintInfor(eHintInfoType.error, CGloabal.g_N5769AModule.strInstruName + "连接失败");
                    }
                    else
                    {

                        CGloabal.g_N5769AModule.bInternet = true;
                    }
                }
                else
                {
                    CommonMethod.ShowHintInfor(eHintInfoType.hint, CGloabal.g_N5769AModule.strInstruName + "已经处于连接状态");
                }

            }
            else
            {
                CommonMethod.ShowHintInfor(eHintInfoType.error, "错误的仪器名");
                return -1;
            }

            return error;

        }
        //关闭设备
        public static int CloseSpecificInstrument(string strInstruName)
        {
            string strError = "";
            int error = 0;
            if (strInstruName == "N5769A")
            {
                if (CGloabal.g_N5769AModule.nHandle > 0)
                {
                    error = N5769ADriver.Close(CGloabal.g_N5769AModule.nHandle, strError);
                    if (error < 0)
                    {
                        CommonMethod.ShowHintInfor(eHintInfoType.error, "电源断开失败");
                    }
                    else//断开成功，要将此时的连接状态更新到仪器参数中
                    {
                        CGloabal.g_N5769AModule.bInternet = false;
                    }
                }

            }
            else
            {
                CommonMethod.ShowHintInfor(eHintInfoType.error, "错误的仪器名");
                return -1;
            }
            return error;
        }

        /******************************************************************************************
       * 函数原型：int SaveInputNetInforsToIniFile(string strInstruName,string strIP,UInt32 port )
       * 函数功能：当用户在界面上正确连接设备后，要将该此时的IP地址和端口号保存到ini文件中并更新仪器的参数信息
       *            这个函数只有在仪器连接成功后，才能调用。
       * 输入参数：strInstruName，仪器名字。
       * 输出参数：
       * 返 回 值：
       * 创 建 者：yzx
       * 创建日期：2016.7.27
       * 修改说明：
       * */
        public static int SaveInputNetInforsToIniFile(string strInstruName, string strIP, UInt32 port)
        {
            string strFilePath;
            //获取ini文件的相对路径
            strFilePath = System.Windows.Forms.Application.StartupPath + "\\APP_INFOS.ini";
            if (File.Exists(strFilePath))//先判断INI文件是否存在
            {
                if (strInstruName == "N5769A")
                {
                    //保存到ini文件
                    CommonMethod.WriteValueToIniFile(strFilePath, "N5769A", "IP地址", strIP);
                    CommonMethod.WriteValueToIniFile(strFilePath, "N5769A", "端口号", port.ToString());
                    //更新当前仪器的参数信息
                    CGloabal.g_N5769AModule.ipAdress = strIP;
                    CGloabal.g_N5769AModule.port = (int)port;
                    CGloabal.g_N5769AModule.bInternet = true;
                }
                if (strInstruName == "N5751A")
                {
                    //保存到ini文件
                    CommonMethod.WriteValueToIniFile(strFilePath, "N5751A", "IP地址", strIP);
                    CommonMethod.WriteValueToIniFile(strFilePath, "N5751A", "端口号", port.ToString());
                    //更新当前仪器的参数信息
                    CGloabal.g_N5751AModule.ipAdress = strIP;
                    CGloabal.g_N5751AModule.port = (int)port;
                    CGloabal.g_N5751AModule.bInternet = true;
                }
                else
                {
                    MessageBox.Show("错误的仪器名", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return -1;
                }
            }
            return 0;
        }
        public static long WriteValueToIniFile(string strFilePath, string Section, string key, string strValue)
        {

            long error = 0;

            error = WritePrivateProfileString(Section, key, strValue, strFilePath);
            if (error < 0)
            {
                MessageBox.Show("ini文件写入出错！");
            }
            return error;
        }

        //定义提示信息枚举体
        public enum eHintInfoType
        {
            hint = 0,
            waring = 1,
            error = 2,
        }

        /*************************************************
     * 函数原型：void RangeCheck(ref byte nInputVal,byte nMinVal,byte nMaxVal)
     * 函数功能：对输入的数据进行范围限定。
     * 输入参数：
     * 输出参数：
     * 创 建 者：yzx
     * 创建日期：2016.7.23
     * 修改说明：
    */
        public static void RangeCheck(ref byte nInputVal, byte nMinVal, byte nMaxVal)
        {
            if (nInputVal < nMinVal)
            {
                nInputVal = nMinVal;
            }
            else if (nInputVal > nMaxVal)
            {
                nInputVal = nMaxVal;
            }
            else
            {
                ;
            }
        }

        /******************************************************************
         * 函数原型：void ShowHintInfor(eHintInfoType eInfoType, string strInfor)
         * 函数功能：提示信息
         * 输入参数：InfoType，提示的类型；strInfor，提示的内容
         * 输出参数：
         * 返 回 值：
         * 创 建 者：yzx
         * 创建日期：
         * 修改说明：
         * */
        public static void ShowHintInfor(eHintInfoType eInfoType, string strInfor)
        {
            switch (eInfoType)
            {
                case eHintInfoType.hint://提示类型的信息
                    MessageBox.Show(strInfor, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case eHintInfoType.waring://警告类型的信息
                    MessageBox.Show(strInfor, "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    break;
                case eHintInfoType.error://错误类型的信息
                    MessageBox.Show(strInfor, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                default:
                    break;
            }

        }
    }
}
