using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AydinCompany.Core.CrossCuttingConserns.Logging
{
    //Loglanacak metohod'a ait property'ler.
    //O metot'a ait bilgiler.
    public class LogDetail
    {
        public string FullName { get; set; } //metot full adı.
        public string MethodName { get; set; }//metot adı.
        public List<LogParameter> Parameters { get; set; }
    }
}
