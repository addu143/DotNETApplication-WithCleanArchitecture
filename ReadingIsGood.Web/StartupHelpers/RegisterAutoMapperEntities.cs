using AutoMapper;
using ReadingIsGood.Core.DBEntities;
using ReadingIsGood.Web.Model;

namespace ReadingIsGood.Web
{
    public class RegisterAutoMapperEntities : Profile
    {
        public RegisterAutoMapperEntities()
        {
            CreateMap<Customer, CustomerModel>();
        }
    }

    
}
