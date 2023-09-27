using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AydinCompany.Core.CrossCuttingConserns.Logging
{
    //Loglanacak metohod'a ait property'ler.
    //O method'a ait 
    public class LogDetail
    {
        public string FullName { get; set; }
        public string MethodName { get; set; }
        public List<LogParameter> Parameters { get; set; }
    }
}
