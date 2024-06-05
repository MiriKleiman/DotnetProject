using System.Runtime.Serialization;

namespace Subsriber_Service
{
    [Serializable]
    internal class MyException : Exception
    {
        private int v1;
        private string v2;
        private string message;

        public MyException()
        {
        }

        public MyException(string? message) : base(message)
        {
        }

        public MyException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        public MyException(int v1, string v2, string message)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.message = message;
        }

        protected MyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}