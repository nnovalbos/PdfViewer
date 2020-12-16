using System;
using Android.Graphics;
using Android.Graphics.Pdf;
using Android.OS;

namespace PdfViewer.Droid.Pdf
{
    public class PdfFile
	{
		PdfRenderer renderer;
		PdfRenderer.Page page;
		Bitmap bitmap;
		public int ScreenWidth;
		int numPages;
		public void RenderPDFPagesIntoImages(Java.IO.File file)
		{
			// create a new renderer
			try
			{
				renderer = new PdfRenderer(ParcelFileDescriptor.Open(file, ParcelFileMode.ReadOnly));
				numPages = renderer.PageCount;
			}
			catch (Exception)
			{
				// handle any exceptions
			}
		}

		public int NumPages
		{
			get { return numPages; }
		}

		// Indexer (read only) for accessing a pdf:
		public Bitmap this[int i]
		{
			get
			{
				page = renderer.OpenPage(i);

				// create bitmap of page
				var ratio = (float)page.Height / page.Width;
				var newHeight = ScreenWidth * ratio;

				bitmap = Bitmap.CreateBitmap(ScreenWidth, (int)newHeight, Bitmap.Config.Argb8888);

				// render for showing on the screen
				page.Render(bitmap, null, null, PdfRenderMode.ForDisplay);

				page.Close();
				page.Dispose();

				return bitmap;
			}
		}
	}
}