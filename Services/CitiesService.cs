﻿using ServiceContract;
namespace Services
{
    public class CitiesService : ICitiesService
    {
        private List<string> _cities;
        private Guid _id;
        public Guid Id 
        {
            get
            {
                return _id;
            }
        }

        public CitiesService()
        {
            _id = Guid.NewGuid();
            _cities = new List<string>()
         {
             "London",
             "Paris",
             "India",
             "hongkong",
             "New York"
         };
        
        }
        public List<string> GetCities()
        {
            return _cities;
        }
    }
}
