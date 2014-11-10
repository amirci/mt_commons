namespace MavenThought.Commons.Tests

module ``Date extensions tests`` =

    open System
    open FsCheck
    open FsCheck.NUnit
    open MavenThought.Commons.Epoch

    module ``Some time Ago extensions`` =

        [<Property>]
        let ``Returns the seconds ago`` (some:int) =
            some > 0 ==> (some .Seconds().Ago = (DateTime.Today.AddSeconds(-float(some))))

        [<Property>]
        let ``Returns the minutes ago`` (some:int) =
            some > 0 ==> (some .Minutes().Ago = (DateTime.Today.AddMinutes(-float(some))))

        [<Property>]
        let ``Returns the days ago`` (some:int) =
            some > 0 ==> (some .Days().Ago = (DateTime.Today.AddDays(-float(some))))

        [<Property>]
        let ``Returns the years ago`` (some:int) =
            some > 0 ==> (some .Years().Ago = (DateTime.Today.AddYears(-some)))

        [<Property>]
        let ``Returns the months ago`` (some:int) =
            some > 0 ==> (some .Months().Ago = (DateTime.Today.AddMonths(-some)))

        [<Property>]
        let ``Returns the weeks ago`` (some:int) =
            some > 0 ==> (some .Weeks().Ago = (DateTime.Today.AddDays(-float(some*7))))

    module ``Some time FromNow extensions`` =
        [<Property>]
        let ``Returns the seconds from now`` (some:int) =
            some > 0 ==> (some .Seconds().FromNow = (DateTime.Today.AddSeconds(float(some))))

        [<Property>]
        let ``Returns the minutes from now`` (some:int) =
            some > 0 ==> (some .Minutes().FromNow = (DateTime.Today.AddMinutes(float(some))))

        [<Property>]
        let ``Returns the days from now`` (some:int) =
            some > 0 ==> (some .Days().FromNow = (DateTime.Today.AddDays(float(some))))

        [<Property>]
        let ``Returns the years from now`` (some:int) =
            some > 0 ==> (some .Years().FromNow = (DateTime.Today.AddYears(some)))

        [<Property>]
        let ``Returns the months from now`` (some:int) =
            some > 0 ==> (some .Months().FromNow = (DateTime.Today.AddMonths(some)))

        [<Property>]
        let ``Returns the weeks from now`` (some:int) =
            some > 0 ==> (some .Weeks().FromNow = (DateTime.Today.AddDays(float(some*7))))


