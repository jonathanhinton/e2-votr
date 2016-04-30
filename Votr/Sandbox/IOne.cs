using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Votr.Sandbox
{
    /// <summary>
    /// Skeleton
    /// </summary>
    public interface IOne
    {
        int printInt();  
    }

    public class One : IOne
    {
        //must implement all interface method signatures.
        //how to implement an interface

        public int printInt() //must be public
        {
            return 1;
        }
    }

    public class Number
    {
        //how to interact with an interface
    }
}