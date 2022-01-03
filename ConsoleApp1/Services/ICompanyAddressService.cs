using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services
{
    public interface ICompanyAddressService
    {
        //böyle bir adres var  mı yok mu kontrolü yapan metod
        bool CheckAddress(string address);
    }
}
