module ParseTree.Tests
 
open FsUnit 
open NUnit.Framework
open ParseTree

let data () = 
    [
        Operand(0), 0
        Addition(Division(Operand(10), Operand(2)), Multiplication((Subtraction(Operand(20), Operand(10)), Operand(5)))), 55
        Multiplication(Operand(2), Operand(5)), 10
        Division(Multiplication(Operand(6), Operand(4)), Operand(2)), 12
    ] |> List.map (fun (tree, result) -> TestCaseData(tree, result))

[<TestCaseSource("data")>]
let parseTreeTests tree expected = 
    calculate tree |> should equal expected