using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using WindowsAppAutomation;

namespace ConsoleApplication1
{

    using System;
    using System.Threading;
    using System.Runtime.Remoting.Contexts;

    public class TestSyncDomainWait
    {
        public static void Main()
        {
          // TcmAutomationHelper.StartupTkmApp();    
            //wnd = (IntPtr) 0xA0844;
            var wnd = AppAutomationHelper.FindWindow("TMainFrm", null);
            TcmAutomationHelper.BuildDiagramForDate(wnd, new DateTime(2012, 10, 10));
            NativeAPI.PostMessage(wnd, NativeAPI.WM_SYSKEYDOWN, 0x12, (IntPtr)0x2038001);
            NativeAPI.PostMessage(wnd, NativeAPI.WM_SYSKEYDOWN, 0x53, (IntPtr)0x201f001);
            NativeAPI.PostMessage(wnd, NativeAPI.WM_SYSCHAR, 0x73, (IntPtr)0x201f001);
            NativeAPI.PostMessage(wnd, NativeAPI.WM_SYSCOMMAND, NativeAPI.SC_KEYMENU , (IntPtr)0x73);
            // NativeAPI.PostMessage(wnd, 0x02A2, 0, IntPtr.Zero);
           // NativeAPI.SendMessage(wnd, NativeAPI.WM_SYSCOMMAND, 0xf095, (IntPtr)0x45e01a);
           //// NativeAPI.SendMessage((IntPtr)0x20192, NativeAPI.WM_ACTIVATE, 1, (IntPtr)0x20192);
           //// NativeAPI.SendMessage((IntPtr)0x20192, NativeAPI.WM_NCACTIVE, 1,  (IntPtr)0x20192);
           // NativeAPI.SendMessage(wnd, 0x281, 0, 0xc000000f);
           // NativeAPI.SendMessage(wnd, 0x282, 1, (IntPtr)0);

           
           // NativeAPI.SendMessage(wnd, NativeAPI.WM_MENUSELECT, 0x8090004, (IntPtr)0x030209);
           // NativeAPI.SendMessage(wnd, NativeAPI.WM_MENUSELECT, 0xffff0000, (IntPtr)0);
           // //TcmAutomationHelper.BuildDiagramForDate(wnd, new DateTime(2012, 9, 2));
           // //TcmAutomationHelper.FileSave(wnd, @"C:\2012_09_01.bmp");
            //NativeAPI.PostMessage((int)wnd, NativeAPI.WM_COMMAND, 4, (IntPtr)0);
            //NativeAPI.ShowWindow((IntPtr) 0x20192, NativeAPI.ShowWindowCommands.Normal);
        }
    }
}

 













