using System;
using Microsoft.Owin.Hosting;

namespace OrdiOwin
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            StartOptions options = new StartOptions();
            options.Urls.Add("http://localhost:8080");
            options.Urls.Add("http://127.0.0.1:8080");
#if RELEASE
            options.Url.Add("http://*:8080");
#endif

            using (WebApp.Start<OrdiOwin.Startups.OrdiStartup>(options))
            {
                Console.WriteLine("Ordi Owin Service Start");

                var startFlag = true;
                while (startFlag)
                {
                    var str = Console.ReadLine();
                    switch (str)
                    {
                        case "exit":
                            startFlag = false;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}
