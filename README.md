# WebScraper

[![NuGet version (SoftCircuits.WebScraper)](https://img.shields.io/nuget/v/SoftCircuits.WebScraper.svg?style=flat-square)](https://www.nuget.org/packages/SoftCircuits.WebScraper/)

```
Install-Package SoftCircuits.WebScraper
```

## Introduction

.NET library to scrape content from the Internet. Use it to extract information from Web pages in your own application.

## Using the Library

Some example code that uses the library is shown below.

```cs
// Create Scraper object and set properties
Scraper scraper = new Scraper();

// Set URL template
scraper.Url = "https://www.example.com/{location}/{category}?page={page}";
// Set container selectors
scraper.ContainerSelector = @"div[id=""top-center-ads""][class=""search-results center-ads""],div[class=""search-results organic""],div[id=""bottom-center-ads""][class=""search-results center-ads""]";
// Set item selectors
scraper.ItemSelector = @"div[id:=""lid-\d+""][class=""result""] div[class=""v-card""]";
// Set next-page selectors
scraper.NextPageSelector = @"div.pagination a[class=""next ajax-page""]";
// Add URL placeholders data
scraper.Placeholders.Add(new Placeholder("location", new[] { "salt-lake-city-ut", "ogden-ut", }));
scraper.Placeholders.Add(new Placeholder("category", new[] { "lawn-mower-repair", "plumbers" }));
// Add data fields
scraper.Fields.Add(new TextField("Name", "a.business-name span"));
scraper.Fields.Add(new TextField("Address", "p.adr"));
scraper.Fields.Add(new TextField("Phone", "div.phones.phone.primary"));
scraper.Fields.Add(new TextField("Category", "div.categories > a"));
scraper.Fields.Add(new AttributeField("Website", "a.track-visit-website", "href"));

// Add handler for UpdateProgress events
scraper.UpdateProgress += Scraper_UpdateProgress;

// Run scraper
await scraper.RunAsync(@"ScraperData.csv");
```

As you can see, there is quite a bit of setup to get it working. We'll step through that here.

After creating an instance of the `Scraper` class, you set the `Url` property to the URL you want to scrape. This property can be set to a complete, regular URL. But it can also contain replacement tags.




