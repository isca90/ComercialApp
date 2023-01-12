using System.ComponentModel.DataAnnotations;

namespace CommercialApp.Models
{
    public abstract class People
    {
       
        public int PeopleId { get; set; }
        [Required(ErrorMessage = "Contact name is required.Can only contain letters.It must be between 4 and 15 characters.")]
        [RegularExpression(@"^[a-zA-Z\s]{4,20}$", ErrorMessage = "Only alphabetic characters and spaces are allowed.")]
        public string  Name { get; init; }

        [Required(ErrorMessage = "Email address is required.Ex: example@example.com")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
         @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
         @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$",
 ErrorMessage = "Please enter a valid email address.Use lowercase please Ex: example@example.com")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        [RegularExpression(@"^[0-9A-Za-z]{4,15}$", ErrorMessage = "Can only contain letters and numbers. It must be between 4 and 15 characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,16}$",
         ErrorMessage = "Password must meet requirements: be between 8 and 16 characters; at least one uppercase letter A-Z; at least one lowercase letter a-z; " +
            "at least one digit 0-9; at least one special character =.*?[#?!@$%^&*-]")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Phone number is required.")]
        [RegularExpression(@"^([9][1236])[0-9]*$", ErrorMessage = "Please enter a valid mobile phone number. For now we only accept portuguese numbers")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Address address is required.")]        
        [RegularExpression(@"^[a-zA-Z0-9_ ]{5,70}$", ErrorMessage = "Can only contain letters and numbers. It must be between 5 and 70 characters")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Postal Code is required")]
        [RegularExpression(@"^\d{4}(-\d{3})?$", ErrorMessage = "A valid postal code is required. xxxx-xxx")]
        public string PostalCode { get; set; }

        [Required(ErrorMessage = "City is required")]
        [RegularExpression(@"^[a-zA-Z\s]{2,30}$", ErrorMessage = "Only alphabetic characters and spaces are allowed.")]
        public string City { get; set; }




    }
}
