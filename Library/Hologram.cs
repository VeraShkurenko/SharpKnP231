using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpKnP231.Library;

internal class Hologram : Literature, INonPrintable
{
    public String ArtItem { get; set; } = null!;
    public override string GetCard()
    {
        return $"Hologram of {Title}: Hologram of {ArtItem} by {base.Publisher}";
    }
}