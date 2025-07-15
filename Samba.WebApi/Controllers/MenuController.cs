using Microsoft.AspNetCore.Mvc;
using Samba.WebApi.DTOs;

namespace Samba.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MenuController : ControllerBase
    {
        private readonly ILogger<MenuController> _logger;

        public MenuController(ILogger<MenuController> logger)
        {
            _logger = logger;
        }

        [HttpGet("items")]
        public async Task<ActionResult<IEnumerable<MenuItemDto>>> GetMenuItems()
        {
            try
            {
                // TODO: Integrate with existing menu service
                // For now, return sample menu data
                var menuItems = new List<MenuItemDto>
                {
                    new MenuItemDto
                    {
                        Id = 1,
                        Name = "Cheeseburger",
                        GroupCode = "BURGERS",
                        Barcode = "123456789",
                        Tag = "beef,cheese",
                        Portions = new List<MenuItemPortionDto>
                        {
                            new MenuItemPortionDto { Id = 1, Name = "Regular", Price = 15.50m, CurrencyCode = "USD" },
                            new MenuItemPortionDto { Id = 2, Name = "Large", Price = 18.50m, CurrencyCode = "USD" }
                        }
                    },
                    new MenuItemDto
                    {
                        Id = 2,
                        Name = "French Fries",
                        GroupCode = "SIDES",
                        Barcode = "123456790",
                        Tag = "potato,fried",
                        Portions = new List<MenuItemPortionDto>
                        {
                            new MenuItemPortionDto { Id = 3, Name = "Small", Price = 3.50m, CurrencyCode = "USD" },
                            new MenuItemPortionDto { Id = 4, Name = "Large", Price = 5.00m, CurrencyCode = "USD" }
                        }
                    },
                    new MenuItemDto
                    {
                        Id = 3,
                        Name = "Coca Cola",
                        GroupCode = "DRINKS",
                        Barcode = "123456791",
                        Tag = "beverage,cola",
                        Portions = new List<MenuItemPortionDto>
                        {
                            new MenuItemPortionDto { Id = 5, Name = "Small", Price = 3.00m, CurrencyCode = "USD" },
                            new MenuItemPortionDto { Id = 6, Name = "Medium", Price = 4.00m, CurrencyCode = "USD" },
                            new MenuItemPortionDto { Id = 7, Name = "Large", Price = 5.00m, CurrencyCode = "USD" }
                        }
                    },
                    new MenuItemDto
                    {
                        Id = 4,
                        Name = "Caesar Salad",
                        GroupCode = "SALADS",
                        Barcode = "123456792",
                        Tag = "salad,lettuce,chicken",
                        Portions = new List<MenuItemPortionDto>
                        {
                            new MenuItemPortionDto { Id = 8, Name = "Regular", Price = 12.00m, CurrencyCode = "USD" }
                        }
                    },
                    new MenuItemDto
                    {
                        Id = 5,
                        Name = "Margherita Pizza",
                        GroupCode = "PIZZA",
                        Barcode = "123456793",
                        Tag = "pizza,tomato,mozzarella",
                        Portions = new List<MenuItemPortionDto>
                        {
                            new MenuItemPortionDto { Id = 9, Name = "Small", Price = 14.00m, CurrencyCode = "USD" },
                            new MenuItemPortionDto { Id = 10, Name = "Medium", Price = 18.00m, CurrencyCode = "USD" },
                            new MenuItemPortionDto { Id = 11, Name = "Large", Price = 22.00m, CurrencyCode = "USD" }
                        }
                    }
                };

                return Ok(menuItems);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving menu items");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("screens")]
        public async Task<ActionResult<IEnumerable<ScreenMenuDto>>> GetScreenMenus()
        {
            try
            {
                // TODO: Integrate with existing menu service
                // Return sample screen menu data organized for POS display
                var screenMenus = new List<ScreenMenuDto>
                {
                    new ScreenMenuDto
                    {
                        Id = 1,
                        Name = "Main Menu",
                        Categories = new List<ScreenMenuCategoryDto>
                        {
                            new ScreenMenuCategoryDto
                            {
                                Id = 1,
                                Name = "Burgers",
                                SortOrder = 1,
                                MenuItems = new List<ScreenMenuItemDto>
                                {
                                    new ScreenMenuItemDto
                                    {
                                        Id = 1,
                                        Name = "Cheeseburger",
                                        MenuItemId = 1,
                                        ItemPortion = "Regular",
                                        Price = 15.50m,
                                        ButtonColor = "#FF6B35",
                                        SortOrder = 1
                                    }
                                }
                            },
                            new ScreenMenuCategoryDto
                            {
                                Id = 2,
                                Name = "Pizza",
                                SortOrder = 2,
                                MenuItems = new List<ScreenMenuItemDto>
                                {
                                    new ScreenMenuItemDto
                                    {
                                        Id = 2,
                                        Name = "Margherita",
                                        MenuItemId = 5,
                                        ItemPortion = "Medium",
                                        Price = 18.00m,
                                        ButtonColor = "#4ECDC4",
                                        SortOrder = 1
                                    }
                                }
                            },
                            new ScreenMenuCategoryDto
                            {
                                Id = 3,
                                Name = "Sides",
                                SortOrder = 3,
                                MenuItems = new List<ScreenMenuItemDto>
                                {
                                    new ScreenMenuItemDto
                                    {
                                        Id = 3,
                                        Name = "French Fries",
                                        MenuItemId = 2,
                                        ItemPortion = "Large",
                                        Price = 5.00m,
                                        ButtonColor = "#45B7D1",
                                        SortOrder = 1
                                    }
                                }
                            },
                            new ScreenMenuCategoryDto
                            {
                                Id = 4,
                                Name = "Drinks",
                                SortOrder = 4,
                                MenuItems = new List<ScreenMenuItemDto>
                                {
                                    new ScreenMenuItemDto
                                    {
                                        Id = 4,
                                        Name = "Coca Cola",
                                        MenuItemId = 3,
                                        ItemPortion = "Medium",
                                        Price = 4.00m,
                                        ButtonColor = "#96CEB4",
                                        SortOrder = 1
                                    }
                                }
                            },
                            new ScreenMenuCategoryDto
                            {
                                Id = 5,
                                Name = "Salads",
                                SortOrder = 5,
                                MenuItems = new List<ScreenMenuItemDto>
                                {
                                    new ScreenMenuItemDto
                                    {
                                        Id = 5,
                                        Name = "Caesar Salad",
                                        MenuItemId = 4,
                                        ItemPortion = "Regular",
                                        Price = 12.00m,
                                        ButtonColor = "#FFEAA7",
                                        SortOrder = 1
                                    }
                                }
                            }
                        }
                    }
                };

                return Ok(screenMenus);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving screen menus");
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("items/{id}")]
        public async Task<ActionResult<MenuItemDto>> GetMenuItem(int id)
        {
            try
            {
                // TODO: Integrate with existing menu service
                // For now, return sample data based on ID
                if (id == 1)
                {
                    var menuItem = new MenuItemDto
                    {
                        Id = 1,
                        Name = "Cheeseburger",
                        GroupCode = "BURGERS",
                        Barcode = "123456789",
                        Tag = "beef,cheese"
                    };
                    return Ok(menuItem);
                }

                return NotFound($"Menu item with ID {id} not found");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving menu item {MenuItemId}", id);
                return StatusCode(500, "Internal server error");
            }
        }
    }
}