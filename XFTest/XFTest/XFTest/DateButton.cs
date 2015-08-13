using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFTest
{
    public class DateButton : Button
    {
        public static BindableProperty IsSelectedProperty = BindableProperty.Create<DateButton, bool>(p => p.IsSelected, false);

        public bool IsSelected
        {
            get { return (bool) GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            BackgroundColor = IsSelected ? Color.Gray : Color.Transparent;
        }
    }
}
