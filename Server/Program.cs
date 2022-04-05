using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using static System.Console;

namespace Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Socket listen = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Socket conexion;
            IPEndPoint connect=new IPEndPoint(IPAddress.Parse("127.0.0.1"), 6400);

            listen.Bind(connect);
            listen.Listen(10);

            conexion=listen.Accept();
            WriteLine("Coneccion aceptada");

            byte[] recibir_Info=new byte[100];
            string data = "";
            int array_size =0;

            array_size=conexion.Receive(recibir_Info,0,recibir_Info.Length,0);
            Array.Resize(ref recibir_Info,array_size);
            data = Encoding.Default.GetString(recibir_Info);

            WriteLine("La indo recibido es:{0}",data);
            ReadKey();
        }
    }
}
