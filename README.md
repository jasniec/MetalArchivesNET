# MetalArchivesNET

MetalArchivesNET is a .NET library which parses [https://www.metal-archives.com](https://www.metal-archives.com) HTML and JSON data into a programmer-friendly code.

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