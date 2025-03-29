using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System;

namespace HelloAvalonia.ViewModel.Bases
{
    public class ValidationViewModelBase : ViewModelBase, INotifyDataErrorInfo
    {
        private readonly Dictionary<string, List<string>> _errorsByPropertyName = new();

        public bool HasErrors => _errorsByPropertyName.Count != 0;

        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

        public System.Collections.IEnumerable GetErrors(string? propertyName) =>
            propertyName is not null && _errorsByPropertyName.TryGetValue(propertyName, out var value) ? value : Enumerable.Empty<string>();

        protected virtual void OnErrorsChanged(DataErrorsChangedEventArgs args) => ErrorsChanged?.Invoke(this, args);

        protected void AddError(in string error, [CallerMemberName] in string? propertyName = null)
        {
            if (propertyName is null)
                return;

            if (!_errorsByPropertyName.TryGetValue(propertyName, out var value))
            {
                value = new List<string>();
                _errorsByPropertyName[propertyName] = value;
            }

            if (!value.Contains(error))
            {
                value.Add(error);
                OnErrorsChanged(new DataErrorsChangedEventArgs(propertyName));
                RaisePropertyChanged(nameof(HasErrors));
            }
        }

        protected void ClearErrors([CallerMemberName] in string? propertyName = null)
        {
            if (propertyName is null)
                return;

            if (_errorsByPropertyName.Remove(propertyName))
            {
                OnErrorsChanged(new DataErrorsChangedEventArgs(propertyName));
                RaisePropertyChanged(nameof(HasErrors));
            }
        }
    }
}
