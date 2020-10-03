using System;
using System.IO;
using System.Text;
using Tcp.Classes.Messages;

namespace Tcp
{
    class Program
    {
        static void Main(string[] args)
        {
            var _loginMsgObj = new LoginMessage();

            try
            {
                _loginMsgObj.ProcessRequest();
                _loginMsgObj.ProcessResponse();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Wyjątek! {e.Message}");
            }

            /*
            string _xml = Encoding.UTF8.GetString(_loginMsgObj.ToXml().ToArray());

            Console.WriteLine($"{_xml}");

            var _loginFromXml = new LoginMessage();

            var _memStream = new MemoryStream(Encoding.UTF8.GetBytes(_xml));

            _loginFromXml.FromXml(_memStream);

            Console.WriteLine(_loginFromXml);
            */

            Console.ReadKey();
        }
    }
}
