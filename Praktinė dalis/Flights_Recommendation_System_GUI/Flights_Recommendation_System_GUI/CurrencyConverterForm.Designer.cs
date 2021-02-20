
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
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.convertButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.conversionInfoButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
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
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(36, 115);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(143, 22);
            this.textBox2.TabIndex = 3;
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
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(218, 36);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(437, 212);
            this.dataGridView1.TabIndex = 5;
            // 
            // conversionInfoButton
            // 
            this.conversionInfoButton.Location = new System.Drawing.Point(36, 173);
            this.conversionInfoButton.Name = "conversionInfoButton";
            this.conversionInfoButton.Size = new System.Drawing.Size(143, 50);
            this.conversionInfoButton.TabIndex = 6;
            this.conversionInfoButton.Text = "Konvertavimo informacija";
            this.conversionInfoButton.UseVisualStyleBackColor = true;
            // 
            // CurrencyConverterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(682, 273);
            this.Controls.Add(this.conversionInfoButton);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.convertButton);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.currentCurrencyTextBox);
            this.Controls.Add(this.newCurrencyLabel);
            this.Controls.Add(this.currentCurrencyLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CurrencyConverterForm";
            this.Text = "Valiutų keitimas";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label currentCurrencyLabel;
        private System.Windows.Forms.Label newCurrencyLabel;
        private System.Windows.Forms.TextBox currentCurrencyTextBox;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button convertButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button conversionInfoButton;
    }
}