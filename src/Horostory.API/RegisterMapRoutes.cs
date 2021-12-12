using Horostory.API.Models;
using Horostory.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Horostory.API
{
    public static class RegisterMapRoutes
    {
        public static IEndpointRouteBuilder RegisterRoutes(this IEndpointRouteBuilder builder)
        {
            MapHoroscope(builder);
            return builder;
        }
         
        private static void MapHoroscope(IEndpointRouteBuilder builder)
        {
            builder.MapGet("horoscope", async (string sign, string date, IHorostoryService service) =>
            {
                if (string.IsNullOrWhiteSpace(sign))
                {
                    return Results.BadRequest();
                }
                return Results.Ok(await service.GetHoroscopeInfo(sign, date));
            })
            .Produces<HoroscopeResponse>(StatusCodes.Status200OK)
            .Produces<HoroscopeResponse>(StatusCodes.Status400BadRequest)
            .RequireCors("AnyOrigin");
        }
    }
}
