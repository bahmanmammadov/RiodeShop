#pragma checksum "C:\Users\Lenovo\Desktop\HomeWork-WebUI\HomeWork-WebUI\Riode.WebUI\Views\Home\SubscribeConfirm.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0cb8041c2abc3d0a2e0493af129c3812f4c7700d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_SubscribeConfirm), @"mvc.1.0.view", @"/Views/Home/SubscribeConfirm.cshtml")]
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
#line 2 "C:\Users\Lenovo\Desktop\HomeWork-WebUI\HomeWork-WebUI\Riode.WebUI\Views\_ViewImports.cshtml"
using Riodetask.Model.Entity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Lenovo\Desktop\HomeWork-WebUI\HomeWork-WebUI\Riode.WebUI\Views\_ViewImports.cshtml"
using Riodetask.AppCode.NewFolder;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Lenovo\Desktop\HomeWork-WebUI\HomeWork-WebUI\Riode.WebUI\Views\_ViewImports.cshtml"
using Riodetask.Model.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Lenovo\Desktop\HomeWork-WebUI\HomeWork-WebUI\Riode.WebUI\Views\_ViewImports.cshtml"
using Resources;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Lenovo\Desktop\HomeWork-WebUI\HomeWork-WebUI\Riode.WebUI\Views\_ViewImports.cshtml"
using Riodetask.AppCode.Extension;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Lenovo\Desktop\HomeWork-WebUI\HomeWork-WebUI\Riode.WebUI\Views\_ViewImports.cshtml"
using Riodetask.Model.FormModel;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0cb8041c2abc3d0a2e0493af129c3812f4c7700d", @"/Views/Home/SubscribeConfirm.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"2582d09e97d7b9426f5fe54d6bf7c3862bb6f367", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_SubscribeConfirm : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\Lenovo\Desktop\HomeWork-WebUI\HomeWork-WebUI\Riode.WebUI\Views\Home\SubscribeConfirm.cshtml"
   
    var m = ViewBag.Message as Tuple<bool, string>;

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<nav class=""breadcrumb-nav"">
    <div class=""container"">
        <ul class=""breadcrumb"">
            <li><a href=""demo1.html""><i class=""d-icon-home""></i></a></li>
            <li>Contact Us</li>
        </ul>
    </div>
</nav>
<div class=""page-header"" style=""background-image: url(images/page-header/contact-us.jpg)"">
    <h1 class=""page-title font-weight-bold text-capitalize ls-l"">Contact Us</h1>
</div>

    <section class=""contact-section"">
        <div class=""container"">
            <div class=""row"">
                <div class=""col-8 offset-2"">
");
#nullable restore
#line 20 "C:\Users\Lenovo\Desktop\HomeWork-WebUI\HomeWork-WebUI\Riode.WebUI\Views\Home\SubscribeConfirm.cshtml"
                     if (m.Item1)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div alert alert-danger text-white>\r\n                        ");
#nullable restore
#line 23 "C:\Users\Lenovo\Desktop\HomeWork-WebUI\HomeWork-WebUI\Riode.WebUI\Views\Home\SubscribeConfirm.cshtml"
                   Write(m.Item1);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n");
#nullable restore
#line 25 "C:\Users\Lenovo\Desktop\HomeWork-WebUI\HomeWork-WebUI\Riode.WebUI\Views\Home\SubscribeConfirm.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div alert alert-success text-white>\r\n                         ");
#nullable restore
#line 29 "C:\Users\Lenovo\Desktop\HomeWork-WebUI\HomeWork-WebUI\Riode.WebUI\Views\Home\SubscribeConfirm.cshtml"
                    Write(m.Item2);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n");
#nullable restore
#line 31 "C:\Users\Lenovo\Desktop\HomeWork-WebUI\HomeWork-WebUI\Riode.WebUI\Views\Home\SubscribeConfirm.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                   \r\n                </div>\r\n            </div>\r\n        </div>\r\n    </section>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591