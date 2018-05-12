using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Models.NewDb;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ECommerce
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) 
        {
            var connection = Configuration["ConnectionStrings:DefaultConnection"];
            services.AddDbContext<DataContext>(options =>
                options.UseSqlServer(connection));
            services.AddIdentity<User, UserRole>()
                .AddEntityFrameworkStores<DataContext>()
                .AddDefaultTokenProviders();
            services.AddMvc();//constructor injection..MVC built in dependency injection
            services.ConfigureApplicationCookie(action =>
            {
                action.LoginPath = "/Auth/Login";
                action.LogoutPath = "/Auth/Logout";
                action.ReturnUrlParameter = "returnUrl";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, UserManager<User> userManager, RoleManager<UserRole> roleManager, DataContext context)
        {
            Seed(userManager, roleManager, context).Wait();
            //consider the order of pipeline 
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();//wwwroot
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"); // go to the home by default
            });
        }

        private async Task Seed(UserManager<User> userManager, RoleManager<UserRole> roleManager, DataContext context)
        {
            await SeedUserRoles(roleManager);
            await SeedUsers(userManager);
            SeedDatabase(context);
        }

        private async Task SeedUsers(UserManager<User> userManager)
        {
            if(await userManager.FindByNameAsync("Admin")!=null)
                return;
            var user = new User
            {
                UserName = "Admin",
                Email = "Admin@dom.com",
                EmailConfirmed = true,
                Firstname = "Admin",
                Lastname = "Default",
                NewsSubscription = true
            };
            await userManager.CreateAsync(user,
                "AdminDef@1t");
            await userManager.AddToRoleAsync(user, "Admin");
        }

        private async Task SeedUserRoles(RoleManager<UserRole> roleManager)
        {
            var role_async_is_found =await roleManager.FindByNameAsync("Admin");

            if (role_async_is_found != null)
                return;

            await roleManager.CreateAsync(new UserRole {Name = "Admin"});
        }

        private void SeedDatabase(DataContext context)
        {
            if(context.Categories.Any())
                return;
            var baseCategories = new List<Category>
            {
                new Category
                {
                    Name = "Men",
                    Children = new List<Category>
                    {
                        new Category()
                        {
                            Name = "T-Shirts",
                            Children = new List<Category> {new Category() {Name = "Test"}}
                        },
                        new Category() {Name = "Shorts"}
                    }
                },
                new Category {Name = "Women", Children = new List<Category> {new Category {Name = "T-Shirts"}}}
            };
            context.Categories.AddRange(baseCategories);
            context.SaveChanges();

            var uid = context.Users.First().Id;
            List<Product> list = new List<Product>();
            foreach (var baseCategory in baseCategories)
            {
                list.AddRange(AddProducts(baseCategory));
            }

            context.Products.AddRange(list);
            context.SaveChanges();

            IEnumerable<Product> AddProducts(Category category)
            {
                var products = new List<Product>();
                foreach (var child in category.Children)
                {
                    products.AddRange(AddProducts(child));
                }

                var product = new Product
                {
                    CategoryId = category.Id,
                    Description = "Lorelm Epsi",
                    ShortDescription = "Short Lorelm",
                    Name = $"Category: {category.Name}",
                    Price = 5.3d,
                    UserId = uid,
                    SoldCount = 0,
                    Images = new List<Image> { new Image { Url = "/images/1.jpg"} }
                };
                products.Add(product);
                return products;
            }
        }
    }
}
