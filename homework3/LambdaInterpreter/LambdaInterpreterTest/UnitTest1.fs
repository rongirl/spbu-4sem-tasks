module LambdaInterpreterTest

open NUnit.Framework
open LambdaInterpreter

[<SetUp>]
let Setup () =
    ()

[<Test>]
let Test1 () =
    LambdaAbstraction("x", Variable ("x"));
