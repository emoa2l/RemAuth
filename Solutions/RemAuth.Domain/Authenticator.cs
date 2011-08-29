namespace RemAuth.Domain
{
    using SharpArch.Domain.DomainModel;

    public class Authenticator : Entity
    {
       public virtual string Name { get; set; }
    }
}