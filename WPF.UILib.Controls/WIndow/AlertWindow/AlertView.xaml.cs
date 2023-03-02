using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static WPF.UILib.Controls.WIndow.AlertWindow.AlertViewModel;

namespace WPF.UILib.Controls.WIndow.AlertWindow
{
    /// <summary>
    /// AlretView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class AlertView : Window
    {
        public AlertView()
        {
            InitializeComponent();
        }
        private void Alert_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        public static bool ShowMessage(string p_mainMessage, AlertType alertType, string p_subMessage = "")
        {
            bool ret = false;
            try
            {
                AlertView instance = new AlertView();
                instance.DataContext = new AlertViewModel(p_mainMessage, alertType, p_subMessage);
                ret = (bool)instance.ShowDialog();
                instance = null;
            }
            catch (System.Exception ex)
            {

            }

            return ret;
        }
    }
}
