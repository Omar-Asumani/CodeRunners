using System;

namespace CitiesAndRoads.DTO
{
    public class Road
    {
        public int Id { get; set; }
        public int Length { get; set; }
        public int SideCityOneId { get; set; }
        public string SideCityOneName { get; set; }
        public int SideCityTwoId { get; set; }
        public string SideCityTwoName { get; set; }
    }
}
