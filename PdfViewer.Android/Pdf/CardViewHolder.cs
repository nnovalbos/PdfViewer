using Android.Views;
using Android.Widget;
using AndroidX.RecyclerView.Widget;

namespace PdfViewer.Droid.Pdf
{
    public class CardViewHolder : RecyclerView.ViewHolder
	{
		public ImageView Image { get; private set; }

		// Get references to the views defined in the CardView layout.
		public CardViewHolder(View itemView) : base(itemView)
		{
			// Locate and cache view references:
			Image = itemView.FindViewById<ImageView>(Resource.Id.imageView);
		}
	}
}