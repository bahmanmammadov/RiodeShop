#pragma checksum "C:\Users\Lenovo\Desktop\HomeWork-WebUI\HomeWork-WebUI\Riode.WebUI\Areas\Admin\Views\Faqs\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dd589a5d7b02e1845ef3a112b478533a092d47fa"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_Faqs_Index), @"mvc.1.0.view", @"/Areas/Admin/Views/Faqs/Index.cshtml")]
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
#line 2 "C:\Users\Lenovo\Desktop\HomeWork-WebUI\HomeWork-WebUI\Riode.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Riodetask.Model.Entity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\Lenovo\Desktop\HomeWork-WebUI\HomeWork-WebUI\Riode.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Riodetask.AppCode.NewFolder;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\Lenovo\Desktop\HomeWork-WebUI\HomeWork-WebUI\Riode.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Riodetask.Model.ViewModels;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\Lenovo\Desktop\HomeWork-WebUI\HomeWork-WebUI\Riode.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using System.Text.RegularExpressions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\Lenovo\Desktop\HomeWork-WebUI\HomeWork-WebUI\Riode.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Riodetask.AppCode.Extension;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\Lenovo\Desktop\HomeWork-WebUI\HomeWork-WebUI\Riode.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Riodetask.Model.FormModel;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\Lenovo\Desktop\HomeWork-WebUI\HomeWork-WebUI\Riode.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Riodetask.AppCode.Application.BrandsModule;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\Lenovo\Desktop\HomeWork-WebUI\HomeWork-WebUI\Riode.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Resources;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\Lenovo\Desktop\HomeWork-WebUI\HomeWork-WebUI\Riode.WebUI\Areas\Admin\Views\_ViewImports.cshtml"
using Riodetask.AppCode.Application.FaqsModule;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dd589a5d7b02e1845ef3a112b478533a092d47fa", @"/Areas/Admin/Views/Faqs/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"10f46df7c02f8e341bae1de2b26d5496c249a367", @"/Areas/Admin/Views/_ViewImports.cshtml")]
    public class Areas_Admin_Views_Faqs_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Riodetask.Model.Entity.Faq>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/libs/toastr.js/toastr.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/libs/sweetalert/sweetalert.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/libs/toastr.js/toastr.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\Lenovo\Desktop\HomeWork-WebUI\HomeWork-WebUI\Riode.WebUI\Areas\Admin\Views\Faqs\Index.cshtml"
  
    ViewData["Title"] = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>Index</h1>\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dd589a5d7b02e1845ef3a112b478533a092d47fa7601", async() => {
                WriteLiteral("Create New");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n                ");
#nullable restore
#line 16 "C:\Users\Lenovo\Desktop\HomeWork-WebUI\HomeWork-WebUI\Riode.WebUI\Areas\Admin\Views\Faqs\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Question));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 19 "C:\Users\Lenovo\Desktop\HomeWork-WebUI\HomeWork-WebUI\Riode.WebUI\Areas\Admin\Views\Faqs\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Answer));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 22 "C:\Users\Lenovo\Desktop\HomeWork-WebUI\HomeWork-WebUI\Riode.WebUI\Areas\Admin\Views\Faqs\Index.cshtml"
           Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n\r\n            <th></th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 29 "C:\Users\Lenovo\Desktop\HomeWork-WebUI\HomeWork-WebUI\Riode.WebUI\Areas\Admin\Views\Faqs\Index.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    ");
