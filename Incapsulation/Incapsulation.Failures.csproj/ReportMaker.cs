using System;
using System.Collections.Generic;

namespace Incapsulation.Failures
{

    public class Common
    {
        public static int Earlier(DateTime v, int day, int month, int year)
        {
            int vYear = v.Year;
            int vMonth = v.Month;
            int vDay = v.Day;
            if (vYear < year) return 1;
            if (vYear > year) return 0;
            if (vMonth < month) return 1;
            if (vMonth > month) return 0;
            if (vDay < day) return 1;
            return 0;
        }
        public static int Earlier(object[] v, int day, int month, int year)
        {
            int vYear = (int)v[2];
            int vMonth = (int)v[1];
            int vDay = (int)v[0];
            if (vYear < year) return 1;
            if (vYear > year) return 0;
            if (vMonth < month) return 1;
            if (vMonth > month) return 0;
            if (vDay < day) return 1;
            return 0;
        }
    }

    public class ReportMaker
    {
      /// <summary>
      /// 
      /// </summary>
      /// <param name="date"></param>
      /// <param name="failureTypes"></param>
      /// <param name="times"></param>
      /// <param name="devices"></param>
      /// <returns></returns>
        public static List<string> FindDevicesFailedBeforeDate(
            DateTime date,
            List<FailureType> failureTypes,
            List<DateTime> times,
            List<Device> devices)
        {

            var problematicDevices = new HashSet<int>();
            for (int i = 0; i < failureTypes.Count; i++)
                if (Failure.IsFailureSerious(failureTypes[i].GetHashCode()) == 1 && Common.Earlier(times[i], date.Day, date.Month, date.Year) == 1)
                    problematicDevices.Add(devices[i].DeviceId);

            var result = new List<string>();
            foreach (var device in devices)
                if (problematicDevices.Contains(device.DeviceId))
                    result.Add(device.Name);

            return result;
        }
        /// <summary>
        /// </summary>
        /// <param name="day"></param>
        /// <param name="failureTypes">
        /// 0 for unexpected shutdown, 
        /// 1 for short non-responding, 
        /// 2 for hardware failures, 
        /// 3 for connection problems
        /// </param>
        /// <param name="deviceId"></param>
        /// <param name="times"></param>
        /// <param name="devices"></param>
        /// <returns></returns>
        public static List<string> FindDevicesFailedBeforeDateObsolete(
            int day,
            int month,
            int year,
            int[] failureTypes,
            int[] deviceId,
            object[][] times,
            List<Dictionary<string, object>> devices)
        {

            var problematicDevices = new HashSet<int>();
            for (int i = 0; i < failureTypes.Length; i++)
                if (Failure.IsFailureSerious(failureTypes[i]) == 1 && Common.Earlier(times[i], day, month, year) == 1)
                    problematicDevices.Add(deviceId[i]);

            var result = new List<string>();
            foreach (var device in devices)
                if (problematicDevices.Contains((int)device["DeviceId"]))
                    result.Add(device["Name"] as string);

            return result;
        }

    }
    public class Device
    {
        public int DeviceId { get; set; }
        public string Name { get; set; }
    }
    public class Failure
    {
        public static int IsFailureSerious(int failure)
        {
            if (failure % 2 == 0) return 1;
            return 0;
        }
    }
    public enum FailureType
    {
        unexpected = 0,
        nonResponding = 1,
        hardware = 2,
        connection = 3
    }
}
