using HelloAvalonia.Commands;
using HelloAvalonia.ViewModel.Bases;
using System.Threading.Tasks;

namespace HelloAvalonia.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase? _selectedViewModel;

        public MainViewModel()
        {
            SelectViewModelCommand = new(SelectViewModel);
            SaveCollectionCommand = new(SaveCollection);
        }

        public ViewModelBase? SelectedViewModel
        {
            get => _selectedViewModel;
            set
            {
                _selectedViewModel = value;
                RaisePropertyChanged();
            }
        }

        public DelegateCommand SelectViewModelCommand { get; }

        public DelegateCommand SaveCollectionCommand { get; }

        public async override Task LoadAsync()
        {
            if (SelectedViewModel is not null)
                await SelectedViewModel.LoadAsync();
        }

        private async void SelectViewModel(object? parameter)
        {
            SelectedViewModel = parameter as ViewModelBase;
            await LoadAsync();
        }

        private async void SaveCollection(object? parameter)
        {
            if (parameter is ViewModelBase viewModel)
                await viewModel.SaveList();
        }
    }
}