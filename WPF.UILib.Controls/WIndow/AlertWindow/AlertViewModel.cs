using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace WPF.UILib.Controls.WIndow.AlertWindow
{
    public class AlertViewModel : NotifyChanged
    {
        public enum AlertType { OK, QUESTION, WARNING, ERROR, INFORMATION };

                
        private ICommand? yButtonClickCommand = null;
        public ICommand YButtonClickCommand { get => yButtonClickCommand ?? (yButtonClickCommand = new UserCommandWithParam(YButtonClick)); }

        private ICommand? nButtonClickCommand = null;
        public ICommand NButtonClickCommand { get => nButtonClickCommand ?? (nButtonClickCommand = new UserCommandWithParam(NButtonClick)); }


        private Visibility cancleButtonVisiblity;
       
        public Visibility CancleButtonVisiblity { get => cancleButtonVisiblity; set => SetProperty(ref cancleButtonVisiblity, value); }

        private string typeImage;
        public string TypeImage { get => typeImage; set => SetProperty(ref typeImage, value); }

        private string mainMessage;
        public string MainMessage { get => mainMessage; set => SetProperty(ref mainMessage, value); }

        private string subMessage;
        public string SubMessage { get => subMessage; set => SetProperty(ref subMessage, value); }

        private Window _this = null;

        public AlertViewModel()
        {

        }
        public AlertViewModel(string p_mainMessage, AlertType alertType, string p_subMessage)
        {                        
            MainMessage = p_mainMessage;
            if (!string.IsNullOrEmpty(p_subMessage))
            {
                SubMessage = "* " + p_subMessage;
            }
            else
            {
                SubMessage = "";
            }

            switch (alertType)
            {
                case AlertType.OK:
                    TypeImage = "/Resources/ic_check.png";
                    CancleButtonVisiblity = Visibility.Collapsed;
                    break;
                case AlertType.QUESTION:
                    TypeImage = "/Resources/ic_question.png";
                    CancleButtonVisiblity = Visibility.Visible;
                    break;
                case AlertType.WARNING:
                    TypeImage = "/Resources/ic_warning.png";
                    CancleButtonVisiblity = Visibility.Collapsed;
                    break;
                case AlertType.ERROR:
                    TypeImage = "/Resources/ic_error.png";
                    CancleButtonVisiblity = Visibility.Collapsed;
                    break;
                case AlertType.INFORMATION:
                    TypeImage = "/Resources/ic_information.png";
                    CancleButtonVisiblity = Visibility.Collapsed;
                    break;
            }
        }


        private void YButtonClick(object sender)
        {
            _this = (Window)sender;
            _this.DialogResult = true;
        }

        private void NButtonClick(object sender)
        {
            _this = (Window)sender;
            _this.DialogResult = false;
        }
    }
}
