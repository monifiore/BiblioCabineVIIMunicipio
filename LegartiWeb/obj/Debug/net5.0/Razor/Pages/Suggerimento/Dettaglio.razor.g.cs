#pragma checksum "C:\Users\ambra.zecchin\Desktop\Legarti\LegartiWeb\Pages\Suggerimento\Dettaglio.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b6bdc39477f89ca18acdb2b8e2ce46b859721ef5"
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
#line 1 "C:\Users\ambra.zecchin\Desktop\Legarti\LegartiWeb\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ambra.zecchin\Desktop\Legarti\LegartiWeb\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\ambra.zecchin\Desktop\Legarti\LegartiWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\ambra.zecchin\Desktop\Legarti\LegartiWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\ambra.zecchin\Desktop\Legarti\LegartiWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\ambra.zecchin\Desktop\Legarti\LegartiWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\ambra.zecchin\Desktop\Legarti\LegartiWeb\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\ambra.zecchin\Desktop\Legarti\LegartiWeb\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\ambra.zecchin\Desktop\Legarti\LegartiWeb\_Imports.razor"
using LegartiWeb;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\ambra.zecchin\Desktop\Legarti\LegartiWeb\_Imports.razor"
using LegartiWeb.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\ambra.zecchin\Desktop\Legarti\LegartiWeb\_Imports.razor"
using MudBlazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\ambra.zecchin\Desktop\Legarti\LegartiWeb\Pages\Suggerimento\Dettaglio.razor"
using LegArtiModel;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(MainLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/suggerimento/dettaglio")]
    public partial class Dettaglio : DettaglioBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "class", "body-content-legarti");
            __builder.AddMarkupContent(2, "<div class=\"titolo\"><label id=\"lblTitolo\">I miei suggerimenti</label></div>\r\n\r\n\r\n    ");
            __builder.OpenElement(3, "div");
            __builder.AddAttribute(4, "class", "content-button-aggiungi");
            __builder.OpenComponent<MudBlazor.MudItem>(5);
            __builder.AddAttribute(6, "xs", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 14 "C:\Users\ambra.zecchin\Desktop\Legarti\LegartiWeb\Pages\Suggerimento\Dettaglio.razor"
                     4

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(7, "sm", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 14 "C:\Users\ambra.zecchin\Desktop\Legarti\LegartiWeb\Pages\Suggerimento\Dettaglio.razor"
                            12

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(8, "md", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 14 "C:\Users\ambra.zecchin\Desktop\Legarti\LegartiWeb\Pages\Suggerimento\Dettaglio.razor"
                                    6

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(9, "Class", "box-left-suggerimento");
            __builder.AddAttribute(10, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddMarkupContent(11, "<a href=\"/suggerimento/index\" style=\"visibility:hidden\"><i class=\"fa fa-arrow-left fa-2x\"></i></a>");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(12, "\r\n        ");
            __builder.OpenComponent<MudBlazor.MudItem>(13);
            __builder.AddAttribute(14, "xs", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 17 "C:\Users\ambra.zecchin\Desktop\Legarti\LegartiWeb\Pages\Suggerimento\Dettaglio.razor"
                     4

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(15, "sm", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 17 "C:\Users\ambra.zecchin\Desktop\Legarti\LegartiWeb\Pages\Suggerimento\Dettaglio.razor"
                            12

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(16, "md", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 17 "C:\Users\ambra.zecchin\Desktop\Legarti\LegartiWeb\Pages\Suggerimento\Dettaglio.razor"
                                    6

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(17, "Class", "box-right-suggerimento");
            __builder.AddAttribute(18, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenElement(19, "button");
                __builder2.AddAttribute(20, "type", "button");
                __builder2.AddAttribute(21, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 18 "C:\Users\ambra.zecchin\Desktop\Legarti\LegartiWeb\Pages\Suggerimento\Dettaglio.razor"
                                              () => AggiungiSuggerimento()

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(22, "class", "button-aggiungi-suggerimento");
                __builder2.AddContent(23, "Aggiungi un suggerimento");
                __builder2.CloseElement();
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
            __builder.AddMarkupContent(24, "\r\n\r\n\r\n    ");
            __builder.OpenElement(25, "div");
            __builder.AddAttribute(26, "class", "box-container-suggerimento");
#nullable restore
#line 24 "C:\Users\ambra.zecchin\Desktop\Legarti\LegartiWeb\Pages\Suggerimento\Dettaglio.razor"
         if (listaSuggerimenti != null)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "C:\Users\ambra.zecchin\Desktop\Legarti\LegartiWeb\Pages\Suggerimento\Dettaglio.razor"
             if (listaSuggerimenti.Count > 0)
            {
                foreach (SuggerimentoModel single in listaSuggerimenti)
                {

#line default
#line hidden
#nullable disable
            __builder.OpenComponent<MudBlazor.MudCard>(27);
            __builder.AddAttribute(28, "Class", "box results");
            __builder.AddAttribute(29, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.OpenComponent<MudBlazor.MudItem>(30);
                __builder2.AddAttribute(31, "xs", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 31 "C:\Users\ambra.zecchin\Desktop\Legarti\LegartiWeb\Pages\Suggerimento\Dettaglio.razor"
                                     6

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(32, "sm", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 31 "C:\Users\ambra.zecchin\Desktop\Legarti\LegartiWeb\Pages\Suggerimento\Dettaglio.razor"
                                            12

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(33, "md", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 31 "C:\Users\ambra.zecchin\Desktop\Legarti\LegartiWeb\Pages\Suggerimento\Dettaglio.razor"
                                                    6

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(34, "Class", "box-left-suggerimento");
                __builder2.AddAttribute(35, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<MudBlazor.MudCardContent>(36);
                    __builder3.AddAttribute(37, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.OpenComponent<MudBlazor.MudText>(38);
                        __builder4.AddAttribute(39, "Typo", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Typo>(
#nullable restore
#line 33 "C:\Users\ambra.zecchin\Desktop\Legarti\LegartiWeb\Pages\Suggerimento\Dettaglio.razor"
                                               Typo.h5

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(40, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder5) => {
                            __builder5.OpenComponent<MudBlazor.MudAvatar>(41);
                            __builder5.AddAttribute(42, "Color", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Color>(
#nullable restore
#line 34 "C:\Users\ambra.zecchin\Desktop\Legarti\LegartiWeb\Pages\Suggerimento\Dettaglio.razor"
                                                      Color.Warning

#line default
#line hidden
#nullable disable
                            ));
                            __builder5.AddAttribute(43, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder6) => {
                                __builder6.AddMarkupContent(44, "<i class=\"fa fa-user fa-3x\" id=\"fa-icon-dettagliosuggerimento-grande\"></i>\r\n                                        <i class=\"fa fa-user\" id=\"fa-icon-dettagliosuggerimento-piccola\" style=\"display:none\"></i>");
                            }
                            ));
                            __builder5.CloseComponent();
                        }
                        ));
                        __builder4.CloseComponent();
                        __builder4.AddMarkupContent(45, "\r\n                                ");
                        __builder4.OpenComponent<MudBlazor.MudText>(46);
                        __builder4.AddAttribute(47, "Typo", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Typo>(
#nullable restore
#line 39 "C:\Users\ambra.zecchin\Desktop\Legarti\LegartiWeb\Pages\Suggerimento\Dettaglio.razor"
                                               Typo.body2

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(48, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder5) => {
                            __builder5.AddContent(49, 
#nullable restore
#line 40 "C:\Users\ambra.zecchin\Desktop\Legarti\LegartiWeb\Pages\Suggerimento\Dettaglio.razor"
                                     single.NomeVisualizzato

#line default
#line hidden
#nullable disable
                            );
                            __builder5.AddMarkupContent(50, " <br>");
                        }
                        ));
                        __builder4.CloseComponent();
                        __builder4.AddMarkupContent(51, "\r\n                                ");
                        __builder4.OpenComponent<MudBlazor.MudText>(52);
                        __builder4.AddAttribute(53, "Typo", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Typo>(
#nullable restore
#line 42 "C:\Users\ambra.zecchin\Desktop\Legarti\LegartiWeb\Pages\Suggerimento\Dettaglio.razor"
                                               Typo.body2

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(54, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder5) => {
                            __builder5.AddContent(55, 
#nullable restore
#line 43 "C:\Users\ambra.zecchin\Desktop\Legarti\LegartiWeb\Pages\Suggerimento\Dettaglio.razor"
                                     single.DataInserimento.ToString("dd/MM/yyyy")

#line default
#line hidden
#nullable disable
                            );
                        }
                        ));
                        __builder4.CloseComponent();
                    }
                    ));
                    __builder3.CloseComponent();
                }
                ));
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(56, "\r\n                        ");
                __builder2.OpenComponent<MudBlazor.MudItem>(57);
                __builder2.AddAttribute(58, "xs", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 48 "C:\Users\ambra.zecchin\Desktop\Legarti\LegartiWeb\Pages\Suggerimento\Dettaglio.razor"
                                     6

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(59, "sm", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 48 "C:\Users\ambra.zecchin\Desktop\Legarti\LegartiWeb\Pages\Suggerimento\Dettaglio.razor"
                                            12

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(60, "md", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 48 "C:\Users\ambra.zecchin\Desktop\Legarti\LegartiWeb\Pages\Suggerimento\Dettaglio.razor"
                                                    6

#line default
#line hidden
#nullable disable
                ));
                __builder2.AddAttribute(61, "Class", "box-right-suggerimento");
                __builder2.AddAttribute(62, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<MudBlazor.MudText>(63);
                    __builder3.AddAttribute(64, "Typo", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Typo>(
#nullable restore
#line 49 "C:\Users\ambra.zecchin\Desktop\Legarti\LegartiWeb\Pages\Suggerimento\Dettaglio.razor"
                                           Typo.body1

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(65, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.AddContent(66, 
#nullable restore
#line 50 "C:\Users\ambra.zecchin\Desktop\Legarti\LegartiWeb\Pages\Suggerimento\Dettaglio.razor"
                                 single.Titolo

#line default
#line hidden
#nullable disable
                        );
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(67, "\r\n                            ");
                    __builder3.OpenComponent<MudBlazor.MudText>(68);
                    __builder3.AddAttribute(69, "Typo", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Typo>(
#nullable restore
#line 52 "C:\Users\ambra.zecchin\Desktop\Legarti\LegartiWeb\Pages\Suggerimento\Dettaglio.razor"
                                           Typo.body2

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(70, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.AddContent(71, 
#nullable restore
#line 53 "C:\Users\ambra.zecchin\Desktop\Legarti\LegartiWeb\Pages\Suggerimento\Dettaglio.razor"
                                 single.Testo

#line default
#line hidden
#nullable disable
                        );
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(72, "\r\n                            ");
                    __builder3.OpenComponent<MudBlazor.MudCardActions>(73);
                    __builder3.AddAttribute(74, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.OpenElement(75, "button");
                        __builder4.AddAttribute(76, "type", "button");
                        __builder4.AddAttribute(77, "class", "button-dett-suggerimento");
                        __builder4.AddAttribute(78, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 56 "C:\Users\ambra.zecchin\Desktop\Legarti\LegartiWeb\Pages\Suggerimento\Dettaglio.razor"
                                                                                                 (() => CancellaSuggerimento(single.IDSuggerimento))

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddMarkupContent(79, "<i class=\"fa fa-trash\"></i>");
                        __builder4.CloseElement();
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
#line 62 "C:\Users\ambra.zecchin\Desktop\Legarti\LegartiWeb\Pages\Suggerimento\Dettaglio.razor"
                }
            }
            else
            {

#line default
#line hidden
#nullable disable
            __builder.OpenElement(80, "div");
            __builder.AddAttribute(81, "class", "div-center");
            __builder.OpenComponent<MudBlazor.MudInputLabel>(82);
            __builder.AddAttribute(83, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddContent(84, " Non ci sono suggerimenti da mostrare");
            }
            ));
            __builder.CloseComponent();
            __builder.CloseElement();
#nullable restore
#line 69 "C:\Users\ambra.zecchin\Desktop\Legarti\LegartiWeb\Pages\Suggerimento\Dettaglio.razor"
            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 69 "C:\Users\ambra.zecchin\Desktop\Legarti\LegartiWeb\Pages\Suggerimento\Dettaglio.razor"
             
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
