using System;
using System.Collections.Generic;
using System.Data;
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

        private DataTable dTable = new DataTable();
        public DataTable DTable { get => dTable; set => SetProperty(ref dTable, value); }



        public MainWindowModel()
        {
            foreach (ResourceLocator.ThemeList theme in Enum.GetValues(typeof(ResourceLocator.ThemeList)))
            {
                ThemesList.Add(theme.ToString());
            }

            DataTable dt = new DataTable();
            dt.Columns.Add("First");
            dt.Columns.Add("Seconds");
            dt.Columns.Add("Third");
            dt.Columns.Add("Fourth");


            dt.Rows.Add("1", "2", "3", "4");
            dt.Rows.Add("11", "22", "33", "44");
            dt.Rows.Add("111", "222", "333", "444");
            dt.Rows.Add("1111", "2222", "3333", "4444");
            dt.Rows.Add("11111", "22222", "33333", "44444");
            dt.Rows.Add("1111", "2222", "3333", "4444");
            dt.Rows.Add("111", "222", "333", "444");
            dt.Rows.Add("11", "22", "33", "44");
            dt.Rows.Add("1", "2", "3", "4");

            DTable = dt.Copy();
        }

        private void Changed()
        {
            ResourceLocator.SetColorScheme(Application.Current.Resources, SelectedString);
        }
    }
}
