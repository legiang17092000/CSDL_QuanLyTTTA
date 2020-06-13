using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSDL_QuanLyTTTA.Libs
{
    class Username
    {
        private static string _username = "";
        public static string username
        {
            get { return _username; }
            set { _username = value; }
        }
    }
}
