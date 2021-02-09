
namespace Flights_Recommendation_System_GUI
{
    partial class LocationSelectionForm
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
            this.selectionButton = new System.Windows.Forms.Button();
            this.cityRadioButton = new System.Windows.Forms.RadioButton();
            this.countryRadioButton = new System.Windows.Forms.RadioButton();
            this.airportRadioButton = new System.Windows.Forms.RadioButton();
            this.locationTextBox = new System.Windows.Forms.TextBox();
            this.locationsDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.locationsDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // selectionButton
            // 
            this.selectionButton.Location = new System.Drawing.Point(32, 388);
            this.selectionButton.Name = "selectionButton";
            this.selectionButton.Size = new System.Drawing.Size(166, 30);
            this.selectionButton.TabIndex = 0;
            this.selectionButton.Text = "Pasirinkti pažymėtą";
            this.selectionButton.UseVisualStyleBackColor = true;
            this.selectionButton.Click += new System.EventHandler(this.selectionButton_Click);
            // 
            // cityRadioButton
            // 
            this.cityRadioButton.AutoSize = true;
            this.cityRadioButton.Location = new System.Drawing.Point(32, 58);
            this.cityRadioButton.Name = "cityRadioButton";
            this.cityRadioButton.Size = new System.Drawing.Size(77, 21);
            this.cityRadioButton.TabIndex = 1;
            this.cityRadioButton.TabStop = true;
            this.cityRadioButton.Text = "Miestas";
            this.cityRadioButton.UseVisualStyleBackColor = true;
            // 
            // countryRadioButton
            // 
            this.countryRadioButton.AutoSize = true;
            this.countryRadioButton.Checked = true;
            this.countryRadioButton.Location = new System.Drawing.Point(32, 31);
            this.countryRadioButton.Name = "countryRadioButton";
            this.countryRadioButton.Size = new System.Drawing.Size(59, 21);
            this.countryRadioButton.TabIndex = 2;
            this.countryRadioButton.TabStop = true;
            this.countryRadioButton.Text = "Šalis";
            this.countryRadioButton.UseVisualStyleBackColor = true;
            // 
            // airportRadioButton
            // 
            this.airportRadioButton.AutoSize = true;
            this.airportRadioButton.Location = new System.Drawing.Point(32, 85);
            this.airportRadioButton.Name = "airportRadioButton";
            this.airportRadioButton.Size = new System.Drawing.Size(175, 21);
            this.airportRadioButton.TabIndex = 3;
            this.airportRadioButton.TabStop = true;
            this.airportRadioButton.Text = "Oro uosto pavadinimas";
            this.airportRadioButton.UseVisualStyleBackColor = true;
            // 
            // locationTextBox
            // 
            this.locationTextBox.Location = new System.Drawing.Point(32, 137);
            this.locationTextBox.Name = "locationTextBox";
            this.locationTextBox.Size = new System.Drawing.Size(166, 22);
            this.locationTextBox.TabIndex = 4;
            this.locationTextBox.TextChanged += new System.EventHandler(this.locationTextBox_TextChanged);
            // 
            // locationsDataGridView
            // 
            this.locationsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.locationsDataGridView.Location = new System.Drawing.Point(216, 31);
            this.locationsDataGridView.Name = "locationsDataGridView";
            this.locationsDataGridView.RowHeadersWidth = 51;
            this.locationsDataGridView.RowTemplate.Height = 24;
            this.locationsDataGridView.Size = new System.Drawing.Size(549, 387);
            this.locationsDataGridView.TabIndex = 5;
            // 
            // LocationSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 453);
            this.Controls.Add(this.locationsDataGridView);
            this.Controls.Add(this.locationTextBox);
            this.Controls.Add(this.airportRadioButton);
            this.Controls.Add(this.countryRadioButton);
            this.Controls.Add(this.cityRadioButton);
            this.Controls.Add(this.selectionButton);
            this.Name = "LocationSelectionForm";
            this.Text = "Lokacijos pasirinkimas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LocationSelectionForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.locationsDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button selectionButton;
        private System.Windows.Forms.RadioButton cityRadioButton;
        private System.Windows.Forms.RadioButton countryRadioButton;
        private System.Windows.Forms.RadioButton airportRadioButton;
        private System.Windows.Forms.TextBox locationTextBox;
        private System.Windows.Forms.DataGridView locationsDataGridView;
    }
}