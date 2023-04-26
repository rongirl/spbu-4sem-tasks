module Workflows

// Rounding workflow
type Rounding(accuracy : int) = 
    member this.Bind(x : float, f) = 
        f (System.Math.Round(x, accuracy))
    member this.Return(x : float) = System.Math.Round(x, accuracy)

// Workflow to calculate over strings
module Option =
    let bind f (x:string) =
        match System.Int32.TryParse x with
        | true, result -> f result
        | _ -> None

type StringCalculate() =
    member this.Bind(x : string, f) = Option.bind f x 
    member this.Return(x) = Some(x)
