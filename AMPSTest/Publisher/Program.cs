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

                // Publish
                while(true)
                {
                    foreach(string topic in ConstLib.topics)
                    {
                        string data = "{ \"message\" : \"data" + Guid.NewGuid().ToString() + "!\" }";
                        c.publish(topic, data);
                        Console.WriteLine($"{DateTime.Now.ToString() }-Published Topic:{topic}  message: {data}");
                        Thread.Sleep(200);
                    }
                }
            });
            Console.Read();
        }
    }
}
