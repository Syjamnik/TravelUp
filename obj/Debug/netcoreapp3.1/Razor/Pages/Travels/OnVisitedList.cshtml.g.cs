#pragma checksum "C:\Users\Klakier\Desktop\GIT PROJECTS\GIT PROJECT travelUP\Pages\Travels\OnVisitedList.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7fe4d49c7716b0f9af846248a793cd56087bb1ba"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(TravelUp.Pages.Travels.Pages_Travels_OnVisitedList), @"mvc.1.0.razor-page", @"/Pages/Travels/OnVisitedList.cshtml")]
namespace TravelUp.Pages.Travels
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
#line 1 "C:\Users\Klakier\Desktop\GIT PROJECTS\GIT PROJECT travelUP\Pages\_ViewImports.cshtml"
using TravelUp;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7fe4d49c7716b0f9af846248a793cd56087bb1ba", @"/Pages/Travels/OnVisitedList.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3e021a4bb6ab7bf4dcf06a7db32752e301174bbc", @"/Pages/_ViewImports.cshtml")]
    public class Pages_Travels_OnVisitedList : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("<h1>My visited places:</h1>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 12 "C:\Users\Klakier\Desktop\GIT PROJECTS\GIT PROJECT travelUP\Pages\Travels\OnVisitedList.cshtml"
           Write(Html.DisplayNameFor(model => model.OnVisitedList[0].Travel.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 15 "C:\Users\Klakier\Desktop\GIT PROJECTS\GIT PROJECT travelUP\Pages\Travels\OnVisitedList.cshtml"
           Write(Html.DisplayNameFor(model => model.OnVisitedList[0].Travel.Author.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 18 "C:\Users\Klakier\Desktop\GIT PROJECTS\GIT PROJECT travelUP\Pages\Travels\OnVisitedList.cshtml"
           Write(Html.DisplayNameFor(model => model.OnVisitedList[0].Travel.Header));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n\r\n    <tbody>\r\n");
#nullable restore
#line 24 "C:\Users\Klakier\Desktop\GIT PROJECTS\GIT PROJECT travelUP\Pages\Travels\OnVisitedList.cshtml"
         foreach (var item in Model.OnVisitedList)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 28 "C:\Users\Klakier\Desktop\GIT PROJECTS\GIT PROJECT travelUP\Pages\Travels\OnVisitedList.cshtml"
               Write(Html.DisplayFor(modelItem => item.Travel.Id));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 31 "C:\Users\Klakier\Desktop\GIT PROJECTS\GIT PROJECT travelUP\Pages\Travels\OnVisitedList.cshtml"
               Write(Html.DisplayFor(modelItem => item.Travel.Author.UserName));

#line default
#line hidden
#nullable disable
            WriteLiteral(";\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 34 "C:\Users\Klakier\Desktop\GIT PROJECTS\GIT PROJECT travelUP\Pages\Travels\OnVisitedList.cshtml"
               Write(Html.DisplayFor(modelItem => item.Travel.Header));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 37 "C:\Users\Klakier\Desktop\GIT PROJECTS\GIT PROJECT travelUP\Pages\Travels\OnVisitedList.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<TravelUp.Pages.Travels.OnVisitedListModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TravelUp.Pages.Travels.OnVisitedListModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<TravelUp.Pages.Travels.OnVisitedListModel>)PageContext?.ViewData;
        public TravelUp.Pages.Travels.OnVisitedListModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591