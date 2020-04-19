using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using odetoofd.data;
using OdeToFood.Core;

namespace odetofood.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public Restaurant ThisRestaurant { get; set; }
        private readonly IRestaurantData RestaurantData;

        public DetailModel(IRestaurantData restaurantData)
        {
            RestaurantData = restaurantData;
        }

        public IActionResult OnGet(int restaurantId)
        {
            ThisRestaurant = RestaurantData.GetById(restaurantId);
            if (ThisRestaurant == null){
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}
