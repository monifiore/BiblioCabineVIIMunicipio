#pragma checksum "C:\1_MONICA\ProjectGitHub\BiblioCabineVIIMunicipio\LegartiWeb\Pages\Suggerimento\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "79db8fcf52a6110405c4963db5cee4ff60f0b92e"
// <auto-generated/>
#pragma warning disable 1591
namespace LegartiWeb.Pages.Suggerimento
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "C:\1_MONICA\ProjectGitHub\BiblioCabineVIIMunicipio\LegartiWeb\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\1_MONICA\ProjectGitHub\BiblioCabineVIIMunicipio\LegartiWeb\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\1_MONICA\ProjectGitHub\BiblioCabineVIIMunicipio\LegartiWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\1_MONICA\ProjectGitHub\BiblioCabineVIIMunicipio\LegartiWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\1_MONICA\ProjectGitHub\BiblioCabineVIIMunicipio\LegartiWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\1_MONICA\ProjectGitHub\BiblioCabineVIIMunicipio\LegartiWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\1_MONICA\ProjectGitHub\BiblioCabineVIIMunicipio\LegartiWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\1_MONICA\ProjectGitHub\BiblioCabineVIIMunicipio\LegartiWeb\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\1_MONICA\ProjectGitHub\BiblioCabineVIIMunicipio\LegartiWeb\_Imports.razor"
using LegartiWeb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\1_MONICA\ProjectGitHub\BiblioCabineVIIMunicipio\LegartiWeb\_Imports.razor"
using LegartiWeb.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\1_MONICA\ProjectGitHub\BiblioCabineVIIMunicipio\LegartiWeb\_Imports.razor"
using MudBlazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\1_MONICA\ProjectGitHub\BiblioCabineVIIMunicipio\LegartiWeb\Pages\Suggerimento\Index.razor"
using LegArtiModel;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(MainLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/suggerimento/index")]
    public partial class Index : IndexBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "body-content-legarti");
            __builder.AddMarkupContent(2, "<div class=\"titolo\"><label id=\"lblTitolo\">Idee & Suggerimenti</label></div>\r\n    ");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "content-button-aggiungi");
            __builder.OpenElement(5, "button");
            __builder.AddAttribute(6, "type", "button");
            __builder.AddAttribute(7, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 12 "C:\1_MONICA\ProjectGitHub\BiblioCabineVIIMunicipio\LegartiWeb\Pages\Suggerimento\Index.razor"
                                          () => SuggerimentiPersonali()

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(8, "class", "button-aggiungi-suggerimento");
            __builder.AddContent(9, "I miei suggerimenti");
            __builder.CloseElement();
            __builder.CloseElement();
            __builder.AddMarkupContent(10, "\r\n\r\n\r\n    ");
            __builder.OpenElement(11, "div");
            __builder.AddAttribute(12, "class", "box-container-suggerimento");
#nullable restore
#line 17 "C:\1_MONICA\ProjectGitHub\BiblioCabineVIIMunicipio\LegartiWeb\Pages\Suggerimento\Index.razor"
         if (listaSuggerimenti != null)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\1_MONICA\ProjectGitHub\BiblioCabineVIIMunicipio\LegartiWeb\Pages\Suggerimento\Index.razor"
             if (listaSuggerimenti.Count > 0)
            {
                foreach (SuggerimentoModel single in listaSuggerimenti)
                {

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<MudBlazor.MudCard>(13);
            __builder.AddAttribute(14, "Class", "box results");
            __builder.AddAttribute(15, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<MudBlazor.MudItem>(16);
                __builder2.AddAttribute(17, "xs", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 24 "C:\1_MONICA\ProjectGitHub\BiblioCabineVIIMunicipio\LegartiWeb\Pages\Suggerimento\Index.razor"
                                     12

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(18, "sm", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 24 "C:\1_MONICA\ProjectGitHub\BiblioCabineVIIMunicipio\LegartiWeb\Pages\Suggerimento\Index.razor"
                                             12

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(19, "md", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 24 "C:\1_MONICA\ProjectGitHub\BiblioCabineVIIMunicipio\LegartiWeb\Pages\Suggerimento\Index.razor"
                                                     12

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(20, "Class", "box-left-suggerimento");
                __builder2.AddAttribute(21, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<MudBlazor.MudCardContent>(22);
                    __builder3.AddAttribute(23, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.OpenComponent<MudBlazor.MudText>(24);
                        __builder4.AddAttribute(25, "Typo", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Typo>(
#nullable restore
#line 26 "C:\1_MONICA\ProjectGitHub\BiblioCabineVIIMunicipio\LegartiWeb\Pages\Suggerimento\Index.razor"
                                               Typo.h5

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(26, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder5) => {
                            __builder5.OpenComponent<MudBlazor.MudAvatar>(27);
                            __builder5.AddAttribute(28, "Color", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Color>(
#nullable restore
#line 27 "C:\1_MONICA\ProjectGitHub\BiblioCabineVIIMunicipio\LegartiWeb\Pages\Suggerimento\Index.razor"
                                                      Color.Warning

#line default
#line hidden
#nullable disable
                            ));
                            __builder5.AddAttribute(29, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder6) => {
                                __builder6.AddMarkupContent(30, "<i class=\"fa fa-user fa-3x\" id=\"fa-icon-dettagliosuggerimento-grande\"></i>\r\n                                        <i class=\"fa fa-user\" id=\"fa-icon-dettagliosuggerimento-piccola\" style=\"display:none\"></i>");
                            }
                            ));
                            __builder5.CloseComponent();
                        }
                        ));
                        __builder4.CloseComponent();
                        __builder4.AddMarkupContent(31, "\r\n                                ");
                        __builder4.OpenComponent<MudBlazor.MudText>(32);
                        __builder4.AddAttribute(33, "Typo", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Typo>(
#nullable restore
#line 32 "C:\1_MONICA\ProjectGitHub\BiblioCabineVIIMunicipio\LegartiWeb\Pages\Suggerimento\Index.razor"
                                               Typo.body2

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(34, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder5) => {
#nullable restore
#line 33 "C:\1_MONICA\ProjectGitHub\BiblioCabineVIIMunicipio\LegartiWeb\Pages\Suggerimento\Index.razor"
__builder5.AddContent(35, single.NomeVisualizzato);

#line default
#line hidden
#nullable disable
                            __builder5.AddMarkupContent(36, " <br>");
                        }
                        ));
                        __builder4.CloseComponent();
                        __builder4.AddMarkupContent(37, "\r\n                                ");
                        __builder4.OpenComponent<MudBlazor.MudText>(38);
                        __builder4.AddAttribute(39, "Typo", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Typo>(
#nullable restore
#line 35 "C:\1_MONICA\ProjectGitHub\BiblioCabineVIIMunicipio\LegartiWeb\Pages\Suggerimento\Index.razor"
                                               Typo.body2

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(40, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder5) => {
#nullable restore
#line 36 "C:\1_MONICA\ProjectGitHub\BiblioCabineVIIMunicipio\LegartiWeb\Pages\Suggerimento\Index.razor"
__builder5.AddContent(41, single.DataInserimento.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
                        }
                        ));
                        __builder4.CloseComponent();
                    }
                    ));
                    __builder3.CloseComponent();
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(42, "\r\n                        ");
                __builder2.OpenComponent<MudBlazor.MudItem>(43);
                __builder2.AddAttribute(44, "xs", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 41 "C:\1_MONICA\ProjectGitHub\BiblioCabineVIIMunicipio\LegartiWeb\Pages\Suggerimento\Index.razor"
                                     6

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(45, "sm", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 41 "C:\1_MONICA\ProjectGitHub\BiblioCabineVIIMunicipio\LegartiWeb\Pages\Suggerimento\Index.razor"
                                            12

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(46, "md", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 41 "C:\1_MONICA\ProjectGitHub\BiblioCabineVIIMunicipio\LegartiWeb\Pages\Suggerimento\Index.razor"
                                                    6

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(47, "Class", "box-right-suggerimento");
                __builder2.AddAttribute(48, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<MudBlazor.MudText>(49);
                    __builder3.AddAttribute(50, "Typo", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Typo>(
#nullable restore
#line 42 "C:\1_MONICA\ProjectGitHub\BiblioCabineVIIMunicipio\LegartiWeb\Pages\Suggerimento\Index.razor"
                                           Typo.body1

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(51, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
#nullable restore
#line 43 "C:\1_MONICA\ProjectGitHub\BiblioCabineVIIMunicipio\LegartiWeb\Pages\Suggerimento\Index.razor"
__builder4.AddContent(52, single.Titolo);

#line default
#line hidden
#nullable disable
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(53, "\r\n                            ");
                    __builder3.OpenComponent<MudBlazor.MudText>(54);
                    __builder3.AddAttribute(55, "Typo", global::Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Typo>(
#nullable restore
#line 45 "C:\1_MONICA\ProjectGitHub\BiblioCabineVIIMunicipio\LegartiWeb\Pages\Suggerimento\Index.razor"
                                           Typo.body2

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(56, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
#nullable restore
#line 46 "C:\1_MONICA\ProjectGitHub\BiblioCabineVIIMunicipio\LegartiWeb\Pages\Suggerimento\Index.razor"
__builder4.AddContent(57, single.Testo);

#line default
#line hidden
#nullable disable
                    }
                    ));
                    __builder3.CloseComponent();
                }
                ));
                __builder2.CloseComponent();
            }
            ));
            __builder.CloseComponent();
#nullable restore
#line 50 "C:\1_MONICA\ProjectGitHub\BiblioCabineVIIMunicipio\LegartiWeb\Pages\Suggerimento\Index.razor"
                }
            }
            else
            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(58, "div");
            __builder.AddAttribute(59, "class", "div-center");
            __builder.OpenComponent<MudBlazor.MudInputLabel>(60);
            __builder.AddAttribute(61, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddContent(62, " Non ci sono suggerimenti da mostrare");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
#nullable restore
#line 57 "C:\1_MONICA\ProjectGitHub\BiblioCabineVIIMunicipio\LegartiWeb\Pages\Suggerimento\Index.razor"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 57 "C:\1_MONICA\ProjectGitHub\BiblioCabineVIIMunicipio\LegartiWeb\Pages\Suggerimento\Index.razor"
             
        }

#line default
#line hidden
#nullable disable
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
