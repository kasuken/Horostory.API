using Horostory.API.Models;

namespace Horostory.API.Services
{
    public interface IHorostoryService
    {

        Task<HoroscopeResponse> GetHoroscopeInfo(string sign, string date);

    }
}
