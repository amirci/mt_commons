
namespace MavenThought.Commons.Delegates
{
    /// <summary>
    /// Delegate for methods that generate values without parameters
    /// </summary>
    /// <typeparam name="TResult">Type of the result</typeparam>
    public delegate TResult Generator<TResult>();
}