// Copyright � 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Runtime.InteropServices;

namespace StarryNight
{
  public enum DeviceCap
  {
    VERTRES = 10,
    DESKTOPVERTRES = 117
  }

  public class Gdi32
	{
		[DllImport("Gdi32.dll")]
		public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

		[DllImport("Gdi32.dll")]
    public static extern IntPtr DeleteDC(IntPtr hDC);

    [DllImport("Gdi32.dll")]
    public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObject);

		[DllImport("Gdi32.dll")]
		public static extern bool DeleteObject(IntPtr hObject);

    [DllImport("Gdi32.dll")]
    public static extern int GetDeviceCaps(IntPtr hDC, int nIndex);
  }
}