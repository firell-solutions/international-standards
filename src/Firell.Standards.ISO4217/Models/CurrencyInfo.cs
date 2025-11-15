using System.Text;

#pragma warning disable IDE0130
namespace Firell.Standards;
#pragma warning restore IDE0130

/// <summary>
/// Represents information about a currency, including its names, codes, symbol, and associated countries.
/// </summary>
public partial record CurrencyInfo
{
    /// <summary>
    /// Gets the common name associated with the currency.
    /// </summary>
    public required string CommonName { get; init; }

    /// <summary>
    /// Gets the native or local name associated with the currency.
    /// </summary>
    public required string NativeName { get; init; }

    /// <summary>
    /// Gets the official name associated with the currency.
    /// </summary>
    public required string OfficialName { get; init; }

    /// <summary>
    /// Gets the symbol used to represent the currency.
    /// </summary>
    public string? Symbol { get; init; }

    /// <summary>
    /// Gets the three-digit ISO 4217 numeric currency code.
    /// </summary>
    public required string NumericCode { get; init; }

    /// <summary>
    /// Gets the three-letter ISO 4217 alphabetic currency code.
    /// </summary>
    public required string AlphabeticCode { get; init; }

    /// <summary>
    /// Gets the countries that use this currency, represented as a dictionary where the key is the country code and the value is the country name.
    /// </summary>
    public Dictionary<string, string> Countries { get; init; } = new Dictionary<string, string>();

    /// <summary>
    /// Gets the number of minor units (decimal places) used by the currency.
    /// </summary>
    public int? MinorUnit { get; init; }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();

        builder.AppendLine($"Common Name: {CommonName}");
        builder.AppendLine($"Native Name: {NativeName}");
        builder.AppendLine($"Official Name: {OfficialName}");

        if (!string.IsNullOrWhiteSpace(Symbol))
        {
            builder.AppendLine($"Symbol: {Symbol}");
        }

        builder.AppendLine($"Numeric Code: {NumericCode}");
        builder.AppendLine($"Alphabetic Code: {AlphabeticCode}");

        if (Countries.Count > 0)
        {
            IEnumerable<string> countries = Countries.Select(x => $"{x.Value} ({x.Key})");
            builder.AppendLine($"Countries: {string.Join(", ", countries)}");
        }

        if (MinorUnit.HasValue)
        {
            builder.AppendLine($"Minor Unit: {MinorUnit}");
        }

        return builder.ToString();
    }
}
