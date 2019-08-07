using AMPS.Client;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Publisher
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem(o =>
            {
                Client c = new Client("publisher");

                // Connect and logon
                c.connect(ConstLib.servername);
                c.logon();

                int i = 0;
                // Publish
                while(true)
                {
                    string data = "{ \"message\" : \"data" + (i++) + "!\" }";
                    string data2 = "{ \"message\" : \"data" + Guid.NewGuid().ToString() + "!\" }";
                    c.publish("test1", data);
                    c.publish("test1", data2);
                    Console.WriteLine($"{DateTime.Now.ToString() }-Published Topic:test1  message: {data}");
                    Console.WriteLine($"{DateTime.Now.ToString() }-Published Topic:test2  message: {data2}");
                    Thread.Sleep(100) ;
                }
                
            });
            Console.Read();
        }
    }
}
