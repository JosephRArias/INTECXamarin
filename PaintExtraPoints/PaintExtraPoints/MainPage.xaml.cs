using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PaintExtraPoints
{
	// Learn more about making custom code visible in the Xamarin.Forms previewer
	// by visiting https://aka.ms/xamarinforms-previewer
	[DesignTimeVisible(false)]
	public partial class MainPage : ContentPage
	{

		private Dictionary<long, SKPath> temporaryPaths = new Dictionary<long, SKPath>();
		private List<SKPath> paths = new List<SKPath>();
		private SKPaint stroke = new SKPaint();
		public MainPage()
		{
			InitializeComponent();
		}

		private void PaintSample_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
		{

			// 1 - Getting current surface 
			var surface = e.Surface;

			// 2 - Getting the canvas to draw
			var canvas = surface.Canvas;

			//  3. Clearing the canvas
			canvas.Clear(SKColors.Bisque);
			stroke.StrokeWidth = 2;
			stroke.Style = SKPaintStyle.Stroke;
			foreach (var touchPath in temporaryPaths)
			{
				canvas.DrawPath(touchPath.Value, stroke);
			}
		}
		private void OnTouch(object sender, SKTouchEventArgs e)
		{
			switch (e.ActionType)
			{
				case SKTouchAction.Pressed:
					var p = new SKPath();
					p.MoveTo(e.Location);
					temporaryPaths[e.Id] = p;
					break;
				case SKTouchAction.Moved:
					if (e.InContact)
						temporaryPaths[e.Id].LineTo(e.Location);
					break;
				case SKTouchAction.Released:
					paths.Add(temporaryPaths[e.Id]);
					break;
			}

			e.Handled = true;

			// update the UI on the screen
			((SKCanvasView)sender).InvalidateSurface();
		}

		private void Button_Clicked(object sender, EventArgs e)
		{
			Button button = (Button)sender;
			stroke.Color = button.BackgroundColor.ToSKColor();
		}

		private void Button_Clicked_1(object sender, EventArgs e)
		{
			var element = (SKPaintSurfaceEventArgs)e;
			element.Surface.Canvas.Clear(SKColors.Bisque);
		}
	}
}
