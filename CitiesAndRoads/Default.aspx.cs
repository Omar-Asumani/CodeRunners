using CitiesAndRoads.Domain;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace CitiesAndRoads
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadCityDropDownLists();
            DisplayCities();
            DisplayRoads();
        }

        protected void addCityButton_Click(object sender, EventArgs e)
        {
            var city = new DTO.City();
            city.Name = cityNameTextBox.Text;
            try
            {
                CitiesManager.AddCity(city);
            }
            catch(Exception ex)
            {
                cityValidationLabel.Text = ex.Message;
            }

            cityNameTextBox.Text = String.Empty;
            DisplayCities();
        }

        protected void addRoadButton_Click(object sender, EventArgs e)
        {
            var road = new DTO.Road();
            int roadLength = 0;
            bool isRoadLengthValid = Int32.TryParse(roadLengthTextBox.Text, out roadLength) && roadLength > 0;
            int sideCityOneId = Int32.Parse(cityOneDropDownList.SelectedValue);
            int sideCityTwoId = Int32.Parse(cityTwoDropDownList.SelectedValue);
            if(!isRoadLengthValid || sideCityOneId < 1 || sideCityTwoId < 1)
            {
                roadValidationLabel.Text = "Bad input.";
                return;
            }
            road.Length = roadLength;
            road.SideCityOneId = sideCityOneId;
            road.SideCityTwoId = sideCityTwoId;
            try
            {
                RoadsManager.AddRoad(road);
            }
            catch(Exception ex)
            {
                roadValidationLabel.Text = ex.Message;
            }

            roadLengthTextBox.Text = String.Empty;
            cityOneDropDownList.SelectedIndex = 0;
            cityTwoDropDownList.SelectedIndex = 0;
            LoadCityDropDownLists();
            DisplayRoads();
        }

        protected void logisticCenterButton_Click(object sender, EventArgs e)
        {
            cityValidationLabel.Text = String.Empty;
            try
            {
                logisticCenterLabel.Text = CitiesManager.GetLogisticCentername();
            }
            catch(Exception ex)
            {
                cityValidationLabel.Text = ex.Message;
            }
        }

        private void DisplayCities()
        {
            var cities = CitiesManager.GetCities();

            citiesGridView.DataSource = cities.ToList();
            citiesGridView.DataBind();
        }

        private void DisplayRoads()
        {
            var roads = RoadsManager.GetRoads();

            roadsGridView.DataSource = roads.ToList();
            roadsGridView.DataBind();
        }

        private void LoadCityDropDownLists()
        {
            var cities = CitiesManager.GetCities();
            cities.Insert(0, new DTO.City { Id = 0, Name = "Select.." });
            if(cityOneDropDownList.SelectedIndex < 1)
            {
                cityOneDropDownList.DataSource = cities.ToList();
                cityOneDropDownList.DataTextField = "Name";
                cityOneDropDownList.DataValueField = "Id";
                cityOneDropDownList.DataBind();
            }
            if(cityTwoDropDownList.SelectedIndex < 1)
            {
                cityTwoDropDownList.DataSource = cities.ToList();
                cityTwoDropDownList.DataTextField = "Name";
                cityTwoDropDownList.DataValueField = "Id";
                cityTwoDropDownList.DataBind();
            }
        }
    }
}