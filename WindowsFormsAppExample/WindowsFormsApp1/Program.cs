using System;
using System.Windows.Forms;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting;

namespace WindowsFormsApp1
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            TcpChannel chan = new TcpChannel(8085);
            ChannelServices.RegisterChannel(chan);

            RemotingConfiguration.RegisterWellKnownServiceType(System.Type.GetType("ServerClass.myRemoteClass,ServerClass"), "RemoteTest", WellKnownObjectMode.SingleCall);
           System.Console.WriteLine("Hit <enter> to exit..");
            System.Console.ReadLine();
        }
    }
}
