module LambdaInterpreter.Tests 

open LambdaInterpreter
open FsUnit 
open NUnit.Framework

let data () = 
    [   
        Application(LambdaAbstraction("x", Variable "x"), Variable "y"), Variable "y"
        Application(LambdaAbstraction("x", LambdaAbstraction("y", Application(Variable "x", Variable "y"))), Variable "y"), LambdaAbstraction ("a", Application (Variable "y", Variable "a"))
        Application(Variable "x", Variable "y"), Application(Variable "x", Variable "y")
        Application(LambdaAbstraction("x", Variable "y"), Application(LambdaAbstraction("x", Application(Variable "x", Variable "x")), LambdaAbstraction("x", Application(Variable "x", Variable "x")))), 
        Variable "y"

    ] |> List.map (fun (input, result) -> TestCaseData(input, result))

[<TestCaseSource(nameof data)>]
let betaReductionTest input expected  =  
     LambdaInterpreter.betaReduce input |> should equal expected