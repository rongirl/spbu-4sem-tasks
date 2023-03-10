module EvenNumbers.Tests

open FsCheck
open FsUnit
open NUnit.Framework
open EvenNumbers

let data () = 
    [
        [], 0
        [1 .. 5], 2
        [1 .. 10], 5
        [-4 .. 4], 5
    ] |> List.map (fun (list, result) -> TestCaseData(list, result))

[<TestCaseSource("data")>]
let numberOfEvenNumbersMapTest list expected =
    numberOfEvenNumbersMap list |> should equal expected

[<TestCaseSource("data")>]
let numberOfEvenNumbersFilterTest list expected =
    numberOfEvenNumbersFilter list |> should equal expected

[<TestCaseSource("data")>]
let numberOfEvenNumbersFoldTest list expected =
    numberOfEvenNumbersFold list |> should equal expected

let checkMapAndFold (list:list<int>) = numberOfEvenNumbersMap list = numberOfEvenNumbersFold list
Check.QuickThrowOnFailure checkMapAndFold

let checkFoldAndFilter (list:list<int>) = numberOfEvenNumbersFold list = numberOfEvenNumbersFilter list
Check.QuickThrowOnFailure checkFoldAndFilter