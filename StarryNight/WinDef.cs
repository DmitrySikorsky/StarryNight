// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Runtime.InteropServices;

namespace StarryNight
{
  public class WinDef
	{
    [StructLayout(LayoutKind.Sequential)]
    public struct POINT
    {
      public int x;
      public int y;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SIZE
    {
      public int cx;
      public int cy;
    }
	}
}
