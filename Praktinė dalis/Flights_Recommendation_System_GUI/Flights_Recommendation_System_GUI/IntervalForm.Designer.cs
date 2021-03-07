
using System;

namespace Flights_Recommendation_System_GUI
{
    partial class IntervalForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IntervalForm));
            this.startOfIntervalDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.endOfIntervalDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.startOfIntervalLabel = new System.Windows.Forms.Label();
            this.endOfIntervalLabel = new System.Windows.Forms.Label();
            this.searchButton = new System.Windows.Forms.Button();
            this.patternLabel = new System.Windows.Forms.Label();
            this.patternNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.searchCountLabel = new System.Windows.Forms.Label();
            this.differenceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.patternNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.differenceNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // startOfIntervalDateTimePicker
            // 
            this.startOfIntervalDateTimePicker.CalendarFont = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startOfIntervalDateTimePicker.CustomFormat = "yyyy-MM-dd";
            this.startOfIntervalDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.startOfIntervalDateTimePicker.Location = new System.Drawing.Point(156, 39);
            this.startOfIntervalDateTimePicker.MinDate = new System.DateTime(2021, 3, 6, 16, 5, 40, 862);
            this.startOfIntervalDateTimePicker.Name = "startOfIntervalDateTimePicker";
            this.startOfIntervalDateTimePicker.Size = new System.Drawing.Size(227, 22);
            this.startOfIntervalDateTimePicker.TabIndex = 0;
            this.startOfIntervalDateTimePicker.Value = new System.DateTime(2021, 3, 6, 16, 5, 40, 862);
            // 
            // endOfIntervalDateTimePicker
            // 
            this.endOfIntervalDateTimePicker.CalendarFont = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endOfIntervalDateTimePicker.CustomFormat = "yyyy-MM-dd";
            this.endOfIntervalDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.endOfIntervalDateTimePicker.Location = new System.Drawing.Point(156, 71);
            this.endOfIntervalDateTimePicker.MinDate = new System.DateTime(2021, 3, 6, 16, 5, 40, 863);
            this.endOfIntervalDateTimePicker.Name = "endOfIntervalDateTimePicker";
            this.endOfIntervalDateTimePicker.Size = new System.Drawing.Size(227, 22);
            this.endOfIntervalDateTimePicker.TabIndex = 1;
            this.endOfIntervalDateTimePicker.Value = new System.DateTime(2021, 3, 6, 16, 5, 40, 863);
            // 
            // startOfIntervalLabel
            // 
            this.startOfIntervalLabel.AutoSize = true;
            this.startOfIntervalLabel.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startOfIntervalLabel.Location = new System.Drawing.Point(22, 44);
            this.startOfIntervalLabel.Name = "startOfIntervalLabel";
            this.startOfIntervalLabel.Size = new System.Drawing.Size(116, 17);
            this.startOfIntervalLabel.TabIndex = 2;
            this.startOfIntervalLabel.Text = "Intervalo pradžia";
            // 
            // endOfIntervalLabel
            // 
            this.endOfIntervalLabel.AutoSize = true;
            this.endOfIntervalLabel.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.endOfIntervalLabel.Location = new System.Drawing.Point(22, 76);
            this.endOfIntervalLabel.Name = "endOfIntervalLabel";
            this.endOfIntervalLabel.Size = new System.Drawing.Size(118, 17);
            this.endOfIntervalLabel.TabIndex = 3;
            this.endOfIntervalLabel.Text = "Intervalo pabaiga";
            // 
            // searchButton
            // 
            this.searchButton.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchButton.Location = new System.Drawing.Point(114, 192);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(177, 29);
            this.searchButton.TabIndex = 4;
            this.searchButton.Text = "Ieškoti";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // patternLabel
            // 
            this.patternLabel.AutoSize = true;
            this.patternLabel.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patternLabel.Location = new System.Drawing.Point(22, 112);
            this.patternLabel.Name = "patternLabel";
            this.patternLabel.Size = new System.Drawing.Size(138, 17);
            this.patternLabel.TabIndex = 6;
            this.patternLabel.Text = "Išvykimo laikotarpis";
            // 
            // patternNumericUpDown
            // 
            this.patternNumericUpDown.Location = new System.Drawing.Point(263, 110);
            this.patternNumericUpDown.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.patternNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.patternNumericUpDown.Name = "patternNumericUpDown";
            this.patternNumericUpDown.Size = new System.Drawing.Size(120, 22);
            this.patternNumericUpDown.TabIndex = 7;
            this.patternNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // searchCountLabel
            // 
            this.searchCountLabel.AutoSize = true;
            this.searchCountLabel.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchCountLabel.Location = new System.Drawing.Point(22, 150);
            this.searchCountLabel.Name = "searchCountLabel";
            this.searchCountLabel.Size = new System.Drawing.Size(95, 17);
            this.searchCountLabel.TabIndex = 8;
            this.searchCountLabel.Text = "Dienų pokytis";
            // 
            // differenceNumericUpDown
            // 
            this.differenceNumericUpDown.Location = new System.Drawing.Point(263, 148);
            this.differenceNumericUpDown.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.differenceNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.differenceNumericUpDown.Name = "differenceNumericUpDown";
            this.differenceNumericUpDown.Size = new System.Drawing.Size(120, 22);
            this.differenceNumericUpDown.TabIndex = 9;
            this.differenceNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // IntervalForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 233);
            this.Controls.Add(this.differenceNumericUpDown);
            this.Controls.Add(this.searchCountLabel);
            this.Controls.Add(this.patternNumericUpDown);
            this.Controls.Add(this.patternLabel);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.endOfIntervalLabel);
            this.Controls.Add(this.startOfIntervalLabel);
            this.Controls.Add(this.endOfIntervalDateTimePicker);
            this.Controls.Add(this.startOfIntervalDateTimePicker);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IntervalForm";
            this.Text = "Paieška intervale";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IntervalForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.patternNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.differenceNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker startOfIntervalDateTimePicker;
        private System.Windows.Forms.DateTimePicker endOfIntervalDateTimePicker;
        private System.Windows.Forms.Label startOfIntervalLabel;
        private System.Windows.Forms.Label endOfIntervalLabel;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label patternLabel;
        private System.Windows.Forms.NumericUpDown patternNumericUpDown;
        private System.Windows.Forms.Label searchCountLabel;
        private System.Windows.Forms.NumericUpDown differenceNumericUpDown;
    }
}