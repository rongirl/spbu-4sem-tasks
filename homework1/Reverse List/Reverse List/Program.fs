printfn "%s" "Enter size of list: "
let size = System.Console.ReadLine() |> int
printfn "%s" "Enter elements: "
let input = System.Console.ReadLine().Split(" ")
let list = List.init size (fun i -> input[i] |> int)

let reverse list =
    let rec loop list newList = 
         match list with 
        | [] -> newList
        | head :: tail -> loop tail (head :: newList)
    loop list []
printfn "The reversed list: %A" (reverse list)