using WordHelper.Models;

namespace WordHelper
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            BitmapGroupManager = new BitmapGroupManager();
            DataContext = BitmapGroupManager;
        }

        public BitmapGroupManager BitmapGroupManager { set; get; }
    }
}