using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllpFit.Library.Exceptions
{
    public class DomainException : Exception
    {
        public string PortugueseMessage { get; protected set; } = string.Empty;

        public DomainException()
        { }

        public DomainException(string message)
            : base(message)
        { }

        public DomainException(string message, string portugueseMessage)
            : base(message)
        {
            PortugueseMessage = portugueseMessage;
        }

        public DomainException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
