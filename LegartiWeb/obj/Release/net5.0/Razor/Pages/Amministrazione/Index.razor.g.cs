#pragma checksum "C:\1_MONICA\ProgettiMiei\Legarti\Legarti\Progetto\LegartiWeb\Pages\Amministrazione\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "04babb20caae9920112b3766581ab02af6a847c4"
// <auto-generated/>
#pragma warning disable 1591
namespace LegartiWeb.Pages.Amministrazione
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\1_MONICA\ProgettiMiei\Legarti\Legarti\Progetto\LegartiWeb\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\1_MONICA\ProgettiMiei\Legarti\Legarti\Progetto\LegartiWeb\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\1_MONICA\ProgettiMiei\Legarti\Legarti\Progetto\LegartiWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\1_MONICA\ProgettiMiei\Legarti\Legarti\Progetto\LegartiWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\1_MONICA\ProgettiMiei\Legarti\Legarti\Progetto\LegartiWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\1_MONICA\ProgettiMiei\Legarti\Legarti\Progetto\LegartiWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\1_MONICA\ProgettiMiei\Legarti\Legarti\Progetto\LegartiWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\1_MONICA\ProgettiMiei\Legarti\Legarti\Progetto\LegartiWeb\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\1_MONICA\ProgettiMiei\Legarti\Legarti\Progetto\LegartiWeb\_Imports.razor"
using LegartiWeb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\1_MONICA\ProgettiMiei\Legarti\Legarti\Progetto\LegartiWeb\_Imports.razor"
using LegartiWeb.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\1_MONICA\ProgettiMiei\Legarti\Legarti\Progetto\LegartiWeb\_Imports.razor"
using MudBlazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\1_MONICA\ProgettiMiei\Legarti\Legarti\Progetto\LegartiWeb\Pages\Amministrazione\Index.razor"
using LegArtiModel;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(MainLayoutAdminWithoutMenu))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/amministrazione/index")]
    public partial class Index : IndexBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<div class=\"titolo\"><label id=\"lblTitolo\">LOGIN</label></div>\r\n\r\n\r\n");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(1);
            __builder.AddAttribute(2, "OnValidSubmit", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 12 "C:\1_MONICA\ProgettiMiei\Legarti\Legarti\Progetto\LegartiWeb\Pages\Amministrazione\Index.razor"
                         Login

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(3, "Model", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 12 "C:\1_MONICA\ProgettiMiei\Legarti\Legarti\Progetto\LegartiWeb\Pages\Amministrazione\Index.razor"
                                        loginModel

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(4, "id", "login-body");
            __builder.AddAttribute(5, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenComponent<Microsoft.AspNetCore.Components.Forms.DataAnnotationsValidator>(6);
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(7, "\r\n    ");
                __builder2.OpenElement(8, "div");
                __builder2.AddAttribute(9, "class", "box-login-admin");
                __builder2.OpenElement(10, "div");
                __builder2.AddAttribute(11, "class", "centered-div-admin");
                __builder2.OpenElement(12, "div");
                __builder2.AddAttribute(13, "id", "#box-login-admin");
                __builder2.AddAttribute(14, "class", "box-login-full-admin");
                __builder2.OpenElement(15, "div");
                __builder2.AddAttribute(16, "class", "input-group form-floating mb-3  col-md-12");
                __Blazor.LegartiWeb.Pages.Amministrazione.Index.TypeInference.CreateMudTextField_0(__builder2, 17, 18, "Email", 19, 
#nullable restore
#line 19 "C:\1_MONICA\ProgettiMiei\Legarti\Legarti\Progetto\LegartiWeb\Pages\Amministrazione\Index.razor"
                                                                                         Variant.Outlined

#line default
#line hidden
#nullable disable
                , 20, 
#nullable restore
#line 19 "C:\1_MONICA\ProgettiMiei\Legarti\Legarti\Progetto\LegartiWeb\Pages\Amministrazione\Index.razor"
                                                                                                                      Adornment.End

#line default
#line hidden
#nullable disable
                , 21, 
#nullable restore
#line 19 "C:\1_MONICA\ProgettiMiei\Legarti\Legarti\Progetto\LegartiWeb\Pages\Amministrazione\Index.razor"
                                                                                                                                                     Icons.Material.Filled.Email

#line default
#line hidden
#nullable disable
                , 22, 
#nullable restore
#line 19 "C:\1_MONICA\ProgettiMiei\Legarti\Legarti\Progetto\LegartiWeb\Pages\Amministrazione\Index.razor"
                                                loginModel.Email

#line default
#line hidden
#nullable disable
                , 23, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => loginModel.Email = __value, loginModel.Email)));
                __builder2.CloseElement();
                __builder2.AddMarkupContent(24, "\r\n                ");
                __builder2.OpenElement(25, "div");
                __builder2.AddAttribute(26, "class", "login-message-label col-md-12");
                __Blazor.LegartiWeb.Pages.Amministrazione.Index.TypeInference.CreateValidationMessage_1(__builder2, 27, 28, 
#nullable restore
#line 22 "C:\1_MONICA\ProgettiMiei\Legarti\Legarti\Progetto\LegartiWeb\Pages\Amministrazione\Index.razor"
                                              () => loginModel.Email

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(29, "\r\n                ");
                __builder2.OpenElement(30, "div");
                __builder2.AddAttribute(31, "class", "input-group form-floating mb-3 col-md-12");
                __builder2.AddAttribute(32, "id", "input-password");
                __Blazor.LegartiWeb.Pages.Amministrazione.Index.TypeInference.CreateMudTextField_2(__builder2, 33, 34, "Password", 35, 
#nullable restore
#line 25 "C:\1_MONICA\ProgettiMiei\Legarti\Legarti\Progetto\LegartiWeb\Pages\Amministrazione\Index.razor"
                                                                                               Variant.Outlined

#line default
#line hidden
#nullable disable
                , 36, 
#nullable restore
#line 25 "C:\1_MONICA\ProgettiMiei\Legarti\Legarti\Progetto\LegartiWeb\Pages\Amministrazione\Index.razor"
                                                                                                                             PasswordInput

#line default
#line hidden
#nullable disable
                , 37, 
#nullable restore
#line 25 "C:\1_MONICA\ProgettiMiei\Legarti\Legarti\Progetto\LegartiWeb\Pages\Amministrazione\Index.razor"
                                                                                                                                                       Adornment.End

#line default
#line hidden
#nullable disable
                , 38, 
#nullable restore
#line 25 "C:\1_MONICA\ProgettiMiei\Legarti\Legarti\Progetto\LegartiWeb\Pages\Amministrazione\Index.razor"
                                                                                                                                                                                      PasswordInputIcon

#line default
#line hidden
#nullable disable
                , 39, Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 25 "C:\1_MONICA\ProgettiMiei\Legarti\Legarti\Progetto\LegartiWeb\Pages\Amministrazione\Index.razor"
                                                                                                                                                                                                                           ViewHiddenPassword

#line default
#line hidden
#nullable disable
                ), 40, 
#nullable restore
#line 25 "C:\1_MONICA\ProgettiMiei\Legarti\Legarti\Progetto\LegartiWeb\Pages\Amministrazione\Index.razor"
                                                loginModel.Password

#line default
#line hidden
#nullable disable
                , 41, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => loginModel.Password = __value, loginModel.Password)));
                __builder2.CloseElement();
                __builder2.AddMarkupContent(42, "\r\n                ");
                __builder2.OpenElement(43, "div");
                __builder2.AddAttribute(44, "class", "login-message-label  col-md-12");
                __Blazor.LegartiWeb.Pages.Amministrazione.Index.TypeInference.CreateValidationMessage_3(__builder2, 45, 46, 
#nullable restore
#line 28 "C:\1_MONICA\ProgettiMiei\Legarti\Legarti\Progetto\LegartiWeb\Pages\Amministrazione\Index.razor"
                                              () => loginModel.Password

#line default
#line hidden
#nullable disable
                );
                __builder2.CloseElement();
                __builder2.AddMarkupContent(47, "\r\n                <div class=\"error-credential\"></div>\r\n                ");
                __builder2.AddMarkupContent(48, "<div class=\"content-button-login\"><button type=\"submit\" class=\"button-login\">Login</button></div>");
                __builder2.CloseElement();
                __builder2.CloseElement();
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
    }
}
namespace __Blazor.LegartiWeb.Pages.Amministrazione.Index
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateMudTextField_0<T>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.String __arg0, int __seq1, global::MudBlazor.Variant __arg1, int __seq2, global::MudBlazor.Adornment __arg2, int __seq3, global::System.String __arg3, int __seq4, T __arg4, int __seq5, global::Microsoft.AspNetCore.Components.EventCallback<T> __arg5)
        {
        __builder.OpenComponent<global::MudBlazor.MudTextField<T>>(seq);
        __builder.AddAttribute(__seq0, "Label", __arg0);
        __builder.AddAttribute(__seq1, "Variant", __arg1);
        __builder.AddAttribute(__seq2, "Adornment", __arg2);
        __builder.AddAttribute(__seq3, "AdornmentIcon", __arg3);
        __builder.AddAttribute(__seq4, "Value", __arg4);
        __builder.AddAttribute(__seq5, "ValueChanged", __arg5);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_1<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
        public static void CreateMudTextField_2<T>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.String __arg0, int __seq1, global::MudBlazor.Variant __arg1, int __seq2, global::MudBlazor.InputType __arg2, int __seq3, global::MudBlazor.Adornment __arg3, int __seq4, global::System.String __arg4, int __seq5, global::Microsoft.AspNetCore.Components.EventCallback<global::Microsoft.AspNetCore.Components.Web.MouseEventArgs> __arg5, int __seq6, T __arg6, int __seq7, global::Microsoft.AspNetCore.Components.EventCallback<T> __arg7)
        {
        __builder.OpenComponent<global::MudBlazor.MudTextField<T>>(seq);
        __builder.AddAttribute(__seq0, "Label", __arg0);
        __builder.AddAttribute(__seq1, "Variant", __arg1);
        __builder.AddAttribute(__seq2, "InputType", __arg2);
        __builder.AddAttribute(__seq3, "Adornment", __arg3);
        __builder.AddAttribute(__seq4, "AdornmentIcon", __arg4);
        __builder.AddAttribute(__seq5, "OnAdornmentClick", __arg5);
        __builder.AddAttribute(__seq6, "Value", __arg6);
        __builder.AddAttribute(__seq7, "ValueChanged", __arg7);
        __builder.CloseComponent();
        }
        public static void CreateValidationMessage_3<TValue>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<TValue>> __arg0)
        {
        __builder.OpenComponent<global::Microsoft.AspNetCore.Components.Forms.ValidationMessage<TValue>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
