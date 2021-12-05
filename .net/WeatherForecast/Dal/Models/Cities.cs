using System;
using System.Collections.Generic;

namespace Dal.Models
{
    public partial class Cities
    {
        public Cities()
        {
            CitiesAndLetters = new HashSet<CitiesAndLetters>();
        }

        public Cities(string l, string k)
        {
            CitiesAndLetters = new HashSet<CitiesAndLetters>();
            LabelCity = l;
            KeyCity = k;
            IsFaorite = 0;
        }
        public int Id { get; set; }
        public string LabelCity { get; set; }
        public string KeyCity { get; set; }
        public int? IsFaorite { get; set; }

        public virtual ICollection<CitiesAndLetters> CitiesAndLetters { get; set; }
    }
}
