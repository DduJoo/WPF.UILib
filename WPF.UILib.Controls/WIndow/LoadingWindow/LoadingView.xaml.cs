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

namespace WPF.UILib.Controls.WIndow.LoadingWindow
{
    /// <summary>
    /// LoadingView.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class LoadingView : Window
    {
        /// <summary>
        /// 전체 화면 로딩
        /// </summary>
        /// <param name="p_Owner">로딩창을 호출하는 부모창</param>
        public LoadingView(Window p_Owner, string p_message)
        {
            InitializeComponent();
            this.Owner = p_Owner;
            this.DataContext = new LoadingViewModel(p_message);
        }
    }
}
