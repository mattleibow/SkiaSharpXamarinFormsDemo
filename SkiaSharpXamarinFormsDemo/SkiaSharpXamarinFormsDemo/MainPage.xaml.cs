using System.Linq;
using Xamarin.Forms;
using SkiaSharp;
using SkiaSharp.Views.Forms;

namespace SkiaSharpXamarinFormsDemo
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

#if __ANDROID__
			var androidView = stack.Children.OfType<Xamarin.Forms.Platform.Android.NativeViewWrapper>().FirstOrDefault();
			var textView = androidView?.NativeView as Android.Widget.TextView;
			textView?.SetMaxLines(1);
#endif
		}

		private void OnPaintSurface(object sender, SKPaintSurfaceEventArgs e)
		{
			var scale = e.Info.Height / ((SKCanvasView)sender).Height;

			var canvas = e.Surface.Canvas;

			canvas.Clear(SKColors.Transparent);

			var paint = new SKPaint
			{
				TextSize = (float)(40 * scale),
				Typeface = SKTypeface.FromFamilyName("Arial"),
				IsAntialias = true
			};

			var text = "Hello World! (SkiaSharp)";

			var bounds = SKRect.Empty;
			paint.MeasureText(text, ref bounds);

			canvas.DrawText(text, 0, -bounds.Top, paint);
		}
	}
}
