printfn("Enter number: ")
let input = System.Console.ReadLine()
let number = input |> int
let factorial number = 
    let rec subFactorial number acc =
        if number < 0 then
            invalidArg (nameof number) "Number is negative"
        elif number = 0 then 
            acc
        else 
            subFactorial (number - 1) (acc * number)
    subFactorial number 1
printfn $"Result: {factorial number}"