using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Unosquare.Data.Models;
using Unosquare.Services.Contracts;
using Unosquare.Services.Services;

namespace Unosquare.API
{
    public partial class Startup
    {
        public void ConfigureDIServices(IServiceCollection services)
        {
            services.AddScoped<IItemService<Item>, ItemService>();
        }
    }
}
