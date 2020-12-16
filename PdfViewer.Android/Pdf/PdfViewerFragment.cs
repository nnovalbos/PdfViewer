using System.IO;
using Android.OS;
using Android.Views;
using AndroidX.RecyclerView.Widget;
using Xamarin.Essentials;
using Fragment = AndroidX.Fragment.App.Fragment;

namespace PdfViewer.Droid.Pdf
{
    public class PdfViewerFragment : Fragment
    {

		public static string fileName = "837pages.pdf";

		// RecyclerView instance that displays the pdf file:
		RecyclerView mRecyclerView;

		// Layout manager that lays out each card in the RecyclerView:
		RecyclerView.LayoutManager mLayoutManager;

		// Adapter that accesses the data set (a pdf file):
		PdfFileAdapter mAdapter;

		// pdf file that is managed by the adapter:
		PdfFile mPdfFile;

		public PdfViewerFragment()
        {
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
			
            base.OnCreate(savedInstanceState);
		}

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
			// Use this to return your custom view for this Fragment
			base.OnCreateView(inflater, container, savedInstanceState);

			return DrawFragment();
        }

		public View DrawFragment()
        {
			Stream inputStream = Platform.AppContext.Assets.Open(fileName);
			using (var outputStream = Platform.CurrentActivity.OpenFileOutput("_sample.pdf", Android.Content.FileCreationMode.Private))
			{
				inputStream.CopyTo(outputStream);
			}

			var fileStreamPath = Platform.CurrentActivity.GetFileStreamPath("_sample.pdf");
			MemoryStream m_memoryStream = new MemoryStream();
			File.OpenRead(fileStreamPath.AbsolutePath).CopyTo(m_memoryStream);

			// Instantiate the pdf file:
			mPdfFile = new PdfFile
			{
				ScreenWidth = (int)DeviceDisplay.MainDisplayInfo.Width
			};

			mPdfFile.RenderPDFPagesIntoImages(fileStreamPath);

			// Get our RecyclerView layout:
			var v = LayoutInflater.From(Platform.AppContext).Inflate(Resource.Layout.pdf_fragment, null);
		    mRecyclerView = v.FindViewById<RecyclerView>(Resource.Id.recyclerView);

			// Use the built-in linear layout manager:
			mLayoutManager = new LinearLayoutManager(Platform.CurrentActivity);

			// Plug the layout manager into the RecyclerView:
			mRecyclerView.SetLayoutManager(mLayoutManager);

			// Create an adapter for the RecyclerView, and pass it the
			// data set (the pdf file) to manage:
			mAdapter = new PdfFileAdapter(mPdfFile);

			// Plug the adapter into the RecyclerView:

			mRecyclerView.SetAdapter(mAdapter);

			return v;
		}
    }
}