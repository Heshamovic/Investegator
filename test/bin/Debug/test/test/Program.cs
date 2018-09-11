﻿using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login_Form());
            int BrowserVer, RegVal;
            // get the installed IE version
            using (WebBrowser Wb = new WebBrowser())
                BrowserVer = Wb.Version.Major;

            // set the appropriate IE version
          //  if (BrowserVer >= 11)
               RegVal = 11001;
           // else if (BrowserVer == 10)
              //  RegVal = 10001;
           // else if (BrowserVer == 9)
              //  RegVal = 9999;
            //else if (BrowserVer == 8)
               // RegVal = 8888;
           
            // set the actual key
            using (RegistryKey Key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", RegistryKeyPermissionCheck.ReadWriteSubTree))
                if (Key.GetValue(System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe") == null)
                    Key.SetValue(System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe", RegVal, RegistryValueKind.DWord);
        }
    }
}
