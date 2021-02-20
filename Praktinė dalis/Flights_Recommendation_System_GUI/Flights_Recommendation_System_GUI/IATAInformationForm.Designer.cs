
namespace Flights_Recommendation_System_GUI
{
    partial class IATAInformationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IATAInformationForm));
            this.countryLabel = new System.Windows.Forms.Label();
            this.cityLabel = new System.Windows.Forms.Label();
            this.countryInfoLabel = new System.Windows.Forms.Label();
            this.cityInfoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // countryLabel
            // 
            this.countryLabel.AutoSize = true;
            this.countryLabel.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.countryLabel.Location = new System.Drawing.Point(38, 29);
            this.countryLabel.Name = "countryLabel";
            this.countryLabel.Size = new System.Drawing.Size(37, 17);
            this.countryLabel.TabIndex = 0;
            this.countryLabel.Text = "Šalis";
            // 
            // cityLabel
            // 
            this.cityLabel.AutoSize = true;
            this.cityLabel.Font = new System.Drawing.Font("Georgia", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cityLabel.Location = new System.Drawing.Point(38, 62);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(56, 17);
            this.cityLabel.TabIndex = 1;
            this.cityLabel.Text = "Miestas";
            // 
            // countryInfoLabel
            // 
            this.countryInfoLabel.AutoSize = true;
            this.countryInfoLabel.Location = new System.Drawing.Point(117, 29);
            this.countryInfoLabel.Name = "countryInfoLabel";
            this.countryInfoLabel.Size = new System.Drawing.Size(12, 17);
            this.countryInfoLabel.TabIndex = 2;
            this.countryInfoLabel.Text = " ";
            // 
            // cityInfoLabel
            // 
            this.cityInfoLabel.AutoSize = true;
            this.cityInfoLabel.Location = new System.Drawing.Point(117, 62);
            this.cityInfoLabel.Name = "cityInfoLabel";
            this.cityInfoLabel.Size = new System.Drawing.Size(12, 17);
            this.cityInfoLabel.TabIndex = 3;
            this.cityInfoLabel.Text = " ";
            // 
            // IATAInformationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 153);
            this.ControlBox = false;
            this.Controls.Add(this.cityInfoLabel);
            this.Controls.Add(this.countryInfoLabel);
            this.Controls.Add(this.cityLabel);
            this.Controls.Add(this.countryLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "IATAInformationForm";
            this.Text = "Informacija";
            this.Click += new System.EventHandler(this.IATAInformationForm_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label countryLabel;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.Label countryInfoLabel;
        private System.Windows.Forms.Label cityInfoLabel;
    }
}