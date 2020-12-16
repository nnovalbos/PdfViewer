using PdfViewer.CustomRenders;
using Xamarin.Forms;

namespace PdfViewer
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            LoadExtraComponents();
        }

        private void LoadExtraComponents()
        {
            if (Device.RuntimePlatform.Equals(Device.iOS))
            {
                PdfWebView pdfWebView = new PdfWebView
                {
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };

                StackHeader.Children.Add(pdfWebView);
            }
        }

        public Frame FrameHeader => Header;

    }
}
