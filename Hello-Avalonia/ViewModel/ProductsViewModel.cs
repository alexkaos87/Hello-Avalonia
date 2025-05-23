using HelloAvalonia.Commands;
using HelloAvalonia.Model;
using HelloAvalonia.ViewModel.Bases;
using HelloAvalonia.ViewModel.Items;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HelloAvalonia.ViewModel
{
    public class ProductsViewModel : ViewModelBase
    {
        public ObservableCollection<ProductItemViewModel> Products { get; } = new();

        public ProductsViewModel()
        {
        }

        public override async Task LoadAsync()
        {
            if (Products.Any())
            {
                return;
            }

            await Task.Delay(10);

            Products.Add(new(new Product { Name = "p1", Description = "This is the first product" }));
            Products.Add(new(new Product { Name = "p2", Description = "This is the second product" }));
            Products.Add(new(new Product { Name = "p3", Description = "This is the third product" }));
            Products.Add(new(new Product { Name = "p4", Description = "This is the forth product" }));
        }

        public async override Task SaveList()
        {
            await LoadAsync();

            var products = new List<Product>();
            foreach (var product in Products)
            {
                products.Add(new Product
                {
                    Name = product.Name,
                    Description = product.Description
                });
            }

            var filePath = Path.Combine(Path.GetTempPath(), "products.json");
            JsonHelper.ToFile(filePath, products);
        }
    }
}
