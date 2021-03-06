using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.StoreContext.ValueObjects
{

    public class Email : Notifiable
    {
        public Email(string addrees)
        {
            Address = addrees;

            AddNotifications(new ValidationContract()
                .Requires()
                .IsEmail(Address, "Email", "O E-mail é inválido")
            );
        }
        public string Address { get; set; }

        public override string ToString()
        {
            return Address;
        }
    }
}