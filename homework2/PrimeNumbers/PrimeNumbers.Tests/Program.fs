module PrimeNumbers.Tests 

open PrimeNumbers 
open FsUnit 
open NUnit.Framework

let data () = 
    [   
        seq{2}, 1
        seq{2; 3; 5}, 3
        seq{2; 3; 5; 7; 11}, 5
        seq{2; 3; 5; 7; 11; 13; 17; 19}, 8 
        seq{2; 3; 5; 7; 11; 13; 17; 19; 23; 29; 31; 37; 41}, 13
    ] |> List.map (fun (result, count) -> TestCaseData(result, count))

[<TestCaseSource(nameof data)>]
let generatePrimeNumbersTests expected count =  
     PrimeNumbers.generatorPrimeNumbers() |> Seq.take count |> should equal expected