# WebScraper

[![NuGet version (SoftCircuits.WebScraper)](https://img.shields.io/nuget/v/SoftCircuits.WebScraper.svg?style=flat-square)](https://www.nuget.org/packages/SoftCircuits.WebScraper/)

```
Install-Package SoftCircuits.WebScraper
```

## Introduction

.NET library to scrape content from the Internet. Use it to extract information from Web pages in your own application.


```cs
Scraper scraper = new Scraper
{
    Url = "https://www.yellowpages.com/{location}/{category}?page={page}",
    ContainerSelector = @"div[id=""top-center-ads""][class=""search-results center-ads""],div[class=""search-results organic""],div[id=""bottom-center-ads""][class=""search-results center-ads""]",
    ItemSelector = @"div[id:=""lid-\d+""][class=""result""] div[class=""v-card""]",
    NextPageSelector = @"div.pagination a[class=""next ajax-page""]",
    DataSeparator = ",",
};

scraper.Placeholders.Add(new Placeholder("location", new[] { "salt-lake-city-ut", "ogden-ut", }));
scraper.Placeholders.Add(new Placeholder("category", new[] { "lawn-mower-repair", "plumbers" }));
scraper.Fields.Add(new TextField("Name", "a.business-name span"));
scraper.Fields.Add(new TextField("Address", "p.adr"));
scraper.Fields.Add(new TextField("Phone", "div.phones.phone.primary"));
scraper.Fields.Add(new TextField("Category", "div.categories > a"));
scraper.Fields.Add(new AttributeField("Website", "a.track-visit-website", "href"));

scraper.UpdateProgress += Scraper_UpdateProgress;

await scraper.RunAsync(@"D:\Users\Jonathan\Desktop\Scraper.csv");
```

## Using the Library

To use the library, create an instance of the `Scraper` class. This class requires you to set up a number of properties to scrape data, which we'll go through next.

Start by setting the `Url` property to the URL you want to scrape. This property can be set to any complete URL. But it can also contain replacement tags.




