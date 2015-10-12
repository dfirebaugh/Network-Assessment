using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using NetworkUtilities;

namespace NetworkUtilties
{
    public class PortScanner
    {
        public static List<int> openPorts = new List<int>();
        public static IEnumerable<int> Scan(string ip, int startPort, int endPort)
        {
            openPorts.Clear();
            //List<int> openPorts = new List<int>();

            for (int port = startPort; port <= endPort; port++)
            {
                Debug.WriteLine(string.Format("Scanning port {0}", port));
                Socket scanSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

                try
                {
                    //scanSocket.Connect(new IPEndPoint(IPAddress.Parse(ip), port));
                    //scanSocket.Disconnect(false);
                    //openPorts.Add(port);
                    //scanSocket.BeginConnect(new IPEndPoint(ip, port), ScanCallBack, new ArrayList() { scanSocket, port });
                    scanSocket.BeginConnect(new IPEndPoint(IPAddress.Parse(ip), port), ScanCallBack, new ArrayList() { scanSocket, port });
                }
                catch (Exception ex)
                {
                    //bury exception since it means we could not connect to the port
                }
                
            }
            //Computers.comp1.Add(ip, openPorts);
            return openPorts;
        }

        /// <summary>  
        /// BeginConnect  
        /// </summary>  
        /// <param name="result">Connect</param>  
        ///         
        public static void ScanCallBack(IAsyncResult result)
        {
            //    
            //List<int> openPorts = new List<int>();



            ArrayList arrList = (ArrayList)result.AsyncState;
            Socket scanSocket = (Socket)arrList[0];
            int port = (int)arrList[1];
            //  
            if (result.IsCompleted && scanSocket.Connected)
            {
                //Console.WriteLine("{0,5}\t", port);
                openPorts.Add(port);
                
                


            }

            scanSocket.Close();

        }
    }
}