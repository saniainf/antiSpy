﻿namespace antiSpy
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
            this.trayMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.countTrayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualTrayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoTrayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeTrayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.btnAuto = new System.Windows.Forms.Button();
            this.btnManual = new System.Windows.Forms.Button();
            this.numTimerPref = new System.Windows.Forms.NumericUpDown();
            this.groupBoxMode = new System.Windows.Forms.GroupBox();
            this.groupBoxPref = new System.Windows.Forms.GroupBox();
            this.btnOpenLanPath = new System.Windows.Forms.Button();
            this.btnOpenManualPath = new System.Windows.Forms.Button();
            this.btnLanPath = new System.Windows.Forms.Button();
            this.btnManualPath = new System.Windows.Forms.Button();
            this.tbLanPath = new System.Windows.Forms.TextBox();
            this.tbManualPath = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSavePref = new System.Windows.Forms.Button();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.trayMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTimerPref)).BeginInit();
            this.groupBoxMode.SuspendLayout();
            this.groupBoxPref.SuspendLayout();
            this.SuspendLayout();
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenuStrip = this.trayMenu;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "Export viewer";
            this.trayIcon.Visible = true;
            this.trayIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.trayIcon_MouseDoubleClick);
            // 
            // trayMenu
            // 
            this.trayMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.countTrayMenuItem,
            this.manualTrayMenuItem,
            this.autoTrayMenuItem,
            this.closeTrayMenuItem});
            this.trayMenu.Name = "trayMenu";
            this.trayMenu.Size = new System.Drawing.Size(153, 114);
            this.trayMenu.Opening += new System.ComponentModel.CancelEventHandler(this.trayMenu_Opening);
            // 
            // countTrayMenuItem
            // 
            this.countTrayMenuItem.Name = "countTrayMenuItem";
            this.countTrayMenuItem.Size = new System.Drawing.Size(152, 22);
            this.countTrayMenuItem.Text = "count";
            // 
            // manualTrayMenuItem
            // 
            this.manualTrayMenuItem.Name = "manualTrayMenuItem";
            this.manualTrayMenuItem.Size = new System.Drawing.Size(152, 22);
            this.manualTrayMenuItem.Text = "manually";
            this.manualTrayMenuItem.Click += new System.EventHandler(this.switchManual);
            // 
            // autoTrayMenuItem
            // 
            this.autoTrayMenuItem.Name = "autoTrayMenuItem";
            this.autoTrayMenuItem.Size = new System.Drawing.Size(152, 22);
            this.autoTrayMenuItem.Text = "automatically";
            this.autoTrayMenuItem.Click += new System.EventHandler(this.switchAuto);
            // 
            // closeTrayMenuItem
            // 
            this.closeTrayMenuItem.Name = "closeTrayMenuItem";
            this.closeTrayMenuItem.Size = new System.Drawing.Size(152, 22);
            this.closeTrayMenuItem.Text = "close";
            this.closeTrayMenuItem.Click += new System.EventHandler(this.closeTrayMenuItem_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // btnAuto
            // 
            this.btnAuto.Location = new System.Drawing.Point(6, 17);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(152, 25);
            this.btnAuto.TabIndex = 2;
            this.btnAuto.Text = "Path auto name";
            this.btnAuto.UseVisualStyleBackColor = true;
            this.btnAuto.Click += new System.EventHandler(this.switchAuto);
            // 
            // btnManual
            // 
            this.btnManual.Location = new System.Drawing.Point(6, 48);
            this.btnManual.Name = "btnManual";
            this.btnManual.Size = new System.Drawing.Size(152, 25);
            this.btnManual.TabIndex = 3;
            this.btnManual.Text = "Path manually name";
            this.btnManual.UseVisualStyleBackColor = true;
            this.btnManual.Click += new System.EventHandler(this.switchManual);
            // 
            // numTimerPref
            // 
            this.numTimerPref.InterceptArrowKeys = false;
            this.numTimerPref.Location = new System.Drawing.Point(55, 24);
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
            this.numTimerPref.Size = new System.Drawing.Size(64, 20);
            this.numTimerPref.TabIndex = 5;
            this.numTimerPref.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupBoxMode
            // 
            this.groupBoxMode.Controls.Add(this.btnAuto);
            this.groupBoxMode.Controls.Add(this.btnManual);
            this.groupBoxMode.Location = new System.Drawing.Point(12, 8);
            this.groupBoxMode.Name = "groupBoxMode";
            this.groupBoxMode.Size = new System.Drawing.Size(164, 80);
            this.groupBoxMode.TabIndex = 6;
            this.groupBoxMode.TabStop = false;
            this.groupBoxMode.Text = "Mode";
            // 
            // groupBoxPref
            // 
            this.groupBoxPref.Controls.Add(this.btnOpenLanPath);
            this.groupBoxPref.Controls.Add(this.btnOpenManualPath);
            this.groupBoxPref.Controls.Add(this.btnLanPath);
            this.groupBoxPref.Controls.Add(this.btnManualPath);
            this.groupBoxPref.Controls.Add(this.tbLanPath);
            this.groupBoxPref.Controls.Add(this.tbManualPath);
            this.groupBoxPref.Controls.Add(this.label4);
            this.groupBoxPref.Controls.Add(this.label3);
            this.groupBoxPref.Controls.Add(this.label2);
            this.groupBoxPref.Controls.Add(this.label1);
            this.groupBoxPref.Controls.Add(this.numTimerPref);
            this.groupBoxPref.Location = new System.Drawing.Point(12, 101);
            this.groupBoxPref.Name = "groupBoxPref";
            this.groupBoxPref.Size = new System.Drawing.Size(164, 148);
            this.groupBoxPref.TabIndex = 7;
            this.groupBoxPref.TabStop = false;
            this.groupBoxPref.Text = "Options";
            // 
            // btnOpenLanPath
            // 
            this.btnOpenLanPath.Location = new System.Drawing.Point(134, 120);
            this.btnOpenLanPath.Name = "btnOpenLanPath";
            this.btnOpenLanPath.Size = new System.Drawing.Size(24, 19);
            this.btnOpenLanPath.TabIndex = 15;
            this.btnOpenLanPath.Text = ">";
            this.btnOpenLanPath.UseVisualStyleBackColor = true;
            this.btnOpenLanPath.Click += new System.EventHandler(this.btnOpenLanPath_Click);
            // 
            // btnOpenManualPath
            // 
            this.btnOpenManualPath.Location = new System.Drawing.Point(134, 73);
            this.btnOpenManualPath.Name = "btnOpenManualPath";
            this.btnOpenManualPath.Size = new System.Drawing.Size(24, 19);
            this.btnOpenManualPath.TabIndex = 14;
            this.btnOpenManualPath.Text = ">";
            this.btnOpenManualPath.UseVisualStyleBackColor = true;
            this.btnOpenManualPath.Click += new System.EventHandler(this.btnOpenManualPath_Click);
            // 
            // btnLanPath
            // 
            this.btnLanPath.Location = new System.Drawing.Point(107, 120);
            this.btnLanPath.Name = "btnLanPath";
            this.btnLanPath.Size = new System.Drawing.Size(24, 19);
            this.btnLanPath.TabIndex = 13;
            this.btnLanPath.Text = "...";
            this.btnLanPath.UseVisualStyleBackColor = true;
            this.btnLanPath.Click += new System.EventHandler(this.btnLanPath_Click);
            // 
            // btnManualPath
            // 
            this.btnManualPath.Location = new System.Drawing.Point(107, 73);
            this.btnManualPath.Name = "btnManualPath";
            this.btnManualPath.Size = new System.Drawing.Size(24, 19);
            this.btnManualPath.TabIndex = 12;
            this.btnManualPath.Text = "...";
            this.btnManualPath.UseVisualStyleBackColor = true;
            this.btnManualPath.Click += new System.EventHandler(this.btnManualPath_Click);
            // 
            // tbLanPath
            // 
            this.tbLanPath.Location = new System.Drawing.Point(6, 120);
            this.tbLanPath.Name = "tbLanPath";
            this.tbLanPath.Size = new System.Drawing.Size(97, 20);
            this.tbLanPath.TabIndex = 11;
            // 
            // tbManualPath
            // 
            this.tbManualPath.Location = new System.Drawing.Point(6, 73);
            this.tbManualPath.Name = "tbManualPath";
            this.tbManualPath.Size = new System.Drawing.Size(97, 20);
            this.tbManualPath.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Path network";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Path manually";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(125, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "time";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Repeat";
            // 
            // btnSavePref
            // 
            this.btnSavePref.Location = new System.Drawing.Point(18, 255);
            this.btnSavePref.Name = "btnSavePref";
            this.btnSavePref.Size = new System.Drawing.Size(152, 25);
            this.btnSavePref.TabIndex = 8;
            this.btnSavePref.Text = "Apply";
            this.btnSavePref.UseVisualStyleBackColor = true;
            this.btnSavePref.Click += new System.EventHandler(this.btnSavePref_Click);
            // 
            // fAntiSpy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(188, 288);
            this.Controls.Add(this.btnSavePref);
            this.Controls.Add(this.groupBoxPref);
            this.Controls.Add(this.groupBoxMode);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fAntiSpy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Export viewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fAntiSpyClosing);
            this.Load += new System.EventHandler(this.fAntiSpy_Load);
            this.Resize += new System.EventHandler(this.fAntiSpy_Resize);
            this.trayMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numTimerPref)).EndInit();
            this.groupBoxMode.ResumeLayout(false);
            this.groupBoxPref.ResumeLayout(false);
            this.groupBoxPref.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button btnAuto;
        private System.Windows.Forms.ContextMenuStrip trayMenu;
        private System.Windows.Forms.ToolStripMenuItem manualTrayMenuItem;
        private System.Windows.Forms.ToolStripMenuItem autoTrayMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeTrayMenuItem;
        private System.Windows.Forms.Button btnManual;
        private System.Windows.Forms.NumericUpDown numTimerPref;
        private System.Windows.Forms.GroupBox groupBoxMode;
        private System.Windows.Forms.GroupBox groupBoxPref;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSavePref;
        private System.Windows.Forms.TextBox tbManualPath;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbLanPath;
        private System.Windows.Forms.Button btnLanPath;
        private System.Windows.Forms.Button btnManualPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button btnOpenManualPath;
        private System.Windows.Forms.Button btnOpenLanPath;
        private System.Windows.Forms.ToolStripMenuItem countTrayMenuItem;
    }
}

