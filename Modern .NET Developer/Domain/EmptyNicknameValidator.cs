namespace Modern.NETDeveloper.Domain
{
    public class EmptyNicknameValidator : IValidator
    {
        public bool Validate(string nickname)
        {
            return !string.IsNullOrEmpty(nickname);
        }
    }
}