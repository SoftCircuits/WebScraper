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
// Set next-page selectors
scraper.NextPageSelector = @"div.pagination a[class=""next ajax-page""]";
// Add URL placeholders data
scraper.Placeholders.Add(new Placeholder("location", new[] { "salt-lake-city-ut", "ogden-ut", }));
scraper.Placeholders.Add(new Placeholder("category", new[] { "lawn-mower-repair", "plumbers" }));
// Set container selectors
scraper.ContainerSelector = @"div[id=""top-center-ads""][class=""search-results center-ads""],div[class=""search-results organic""],div[id=""bottom-center-ads""][class=""search-results center-ads""]";
// Set item selectors
scraper.ItemSelector = @"div[id:=""lid-\d+""][class=""result""] div[class=""v-card""]";
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

### Url

After creating an instance of the `Scraper` class, you set the `Url` property to the URL you want to scrape. This property can be set to a regular URL. The URL can also contain a `{page}` tag. For targets that involve multiple pages, this tag will be replaced with the current page number. For more details, see the NextPageSelector section further down.

The URL can also contain user tags. In the code above, two user tags are defined, `{location}` and `{category}`. These tags will also be replaced with data that you supply.

### Placeholders

The `Placeholders` property is a collection that defines the values you want to replace any user tags you've defined. A `Placeholder` contains a name--the tag without the curly braces (`{` and `}`), and a list of items that will replace the tag.

So if your URL is `"http://www.example.com/{category}"`, and you define a `Placeholder` with the name `"category"` (not case-sensitive) and the list of values: `"electrical"`, `"plumbing"`, and `"furniture"`, the `Scraper` class will examine the following URLs:

- http://www.example.com/electrical
- http://www.example.com/plumbing
- http://www.example.com/furniture

Moreover, if you changed the URL to `"http://www.example.com/{location}/{category}"` and added a second `Placeholder` with the name `"location"` and the list of values: `"Los-Angeles"`, `"Denver"`, and `"New-York"`, it will example the following URLs:

- http://www.example.com/Los-Angeles/electrical
- http://www.example.com/Los-Angeles/plumbing
- http://www.example.com/Los-Angeles/furniture
- http://www.example.com/Denver/electrical
- http://www.example.com/Denver/plumbing
- http://www.example.com/Denver/furniture
- http://www.example.com/New-York/electrical
- http://www.example.com/New-York/plumbing
- http://www.example.com/New-York/furniture

As you can see, the library will generate a URL using every combination of placeholders you provide, regardless of the number of placeholders you define. In addition, if the `{page}` tag is implemented, multiple pages will be generated for every combination of your user tags.

### ContainerSelector

The `ContainerSelector` property is a string *selector* that identifies the elements on the page that contain all the items to be scraped. Selectors used by WebScraper are similar to CSS or jQuery selectors. There is a section on WebScraper selectors below. For now, just know that selectors describe one or more elements on a page.

The container narrows down the area to be searched when looking for data to scrape, and so it makes the code a little more efficient. But `ContainerSelector` is the only selector that is optional. If it is not provided, then the entire page is the container.

### ItemSelector

The `ItemSelector` property is a string selector that identifies the elements within the container that contain data for one item. For example, if you are scanning a website that lists employee details, you would have an element that contains all the employees on the current page (the container). And within the container you would have any number of elements that contain the information for a specific employee (the item).

The library will look for the specific data items you are requesting within the item element or elements, and the library will know all data found within this location is for one employee (item). 

### NextPageSelector

The `NextPageSelector` property is a string selector that identifies the element or elements that, if present, indicate there are more pages. For example, paged results generally have some sort of *Next* button used to access the next page. By adding a selector that describes this element, the library uses it to determine if there are additional pages. And if the `{page}` tag is included in the URL, it will be incremented for each page.




## Selectors
