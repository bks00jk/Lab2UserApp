using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMA.ProgrammingInCSharp2023.Lab2UserApp.Tools.Exceptions
{
    internal class InvalidNameException : Exception
    { 
        internal InvalidNameException(string message) : base(message) { }
    
    }
}
