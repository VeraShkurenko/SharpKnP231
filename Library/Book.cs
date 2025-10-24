using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpKnP231.Library
{
    public class Book : Literature
    {
        public String Author { get; set; } = null!;
        
        #region property - з явною реалізацією

        private int _year;

        public int Year
        {
            get => _year;
            set
            {
                if (_year != value) // value - значення що приходить на заміну
                {                   // в інструкціі book.Year = 2000
                    _year = value;  // (value = 2000) 
                }
            }
        }
        #endregion
        public override string GetCard()
        {
            return $"{this.Author}. {base.Title} - {base.Publisher} - {this.Year}";
        }
    }
}
