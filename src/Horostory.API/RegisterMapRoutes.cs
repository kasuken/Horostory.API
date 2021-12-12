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
            var signs = new List<string>();
            signs.Add("aries");
            signs.Add("taurus");
            signs.Add("gemini");
            signs.Add("cancer");
            signs.Add("leo");
            signs.Add("virgo");
            signs.Add("libra");
            signs.Add("scorpio");
            signs.Add("sagittarius");
            signs.Add("capricorn");
            signs.Add("pisces");
            signs.Add("aquarius");

            builder.MapGet("horoscope", async (string sign, string date, IHorostoryService service) =>
            {
                if (string.IsNullOrWhiteSpace(sign))
                {
                    return Results.BadRequest();
                }
                if (!signs.Contains(sign.ToLower()))
                {
                    return Results.BadRequest("Sign not found");
                }

                if (string.IsNullOrWhiteSpace(date))
                {
                    date = "today";
                }

                return Results.Ok(await service.GetHoroscopeInfo(sign, date));
            })
            .Produces<HoroscopeResponse>(StatusCodes.Status200OK)
            .Produces<HoroscopeResponse>(StatusCodes.Status400BadRequest)
            .RequireCors("AnyOrigin");
        }
    }
}
