#pragma checksum "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\DetailsSingular.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f799bec5bfadf724f44c02dde2e0fcc3d5ebb771"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Transaction_DetailsSingular), @"mvc.1.0.view", @"/Views/Transaction/DetailsSingular.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f799bec5bfadf724f44c02dde2e0fcc3d5ebb771", @"/Views/Transaction/DetailsSingular.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4e103615ed7ecc7e249f60093399f767ba4d605b", @"/Views/_ViewImports.cshtml")]
    public class Views_Transaction_DetailsSingular : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<CommercialApp.Models.Transaction>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 4 "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\DetailsSingular.cshtml"
  
    ViewData["Title"] = "DetailsSingular";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<br />\r\n<!DOCTYPE html>\r\n\r\n<html>\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f799bec5bfadf724f44c02dde2e0fcc3d5ebb7713609", async() => {
                WriteLiteral("\r\n    <meta name=\"viewport\" content=\"width=device-width\" />\r\n    <title>Details</title>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "f799bec5bfadf724f44c02dde2e0fcc3d5ebb7714670", async() => {
                WriteLiteral(@"
    <div>
        <br><br>
        <h4 class=""text-center"">Shopping cart</h4>
        <br><br>
        <div class=""container"">
            <table class=""table"">
                <h5 class=""text-center"">Products</h5>
                <br>
                <thead>
                    <tr>
                        <th>
                            Product
                        </th>
                        <th>
                            Supplied By
                        </th>
                        <th>
                            Image
                        </th>
                        <th>
                            Description
                        </th>
                        <th>
                            Unit Price (without taxes)
                        </th>
                        <th>
                            Tax Rate %
                        </th>
                        <th></th>
                        <th></th>
                    </tr>
              ");
                WriteLiteral("  </thead>\r\n                <tbody>\r\n");
#nullable restore
#line 50 "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\DetailsSingular.cshtml"
                     if (Model.TransactionDetails.Count() == 0)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <p>There are no products in your cart yet</p>\r\n");
#nullable restore
#line 53 "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\DetailsSingular.cshtml"
                    }

#line default
#line hidden
#nullable disable
#nullable restore
#line 54 "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\DetailsSingular.cshtml"
                     foreach (CommercialApp.Models.TransactionDetail x in Model.TransactionDetails)
                    {


#line default
#line hidden
#nullable disable
                WriteLiteral("                        <tr>\r\n                            <td>\r\n                                ");
#nullable restore
#line 59 "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\DetailsSingular.cshtml"
                            Write(x.Product.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 62 "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\DetailsSingular.cshtml"
                            Write(x.Product.Company.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                <img");
                BeginWriteAttribute("src", " src=\"", 1960, "\"", 2031, 2);
                WriteAttributeValue("", 1966, "data:image;base64,", 1966, 18, true);
#nullable restore
#line 65 "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\DetailsSingular.cshtml"
WriteAttributeValue("", 1984, System.Convert.ToBase64String(x.Product.Image), 1984, 47, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" width=\"80\" height=\"80\" />\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 68 "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\DetailsSingular.cshtml"
                            Write(x.Product.Description);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 71 "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\DetailsSingular.cshtml"
                            Write(x.Product.UnitPrice);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </td>\r\n                            <td>\r\n                                ");
#nullable restore
#line 74 "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\DetailsSingular.cshtml"
                            Write(x.Product.TaxRate);

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </td>\r\n");
#nullable restore
#line 76 "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\DetailsSingular.cshtml"
                             if (Model.State == "Open")
                            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                <td>\r\n                                    ");
#nullable restore
#line 79 "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\DetailsSingular.cshtml"
                               Write(Html.ActionLink("-", "RemoveProduct", "Transaction", new { id = x.TransactionDetailId }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </td>\r\n                                <td>\r\n                                    ");
#nullable restore
#line 82 "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\DetailsSingular.cshtml"
                               Write(Html.ActionLink("+", "AddAnotherProduct", "Transaction", new { id = x.ProductId }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                                </td>\r\n");
#nullable restore
#line 84 "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\DetailsSingular.cshtml"
                            }

#line default
#line hidden
#nullable disable
                WriteLiteral("                        </tr>\r\n");
#nullable restore
#line 86 "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\DetailsSingular.cshtml"

                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </tbody>\r\n            </table>\r\n\r\n\r\n            <p>Quantity: ");
#nullable restore
#line 92 "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\DetailsSingular.cshtml"
                    Write(Model.TransactionDetails.Count());

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n            <p>Total (with taxes): ");
#nullable restore
#line 93 "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\DetailsSingular.cshtml"
                              Write(Html.DisplayFor(model => model.Total));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</p>
            <br><br>
            <h5 class=""text-center"">Delivery information</h5>
            <br>
            <table class=""table"">
                <thead>
                    <tr>
                        <th>
                            Name
                        </th>
                        <th>
                            ");
#nullable restore
#line 104 "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\DetailsSingular.cshtml"
                       Write(Html.DisplayNameFor(model => model.Singular.Email));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            Contact Number\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 110 "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\DetailsSingular.cshtml"
                       Write(Html.DisplayNameFor(model => model.Singular.Address));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </th>\r\n                        <th>\r\n                            Postal code\r\n                        </th>\r\n                        <th>\r\n                            ");
#nullable restore
#line 116 "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\DetailsSingular.cshtml"
                       Write(Html.DisplayNameFor(model => model.Singular.City));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </th>\r\n                    </tr>\r\n                </thead>\r\n                <tbody>\r\n                    <tr>\r\n                        <td>\r\n                            ");
#nullable restore
#line 123 "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\DetailsSingular.cshtml"
                       Write(Html.DisplayFor(model => model.Singular.Name));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 126 "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\DetailsSingular.cshtml"
                       Write(Html.DisplayFor(model => model.Singular.Email));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 129 "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\DetailsSingular.cshtml"
                       Write(Html.DisplayFor(model => model.Singular.PhoneNumber));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 132 "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\DetailsSingular.cshtml"
                       Write(Html.DisplayFor(model => model.Singular.Address));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 135 "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\DetailsSingular.cshtml"
                       Write(Html.DisplayFor(model => model.Singular.PostalCode));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n                        <td>\r\n                            ");
#nullable restore
#line 138 "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\DetailsSingular.cshtml"
                       Write(Html.DisplayFor(model => model.Singular.City));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                        </td>\r\n");
#nullable restore
#line 140 "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\DetailsSingular.cshtml"
                         if (Model.State == "Open")
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            <td>\r\n                                ");
#nullable restore
#line 143 "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\DetailsSingular.cshtml"
                           Write(Html.ActionLink("Edit", "Edit", "Singular", new { id = Model.Singular.PeopleId }));

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n                            </td>\r\n");
#nullable restore
#line 145 "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\DetailsSingular.cshtml"
                        }

#line default
#line hidden
#nullable disable
                WriteLiteral("                    </tr>\r\n                </tbody>\r\n            </table>\r\n            <br>\r\n            <div class=\"form-group\">\r\n");
#nullable restore
#line 151 "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\DetailsSingular.cshtml"
                 if (Model.State == "Open")
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <p class=\"btn btn-primary\">");
#nullable restore
#line 153 "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\DetailsSingular.cshtml"
                                          Write(Html.ActionLink("Confirm", "ChangeState", "Transaction", new { id = Model.TransactionId }));

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n                    <p class=\"btn btn-primary\">");
#nullable restore
#line 154 "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\DetailsSingular.cshtml"
                                          Write(Html.ActionLink("Delete this cart", "Delete", "Transaction", new { id = Model.TransactionId }));

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n");
#nullable restore
#line 155 "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\DetailsSingular.cshtml"
                }

#line default
#line hidden
#nullable disable
#nullable restore
#line 156 "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\DetailsSingular.cshtml"
                 if (Model.State == "Awaiting treatment")
                {

#line default
#line hidden
#nullable disable
                WriteLiteral("                    <p class=\"btn btn-success\" style=\"background-color: white;color :#0081CF \"> ");
#nullable restore
#line 158 "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\DetailsSingular.cshtml"
                                                                                           Write(Html.ActionLink("Confirm Reception", "ConfirmReception", new { id = Model.TransactionId }));

#line default
#line hidden
#nullable disable
                WriteLiteral("</p>\r\n");
#nullable restore
#line 159 "C:\Users\Ines\source\repos\CommercialApp\Views\Transaction\DetailsSingular.cshtml"
                }

#line default
#line hidden
#nullable disable
                WriteLiteral("            </div>\r\n        </div>\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</html>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<CommercialApp.Models.Transaction> Html { get; private set; }
    }
}
#pragma warning restore 1591