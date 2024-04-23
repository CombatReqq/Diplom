using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Appdata
{
    internal class ConDB
    {
        public static navEntities context;
        public static navEntities GetCont()
        {
            if (context == null)
                context = new navEntities();
            return context;
        }

    }
}
