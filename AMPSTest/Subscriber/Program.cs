using AMPS.Client;
using Common;
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
                Client c = new Client(Guid.NewGuid().ToString());

                // Connect and logon
                c.connect(ConstLib.servername);
                c.logon();

                Command cmd = new Command(Message.Commands.Subscribe).setTopic("test1");
                var id = c.executeAsync(cmd, (message) => {
                    System.Console.WriteLine($"{DateTime.Now.ToString() }-Received message: {message.Data}");
                });
            });
            Console.Read();
        }
    }
}
