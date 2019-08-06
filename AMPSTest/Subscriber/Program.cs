using AMPS.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem(o =>
            {
                Client c = new Client("subscriber");

                // Connect and logon
                c.connect("tcp://52.207.213.242:9007/amps/json");
                c.logon();

                Command cmd = new Command(Message.Commands.Subscribe).setTopic("test");
                var id = c.executeAsync(cmd, (message) => {
                    System.Console.WriteLine($"{DateTime.Now.ToString() }-Received message: {message.Data}");
                });
            });
            Console.Read();
        }
    }
}
