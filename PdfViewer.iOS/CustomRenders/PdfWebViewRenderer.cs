using Foundation;
using PdfViewer.CustomRenders;
using PdfViewer.iOS.CustomRenders;
using WebKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(PdfWebView), typeof(PdfWebViewRenderer))]
namespace PdfViewer.iOS.CustomRenders
{
    public class PdfWebViewRenderer : ViewRenderer<PdfWebView, WKWebView>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<PdfWebView> e)
        {
            base.OnElementChanged(e);

            if(Control == null)
            {
                SetNativeControl(new WKWebView(Frame, new WKWebViewConfiguration()));
            }

            if(e.OldElement != null)
            {
                //clean
            }
            
            if (e.NewElement != null)
            {
                Control.LoadRequest(new NSUrlRequest(new NSUrl(NSBundle.MainBundle.PathForResource("837pages", "pdf"), false)));
            }
        }
    }
}
