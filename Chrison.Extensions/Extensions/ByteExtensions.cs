using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chrison.Extensions;

public static class ByteExtensions
{
    /// <summary>
    /// Encode raw Byte Array to Base64 based Byte-Array
    /// </summary>
    /// <param name="rawData"></param>
    /// <returns></returns>
    public static byte[] EncodeToBase64Bytes(this byte[] rawData)
    {
        string base64String = Convert.ToBase64String(rawData);
        var returnValue = Convert.FromBase64String(base64String);
        return returnValue;
    }
}