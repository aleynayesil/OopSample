using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services
{
    //şirketin kayıt işlemleri register işlemleri sırasında böyle bir adresin olup olmadıını teyit etmek için sorgulama yapan servis
    //bu sorgulama servşsş şuan için bir liste üzeinden kontrol edilecek olup ilerleyen zamanlarda e devlet adres sorgulama sistemşne baplanabilir
    public class NBuyCompanyAddressService : ICompanyAddressService
    {
        List<string> companyAddress = new List<string>();

        public NBuyCompanyAddressService()
        {
            companyAddress.Add("Akşemsettin, Atatürk Blv, 34070 Eyüpsultan / İstanbul");
            companyAddress.Add("Göztepe, Kavacık Kavşağı, 34810 Beykoz/İstanbul");
            companyAddress.Add("1, Saip Molla Caddesi, Kısayol Sk., 34800 Beykoz / İstanbul");
            companyAddress.Add("Acarlar Mahallesi Acarkent Sitesi Acarblu Rezidans Ticaret Merkezi 1-A, Acarkent B1 Kapısı, 34800 Beykoz/İstanbul");
        }
        public bool CheckAddress(string address)
        {
            //any true false döner
            return companyAddress.Any(cAddress => cAddress == address);
        }
    }
}
