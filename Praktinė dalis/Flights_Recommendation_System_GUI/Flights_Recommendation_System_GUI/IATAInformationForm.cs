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

            cityInfoLabel.Text = CityList[index];
            countryInfoLabel.Text = CountryList[index];
        }

        private void IATAInformationForm_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
