using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpKnP231.Library
{
    internal class Poster : Literature, INonPrintable
    {
        public string Topic { get; set; }

        public Poster(string title, string topic)
        {
            Title = title;
            Topic = topic;
            Publisher = "Друкарня 'АртПростір'";
        }

        public override string GetCard()
        {
            return $"Poster: {Title} ({Topic}) - {Publisher}";
        }
    }
}
