﻿
using System;

namespace Flights_Recommendation_System_GUI
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.airlineLabel = new System.Windows.Forms.Label();
            this.departureAirportLabel = new System.Windows.Forms.Label();
            this.arrivalAirportLabel = new System.Windows.Forms.Label();
            this.departureDateLabel = new System.Windows.Forms.Label();
            this.ClassLabel = new System.Windows.Forms.Label();
            this.arrivalDateLabel = new System.Windows.Forms.Label();
            this.directFlightCheckBox = new System.Windows.Forms.CheckBox();
            this.OWRTcheckBox = new System.Windows.Forms.CheckBox();
            this.classComboBox = new System.Windows.Forms.ComboBox();
            this.departureAirportTextBox = new System.Windows.Forms.TextBox();
            this.arrivalAirportTextBox = new System.Windows.Forms.TextBox();
            this.airlineTextBox = new System.Windows.Forms.TextBox();
            this.departureDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.arrivalDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.allFlightsButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.optionsButton = new System.Windows.Forms.Button();
            this.priceDifferenceButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // airlineLabel
            // 
            this.airlineLabel.AutoSize = true;
            this.airlineLabel.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.airlineLabel.Location = new System.Drawing.Point(50, 41);
            this.airlineLabel.Name = "airlineLabel";
            this.airlineLabel.Size = new System.Drawing.Size(68, 17);
            this.airlineLabel.TabIndex = 0;
            this.airlineLabel.Text = "Avialinija";
            // 
            // departureAirportLabel
            // 
            this.departureAirportLabel.AutoSize = true;
            this.departureAirportLabel.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departureAirportLabel.Location = new System.Drawing.Point(296, 41);
            this.departureAirportLabel.Name = "departureAirportLabel";
            this.departureAirportLabel.Size = new System.Drawing.Size(136, 17);
            this.departureAirportLabel.TabIndex = 1;
            this.departureAirportLabel.Text = "Išvykimo oro uostas";
            // 
            // arrivalAirportLabel
            // 
            this.arrivalAirportLabel.AutoSize = true;
            this.arrivalAirportLabel.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arrivalAirportLabel.Location = new System.Drawing.Point(296, 78);
            this.arrivalAirportLabel.Name = "arrivalAirportLabel";
            this.arrivalAirportLabel.Size = new System.Drawing.Size(139, 17);
            this.arrivalAirportLabel.TabIndex = 2;
            this.arrivalAirportLabel.Text = "Atvykimo oro uostas";
            // 
            // departureDateLabel
            // 
            this.departureDateLabel.AutoSize = true;
            this.departureDateLabel.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departureDateLabel.Location = new System.Drawing.Point(601, 41);
            this.departureDateLabel.Name = "departureDateLabel";
            this.departureDateLabel.Size = new System.Drawing.Size(98, 17);
            this.departureDateLabel.TabIndex = 3;
            this.departureDateLabel.Text = "Išvykimo data";
            // 
            // ClassLabel
            // 
            this.ClassLabel.AutoSize = true;
            this.ClassLabel.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClassLabel.Location = new System.Drawing.Point(965, 41);
            this.ClassLabel.Name = "ClassLabel";
            this.ClassLabel.Size = new System.Drawing.Size(42, 17);
            this.ClassLabel.TabIndex = 4;
            this.ClassLabel.Text = "Klasė";
            // 
            // arrivalDateLabel
            // 
            this.arrivalDateLabel.AutoSize = true;
            this.arrivalDateLabel.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arrivalDateLabel.Location = new System.Drawing.Point(602, 78);
            this.arrivalDateLabel.Name = "arrivalDateLabel";
            this.arrivalDateLabel.Size = new System.Drawing.Size(101, 17);
            this.arrivalDateLabel.TabIndex = 6;
            this.arrivalDateLabel.Text = "Atvykimo data";
            // 
            // directFlightCheckBox
            // 
            this.directFlightCheckBox.AutoSize = true;
            this.directFlightCheckBox.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.directFlightCheckBox.Location = new System.Drawing.Point(968, 107);
            this.directFlightCheckBox.Name = "directFlightCheckBox";
            this.directFlightCheckBox.Size = new System.Drawing.Size(147, 21);
            this.directFlightCheckBox.TabIndex = 12;
            this.directFlightCheckBox.Text = "Tiesioginis skrydis";
            this.directFlightCheckBox.UseVisualStyleBackColor = true;
            // 
            // OWRTcheckBox
            // 
            this.OWRTcheckBox.AutoSize = true;
            this.OWRTcheckBox.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OWRTcheckBox.Location = new System.Drawing.Point(968, 78);
            this.OWRTcheckBox.Name = "OWRTcheckBox";
            this.OWRTcheckBox.Size = new System.Drawing.Size(130, 21);
            this.OWRTcheckBox.TabIndex = 13;
            this.OWRTcheckBox.Text = "Dvipusė kelionė";
            this.OWRTcheckBox.UseVisualStyleBackColor = true;
            // 
            // classComboBox
            // 
            this.classComboBox.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classComboBox.FormattingEnabled = true;
            this.classComboBox.Location = new System.Drawing.Point(1026, 38);
            this.classComboBox.Name = "classComboBox";
            this.classComboBox.Size = new System.Drawing.Size(125, 24);
            this.classComboBox.TabIndex = 14;
            // 
            // departureAirportTextBox
            // 
            this.departureAirportTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.departureAirportTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.departureAirportTextBox.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departureAirportTextBox.Location = new System.Drawing.Point(444, 38);
            this.departureAirportTextBox.MaxLength = 3;
            this.departureAirportTextBox.Name = "departureAirportTextBox";
            this.departureAirportTextBox.Size = new System.Drawing.Size(125, 22);
            this.departureAirportTextBox.TabIndex = 16;
            this.departureAirportTextBox.DoubleClick += new System.EventHandler(this.departureAirportTextBox_DoubleClick);
            // 
            // arrivalAirportTextBox
            // 
            this.arrivalAirportTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.arrivalAirportTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.arrivalAirportTextBox.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arrivalAirportTextBox.Location = new System.Drawing.Point(444, 75);
            this.arrivalAirportTextBox.MaxLength = 3;
            this.arrivalAirportTextBox.Name = "arrivalAirportTextBox";
            this.arrivalAirportTextBox.Size = new System.Drawing.Size(125, 22);
            this.arrivalAirportTextBox.TabIndex = 17;
            this.arrivalAirportTextBox.DoubleClick += new System.EventHandler(this.arrivalAirportTextBox_DoubleClick);
            // 
            // airlineTextBox
            // 
            this.airlineTextBox.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.airlineTextBox.Location = new System.Drawing.Point(143, 38);
            this.airlineTextBox.Name = "airlineTextBox";
            this.airlineTextBox.Size = new System.Drawing.Size(125, 22);
            this.airlineTextBox.TabIndex = 18;
            // 
            // departureDateTimePicker
            // 
            this.departureDateTimePicker.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departureDateTimePicker.Location = new System.Drawing.Point(717, 40);
            this.departureDateTimePicker.Name = "departureDateTimePicker";
            this.departureDateTimePicker.Size = new System.Drawing.Size(229, 22);
            this.departureDateTimePicker.TabIndex = 19;
            this.departureDateTimePicker.MinDate = DateTime.Today;
            // 
            // arrivalDateTimePicker
            // 
            this.arrivalDateTimePicker.CalendarFont = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arrivalDateTimePicker.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arrivalDateTimePicker.Location = new System.Drawing.Point(718, 78);
            this.arrivalDateTimePicker.Name = "arrivalDateTimePicker";
            this.arrivalDateTimePicker.Size = new System.Drawing.Size(228, 22);
            this.arrivalDateTimePicker.TabIndex = 20;
            this.arrivalDateTimePicker.MinDate = DateTime.Today;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(54, 146);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1319, 647);
            this.dataGridView1.TabIndex = 21;
            // 
            // allFlightsButton
            // 
            this.allFlightsButton.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.allFlightsButton.Location = new System.Drawing.Point(54, 83);
            this.allFlightsButton.Name = "allFlightsButton";
            this.allFlightsButton.Size = new System.Drawing.Size(214, 30);
            this.allFlightsButton.TabIndex = 22;
            this.allFlightsButton.Text = "Visi avialinijos skrydžiai";
            this.allFlightsButton.UseVisualStyleBackColor = true;
            // 
            // searchButton
            // 
            this.searchButton.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchButton.Location = new System.Drawing.Point(1196, 34);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(177, 30);
            this.searchButton.TabIndex = 23;
            this.searchButton.Text = "Atlikti paiešką";
            this.searchButton.UseVisualStyleBackColor = true;
            // 
            // optionsButton
            // 
            this.optionsButton.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optionsButton.Location = new System.Drawing.Point(1196, 85);
            this.optionsButton.Name = "optionsButton";
            this.optionsButton.Size = new System.Drawing.Size(177, 30);
            this.optionsButton.TabIndex = 24;
            this.optionsButton.Text = "Papildomi nustatymai";
            this.optionsButton.UseVisualStyleBackColor = true;
            // 
            // priceDifferenceButton
            // 
            this.priceDifferenceButton.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.priceDifferenceButton.Location = new System.Drawing.Point(1168, 808);
            this.priceDifferenceButton.Name = "priceDifferenceButton";
            this.priceDifferenceButton.Size = new System.Drawing.Size(198, 30);
            this.priceDifferenceButton.TabIndex = 25;
            this.priceDifferenceButton.Text = "Skrydžio kainų pokyčiai";
            this.priceDifferenceButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1422, 853);
            this.Controls.Add(this.priceDifferenceButton);
            this.Controls.Add(this.optionsButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.allFlightsButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.arrivalDateTimePicker);
            this.Controls.Add(this.departureDateTimePicker);
            this.Controls.Add(this.airlineTextBox);
            this.Controls.Add(this.arrivalAirportTextBox);
            this.Controls.Add(this.departureAirportTextBox);
            this.Controls.Add(this.classComboBox);
            this.Controls.Add(this.OWRTcheckBox);
            this.Controls.Add(this.directFlightCheckBox);
            this.Controls.Add(this.arrivalDateLabel);
            this.Controls.Add(this.ClassLabel);
            this.Controls.Add(this.departureDateLabel);
            this.Controls.Add(this.arrivalAirportLabel);
            this.Controls.Add(this.departureAirportLabel);
            this.Controls.Add(this.airlineLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Skrydžių rekomendavimo sistema";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label airlineLabel;
        private System.Windows.Forms.Label departureAirportLabel;
        private System.Windows.Forms.Label arrivalAirportLabel;
        private System.Windows.Forms.Label departureDateLabel;
        private System.Windows.Forms.Label ClassLabel;
        private System.Windows.Forms.Label arrivalDateLabel;
        private System.Windows.Forms.CheckBox directFlightCheckBox;
        private System.Windows.Forms.CheckBox OWRTcheckBox;
        private System.Windows.Forms.ComboBox classComboBox;
        private System.Windows.Forms.TextBox departureAirportTextBox;
        private System.Windows.Forms.TextBox arrivalAirportTextBox;
        private System.Windows.Forms.TextBox airlineTextBox;
        private System.Windows.Forms.DateTimePicker departureDateTimePicker;
        private System.Windows.Forms.DateTimePicker arrivalDateTimePicker;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button allFlightsButton;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button optionsButton;
        private System.Windows.Forms.Button priceDifferenceButton;
    }
}

