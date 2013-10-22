using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;


namespace antiSpy
{
    public partial class fAntiSpy : Form
    {
        Bitmap bmpScreenShot = new Bitmap(Screen.PrimaryScreen.Bounds.Width,
                          Screen.PrimaryScreen.Bounds.Height,
                          System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        Graphics gScreenShot;

        string pathManual;
        string pathAuto;
        string pathLan;
        bool mode; //true - Auto, false - Manual

        public fAntiSpy()
        {
            InitializeComponent();

            gScreenShot = Graphics.FromImage(bmpScreenShot);

            //TODO заменить на настройки
            pathManual = Properties.Settings.Default.pathManual;
            pathAuto = Properties.Settings.Default.pathAuto;
            pathLan = Properties.Settings.Default.pathLan;
            mode = Properties.Settings.Default.mode;
            timer.Interval = Properties.Settings.Default.timer * 1000;
            numTimerPref.Value = Properties.Settings.Default.timer;

            //TODO заменить на настройки
            if (mode)
            {
                autoTrayMenuItem.Checked = true;
                btnAuto.Enabled = false;
            }
            else
            {
                manualTrayMenuItem.Checked = true;
                btnManual.Enabled = false;
            }

            //событие нажатия кнопки
            HotKeyManager.RegisterHotKey(Keys.End, KeyModifiers.Alt);
            HotKeyManager.HotKeyPressed += new EventHandler<HotKeyEventArgs>(gkh_KeyDown);

            //сделать иконку невидимой
            trayIcon.Visible = true;
            //меню иконки в трее
            trayIcon.ContextMenuStrip = trayMenu;

            //вкл таймер
            timer.Enabled = true;
        }

        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            trayIcon.Visible = false;
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
        }

        private void fAntiSpy_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                trayIcon.Visible = true;
            }
        }

        //перехват кнопки
        private void gkh_KeyDown(object sender, HotKeyEventArgs e)
        {
            if (!mode)
            {
                makeScrShot();

                //сохранить картинку с именем текущей даты
                bmpScreenShot.Save(pathManual + DateTime.Now.ToString("yyMMdd_HHmmss") + ".jpg", ImageFormat.Jpeg);
                lstLog.Items.Add("press btn");
            }
        }

        //тик таймера
        private void timer_Tick(object sender, EventArgs e)
        {
            lstLog.Items.Add("tic");

            if (mode)
            {
                makeScrShot();

                //сохранить картинку с именем компа 
                bmpScreenShot.Save(pathAuto + Environment.MachineName + ".jpg", ImageFormat.Jpeg);
            }
            //переместить файл
            fileMove();
        }

        //сделать новый скрин в bmpScreenShot
        private void makeScrShot()
        {
            gScreenShot.CopyFromScreen(Screen.PrimaryScreen.Bounds.X,
               Screen.PrimaryScreen.Bounds.Y,
               0, 0,
               Screen.PrimaryScreen.Bounds.Size,
               CopyPixelOperation.SourceCopy);

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Image = bmpScreenShot;
        }

        //переместить файл
        private void fileMove()
        {
            if (mode)
            {
                if (File.Exists(pathAuto + Environment.MachineName + ".jpg"))
                {
                    File.Delete(pathLan + Environment.MachineName + ".jpg");
                    File.Move(pathAuto + Environment.MachineName + ".jpg", pathLan + Environment.MachineName + ".jpg");
                    lstLog.Items.Add("move auto");
                }
            }
            else
            {
                string[] allFiles = Directory.GetFiles(pathManual);
                if (allFiles.GetLength(0) > 0)
                {
                    File.Delete(pathLan + Environment.MachineName + ".jpg");
                    File.Move(allFiles[0], pathLan + Environment.MachineName + ".jpg");
                    lstLog.Items.Add("move manually");
                }
            }
        }

        # region mode switch

        private void closeTrayMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void switchAuto(object sender, EventArgs e)
        {
            if (!mode)
            {
                manualTrayMenuItem.Checked = false;
                autoTrayMenuItem.Checked = true;
                btnAuto.Enabled = false;
                btnManual.Enabled = true;
                mode = true;
                Properties.Settings.Default.mode = true;
                Properties.Settings.Default.Save();
            }
        }

        private void switchManual(object sender, EventArgs e)
        {
            if (mode)
            {
                manualTrayMenuItem.Checked = true;
                autoTrayMenuItem.Checked = false;
                btnAuto.Enabled = true;
                btnManual.Enabled = false;
                mode = false;
                Properties.Settings.Default.mode = false;
                Properties.Settings.Default.Save();
            }
        }
        # endregion

        private void numTimerPref_ValueChanged(object sender, EventArgs e)
        {
            timer.Interval = (int)numTimerPref.Value * 1000;
            Properties.Settings.Default.timer = (int)numTimerPref.Value;
            Properties.Settings.Default.Save();
        }
    }

    #region hotkey
    public class HotKeyManager
    {
        public static event EventHandler<HotKeyEventArgs> HotKeyPressed;

        public static int RegisterHotKey(Keys key, KeyModifiers modifiers)
        {
            int id = System.Threading.Interlocked.Increment(ref _id);
            RegisterHotKey(_wnd.Handle, id, (uint)modifiers, (uint)key);
            return id;
        }

        public static bool UnregisterHotKey(int id)
        {
            return UnregisterHotKey(_wnd.Handle, id);
        }

        protected static void OnHotKeyPressed(HotKeyEventArgs e)
        {
            if (HotKeyManager.HotKeyPressed != null)
            {
                HotKeyManager.HotKeyPressed(null, e);
            }
        }

        private static MessageWindow _wnd = new MessageWindow();

        private class MessageWindow : Form
        {
            protected override void WndProc(ref Message m)
            {
                if (m.Msg == WM_HOTKEY)
                {
                    HotKeyEventArgs e = new HotKeyEventArgs(m.LParam);
                    HotKeyManager.OnHotKeyPressed(e);
                }

                base.WndProc(ref m);
            }

            private const int WM_HOTKEY = 0x312;
        }

        [DllImport("user32")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private static int _id = 0;
    }


    public class HotKeyEventArgs : EventArgs
    {
        public readonly Keys Key;
        public readonly KeyModifiers Modifiers;

        public HotKeyEventArgs(Keys key, KeyModifiers modifiers)
        {
            this.Key = key;
            this.Modifiers = modifiers;
        }

        public HotKeyEventArgs(IntPtr hotKeyParam)
        {
            uint param = (uint)hotKeyParam.ToInt64();
            Key = (Keys)((param & 0xffff0000) >> 16);
            Modifiers = (KeyModifiers)(param & 0x0000ffff);
        }
    }

    [Flags]
    public enum KeyModifiers
    {
        Alt = 1,
        Control = 2,
        Shift = 4,
        Windows = 8,
        NoRepeat = 0x4000
    }
    #endregion
}
