using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services
{
   public interface ITaxNumberLookupService
    {
        //vergi numarası sorgulama sistemi
        //gerçekten böyle bir vergi numarası olup ollmadığını
        //abstraction
        //bizim vergi sorgulama sistemimiz olsun nasıl çalılır bilmiyıruz ya da farklı şekillerde sorgulama olabilir sistemde bu sebeple özetini yazmış olduk
        bool LookUp(string taxNumber);
    }
}
