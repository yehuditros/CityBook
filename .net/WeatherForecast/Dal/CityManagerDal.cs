using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dal
{
    public static class CityManagerDal
    {



        public static int GetFavoriteCities()
        {


            using (var context = new Models.WeatherForecatDBContext())
            {
                return context.Cities.Where(t => t.IsFaorite == 1).ToList().Count();

            }


        }

        public static int AddToFavoriteCities(string city)
        {
            using (var context = new Models.WeatherForecatDBContext())
            {
                var c = context.Cities.Where(t => t.LabelCity == city).ToList().FirstOrDefault();
                if (c != null)
                {
                    if (c.IsFaorite == 1)
                        return 0;
                    else
                    {
                        c.IsFaorite = 1;
                        context.SaveChanges();
                        return 1;
                    }

                }
                else
                {
                    Models.Cities ci = new Models.Cities(city, "");
                    ci.IsFaorite = 1;
                    context.Cities.Add(ci);
                    context.SaveChanges();
                    return 1;
                }
            }
        }

        public static void AddToSearch(Common.Search search)
        {
            using (var context = new Models.WeatherForecatDBContext())
            {
                var c = context.Letters.Where(t => t.SearchLetters == search.searchLetters).ToList().FirstOrDefault();
                if (c == null)
                {
                    context.Letters.Add(new Models.Letters(search.searchLetters));
                    var l = context.Letters.Where(t => t.SearchLetters == search.searchLetters).ToList().FirstOrDefault();
                    foreach (var item in search.cities)
                    {
                        var city = context.Cities.Where(t => t.LabelCity == item.label).ToList().FirstOrDefault();
                        if (city == null)
                        {
                            context.Cities.Add(new Models.Cities(item.label, item.key));
                            city = context.Cities.Where(t => t.KeyCity == item.key).ToList().FirstOrDefault();
                        }
                        var cl = new Models.CitiesAndLetters(l.Id, city.Id);
                        context.CitiesAndLetters.Add(cl);
                        context.SaveChanges();
                    }
                    context.SaveChanges();
                }
            }

        }

        public static Common.Search[] GetAllSearches()
        {
            List<Common.Search> ls = new List<Common.Search>();


            using (var context = new Models.WeatherForecatDBContext())
            {
                var searches = context.Letters.Select(t => t).ToList();
                if (searches != null)
                {
                    foreach (var item in searches)
                    {
                        Common.Search s = new Common.Search();
                        s.searchLetters = item.SearchLetters;
                        List<Common.Result> lls = new List<Common.Result>();
                        var cid = context.CitiesAndLetters.Where(t => t.LettersId == item.Id).Select(t => t.CityId).ToList();
                        foreach (var c in cid)
                        {

                            var cdetails = context.Cities.Where(t => t.Id == c).ToList().FirstOrDefault();
                            Common.Result r = new Common.Result(cdetails.LabelCity, cdetails.KeyCity);
                            lls.Add(r);


                        }
                        var f = lls.ToArray();
                        s.cities = f;
                        ls.Add(s);
                    }
                    var ff = ls.ToArray();
                    return ff;

                }
                return null;
            }


        }
    }
}
