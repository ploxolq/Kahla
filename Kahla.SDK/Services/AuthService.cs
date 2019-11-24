﻿using Aiursoft.Pylon.Interfaces;
using Aiursoft.Pylon.Models;
using Aiursoft.Pylon.Models.ForApps.AddressModels;
using System.Threading.Tasks;

namespace Kahla.SDK.Services
{
    public class AuthService : IScopedDependency
    {
        private readonly SingletonHTTP _http;
        private readonly KahlaLocation _kahlaLocation;

        public AuthService(
            SingletonHTTP http,
            KahlaLocation kahlaLocation)
        {
            _http = http;
            _kahlaLocation = kahlaLocation;
        }
        public async Task<string> OAuthAsync()
        {
            var url = new AiurUrl(_kahlaLocation.ToString(), "Auth", "OAuth", new { });
            var result = await _http.Track(url);
            return result;
        }

        public async Task<string> SignIn(int code)
        {
            var url = new AiurUrl(_kahlaLocation.ToString(), "Auth", "AuthResult", new AuthResultAddressModel
            {
                Code = code
            });
            var result = await _http.Track(url);
            return result;
        }
    }
}
