﻿using FloydPink.Flickr.Downloadr.Repository.Cryptography;
using NUnit.Framework;

namespace FloydPink.Flickr.Downloadr.Tests.CryptogrphyTests
{
    [TestFixture]
    public class CryptTests
    {
        private const string CryptKey = "kn98nkgg90sknka2038234(&9883!@%^";

        [Test]
        public void WillEncryptDecryptToken()
        {
            string token = "08kkh4208234n23ZS97Hj40u24";
            Assert.AreEqual(token, Crypt.Decrypt(Crypt.Encrypt(token, CryptKey), CryptKey));
        }
    }
}