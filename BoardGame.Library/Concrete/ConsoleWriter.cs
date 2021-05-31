using BoardGame.Library.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGame.Library.Concrete
{
    public class ConsoleWriter : ITextWriter
    {
        public void Write(string toWrite)
        {
            Console.WriteLine(toWrite);
        }
    }
}
