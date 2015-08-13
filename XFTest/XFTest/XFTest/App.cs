using System;
using System.Diagnostics;

using Xamarin.Forms;
using XFtest;

namespace XFTest
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            MainPage = new NavigationPage(new CalendarTest());
        }
    }
}
