using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Horostory.API.Models
{
    public class HoroscopeResponse
    {
        public string Sign { get; set; }
        public string DateRange { get; set; }
        public string CurrentDate { get; set; }
        public string Description { get; set; }
        public string Compatibility { get; set; }
        public string Mood { get; set; }
        public string Color { get; set; }
        public string LuckyNumber { get; set; }
        public string LuckyTime { get; set; }
    }
}
