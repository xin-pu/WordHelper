using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Input;
using MvvmCross.ViewModels;

namespace WordHelper.Models
{
    public class BitmapItem : MvxViewModel
    {
        private Bitmap _bitmap;
        private string _name;
        private string _path;
        private DateTime _updateTime;

        public BitmapItem(string path)
        {
            Path = path;

            var fileInfo = new FileInfo(path);
            Name = fileInfo.Name;
            UpdateTime = fileInfo.LastWriteTime;
        }

        public string Path
        {
            protected set => SetProperty(ref _path, value);
            get => _path;
        }

        public Bitmap Bitmap
        {
            protected set => SetProperty(ref _bitmap, value);
            get => _bitmap;
        }

        public string Name
        {
            protected set => SetProperty(ref _name, value);
            get => _name;
        }

        public DateTime UpdateTime
        {
            protected set => SetProperty(ref _updateTime, value);
            get => _updateTime;
        }

        public int Width => Bitmap.Width;
        public int Height => Bitmap.Height;


        public ICommand Command => new RelayCommand(() => { });

        public override string ToString()
        {
            var str = new StringBuilder();
            str.AppendLine(Name);
            str.AppendLine($"Path:{Path}");
            str.AppendLine($"UpdateTime:{UpdateTime:D}");
            str.AppendLine($"Size:{Height},{Width}");
            return str.ToString();
        }
    }
}