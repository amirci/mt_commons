using Rhino.Mocks;


namespace MavenThought.Commons.Tests
{
    /// <summary>
    /// Base class for tests that use mocking
    /// </summary>
    public abstract class BaseTestWithMocking
    {
        protected static T Mock<T>() where T : class
        {
            return MockRepository.GenerateMock<T>();
        }

        protected static T Stub<T>() where T : class
        {
            return MockRepository.GenerateStub<T>();
        }
    }
}
