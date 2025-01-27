using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chrison.Exceptions;

[Serializable]
public class IrdNumberHasInvalidCheckDigitException : Exception
{
    #region Constructor
    public IrdNumberHasInvalidCheckDigitException() : base("IRD check digit is invalid") { }
    public IrdNumberHasInvalidCheckDigitException(Exception exception) : base("IRD check digit is invalid", exception) { }
    #endregion
}