﻿using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace AccessManager.Sso.Certificates
{
    public class SigningIssuerCertificate : IDisposable
    {
        private readonly RSA rsa;

        public SigningIssuerCertificate()
        {
            rsa = RSA.Create();
        }

        public RsaSecurityKey GetIssuerSigningKey()
        {
            string publicXmlKey = File.ReadAllText("./public_key.xml");
            rsa.FromXmlString(publicXmlKey);

            return new RsaSecurityKey(rsa);
        }

        public void Dispose()
        {
            rsa?.Dispose();
        }
    }
}
