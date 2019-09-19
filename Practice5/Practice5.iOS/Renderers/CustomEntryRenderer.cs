using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using Practice5.Controls;
using Practice5.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRenderer))]
namespace Practice5.iOS.Renderers
{
	public class CustomEntryRenderer : EntryRenderer  
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
		{
			base.OnElementChanged(e);

			if (Control != null)
			{
				// do whatever you want to the UITextField here!
				Control.BackgroundColor = UIColor.FromRGB(204, 153, 255);
				Control.BorderStyle = UITextBorderStyle.Line;
			}
		}
	}
}