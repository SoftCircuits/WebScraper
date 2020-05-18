# WebScraper

[![NuGet version (SoftCircuits.WebScraper)](https://img.shields.io/nuget/v/SoftCircuits.WebScraper.svg?style=flat-square)](https://www.nuget.org/packages/SoftCircuits.WebScraper/)

```
Install-Package SoftCircuits.WebScraper
```

## Introduction

.NET library to scrape content from the Internet. Use it to extract information from Web pages in your own application. The library writes the extracted data to a CSV file.

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
// Set next-page selectors
scraper.NextPageSelector = @"div.pagination a[class=""next ajax-page""]";
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

After creating an instance of the `Scraper` class, you set the `Url` property to the URL you want to scrape. This property can be set to a regular URL. The URL can also contain special placeholder tags that will be replaced with replacement values. The code example above sets the URL to a value that contains three placeholder tags: `{location}`, `{category}`, and `{page}`. We'll cover these next.

### Placeholders

The `Placeholders` property is a collection that defines the values you want to replace any user tags you've defined. A `Placeholder` contains a name--the tag without the curly braces (`{` and `}`)--and a list of items that will replace the tag.

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

### NextPageSelector

In addition to user tags, a URL can also contain the `{page}` tag. For targets that involve multiple pages, this tag will be replaced with the current page number.

The `NextPageSelector` property is a string selector that identifies the element or elements that, if present, indicate there are more pages. *Selectors used by WebScraper are similar to CSS or jQuery selectors. There is a section on WebScraper selectors below. For now, just know that selectors describe one or more elements on a page.*

For example, paged results generally have some sort of *Next* button used to access the next page. By adding a selector that describes this element, the library uses it to determine if there are additional pages. And if the `{page}` tag is included in the URL, it will be incremented for each page.

### ContainerSelector

The `ContainerSelector` property is a string *selector* that identifies the elements on the page that contain all the items to be scraped.

The container narrows down the area to be searched when looking for data to scrape, and so it makes the code a little more efficient. But `ContainerSelector` is the only selector that is optional. If it is not provided, then the entire page is the container.

### ItemSelector

The `ItemSelector` property is a string selector that identifies the elements within the container that contain data for one item. For example, if you are scanning a website that lists employee details, you would have an element that contains all the employees on the current page (the container). And within the container you would have any number of elements that contain the information for a specific employee (the item).

The library will look for the specific data items you are requesting within the item element or elements, and the library will know all data found within this location is for one employee (item). 

Note that the `ItemSelector` is relative to the `ContainerSelector`.

### Fields

Finally, the `Fields` property is a collection that defines the specific data items you want to extract. There are several different field classes, `TextField`

A `Field` has a name and selector. The name represents the data item. It is not used by the library except that, if you have configured the library to write headers to the resulting CSV file, this name will be the header of the corresponding column.

The selector is a string selector that identifies the element or elements (relative to `ItemSelector`) that contain the data to be extracted for this field.

There are four types of field classes:

#### TextField

This field type extracts the data from the text of the matching element or elements.

#### AttributeField

This field type extracts the data from the value of an attribute of the matching element or elements. This class has one additional property, `AttributeName`, which specifies the name of the attribute.

#### InnerHtmlField

This field type extracts the inner HTML of the matching element or elements.

#### OuterHtmlField

This field type extracts the outer HTML of the matching element or elements.

### DataSeparator

Since it is possible to have more than one element match the target selectors, multiple values will be concatenated together. Use the `DataSeparator` property to insert a delimiter between multiple values. This property is a comma by default.

## Selectors

Selectors are used identify elements in an HTML document. WebScraper selectors are very similar to CSS and jQuery selectors, with a couple of minor differences.

### Wildcard

The wildcard character matches all HTML elements in the range being searched.

`"*"` matches all HTML elmements in the range being searched.

### Tag Names

You can also specify the tag name to return all the tags with the given name.

`"p"` would match all the `<p>` tags in the range being searched. Tag names are not case-sensitive.

### "#", "." and ":"

These characters are shortcuts for ID, class and type attributes.

`"p#center-ad"` matches `<p id="center-ad">`.

`"a.align-right"` matches `<a href="#" class="align-right">`.

`"input:button"` matches `<input type="button">`.

### Square Brackets ([])

For greater control over attributes, you can use square brackets (`[]`). This is similar to specifying attributes in jQuery, but there are some differences. The first difference is that all the variations for finding a match at the start, middle or end are not supported by WebScraper. Instead, you can use the `:=` operator to specify that the value is a regular expression and the code will match if the attribute value matches that regular expression.

`"p[id=\"center-ad\"]"` matches `<p>` tags with the attribute `id="center-ad"`.

`"p[id=center-ad][class=align-right]"` matches any `<p>` tags that have both attributes `id="center-ad"` and `class="align-right"`.

Quotes within the square brackets are optional if the value contains no whitespace or most punctuation. For example, `"p[id=center-ad][class=align-right]"` is valid too.

`"a[href]"` matches all `<a>` tags that have an `href` attribute. The attribute value does not matter.

`"p[data-id:=\"abc-\\d+\"]"` matches any `<p>` tags that have the attribute `data-id` with the value that matches the regular expression `"abc-\d+"`. This example is not case-sensitive.

`"a[href:=\"^(http:\\/\\/|https:\\/\\/)?(www\\.)?blackbeltcoder.com\"]"` matches all `<a>` links that link to blackbeltcoder.com. This regular expression allows optional `http://` or `https://`, and `www.` prefix. This example is also not case-sensitive.

Note that there is one key difference when using square brackets. When using a pound (`#`), period (`.`) or colon (`:`) to specify an attribute value, it is considered a match if it matches any value within that attribute. For example, the selector `"div.right-align"` would match the attribute `class="main-content right-align"`. When using square brackets, it must match the entire value (although there are exceptions to this when using regular expressions).

### Multiple Selectors

There are several cases where you can specify multiple selectors.

`"a, div, p"` matches all `<a>`, `<div>` and `<p>` tags.

`"div span"` matches all `<span>` tags that are descendants of a `<div>` tag.

`div > span` matches all `<span>` tags that are a direct descendant of a `<div>` tag.

