module EvenNumbers

let numberOfEvenNumbersFold list =
    list |> List.fold(fun acc number -> 
        if number % 2 = 0 then 
            acc + 1 else acc) 0

let numberOfEvenNumbersMap list =
    list |> List.map(fun number -> if number % 2 = 0 then 1 else 0) |> List.sum

let numberOfEvenNumbersFilter list =
    list |> List.filter(fun number -> number % 2 = 0) |> List.length

let r = numberOfEvenNumbersMap [-4 .. 5]