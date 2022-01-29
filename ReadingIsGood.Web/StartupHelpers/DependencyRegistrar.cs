using Microsoft.Extensions.DependencyInjection;
using ReadingIsGood.Core.Data;
using ReadingIsGood.Core.DBEntities;
using ReadingIsGood.Core.Interfaces;
using ReadingIsGood.Core.Services;
using ReadingIsGood.Infrastructure.Data;
using ReadingIsGood.Web.EnpointModel;
using ReadingIsGood.Web.Helpers;
using System;

namespace ReadingIsGood.Web
{
    internal class DependencyRegistrar
    {
        private IServiceCollection _services;

        public DependencyRegistrar(IServiceCollection services)
        {
            this._services = services;
        }

        internal void ConfigureDependencies()
        {

            _services.AddScoped<IRepository<Customer>, EfRepository<Customer>>();
            _services.AddScoped<IRepository<ProductCategory>, EfRepository<ProductCategory>>();
            _services.AddScoped<IRepository<Product>, EfRepository<Product>>();
            _services.AddScoped<IRepository<Order>, EfRepository<Order>>();
            _services.AddScoped<IRepository<Log>, EfRepository<Log>>();

            _services.AddScoped<ICustomerService, CustomerService>();
            _services.AddScoped<IProductService, ProductService>();
            _services.AddScoped<IOrderService, OrderService>();
            _services.AddScoped<ILogService, LogService>();

            _services.AddScoped<IResponseGeneric, ResponseGeneric>();



        }
    }
}