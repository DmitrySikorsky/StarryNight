// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace StarryNight
{
  public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);

  public class HookHelper
  {
    private int hHook = 0;
    private HookProc mouseHookProcedure;

    public event MouseEventHandler MouseMove;
    public event MouseEventHandler MouseClick;

    public bool SetHook()
    {
      this.mouseHookProcedure = new HookProc(this.MouseHookProc);
      this.hHook = User32.SetWindowsHookEx(
        WinUser.WH_MOUSE_LL,
        this.mouseHookProcedure,
        Process.GetCurrentProcess().MainModule.BaseAddress,
        0
      );

      return this.hHook != 0;
    }

    private int MouseHookProc(int nCode, IntPtr wParam, IntPtr lParam)
    {
      WinUser.MouseHookStruct mouseHookStruct = (WinUser.MouseHookStruct)Marshal.PtrToStructure(lParam, typeof(WinUser.MouseHookStruct));

      if (nCode < 0)
        return User32.CallNextHookEx(hHook, nCode, wParam, lParam);

      else
      {
        MouseButtons button = MouseButtons.None;
        int clicks = 0;
        int x = mouseHookStruct.pt.x;
        int y = mouseHookStruct.pt.y;
        int delta = 0;

        if ((int)wParam == WinUser.WM_MOUSEMOVE)
        {
        }

        else if ((int)wParam == WinUser.WM_LBUTTONDOWN)
        {
          button = MouseButtons.Left;
          clicks = 1;
        }

        else if ((int)wParam == WinUser.WM_RBUTTONDOWN)
        {
          button = MouseButtons.Right;
          clicks = 1;
        }

        else if ((int)wParam == WinUser.WM_LBUTTONUP)
        {
          button = MouseButtons.Left;
          clicks = 1;
        }

        else if ((int)wParam == WinUser.WM_RBUTTONUP)
        {
          button = MouseButtons.Right;
          clicks = 1;
        }

        else if ((int)wParam == WinUser.WM_LBUTTONDBLCLK)
        {
          button = MouseButtons.Left;
          clicks = 2;
        }

        else if ((int)wParam == WinUser.WM_RBUTTONDBLCLK)
        {
          button = MouseButtons.Right;
          clicks = 2;
        }

        if (this.MouseMove != null && clicks == 0)
          this.MouseMove(null, new MouseEventArgs(button, clicks, x, y, delta));

        if (this.MouseClick != null && clicks != 0)
          this.MouseClick(null, new MouseEventArgs(button, clicks, x, y, delta));

        return User32.CallNextHookEx(hHook, nCode, wParam, lParam);
      }
    }
  }
}