using Android.Content;
using Android.Views;
using PdfViewer;
using PdfViewer.Droid;
using PdfViewer.Droid.Pdf;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MainPage), typeof(AndroidMainPageRenderer))]
namespace PdfViewer.Droid
{
    public class AndroidMainPageRenderer : PageRenderer
    {
        Android.Views.View _view;
        Frame _header = null;

        public AndroidMainPageRenderer(Context context): base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);
            
            if (e.NewElement != null)
            {
                _header = (Element as MainPage).FrameHeader;
            }
        
            PdfViewerFragment fragment = new PdfViewerFragment();
            _view = fragment.DrawFragment();
            AddView(_view);  
        }

        
        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);
            var msw = MeasureSpec.MakeMeasureSpec(r - l, MeasureSpecMode.Exactly);
            var msh = MeasureSpec.MakeMeasureSpec(b - t, MeasureSpecMode.Exactly);
            _view.Measure(msw, msh);

            var y = (int) (_header != null ? _header.Bounds.Height * DeviceDisplay.MainDisplayInfo.Density : 0);
            _view.Layout(0, y, r - l, b - t);
        }
    }
}