// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Runtime.InteropServices;

namespace StarryNight
{
  public class User32
	{
		[DllImport("User32.dll")]
		public static extern IntPtr GetDC(IntPtr hWnd);

    [DllImport("User32.dll")]
    public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

		[DllImport("User32.dll")]
		public extern static long GetWindowLong(IntPtr hWnd, int dwStyle);	

		[DllImport("User32.dll")]
		public static extern int SetWindowLong(IntPtr hWnd, int nIndex, long dwNewLong);

		[DllImport("User32.dll")]
		public static extern bool UpdateLayeredWindow(
      IntPtr hWnd, IntPtr hDCDst, ref WinDef.POINT pDst, ref WinDef.SIZE pSize, IntPtr hDCSrc, ref WinDef.POINT pSrc, int clrKey, ref WinGdi.BLENDFUNCTION blend, int dwFlags
    );

    [DllImport("User32.dll")]
    public static extern int SetWindowsHookEx(int idHook, HookProc lpfn, IntPtr hInstance, int threadId);

    [DllImport("User32.dll")]
    public static extern int CallNextHookEx(int idHook, int nCode, IntPtr wParam, IntPtr lParam);
	}
}