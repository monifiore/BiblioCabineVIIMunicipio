#pragma checksum "C:\1_MONICA\ProjectGitHub\BiblioCabineVIIMunicipio\LegartiWeb\Shared\MenuTopAdmin.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b470ec861cd8253be6741d058283a5e1e199e1f1"
// <auto-generated/>
#pragma warning disable 1591
namespace LegartiWeb.Shared
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
    public partial class MenuTopAdmin : MenuTopAdminBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 3 "C:\1_MONICA\ProjectGitHub\BiblioCabineVIIMunicipio\LegartiWeb\Shared\MenuTopAdmin.razor"
  
        int appo=0;


#line default
#line hidden
#nullable disable
            __builder.OpenElement(0, "nav");
            __builder.AddAttribute(1, "class", "top_sub-menu");
            __builder.AddAttribute(2, "data-menu-events");
            __builder.AddAttribute(3, "data-menu-action", "Level 1 open");
            __builder.OpenElement(4, "a");
            __builder.AddAttribute(5, "class", 
#nullable restore
#line 8 "C:\1_MONICA\ProjectGitHub\BiblioCabineVIIMunicipio\LegartiWeb\Shared\MenuTopAdmin.razor"
               !string.IsNullOrEmpty(voceMenuSelezionata) && (voceMenuSelezionata.ToLower()=="amministrazione/descrizionihome/index" || voceMenuSelezionata =="" )? "top_sub-menu-link active" : "top_sub-menu-link"

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(6, "href", "/amministrazione/home/index");
            __builder.AddContent(7, "Sezioni home");
            __builder.CloseElement();
            __builder.AddMarkupContent(8, "\r\n    ");
            __builder.OpenElement(9, "a");
            __builder.AddAttribute(10, "class", 
#nullable restore
#line 9 "C:\1_MONICA\ProjectGitHub\BiblioCabineVIIMunicipio\LegartiWeb\Shared\MenuTopAdmin.razor"
               !string.IsNullOrEmpty(voceMenuSelezionata) && voceMenuSelezionata.ToLower()=="amministrazione/eventi/index" ? "top_sub-menu-link active" : "top_sub-menu-link"

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(11, "href", "/amministrazione/eventi/index");
            __builder.AddContent(12, "Eventi");
            __builder.CloseElement();
            __builder.AddMarkupContent(13, "\r\n    ");
            __builder.OpenElement(14, "a");
            __builder.AddAttribute(15, "class", 
#nullable restore
#line 10 "C:\1_MONICA\ProjectGitHub\BiblioCabineVIIMunicipio\LegartiWeb\Shared\MenuTopAdmin.razor"
               !string.IsNullOrEmpty(voceMenuSelezionata) && (voceMenuSelezionata.ToLower()=="suggerimento/index" ) ? "top_sub-menu-link active" : "top_sub-menu-link"

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(16, "href", "/amministrazione/bibliocabine/index");
            __builder.AddContent(17, "Bibliocabine");
            __builder.CloseElement();
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
