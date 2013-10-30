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
        string pathLan;
        bool mode = true; //true - Auto, false - Manual

        public fAntiSpy()
        {
            InitializeComponent();

            gScreenShot = Graphics.FromImage(bmpScreenShot);

            //настройки в поля
            applyPref();

            //событие нажатия кнопки
            HotKeyManager.RegisterHotKey(Keys.End, KeyModifiers.Alt);
            HotKeyManager.HotKeyPressed += new EventHandler<HotKeyEventArgs>(gkh_KeyDown);

            //вкл таймер
            timer.Enabled = true;
        }

        #region всякие настройки формы

        //загрузка формы
        private void fAntiSpy_Load(object sender, EventArgs e)
        {
            autoTrayMenuItem.Checked = true;
            btnAuto.Enabled = false;

            this.WindowState = FormWindowState.Minimized;
        }

        //закрытие формы
        private void fAntiSpyClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.WindowState = FormWindowState.Minimized;
        }

        //выход
        //TODO чето он кривой
        private void closeTrayMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void trayIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
            }

            else if (WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Minimized;
            }
        }

        private void fAntiSpy_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                //timer.Start();
            }
            else if (WindowState == FormWindowState.Normal)
            {
                this.ShowInTaskbar = true;
                //timer.Stop();
            }
        }

        #endregion

        #region основное

        //настройки в поля
        private void applyPref()
        {
            pathManual = Properties.Settings.Default.pathManual;
            pathLan = Properties.Settings.Default.pathLan;
            numTimerPref.Value = Properties.Settings.Default.timer;

            tbManualPath.Text = pathManual;
            tbLanPath.Text = pathLan;

            timer.Interval = Properties.Settings.Default.timer * 60000; //60000
        }

        //перехват кнопки
        private void gkh_KeyDown(object sender, HotKeyEventArgs e)
        {
            if (!mode)
            {
                makeScrShot();
                //сохранить картинку с именем текущей даты в мануал папку
                bmpScreenShot.Save(pathManual + DateTime.Now.ToString("yyMMdd_HHmmss") + ".jpg", ImageFormat.Jpeg);
            }
        }

        //тик таймера
        private void timer_Tick(object sender, EventArgs e)
        {
            if (mode)
            {
                makeScrShot();
                //сохранить картинку с именем компа в авто папку
                bmpScreenShot.Save(Environment.MachineName + ".jpg", ImageFormat.Jpeg);
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
        }

        //переместить файл
        private void fileMove()
        {
            if (mode) //авто режим
            {
                if (File.Exists(Environment.MachineName + ".jpg"))
                {
                    try
                    {
                        //удалить файл
                        File.Delete(pathLan + Environment.MachineName + ".jpg");

                        //переместить новый
                        File.Move(Environment.MachineName + ".jpg", pathLan + Environment.MachineName + ".jpg");
                    }
                    catch (IOException)
                    {
                        trayIcon.ShowBalloonTip(500, "Alert", "no move", ToolTipIcon.Info);
                    }
                }
            }
            else //ручной режим
            {
                string[] allFiles = Directory.GetFiles(pathManual);
                if (allFiles.GetLength(0) > 0)
                {
                    if (allFiles.GetLength(0) < 4)
                        trayIcon.ShowBalloonTip(500, "Alert", "left " + (allFiles.GetLength(0) - 1), ToolTipIcon.Info);

                    try
                    {
                        //удалить файл
                        File.Delete(pathLan + Environment.MachineName + ".jpg");

                        //изменить даты
                        //File.SetCreationTime(allFiles[0], DateTime.Now);
                        File.SetLastWriteTime(allFiles[0], DateTime.Now);
                        File.SetLastAccessTime(allFiles[0], DateTime.Now);

                        //переместить новый
                        File.Move(allFiles[0], pathLan + Environment.MachineName + ".jpg");
                    }
                    catch (IOException)
                    {
                        trayIcon.ShowBalloonTip(500, "Alert", "no move", ToolTipIcon.Info);
                    }
                }

                //файла нет, изменить дату на серве
                else
                {
                    File.SetCreationTime(pathLan + Environment.MachineName + ".jpg", DateTime.Now);
                    File.SetLastWriteTime(pathLan + Environment.MachineName + ".jpg", DateTime.Now);
                    File.SetLastAccessTime(pathLan + Environment.MachineName + ".jpg", DateTime.Now);
                }
            }
        }

        #endregion

        #region интерфейс

        //сохранить настройки и обновить поля
        private void btnSavePref_Click(object sender, EventArgs e)
        {
            //изменить настройки
            Properties.Settings.Default.timer = (int)numTimerPref.Value;

            if (!tbLanPath.Text.EndsWith("\\"))
                Properties.Settings.Default.pathLan = tbLanPath.Text + "\\";
            else
                Properties.Settings.Default.pathLan = tbLanPath.Text;

            if (!tbManualPath.Text.EndsWith("\\"))
                Properties.Settings.Default.pathManual = tbManualPath.Text + "\\";
            else
                Properties.Settings.Default.pathManual = tbManualPath.Text;

            //и сохранить
            Properties.Settings.Default.Save();

            //и пременить
            applyPref();
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

                if (MessageBox.Show("Clear local dir?", "Manually mode", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(pathManual);
                    foreach (FileInfo file in dirInfo.GetFiles())
                    {
                        file.Delete();
                    }
                }
            }
        }

        private void btnManualPath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                tbManualPath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnLanPath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                tbLanPath.Text = folderBrowserDialog.SelectedPath;
            }
        }

        private void btnOpenManualPath_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer", Path.GetDirectoryName(pathManual));
        }

        private void btnOpenLanPath_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer", Path.GetDirectoryName(pathLan));
        }

        #endregion
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
