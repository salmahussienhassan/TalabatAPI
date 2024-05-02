using Microsoft.AspNetCore.Mvc;
using Talabat.Core.Repositories;
using Talabat.Repository.Data;
using Talabat.Repository;
using AutoMapper;
using Talabat.Api.Helper;
using Talabat.Api.Errors;

namespace Talabat.Api.Extension
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection Services)
        {
          

            Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

                Services.AddAutoMapper(typeof(MappingProfile));


            #region Configure Validation Error Response

            // service name ApiBehaviorOptions
            Services.Configure<ApiBehaviorOptions>(Options =>

            // InvalidModelStateResponseFactory :that generate response of validation error response
            //actionContext : that represent response it self so i will change on it to make it like i need
            Options.InvalidModelStateResponseFactory = (actionContext) =>
            {
                //modelState => dictionary Keyvalue pair
                //key => name of param
                //value => error it self

                var error = actionContext.ModelState.Where(p => p.Value.Errors.Count() > 0)
                                                   .SelectMany(p => p.Value.Errors)
                                                   .Select(p => p.ErrorMessage)
                                                   .ToList();

                var ValidationErrorResponse = new ValidationErrorResponse()
                {
                    Errors = error
                };

                return new BadRequestObjectResult(ValidationErrorResponse);
            }

            );


            #endregion

            return Services;
        }
    }
}
