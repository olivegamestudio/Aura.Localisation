using System.Globalization;

namespace Aura;

public class LocalisedStringTable
{
    public Dictionary<CultureInfo, string> Text { get; set; } = [];
}
