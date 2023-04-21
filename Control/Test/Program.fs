module Test 
open Control 
open FsUnit
open NUnit.Framework

[<Test>]
let TestForSuperMap() =
    Control.supermap (fun x -> [x * 10; x + 5]) [1; 2; 3] |> should equal [10; 6; 20; 7; 30; 8]

[<Test>]
let TestForSuperMapEmptyList() =
    Control.supermap (fun x -> [x * 10; x + 5]) [] |> should be Empty


[<Test>]
let TestForConcurrentStack() = 
    let stack = new Control.ConcurrentStack<int>()
    stack.TryPop() |> should equal None
    stack.Push 5
    stack.TryPop() |> should equal (Some(5))
    stack.TryPop() |> should equal None
    stack.Push 6
    stack.Push 7
    stack.TryPop() |> should equal (Some(7))
    stack.TryPop() |> should equal (Some(6))
    stack.TryPop() |> should equal None 
