using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using CityService;
using CountryService;
using GeographicalStateService;
using PersonTypeService;
using ProgramSubjectService;
using ProgramSubjectPersonService;
using RoomService;
using ProgramService;
using PersonService;
using RoomSubjectService;
using NotesService;
using SubjectService;
using Newtonsoft.Json.Serialization;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace UniversityWebApp
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
            #region ActivateServices

            services.AddMvc();

            services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ContractResolver = new DefaultContractResolver();
    });
            services.AddTransient<ICity>(x => new CityClient());
            services.AddTransient<ICountry>(x => new CountryClient());
            services.AddTransient<IGeographicalState>(x => new GeographicalStateClient());
            services.AddTransient<IPerson>(x => new PersonClient());
            services.AddTransient<IPersonType>(x => new PersonTypeClient());
            services.AddTransient<IProgram>(x => new ProgramClient());
            services.AddTransient<IProgramSubject>(x => new ProgramSubjectClient());
            services.AddTransient<IProgramSubjectPerson>(x => new ProgramSubjectPersonClient());
            services.AddTransient<IRoom>(x => new RoomClient());
            services.AddTransient<IRoomSubject>(x => new RoomSubjectClient());
            services.AddTransient<ISubject>(x => new SubjectClient());
            services.AddTransient<INotes>(x => new NotesClient());

            #endregion ActivateServices

            // Add Kendo UI services to the services container
            services.AddKendo();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            var supportedCultures = new[] { new CultureInfo("es-CO") };
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("es-CO"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}