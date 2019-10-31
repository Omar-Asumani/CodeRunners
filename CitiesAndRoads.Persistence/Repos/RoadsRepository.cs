using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CitiesAndRoads.DTO;

namespace CitiesAndRoads.Persistence
{
    public class RoadsRepository
    {
        public static List<DTO.Road> GetRoads()
        {
            CitiesAndRoadsDbContext db = new CitiesAndRoadsDbContext();
            List<Road> dbRoads = db.Roads.Include("SideCityOne").Include("SideCityTwo").OrderBy(r => r.Length).ToList();
            List<DTO.Road> dtoRoads = new List<DTO.Road>();
            foreach(Road item in dbRoads)
            {
                var road = new DTO.Road();
                road.Id = item.Id;
                road.Length = item.Length;
                road.SideCityOneId = item.SideCityOneId;
                road.SideCityOneName = item.SideCityOne.Name;
                road.SideCityTwoId = item.SideCityTwoId;
                road.SideCityTwoName = item.SideCityTwo.Name;
                dtoRoads.Add(road);
            }

            return dtoRoads;
        }

        public static void AddRoad(DTO.Road newRoad)
        {
            CitiesAndRoadsDbContext db = new CitiesAndRoadsDbContext();
            if(newRoad.Length == 0)
            {
                throw new CustomException("Road requires actual length.");
            }
            if(newRoad.SideCityOneId == newRoad.SideCityTwoId)
            {
                throw new CustomException("Cities must be different.");
            }
            if(DoesRoadExist(newRoad, db))
            {
                throw new CustomException("Road already exist.");
            }

            var road = new Road();
            road.Length = newRoad.Length;
            road.SideCityOneId = newRoad.SideCityOneId;
            road.SideCityTwoId = newRoad.SideCityTwoId;
            db.Roads.Add(road);
            db.SaveChanges();
        }

        private static bool DoesRoadExist(DTO.Road newRoad, CitiesAndRoadsDbContext db)
        {
            return db.Roads.Any(r =>
                (r.SideCityOneId == newRoad.SideCityOneId
                && r.SideCityTwoId == newRoad.SideCityTwoId)
                || (r.SideCityOneId == newRoad.SideCityTwoId
                && r.SideCityTwoId == newRoad.SideCityOneId));
        }
    }
}