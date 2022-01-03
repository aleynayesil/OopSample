using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public enum InvoiceUnitType//veri tabanına atacağım için ıd gibi değer verdim
    {
        Monthly = 100,
        Daily = 200,
        Hourly = 300,
        Quantity = 400
    }
   public class InvoiceItem
    {
  
        public string Description { get;private set; }
        //birim fiyat 10tl
        public decimal UnitPrice { get;private set; }
        //3 adet
        public int UnitType { get;private set; }
        //hizmet fiyatı 30tl
        private decimal _listPrice = 0;
        public decimal ListPrice { get{
                return _listPrice;
            } }
        //sıra no olarak kullanacağız
        //ilk sıra no 1 olduğundan default 1 olarak ayarladık
        public int SequenceNo { get; private set; } = 1;
        public string Id { get; set; }//string yaparız çünkü ıd tahmin edilemez olsun diye
        //miktar adet yada ay saat
        public int Amount { get; private set; }

        public InvoiceItem(string description,decimal unitPrice,InvoiceUnitType unitType,int amount)//listPrice :type ve unitprice ı biliyoruz hesaplanabilir.bu yüzden set yazmadık
        {
            Id = Guid.NewGuid().ToString();//string bir ıd türetecek
            UnitType = (int)unitType;//class enum alıp int olarak işaretledik
            SetAmount(amount);
            SetDescription(description);
            SetUnitPrice(unitPrice);
            //amount ve unitprice değerleri alındıktan sınra listprice hesaplıyoruz
            SetListPrice();
           
        }
        //listprice değerinin setter yazmadık veri tabanında bu alanı tutmaya gerek yok fakat program tarafından invoice bir item eklendiğinde toplam fatura tutarını bulmak için telk bir item ait toplam maliyet hesaplanmış olması gerekiyor 
        private void SetListPrice()
        {
            _listPrice = Amount * UnitPrice;
        }
        private void SetAmount(int amount)
        {
            if (amount<=0)
            {
                throw new Exception("0dan küçük girilemez.");
            }
            Amount = amount;
        }
        private void SetUnitType(InvoiceUnitType unitType)
        {
            UnitType = (int)unitType;
        }
        private void SetUnitPrice(decimal unitPrice)
        {
            if (unitPrice<=0)
            {
                throw new Exception("birim fiyatı 0 dan küçük olamaz");
            }
            UnitPrice = unitPrice;
        }
        private void SetDescription(string description)
        {
            if (string.IsNullOrEmpty(description))
            {
                throw new Exception("mal hizmet alanı boş geçilemez");
            }
            Description = description;
        }
        //sequence numarasını arttırma
        public void SetSequenceNumber(int sequenceNumber)//işlemi clasa yaptırdık
        {
            SequenceNo = sequenceNumber;
        }
        
    }
}
