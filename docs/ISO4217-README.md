# ISO 4217
This package includes international standard currency codes, along with related information that may be useful in different contexts.

## Features
- Currency codes (numeric, alphabetic)
- Official, native, and common currency names
- Currency symbols
- Minor units
- Country associations
- Commodities and specialized currencies

## Usage

### Get countries & regions
Access the different lists of currencies using predefined properties in the `ISO4217` class.
```csharp
var currencies = ISO4217.Currencies;
var specializedCurrencies = ISO4217.SpecializedCurrencies;
var commodities = ISO4217.Commodities;
```

Alternatively, you can get specific currencies using their predefined currency property or their international codes:
```csharp
var euro = CurrencyInfo.Euro;
var danishKrone = ISO4217.GetCurrencyByCode("DKK");
var unitedStatesDollar = ISO4217.GetCurrencyByCode("840");
```

## Models
```cs
public partial record CurrencyInfo
{
    public string CommonName { get; init; }
    public string NativeName { get; init; }
    public string OfficialName { get; init; }
    public string? Symbol { get; init; }
    public string NumericCode { get; init; }
    public string AlphabeticCode { get; init; }
    public Dictionary<string, string> Countries { get; init; }
    public int? MinorUnit { get; init; }
}
```
Each model includes a custom string representation for easy printing and debugging:
```
Common Name: Krone
Native Name: Dansk Krone
Official Name: Danish Krone
Symbol: kr.
Numeric Code: 208
Alphabetic Code: DKK
Countries: Kingdom of Denmark (DNK), Faroe Islands (FRO), Greenland (GRL)
Minor Unit: 2
```
