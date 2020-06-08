using Hardcodet.Wpf.TaskbarNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

namespace MouseCursorSpeedChanger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // ウィンドウいらんので消す
            Hide();
        }

        /// <summary>
        /// マウスのカーソルの速度変更関数。
        /// </summary>
        /// <param name="speed">移動速度。マウスで5、タッチパッドで10がいい？</param>
        private void SetCursorSpeed(int speed) => SystemParametersInfo(SPI_SETMOUSESPEED, 0, new IntPtr(speed), 0);

        private void MenuItemClickExit(object sender, RoutedEventArgs e) => Application.Current.Shutdown();

        private void MenuItemClickMouse(object sender, RoutedEventArgs e) => SetCursorSpeed(5);

        private void MenuItemClickTouchPad(object sender, RoutedEventArgs e) => SetCursorSpeed(10);

        /** マウスのカーソルの速度変更関係 */
        public const uint SPI_GETMOUSESPEED = 0x70;
        public const uint SPI_SETMOUSESPEED = 0x71;

        [DllImport("User32.dll")]
        static extern Boolean SystemParametersInfo(
            UInt32 uiAction,
            UInt32 uiParam,
            IntPtr pvParam,
            UInt32 fWinIni);

    }
}
