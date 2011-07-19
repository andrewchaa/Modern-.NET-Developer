namespace Modern.NETDeveloper.Domain
{
    public class EmptyNicknameValidator : INicknameValidator
    {
        public bool Validate(string nickname)
        {
            return !string.IsNullOrEmpty(nickname);
        }
    }
}