using Xunit;

namespace Example.Tests
{
    public class AesTransformerTest
    {
        private readonly ITransformer _transformer;

        public AesTransformerTest()
        {
            _transformer = new AesTransformer();
        }

        [Fact]
        public void IntegrationTest()
        {
            string value = "cool value";

            string encrypted = _transformer.Encrypt(value, out string key, out string iv);
            string decrypted = _transformer.Decrypt(encrypted, key, iv);

            Assert.NotEqual(value, encrypted);
            Assert.Equal(value, decrypted);
        }
    }
}