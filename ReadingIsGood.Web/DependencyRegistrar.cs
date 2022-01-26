using Microsoft.Extensions.DependencyInjection;
using ReadingIsGood.Core.Data;
using ReadingIsGood.Core.DBEntities;
using ReadingIsGood.Core.Interfaces;
using ReadingIsGood.Core.Services;
using ReadingIsGood.Infrastructure.Data;
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

            _services.AddScoped<ICustomerService, CustomerService>();

        }
    }
}