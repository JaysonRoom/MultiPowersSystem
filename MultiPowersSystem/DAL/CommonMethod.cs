using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultiPowersSystem.DAL
{
    class CommonMethod
    {
        //连接设备
        public static int ConnectSpecificInstrument(string strInstruName, string resourceName)
        {
            int error = 0;
            string strError = "";
            if (strInstruName == "N5769A")
            {
                if (CGloabal.g_InstrPowerModule.nHandle == 0)
                {
                    error = N5769ADriver.Init(resourceName, ref CGloabal.g_InstrPowerModule.nHandle, strError);
                    if (error < 0)
                    {
                        CGloabal.g_InstrPowerModule.bInternet = false;
                        CommonMethod.ShowHintInfor(eHintInfoType.error, CGloabal.g_InstrPowerModule.strInstruName + "连接失败");
                    }
                    else
                    {

                        CGloabal.g_InstrPowerModule.bInternet = true;
                    }
                }
                else
                {
                    CommonMethod.ShowHintInfor(eHintInfoType.hint, CGloabal.g_InstrPowerModule.strInstruName + "已经处于连接状态");
                }

            }
            else
            {
                CommonMethod.ShowHintInfor(eHintInfoType.error, "错误的仪器名");
                return -1;
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
