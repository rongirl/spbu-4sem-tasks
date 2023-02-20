System.Console.WriteLine("Enter number")
let input = System.Console.ReadLine()
let number = input |> int
let fibonacci number =
    if number = 0 then
        0
    elif  number = 1 then
        1
    else    
        let rec subFibonacci i previous current = 
            if i = number then
                previous
            else    
                subFibonacci (i + 1) current (previous + current)
        subFibonacci 1 0 1
printfn $"%d{fibonacci number}"