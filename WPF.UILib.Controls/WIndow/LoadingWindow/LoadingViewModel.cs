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

        public override void Loaded(object sender)
        {
            base.Loaded(sender);

            _this = base._this;

            _this.Height = _this.Owner.Height;
            _this.Width = _this.Owner.Width;

            _this.Left = _this.Owner.Left;
            _this.Top = _this.Owner.Top;
        }
    }
}
