using System;
using System.IO;
using System.Text;
using Tcp.Classes;
using Tcp.Classes.Messages;

namespace Tcp
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlStorageTypes.Register<Exception>();

            //client
            LoginMessage _loginObj = new LoginMessage();
            /*
            {
                Login = "Jacek"
            };
            */

            //server

            _loginObj.ProcessRequest();

            string _sXml = Encoding.UTF8.GetString(_loginObj.ToXml().ToArray());


            Console.WriteLine();
            Console.WriteLine(_sXml);
            Console.WriteLine();

            //client

            try
            {
                LoginMessage _loginObj2 = new LoginMessage();

                _loginObj2.FromXml(new MemoryStream(Encoding.UTF8.GetBytes(_sXml)));

                _loginObj2.ProcessResponse();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Wystąpił wyjątek! {e.Message}");
            }

            Console.ReadKey();
        }
    }
}
