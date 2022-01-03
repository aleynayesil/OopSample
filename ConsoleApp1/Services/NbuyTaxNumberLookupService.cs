using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services
{
    public class NbuyTaxNumberLookupService : ITaxNumberLookupService
    {
        private List<string> _taxNumber
        {
            get
            {
                return new List<string> { 
                    "312314132",
                    "431242541",
                    "2314524322",
                    "2543256132",
                    "5142145242"
                };
            }
        }
        public bool LookUp(string taxNumber)
        {
            return _taxNumber.Any(x => x == taxNumber);
        }
    }
}
