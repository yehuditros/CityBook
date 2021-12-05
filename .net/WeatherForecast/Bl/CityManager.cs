using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dal;
using Common;

namespace Bl
{
    public static class CityManager
    {
        public static int GetFavoriteCities()
        {
            return CityManagerDal.GetFavoriteCities();
        }


        public static int AddToFavoriteCities(string city)
        {
            return CityManagerDal.AddToFavoriteCities(city);
        }

        public static void AddToSearch(Common.Search search)
        {
            CityManagerDal.AddToSearch(search);
        }

        public static Common.Search[] GetAllSearches()
        {
            return CityManagerDal.GetAllSearches();
        }

    }
}
