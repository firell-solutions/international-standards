#pragma warning disable IDE0130
namespace Firell.Standards;
#pragma warning restore IDE0130

/// <summary>
/// Represents a currency with a name and symbol.
/// </summary>
public record Currency
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Currency"/> class with the specified name and symbol.
    /// </summary>
    /// <param name="name">The name of the currency.</param>
    /// <param name="symbol">The symbol of the currency.</param>
    public Currency(string name, string symbol)
    {
        Name = name;
        Symbol = symbol;
    }

    /// <summary>
    /// Gets the name of the currency.
    /// </summary>
    public string Name { get; init; }

    /// <summary>
    /// Gets the symbol of the currency.
    /// </summary>
    public string Symbol { get; init; }

    public override string ToString()
    {
        return $"{Name} ({Symbol})";
    }
}
