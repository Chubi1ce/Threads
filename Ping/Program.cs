using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
/*
Напишите многопоточное приложение которое определяет
все IP-адресаинтернет-ресурса
и определяет до которого их них лучше Ping
*/
internal class Program
{
    private static void Main(string[] args)
    {
        string resource = "yandex.ru";
        var IpAdresses = Dns.GetHostAddresses(resource, AddressFamily.InterNetwork);
        Dictionary<IPAddress, long> pings = new Dictionary<IPAddress, long>(); ;
        List<Thread> threads = new List<Thread>();

        foreach (var address in IpAdresses)
        {
            Console.WriteLine(address);
        }

        foreach (var address in IpAdresses)
        {
            Thread tr = new Thread(() =>
            {
                Ping ping = new Ping();
                PingReply pingReply = ping.Send(resource);

                pings.Add(address, pingReply.RoundtripTime);
            });

            threads.Add(tr);
            tr.Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        long min = long.MaxValue;
        
        foreach (var ping in pings)
        {
            Console.WriteLine($"IP: {ping.Key}: Ping: {ping.Value}");
            if (ping.Value < min)
            {
                min = ping.Value;
            }
        }
        
        Console.WriteLine($"Minimum Ping = {min}");


    }
}