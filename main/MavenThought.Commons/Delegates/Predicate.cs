namespace MavenThought.Commons.Delegates
{
    /// <summary>
    /// Binary predicate declaration
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <param name="first"></param>
    /// <param name="second"></param>
    public delegate bool Predicate<T1, T2>(T1 first, T2 second);
}