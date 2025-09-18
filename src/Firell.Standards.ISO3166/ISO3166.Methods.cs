using System.Diagnostics.CodeAnalysis;

#pragma warning disable IDE0130
namespace Firell.Standards;
#pragma warning restore IDE0130

public static partial class ISO3166
{
    /// <summary>
    /// Lookup dictionary for countries by their numeric code.
    /// </summary>
    private static readonly Dictionary<string, CountryInfo> _numericCodeLookup = new Dictionary<string, CountryInfo>(Countries.Count, StringComparer.OrdinalIgnoreCase);

    /// <summary>
    /// Lookup dictionary for countries by their two-letter code.
    /// </summary>
    private static readonly Dictionary<string, CountryInfo> _twoLetterCodeLookup = new Dictionary<string, CountryInfo>(Countries.Count, StringComparer.OrdinalIgnoreCase);

    /// <summary>
    /// Lookup dictionary for countries by their three-letter code.
    /// </summary>
    private static readonly Dictionary<string, CountryInfo> _threeLetterCodeLookup = new Dictionary<string, CountryInfo>(Countries.Count, StringComparer.OrdinalIgnoreCase);

    /// <summary>
    /// Initializes static lookup dictionaries for efficient retrieval of country information by numeric, two-letter, and three-letter codes.
    /// </summary>
    static ISO3166()
    {
        foreach (CountryInfo country in Countries)
        {
            _numericCodeLookup[country.NumericCode] = country;
            _twoLetterCodeLookup[country.TwoLetterCode] = country;
            _threeLetterCodeLookup[country.ThreeLetterCode] = country;
        }
    }

    /// <summary>
    /// Retrieves a country based on its code, which can be its numeric code (3 digits), a two-letter ISO 3166-1 alpha-2 code, or a three-letter ISO 3166-1 alpha-3 code.
    /// </summary>
    /// <param name="code">The country code to look up.</param>
    /// <returns>A <see cref="CountryInfo"/> object if a matching country is found; otherwise, <see langword="null"/>.</returns>
    public static CountryInfo? GetCountryByCode(string code)
    {
        // We know that if the length is 2, it's a two-letter code, so we check that first and its also the most common code type.
        if (code.Length == 2 && _twoLetterCodeLookup.TryGetValue(code, out CountryInfo? country))
        {
            return country;
        }

        // If the length is not 3, it can't be a three-letter or numeric code, so we return null.
        if (code.Length != 3)
        {
            return null;
        }

        // We know that if the length is 3, it can only be either a three-letter code or a numeric code.
        // Since three-letter codes are more common than numeric codes, we check for the three-letter code first.
        if (_threeLetterCodeLookup.TryGetValue(code, out country))
        {
            return country;
        }
        else if (_numericCodeLookup.TryGetValue(code, out country))
        {
            return country;
        }

        return null;
    }

    /// <summary>
    /// Attempts to retrieve a country based on its code, which can be its numeric code (3 digits), a two-letter ISO 3166-1 alpha-2 code, or a three-letter ISO 3166-1 alpha-3 code.
    /// </summary>
    /// <param name="code">The country code to look up.</param>
    /// <param name="country">When this method returns, contains the <see cref="CountryInfo"/> object associated with the specified code, if the lookup succeeds; otherwise, <see langword="null"/>.</param>
    /// <returns><see langword="true"/> if a country with the specified code is found; otherwise, <see langword="false"/>.</returns>
    public static bool TryGetCountryByCode(string code, [NotNullWhen(true)] out CountryInfo? country)
    {
        country = GetCountryByCode(code);
        return country is not null;
    }

    /// <summary>
    /// Retrieves a read-only collection of countries that belong to the specified region.
    /// </summary>
    /// <param name="region">The region to filter countries by.</param>
    /// <returns>A read-only collection of <see cref="CountryInfo"/> objects that are located in the specified region. If no countries are found for the given region, an empty collection is returned.</returns>
    public static IReadOnlyList<CountryInfo> GetCountriesByRegion(string region)
    {
        return Countries.Where(c => c.Region.Equals(region, StringComparison.OrdinalIgnoreCase)).ToArray();
    }

    /// <summary>
    /// Retrieves a read-only collection of countries that belong to the specified subregion.
    /// </summary>
    /// <param name="subregion">The subregion to filter countries by.</param>
    /// <returns>A read-only collection of <see cref="CountryInfo"/> objects that are located in the specified subregion. If no countries are found for the given subregion, an empty collection is returned.</returns>
    public static IReadOnlyList<CountryInfo> GetCountriesBySubregion(string subregion)
    {
        return Countries.Where(c => c.Subregion.Equals(subregion, StringComparison.OrdinalIgnoreCase)).ToArray();
    }
}
