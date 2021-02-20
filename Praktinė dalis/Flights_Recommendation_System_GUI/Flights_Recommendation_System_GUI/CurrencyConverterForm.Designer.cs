
namespace Flights_Recommendation_System_GUI
{
    partial class CurrencyConverterForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CurrencyConverterForm));
            this.currentCurrencyLabel = new System.Windows.Forms.Label();
            this.newCurrencyLabel = new System.Windows.Forms.Label();
            this.currentCurrencyTextBox = new System.Windows.Forms.TextBox();
            this.newCurrencyTextBox = new System.Windows.Forms.TextBox();
            this.convertButton = new System.Windows.Forms.Button();
            this.currenciesDataGridView = new System.Windows.Forms.DataGridView();
            this.conversionInfoButton = new System.Windows.Forms.Button();
            this.rateLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.currenciesDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // currentCurrencyLabel
            // 
            this.currentCurrencyLabel.AutoSize = true;
            this.currentCurrencyLabel.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentCurrencyLabel.Location = new System.Drawing.Point(33, 36);
            this.currentCurrencyLabel.Name = "currentCurrencyLabel";
            this.currentCurrencyLabel.Size = new System.Drawing.Size(95, 17);
            this.currentCurrencyLabel.TabIndex = 0;
            this.currentCurrencyLabel.Text = "Esama valiuta";
            // 
            // newCurrencyLabel
            // 
            this.newCurrencyLabel.AutoSize = true;
            this.newCurrencyLabel.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newCurrencyLabel.Location = new System.Drawing.Point(33, 95);
            this.newCurrencyLabel.Name = "newCurrencyLabel";
            this.newCurrencyLabel.Size = new System.Drawing.Size(91, 17);
            this.newCurrencyLabel.TabIndex = 1;
            this.newCurrencyLabel.Text = "Nauja valiuta";
            // 
            // currentCurrencyTextBox
            // 
            this.currentCurrencyTextBox.Enabled = false;
            this.currentCurrencyTextBox.Location = new System.Drawing.Point(36, 56);
            this.currentCurrencyTextBox.Name = "currentCurrencyTextBox";
            this.currentCurrencyTextBox.Size = new System.Drawing.Size(143, 22);
            this.currentCurrencyTextBox.TabIndex = 2;
            // 
            // newCurrencyTextBox
            // 
            this.newCurrencyTextBox.Location = new System.Drawing.Point(36, 115);
            this.newCurrencyTextBox.Name = "newCurrencyTextBox";
            this.newCurrencyTextBox.Size = new System.Drawing.Size(143, 22);
            this.newCurrencyTextBox.TabIndex = 3;
            this.newCurrencyTextBox.TextChanged += new System.EventHandler(this.newCurrencyTextBox_TextChanged);
            // 
            // convertButton
            // 
            this.convertButton.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.convertButton.Location = new System.Drawing.Point(36, 229);
            this.convertButton.Name = "convertButton";
            this.convertButton.Size = new System.Drawing.Size(143, 23);
            this.convertButton.TabIndex = 4;
            this.convertButton.Text = "Konvertuoti";
            this.convertButton.UseVisualStyleBackColor = true;
            this.convertButton.Click += new System.EventHandler(this.convertButton_Click);
            // 
            // currenciesDataGridView
            // 
            this.currenciesDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.currenciesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.currenciesDataGridView.Location = new System.Drawing.Point(218, 36);
            this.currenciesDataGridView.Name = "currenciesDataGridView";
            this.currenciesDataGridView.RowHeadersWidth = 51;
            this.currenciesDataGridView.RowTemplate.Height = 24;
            this.currenciesDataGridView.Size = new System.Drawing.Size(437, 212);
            this.currenciesDataGridView.TabIndex = 5;
            this.currenciesDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.currenciesDataGridView_CellClick);
            // 
            // conversionInfoButton
            // 
            this.conversionInfoButton.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.conversionInfoButton.Location = new System.Drawing.Point(36, 173);
            this.conversionInfoButton.Name = "conversionInfoButton";
            this.conversionInfoButton.Size = new System.Drawing.Size(143, 50);
            this.conversionInfoButton.TabIndex = 6;
            this.conversionInfoButton.Text = "Konvertavimo informacija";
            this.conversionInfoButton.UseVisualStyleBackColor = true;
            this.conversionInfoButton.Click += new System.EventHandler(this.conversionInfoButton_Click);
            // 
            // rateLabel
            // 
            this.rateLabel.AutoSize = true;
            this.rateLabel.Location = new System.Drawing.Point(36, 144);
            this.rateLabel.Name = "rateLabel";
            this.rateLabel.Size = new System.Drawing.Size(46, 17);
            this.rateLabel.TabIndex = 7;
            this.rateLabel.Text = "empty";
            // 
            // CurrencyConverterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 273);
            this.Controls.Add(this.rateLabel);
            this.Controls.Add(this.conversionInfoButton);
            this.Controls.Add(this.currenciesDataGridView);
            this.Controls.Add(this.convertButton);
            this.Controls.Add(this.newCurrencyTextBox);
            this.Controls.Add(this.currentCurrencyTextBox);
            this.Controls.Add(this.newCurrencyLabel);
            this.Controls.Add(this.currentCurrencyLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CurrencyConverterForm";
            this.Text = "Valiutų keitimas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CurrencyConverterForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.currenciesDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label currentCurrencyLabel;
        private System.Windows.Forms.Label newCurrencyLabel;
        private System.Windows.Forms.TextBox currentCurrencyTextBox;
        private System.Windows.Forms.TextBox newCurrencyTextBox;
        private System.Windows.Forms.Button convertButton;
        private System.Windows.Forms.DataGridView currenciesDataGridView;
        private System.Windows.Forms.Button conversionInfoButton;
        private System.Windows.Forms.Label rateLabel;
    }
}