using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Xamarin.Forms;

namespace XFTest
{
    public class CalendarTest : ContentPage
    {
        private readonly Label _monthLabel;

        private DateTime _currentDate;

        private readonly Grid _dateGrid;

        public CalendarTest()
        {
            var layout = new StackLayout
            {
                Orientation = StackOrientation.Vertical
            };

            _monthLabel = new Label
            {
                XAlign = TextAlignment.Center,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof (Label)),
                FontAttributes = FontAttributes.Bold
            };

            var nextMonthBtn = new Button
            {
                Image = "arrowright.png"
            };
            nextMonthBtn.Clicked += NextMonthBtnOnClicked;

            var lastMonthBtn = new Button
            {
                Image = "arrowleft.png"
            };
            lastMonthBtn.Clicked += LastMonthBtnOnClicked;

            var calendarGrid = new Grid
            {
                ColumnSpacing = 0,
                ColumnDefinitions =
                {
                    new ColumnDefinition{Width = new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition{Width = new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition{Width = new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition{Width = new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition{Width = new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition{Width = new GridLength(1, GridUnitType.Star)},
                    new ColumnDefinition{Width = new GridLength(1, GridUnitType.Star)}
                }
            };

            _dateGrid = new Grid
            {
                ColumnSpacing = 0,
                RowSpacing = 0
            };

            string[] dayNames = {"Mo", "Di", "Mi", "Do", "Fr", "Sa", "So"};

            var dayCounter = 0;

            foreach (var day in dayNames)
            {
                calendarGrid.Children.Add(new Label
                {
                    Text = day,
                    BackgroundColor = Color.Gray,
                    XAlign = TextAlignment.Center
                }, dayCounter, 0); 
                dayCounter++;
            }

            _currentDate = DateTime.Today;

            _monthLabel.Text = _currentDate.ToString("MMMM", new CultureInfo("de-DE")) + " " + _currentDate.ToString("yyyy");

            FillGrid();

            var headerStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Children =
                {
                    lastMonthBtn,
                    _monthLabel,
                    nextMonthBtn
                }
            };
            
            layout.Children.Add(headerStack);
            layout.Children.Add(calendarGrid);
            layout.Children.Add(_dateGrid);

            Content = layout;
        }

        private async void LastMonthBtnOnClicked(object sender, EventArgs eventArgs)
        {
            _currentDate = _currentDate.AddMonths(-1);
            _monthLabel.Text = _currentDate.ToString("MMMM") + " " + _currentDate.ToString("yyyy");
            using (UserDialogs.Instance.Loading(""))
            {
                await Task.Delay(250);
                await FillGrid();
                await Task.Delay(250);
            }
        }

        private async void NextMonthBtnOnClicked(object sender, EventArgs eventArgs)
        {
            _currentDate = _currentDate.AddMonths(1);
            _monthLabel.Text = _currentDate.ToString("MMMM") + " " + _currentDate.ToString("yyyy");
            using (UserDialogs.Instance.Loading(""))
            {
                await Task.Delay(250);
                await FillGrid();
                await Task.Delay(250);
            }
        }

        private async Task<bool> FillGrid()
        {
            var rowCounter = 0;
            var columnCounter = 0;

            _dateGrid.Children.Clear();
            if (_dateGrid.Children.Count != 0)
            {
                _dateGrid.Children.Clear();
            }

            var firstDay = new DateTime(_currentDate.Year, _currentDate.Month, 1);
            
            var culture = new CultureInfo("en-US");

            if (firstDay.ToString("dddd", culture) == "Monday")
            {
                ////No change needed
            }
            else if (firstDay.ToString("dddd", culture) == "Tuesday")
            {
                columnCounter++;
            }
            else if (firstDay.ToString("dddd", culture) == "Wednesday")
            {
                columnCounter += 2;
            }
            else if (firstDay.ToString("dddd", culture) == "Thursday")
            {
                columnCounter += 3;
            }
            else if (firstDay.ToString("dddd", culture) == "Friday")
            {
                columnCounter += 4;
            }
            else if (firstDay.ToString("dddd", culture) == "Saturday")
            {
                columnCounter += 5;
            }
            else if (firstDay.ToString("dddd", culture) == "Sunday")
            {
                columnCounter += 6;
            }
            await Task.Run(() =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    for (var i = 0; i < DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month); i++)
                    {
                        var color = Color.Transparent;

                        if (_currentDate.Month == DateTime.Today.Month && (i + 1) == DateTime.Today.Day)
                        {
                            color = Color.FromHex("#add8e6");
                        }

                        var dateButton = new DateButton
                        {
                            Text = (i + 1).ToString(),
                            BackgroundColor = color,
                            BorderWidth = 1,
                        };
                        dateButton.Clicked += (sender, e) =>
                        {
                            DateClicked(sender);
                        };

                        _dateGrid.Children.Add(dateButton,columnCounter,rowCounter);

                        if (columnCounter == 6)
                        {
                            rowCounter++;
                            columnCounter = 0;
                        }
                        else
                        {
                            columnCounter++;
                        }
                    }
                });
            });

            return true;
        }

        private void DateClicked(object sender)
        {
            foreach (var button in _dateGrid.Children.Where(button => ((DateButton) button).IsSelected))
            {
                ((DateButton) button).IsSelected = false;
            }

            var datebutton = ((DateButton) sender);
            datebutton.IsSelected = true;
            var selectedDate = new DateTime(_currentDate.Year, _currentDate.Month, int.Parse(datebutton.Text));
            UserDialogs.Instance.Alert(selectedDate.ToString("dd.MM.yyyy"));
        }
    }
}
