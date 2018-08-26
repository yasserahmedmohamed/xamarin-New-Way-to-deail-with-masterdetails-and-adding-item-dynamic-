using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Icode3
{
	public partial class MainPage : MasterDetailPage
	{
        CustomStacklyout[] AllstackChiled,StackinnerChields;
        CustomStacklyout lastopen;
        public MainPage()
		{
			InitializeComponent();
            Detail = new DetailsPage();
            //////////////////mainClass
            CustomStacklyout[] AllStacklyout = new CustomStacklyout[10];
            AllstackChiled = new CustomStacklyout[10];
            StackinnerChields = new CustomStacklyout[50];
            for (int i = 0; i < 10; i++) {
                AllStacklyout[i] = new CustomStacklyout
                {
                    Orientation = StackOrientation.Horizontal,
                    Margin = new Thickness {Top=4, Left = 4, Right = 10 }
                };
                AllStacklyout[i].Sta_ID = "st" + i;
                AllStacklyout[i].stac_num = i;
                Image image = new Image
                {
                    WidthRequest = 25,
                    HeightRequest = 25,
                    Source = ImageSource.FromFile("library.png")
                };
               Label Alllabels = new CustomLabel
                {
                    FontSize = 20,
                    Text = "Main test " + (i + 1),
                    TextColor = Color.White,
                    HorizontalOptions=LayoutOptions.StartAndExpand

                };

                Image imagenext = new Image
                {HorizontalOptions=LayoutOptions.EndAndExpand,
                    WidthRequest = 20,
                    HeightRequest = 20,

                    Source = ImageSource.FromFile("next.png"),
                    Margin=new Thickness { Right=10}
                  
                };
                AllStacklyout[i].Children.Add(image);
                AllStacklyout[i].Children.Add(Alllabels);
                AllStacklyout[i].Children.Add(imagenext);


                var tgr = new TapGestureRecognizer();
                tgr.Tapped += Tgr_Tapped;
                AllStacklyout[i].GestureRecognizers.Add(tgr);
                
                main_stacklayout.Children.Add(AllStacklyout[i]);
                AllstackChiled[i] = new CustomStacklyout
                {
                    Orientation = StackOrientation.Vertical,
                    BackgroundColor = Color.FromHex("#1C1C1C"),
                    IsVisible = false

                };
               
                for (int j = 0; j < 10; j++) {
                Image childimage = new Image
                {
                    WidthRequest = 25,
                    HeightRequest = 25,
                    Source = ImageSource.FromFile("reference.png")
                };
                Label childlabel = new CustomLabel
                {
                    FontSize = 20,
                    Text = "Main test " + (j + 1),
                    TextColor = Color.White,
                    HorizontalOptions = LayoutOptions.StartAndExpand

                };
                    StackinnerChields[j] = new CustomStacklyout
                {
                    Margin = new Thickness { Left = 20  },
                    Orientation = StackOrientation.Horizontal
                    
                };
                    StackinnerChields[j].Children.Add(childimage);
                    StackinnerChields[j].Children.Add(childlabel);
                    var tgrchild = new TapGestureRecognizer();
                    tgrchild.Tapped += Tgrchild_Tapped;
                    StackinnerChields[j].GestureRecognizers.Add(tgrchild);
                    StackinnerChields[j].child_num = j;
                    StackinnerChields[j].stac_num = i;
                    AllstackChiled[i].Children.Add(StackinnerChields[j]);

                }
                AllstackChiled[i].stac_num = i;
                main_stacklayout.Children.Add(AllstackChiled[i]);


            }

        }

        private void Tgrchild_Tapped(object sender, EventArgs e)
        {
            CustomStacklyout customStacklyout = (CustomStacklyout)sender;
            Detail = new DetailPAge2("Parent Number is : " + (customStacklyout.stac_num+1) +
                "  child number is : " + (customStacklyout.child_num+1));
        }

        private void Tgr_Tapped(object sender, EventArgs e)
        {


            CustomStacklyout l = (CustomStacklyout)sender;
            if (lastopen == null) {
                lastopen = new CustomStacklyout();
                lastopen = AllstackChiled[l.stac_num];
                lastopen.IsVisible = true;
            }
           else if (l.stac_num == lastopen.stac_num)
            {
                AllstackChiled[l.stac_num].IsVisible = !AllstackChiled[l.stac_num].IsVisible;
            }
            else
            {
                if (lastopen.IsVisible)
                    lastopen.IsVisible = !lastopen.IsVisible;
                lastopen = AllstackChiled[l.stac_num];
                lastopen.IsVisible = true;
            }
        }
    }
}
