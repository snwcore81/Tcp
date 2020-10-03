using System;
using System.Collections.Generic;
using System.Text;

namespace Tcp.Interfaces
{
    public interface IMessage
    {
        IMessage ProcessRequest();
        IMessage ProcessResponse();
    }
}