#nullable restore
#line 33 "C:\Users\Lenovo\Desktop\HomeWork-WebUI\HomeWork-WebUI\Riode.WebUI\Areas\Admin\Views\Faqs\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Question));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 36 "C:\Users\Lenovo\Desktop\HomeWork-WebUI\HomeWork-WebUI\Riode.WebUI\Areas\Admin\Views\Faqs\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Answer));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 39 "C:\Users\Lenovo\Desktop\HomeWork-WebUI\HomeWork-WebUI\Riode.WebUI\Areas\Admin\Views\Faqs\Index.cshtml"
               Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n\r\n                <td>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dd589a5d7b02e1845ef3a112b478533a092d47fa11307", async() => {
                WriteLiteral("Edit");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 43 "C:\Users\Lenovo\Desktop\HomeWork-WebUI\HomeWork-WebUI\Riode.WebUI\Areas\Admin\Views\Faqs\Index.cshtml"
                                           WriteLiteral(item.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dd589a5d7b02e1845ef3a112b478533a092d47fa13503", async() => {
                WriteLiteral("Details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 44 "C:\Users\Lenovo\Desktop\HomeWork-WebUI\HomeWork-WebUI\Riode.WebUI\Areas\Admin\Views\Faqs\Index.cshtml"
                                              WriteLiteral(item.ID);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(" |\r\n                    <a");
            BeginWriteAttribute("onclick", " onclick=\"", 1176, "\"", 1221, 6);
            WriteAttributeValue("", 1186, "remove(", 1186, 7, true);
#nullable restore
#line 45 "C:\Users\Lenovo\Desktop\HomeWork-WebUI\HomeWork-WebUI\Riode.WebUI\Areas\Admin\Views\Faqs\Index.cshtml"
WriteAttributeValue("", 1193, item.ID, 1193, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue(" ", 1201, ",", 1202, 2, true);
            WriteAttributeValue(" ", 1203, "\'", 1204, 2, true);
#nullable restore
#line 45 "C:\Users\Lenovo\Desktop\HomeWork-WebUI\HomeWork-WebUI\Riode.WebUI\Areas\Admin\Views\Faqs\Index.cshtml"
WriteAttributeValue("", 1205, item.Question, 1205, 14, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1219, "\')", 1219, 2, true);
            EndWriteAttribute();
            WriteLiteral(">Delete</a>\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 48 "C:\Users\Lenovo\Desktop\HomeWork-WebUI\HomeWork-WebUI\Riode.WebUI\Areas\Admin\Views\Faqs\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n");
            DefineSection("addcss", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "dd589a5d7b02e1845ef3a112b478533a092d47fa17018", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            DefineSection("addjs", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dd589a5d7b02e1845ef3a112b478533a092d47fa18316", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dd589a5d7b02e1845ef3a112b478533a092d47fa19416", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"
    <script>

        function remove(id, name) {

            swal({
                title: ""Eminsiniz?"",
                text: `Testik etdiyiniz teqdirde  '${name}' sistemden  silinecek!`,
                type: ""warning"",
                showCancelButton: true,
                confirmButtonClass: ""btn-danger"",
                buttons: [""No"", ""Yes""]
            }).then(
                function (isConfirm) {
                    if (isConfirm) {


                        $.ajax({
                            url: '");
#nullable restore
#line 74 "C:\Users\Lenovo\Desktop\HomeWork-WebUI\HomeWork-WebUI\Riode.WebUI\Areas\Admin\Views\Faqs\Index.cshtml"
                             Write(Url.Action("Delete"));

#line default
#line hidden
#nullable disable
                WriteLiteral(@"',
                            type: 'POST',
                            data: { id },
                            contentType: 'application/x-www-form-urlencoded', // ne tip  gedecek?   2side model binding rolnu oynayir datani back gondermek ucun isdifade edilir  yeni back gonderilmeye xirmet edilir
                            dataType: 'json',
                    beforeSend: function () {
                        console.log(""sorgudan evvel"")   // loadir acmaq

                    },
                    success: function (response) {   // sorgunun neticesi ugurlu olsa
                        console.log(response)

                        if (response.error == false) {

                            toastr.success(response.Message, ""Ugurludur"");
                            window.location.reload();

                        } else {
                            toastr.error(response.Message, ""xeta"");

                        }
                    },
                            error: functio");
                WriteLiteral(@"n (response) {   // sorgunun neticesi ugursuz olsa
                                console.log(response)
                    },


                }).always(function () {
                         console.log(""sorgudan sonra"")  //loadir baglamaq

                });

                    }
                });
        };
    </script>
");
            }
            );
            WriteLiteral("  ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Riodetask.Model.Entity.Faq>> Html { get; private set; }
    }
}
#pragma warning restore 1591
