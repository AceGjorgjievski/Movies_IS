#pragma checksum "C:\Users\Ace\Desktop\Movies\Movies.Web\Views\Order\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d9fb2a3fc2ef8675e3dc3de7c3dcbc2e64946716"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Order_Index), @"mvc.1.0.view", @"/Views/Order/Index.cshtml")]
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
#line 1 "C:\Users\Ace\Desktop\Movies\Movies.Web\Views\_ViewImports.cshtml"
using Movies.Web;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d9fb2a3fc2ef8675e3dc3de7c3dcbc2e64946716", @"/Views/Order/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"16f12866947247235a52ba4f9d080180ffcf5c5a", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Order_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Domain.DTO.TicketInOrderDto>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "C:\Users\Ace\Desktop\Movies\Movies.Web\Views\Order\Index.cshtml"
  
    ViewBag.Title = "Tickets";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>All Orders</h2>\r\n\r\n");
#nullable restore
#line 11 "C:\Users\Ace\Desktop\Movies\Movies.Web\Views\Order\Index.cshtml"
 if (Model == null)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <h2>No tickets available.</h2>\r\n");
#nullable restore
#line 14 "C:\Users\Ace\Desktop\Movies\Movies.Web\Views\Order\Index.cshtml"
}
else
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <table class=""table"">
        <thead class=""thead-dark"">
        <tr>
            <th class=""col-md-1"">#</th>
            <th class=""col"">Username</th>
            <th class=""col"">Quantity</th>
        </tr>
        </thead>
        <tbody>
            var ticketInOrder = Model[i];
            <tr>
                <td></td>
                <td>");
#nullable restore
#line 29 "C:\Users\Ace\Desktop\Movies\Movies.Web\Views\Order\Index.cshtml"
               Write(Model.Username);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                <td>");
#nullable restore
#line 30 "C:\Users\Ace\Desktop\Movies\Movies.Web\Views\Order\Index.cshtml"
               Write(Model.Quantity);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n            </tr>\r\n        </tbody>\r\n    </table>\r\n");
#nullable restore
#line 34 "C:\Users\Ace\Desktop\Movies\Movies.Web\Views\Order\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Domain.DTO.TicketInOrderDto> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591
