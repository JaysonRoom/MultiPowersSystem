using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MultiPowersSystem
{
    public partial class ViewForm : Form
    {
        public ViewForm(Chart volChart,Chart eleChart,string Name)
        {
            InitializeComponent();

            this.Text = Name+"汇总视图";

            vchart1.Series[0] = volChart.Series[0];
            eChart1.Series[0] = eleChart.Series[0];
        }
    }
}
