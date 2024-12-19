using Csla;
using System;
using System.Threading.Tasks;

namespace CslaAspMvc.Models
{
    [Serializable]
    public class PersonEdit : BusinessBase<PersonEdit>
    {
        public static readonly PropertyInfo<string> NameProperty = RegisterProperty<string>(nameof(Name));
        public string Name
        {
            get => GetProperty(NameProperty);
            set => SetProperty(NameProperty, value);
        }

        [Create][Fetch]
        private async Task Cretch(string name)
        {
            LoadProperty(NameProperty, name);
            await BusinessRules.CheckRulesAsync();
        }
    }
}