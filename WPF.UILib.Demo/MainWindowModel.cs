using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using WPF.UILib.Controls;
using WPF.UILib.Controls.ViewModel;

namespace WPF.UILib.Demo
{
    public class MainWindowModel : WindowBase
    {        
        private ICommand? changedEvent = null;
        public ICommand ChangedEvent { get => changedEvent ?? (changedEvent = new UserCommand(Changed)); }


        private List<string> themesList = new List<string>();        
        public List<string> ThemesList { get => themesList; set => SetProperty(ref themesList, value); }


        private string selectedString = string.Empty;
        public string SelectedString { get => selectedString; set => SetProperty(ref selectedString, value); }


        public MainWindowModel()
        {
            foreach (ResourceLocator.ThemeList theme in Enum.GetValues(typeof(ResourceLocator.ThemeList)))
            {
                ThemesList.Add(theme.ToString());
            }
        }

        private void Changed()
        {
            ResourceLocator.SetColorScheme(Application.Current.Resources, SelectedString);
        }
    }
}
