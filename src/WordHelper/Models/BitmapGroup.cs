using System;
using System.Collections.ObjectModel;
using MvvmCross.ViewModels;

namespace WordHelper.Models
{
    public class BitmapGroup : MvxViewModel
    {
        private ObservableCollection<BitmapItem> _images;


        public BitmapGroup(string path)
        {
            Images = new ObservableCollection<BitmapItem> {new BitmapItem(path)};
        }


        public int Width { protected set; get; }
        public int Height { protected set; get; }

        public ObservableCollection<BitmapItem> Images
        {
            set => SetProperty(ref _images, value);
            get => _images;
        }

        public RelayCommand AppendBitmapCommand => new RelayCommand(AppendBitmapCommand_Execute);

        public RelayCommand RemoveBitmapCommand => new RelayCommand(RemoveBitmapCommand_Execute);

        private void RemoveBitmapCommand_Execute(object obj)
        {
            throw new NotImplementedException();
        }

        private void AppendBitmapCommand_Execute(object obj)
        {
            if (obj is BitmapItem bitmapItem) Images.Remove(bitmapItem);
        }
    }
}