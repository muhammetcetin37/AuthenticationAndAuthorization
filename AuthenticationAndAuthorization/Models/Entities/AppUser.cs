using Microsoft.AspNetCore.Identity;

namespace AuthenticationAndAuthorization.Models.Entities
{

    //IdentityUser => Microsoft.Extensions.Identity.Stores  sahip paket yüklendi.
    //AspNetCore.Identity bize hazır olarak sulunmuş bir sınıf. AspNetCore.Identity aracılığı ile işlemlerimizi hızlıca yürütebiliriz. İçerisinde kullanıcın tüm işlmelerini yürütebilceğimiz hazır CRUD methodları ve migration ile veritabanına hızlı gönderebileceğiniz sınıflar bulunmaktadırö. Kullanıcı işlemleri için veri tabanında ve uygulama tarafında hazırlanması gereken varlıkları bize 8 adet sınıf aracılığıyla sunmaktadır. Migtation esnasında göç ettirilen sınıflar incelendiğinde bunu görebilirsiniz. Bunun yanında authentication işlemleri için yada CRUD operasyonlarında kullanacabileceğimiz hazır methodlar senkron ve asenkron program için bizlere sunmaktadır. Örneğin check credention, password haser, login ve registration işlemleride kolaylıkla yürütülebillir.

    //Günümüzde bir çok firma Identity mekanizması üzerine kendi yapılarını yada projede ihtiyaç duydukları özellikleri kazandırarak kendi Identity yapılarını oluşturmaktadır. Bizde aşağıda görebileceğiniz gibi Identity ile gelen user özellikllerinin yanına minik bir log özelikleri ve meslek alanı ekledik.

    public class AppUser : IdentityUser, IBaseEntity
    {
        private DateTime _CreateDate = DateTime.Now;
        public DateTime CreateDate { get => _CreateDate; set => _CreateDate = value; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        private Status _status = Status.Active;

        public Status Status
        {
            get => _status;
            set => _status = value;
        }

        public string? TcNo { get; set; }
    }
}