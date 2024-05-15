using Dotnettask.Model;
using Dotnettask.Services;

namespace Dotnettask.DTOs
{
    public class UserInformationDTO: ICosmosEntity
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Nationality { get; set; }
        public string CurrentResidence { get; set; }
        public string IDNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public List<UserQuestionDto> UserQuestions { get; set; } // A user can have many questions
    }

}
