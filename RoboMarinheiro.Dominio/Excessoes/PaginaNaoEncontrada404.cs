using System;
using System.Runtime.Serialization;

namespace RoboMarinheiro.Dominio.Excessoes
{
    [Serializable]
    public class PaginaNaoEncontrada404Exception : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public PaginaNaoEncontrada404Exception()
        {
        }

        public PaginaNaoEncontrada404Exception(string message) : base(message)
        {
        }

        public PaginaNaoEncontrada404Exception(string message, Exception inner) : base(message, inner)
        {
        }

        protected PaginaNaoEncontrada404Exception(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}