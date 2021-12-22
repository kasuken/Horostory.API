using AngleSharp;
using Horostory.API.Models;
using System.Text.RegularExpressions;

namespace Horostory.API.Services
{
    public class KudosmediaHorostoryService : IHorostoryService
    {
        public async Task<HoroscopeResponse> GetHoroscopeInfo(string sign, string date)
        {
            var model = new HoroscopeResponse();

            var url = $"http://astrology.kudosmedia.net/m/{sign}?day={date}";

            var config = Configuration.Default
                    .WithDefaultLoader()
                    .WithDefaultCookies();

            var context = BrowsingContext.New(config);
            var document = await context.OpenAsync(url);

            model.Sign = document.GetElementsByTagName("td")[1].GetElementsByTagName("b").FirstOrDefault().InnerHtml;

            model.DateRange = document.GetElementsByTagName("td")[1].InnerHtml;

            //TODO do it better
            model.DateRange = Regex.Replace(model.DateRange, "<.*?>", String.Empty).Replace(model.Sign,"").Replace("\n\t\t\t\t\t\n\t\t\t\t\t","").Trim();

            model.CurrentDate = document.GetElementsByTagName("p").FirstOrDefault().InnerHtml.Replace("Daily Horoscope:", "").Trim();

            model.Description = document.GetElementsByTagName("p")[1].InnerHtml.Replace("\"", "").Trim();

            var li = document.GetElementsByTagName("ul")[1].GetElementsByTagName("li").ToList();

            model.Compatibility = li[0].GetElementsByTagName("strong").FirstOrDefault().InnerHtml;
            model.Mood = li[1].GetElementsByTagName("strong").FirstOrDefault().InnerHtml;
            model.Color = li[2].GetElementsByTagName("strong").FirstOrDefault().InnerHtml;
            model.LuckyNumber = li[3].GetElementsByTagName("strong").FirstOrDefault().InnerHtml;
            model.LuckyTime = li[4].GetElementsByTagName("strong").FirstOrDefault().InnerHtml;

            return model;
        }
    }
}