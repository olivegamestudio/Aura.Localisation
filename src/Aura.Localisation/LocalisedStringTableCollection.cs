using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Aura;

public static class LocalisedStringTableCollection
{
    static readonly Dictionary<string, LocalisedStringTable> _tables = new();

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [DebuggerStepThrough]
    public static void Clear()
    {
        _tables.Clear();
    }
    
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [DebuggerStepThrough]
    public static void Add(string key, CultureInfo language, string text)
    {
        if (_tables.TryGetValue(key, out LocalisedStringTable? table))
        {
            table.Text[language] = text;
            return;
        }

        LocalisedStringTable newTable = new LocalisedStringTable();
        newTable.Text.Add(language, text);
        _tables.Add(key, newTable);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [DebuggerStepThrough]
    public static string Resolve(string key)
    {
        if (_tables.ContainsKey(key))
        {
            if (_tables[key].Text.ContainsKey(LocalizationSettings.SelectedLocale))
            {
                return _tables[key].Text[LocalizationSettings.SelectedLocale];
            }
        }

        return string.Empty;
    }
}
