#r @"../packages/FAKE/tools/FakeLib.dll"

#load "./config.fsx"
#load "./userInput.fsx"

open Fake
open Config
open System
open System.Diagnostics
open System.IO
open System.Xml
open System.Xml.XPath
open UserInput


module Deploy =

    type DeployTarget = {iis: string; deployDir: string}
