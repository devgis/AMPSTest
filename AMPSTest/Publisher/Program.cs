using AMPS.Client;
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
                c.connect("tcp://52.207.213.242:9007/amps/json");
                c.logon();

                int i = 0;
                // Publish
                while(true)
                {
                    string data = "{ \"message\" : \"data" + (i++) + "!\" }";
                    c.publish("test", data);
                    Console.WriteLine($"{DateTime.Now.ToString() }-Received message: {data}");
                    Thread.Sleep(100) ;
                }
                
            });
            Console.Read();
        }
    }
}
