using MathPlacementTest.Data;
using MathPlacementTest.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MathPlacementTest.Api
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
            services.AddControllers();
            services.AddDbContext<MathTestDbContext>(o => o.UseMySQL(Configuration.GetConnectionString("MathDb")));

            services.AddScoped<IStudentResultFetcherService, StudentResultFetcherService>();
            services.AddScoped<ITestQuestionsFetcherService, TestQuestionsFetcherService>();
            services.AddScoped<ITestQuestionsDataFetcher, TestQuestionsDataFetcher>();

            services.AddScoped<IStudentQuestionaireDataInsertorService, StudentQuestionaireDataInsertorService>();
            services.AddScoped<IStudentQuestionaireInfoCreatorService, StudentQuestionaireInfoCreatorService>();
            services.AddScoped<IStudentCreateService, StudentCreateService>();
            services.AddScoped<IStudentCreateDataCreatorService, StudentCreateDataCreatorService>();
            services.AddScoped<IAdminStudentPlacementUpdateService, AdminStudentPlacementUpdateService>();
            services.AddScoped<IGetAllStudentService, GetAllStudentService>();
            services.AddScoped<IGetAllStudentDataService, GetAllStudentDataService>();
            services.AddScoped<IGetPastCoursesService, GetPastCoursesService>();
            services.AddScoped<IGetPastCourseDataRetrieverService, GetPastCoursesDataRetrieverService>();
            services.AddScoped<IStudentQuestionResultService, StudentQuestionResultService>();
            services.AddScoped<IStudentQuestionResultDataInsertor, StudentQuestionResultDataInsertor>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}