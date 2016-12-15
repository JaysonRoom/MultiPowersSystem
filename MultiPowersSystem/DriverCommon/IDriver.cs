using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultiPowersSystem.DriverCommon
{
     public interface IDriver
    {      
            /*************************************************
          函数原型：Init (ViChar resourceName[],HANDLE *pnHandle,ViString pErrMsg)  
          函数功能：电源模块初始化
          输入参数：
          输出参数：
          返 回 值：
          */
          int Init(string resourceName, ref int nHandle, string pErrMsg);

        //IDN查询
          int IDNQuery(int nInstrumentHandle, ref string pErrMsg);

        //复位
         int Reset(int nInstrumentHandle, string strErrMsg);

        //关闭模块
         int Close(int nInstrumentHandle, string strErrMsg);

        //
         int SetVolAndEle(int nInstrumentHandle, double vloVal, double eleVal, string strErrMsg);

        int SetOpenCommand(int nInstrumentHandle, string strErrMsg);

        int SetCloseCommand(int nInstrumentHandle, string strErrMsg);

        int ReadVolteCommand(int nInstrumentHandle, ref double reVlote, string strErrMsg);

        int ReadElectCommand(int nInstrumentHandle, ref double reElect, string strErrMsg);

        //读取电压电流值
        int ReadVolAndEleCommand(int nInstrumentHandle, ref double reVlote, ref double reElect);
    }
}
