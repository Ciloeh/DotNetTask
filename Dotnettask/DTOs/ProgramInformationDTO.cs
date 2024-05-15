using Dotnettask.Services;

namespace Dotnettask.DTOs
{
    public class ProgramInformationDTO : ICosmosEntity
    {
        public string Id { get; set; }
        public string ProgramId { get; set; }
        public string ProgramTitle { get; set; }
        public string ProgramDescription { get; set; }
        public List<UserInformationDTO> UserInformation { get; set; }
    }



}
