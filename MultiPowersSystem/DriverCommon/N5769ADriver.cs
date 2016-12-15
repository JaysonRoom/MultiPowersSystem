using MultiPowersSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultiPowersSystem.DriverCommon
{
    public class N5769ADriver : IDriver
    {
        static int PowerDefaultRM;
        const int BUFF_SIZE = 512;
        public int Init(string resourceName, ref int nHandle, string pErrMsg)
        {
            int nReturnStatus; //模块化电源底层初始化函数返回状态

            if ((nReturnStatus = visa32.viOpenDefaultRM(out PowerDefaultRM)) < 0)
                return nReturnStatus;

            if ((nReturnStatus = visa32.viOpen(PowerDefaultRM, resourceName, 0, 0, out nHandle)) < 0)
            {
                visa32.viClose(PowerDefaultRM);
                nHandle = 0;
                pErrMsg = "电源模块初始化失败！";
                return nReturnStatus;
            }

            visa32.viSetAttribute(nHandle, visa32.VI_ATTR_TERMCHAR_EN, visa32.VI_TRUE);//终止符使能
            visa32.viSetAttribute(nHandle, visa32.VI_ATTR_SEND_END_EN, visa32.VI_TRUE);//终止符使能	
            visa32.viSetAttribute(nHandle, visa32.VI_ATTR_TERMCHAR, 0xa);//终止符设置0xA
            visa32.viSetBuf(nHandle, visa32.VI_READ_BUF, 500);//RECVMAXLEN+4
            visa32.viSetAttribute(nHandle, visa32.VI_ATTR_TMO_VALUE, 500); //超时2000ms

            return 0;
        }
        public int IDNQuery(int nInstrumentHandle, ref string pErrMsg)
        {
            int error = 0;
            int retCnt;

            string Commands = "*IDN?";
            error = visa32.viWrite(nInstrumentHandle, System.Text.Encoding.Default.GetBytes(Commands), Commands.Length, out retCnt);
            if (error < 0)
            {
                pErrMsg = "设置查询模块ID失败";
                return error;
            }

            //读取
            byte[] byteArray = new byte[100];
            error = visa32.viRead(nInstrumentHandle, byteArray, BUFF_SIZE, out retCnt);

            if (error < 0)
            {
                pErrMsg = "读取电源模块ID失败";
                return error;
            }
            else
            {
                string strIDN = System.Text.Encoding.Default.GetString(byteArray);
                pErrMsg = strIDN;
            }
            return error;
        }
        public int Reset(int nInstrumentHandle, string strErrMsg)
        {
            int status = 0;
            string commands;
            int retCnt;

            commands = "*RST";
            status = visa32.viWrite(nInstrumentHandle, System.Text.Encoding.Default.GetBytes(commands), commands.Length, out retCnt);
            if (status < 0)
            {
                strErrMsg = "VISA函数错误!";
                return status;
            }
            return status;
        }

        public int Close(int nInstrumentHandle, string strErrMsg)
        {
            if (nInstrumentHandle == 0)
            {
                strErrMsg = "电源模块已经关闭或初始化失败!";
                return -1;
            }
            if (nInstrumentHandle > 0)
            {
                visa32.viClose(nInstrumentHandle);  //关闭指定的session,事件或查表(find list)
            }
            if (PowerDefaultRM > 0)
            {
                visa32.viClose(PowerDefaultRM);
            }
            return 0;
        }
        public int SetVolAndEle(int nInstrumentHandle, double vloVal, double eleVal, string strErrMsg)
        {
            int status = 0;
            string commands;
            int retCnt;

            commands = ":VOLT " + vloVal; //输出电压电平设置
            status = visa32.viWrite(nInstrumentHandle, System.Text.Encoding.Default.GetBytes(commands), commands.Length, out retCnt);
            if (status < 0)
            {
                strErrMsg = "VISA函数错误!";
                return status;
            }

            commands = ":CURR " + eleVal; //输出电流电平设置
            status = visa32.viWrite(nInstrumentHandle, System.Text.Encoding.Default.GetBytes(commands), commands.Length, out retCnt);
            if (status < 0)
            {
                strErrMsg = "VISA函数错误!";
                return status;
            }
            return status;
        }

        public  int SetOpenCommand(int nInstrumentHandle, string strErrMsg)
        {
            int status = 0;
            string commands;
            int retCnt;

            commands = ":OUTP ON";
            status = visa32.viWrite(nInstrumentHandle, System.Text.Encoding.Default.GetBytes(commands), commands.Length, out retCnt);
            if (status < 0)
            {
                strErrMsg = "VISA函数错误!";
                return status;
            }
            return status;
        }

        public  int SetCloseCommand(int nInstrumentHandle, string strErrMsg)
        {
            int status = 0;
            string commands;
            int retCnt;

            commands = ":OUTP OFF";
            status = visa32.viWrite(nInstrumentHandle, System.Text.Encoding.Default.GetBytes(commands), commands.Length, out retCnt);
            if (status < 0)
            {
                strErrMsg = "VISA函数错误!";
                return status;
            }
            return status;
        }

        public  int ReadVolteCommand(int nInstrumentHandle, ref double reVlote, string strErrMsg)
        {
            int status = 0;
            string commands;
            int retCnt;
            string strVal;
            byte[] byteArray = new byte[100];

            commands = "MEAS:VOLT?";//返回电压
            status = visa32.viWrite(nInstrumentHandle, System.Text.Encoding.Default.GetBytes(commands), commands.Length, out retCnt);
            if (status < 0)
            {
                strErrMsg = "VISA函数错误!";
                return status;
            }

            status = visa32.viRead(nInstrumentHandle, byteArray, BUFF_SIZE, out retCnt);
            if (status < 0)
            {
                strErrMsg = "VISA函数错误!";
                return status;
            }
            strVal = System.Text.Encoding.Default.GetString(byteArray);
            reVlote = Convert.ToDouble(strVal);
            if (reVlote < 0.0001)
                reVlote = 0;

            //模拟数据
            //reVlote = new Random().Next(0, 20);

            return status;
        }

        public  int ReadElectCommand(int nInstrumentHandle, ref double reElect, string strErrMsg)
        {
            int status = 0;
            string commands;
            int retCnt;
            string strVal;
            byte[] byteArray = new byte[100];

            commands = "MEAS:CURR?";//返回电流
            status = visa32.viWrite(nInstrumentHandle, System.Text.Encoding.Default.GetBytes(commands), commands.Length, out retCnt);
            if (status < 0)
            {
                strErrMsg = "VISA函数错误!";
                return status;
            }

            status = visa32.viRead(nInstrumentHandle, byteArray, BUFF_SIZE, out retCnt);
            if (status < 0)
            {
                strErrMsg = "VISA函数错误!";
                return status;
            }
            strVal = System.Text.Encoding.Default.GetString(byteArray);
            reElect = Convert.ToDouble(strVal);
            if (reElect < 0.0001)
                reElect = 0;

            //模拟数据
            //reElect = new Random().Next(0, 5);
            return status;
        }

        //读取电压电流值

        public  int ReadVolAndEleCommand(int nInstrumentHandle, ref double reVlote, ref double reElect)
        {
            int status = 0;


            string strErrMsg = "";
            byte[] byteArray = new byte[100];

            ReadVolteCommand(nInstrumentHandle, ref reVlote, strErrMsg);
            ReadElectCommand(nInstrumentHandle, ref reElect, strErrMsg);

            //模拟数据

            return status;
        }

    }
}
