﻿using System.Configuration;
using System.Diagnostics;

namespace RemotePowerButton.API
{
    public class TokenValidator
    {
        protected readonly string validToken;

        public TokenValidator()
        {
            validToken = ConfigurationManager.AppSettings["securityToken"];
        }
        public bool IsValid(string token)
        {
            return token == validToken;
        }
    }
}