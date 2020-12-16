using Android.Graphics.Drawables;
using Android.Views;
using AndroidX.RecyclerView.Widget;

namespace PdfViewer.Droid.Pdf
{
    // Adapter to connect the data set (PDF file) to the RecyclerView:
    public class PdfFileAdapter : RecyclerView.Adapter
	{
		// Underlying data set (a pdf file):
		public PdfFile PdfFile;

		// Load the adapter with the data set (pdf file) at construction time:
		public PdfFileAdapter(PdfFile pdfFile)
		{
			PdfFile = pdfFile;
		}

		// Create a new pdf CardView (invoked by the layout manager): 
		public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
		{
			// Inflate the CardView for the pdf:
			View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.card_view, parent, false);

			// Create a ViewHolder to find and hold these view references
			CardViewHolder vh = new CardViewHolder(itemView);

			return vh;
		}

		// Fill in the contents of the pdf card (invoked by the layout manager):
		public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
		{
			CardViewHolder vh = holder as CardViewHolder;

			// Set the ImageView and TextView in this ViewHolder's CardView 
			// from this position in the pdf file:
			vh.Image.SetImageBitmap(PdfFile[position]);
		}

		// Return the number of pdfs available in the pdf file:
		public override int ItemCount
		{
			get { return PdfFile.NumPages; }
		}

		
		public override void OnViewDetachedFromWindow(Java.Lang.Object holder)
		{
			base.OnViewDetachedFromWindow(holder);

			var vh = holder as CardViewHolder;
			var bitmapD = vh.Image.Drawable as BitmapDrawable;
			var bitmap = bitmapD.Bitmap;

			vh.Image.SetImageBitmap(null);

			if (bitmap != null)
			{
				bitmap.Recycle();
			}
		}

		public override void OnViewAttachedToWindow(Java.Lang.Object holder)
		{
			base.OnViewAttachedToWindow(holder);

			var vh = holder as CardViewHolder;
			var bitmapD = vh.Image.Drawable as BitmapDrawable;
			var bitmap = bitmapD.Bitmap;

			if (bitmap == null)
			{
				vh.Image.SetImageBitmap(PdfFile[vh.LayoutPosition]);
			}
		}

		public override bool OnFailedToRecycleView(Java.Lang.Object holder)
		{
			return base.OnFailedToRecycleView(holder);
		}

		public override void OnViewRecycled(Java.Lang.Object holder)
		{
			base.OnViewRecycled(holder);
		}
	}
}