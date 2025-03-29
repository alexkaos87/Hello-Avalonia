using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace HelloAvalonia.ViewModel.Bases
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] in string? propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public virtual Task LoadAsync() => Task.CompletedTask;

        public virtual Task SaveList() => Task.CompletedTask;
    }
}