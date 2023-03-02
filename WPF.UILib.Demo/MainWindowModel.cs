using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF.UILib.Controls;
using WPF.UILib.Controls.ViewModel;
using WPF.UILib.Controls.WIndow.LoadingWindow;

namespace WPF.UILib.Demo
{
    public class MainWindowModel : WindowBase
    {

        private ICommand? rowAddEvent = null;
        public ICommand RowAddEvent { get => rowAddEvent ?? (rowAddEvent = new UserCommand(RowAdd)); }

        private ICommand? changedEvent = null;
        public ICommand ChangedEvent { get => changedEvent ?? (changedEvent = new UserCommand(Changed)); }

        private ICommand? popUpOpenEvent = null;
        public ICommand PopUpOpenEvent { get => popUpOpenEvent ?? (popUpOpenEvent = new UserCommand(PopUpOpen)); }

        private ICommand? loadingOpenEvent = null;
        public ICommand LoadingOpenEvent { get => loadingOpenEvent ?? (loadingOpenEvent = new UserCommand(LoadingOpen)); }


        private List<string> themesList = new List<string>();        
        public List<string> ThemesList { get => themesList; set => SetProperty(ref themesList, value); }


        private string selectedString = string.Empty;
        public string SelectedString { get => selectedString; set => SetProperty(ref selectedString, value); }

        private DataTable dTable = new DataTable();
        public DataTable DTable { get => dTable; set => SetProperty(ref dTable, value); }


        private ObservableCollection<string> list = new ObservableCollection<string>();
        public ObservableCollection<string> Lis { get => list; set => SetProperty(ref list, value, "Lis"); }


     


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

        private void PopUpOpen()
        {
            PopupView popupView = new PopupView();
            popupView.ShowDialog();
        }

        private void RowAdd()
        {
            Lis.Add("aaa");
        }

        private void LoadingOpen()
        {
            ShowLoading();
        }

           
        private async Task ShowLoading()
        {
            LoadingView loadingView = new LoadingView(base._this);
            loadingView.Show();

            await Task.Delay(3000);

            loadingView.Close();
        }
    }
}
