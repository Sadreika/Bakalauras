namespace Flights_Recommendation_System_GUI
{
    using System;
    using System.Windows.Forms;
    public partial class IntervalForm : Form
    {
        private MainForm Mainform { get; set; }
        public IntervalForm(MainForm mainform)
        {
            this.Mainform = mainform;
            mainform.Enabled = false;

            InitializeComponent();
            PrepareCalendar();
        }
        private void PrepareCalendar()
        {
            startOfIntervalDateTimePicker.MinDate = DateTime.Now;
            endOfIntervalDateTimePicker.MinDate = DateTime.Now;
            startOfIntervalDateTimePicker.CustomFormat = "yyyy-MM-dd";
            endOfIntervalDateTimePicker.CustomFormat = "yyyy-MM-dd";
        }
        private void IntervalForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Mainform.Enabled = true;
        }

        private void searchButton_Click(object sender, System.EventArgs e)
        {
            Mainform.intervalSearch(startOfIntervalDateTimePicker, endOfIntervalDateTimePicker, differenceNumericUpDown, patternNumericUpDown);

            Mainform.Enabled = true;
            this.Close();
        }
    }
}
