# MetalArchivesNET

MetalArchivesNET is a .NET library which parses [https://www.metal-archives.com](https://www.metal-archives.com) HTML and JSON data into a programmer-friendly code.

# Nuget
`
PM> Install-Package MetalArchivesNET -Version 1.0.0
`\
\
[https://www.nuget.org/packages/MetalArchivesNET/1.0.0](https://www.nuget.org/packages/MetalArchivesNET/1.0.0)

## Usage

```csharp
using MetalArchivesNET;

// ...

IEnumerable<SimpleBandSearchResult> results = MetalArchives.Band.ByName("black sabbath");

foreach (var band in bands)
    Console.WriteLine($"{band.Name} comes from {band.Country} and plays {band.Genre}");
```

## License
[MIT](https://choosealicense.com/licenses/mit/)