using System.Collections.Generic;

namespace Modern.NETDeveloper.Domain
{
    public class DuplicatedNicknameValidator : IValidator
    {
        private readonly IList<string> _nicknames;

        public DuplicatedNicknameValidator(IList<string> nicknames)
        {
            _nicknames = nicknames;
        }

        public bool Validate(string nickname)
        {
            return !_nicknames.Contains(nickname);
        }
    }
}