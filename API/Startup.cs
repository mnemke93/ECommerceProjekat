using Application.Logging;
using Application.Queries;
using Application.UseCases.Commands;
using Application.UseCases.Services;
using DataAccess;
using Implementation;
using Implementation.Logging;
using Implementation.Services;
using Implementation.UseCases.Commands;
using Implementation.UseCases.Queries;
using Implementation.Validator;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API
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

            
            services.AddTransient<ECommerceContext>(x =>
            {
                var optionsBuilder = new DbContextOptionsBuilder();

                var options = optionsBuilder.Options;

                return new ECommerceContext(options);
            });
            services.AddTransient<IGetCategoriesQuery, GetCategoriesQuery>();
            services.AddTransient<ICreateCategoryCommand, CreateCategoryCommand>();
            services.AddTransient<IUpdateCategoryCommand, UpdateCategoryCommand>();
            services.AddTransient<IDeleteCategoryCommand, DeleteCategoryCommand>();
            services.AddTransient<ICreateSupplierCommand, CreateSupplierCommand>();
            services.AddTransient<IUpdateSupplierCommand, UpdateSupplierCommand>();
            services.AddTransient<IDeleteSupplierCommand, DeleteSupplierCommand>();
            services.AddTransient<IRegisterUserCommand, RegisterUserCommand>();
            services.AddTransient<IUpdateUserCommand, UpdateUserCommand>();
            services.AddTransient<IDeleteUserCommand, DeleteUserCommand>();
            services.AddTransient<ILoginUserService, LoginUserService>();
            services.AddTransient<ICreateReviewCommand, CreateReviewCommand>();
            services.AddTransient<IUpdateReviewCommand, UpdateReviewCommand>();
            services.AddTransient<IDeleteReviewCommand, DeleteReviewCommand>();
            services.AddTransient<ICreateCartCommand, CreateCartCommand>();
            services.AddTransient<IUpdateCartCommand, UpdateCartCommand>();
            services.AddTransient<IDeleteCartCommand, DeleteCartCommand>();
            services.AddTransient<ICreateCartItemCommand, CreateCartItemCommand>();
            services.AddTransient<IUpdateCartItemCommand, UpdateCartItemCommand>();
            services.AddTransient<IDeleteCartItemCommand, DeleteCartItemCommand>();
            services.AddTransient<ICreateOrderCommand, CreateOrderCommand>();
            services.AddTransient<IUpdateOrderCommand, UpdateOrderCommand>();
            services.AddTransient<IDeleteOrderCommand, DeleteOrderCommand>();
            services.AddTransient<ICreateOrderDetailCommand, CreateOrderDetailCommand>();
            services.AddTransient<IUpdateOrderDetailCommand, UpdateOrderDetailCommand>();
            services.AddTransient<IDeleteOrderDetailCommand, DeleteOrderDetailCommand>();
            services.AddTransient<ICreateImageCommand, CreateImageCommand>();
            services.AddTransient<IUpdateImageCommand, UpdateImageCommand>();
            services.AddTransient<IDeleteImageCommand, DeleteImageCommand>();
            services.AddTransient<ICreatePaymentCommand, CreatePaymentCommand>();
            services.AddTransient<IUpdatePaymentCommand, UpdatePaymentCommand>();
            services.AddTransient<IDeletePaymentCommand, DeletePaymentCommand>();
            services.AddTransient<ICreateProductCommand, CreateProductCommand>();
            services.AddTransient<IUpdateProductCommand, UpdateProductCommand>();
            services.AddTransient<IDeleteProductCommand, DeleteProductCommand>();
            services.AddTransient<IExceptionLogger, ConsoleExceptionLogger>();
            services.AddTransient<UseCaseHandler>();

            services.AddTransient<CreateCategoryValidator>();
            services.AddTransient<UpdateCategoryValidator>();
            services.AddTransient<DeleteCategoryValidator>();
            services.AddTransient<CreateSupplierValidator>();
            services.AddTransient<UpdateSupplierValidator>();
            services.AddTransient<DeleteSupplierValidator>();
            services.AddTransient<RegisterUserValidator>();
            services.AddTransient<UpdateUserValidator>();
            services.AddTransient<DeleteUserValidator>();
            services.AddTransient<CreateReviewValidator>();
            services.AddTransient<UpdateReviewValidator>();
            services.AddTransient<DeleteReviewValidator>();
            services.AddTransient<CreateCartValidator>();
            services.AddTransient<UpdateCartValidator>();
            services.AddTransient<DeleteCartValidator>();
            services.AddTransient<CreateCartItemValidator>();
            services.AddTransient<UpdateCartItemValidator>();
            services.AddTransient<DeleteCartItemValidator>();
            services.AddTransient<CreateOrderValidator>();
            services.AddTransient<UpdateOrderValidator>();
            services.AddTransient<DeleteOrderValidator>();
            services.AddTransient<CreateOrderDetailValidator>();
            services.AddTransient<UpdateOrderDetailValidator>();
            services.AddTransient<DeleteOrderDetailValidator>();
            services.AddTransient<CreateImageValidator>();
            services.AddTransient<UpdateImageValidator>();
            services.AddTransient<DeleteImageValidator>();
            services.AddTransient<CreatePaymentValidator>();
            services.AddTransient<UpdatePaymentValidator>();
            services.AddTransient<DeletePaymentValidator>();
            services.AddTransient<CreateProductValidator>();
            services.AddTransient<UpdateProductValidator>();
            services.AddTransient<DeleteProductValidator>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseExceptionHandler(errorApp =>
                {
                    errorApp.Run(async context =>
                    {
                        context.Response.StatusCode = 500; 
                        context.Response.ContentType = "application/json";

                        var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                        if (contextFeature != null)
                        {
                            // Log the exception
                            var logger = errorApp.ApplicationServices.GetRequiredService<ILogger<Startup>>();
                            logger.LogError(contextFeature.Error, contextFeature.Error.Message);

                            // You can also handle the exception here according to your needs.
                        }
                    });
                });
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
