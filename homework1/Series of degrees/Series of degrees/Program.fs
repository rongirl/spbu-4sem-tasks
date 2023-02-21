printfn "%s" "Enter n and m: "
let input = System.Console.ReadLine().Split(' ')
let n = input[0] |> int
let m = input[1] |> int 
let seriesOfDegrees n m = 
    let rec loop current list =
        if current = m then
            list
        else 
            loop (current + 1) ((list |> List.head |> (*) 2) :: list)
    loop 0 [pown 2 n]
let listOfDegrees =  seriesOfDegrees n m  |> List.rev
printfn $"%A{listOfDegrees}"