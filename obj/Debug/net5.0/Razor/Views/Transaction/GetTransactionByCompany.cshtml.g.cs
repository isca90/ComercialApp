#pragma checksum "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\GetTransactionByCompany.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ed76a3ca56ecbc6cead5f74af2c3b2622807950a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Transaction_GetTransactionByCompany), @"mvc.1.0.view", @"/Views/Transaction/GetTransactionByCompany.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\Ines\source\repos\CommercialApp\Views\_ViewImports.cshtml"
using CommercialApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\Ines\source\repos\CommercialApp\Views\_ViewImports.cshtml"
using CommercialApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ed76a3ca56ecbc6cead5f74af2c3b2622807950a", @"/Views/Transaction/GetTransactionByCompany.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e103615ed7ecc7e249f60093399f767ba4d605b", @"/Views/_ViewImports.cshtml")]
    public class Views_Transaction_GetTransactionByCompany : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<CommercialApp.Models.Transaction>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\GetTransactionByCompany.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n\r\n<h1>Orders that have products I supply</h1>\r\n<br />\r\n<div class=\"text-danger\">\r\n    ");
#nullable restore
#line 11 "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\GetTransactionByCompany.cshtml"
Write(ViewBag.Error);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n");
#nullable restore
#line 13 "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\GetTransactionByCompany.cshtml"
 if (Model.Count() == 0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>There are still no sellings registered</p>\r\n");
#nullable restore
#line 16 "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\GetTransactionByCompany.cshtml"
}

#line default
#line hidden
#nullable disable
#nullable restore
#line 17 "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\GetTransactionByCompany.cshtml"
 foreach (CommercialApp.Models.Transaction item in Model)
{


#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <table class=""table"">
        <thead>
            <tr>
                <th>
                    Date
                </th>
                <th>
                    State
                </th>
                <th></th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <td>
                    ");
#nullable restore
#line 35 "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\GetTransactionByCompany.cshtml"
               Write(item.DateCreated);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 38 "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\GetTransactionByCompany.cshtml"
               Write(item.State);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 41 "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\GetTransactionByCompany.cshtml"
               Write(Html.ActionLink("Details", "DetailsCompany", new { id = item.TransactionId }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n\r\n        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 47 "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\GetTransactionByCompany.cshtml"

}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<CommercialApp.Models.Transaction>> Html { get; private set; }
    }
}
#pragma warning restore 1591
