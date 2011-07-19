using System;
using System.Collections.Generic;

namespace Modern.NETDeveloper.Domain
{
    public class DuplicatedNicknameValidator : IDuplicatedNicknameValidator
    {
        public bool Validate(string nickname, IList<string> nicknames)
        {
            return !nicknames.Contains(nickname);
        }
    }

    public interface IDuplicatedNicknameValidator
    {
        bool Validate(string nickname, IList<string> nicknames);
    }
}