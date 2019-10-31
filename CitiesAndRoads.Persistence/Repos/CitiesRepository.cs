using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitiesAndRoads.DTO;

namespace CitiesAndRoads.Persistence
{
    public class CitiesRepository
    {
        public static List<DTO.City> GetCities()
        {
            CitiesAndRoadsDbContext db = new CitiesAndRoadsDbContext();
            List<City> dbCities = db.Cities.OrderBy(c => c.Name).ToList();
            List<DTO.City> dtoCities = new List<DTO.City>();
            foreach(City item in dbCities)
            {
                var city = new DTO.City();
                city.Id = item.Id;
                city.Name = item.Name;
                city.IsLogisticCenter = item.IsLogisticCenter;
                dtoCities.Add(city);
            }

            return dtoCities;
        }

        public static void AddCity(DTO.City newCity)
        {
            CitiesAndRoadsDbContext db = new CitiesAndRoadsDbContext();
            if(String.IsNullOrWhiteSpace(newCity.Name))
            {
                throw new CustomException("City requires Name.");
            }
            if(DoesCityExist(newCity, db))
            {
                throw new CustomException("City already exists.");
            }

            var city = new City();
            city.Name = newCity.Name;
            db.Cities.Add(city);
            db.SaveChanges();
        }

        private static bool DoesCityExist(DTO.City newCity, CitiesAndRoadsDbContext db)
        {
            return db.Cities.Any(c => c.Name == newCity.Name);
        }

        public static void SetLogisticCenter(DTO.City logisticCenter)
        {
            CitiesAndRoadsDbContext db = new CitiesAndRoadsDbContext();

            logisticCenter.IsLogisticCenter = true;
            var city = db.Cities.First(c => c.Id == logisticCenter.Id);
            city.IsLogisticCenter = logisticCenter.IsLogisticCenter;
            db.SaveChanges();
        }
    }
}
