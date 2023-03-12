module PrimeNumbers

let generatorPrimeNumbers() = 
    let isPrime number = 
        let max = float number |> sqrt |> int 
        seq{2 .. max} |> Seq.forall(fun i -> number % i <> 0) 
    Seq.initInfinite(fun elem -> elem + 2) |> Seq.filter isPrime