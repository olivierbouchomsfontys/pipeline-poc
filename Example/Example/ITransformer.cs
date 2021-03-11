namespace Example
{
    public interface ITransformer
    {
        string Encrypt(string input, out string key, out string iv);

        string Decrypt(string input, string key, string iv);
    }
}