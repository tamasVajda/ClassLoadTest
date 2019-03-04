using System;
using System.Collections.Generic;
using System.Text;

namespace DebendencyContainer
{
    public class MethodManager
    {
        public bool GetResult ()
        {
            DataClass mydata = new DataClass(); ;
            var method = Resolver.GetMethod(mydata.GetType());

            return method.myMethod();
        }
    }
}
