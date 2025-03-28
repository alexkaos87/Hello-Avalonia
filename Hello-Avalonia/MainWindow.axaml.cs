using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Hello_Avalonia;

public partial class MainWindow : Window
{
    private readonly MainViewModel _viewModel;

    public MainWindow(MainViewModel viewModel)
    {
        InitializeComponent();

        _viewModel = viewModel;
        DataContext = _viewModel;

        Loaded += LoadedHandler;
    }

    private async void LoadedHandler(object? sender, RoutedEventArgs e) =>
        await _viewModel.LoadAsync();
}