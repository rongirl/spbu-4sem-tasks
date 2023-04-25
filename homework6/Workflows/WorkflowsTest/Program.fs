module WorkflowsTest

open NUnit.Framework
open Workflows
open FsUnit 


[<Test>]
let TestRounding() =
    let rounding = Rounding
    rounding 3 {
    let! a = 2.0 / 12.0
    let! b = 3.5
    return a / b
    } |> should equal 0.048
    
[<Test>]
let TestRoundingNegativeNumbers() =
    let rounding = Rounding
    rounding 4 {
    let! a = -9.0 / -12.5
    let! b = -3.5
    return a / b
    } |> should equal -0.2057

[<Test>]
let TestCalculate() =
    let calculate = StringCalculate()
    let res = calculate {
        let! x = "1"
        let! y = "2"
        let z = x + y
        return z
    }
    res |> should equal (Some(3))
 
[<Test>]
let TestCalculateNone() =
    let calculate = StringCalculate()
    let res = calculate {
        let! x = "заходит как-то сын в бар а там сидят мама, сосед, и директор школы"
        let! y = "директор говорит а гвозди а сосед отвечает: вот у него в рюкзаке"
        let z = x - y
        return z
    }
    res |> should equal None

