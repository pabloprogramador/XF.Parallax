using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Parallax
{

    public partial class MainPage : ContentPage
    {
        private double depth = 200; // FORCE OF PARALLAX
        private List<MainViewModel> mainViewModel;
        private int ajustDevice = Device.RuntimePlatform == Device.Android ? 2 : 1;


        public MainPage()
        {
            InitializeComponent();
            mainViewModel = new List<MainViewModel>() {
                 new MainViewModel{ Photo="pic2.png", Title = "PARALLAX", BackgroundColor= Color.Lime},
                 new MainViewModel{ Photo="pic5.png", Title = "EASY", BackgroundColor= Color.Red},
                 new MainViewModel{ Photo="pic3.png", Title = "JUST COPY", BackgroundColor= Color.Pink},
                 new MainViewModel{ Photo="pic6.png", Title = "NO PLUGINS", BackgroundColor= Color.Orange},
                 new MainViewModel{ Photo="pic7.png", Title = "FORMS 4.2", BackgroundColor= Color.Blue},
                 new MainViewModel{ Photo="pic10.png", Title = "FAST, NO BUGS", BackgroundColor= Color.Silver},
            };
            this.BindingContext = mainViewModel;
            pgCarousel.ItemsSource = mainViewModel;
        }



        public void Handle_Scrolled(object sender, ItemsViewScrolledEventArgs e)
        {
            var _currentIndex = e.CenterItemIndex;
            var widthCarousel = pgCarousel.Width;
            var posOffset = (widthCarousel * (_currentIndex + 1)) - (e.HorizontalOffset / ajustDevice);
            var pos = (((posOffset * depth) / widthCarousel) - depth);

            mainViewModel[e.LastVisibleItemIndex].Position = pos + depth;
            mainViewModel[_currentIndex].Position = pos;
            
        }

       


    }
}
