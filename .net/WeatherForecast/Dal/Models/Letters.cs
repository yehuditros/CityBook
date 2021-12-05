using System;
using System.Collections.Generic;

namespace Dal.Models
{
    public partial class Letters
    {
        public Letters()
        {
            CitiesAndLetters = new HashSet<CitiesAndLetters>();
        }

        public Letters(string searchLetters)
        {
            CitiesAndLetters = new HashSet<CitiesAndLetters>();
            SearchLetters = searchLetters;
        }

        public int Id { get; set; }
        public string SearchLetters { get; set; }

        public virtual ICollection<CitiesAndLetters> CitiesAndLetters { get; set; }
    }
}
