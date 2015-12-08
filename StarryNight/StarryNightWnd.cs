// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Windows.Forms;

namespace StarryNight
{
  public partial class StarryNightWnd : Form
  {
    List<Star> stars;
    Random rnd;
    private HookHelper hookHelper;
    private int x;
    private int y;

    public StarryNightWnd()
    {
      // Initialize list of the stars
      this.stars = new List<Star>();

      // Initialize randomizer (very important thing in this project)
      this.rnd = new Random();

      // Initialize hook helper
      this.hookHelper = new HookHelper();

      // Current mouse position is unknown
      this.x = -1;
      this.y = -1;
      this.InitializeComponent();

      // Set styles WS_EX_LAYERED and WS_EX_TRANSPARENT for the window
      this.MakeWindowLayered();
      
      // Invalidate the window
      this.Invalidate();
    }

    private void cmiAbout_Click(object sender, EventArgs e)
    {
      new AboutWnd().ShowDialog();
    }

    private void cmiExit_Click(object sender, EventArgs e)
    {
      // We should also remove global mouse events hooks here (but we don't :( )
      this.Close();
    }

    private void timer_Tick(object sender, EventArgs e)
    {
      // Return if we still don't have current mouse position
      if (this.x == -1 && this.y == -1)
        return;

      // Update all stars (position, lifetime etc)
      for (int i = 0; i < this.stars.Count; i++)
      {
        this.stars[i].y += this.stars[i].speed;

        if (this.stars[i].xDelta < 0 && this.stars[i].xVal > this.stars[i].xDelta)
        {
          this.stars[i].xVal += this.stars[i].xDelta / (2 * this.stars[i].smoother);
          this.stars[i].x += this.stars[i].xDelta / (2 * this.stars[i].smoother);
        }

        if (this.stars[i].xDelta > 0 && this.stars[i].xVal < this.stars[i].xDelta)
        {
          this.stars[i].xVal += this.stars[i].xDelta / (2 * this.stars[i].smoother);
          this.stars[i].x += this.stars[i].xDelta / (2 * this.stars[i].smoother);
        }

        if (this.stars[i].yDelta < 0 && this.stars[i].yVal > this.stars[i].yDelta)
        {
          this.stars[i].yVal += this.stars[i].yDelta / (2 * this.stars[i].smoother);
          this.stars[i].y += this.stars[i].yDelta / (2 * this.stars[i].smoother);

        }

        if (this.stars[i].yDelta > 0 && this.stars[i].yVal < this.stars[i].yDelta)
        {
          this.stars[i].yVal += this.stars[i].yDelta / (2 * this.stars[i].smoother);
          this.stars[i].y += this.stars[i].yDelta / (2 * this.stars[i].smoother);
          this.stars[i].y += this.stars[i].smoother;
        }

        this.stars[i].smoother += 2;

        if (this.stars[i].lifetime > 0)
          this.stars[i].lifetime--;

        else if (this.stars[i].alpha > 0)
        {
          this.stars[i].alpha -= 25;

          if (this.stars[i].alpha < 0)
            this.stars[i].alpha = 0;
        }
      }

      // Create 1 new star and add them to the list every timer tick
      Star star = new Star();

      star.x = this.x + rnd.Next(-10, 10);
      star.y = this.y + rnd.Next(-10, 10);
      star.size = this.rnd.Next(2, 15);
      star.speed = this.rnd.Next(5, 20);
      star.lifetime = this.rnd.Next(10, 100);
      star.alpha = rnd.Next(150, 256);
      star.text = this.GetStarText();
      star.color = this.GetStarColor();
      this.stars.Add(star);

      // Maximum number of stars is 1000
      while (this.stars.Count > 1000)
        this.stars.RemoveAt(0);

      // Invalidate the window
      this.Invalidate();
    }

    private void hookManager_MouseMove(object sender, MouseEventArgs e)
    {
      // Save current mouse position
      this.x = e.X;
      this.y = e.Y;
    }

    private void hookManager_MouseClick(object sender, MouseEventArgs e)
    {
      // Create from 20 to 50 new stars and add them to the list
      int count = this.rnd.Next(20, 50);

      for (int i = 0; i != count; i++)
      {
        Star star = new Star();

        star.x = this.x + this.rnd.Next(-10, 10);
        star.y = this.y + this.rnd.Next(-10, 10);
        star.size = this.rnd.Next(2, 20);
        star.xDelta = this.rnd.Next(-250, 250);
        star.yDelta = this.rnd.Next(-250, 250);
        star.smoother = this.rnd.Next(2, 5);
        star.speed = this.rnd.Next(5, 20);
        star.lifetime = this.rnd.Next(10, 100);
        star.alpha = rnd.Next(150, 256);
        star.text = this.GetStarText();
        star.color = this.GetStarColor();
        this.stars.Add(star);

        // Maximum number of stars is 1000
        while (this.stars.Count > 1000)
          this.stars.RemoveAt(0);
      }
    }

