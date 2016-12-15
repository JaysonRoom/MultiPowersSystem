using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MultiPowersSystem.DriverCommon
{
    public class N5772ADriver:IDriver
    {
        static int PowerDefaultRM;
        const int BUFF_SIZE = 512;
        public int Init(string resourceName, ref int nHandle, string pErrMsg)
        {
            throw new NotImplementedException();
        }
        public int IDNQuery(int nInstrumentHandle,  ref string pErrMsg)
        {
            throw new NotImplementedException();
        }
        public int Reset(int nInstrumentHandle, string strErrMsg)
        {
            throw new NotImplementedException();
        }

        public int Close(int nInstrumentHandle, string strErrMsg)
        {
            throw new NotImplementedException();
        }
        public int SetVolAndEle(int nInstrumentHandle, double vloVal, double eleVal, string strErrMsg)
        {
            throw new NotImplementedException();
        }

        public int SetOpenCommand(int nInstrumentHandle, string strErrMsg)
        {
            throw new NotImplementedException();
        }

        public int SetCloseCommand(int nInstrumentHandle, string strErrMsg)
        {
            throw new NotImplementedException();
        }
        public int ReadVolteCommand(int nInstrumentHandle, ref double reVlote, string strErrMsg)
        {
            throw new NotImplementedException();
        }
        public int ReadElectCommand(int nInstrumentHandle, ref double reElect, string strErrMsg)
        {
            throw new NotImplementedException();
        }
        public int ReadVolAndEleCommand(int nInstrumentHandle, ref double reVlote, ref double reElect)
        {
            throw new NotImplementedException();
        }
    }
}
