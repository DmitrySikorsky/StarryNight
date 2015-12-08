// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Diagnostics;
using System.Windows.Forms;

namespace StarryNight
{
  public partial class AboutWnd : Form
  {
    public AboutWnd()
    {
      this.InitializeComponent();
    }

    private void llWebsite_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      Process.Start("http://sikorsky.pro/");
    }
  }
}