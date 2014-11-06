namespace MavenThought.Commons.Tests

module ``Date extensions tests`` =

    open System
    open NUnit.Framework
    open FsCheck
    open FsCheck.NUnit
    open MavenThought.Commons.Extensions

    module ``Some days ago`` =

        [<Property>]
        let ``Returns the days ago`` (some:int) =
            some > 0 ==> (some .Days().Ago = (DateTime.Today.AddDays(-float(some))))


    module ``Some days span`` =

        [<Property>]
        let ``Returns the days span`` (some:int) =
            some > 0 ==> (some .Days().Span = (new TimeSpan(int64(some))))
