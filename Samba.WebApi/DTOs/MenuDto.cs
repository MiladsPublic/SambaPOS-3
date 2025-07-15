using System.Collections.Generic;

namespace Samba.WebApi.DTOs
{
    public class MenuItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string GroupCode { get; set; }
        public string Barcode { get; set; }
        public string Tag { get; set; }
        public List<MenuItemPortionDto> Portions { get; set; } = new List<MenuItemPortionDto>();
    }

    public class MenuItemPortionDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string CurrencyCode { get; set; }
    }

    public class ScreenMenuDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<ScreenMenuCategoryDto> Categories { get; set; } = new List<ScreenMenuCategoryDto>();
    }

    public class ScreenMenuCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }
        public List<ScreenMenuItemDto> MenuItems { get; set; } = new List<ScreenMenuItemDto>();
    }

    public class ScreenMenuItemDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int MenuItemId { get; set; }
        public string ItemPortion { get; set; }
        public decimal Price { get; set; }
        public string ButtonColor { get; set; }
        public int SortOrder { get; set; }
    }
}