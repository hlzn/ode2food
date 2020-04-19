using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using odetoofd.data;
using OdeToFood.Core;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace odetofood.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;
        //to make it input and output
        [BindProperty]
        public Restaurant restaurant { get; set; }

        public IEnumerable<SelectListItem> cuisines { get; set; }

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }
        public IActionResult OnGet(int? restaurantId)
        {
            cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
            if (restaurantId.HasValue)
            {
                restaurant = restaurantData.GetById(restaurantId.Value);
            } else {
                restaurant = new Restaurant();
            }
            if (restaurant == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }

            if (restaurant.Id > 0){
                restaurantData.Update(restaurant);
            } else {
                restaurantData.Add(restaurant);
            }
            TempData["Message"] = "Restaurant saved!";
            restaurantData.Commit();
            return RedirectToPage("./Detail", new { restaurantId = restaurant.Id });
        }
    }
}
