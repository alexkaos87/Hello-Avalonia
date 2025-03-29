using Avalonia.Controls;
using Avalonia.Interactivity;
using HelloAvalonia.ViewModel;

namespace HelloAvalonia;

public partial class MainWindow : Window
{
    private MainViewModel _viewModel;

    // this declaration is required to run designer
    public MainWindow()
    {
        InitializeComponent();

        _viewModel = new MainViewModel();
    }

    public MainWindow(MainViewModel viewModel) : this()
    {
        _viewModel = viewModel;
        DataContext = _viewModel;

        Loaded += LoadedHandler;
    }

    private async void LoadedHandler(object? sender, RoutedEventArgs e) =>
        await _viewModel.LoadAsync();
}