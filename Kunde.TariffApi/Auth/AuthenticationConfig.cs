﻿namespace Kunde.TariffApi.Auth
{
    public class AuthenticationConfig
    {
        public AuthenticationConfig(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
