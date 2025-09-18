using System.Text;

#pragma warning disable IDE0130
namespace Firell.Standards;
#pragma warning restore IDE0130

/// <summary>
/// Represents a country with its associated names and ISO 3166-1 codes.
/// </summary>
public partial record CountryInfo
{
    /// <summary>
    /// Gets the common name of the country.
    /// </summary>
    public required string CommonName { get; init; }

    /// <summary>
    /// Gets the common native name of the country.
    /// </summary>
    public required string CommonNativeName { get; init; }

    /// <summary>
    /// Gets the official name of the country.
    /// </summary>
    public required string OfficialName { get; init; }

    /// <summary>
    /// Gets the official native name of the country.
    /// </summary>
    public required string OfficialNativeName { get; init; }

    /// <summary>
    /// Gets the three-digit ISO 3166-1 numeric country code.
    /// </summary>
    public required string NumericCode { get; init; }

    /// <summary>
    /// Gets the two-letter ISO 3166-1 alpha-2 country code.
    /// </summary>
    public required string TwoLetterCode { get; init; }

    /// <summary>
    /// Gets the three-letter ISO 3166-1 alpha-3 country code.
    /// </summary>
    public required string ThreeLetterCode { get; init; }

    /// <summary>
    /// Gets the region where the country is located.
    /// </summary>
    public required string Region { get; init; }

    /// <summary>
    /// Gets the subregion of the region where the country is located.
    /// </summary>
    public required string Subregion { get; init; }

    /// <summary>
    /// Gets the capital city of the country.
    /// </summary>
    public required string Capital { get; init; }

    /// <summary>
    /// Gets the languages spoken in the country, represented as a dictionary where the key is the language code and the value is the language name.
    /// </summary>
    public Dictionary<string, string> Languages { get; init; } = new Dictionary<string, string>();

    /// <summary>
    /// Gets the currencies used in the country, represented as a dictionary where the key is the currency code and the value is a <see cref="Currency"/> object containing the currency's name and symbol.
    /// </summary>
    public Dictionary<string, Currency> Currencies { get; init; } = new Dictionary<string, Currency>();

    /// <summary>
    /// Gets the international dialing code of the country.
    /// </summary>
    public required string DialingCode { get; init; }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();

        builder.AppendLine($"Common Name: {CommonName}");
        builder.AppendLine($"Common Native Name: {CommonNativeName}");

        builder.AppendLine($"Official Name: {OfficialName}");
        builder.AppendLine($"Official Native Name: {OfficialNativeName}");

        builder.AppendLine($"Numeric Code: {NumericCode}");
        builder.AppendLine($"Two Letter Code: {TwoLetterCode}");
        builder.AppendLine($"Three Letter Code: {ThreeLetterCode}");

        builder.AppendLine($"Region: {Region}");
        builder.AppendLine($"Subregion: {Subregion}");
        builder.AppendLine($"Capital: {Capital}");

        foreach (KeyValuePair<string, string> language in Languages)
        {
            builder.AppendLine($"Language: {language.Value} ({language.Key})");
        }

        foreach (KeyValuePair<string, Currency> currency in Currencies)
        {
            builder.AppendLine($"Currency: {currency.Value.Name} ({currency.Key}, {currency.Value.Symbol})");
        }

        builder.AppendLine($"Dialing Code: {DialingCode}");

        return builder.ToString();
    }
}
