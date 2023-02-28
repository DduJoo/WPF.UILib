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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF.UILib.Demo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        


        public MainWindow()
        {
            InitializeComponent();          
        }

        public static readonly DependencyProperty IsDarkProperty = DependencyProperty.Register("IsDark", typeof(bool), typeof(MainWindow), new PropertyMetadata(false, OnIsDarkChanged));

        public bool IsDark
        {
            get => (bool)GetValue(IsDarkProperty);
            set => SetValue(IsDarkProperty, value);
        }

        private static void OnIsDarkChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((MainWindow)d).ChangeColor((bool)e.OldValue);
        }
     
        private void ChangeColor(bool p_bool)
        {
            ResourceLocator.SetColorScheme(Application.Current.Resources, p_bool ? ResourceLocator.LightColorScheme : ResourceLocator.DarkColorScheme);
       }
    }
}
