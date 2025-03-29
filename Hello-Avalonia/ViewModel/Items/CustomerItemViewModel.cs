using HelloAvalonia.Model;
using HelloAvalonia.ViewModel.Bases;

namespace HelloAvalonia.ViewModel.Items
{
    public class CustomerItemViewModel : ValidationViewModelBase
    {
        private readonly Customer _model;

        public CustomerItemViewModel(Customer model) => _model = model;

        public int Id => _model.Id;

        public string? FirstName
        {
            get => _model.FirstName;
            set
            {
                _model.FirstName = value;
                RaisePropertyChanged();

                if (string.IsNullOrEmpty(_model.FirstName))
                {
                    AddError("First Name is required");
                }
                else
                {
                    ClearErrors();
                }
            }
        }

        public string? LastName
        {
            get => _model.LastName;
            set
            {
                _model.LastName = value;
                RaisePropertyChanged();

                if (string.IsNullOrEmpty(_model.LastName))
                {
                    AddError("Last Name is required");
                }
                else
                {
                    ClearErrors();
                }
            }
        }

        public bool IsDeveloper
        {
            get => _model.IsDeveloper;
            set
            {
                _model.IsDeveloper = value;
                RaisePropertyChanged();
            }
        }

        public Customer Customer
        {
            get
            {
                Customer clone = new()
                {
                    FirstName = _model.FirstName,
                    LastName = _model.LastName,
                    IsDeveloper = _model.IsDeveloper,
                    Id = _model.Id
                };
                return clone;
            }
        }
    }
}
