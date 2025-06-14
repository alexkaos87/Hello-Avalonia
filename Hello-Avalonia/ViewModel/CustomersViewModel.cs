﻿using HelloAvalonia.Commands;
using HelloAvalonia.Data;
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
    public class CustomersViewModel : ViewModelBase
    {
        private int _customerId;

        private CustomerItemViewModel? _selectedCustomer;
        private NavigationSide _navigationSide;

        public CustomersViewModel()
        {
            AddCommand = new DelegateCommand(Add);
            DeleteCommand = new DelegateCommand(Delete, CanDelete);
            MoveNavigationCommand = new DelegateCommand(MoveNavigation);
            _customerId = 0;
        }

        public ObservableCollection<CustomerItemViewModel> Customers { get; } = new();

        public CustomerItemViewModel? SelectedCustomer
        {
            get => _selectedCustomer;
            set
            {
                _selectedCustomer = value;
                RaisePropertyChanged();
                RaisePropertyChanged(nameof(IsCustomerSelected)); // raise that IsCustomerSelected is changed
                DeleteCommand.RaiseCanExecuteChanged(); // raise CanExecuteCommand of DeleteCommand
            }
        }

        public bool IsCustomerSelected => SelectedCustomer is not null;

        public NavigationSide NavigationSide
        {
            get => _navigationSide;
            private set
            {
                _navigationSide = value;
                RaisePropertyChanged();
            }
        }

        public DelegateCommand AddCommand { get; } // it is used instead of events

        public DelegateCommand DeleteCommand { get; } // it is used instead of events

        public DelegateCommand MoveNavigationCommand { get; } // it is used instead of events

        public async override Task LoadAsync()
        {
            if (Customers.Any())
            {
                return;
            }

            await Task.Delay(10);

            Customers.Add(new(new Customer { FirstName = "Bob", LastName = "Black", Id = 1, IsDeveloper = true }));
            Customers.Add(new(new Customer { FirstName = "Jack", LastName = "White", Id = 2, IsDeveloper = true }));
            Customers.Add(new(new Customer { FirstName = "Alice", LastName = "Red", Id = 3, IsDeveloper = false }));
        }

        public async override Task SaveList()
        {
            await LoadAsync();

            var customers = new List<Customer>();
            foreach (var customer in Customers)
            {
                customers.Add(new Customer
                {
                    Id = customer.Id,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    IsDeveloper = customer.IsDeveloper
                });
            }

            var filePath = Path.Combine(Path.GetTempPath(), "customers.json");
            JsonHelper.ToFile(filePath, customers);
        }

        private void Add(object? parameter)
        {
            var customer = new Customer
            {
                FirstName = "Customer",
                Id = ++_customerId
            };
            var customerViewModel = new CustomerItemViewModel(customer);
            Customers.Add(customerViewModel);
            SelectedCustomer = customerViewModel;
        }

        private bool CanDelete(object? parameter) => IsCustomerSelected;

        private void Delete(object? parameter)
        {
            if (SelectedCustomer is not null)
            {
                Customers.Remove(SelectedCustomer);
                SelectedCustomer = null;
            }
        }

        private void MoveNavigation(object? parameter) => NavigationSide = NavigationSide == NavigationSide.Left ? NavigationSide.Right : NavigationSide.Left;
    }
}
