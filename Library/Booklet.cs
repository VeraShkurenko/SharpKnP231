using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpKnP231.Library
{
    public class Booklet : Literature
    {
        public String Organization { get; set; } = null!;
        public int Year { get; set; }

        public override string GetCard()
        {
            return $"{base.Title} - {base.Publisher} - {this.Year}. {this.Organization}";
        }
    }
}
