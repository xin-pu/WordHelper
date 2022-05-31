using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MvvmCross.ViewModels;

namespace WordHelper.Models
{
    public class BitmapGroupManager : MvxViewModel
    {
        public ObservableCollection<BitmapGroup> _bitmapGroups;


        public ObservableCollection<BitmapGroup> BitmapGroups
        {
            set => SetProperty(ref _bitmapGroups, value);
            get => _bitmapGroups;
        }


        public RelayCommand LoadCommand => new RelayCommand(LoadCommand_Execute);

        public RelayCommand CleanCommand => new RelayCommand(CleanCommand_Execute);

        public RelayCommand SaveCommand => new RelayCommand(SaveCommand_Execute);

        private void LoadCommand_Execute()
        {
            BitmapGroups = new ObservableCollection<BitmapGroup>();
            var dialog = new FolderBrowserDialog
            {
                Description = @"请选择Txt所在文件夹"
            };
            if (dialog.ShowDialog() != DialogResult.OK)
                return;
            var allFiles = GetImages(new DirectoryInfo(dialog.SelectedPath), "*.png", "*.jpg");
            BitmapGroups = new ObservableCollection<BitmapGroup>(allFiles.Select(f => new BitmapGroup(f.FullName)));
        }

        private void CleanCommand_Execute()
        {
            BitmapGroups.Clear();
        }

        private void SaveCommand_Execute()
        {
        }


        private FileInfo[] GetImages(DirectoryInfo dirPath, params string[] searchPatterns)
        {
            if (searchPatterns.Length <= 0) return null;


            var files = searchPatterns
                .SelectMany(pattern => dirPath.GetFiles(pattern, SearchOption.AllDirectories))
                .ToArray();

            return files;
        }
    }
}