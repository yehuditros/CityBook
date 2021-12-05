using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class Search
    {
        public string searchLetters;
        public Result[] cities;

        public Search(string l, Result[] res)
        {
            searchLetters = l;
            cities = res;
        }
        public Search()
        {

        }
    }


}