    public new virtual void Invalidate()
    {
      // Call our method to invalidate the window
      if (this.Visible)
        this.Invalidate(this.Bounds);
    }

    protected override void OnShown(EventArgs e)
    {
      base.OnShown(e);

      // Set global mouse events hook
      if (!this.hookHelper.SetHook())
        MessageBox.Show("В процессе инициализации произошла ошибка!", "Ошибка", MessageBoxButtons.OK);

      // Set events
      this.hookHelper.MouseMove += hookManager_MouseMove;
      this.hookHelper.MouseClick += hookManager_MouseClick;
    }

    protected override void OnPaint(PaintEventArgs e)
    {
      // Enable smoothing
      e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
      e.Graphics.TextRenderingHint = TextRenderingHint.AntiAlias;

      // Обходим все объекты-звездочки из списка и выводим их на экран
      foreach (Star star in this.stars)
      {
        int x = star.x - star.size / 2;
        int y = star.y - star.size / 2;

        using (Font font = new Font("Wingdings", star.size))
          using (Brush brush = new SolidBrush(Color.FromArgb(star.alpha, star.color)))
            if (star.lifetime > 0 || star.alpha > 0)
              e.Graphics.DrawString(star.text, font, brush, x, y);
      }
    }

    private new void Invalidate(Rectangle rect)
    {
      Bitmap memoryBitmap = new Bitmap(
        rect.Size.Width,
        rect.Size.Height,
        PixelFormat.Format32bppArgb
      );

      using (Graphics g = Graphics.FromImage(memoryBitmap))
      {
        Rectangle area = new Rectangle(0, 0, rect.Size.Width, rect.Size.Height);

        this.OnPaint(new PaintEventArgs(g, area));

        IntPtr hDC = User32.GetDC(IntPtr.Zero);
        IntPtr memoryDC = Gdi32.CreateCompatibleDC(hDC);
        IntPtr hBitmap = memoryBitmap.GetHbitmap(Color.FromArgb(0));
        IntPtr oldBitmap = Gdi32.SelectObject(memoryDC, hBitmap);

        WinDef.POINT dst;
        dst.x = rect.Location.X;
        dst.y = rect.Location.Y;

        WinDef.SIZE size;
        size.cx = rect.Size.Width;
        size.cy = rect.Size.Height;

        WinDef.POINT src;
        src.x = 0;
        src.y = 0;

        WinGdi.BLENDFUNCTION blend;
        blend.BlendOp = (byte)WinGdi.AC_SRC_OVER;
        blend.BlendFlags = 0;
        blend.SourceConstantAlpha = (byte)255;
        blend.AlphaFormat = (byte)WinGdi.AC_SRC_ALPHA;

        User32.UpdateLayeredWindow(
          this.Handle, hDC, ref dst, ref size, memoryDC, ref src, 0, ref blend, WinUser.ULW_ALPHA
        );

        Gdi32.SelectObject(memoryDC, oldBitmap);
        User32.ReleaseDC(IntPtr.Zero, hDC);
        Gdi32.DeleteObject(hBitmap);
        Gdi32.DeleteDC(memoryDC);
        Gdi32.DeleteDC(hDC);
        memoryBitmap.Dispose();
      }
    }

    private void MakeWindowLayered()
    {
      // Get current window styles
      long dwExStyle = User32.GetWindowLong(this.Handle, WinUser.GWL_EXSTYLE);

      // Add WS_EX_LAYERED and WS_EX_TRANSPARENT
      dwExStyle = dwExStyle | WinUser.WS_EX_LAYERED | WinUser.WS_EX_TRANSPARENT;

      // Set new window styles
      User32.SetWindowLong(this.Handle, WinUser.GWL_EXSTYLE, dwExStyle);
    }

    private string GetStarText()
    {
      // You can try another chars here
      string[] texts = { /*"©", "ª",*/ "«"/*, "¬", "­"*/ };

      return texts[this.rnd.Next(texts.Length)];
    }

    private Color GetStarColor()
    {
      // You can try another colors here
      Color[] colors = { Color.Red/*, Color.Green, Color.Blue*/ };

      return colors[this.rnd.Next(colors.Length)];
    }
  }
}