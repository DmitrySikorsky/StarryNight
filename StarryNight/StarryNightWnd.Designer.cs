namespace StarryNight
{
  partial class StarryNightWnd
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StarryNightWnd));
      this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
      this.contextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.cmiAbout = new System.Windows.Forms.ToolStripMenuItem();
      this.cms1 = new System.Windows.Forms.ToolStripSeparator();
      this.cmiExit = new System.Windows.Forms.ToolStripMenuItem();
      this.timer = new System.Windows.Forms.Timer(this.components);
      this.contextMenu.SuspendLayout();
      this.SuspendLayout();
      // 
      // notifyIcon
      // 
      this.notifyIcon.ContextMenuStrip = this.contextMenu;
      this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
      this.notifyIcon.Text = "StarryNight";
      this.notifyIcon.Visible = true;
      // 
      // contextMenu
      // 
      this.contextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmiAbout,
            this.cms1,
            this.cmiExit});
      this.contextMenu.Name = "contextMenu";
      this.contextMenu.Size = new System.Drawing.Size(150, 54);
      // 
      // cmiAbout
      // 
      this.cmiAbout.Name = "cmiAbout";
      this.cmiAbout.Size = new System.Drawing.Size(149, 22);
      this.cmiAbout.Text = "О программе";
      this.cmiAbout.Click += new System.EventHandler(this.cmiAbout_Click);
      // 
      // cms1
      // 
      this.cms1.Name = "cms1";
      this.cms1.Size = new System.Drawing.Size(146, 6);
      // 
      // cmiExit
      // 
      this.cmiExit.Name = "cmiExit";
      this.cmiExit.Size = new System.Drawing.Size(149, 22);
      this.cmiExit.Text = "Выход";
      this.cmiExit.Click += new System.EventHandler(this.cmiExit_Click);
      // 
      // timer
      // 
      this.timer.Enabled = true;
      this.timer.Interval = 25;
      this.timer.Tick += new System.EventHandler(this.timer_Tick);
      // 
      // StarryNightWnd
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(100, 100);
      this.DoubleBuffered = true;
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
      this.Name = "StarryNightWnd";
      this.ShowInTaskbar = false;
      this.Text = "StarryNight™";
      this.TopMost = true;
      this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
      this.contextMenu.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.NotifyIcon notifyIcon;
    private System.Windows.Forms.ContextMenuStrip contextMenu;
    private System.Windows.Forms.ToolStripMenuItem cmiExit;
    private System.Windows.Forms.ToolStripMenuItem cmiAbout;
    private System.Windows.Forms.ToolStripSeparator cms1;
    private System.Windows.Forms.Timer timer;
  }
}

