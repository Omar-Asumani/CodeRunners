using CitiesAndRoads.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitiesAndRoads.Domain
{
    public class RoadsManager
    {
        public static List<DTO.Road> GetRoads()
        {
            var roads = RoadsRepository.GetRoads();
            return roads;
        }

        public static void AddRoad(DTO.Road road)
        {
            try
            {
                RoadsRepository.AddRoad(road);
            }
            catch(Exception ex)
            {
                // Log it
                throw;
            }
        }
    }
}
