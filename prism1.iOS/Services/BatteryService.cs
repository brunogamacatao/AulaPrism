using System;
using prism1.Services;
using UIKit;

namespace prism1.iOS.Services
{
    public class BatteryService: IBatteryService
    {
        public string GetBatteryStatus()
        {
            switch (UIDevice.CurrentDevice.BatteryState) {
                case UIDeviceBatteryState.Charging:
                    return "Charging";
                case UIDeviceBatteryState.Full:
                    return "Full";
                case UIDeviceBatteryState.Unplugged:
                    return "Discharging";
                default:
                    return "Unknown";
            }
        }
    }
}
