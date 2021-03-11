using Xunit;

namespace Example.Tests
{
    public class CommandExecutorTests
    {
        private readonly CommandExecutor _executor;

        public CommandExecutorTests()
        {
            _executor = new CommandExecutor();
        }
        
        [Fact]
        public void TestCommandExecutor()
        {
            _executor.Start(".");
        }
    }
}