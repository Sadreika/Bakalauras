
namespace Flights_Recommendation_System_GUI
{
    partial class CompareChartForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompareChartForm));
            this.outboundCompareCartesianChart = new LiveCharts.WinForms.CartesianChart();
            this.inboundCompareCartesianChart = new LiveCharts.WinForms.CartesianChart();
            this.SuspendLayout();
            // 
            // outBoundCompareCartesianChart
            // 
            this.outboundCompareCartesianChart.Location = new System.Drawing.Point(12, 23);
            this.outboundCompareCartesianChart.Name = "outBoundCompareCartesianChart";
            this.outboundCompareCartesianChart.Size = new System.Drawing.Size(750, 420);
            this.outboundCompareCartesianChart.TabIndex = 0;
            this.outboundCompareCartesianChart.Text = "cartesianChart1";
            // 
            // inboundCompareCartesianChart
            // 
            this.inboundCompareCartesianChart.Location = new System.Drawing.Point(791, 23);
            this.inboundCompareCartesianChart.Name = "inboundCompareCartesianChart";
            this.inboundCompareCartesianChart.Size = new System.Drawing.Size(750, 422);
            this.inboundCompareCartesianChart.TabIndex = 1;
            this.inboundCompareCartesianChart.Text = "cartesianChart1";
            // 
            // CompareChartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1553, 457);
            this.Controls.Add(this.inboundCompareCartesianChart);
            this.Controls.Add(this.outboundCompareCartesianChart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CompareChartForm";
            this.Text = "Kainų palyginimas";
            this.ResumeLayout(false);

        }

        #endregion

        private LiveCharts.WinForms.CartesianChart outboundCompareCartesianChart;
        private LiveCharts.WinForms.CartesianChart inboundCompareCartesianChart;
    }
}