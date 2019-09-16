using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace Parallax
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public string Title { get; set; }
        public Color BackgroundColor { get; set; }
        public string Photo { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        private double _position;
        public double Position
        {
            get { return _position; }
            set
            {
                if (_position != value)
                {
                    _position = value;
                    OnPropertyChanged();
                }
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
