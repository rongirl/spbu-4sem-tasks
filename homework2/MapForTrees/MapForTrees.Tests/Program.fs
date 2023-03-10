module MapForTrees.Tests

open FsUnit 
open NUnit.Framework
open MapForTrees

[<Test>]
let mapForEmptyTreeTest () =
    map Empty (fun x -> x + 1) |> should equal (Empty:Tree<int>)

[<Test>]
let mapForTreeTest() =
    let tree = Node(4, Node(2, Node(0, Empty, Empty), Node(3, Empty, Empty)), Node(5, Empty, Empty))
    let func x = x + 1
    let expected = Node(5, Node(3, Node(1, Empty, Empty), Node(4, Empty, Empty)), Node(6, Empty, Empty))
    map tree func |> should equal expected 


