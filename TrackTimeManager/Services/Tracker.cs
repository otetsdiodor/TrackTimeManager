using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrackTimeManager.Models;

namespace TrackTimeManager.Services
{
    public class Tracker
    {
        TrackAreaModel targetArea;
        DateTime trackStartPoint;
        DateTime trackEndPoint;
        TimeSpan totalTime;
        bool isStarted;

        #region Prop

        public double TotalTime
        {
            get
            {
                return totalTime.TotalMinutes;
            }
        }

        #endregion

        public Tracker(TrackAreaModel areaModel)
        {
            targetArea = areaModel;
            totalTime = areaModel.TotalTime;
            isStarted = false;
        }

        public void Track()
        {
            if (!isStarted)   
            {
                isStarted = true;
                trackStartPoint = DateTime.Now;
            }
            else
            {
                trackEndPoint = DateTime.Now;
                isStarted = false;
                totalTime += trackEndPoint.Subtract(trackStartPoint);
                targetArea.TotalTime = totalTime;
            }
        }
    }
}
