using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace WPF.UILib.Controls.ViewModel
{
    public class WindowBase : NotifyChanged
    {

        #region 커맨드
        private ICommand? loadedEvent = null;
        public ICommand LoadedEvent { get => loadedEvent ?? (loadedEvent = new UserCommandWithParam(Loaded)); }



        private ICommand? dragMoveCommand = null;
        public ICommand DragMoveCommand => dragMoveCommand ?? (dragMoveCommand = new UserCommand(DragMove));

        private ICommand? minimizeCommand = null;
        public ICommand MinimizeCommand => minimizeCommand ?? (minimizeCommand = new UserCommand(Minimize));

        private ICommand? maxNormalizeCommand = null;
        public ICommand MaxNormalizeCommand => maxNormalizeCommand ?? (maxNormalizeCommand = new UserCommand(MaxNormalize));


        private ICommand? closeCommand = null;
        public ICommand CloseCommand => closeCommand ?? (closeCommand = new UserCommand(Close));



        private ICommand? confirmCommand = null;
        public ICommand ConfirmCommand => confirmCommand ?? (confirmCommand = new UserCommand(Confirm));

        private ICommand? cancelCommand { get; set; }
        public ICommand CancelCommand => cancelCommand ?? (cancelCommand = new UserCommand(Cancel));

        #endregion


        #region 전역변수
        public Window _this = null;
        #endregion


        /// <summary>
        /// 화면 로드 커맨드 함수
        /// </summary>
        /// <param name="sender"></param>
        public virtual void Loaded(object sender)
        {
            try
            {
                _this = (Window)sender;
            }
            catch { }

        }

        /// <summary>
        /// 화면 드래그 이동 커맨드 함수
        /// </summary>
        private void DragMove()
        {
            _this.DragMove();
        }



        /// <summary>
        /// 화면 최소화 커맨드 함수
        /// </summary>
        private void Minimize()
        {
            _this.WindowState = WindowState.Minimized;
        }

        /// <summary>
        /// 화면 최대화 또는 보통 커맨드 함수
        /// </summary>
        private void MaxNormalize()
        {
            if (_this.WindowState == WindowState.Maximized)
            {
                _this.WindowState = WindowState.Normal;                
            }
            else if (_this.WindowState == WindowState.Normal)
            {
                _this.WindowState = WindowState.Maximized;                
            }
        }



        /// <summary>
        /// 화면 닫기 커맨드 함수
        /// </summary>
        public virtual void Close()
        {
            _this.Close();
        }

        /// <summary>
        /// 팝업 화면 확인 커맨드 함수
        /// </summary>
        public virtual void Confirm()
        {            
            _this.DialogResult = true;
        }

        /// <summary>
        /// 팝업 화면 취소 커맨드 함수
        /// </summary>
        private void Cancel()
        {
            _this.DialogResult = false;
        }
    }
}
