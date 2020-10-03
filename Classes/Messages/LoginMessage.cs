using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using Tcp.Interfaces;

namespace Tcp.Classes.Messages
{
    [DataContract]
    public class LoginMessage : XmlStorage<LoginMessage>, IMessage
    {
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public Response Response { get; private set; }

        public LoginMessage()
        {
            Login = string.Empty;
        }

        public override bool InitializeFromObject(LoginMessage Object)
        {
            this.Login = Object.Login;
            this.Response = Object.Response;

            return true;
        }

        public override string ToString()
        {
            return $"Login={Login}";
        }

        public IMessage ProcessRequest()
        {
            if (string.IsNullOrEmpty(Login))
            {
                Response = new Response(-1, new Exception("Brak loginu"));
            }
            else
            {
                Response = new Response(0, "Użytkownik poprawnie zalogowany");
            }

            return this;
        }

        public IMessage ProcessResponse()
        {
            if (Response?.Object is Exception)
            {
                throw Response.Object as Exception;
            }

            Console.WriteLine($"Odpowiedz={Response}");

            return this;
        }
    }
}
