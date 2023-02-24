let searchNumber number list = 
    let rec search list index =
        match list with 
        | [] -> None
        | head :: tail when head = number -> Some(index)
        | head :: tail -> search (tail) (index + 1)
    search list 0

printfn "Enter length of list: "
let length = System.Console.ReadLine() |> int
printfn "Enter elements of list: "
let input = System.Console.ReadLine().Split(' ')
let list = List.init length (fun i -> input[i] |> int)
printfn "Enter number "
let number = System.Console.ReadLine() |> int

let position = searchNumber number list 
match position with 
    | None -> printfn "The element is not in the list"
    | Some(result) -> printfn "Position of %d in list %d" number result
    