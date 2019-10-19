using System.ComponentModel.DataAnnotations;

namespace _018ventilation.se.Models
{
    public class ContactModel
    {
        //[UmbracoDisplay("fullname"), UmbracoRequired("fullnamereq")]

        public string FullName { get; set; }

        //[UmbracoDisplay("email"), UmbracoRequired("reqemail")]
        public string Email { get; set; }

        //[UmbracoDisplay("messagetext")]
        [DataType(DataType.MultilineText)]
        public string Comment { get; set; }

        public string Cell { get; set; }
    }
}