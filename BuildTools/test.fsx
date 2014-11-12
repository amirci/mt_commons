#r @"../packages/FAKE/tools/FakeLib.dll"

#load "./config.fsx"

open System.IO
open Fake
open Config
open System.Configuration

let allTests = Map["CommonsF", "MavenThought.Commons.Epoch.Tests"; 
    "Commons", "MavenThought.Commons.Tests";
    "Commons.WPF", "MavenThought.Commons.Wpf.Tests";
    ]

let testFiles testPrj = sprintf "test/%s/bin/%s/*Tests.dll" testPrj (buildMode())

let runTests files =
    files
      |> NUnit (fun p ->
          {p with
             DisableShadowCopy = true
             ExcludeCategory = "DatabaseDependent"
             OutputFile = testDir + "/TestResults.xml" })

let addTestTarget targetName testPrj =
    let csProj = sprintf "./test/%s/%s.csproj" testPrj testPrj
    let fsProj = sprintf "./test/%s/%s.fsproj" testPrj testPrj
    let prjFile = (if fileExists csProj then csProj else fsProj)

    Target ("Test:" + targetName) (fun _ ->
        (debugMode ())
        let testParams defaults = 
            {(setParams defaults) with
                Properties = 
                [
                    "Configuration", buildMode()
                    "Platform", "AnyCPU"
                ]
            }

        build testParams prjFile
        !! (testFiles testPrj) |> runTests
    )


Target "Test" (fun _ -> allTests |> Map.iter (fun name _ -> run ("Test:" + name)))

allTests |> Map.iter (fun name prj -> addTestTarget name prj)

