namespace Dezrez.Rezi.Domain.People
{
    public class Person : BaseEntity
    {
        public virtual string Name { get; set; }
        public virtual string Notes { get; set; }
        public virtual ContactDetail ContactDetails { get; set; }
    }
}