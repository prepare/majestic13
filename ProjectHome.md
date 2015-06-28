A wrap around html parser (http://www.majestic12.co.uk/projects/html_parser.php) providing simpler API.

Works on .net framework and mono.

## About ##

### Example ###

How to extract links from the page.

![http://majestic13.googlecode.com/files/case_b.png](http://majestic13.googlecode.com/files/case_b.png)

### NuGet ###

Majestic13 is now available on [NuGet](http://nuget.org/).

http://nuget.org/List/Packages/Majestic13

### Classes ###

**HtmlParser** converts html from string to tree representation.

**HtmlNode** represents html using tree structure that supports visitor pattern.

**FindTagsVisitor** is a strategy that selects tags from document by predicate.