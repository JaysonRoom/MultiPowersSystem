namespace MultiPowersSystem
{
    partial class ViewForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.eChart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.vchart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.eChart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vchart1)).BeginInit();
            this.SuspendLayout();
            // 
            // eChart1
            // 
            chartArea1.AxisY.LogarithmBase = 5D;
            chartArea1.Name = "ChartArea1";
            this.eChart1.ChartAreas.Add(chartArea1);
            legend1.BorderWidth = 3;
            legend1.DockedToChartArea = "ChartArea1";
            legend1.Name = "Legend1";
            this.eChart1.Legends.Add(legend1);
            this.eChart1.Location = new System.Drawing.Point(21, 309);
            this.eChart1.Name = "eChart1";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Red;
            series1.Legend = "Legend1";
            series1.Name = "电流";
            this.eChart1.Series.Add(series1);
            this.eChart1.Size = new System.Drawing.Size(802, 300);
            this.eChart1.TabIndex = 3;
            this.eChart1.Text = "chart1";
            // 
            // vchart1
            // 
            chartArea2.Name = "ChartArea1";
            this.vchart1.ChartAreas.Add(chartArea2);
            legend2.BorderWidth = 3;
            legend2.DockedToChartArea = "ChartArea1";
            legend2.Name = "Legend1";
            this.vchart1.Legends.Add(legend2);
            this.vchart1.Location = new System.Drawing.Point(21, 3);
            this.vchart1.Name = "vchart1";
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "电压";
            this.vchart1.Series.Add(series2);
            this.vchart1.Size = new System.Drawing.Size(802, 300);
            this.vchart1.TabIndex = 2;
            this.vchart1.Text = "chart1";
            // 
            // ViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(846, 625);
            this.Controls.Add(this.eChart1);
            this.Controls.Add(this.vchart1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewForm";
            this.ShowIcon = false;
            this.Text = "电压电流汇总";
            ((System.ComponentModel.ISupportInitialize)(this.eChart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vchart1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart eChart1;
        private System.Windows.Forms.DataVisualization.Charting.Chart vchart1;
    }
}