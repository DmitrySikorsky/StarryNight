// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Runtime.InteropServices;

namespace StarryNight
{
  public class WinUser
	{
		public const int WS_EX_LAYERED = 0x80000;
		public const int WS_EX_TRANSPARENT = 0x20;

		public const int ULW_ALPHA = 2;

    public const int GWL_EXSTYLE = -20;

    public const int WM_MOUSEMOVE = 0x200;
    public const int WM_LBUTTONDOWN = 0x201;
    public const int WM_RBUTTONDOWN = 0x204;
    public const int WM_LBUTTONUP = 0x202;
    public const int WM_RBUTTONUP = 0x205;
    public const int WM_LBUTTONDBLCLK = 0x203;
    public const int WM_RBUTTONDBLCLK = 0x206;

    public const int WH_MOUSE_LL = 14;

    [StructLayout(LayoutKind.Sequential)]
    public class MouseHookStruct
    {
      public WinDef.POINT pt;
      public int hWnd;
      public int wHitTestCode;
      public int dwExtraInfo;
    }
	}
}