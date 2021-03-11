using System;

namespace Example
{
    public class User
    {
        public Guid Id { get; set; }
        
        public string Email { get; set; }
        
        public string Password { get; set; }
        
        public string Salt { get; set; }
        
        public string Secret { get; set; }
        
        public string SecretKey { get; set; }
        
        public string SecretIv { get; set; }
    }
}