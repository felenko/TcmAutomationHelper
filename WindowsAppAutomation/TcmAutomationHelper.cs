using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using ManagedWinapi.Windows;

namespace WindowsAppAutomation
{
    public static class TcmAutomationHelper
    {
        public static IntPtr StartupTkmApp()
        {
            AppAutomationHelper.StartAppByName(@"C:\Program Files\TKM\Bioritm.exe");
            EventWaitHandle wh = new AutoResetEvent(false);
            wh.WaitOne(5000);
            IntPtr wnd;
            var caption = string.Empty;
            do
            {

                do
                {
                    wnd = AppAutomationHelper.FindWindow("TMainFrm", null);
                } while (wnd == IntPtr.Zero);

                var c = new StringBuilder(255);
                NativeAPI.GetWindowText(wnd, c, 255);
                caption = c.ToString();
            } while (caption.IndexOf("Хронопунктура", System.StringComparison.Ordinal) == -1);
            wnd = AppAutomationHelper.FindWindow("TApplication", null);
            return wnd;
        }


        public static void FileOpen(IntPtr appHwnd, string fileName)
        {
            NativeAPI.PostMessage(appHwnd, NativeAPI.WM_COMMAND, NativeAPI.FileOpenMenuCommand, IntPtr.Zero);
            Thread.Sleep(1000);
            var tmpWndClass = "#32770";
            var tmpHwnd = NativeAPI.FindWindowEx(IntPtr.Zero, IntPtr.Zero, tmpWndClass, null);
            var dlgOpenHwnd = tmpHwnd;
            tmpWndClass = "ComboBoxEx32";
            tmpHwnd = NativeAPI.FindWindowEx(tmpHwnd, IntPtr.Zero, tmpWndClass, null);
            tmpWndClass = "ComboBox";
            var fileNameEditHwnd = NativeAPI.FindWindowEx(tmpHwnd, IntPtr.Zero, tmpWndClass, null);
            tmpWndClass = "Edit";
            fileNameEditHwnd = NativeAPI.FindWindowEx(fileNameEditHwnd, IntPtr.Zero, tmpWndClass, null);
            AppAutomationHelper.SendText(fileNameEditHwnd, fileName);
            Thread.Sleep(100);
            NativeAPI.SendMessage(dlgOpenHwnd, NativeAPI.WM_COMMAND, 1, IntPtr.Zero);
        }

        public static void FileSave(IntPtr appHwnd, string fileName)
        {
            NativeAPI.PostMessage(appHwnd, NativeAPI.WM_COMMAND, 4, IntPtr.Zero);
            Thread.Sleep(1000);
            var tmpWndClass = "#32770";
            var tmpHwnd = NativeAPI.FindWindowEx(IntPtr.Zero, IntPtr.Zero, tmpWndClass, null);
            var dlgOpenHwnd = tmpHwnd;
            tmpWndClass = "ComboBoxEx32";
            tmpHwnd = NativeAPI.FindWindowEx(tmpHwnd, IntPtr.Zero, tmpWndClass, null);
            tmpWndClass = "ComboBox";
            var fileNameEditHwnd = NativeAPI.FindWindowEx(tmpHwnd, IntPtr.Zero, tmpWndClass, null);
            tmpWndClass = "Edit";
            fileNameEditHwnd = NativeAPI.FindWindowEx(fileNameEditHwnd, IntPtr.Zero, tmpWndClass, null);
            AppAutomationHelper.SendText(fileNameEditHwnd, fileName);
            Thread.Sleep(100);
            NativeAPI.SendMessage(dlgOpenHwnd, NativeAPI.WM_COMMAND, 1, IntPtr.Zero);
        }

        public static void BuildDiagramForDate(IntPtr appHwnd, DateTime date)
        {
            var tempFileName = System.IO.Path.GetTempFileName();
            tempFileName = Path.ChangeExtension(tempFileName, ".data");
            using (var file = new FileStream(tempFileName, FileMode.OpenOrCreate, FileAccess.Write))
            {
                var writer = new StreamWriter(file);
                writer.Write(date.ToString("dd.MM.yyyyy"));
                writer.Flush();
            }

            FileOpen(appHwnd, tempFileName);

        }
    }
}
