﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Runtime.Serialization.Formatters.Binary;

namespace gigaFlash
{
    public class Connection
    {
        #region Constructor 
        public Connection()
        {
            mSocket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            int port = System.Convert.ToInt16(mPort, 10);
            IPAddress remoteIPAddress = System.Net.IPAddress.Parse(IP);
            IPEndPoint remoteEndPoint = new System.Net.IPEndPoint(remoteIPAddress, port);
            mSocket.Connect(remoteEndPoint);
            
            //String szData = "Hello There";
            //byte[] byData = System.Text.Encoding.ASCII.GetBytes(szData);
            //mSocket.Send(byData);
        }
        #endregion 

        #region Public Methods
        public void Send(byte[] pByteArray)
        {

            //BinaryFormatter bf = new BinaryFormatter();
            //bf.Serialize(pByteArray); 

            mSocket.Send(pByteArray); 
        }
        #endregion 

        #region Members & Fields
        protected const string LIGHT_BOX_IP = "10.1.1.98";

        string mPort = "6038";

        protected Socket mSocket;

        protected string mIP = LIGHT_BOX_IP;
        public string IP
        {
            get { return mIP; }
            set { mIP = value; } 
        }
        #endregion 
    }
}
