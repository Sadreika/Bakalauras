namespace Flights_Recommendation_System_GUI
{
    using System.Windows.Forms;
    public partial class IntervalForm : Form
    {
        private MainForm Mainform { get; set; }
        public IntervalForm(MainForm mainform)
        {
            this.Mainform = mainform;
            mainform.Enabled = false;

            InitializeComponent();
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
