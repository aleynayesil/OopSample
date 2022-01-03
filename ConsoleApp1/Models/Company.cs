
using ConsoleApp1.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Models
{
    public class Company
    {
        public string Name { get; private set; }//property encapsulation
        public string Address { get; private set; }
        //vergiNo
        public string TaxNumber { get; private set; }
        //şirket hattı
        public string  PhoneNumber { get; set; }

        private ICompanyAddressService _companyAddressService;
        private ITaxNumberLookupService _taxNumberLookupService;//polimorphsm
        //zorunlu alanları contract alıyoruz

        public Company(string name,string address,string taxNumber, ICompanyAddressService companyAddressService,ITaxNumberLookupService taxNumberLookupService)
        {
            _companyAddressService = companyAddressService;
            _taxNumberLookupService = taxNumberLookupService;
            SetCompanyName(name);
            SetAddress(address);
            SetTaxNumber(taxNumber);
        }
        public void SetPhoneNumber(string phoneNumber)//set ile girebilir
        {
            if (string.IsNullOrEmpty(phoneNumber))
            {
                throw new Exception("telefon numarası boş geçilemez");
            }
            PhoneNumber = phoneNumber;
        }
        private void SetTaxNumber(string taxNumber)//private çünkü contructor ile girilmesini istiyorum
        {
            var result = _taxNumberLookupService.LookUp(taxNumber);//class encapsulation
            if (!result)
            {
                throw new Exception("böyle bir vergi numarası sistemde yok");

            }
            TaxNumber = taxNumber;
        }
        private void SetAddress(string address)
        {
            if (string.IsNullOrEmpty(address))
            {
                throw new Exception("adres bilgisi boş olamaz");
            }
            if (address.Length<20)
            {
                throw new Exception("minimum 20 karakter olmalı");
            }
            var result = _companyAddressService.CheckAddress(address);//metod encapsulation
            //adres yoksa hata veer
            if (result==false)
            {
                throw new Exception("böyle bir adress sistemde bulunamamıştır");
            }
            Address = address.Trim();
        }

        //adressservice ile bu adresin gerçekte olup olmadığını teyit etmeliyiz
        private void SetCompanyName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new Exception("Şirket adı boş geçilemez.");
            }
            //kullanıcı input içerisinden name alanını ön arkasında boşluklu girilebilir bu boşlukları sisteme girmeden önce kaldırıyoruz.

            //trim sağdan soldan boşukları alır       ali     ='ali'
            Name = name.Trim();
        }

    }
}
