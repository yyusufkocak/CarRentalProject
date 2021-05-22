using Core.Entities.Concrete;
using Entities.Concrete;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Business
{
    public static class Messages
    {
        public static string MaintenanceTime = "Sistem Bakımda";


        public static string CarAdded = "Araba Eklendi";
        public static string CarNameInvalid = "Geçersiz Araba İsmi";
        public static string CarDeleted = "Araba Silindi";
        public static string CarIdInvalid = "Geçersiz Araba Id";
        public static string CarUpdated = "Araba Güncellendi";


        public static string ColorAdded = "Renk Eklendi";
        public static string ColorNameInvalid = "Geçersiz Renk İsmi";
        public static string ColorDeleted = "Renk Silindi";
        public static string ColorIdInvalid = "Geçersiz Renk Id";
        public static string ColorUpdated = "Renk Güncellendi";


        public static string BrandAdded = "Marka Eklendi";
        public static string BrandNameInvalid = "Geçersiz Marka İsmi";
        public static string BrandDeleted = "Marka Silindi";
        public static string BrandIdInvalid = "Geçersiz Marka Id";
        public static string BrandUpdated = "Marka Güncellendi";


        public static string CustomerAdded = "Müşteri Eklendi";
        public static string CustomerNameInvalid = "Geçersiz Müşteri İsmi";
        public static string CustomerDeleted = "Müşteri Silindi";
        public static string CustomerIdInvalid = "Geçersiz Müşteri Id";
        public static string CustomerUpdated = "Müşteri Güncellendi";


        public static string UserAdded = "Kullanıcı Eklendi";
        public static string UserNameInvalid = "Geçersiz Kullanıcı İsmi";
        public static string UserDeleted = "Kullanıcı Silindi";
        public static string UserIdInvalid = "Geçersiz Kullanıcı Id";
        public static string UserUpdated = "Kullanıcı Güncellendi";


        public static string RentalAdded = "Kiralama Oluşturuldu";
        public static string RentalDeleted = "Kiralama Silindi";
        public static string RentalUpdated = "Kiralama Güncellendi";
        public static string DeleteInvalidRental = "Şart Sağlanmadı,Silme İşlemi Başarısız";
        public static string RentalInvalid = "Geçersiz Kiralama";
      

        public static string CarImageAdded = " Resim Eklendi";
        public static string CarImageDeleted = "  Resim Silindi";
        public static string CarImageIdInvalid = "Geçersiz Id";
        public static string CarImageUpdated = "Resim Güncellendi";
        public static string CarImageInvalid = " Geçersiz Resim";
        public static string CarImageLimitFail = "Resim Limit Hatası";
        public static string CarImageNotFound = "Resim Bulanamadı";


        public static string AuthorizationDenied = "Yetkilendirme Hatası";
        public static string UserRegistered = "Kullanıcı Kaydı Başarılı";
        public static string PasswordNotStrongEnough = "Şifre Yeterince Güçlü Değil";
        public static string PasswordError = "Hatalı Şifre";
        public static string SuccessLogin = "Başarılı Giriş";
        public static string UserAlreadyExists = "Kullanıcı zaten var";
        public static string UserNotFound = "Kullanıcı Bulunamadı";
        
    }
}