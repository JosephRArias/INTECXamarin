using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using Practice5.iOS;
using Practice5.Services;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Internals;


[assembly: Dependency(typeof(DeviceOrientationService))]
namespace Practice5.iOS
{
	public class DeviceOrientationService : IDeviceOrientationService
	{
		public DeviceOrientation GetOrientation()
		{
			UIInterfaceOrientation orientation = UIApplication.SharedApplication.StatusBarOrientation;

			bool isPortrait = orientation == UIInterfaceOrientation.Portrait ||
				orientation == UIInterfaceOrientation.PortraitUpsideDown;
			return isPortrait ? DeviceOrientation.Portrait : DeviceOrientation.Landscape;
		}
	}
}