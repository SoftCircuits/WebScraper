// Copyright (c) 2020 Jonathan Wood (www.softcircuits.com)
// Licensed under the MIT license.
//

using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoftCircuits.WebScraper;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace WebScraper.Tests
{
    [TestClass]
    public class Tests
    {

    //    [TestMethod]
    //    public async Task TestYellowPagesAsync()
    //    {
    //        Scraper scraper = new Scraper
    //        {
    //            Url = "https://www.yellowpages.com/{location}/{category}?page={page}",
    //            ContainerSelector = @"div[id=""top-center-ads""][class=""search-results center-ads""],div[class=""search-results organic""],div[id=""bottom-center-ads""][class=""search-results center-ads""]",
    //            ItemSelector = @"div[id:=""lid-\d+""][class=""result""] div[class=""v-card""]",
    //            NextPageSelector = @"div.pagination a[class=""next ajax-page""]",
    //            DataSeparator = ",",
    //        };

    //        scraper.Placeholders.Add(new Placeholder("location", new[] { "salt-lake-city-ut", "ogden-ut", }));
    //        scraper.Placeholders.Add(new Placeholder("category", new[] { "lawn-mower-repair", "plumbers" }));
    //        scraper.Fields.Add(new TextField("Name", "a.business-name span"));
    //        scraper.Fields.Add(new TextField("Address", "p.adr"));
    //        scraper.Fields.Add(new TextField("Phone", "div.phones.phone.primary"));
    //        scraper.Fields.Add(new TextField("Category", "div.categories > a"));
    //        scraper.Fields.Add(new AttributeField("Website", "a.track-visit-website", "href"));

    //        scraper.UpdateProgress += Scraper_UpdateProgress;

    //        await scraper.RunAsync(@"D:\Users\Jonathan\Desktop\Scraper.csv");
    //    }

    //    private void Scraper_UpdateProgress(object sender, UpdateProgressEventArgs e)
    //    {
    //        Debug.WriteLine($"{e.Percent}% : {e.Status}");
    //    }

        [TestMethod]
        public void TestPlaceholderIterator()
        {
            PlaceholderIterator iterator;
            List<string> results;

            iterator = new PlaceholderIterator("http://www.example.com");
            Assert.AreEqual(1, iterator.GetTotalUrlCount());
            results = new List<string>();
            iterator.Reset(out string url);
            do
            {
                results.Add(url);
            } while (iterator.Next(out url));
            CollectionAssert.AreEqual(new[] {
                "http://www.example.com"
            }, results);

            iterator = new PlaceholderIterator("http://www.example.com?arg={arg}")
            {
                new PlaceholderIteratorItem(new Placeholder("arg", new[] { "one", "two", "three" })),
            };
            Assert.AreEqual(3, iterator.GetTotalUrlCount());
            results = new List<string>();
            iterator.Reset(out url);
            do
            {
                results.Add(url);
            } while (iterator.Next(out url));
            CollectionAssert.AreEqual(new[] {
                "http://www.example.com?arg=one",
                "http://www.example.com?arg=two",
                "http://www.example.com?arg=three",
            }, results);

            iterator = new PlaceholderIterator("http://www.example.com?arg1={arg1}&arg2={arg2}&arg3={arg3}")
            {
                new PlaceholderIteratorItem(new Placeholder("arg1", new[] { "one", "two", "three" })),
                new PlaceholderIteratorItem(new Placeholder("Arg2", new[] { "a", "b", "c" })),
                new PlaceholderIteratorItem(new Placeholder("ARG3", new[] { "red", "green", "blue" }))
            };
            Assert.AreEqual(27, iterator.GetTotalUrlCount());
            results = new List<string>();
            iterator.Reset(out url);
            do
            {
                results.Add(url);
            } while (iterator.Next(out url));
            CollectionAssert.AreEqual(new[] {
                "http://www.example.com?arg1=one&arg2=a&arg3=red",
                "http://www.example.com?arg1=one&arg2=a&arg3=green",
                "http://www.example.com?arg1=one&arg2=a&arg3=blue",
                "http://www.example.com?arg1=one&arg2=b&arg3=red",
                "http://www.example.com?arg1=one&arg2=b&arg3=green",
                "http://www.example.com?arg1=one&arg2=b&arg3=blue",
                "http://www.example.com?arg1=one&arg2=c&arg3=red",
                "http://www.example.com?arg1=one&arg2=c&arg3=green",
                "http://www.example.com?arg1=one&arg2=c&arg3=blue",
                "http://www.example.com?arg1=two&arg2=a&arg3=red",
                "http://www.example.com?arg1=two&arg2=a&arg3=green",
                "http://www.example.com?arg1=two&arg2=a&arg3=blue",
                "http://www.example.com?arg1=two&arg2=b&arg3=red",
                "http://www.example.com?arg1=two&arg2=b&arg3=green",
                "http://www.example.com?arg1=two&arg2=b&arg3=blue",
                "http://www.example.com?arg1=two&arg2=c&arg3=red",
                "http://www.example.com?arg1=two&arg2=c&arg3=green",
                "http://www.example.com?arg1=two&arg2=c&arg3=blue",
                "http://www.example.com?arg1=three&arg2=a&arg3=red",
                "http://www.example.com?arg1=three&arg2=a&arg3=green",
                "http://www.example.com?arg1=three&arg2=a&arg3=blue",
                "http://www.example.com?arg1=three&arg2=b&arg3=red",
                "http://www.example.com?arg1=three&arg2=b&arg3=green",
                "http://www.example.com?arg1=three&arg2=b&arg3=blue",
                "http://www.example.com?arg1=three&arg2=c&arg3=red",
                "http://www.example.com?arg1=three&arg2=c&arg3=green",
                "http://www.example.com?arg1=three&arg2=c&arg3=blue",
            }, results);
        }
    }
}
