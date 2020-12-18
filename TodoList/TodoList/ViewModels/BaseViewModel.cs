using System.ComponentModel;
using System.Runtime.CompilerServices;
using TodoList.Annotations;

namespace TodoList.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        private bool _busy;
        
        public bool IsBusy
        {
            get => _busy;
            set
            {
                if (_busy == value) return;
                _busy = value;
                OnPropertyChanged();
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}