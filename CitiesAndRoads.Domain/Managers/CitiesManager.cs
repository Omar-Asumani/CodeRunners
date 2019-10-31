using CitiesAndRoads.Persistence;
using System;
using System.Linq;
using System.Collections.Generic;

namespace CitiesAndRoads.Domain
{
    public class CitiesManager
    {
        public static List<DTO.City> GetCities()
        {
            var cities = CitiesRepository.GetCities();
            return cities;
        }

        public static void AddCity(DTO.City city)
        {
            try
            {
                CitiesRepository.AddCity(city);
            }
            catch(Exception ex)
            {
                // Log it
                throw;
            }
        }

        public static string GetLogisticCentername()
        {
            IEnumerable<DTO.City> cities = GetCities();
            DTO.City logisticCenter = cities.FirstOrDefault(c => c.IsLogisticCenter == true);

            IEnumerable<DTO.Road> roads = RoadsManager.GetRoads();
            IEnumerable<DTO.Road> connectedRoadsTmp = null;
            DTO.Road furthestRoad = new DTO.Road();

            int newLogisticCenterId = 0;

            foreach(DTO.City city in cities)
            {
                connectedRoadsTmp = roads.Where(r => r.SideCityOneId == city.Id || r.SideCityTwoId == city.Id);
                if(connectedRoadsTmp != null && connectedRoadsTmp.Count() > 0)
                {
                    DTO.Road closestRoadTmp = connectedRoadsTmp.OrderBy(r => r.Length).First();
                    if(closestRoadTmp.Length > furthestRoad.Length)
                    {
                        furthestRoad = closestRoadTmp;
                        // Get logistic center city id which is opposite side of the furthest city
                        newLogisticCenterId = city.Id == furthestRoad.SideCityOneId ? furthestRoad.SideCityTwoId : furthestRoad.SideCityOneId;
                    }
                }
            }

            if(logisticCenter != null && logisticCenter.Id == newLogisticCenterId)
            {
                throw new CustomException("Logistic center hasn't changed.");
            }
            else if(newLogisticCenterId == 0)
            {
                throw new CustomException("Logistic center doesn't exist.");
            }
            else
            {
                logisticCenter = cities.First(c => c.Id == newLogisticCenterId);
                CitiesRepository.SetLogisticCenter(logisticCenter);
            }

            return logisticCenter.Name;
        }
    }
}
