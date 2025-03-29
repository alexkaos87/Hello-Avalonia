using HelloAvalonia.ViewModel.Bases;
using HelloAvalonia.ViewModel.Items;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace HelloAvalonia.ViewModel
{
    public class ProductsViewModel : ViewModelBase
    {
        public ObservableCollection<ProductItemViewModel> Products { get; } = new();

        public override async Task LoadAsync()
        {
            if (Products.Any())
            {
                return;
            }

            await Task.Delay(10);
            // TODO : load products
        }

        public async override Task SaveList()
        {
            await LoadAsync();

            // TODO : save products
        }
    }
}
