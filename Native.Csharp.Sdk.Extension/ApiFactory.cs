using Native.Csharp.Sdk.Cqp;
using Native.Csharp.Sdk.Cqp.EventArgs;
using Native.Csharp.Sdk.Cqp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Native.Csharp.Sdk.Extension
{
    public static class ApiFactoryExtension
    {
        public static bool SendMessage(this CQGroupMessageEventArgs e)
        {
            return true;
        }
    }
}
