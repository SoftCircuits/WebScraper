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
// Add URL placeholders data
scraper.Placeholders.Add(new Placeholder("location", new[] { "salt-lake-city-ut", "ogden-ut", }));
scraper.Placeholders.Add(new Placeholder("category", new[] { "lawn-mower-repair", "plumbers" }));
// Set container selectors
scraper.ContainerSelector = @"div[id=""top-center-ads""][class=""search-results center-ads""],div[class=""search-results organic""],div[id=""bottom-center-ads""][class=""search-results center-ads""]";
// Set item selectors
scraper.ItemSelector = @"div[id:=""lid-\d+""][class=""result""] div[class=""v-card""]";
// Set next-page selectors
scraper.NextPageSelector = @"div.pagination a[class=""next ajax-page""]";
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

As you can see, there are a number of steps to get the class working. We'll go through those steps here.

#### Url

After creating an instance of the `Scraper` class, you set the `Url` property to the URL you want to scrape. This property can be set to a regular URL. The URL can also contain a `{page}` tag. For targets that involve multiple pages, this tag will be replaced with the current page number. We'll discuss this a little more later.

The URL can also contain user tags. In the code above, two user tags are defined, `{location}` and `{category}`. These tags will also be replaced with data that you supply. We will also discuss this a little more later.

#### ContainerSelector

The `ContainerSelector` property is a string *selector* that identifies the elements on the page that contain all the items to be scraped. Selectors used by WebScraper are similar to CSS or jQuery selectors. There is a section on WebScraper selectors below. For now, just know that selectors describe one or more elements on a page.

The container narrows down the area to be searched when looking for data to scrape, and so it makes the code a little more efficient. But `ContainerSelector` is the only selector that is optional. If it is not provided, then the entire page is the container.

#### ItemSelector

The `ItemSelector` property is a string selector that identifies the elements within the container that contain data for one item. For example, if you are scanning a website that lists employee details, you would have an element that contains all the employees on the current page (the container). And within the container you would have any number of elements that contain the information for a specific employee (the item).

The library will look for the specific data items you are requesting within the item element or elements, and the library will know all data found within this location is for one employee (item). 

#### NextPageSelector





## Selectors
