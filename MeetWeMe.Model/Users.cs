using System.ComponentModel.DataAnnotations;

namespace MeetWeMe.Model
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }

        public string FirstName { get; set; }

        public string NickName { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }


        public DateTime DateOfMeeting { get; set; } = DateTime.Today;

        public string LocationName { get; set; }
        public string Message { get; set; }


        public string City { get; set; }

        public Gender Gender { get; set; }

        public int CategoriesId { get; set; }


        public Categories? Categories { get; set; }

        public string PhotoPath { get; set; }




    }
}
