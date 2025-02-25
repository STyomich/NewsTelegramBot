namespace Core.Entities
{
    public class UserData
    {
        public Guid Id { get; set; }
        public string? UserNickname { get; set; }
        public DateTime DateOfLastRequest { get; set; }
    }
}