module BracketSequenceTest

open BracketSequence
open FsUnit 
open NUnit.Framework

let data () = 
    [   
        "()", true
        "(([{{[]}}]))(){}[]", true
        "([{}]", false
        "", true
        "[", false
        "}})]", false

    ] |> List.map (fun (input, result) -> TestCaseData(input, result))

[<TestCaseSource(nameof data)>]
let checkBracketSequenceTest input expected  =  
     BracketSequence.checkBracketSequence input |> should equal expected