using System.Net;
using System.Net.Sockets;
using System.Text;

public class BS
{
    byte[] bytes = new byte[1024];

    public void StartClient()
    {
        try
        {
            var hostname = Dns.GetHostName();
            IPHostEntry ip_host_entry = Dns.GetHostEntry(hostname);
            Console.WriteLine($"HOST: {hostname}");
            IPAddress ip = ip_host_entry.AddressList[0];
            IPEndPoint remoteEp = new IPEndPoint(ip, 453323);

            Socket sender = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                sender.Connect(remoteEp);
                Console.WriteLine("socket connected");
                string wha = sender.RemoteEndPoint.ToString();
                byte[] msg = Encoding.ASCII.GetBytes("Tis just a test");
                int byteSent = sender.Send(msg);
                int byteRec = sender.Receive(bytes);
                Console.WriteLine($"ECHO TEST {Encoding.ASCII.GetString(bytes, 0, byteRec)}");

                sender.Shutdown(SocketShutdown.Both);
                sender.Close(); 
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            catch(SocketException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }
}