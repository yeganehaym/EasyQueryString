# EasyQueryString
a class by reflection to work with querystrings easily

![EasyQueryString](http://8pic.ir/images/kihc6qpnjm637ry8wvbz.png "EasyQueryString")


easyquerystring helps you establish a connection between your property names and query string names.you dont have to follow rule that query string field name must be same as class property name anymore

look at below code:

this is querystring: **current=1&rowCount=10&sort[sender]=asc&searchPhrase=keyword**

```C#
public class EmployeesRequestBody
{
    [RequestBodyField("current")]
    public  int CurrentPage { get; set; }
 
    [RequestBodyField("rowcount")]
    public int RowCount { get; set; }
 
    [RequestBodyField("searchPhrase")]
    public string SearchPhrase { get; set; }
 
    [RequestBodyField("sort")]
    public NameValueCollection SortDictionary { get; set; }
}
```

now write this code

```C#
public ActionResult yourMethod()
{
  EmployeesRequestBody data = Requests.GetFromQueryString<EmployeesRequestBody>();
  // EmployeesRequestBody data = Requests.GetFromQueryString<EmployeesRequestBody>(RequestType.POST);
  return View(data);
}

```
