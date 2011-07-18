namespace Modern.NETDeveloper.Domain
{
    public class NicknameValidator
    {
        public bool Validate(string nickname)
        {
            return !string.IsNullOrEmpty(nickname);
        }
    }
}