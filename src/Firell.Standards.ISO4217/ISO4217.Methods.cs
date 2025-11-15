using System.Diagnostics.CodeAnalysis;

#pragma warning disable IDE0130
namespace Firell.Standards;
#pragma warning restore IDE0130

public static partial class ISO4217
{
    /// <summary>
    /// Lookup dictionary for currencies by their numeric code.
    /// </summary>
    private static readonly Dictionary<string, CurrencyInfo> _numericCodeLookup = new Dictionary<string, CurrencyInfo>(Currencies.Count + SpecializedCurrencies.Count + Commodities.Count, StringComparer.OrdinalIgnoreCase);

    /// <summary>
    /// Lookup dictionary for currencies by their alphabetic code.
    /// </summary>
    private static readonly Dictionary<string, CurrencyInfo> _alphabeticCodeLookup = new Dictionary<string, CurrencyInfo>(Currencies.Count + SpecializedCurrencies.Count + Commodities.Count, StringComparer.OrdinalIgnoreCase);

    /// <summary>
    /// Initializes static lookup dictionaries for efficient retrieval of currency information by numeric and alphabetic codes.
    /// </summary>
    static ISO4217()
    {
        foreach (CurrencyInfo currency in Currencies.Concat(SpecializedCurrencies).Concat(Commodities))
        {
            _numericCodeLookup[currency.NumericCode] = currency;
            _alphabeticCodeLookup[currency.AlphabeticCode] = currency;
        }
    }

    /// <summary>
    /// Retrieves a currency based on its code, which can be its three-digit numeric code or the three-letter alphabetic code.
    /// </summary>
    /// <param name="code">The currency code to look up.</param>
    /// <returns>A <see cref="CurrencyInfo"/> object if a matching currency is found; otherwise, <see langword="null"/>.</returns>
    public static CurrencyInfo? GetCurrencyByCode(string code)
    {
        // We know that if the length isn't 3, then it can't be either an alphabetic code or a numeric code, so we return null.
        if (code.Length != 3)
        {
            return null;
        }

        // Since alphabetic codes are more common than numeric codes, we check for the alphabetic code first.
        if (_alphabeticCodeLookup.TryGetValue(code, out CurrencyInfo? currency))
        {
            return currency;
        }
        else if (_numericCodeLookup.TryGetValue(code, out currency))
        {
            return currency;
        }

        return null;
    }

    /// <summary>
    /// Attempts to retrieve a currency based on its code, which can be its three-digit numeric code or the three-letter alphabetic code.
    /// </summary>
    /// <param name="code">The currency code to look up.</param>
    /// <param name="currency">When this method returns, contains the <see cref="CurrencyInfo"/> object associated with the specified code, if the lookup succeeds; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if a currency with the specified code is found; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetCurrencyByCode(string code, [NotNullWhen(true)] out CurrencyInfo? currency)
    {
        currency = GetCurrencyByCode(code);
        return currency is not null;
    }
}
