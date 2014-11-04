using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace SuspenderLib
{

    public class BrowserDetector
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetDlgItem(IntPtr hDlg, int nIDDlgItem);
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int msg, int Param, string s);

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string lclassName, string windowTitle);

        private const int WM_GETTEXTLENGTH = 0xE;
        private const int WM_GETTEXT = 0xd;

        public static List<String> GetChromeUrls()
        {
            List<String> res = new List<String>();
            Process[] ps = Process.GetProcessesByName("chrome");
            foreach (Process p in ps)
            {
                IntPtr ChromeHandle = p.MainWindowHandle;
                if (ChromeHandle == IntPtr.Zero) continue;
	            IntPtr urlHandle = FindWindowEx(ChromeHandle, IntPtr.Zero, "Chrome_AutocompleteEditView", null);
	            int nChars = 256;
//	            StringBuilder sb = new StringBuilder(nChars);
                String str = String .Empty;
                int length = SendMessage(urlHandle, WM_GETTEXTLENGTH, 0, string.Empty);
        		SendMessage(urlHandle, WM_GETTEXT, nChars, str);
/*
	If length > 0 Then

		Return browserUrl
	Else
		Return browserUrl
	End If
 */
            }

            return res;
        }
    }
}
