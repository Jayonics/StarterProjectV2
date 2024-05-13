﻿using Microsoft.AspNetCore.Components;
using Shop.Models.Dtos;

namespace Shop.WebApp.Components.Pages
{
    public partial class DisplayProductsBase : ComponentBase
    {
        [Parameter]
        public IEnumerable<ProductDto> Products { get; set; }
    }
}
