namespace antiSpy
{
    partial class fAntiSpy
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fAntiSpy));
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.lstLog = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.btnAuto = new System.Windows.Forms.Button();
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.manualTrayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoTrayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeTrayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnManual = new System.Windows.Forms.Button();
            this.numTimerPref = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.trayMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimerPref)).BeginInit();
            this.SuspendLayout();
            // 
            // trayIcon
            // 
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "AntiSpy";
            this.trayIcon.Visible = true;
            this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseDoubleClick);
            // 
            // lstLog
            // 
            this.lstLog.FormattingEnabled = true;
            this.lstLog.Location = new System.Drawing.Point(12, 24);
            this.lstLog.Name = "lstLog";
            this.lstLog.Size = new System.Drawing.Size(191, 420);
            this.lstLog.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(209, 24);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(648, 420);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // btnAuto
            // 
            this.btnAuto.Location = new System.Drawing.Point(12, 469);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(98, 23);
            this.btnAuto.TabIndex = 2;
            this.btnAuto.Text = "Автоматически";
            this.btnAuto.UseVisualStyleBackColor = true;
            this.btnAuto.Click += new System.EventHandler(this.switchAuto);
            // 
            // trayMenu
            // 
            this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manualTrayMenuItem,
            this.autoTrayMenuItem,
            this.closeTrayMenuItem});
            this.trayMenu.Name = "trayMenu";
            this.trayMenu.Size = new System.Drawing.Size(158, 92);
            // 
            // manualTrayMenuItem
            // 
            this.manualTrayMenuItem.Name = "manualTrayMenuItem";
            this.manualTrayMenuItem.Size = new System.Drawing.Size(157, 22);
            this.manualTrayMenuItem.Text = "в ручную";
            this.manualTrayMenuItem.Click += new System.EventHandler(this.switchManual);
            // 
            // autoTrayMenuItem
            // 
            this.autoTrayMenuItem.Name = "autoTrayMenuItem";
            this.autoTrayMenuItem.Size = new System.Drawing.Size(157, 22);
            this.autoTrayMenuItem.Text = "автоматически";
            this.autoTrayMenuItem.Click += new System.EventHandler(this.switchAuto);
            // 
            // closeTrayMenuItem
            // 
            this.closeTrayMenuItem.Name = "closeTrayMenuItem";
            this.closeTrayMenuItem.Size = new System.Drawing.Size(157, 22);
            this.closeTrayMenuItem.Text = "выход";
            this.closeTrayMenuItem.Click += new System.EventHandler(this.closeTrayMenuItem_Click);
            // 
            // btnManual
            // 
            this.btnManual.Location = new System.Drawing.Point(116, 469);
            this.btnManual.Name = "btnManual";
            this.btnManual.Size = new System.Drawing.Size(87, 23);
            this.btnManual.TabIndex = 3;
            this.btnManual.Text = "В ручную";
            this.btnManual.UseVisualStyleBackColor = true;
            this.btnManual.Click += new System.EventHandler(this.switchManual);
            // 
            // numTimerPref
            // 
            this.numTimerPref.InterceptArrowKeys = false;
            this.numTimerPref.Location = new System.Drawing.Point(209, 469);
            this.numTimerPref.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            0});
            this.numTimerPref.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTimerPref.Name = "numTimerPref";
            this.numTimerPref.Size = new System.Drawing.Size(120, 20);
            this.numTimerPref.TabIndex = 5;
            this.numTimerPref.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numTimerPref.ValueChanged += new System.EventHandler(this.numTimerPref_ValueChanged);
            // 
            // fAntiSpy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(869, 501);
            this.Controls.Add(this.numTimerPref);
            this.Controls.Add(this.btnManual);
            this.Controls.Add(this.btnAuto);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lstLog);
            this.Name = "fAntiSpy";
            this.Text = "AntiSpy";
            this.Resize += new System.EventHandler(this.fAntiSpy_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.trayMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numTimerPref)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ListBox lstLog;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button btnAuto;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripMenuItem manualTrayMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoTrayMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeTrayMenuItem;
        private System.Windows.Forms.Button btnManual;
        private System.Windows.Forms.NumericUpDown numTimerPref;
    }
}

