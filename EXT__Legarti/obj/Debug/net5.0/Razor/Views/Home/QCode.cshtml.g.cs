#pragma checksum "C:\1_Monica\ProgettiMiei\Miei\Legarti\Progetto\EXT__Legarti\Views\Home\QCode.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9cfdb70fa782f3d9a8e5481a1f4d9e5a3daf737c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_QCode), @"mvc.1.0.view", @"/Views/Home/QCode.cshtml")]
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
#line 1 "C:\1_Monica\ProgettiMiei\Miei\Legarti\Progetto\EXT__Legarti\Views\_ViewImports.cshtml"
using EXT__Legarti;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\1_Monica\ProgettiMiei\Miei\Legarti\Progetto\EXT__Legarti\Views\_ViewImports.cshtml"
using EXT__Legarti.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9cfdb70fa782f3d9a8e5481a1f4d9e5a3daf737c", @"/Views/Home/QCode.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e875ab0aab8058351336e1cd3e1aa2c23ca7c8ce", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_QCode : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Byte[]>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "C:\1_Monica\ProgettiMiei\Miei\Legarti\Progetto\EXT__Legarti\Views\Home\QCode.cshtml"
  
    ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9cfdb70fa782f3d9a8e5481a1f4d9e5a3daf737c4087", async() => {
                WriteLiteral(@"
    <div class=""container"">
        <div class=""panel-group"">
            <div class=""panel panel-info"">
                <div class=""panel-heading"">Generate QR Code</div>
                <div class=""panel-body"">
                    <div class=""row"">
                        <div class=""col-md-12"">
                            <div class=""col-md-3"">Type text to generate QR Code</div>
                            <div class=""col-md-9""><input type=""text"" class=""form-control"" id=""txtQRCode"" name=""txtQRCode"" /></div>
                        </div>
                    </div>
                    <div class=""row mt-3"">
                        <div class=""col-md-12"">
                            <div class=""col-md-3""></div>
                            <div class=""col-md-9"">
                                <input type=""submit"" class=""btn btn-primary"" id=""btnSubmit"" value=""Generate QR Code"" autocomplete=""off"" />
                            </div>
                        </div>
                    </div>
                WriteLiteral("\n");
#nullable restore
#line 27 "C:\1_Monica\ProgettiMiei\Miei\Legarti\Progetto\EXT__Legarti\Views\Home\QCode.cshtml"
                      
                        if (Model != null)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                            <div class=""row mt-3"">
                                <div class=""col-md-12"">
                                    <div class=""col-md-3""></div>
                                    <div class=""col-md-9"">
                                        <img");
                BeginWriteAttribute("src", " src=\"", 1585, "\"", 1665, 1);
#nullable restore
#line 34 "C:\1_Monica\ProgettiMiei\Miei\Legarti\Progetto\EXT__Legarti\Views\Home\QCode.cshtml"
WriteAttributeValue("", 1591, String.Format("data:image/png;base64,{0}", Convert.ToBase64String(Model)), 1591, 74, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" height=\"300\" width=\"300\" />\r\n                                    </div>\r\n                                </div>\r\n                            </div>\r\n");
#nullable restore
#line 38 "C:\1_Monica\ProgettiMiei\Miei\Legarti\Progetto\EXT__Legarti\Views\Home\QCode.cshtml"
                        }
                    

#line default
#line hidden
#nullable disable
                WriteLiteral("                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
#nullable restore
#line 7 "C:\1_Monica\ProgettiMiei\Miei\Legarti\Progetto\EXT__Legarti\Views\Home\QCode.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Antiforgery = true;

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-antiforgery", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Antiforgery, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("  ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Byte[]> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591