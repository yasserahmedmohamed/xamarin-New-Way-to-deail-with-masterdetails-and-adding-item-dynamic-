using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Icode3
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailPAge2 : ContentPage
	{
		public DetailPAge2 (string text)
		{
			InitializeComponent ();
            text_sent.Text = text;
		}
	}
}