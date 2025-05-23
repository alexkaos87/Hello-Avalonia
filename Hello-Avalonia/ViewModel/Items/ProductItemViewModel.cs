using HelloAvalonia.Model;
using HelloAvalonia.ViewModel.Bases;

namespace HelloAvalonia.ViewModel.Items
{
    public class ProductItemViewModel : ViewModelBase
    {
        private readonly Product _model;

        public ProductItemViewModel(Product model) => _model = model;

        public string? Name => _model.Name;

        public string? Description => _model.Description;
        
        public Product Product
        {
            get
            {
                Product clone = new()
                {
                    Name = _model.Name,
                    Description = _model.Description
                };
                return clone;
            }
        }
    }
}
