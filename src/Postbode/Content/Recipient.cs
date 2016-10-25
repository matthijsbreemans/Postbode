using Postbode.Interfaces;

namespace Postbode.Content
{
    public class Recipient : IRecipient
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public Recipient(string email, string name = null)
        {
            Email = email;
            Name = name;
        }

        public override string ToString()
        {
            return $"{Name} <{Email}>";
        }
    }
}
