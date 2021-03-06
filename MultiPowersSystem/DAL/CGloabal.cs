﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace MultiPowersSystem.DAL
{
    public class CGloabal
    {
        //定义仪器管理的参数类
        public class InstrMentsParas
        {
            public string strInstruName;  //仪器名字
            public string ipAdress;      //ip地址
            public int port;             //端口号
            public bool bInternet;       //连接状态， 0断开  1连接
            public int nHandle;        //句柄
            public Image imag;         //各自仪器的图片         


            public InstrMentsParas(string name)
            {
                this.strInstruName = name;
                this.ipAdress = "192.168.1.30";
                this.nHandle = 8000;
                this.bInternet = false;
                this.nHandle = 0; //默认为0

            }
        };

        //List<InstrMentsParas> g_InstrModule = new List<InstrMentsParas>() {
        //    new InstrMentsParas("N5769A"),
        //    new InstrMentsParas("N5751A"),
        //    new InstrMentsParas("N5752A"),
        //    new InstrMentsParas("N5772A"),
        //    new InstrMentsParas("N6702A"),
        //    new InstrMentsParas("N6705A")
        //};
        

        //定义六个仪器的对象
        public static InstrMentsParas g_N5769AModule = new InstrMentsParas("N5769A");
        public static InstrMentsParas g_N5751AModule = new InstrMentsParas("N5751A");
        public static InstrMentsParas g_N5752AModule = new InstrMentsParas("N5752A");
        public static InstrMentsParas g_N5772AModule = new InstrMentsParas("N5772A");
        public static InstrMentsParas g_N6702AModule = new InstrMentsParas("N6702A");
        public static InstrMentsParas g_N6705AModule = new InstrMentsParas("N6705A");
    }
}
