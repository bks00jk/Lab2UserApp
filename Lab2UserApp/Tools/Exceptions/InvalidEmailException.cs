using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMA.ProgrammingInCSharp2023.Lab2UserApp.Tools.Exceptions
{
    internal class InvalidEmailException : Exception
    {
        internal InvalidEmailException(string message) : base(message) { }
    }
}
