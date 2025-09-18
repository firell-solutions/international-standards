# International Standards
Working with international standards data can be tricky. It is often hard to find and even harder to keep up to date across multiple projects. This library gives .NET developers a straightforward alternative to building or collecting their own data. Its simple interface lets you access a wide range of information with minimal code.

The library is broken into smaller NuGet packages so you can pick only the standards you need, keeping your projects lean and clutter-free. If you want everything, the main package bundles all sub-packages for convenience.

## ISO 3166
This package includes international standard country codes, along with related information that may be useful in different contexts.

### Features
- Country codes (numeric, alpha-2, alpha-3)
- Common and native country names
- Official country names
- Regions and capital cities
- Spoken languages and active currencies
- International dialing codes

### Usage

#### Get countries & regions
Access the list of countries or regions using predefined properties in the `ISO3166` class, or filter countries by region.
```csharp
var countries = ISO3166.Countries;
var regions = ISO3166.Regions;
var europe = ISO3166.GetCountriesByRegion(Region.Europe);
var northernEurope = ISO3166.GetCountriesBySubregion(Subregion.NorthernEurope);
```

Alternatively, you can get specific countries using their predefined country property or their international codes:
```csharp
var canada = CountryInfo.Canada;
var germany = ISO3166.GetCountryByCode("276");
var denmark = ISO3166.GetCountryByCode("DK");
var unitedStates = ISO3166.GetCountryByCode("USA");
```

### Models
```cs
public record CountryInfo
{
    public string CommonName { get; init; }
    public string CommonNativeName { get; init; }
    public string OfficialName { get; init; }
    public string OfficialNativeName { get; init; }
    public string NumericCode { get; init; }
    public string TwoLetterCode { get; init; }
    public string ThreeLetterCode { get; init; }
    public string Region { get; init; }
    public string Subregion { get; init; }
    public string Capital { get; init; }
    public Dictionary<string, string> Languages { get; init; }
    public Dictionary<string, Currency> Currencies { get; init; }
    public string DialingCode { get; init; }
}

public record Currency
{
    public string Name { get; init; }
    public string Symbol { get; init; }
}
```
Each model includes a custom string representation for easy printing and debugging:
```
Common Name: Denmark
Common Native Name: Danmark
Official Name: Kingdom of Denmark
Official Native Name: Kongeriget Danmark
Numeric Code: 208
Two Letter Code: DK
Three Letter Code: DNK
Region: Europe
Subregion: Northern Europe
Capital: Copenhagen
Language: Danish (DAN)
Currency: Danish krone (DKK, kr)
Dialing Code: +45
```

## Planned Standards
Additional international standards will be added over time, either upon request or as needed.
- [x] ISO3166 (Country codes)
- [ ] ISO4217 (Currency codes)
