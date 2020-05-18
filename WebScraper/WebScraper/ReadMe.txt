Web Scraper is an application for extracting data from web pages.



URL Section
---------------------------
Use this section to specify the URL to be examined. While each Web Scraper file you create can only have one URL, you can have the software convert the URL into many URLs using placeholders.

For example, the {page} placeholder can be used to examine multiple pages. Example:

https://www.yellowpages.com/ut/plumbers?page={page}

If the {page} placeholder is specified in the URL and a Next page selector is specified under the Selectors section, the software will replace this placeholder with "1", and then repeat for "2", "3", "4", etc. until a page is examined that has no elements matching the Next page selector.

In addition, you can add your own placeholders. Example:

https://www.yellowpages.com/{location}/plumbers

In this case, you must define a URL placeholder for the {location} placeholder. You can specify any number of replacement values in a comma-delimited list. So if you created the following example placeholder:

location=salt-lake-city-ut, ogden-ut

The software will generate and examine two URLs:

https://www.yellowpages.com/salt-lake-city-ut/plumbers
https://www.yellowpages.com/ogden-ut/plumbers

You can add any number of placeholders and the software will generate a URL with all combinations of the values you provide. So if, for example, you added two placeholders and gave each placeholder three values, nine different URLs would be generated and examined.

Custom placeholder work in combination with the {page} placeholder, if included. Each URL with all combinations of the placeholder values will used with each page sequence.

Selectors Section
---------------------------
Use this section to specify the selectors that define how to find the data you want to extract from the pages. To improve both simplicity and efficiency, a hierarchy of selectors is used to find the parts of data that you want to extract.

The Container selector specifies how to find the elements that contain all of the item elements. It's okay if the Container selector returns multiple elements. In that case, each of the container elements will be searched to find item elements.

The Item selector specifies how to find the items within each container. This selector is relative to a container element. Each item element should contain a set of fields for a single item.

The Next page selector is used to define the element that is used to navigate to the next page. If the {page} placeholder was specified in the URL section, the software searches for the element that corresponds to the Next page selector. If the element is not found, the software assumes there are no more pages to examine.

Fields Section
---------------------------
This section is used to define the fields from which content should be extracted. You can define a field name and a corresponding selector. Each field selector is relative to an item element.

You can define any number of fields. When editing a field, you can specify the source of data from the matching element. The default source is Text. This specifies that the inner text of the matching element should be extracted. Another options is Attribute Value. When selecting this option, an attribute name must also be specified and the software will extract the value of this attribute. There are a few other options in addition to these most common ones.

In some cases, the field selector may match multiple elements within the same item element. Or, the matching element may have multiple children that have content. In these cases, the content from all matching elements will be extracted. If you want to insert a delimiter between the content, you can specify it in the Separator inserted between multiple field elements text box. The default value is a comma followed by a space.
