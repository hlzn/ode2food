using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using odetoofd.data;
using OdeToFood.Core;

namespace odetofood.Pages.Restaurants
{
    public class ListsModel : PageModel
    {
        private readonly IConfiguration config;

        public string HelloMessage { get; set; }

        public string MsgFromAppSelttings { get; set; }

        private readonly IRestaurantData restaurantData;

        public IEnumerable<Restaurant> MyRestaurants { get; set; }
        
        [BindProperty(SupportsGet=true)]
        public string SearchTerm { get; set; }

        public ListsModel(IConfiguration config, IRestaurantData restaurantData)
        {
            this.config = config;
            this.restaurantData = restaurantData;
        }

        public void OnGet()
        {
            //var searchTerm = HttpContext.Request.QueryString["searchTerm"];

            HelloMessage = "Hello from model";
            MsgFromAppSelttings = config["Message"];
            MyRestaurants = restaurantData.GetRestaurantsByName(SearchTerm);
        }
    }
}
