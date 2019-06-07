using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MUA_Share
{
    class ServerClient
    {
        private Socket socket;
        private NetworkStream netstream;
        private IPAddress ipAddress;
        private string port;
        public TcpListener tcpListener;
        public ServerClient(string ip_,string port_)
        {
            try
            {
                this.ipAddress = IPAddress.Parse(ip_);
                this.port = port_;
                tcpListener = new TcpListener(ipAddress, int.Parse(port_));
                tcpListener.Start();
                Util.serverClient = this;
            }
            catch(Exception e)
            {
                
            }
        }

        public void Stop()
        {
            if(Util.serverClient!=null && Util.serverClient.tcpListener!=null)
            {
                tcpListener.Stop();
                Util.serverClient = null;
            }
        }
    }
}
