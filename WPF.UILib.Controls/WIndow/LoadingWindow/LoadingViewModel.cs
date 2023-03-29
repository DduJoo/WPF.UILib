using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPF.UILib.Controls.ViewModel;

namespace WPF.UILib.Controls.WIndow.LoadingWindow
{
    public class LoadingViewModel : WindowBase
    {
        
        private Window? _this = null;

        private string message = string.Empty;
        public string Message { get => message; set => SetProperty(ref message, value); }

        private string realTimeMessage = string.Empty;
        public string RealTimeMessage { get => realTimeMessage; set => SetProperty(ref realTimeMessage, value); }

        public LoadingViewModel(){}
        public LoadingViewModel(string p_message)
        {
            Message = p_message;
        }

        public override void Loaded(object sender)
        {
            base.Loaded(sender);
            

            _this = base._this;
            _this.Hide();
            _this.Height = _this.Owner.Height - 36;
            _this.Width = _this.Owner.Width;

            _this.Left = _this.Owner.Left;
            _this.Top = _this.Owner.Top + 36;
            _this.Show();

        }

        public void SetRealTimeMessage(string p_message)
        {
            RealTimeMessage = p_message;
        }

    }
}
