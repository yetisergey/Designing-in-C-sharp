using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Incapsulation.Failures
{
    [TestFixture]
    public class ReportMaker_Tests
    {
        [Test]
        public void NoDevices()
        {
            var result = ReportMaker.FindDevicesFailedBeforeDate(
                new DateTime(2010, 5, 10),
                new List<FailureType>(),
                new List<DateTime>(),
                new List<Device>());
            CollectionAssert.IsEmpty(result);
        }

        [Test]
        public void FilterSingleDevice()
        {
            var lD = new List<Device>
                 {
                    new Device
                    {
                        DeviceId=0,
                        Name="0"
                    },
                    new Device
                    {
                        DeviceId=1,
                        Name="1"
                    },
                    new Device
                    {
                        DeviceId=2,
                        Name="2"
                    },
                    new Device
                    {
                        DeviceId=3,
                        Name="3"
                    },
                 };
            var result = ReportMaker.FindDevicesFailedBeforeDate(
                 new DateTime(2010, 5, 10),
                 new List<FailureType> {
                     FailureType.unexpected,
                     FailureType.nonResponding,
                     FailureType.hardware,
                     FailureType.connection },
                 new List<DateTime>
                 {
                    new DateTime(2010,4,9) ,
                    new DateTime( 2010,4,9 ) ,
                    new DateTime(2010 , 5, 11) ,
                    new DateTime(2010, 4,  9),
                 }, lD
                 );

            CollectionAssert.AreEqual(new[] { "0" }, result);
        }

        [Test]
        public void FilterManyDevices()
        {
            var lD = new List<Device>
                {
                    new Device
                    {
                        DeviceId=0,
                        Name="Device A"
                    },
                    new Device
                    {
                        DeviceId=1,
                        Name="Device B"
                    },
                    new Device
                    {
                        DeviceId=2,
                        Name="Device C"
                    },
                    new Device
                    {
                        DeviceId=3,
                        Name="Device D"
                    },
                };
            var result = ReportMaker.FindDevicesFailedBeforeDate(
                new DateTime(2010, 5, 10),
                new List<FailureType> {
                    FailureType.unexpected,
                    FailureType.nonResponding,
                    FailureType.unexpected,
                    FailureType.hardware
                },
                new List<DateTime>
                {
                    new DateTime(2010,5,9),
                    new DateTime(2009,6,1),
                    new DateTime(2010,5,9),
                    new DateTime(2010,5,19)
                }, lD);

            CollectionAssert.AreEqual(new[] { "Device A", "Device C" }, result);
        }
    }
}
