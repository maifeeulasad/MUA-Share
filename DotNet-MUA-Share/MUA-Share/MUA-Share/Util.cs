﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace MUA_Share
{
    class Util
    {
        public static string userName = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        public static ServerClient serverClient = null;
        public static string recieveLocation = @"C:\Users\"+
            userName.Substring(userName.IndexOf('\\'))+
            @"\Downloads\MUA-Share";

        public static void CreateServerClient(TextBox ip,TextBox port)
        {
            new ServerClient(ip.Text, port.Text);
            Directory.CreateDirectory(recieveLocation);
        }

        public static void StopServerClient()
        {
            if (serverClient != null && serverClient.tcpListener != null)
            {
                serverClient.Stop();
            }
        }

    }
}
