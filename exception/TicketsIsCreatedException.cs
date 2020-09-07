using System;
using System.Runtime.Serialization;

namespace air_ticket_cashier
{
    [Serializable]
    internal class TicketsIsCreatedException : Exception
    {
        public TicketsIsCreatedException()
        {
        }

        public TicketsIsCreatedException(string message) : base(message)
        {
        }

        public TicketsIsCreatedException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TicketsIsCreatedException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}