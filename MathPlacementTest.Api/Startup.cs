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
            services.AddScoped<IStudentDetailsFetcherService, StudentDetailsFetcherService>();
            services.AddScoped<IStudentDetailsDataFetcher, StudentDetailsDataFetcher>();
            services.AddScoped<IAdminStudentPlacementUpdateService, AdminStudentPlacementUpdateService>();
            services.AddScoped<IGetAllStudentService, GetAllStudentService>();
            services.AddScoped<IGetAllStudentDataService, GetAllStudentDataService>();
            services.AddScoped<IGetPastCoursesService, GetPastCoursesService>();
            services.AddScoped<IGetPastCourseDataRetrieverService, GetPastCoursesDataRetrieverService>();
            services.AddScoped<IAdminGenerateReportService, AdminGenerateReportService>();
            services.AddScoped<IAdminGenerateReportDataRetrieverService, AdminGenerateReportDataRetrieverService>();
            services.AddScoped<IStudentQuestionResultService, StudentQuestionResultService>();
            services.AddScoped<IStudentQuestionResultDataInsertor, StudentQuestionResultDataInsertor>();
            services.AddScoped<IAdminGenerateReportSenderService, AdminGenerateReportSenderService>();
            services.AddScoped<IInfoGetPastCoursesDataFetcher, InfoGetPastCoursesDataFetcher>();
            services.AddScoped<IInfoGetPastCoursesFetcherService, InfoGetPastCoursesFetcherService>();
            services.AddScoped<IEmailReportService, EmailReportService>();
            services.AddScoped<IGetStudentResultSummary, GetStudentResultSummaryService>();
            services.AddScoped<IStudentResultSummaryDataFetcher, StudentResultSummaryDataFetcher>();

            services.AddMvcCore().AddApiExplorer();
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Math Placement Test API V1");
            });

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