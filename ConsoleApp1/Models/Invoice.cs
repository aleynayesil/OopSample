using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
   public class Invoice
    {
        public DateTime InvoiceDate { get;private set; }
        //faturayı kesen  firma
        public Company Exporter { get;private set; }
        //mal hizmeti alan firma
        public Company Consignee { get;private set; }
        public decimal TotalPrice { get;private set; }

        private List<InvoiceItem> _items = new List<InvoiceItem>();//field //private alanlar _ olur
        //list item readonly olarak işaretleyip sadece bu alanın get  edilebileceğini saylemiş olduk //addinvoice metodunu kullanmaya zorunlu kıldkık
        public IReadOnlyList<InvoiceItem> Items => _items;//{get{
                                                            //returns item;
                                                          //}}aynı kod
        public string Id { get;private set; }

        //fatura kesmek için faturyı kesen ve fatura kesilen fi,rmalaeı bilmemiz yeterli
        public Invoice(Company exporter,Company consignee)
        {
            Id = Guid.NewGuid().ToString();
            //fatura kesim tarihi işlem yapılan tarih olmalı dışarıdan almıyoruz
            InvoiceDate = DateTime.Now;
            Exporter = exporter;
            Consignee = consignee;
        }
       

        //faturaya fatura ile ilgili hizmetlerin listesini ekldediğimiz metod
        public void AddInvoiceItem(InvoiceItem item)
        {
            //ıtem eklemeden çnce elimizdeki ınvoice ıtem count üzerinden kaçıncı sırada olduğumuzu bildiğimiz için  +1 arttırarak snumber güncellendi
            item.SetSequenceNumber(Items.Count+1);
            _items.Add(item);
            //her bir item eklendiğinde
            TotalPrice += item.ListPrice;
            
        }
    }
}
