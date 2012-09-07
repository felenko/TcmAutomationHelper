using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace WindowsAppAutomation
{
    public static class AppAutomationHelper
    {
        public static void StartAppByName(string appFullName)
        {
            var workingDir = Path.GetDirectoryName(appFullName);
            if (string.IsNullOrEmpty(workingDir)) throw new ArgumentException("appFullName should be name WITH full path");
            AppProcess = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = appFullName,
                    WorkingDirectory = workingDir
                   
                }
            };

            AppProcess.Start();
            
          }

        public static Process AppProcess { get; set; }

        public static void SendF10Key(IntPtr mainWindowHandle)
        {
            int result = NativeAPI.PostMessage(mainWindowHandle, NativeAPI.WM_SYSKEYDOWN, NativeAPI.VK_F10, IntPtr.Zero);
            Thread.Sleep(200);
            result = NativeAPI.PostMessage(mainWindowHandle, NativeAPI.WM_SYSKEYUP, NativeAPI.VK_F10, IntPtr.Zero);
        }

        public static void SendAltKey(IntPtr mainWindowHandle)
        {
            int result = NativeAPI.PostMessage(mainWindowHandle, NativeAPI.WM_SYSKEYDOWN, 0x12, (IntPtr)0x20380001);
            Thread.Sleep(200);
            result = NativeAPI.PostMessage(mainWindowHandle, NativeAPI.WM_SYSKEYUP, 0x12, (IntPtr)0xC0380001);
        }

        public static void SendSysKey(IntPtr mainWindowHandle, uint key)
        {
            int result = NativeAPI.SendMessage(mainWindowHandle, NativeAPI.WM_SYSKEYDOWN, key, IntPtr.Zero);

             result = NativeAPI.SendMessage(mainWindowHandle, NativeAPI.WM_SYSKEYUP, key, IntPtr.Zero);
        }

        public static void SendKey(IntPtr mainWindowHandle, uint key)
        {
            int result = NativeAPI.SendMessage(mainWindowHandle, NativeAPI.WM_KEYDOWN, key, IntPtr.Zero);
           
            result = NativeAPI.SendMessage(mainWindowHandle, NativeAPI.WM_KEYUP, key, (IntPtr)1);
        }

        public static void SendKeyDown(IntPtr mainWindowHandle, uint key)
        {
            int result = NativeAPI.SendMessage(mainWindowHandle, NativeAPI.WM_KEYDOWN, key, IntPtr.Zero);
        }

        public static void SendChar(IntPtr mainWindowHandle, uint key)
        {
            int result = NativeAPI.SendMessage(mainWindowHandle, NativeAPI.WM_KEYDOWN, key, IntPtr.Zero);
            NativeAPI.SendMessage(mainWindowHandle, NativeAPI.WM_CHAR, key, (IntPtr)1);
            result = NativeAPI.SendMessage(mainWindowHandle, NativeAPI.WM_KEYUP, key,  (IntPtr)1);
        }
        public static void SendText(IntPtr mainWindowHandle, string text)
        {
            for (int i = 0; i < text.Length; i++)
            {
                SendChar(mainWindowHandle, text[i]);
            }
        }
        
        public static IntPtr FindWindow(string wndClass, string wndCaption)
        {
            return NativeAPI.FindWindowEx(IntPtr.Zero, IntPtr.Zero, wndClass, wndCaption);
        }
    }
}
