using System;
using System.Collections.Generic;

namespace Dal.Models
{
    public partial class CitiesAndLetters
    {
        public CitiesAndLetters(int l, int c)
        {
            CityId = c;
            LettersId = l;

        }


        public CitiesAndLetters()
        {
        }

        public int Id { get; set; }
        public int CityId { get; set; }
        public int LettersId { get; set; }

        public virtual Cities City { get; set; }
        public virtual Letters Letters { get; set; }
    }
}
