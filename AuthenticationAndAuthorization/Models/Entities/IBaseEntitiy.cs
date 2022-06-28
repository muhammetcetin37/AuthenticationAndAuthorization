namespace AuthenticationAndAuthorization.Models.Entities
{
    public enum Status
    {
        Active = 1,
        Modified = 2,
        Delete = 3
    }


    public interface IBaseEntity
    {
        //IBaseEntity.cs sınıfında yada daha önce hazırladığımız base sınıf mantıklarında her zaman Id'yi ilgili ata sınıftan dağıtırdık. Bu projede bunu yapmadık. Çünkü "AppUser.cs" sınıfında IdentityUser.cs sınıfının bize sunduğu hazır varlıklardan faydalanacağız ve farkına varcağınız gibi bu hazır varlıkların kendi Id'leri ve iyi bir şekilde düşünülmüş kullanıcı bazlı üyeleri bulunmaktadır. Bu yüzden IBaseEntity içerisinde Id barındırmadık. Şayet bunu yapsaydık IdentityUser ile IBaseEntity üzerinden dağıttığımız Id'ler çakışacaktı.

        //Ayrıca arayüzlere bu şekilde üye tanımlamanın yazılım dğnyaısnda hoş karşılanmadığını unutmayalım ama bizim uygulamamızdaki AppUser sınıfı concrete olan Identitiy sınıfından miras alacağından burada AppUser'ın soyutlamaya bağlı kalması açısından interface kullanmak zorundaydık. 


        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public DateTime? DeleteDate { get; set; }

        public Status Status { get; set; }
    }
}