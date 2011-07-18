namespace Modern.NETDeveloper.Domain
{
    public class EmptyNicknameValidator
    {
        public bool Validate(string nickname)
        {
            return !string.IsNullOrEmpty(nickname);
        }
    }
}