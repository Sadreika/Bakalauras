namespace Flights_Recommendation_System_GUI
{
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Windows.Forms;
    public partial class IATAInformationForm : Form
    {
        private List<string> CityList = new List<string>();
        private List<string> CountryList = new List<string>();
        public IATAInformationForm(DataTable dataFromDatabase, string cellValue)
        {
            InitializeComponent();

            int index = dataFromDatabase.Rows.OfType<DataRow>().Select(x => x.Field<string>("IATA")).ToList().IndexOf(cellValue);
            CityList = dataFromDatabase.Rows.OfType<DataRow>().Select(x => x.Field<string>("City")).ToList();
            CountryList = dataFromDatabase.Rows.OfType<DataRow>().Select(x => x.Field<string>("Country")).ToList();

            if(index != -1)
            {
                cityInfoLabel.Text = CityList[index];
                countryInfoLabel.Text = CountryList[index];
            }
            else
            {
                cityInfoLabel.Text = "Nerasta";
                countryInfoLabel.Text = "Nerasta";
            }
        }

        private void IATAInformationForm_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
