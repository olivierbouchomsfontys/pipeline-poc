namespace Example.Tests.Mocks
{
    public class NullPasswordGenerator : IPasswordGenerator
    {
        public string GeneratePassword()
        {
            return "password";
        }
    }
}