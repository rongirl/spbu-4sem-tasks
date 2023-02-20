printfn("Enter number: ")
let input = System.Console.ReadLine()
let number = input |> int
let rec factorial number acc =
    if number = 0 then 
        acc
    else 
        factorial (number - 1) (acc * number)
printfn $"Result: {factorial number 1}"