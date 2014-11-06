namespace MavenThought.Commons.Tests

module PropertyChangedNotification =

    open System
    open NUnit.Framework
    open FsUnit
    open Foq
    open MavenThought.Commons.Events

    type DummyNotifyPropertyChanged() =
        inherit AbstractNotifyPropertyChanged()

        member val Property = false with get, set

        member this.Notify(propertyName: string, b: bool) =
            this.NotifyPropertyChanged(propertyName, ref this.Property, true)
        
    module ``When notify is called`` =

        let mutable called = false

        [<Test>]
        let ``The handler is called`` () =

            let handler = (fun args -> called <- true)

            let sut = DummyNotifyPropertyChanged()

            sut.PropertyChanged.Add handler

            let actual = sut.Notify("CurrentProperty", true)

            actual |> should be True
            called |> should be True

    module ``When notify is called with an expression`` =

        let mutable called = false

        [<Test>]
        let ``The handler is called`` () =

            let handler = (fun args -> called <- true)

            let sut = DummyNotifyPropertyChanged()

            sut.PropertyChanged.Add handler

            let actual = sut.Notify("CurrentProperty", true)

            actual |> should be True
            called |> should be True
