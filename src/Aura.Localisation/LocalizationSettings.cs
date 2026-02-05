using System.Globalization;

namespace Aura;

public static class LocalizationSettings
{
    public static CultureInfo SelectedLocale { get; set; } =  new CultureInfo("en-US");
}
