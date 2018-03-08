using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrackTimeManager.Models
{
    public class TrackAreaModel
    {
        public int id { get; set; }
        public string AreaName { get; set; }
        public TimeSpan TotalTime = new TimeSpan(0, 0, 0);

        public TrackAreaModel(string areaName,string totalTime)
        {
            AreaName = areaName;
            TimeSpan.TryParse(totalTime,out TotalTime);
        }
    }
}
