using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OdeToFood.Core;
using odetoofd.data;

namespace odetofood.Pages.Restaurants
{
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        public Restaurant MyRestaurant { get; set; }
        public DeleteModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public IActionResult OnGet(int restaurantId)
        {
            MyRestaurant = restaurantData.GetById(restaurantId);
            if (MyRestaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost(int restaurantId)
        {
            MyRestaurant = restaurantData.Delete(restaurantId);
            if (MyRestaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            restaurantData.Commit();
            TempData["Message"] = $"{MyRestaurant.Name} deleted";
            return RedirectToPage("./Lists");
        }
    }
}
