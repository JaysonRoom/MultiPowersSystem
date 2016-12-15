using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
    }
}
