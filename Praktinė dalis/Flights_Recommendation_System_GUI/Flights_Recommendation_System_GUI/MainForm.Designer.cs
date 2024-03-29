﻿
using System;
using System.Windows.Forms;

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
            this.OWRTcheckBox = new System.Windows.Forms.CheckBox();
            this.classComboBox = new System.Windows.Forms.ComboBox();
            this.departureAirportTextBox = new System.Windows.Forms.TextBox();
            this.arrivalAirportTextBox = new System.Windows.Forms.TextBox();
            this.airlineTextBox = new System.Windows.Forms.TextBox();
            this.departureDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.arrivalDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.airlineFlightsDataGridView = new System.Windows.Forms.DataGridView();
            this.collectedDataButton = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.filterCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.compareButton = new System.Windows.Forms.Button();
            this.intervalSearchButton = new System.Windows.Forms.Button();
            this.zeroConnectionLabel = new System.Windows.Forms.Label();
            this.lowestPriceLabel = new System.Windows.Forms.Label();
            this.travelDurationLabel = new System.Windows.Forms.Label();
            this.stropsLabel = new System.Windows.Forms.Label();
            this.oneStopCheckBox = new System.Windows.Forms.CheckBox();
            this.zeroStopsCheckBox = new System.Windows.Forms.CheckBox();
            this.oneConnectionLabel = new System.Windows.Forms.Label();
            this.directFlightCheckBox = new System.Windows.Forms.CheckBox();
            this.lowestPriceTextBox = new System.Windows.Forms.TextBox();
            this.biggestPriceTextBox = new System.Windows.Forms.TextBox();
            this.filterButton = new System.Windows.Forms.Button();
            this.hoursNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.minutesNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.hoursLabel = new System.Windows.Forms.Label();
            this.minutesLabel = new System.Windows.Forms.Label();
            this.chartButton = new System.Windows.Forms.Button();
            this.excelButton = new System.Windows.Forms.Button();
            this.mainProgressBar = new System.Windows.Forms.ProgressBar();
            this.symbolLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.airlineFlightsDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hoursNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minutesNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // airlineLabel
            // 
            this.airlineLabel.AutoSize = true;
            this.airlineLabel.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.airlineLabel.Location = new System.Drawing.Point(14, 22);
            this.airlineLabel.Name = "airlineLabel";
            this.airlineLabel.Size = new System.Drawing.Size(68, 17);
            this.airlineLabel.TabIndex = 0;
            this.airlineLabel.Text = "Avialinija";
            // 
            // departureAirportLabel
            // 
            this.departureAirportLabel.AutoSize = true;
            this.departureAirportLabel.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departureAirportLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.departureAirportLabel.Location = new System.Drawing.Point(14, 53);
            this.departureAirportLabel.Name = "departureAirportLabel";
            this.departureAirportLabel.Size = new System.Drawing.Size(136, 17);
            this.departureAirportLabel.TabIndex = 1;
            this.departureAirportLabel.Text = "Išvykimo oro uostas";
            // 
            // arrivalAirportLabel
            // 
            this.arrivalAirportLabel.AutoSize = true;
            this.arrivalAirportLabel.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arrivalAirportLabel.Location = new System.Drawing.Point(14, 87);
            this.arrivalAirportLabel.Name = "arrivalAirportLabel";
            this.arrivalAirportLabel.Size = new System.Drawing.Size(139, 17);
            this.arrivalAirportLabel.TabIndex = 2;
            this.arrivalAirportLabel.Text = "Atvykimo oro uostas";
            // 
            // departureDateLabel
            // 
            this.departureDateLabel.AutoSize = true;
            this.departureDateLabel.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departureDateLabel.Location = new System.Drawing.Point(272, 19);
            this.departureDateLabel.Name = "departureDateLabel";
            this.departureDateLabel.Size = new System.Drawing.Size(98, 17);
            this.departureDateLabel.TabIndex = 3;
            this.departureDateLabel.Text = "Išvykimo data";
            // 
            // ClassLabel
            // 
            this.ClassLabel.AutoSize = true;
            this.ClassLabel.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ClassLabel.Location = new System.Drawing.Point(324, 89);
            this.ClassLabel.Name = "ClassLabel";
            this.ClassLabel.Size = new System.Drawing.Size(42, 17);
            this.ClassLabel.TabIndex = 4;
            this.ClassLabel.Text = "Klasė";
            // 
            // arrivalDateLabel
            // 
            this.arrivalDateLabel.AutoSize = true;
            this.arrivalDateLabel.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arrivalDateLabel.Location = new System.Drawing.Point(269, 51);
            this.arrivalDateLabel.Name = "arrivalDateLabel";
            this.arrivalDateLabel.Size = new System.Drawing.Size(101, 17);
            this.arrivalDateLabel.TabIndex = 6;
            this.arrivalDateLabel.Text = "Atvykimo data";
            // 
            // OWRTcheckBox
            // 
            this.OWRTcheckBox.AutoSize = true;
            this.OWRTcheckBox.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OWRTcheckBox.Location = new System.Drawing.Point(569, 18);
            this.OWRTcheckBox.Name = "OWRTcheckBox";
            this.OWRTcheckBox.Size = new System.Drawing.Size(130, 21);
            this.OWRTcheckBox.TabIndex = 13;
            this.OWRTcheckBox.Text = "Dvipusė kelionė";
            this.OWRTcheckBox.UseVisualStyleBackColor = true;
            this.OWRTcheckBox.Click += new System.EventHandler(this.OWRTcheckBox_Click);
            // 
            // classComboBox
            // 
            this.classComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.classComboBox.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.classComboBox.FormattingEnabled = true;
            this.classComboBox.Location = new System.Drawing.Point(385, 86);
            this.classComboBox.Name = "classComboBox";
            this.classComboBox.Size = new System.Drawing.Size(127, 24);
            this.classComboBox.TabIndex = 14;
            // 
            // departureAirportTextBox
            // 
            this.departureAirportTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.departureAirportTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.departureAirportTextBox.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departureAirportTextBox.Location = new System.Drawing.Point(162, 50);
            this.departureAirportTextBox.MaxLength = 3;
            this.departureAirportTextBox.Name = "departureAirportTextBox";
            this.departureAirportTextBox.Size = new System.Drawing.Size(60, 22);
            this.departureAirportTextBox.TabIndex = 16;
            this.departureAirportTextBox.DoubleClick += new System.EventHandler(this.departureAirportTextBox_DoubleClick);
            // 
            // arrivalAirportTextBox
            // 
            this.arrivalAirportTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.arrivalAirportTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.arrivalAirportTextBox.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arrivalAirportTextBox.Location = new System.Drawing.Point(162, 84);
            this.arrivalAirportTextBox.MaxLength = 3;
            this.arrivalAirportTextBox.Name = "arrivalAirportTextBox";
            this.arrivalAirportTextBox.Size = new System.Drawing.Size(60, 22);
            this.arrivalAirportTextBox.TabIndex = 17;
            this.arrivalAirportTextBox.DoubleClick += new System.EventHandler(this.arrivalAirportTextBox_DoubleClick);
            // 
            // airlineTextBox
            // 
            this.airlineTextBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.airlineTextBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.airlineTextBox.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.airlineTextBox.Location = new System.Drawing.Point(112, 19);
            this.airlineTextBox.Name = "airlineTextBox";
            this.airlineTextBox.Size = new System.Drawing.Size(110, 22);
            this.airlineTextBox.TabIndex = 18;
            // 
            // departureDateTimePicker
            // 
            this.departureDateTimePicker.CustomFormat = "yyyy-MM-dd";
            this.departureDateTimePicker.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departureDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.departureDateTimePicker.Location = new System.Drawing.Point(384, 17);
            this.departureDateTimePicker.MinDate = new System.DateTime(2021, 2, 10, 0, 0, 0, 0);
            this.departureDateTimePicker.Name = "departureDateTimePicker";
            this.departureDateTimePicker.Size = new System.Drawing.Size(128, 22);
            this.departureDateTimePicker.TabIndex = 19;
            // 
            // arrivalDateTimePicker
            // 
            this.arrivalDateTimePicker.CalendarFont = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arrivalDateTimePicker.CustomFormat = "yyyy-MM-dd";
            this.arrivalDateTimePicker.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arrivalDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.arrivalDateTimePicker.Location = new System.Drawing.Point(385, 51);
            this.arrivalDateTimePicker.MinDate = new System.DateTime(2021, 2, 10, 0, 0, 0, 0);
            this.arrivalDateTimePicker.Name = "arrivalDateTimePicker";
            this.arrivalDateTimePicker.Size = new System.Drawing.Size(127, 22);
            this.arrivalDateTimePicker.TabIndex = 20;
            // 
            // airlineFlightsDataGridView
            // 
            this.airlineFlightsDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.airlineFlightsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.airlineFlightsDataGridView.Location = new System.Drawing.Point(12, 123);
            this.airlineFlightsDataGridView.Name = "airlineFlightsDataGridView";
            this.airlineFlightsDataGridView.ReadOnly = true;
            this.airlineFlightsDataGridView.RowHeadersWidth = 51;
            this.airlineFlightsDataGridView.RowTemplate.Height = 24;
            this.airlineFlightsDataGridView.Size = new System.Drawing.Size(1878, 858);
            this.airlineFlightsDataGridView.TabIndex = 21;
            this.airlineFlightsDataGridView.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.airlineFlightsDataGridView_CellContentDoubleClick);
            // 
            // collectedDataButton
            // 
            this.collectedDataButton.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.collectedDataButton.Location = new System.Drawing.Point(924, 14);
            this.collectedDataButton.Name = "collectedDataButton";
            this.collectedDataButton.Size = new System.Drawing.Size(192, 25);
            this.collectedDataButton.TabIndex = 22;
            this.collectedDataButton.Text = "Pasirinktų dienų pasiūlymai";
            this.collectedDataButton.UseVisualStyleBackColor = true;
            this.collectedDataButton.Click += new System.EventHandler(this.collectedDataButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchButton.Location = new System.Drawing.Point(766, 12);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(130, 25);
            this.searchButton.TabIndex = 23;
            this.searchButton.Text = "Atlikti paiešką";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // filterCheckedListBox
            // 
            this.filterCheckedListBox.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterCheckedListBox.FormattingEnabled = true;
            this.filterCheckedListBox.Location = new System.Drawing.Point(1656, 11);
            this.filterCheckedListBox.Name = "filterCheckedListBox";
            this.filterCheckedListBox.Size = new System.Drawing.Size(234, 84);
            this.filterCheckedListBox.TabIndex = 24;
            this.filterCheckedListBox.SelectedIndexChanged += new System.EventHandler(this.filterCheckedListBox_SelectedIndexChanged);
            // 
            // compareButton
            // 
            this.compareButton.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.compareButton.Location = new System.Drawing.Point(924, 44);
            this.compareButton.Name = "compareButton";
            this.compareButton.Size = new System.Drawing.Size(192, 25);
            this.compareButton.TabIndex = 25;
            this.compareButton.Text = "Visų dienų pasiūlymai";
            this.compareButton.UseVisualStyleBackColor = true;
            this.compareButton.Click += new System.EventHandler(this.compareButton_Click);
            // 
            // intervalSearchButton
            // 
            this.intervalSearchButton.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.intervalSearchButton.Location = new System.Drawing.Point(766, 44);
            this.intervalSearchButton.Name = "intervalSearchButton";
            this.intervalSearchButton.Size = new System.Drawing.Size(130, 25);
            this.intervalSearchButton.TabIndex = 26;
            this.intervalSearchButton.Text = "Paieška intervale";
            this.intervalSearchButton.UseVisualStyleBackColor = true;
            this.intervalSearchButton.Click += new System.EventHandler(this.intervalSearchButton_Click);
            // 
            // zeroConnectionLabel
            // 
            this.zeroConnectionLabel.AutoSize = true;
            this.zeroConnectionLabel.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zeroConnectionLabel.Location = new System.Drawing.Point(1485, 89);
            this.zeroConnectionLabel.Name = "zeroConnectionLabel";
            this.zeroConnectionLabel.Size = new System.Drawing.Size(30, 17);
            this.zeroConnectionLabel.TabIndex = 27;
            this.zeroConnectionLabel.Text = " (0)";
            // 
            // lowestPriceLabel
            // 
            this.lowestPriceLabel.AutoSize = true;
            this.lowestPriceLabel.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lowestPriceLabel.Location = new System.Drawing.Point(1351, 14);
            this.lowestPriceLabel.Name = "lowestPriceLabel";
            this.lowestPriceLabel.Size = new System.Drawing.Size(116, 17);
            this.lowestPriceLabel.TabIndex = 28;
            this.lowestPriceLabel.Text = "Kainos intervalas";
            // 
            // travelDurationLabel
            // 
            this.travelDurationLabel.AutoSize = true;
            this.travelDurationLabel.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.travelDurationLabel.Location = new System.Drawing.Point(1351, 53);
            this.travelDurationLabel.Name = "travelDurationLabel";
            this.travelDurationLabel.Size = new System.Drawing.Size(59, 17);
            this.travelDurationLabel.TabIndex = 32;
            this.travelDurationLabel.Text = "Trukmė";
            // 
            // stropsLabel
            // 
            this.stropsLabel.AutoSize = true;
            this.stropsLabel.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stropsLabel.Location = new System.Drawing.Point(1351, 89);
            this.stropsLabel.Name = "stropsLabel";
            this.stropsLabel.Size = new System.Drawing.Size(74, 17);
            this.stropsLabel.TabIndex = 34;
            this.stropsLabel.Text = "Sustojimai";
            // 
            // oneStopCheckBox
            // 
            this.oneStopCheckBox.AutoSize = true;
            this.oneStopCheckBox.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oneStopCheckBox.Location = new System.Drawing.Point(1539, 88);
            this.oneStopCheckBox.Name = "oneStopCheckBox";
            this.oneStopCheckBox.Size = new System.Drawing.Size(37, 21);
            this.oneStopCheckBox.TabIndex = 36;
            this.oneStopCheckBox.Text = "1";
            this.oneStopCheckBox.UseVisualStyleBackColor = true;
            // 
            // zeroStopsCheckBox
            // 
            this.zeroStopsCheckBox.AutoSize = true;
            this.zeroStopsCheckBox.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.zeroStopsCheckBox.Location = new System.Drawing.Point(1451, 88);
            this.zeroStopsCheckBox.Name = "zeroStopsCheckBox";
            this.zeroStopsCheckBox.Size = new System.Drawing.Size(39, 21);
            this.zeroStopsCheckBox.TabIndex = 37;
            this.zeroStopsCheckBox.Text = "0";
            this.zeroStopsCheckBox.UseVisualStyleBackColor = true;
            // 
            // oneConnectionLabel
            // 
            this.oneConnectionLabel.AutoSize = true;
            this.oneConnectionLabel.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.oneConnectionLabel.Location = new System.Drawing.Point(1571, 90);
            this.oneConnectionLabel.Name = "oneConnectionLabel";
            this.oneConnectionLabel.Size = new System.Drawing.Size(30, 17);
            this.oneConnectionLabel.TabIndex = 39;
            this.oneConnectionLabel.Text = " (0)";
            // 
            // directFlightCheckBox
            // 
            this.directFlightCheckBox.AutoSize = true;
            this.directFlightCheckBox.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.directFlightCheckBox.Location = new System.Drawing.Point(569, 51);
            this.directFlightCheckBox.Name = "directFlightCheckBox";
            this.directFlightCheckBox.Size = new System.Drawing.Size(147, 21);
            this.directFlightCheckBox.TabIndex = 40;
            this.directFlightCheckBox.Text = "Tiesioginis skrydis";
            this.directFlightCheckBox.UseVisualStyleBackColor = true;
            // 
            // lowestPriceTextBox
            // 
            this.lowestPriceTextBox.Location = new System.Drawing.Point(1484, 12);
            this.lowestPriceTextBox.MaxLength = 5;
            this.lowestPriceTextBox.Name = "lowestPriceTextBox";
            this.lowestPriceTextBox.Size = new System.Drawing.Size(50, 22);
            this.lowestPriceTextBox.TabIndex = 41;
            // 
            // biggestPriceTextBox
            // 
            this.biggestPriceTextBox.Location = new System.Drawing.Point(1559, 11);
            this.biggestPriceTextBox.MaxLength = 5;
            this.biggestPriceTextBox.Name = "biggestPriceTextBox";
            this.biggestPriceTextBox.Size = new System.Drawing.Size(50, 22);
            this.biggestPriceTextBox.TabIndex = 42;
            // 
            // filterButton
            // 
            this.filterButton.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterButton.Location = new System.Drawing.Point(1148, 45);
            this.filterButton.Name = "filterButton";
            this.filterButton.Size = new System.Drawing.Size(94, 25);
            this.filterButton.TabIndex = 43;
            this.filterButton.Text = "Filtruoti";
            this.filterButton.UseVisualStyleBackColor = true;
            this.filterButton.Click += new System.EventHandler(this.filterButton_Click);
            // 
            // hoursNumericUpDown
            // 
            this.hoursNumericUpDown.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoursNumericUpDown.Location = new System.Drawing.Point(1451, 50);
            this.hoursNumericUpDown.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.hoursNumericUpDown.Name = "hoursNumericUpDown";
            this.hoursNumericUpDown.Size = new System.Drawing.Size(39, 22);
            this.hoursNumericUpDown.TabIndex = 45;
            // 
            // minutesNumericUpDown
            // 
            this.minutesNumericUpDown.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minutesNumericUpDown.Location = new System.Drawing.Point(1537, 51);
            this.minutesNumericUpDown.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.minutesNumericUpDown.Name = "minutesNumericUpDown";
            this.minutesNumericUpDown.Size = new System.Drawing.Size(39, 22);
            this.minutesNumericUpDown.TabIndex = 46;
            // 
            // hoursLabel
            // 
            this.hoursLabel.AutoSize = true;
            this.hoursLabel.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hoursLabel.Location = new System.Drawing.Point(1496, 53);
            this.hoursLabel.Name = "hoursLabel";
            this.hoursLabel.Size = new System.Drawing.Size(20, 17);
            this.hoursLabel.TabIndex = 48;
            this.hoursLabel.Text = "h.";
            // 
            // minutesLabel
            // 
            this.minutesLabel.AutoSize = true;
            this.minutesLabel.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minutesLabel.Location = new System.Drawing.Point(1574, 52);
            this.minutesLabel.Name = "minutesLabel";
            this.minutesLabel.Size = new System.Drawing.Size(36, 17);
            this.minutesLabel.TabIndex = 49;
            this.minutesLabel.Text = "min.";
            // 
            // chartButton
            // 
            this.chartButton.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chartButton.Location = new System.Drawing.Point(1148, 12);
            this.chartButton.Name = "chartButton";
            this.chartButton.Size = new System.Drawing.Size(130, 25);
            this.chartButton.TabIndex = 50;
            this.chartButton.Text = "Rodyti grafiką";
            this.chartButton.UseVisualStyleBackColor = true;
            this.chartButton.Click += new System.EventHandler(this.chartButton_Click);
            // 
            // excelButton
            // 
            this.excelButton.Image = ((System.Drawing.Image)(resources.GetObject("excelButton.Image")));
            this.excelButton.Location = new System.Drawing.Point(1248, 44);
            this.excelButton.Name = "excelButton";
            this.excelButton.Size = new System.Drawing.Size(25, 25);
            this.excelButton.TabIndex = 52;
            this.excelButton.Text = " ";
            this.excelButton.UseVisualStyleBackColor = true;
            this.excelButton.Click += new System.EventHandler(this.excelButton_Click);
            // 
            // mainProgressBar
            // 
            this.mainProgressBar.Location = new System.Drawing.Point(766, 89);
            this.mainProgressBar.Name = "mainProgressBar";
            this.mainProgressBar.Size = new System.Drawing.Size(512, 23);
            this.mainProgressBar.TabIndex = 53;
            this.mainProgressBar.Visible = false;
            // 
            // symbolLabel
            // 
            this.symbolLabel.AutoSize = true;
            this.symbolLabel.Location = new System.Drawing.Point(1540, 15);
            this.symbolLabel.Name = "symbolLabel";
            this.symbolLabel.Size = new System.Drawing.Size(13, 17);
            this.symbolLabel.TabIndex = 54;
            this.symbolLabel.Text = "-";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1902, 993);
            this.Controls.Add(this.symbolLabel);
            this.Controls.Add(this.mainProgressBar);
            this.Controls.Add(this.excelButton);
            this.Controls.Add(this.chartButton);
            this.Controls.Add(this.minutesLabel);
            this.Controls.Add(this.hoursLabel);
            this.Controls.Add(this.minutesNumericUpDown);
            this.Controls.Add(this.hoursNumericUpDown);
            this.Controls.Add(this.filterButton);
            this.Controls.Add(this.biggestPriceTextBox);
            this.Controls.Add(this.lowestPriceTextBox);
            this.Controls.Add(this.directFlightCheckBox);
            this.Controls.Add(this.oneConnectionLabel);
            this.Controls.Add(this.zeroStopsCheckBox);
            this.Controls.Add(this.oneStopCheckBox);
            this.Controls.Add(this.stropsLabel);
            this.Controls.Add(this.travelDurationLabel);
            this.Controls.Add(this.lowestPriceLabel);
            this.Controls.Add(this.zeroConnectionLabel);
            this.Controls.Add(this.intervalSearchButton);
            this.Controls.Add(this.compareButton);
            this.Controls.Add(this.filterCheckedListBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.collectedDataButton);
            this.Controls.Add(this.airlineFlightsDataGridView);
            this.Controls.Add(this.arrivalDateTimePicker);
            this.Controls.Add(this.departureDateTimePicker);
            this.Controls.Add(this.airlineTextBox);
            this.Controls.Add(this.arrivalAirportTextBox);
            this.Controls.Add(this.departureAirportTextBox);
            this.Controls.Add(this.classComboBox);
            this.Controls.Add(this.OWRTcheckBox);
            this.Controls.Add(this.arrivalDateLabel);
            this.Controls.Add(this.ClassLabel);
            this.Controls.Add(this.departureDateLabel);
            this.Controls.Add(this.arrivalAirportLabel);
            this.Controls.Add(this.departureAirportLabel);
            this.Controls.Add(this.airlineLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Skrydžių rekomendavimo sistema";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.airlineFlightsDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hoursNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minutesNumericUpDown)).EndInit();
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
        private System.Windows.Forms.CheckBox OWRTcheckBox;
        private System.Windows.Forms.ComboBox classComboBox;
        private System.Windows.Forms.TextBox departureAirportTextBox;
        private System.Windows.Forms.TextBox arrivalAirportTextBox;
        private System.Windows.Forms.TextBox airlineTextBox;
        private System.Windows.Forms.DateTimePicker departureDateTimePicker;
        private System.Windows.Forms.DateTimePicker arrivalDateTimePicker;
        private System.Windows.Forms.DataGridView airlineFlightsDataGridView;
        private System.Windows.Forms.Button collectedDataButton;
        private System.Windows.Forms.Button searchButton;
        private CheckedListBox filterCheckedListBox;
        private Button compareButton;
        private Button intervalSearchButton;
        private Label zeroConnectionLabel;
        private Label lowestPriceLabel;
        private Label travelDurationLabel;
        private Label stropsLabel;
        private CheckBox oneStopCheckBox;
        private CheckBox zeroStopsCheckBox;
        private Label oneConnectionLabel;
        private CheckBox directFlightCheckBox;
        private TextBox lowestPriceTextBox;
        private TextBox biggestPriceTextBox;
        private Button filterButton;
        private NumericUpDown hoursNumericUpDown;
        private NumericUpDown minutesNumericUpDown;
        private Label hoursLabel;
        private Label minutesLabel;
        private Button chartButton;
        private Button excelButton;
        private ProgressBar mainProgressBar;
        private Label symbolLabel;
    }
}

