// File:    TimeInterval.cs
// Created: 21. maj 2020 13:42:07
// Purpose: Definition of Class TimeInterval

using System;

namespace SIMS.Util
{
    public class TimeInterval
    {
        private DateTime _startTime;
        private DateTime _endTime;

        public DateTime StartTime { get => _startTime; set => _startTime = value; }
        public DateTime EndTime { get => _endTime; set => _endTime = value; }

        public TimeInterval(DateTime startTime, DateTime endTime)
        {
            //TODO: Enforce endTime >= startTime
            _startTime = startTime;
            _endTime = endTime;
        }

        public bool IsDateTimeBetween(DateTime dateTime)
            => ((dateTime >= StartTime) && (dateTime <= EndTime));

        public bool IsDateTimeBetween(TimeInterval timeInterval)
        {
            return (timeInterval.StartTime >= StartTime) && (timeInterval.EndTime <= EndTime);
        }

        public bool IsTimeBetween(TimeInterval timeInterval)
        {
            //Note (Gergo) : This method ignores date values and compares only time values, useful when comparing timetable time with actual datetime
            DateTime compareStart = new DateTime(StartTime.Year, StartTime.Month, StartTime.Day, timeInterval.StartTime.Hour, timeInterval.StartTime.Minute, timeInterval.StartTime.Second);
            DateTime compareEnd = new DateTime(EndTime.Year, EndTime.Month, EndTime.Day, timeInterval.EndTime.Hour, timeInterval.EndTime.Minute, timeInterval.EndTime.Second);
            return (compareStart >= StartTime) && (compareEnd <= EndTime);
        }

        public bool IsOverlappingWith(TimeInterval timeInterval)
        {
            //(StartA <(=) EndB) and (EndA >(=) StartB)
            return ((StartTime < timeInterval.EndTime) && (EndTime > timeInterval.StartTime));
        }

        public TimeSpan Duration()
            => EndTime.Subtract(StartTime);

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            TimeInterval otherTime = obj as TimeInterval;

            return StartTime.Equals(otherTime.StartTime) && EndTime.Equals(otherTime.EndTime);
        }
    }
}