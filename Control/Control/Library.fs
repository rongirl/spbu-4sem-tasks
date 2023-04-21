module Control 
 
let supermap func list =
    let rec innerFun acc list =
        match list with
        | [] -> acc  
        | head::tail -> innerFun (List.append acc (func head)) (tail)
    innerFun [] list

let print n = 
    let rec innerFun result current = 
        if current = 1 || current = n * 2 - 1 then
            innerFun (result + String.replicate (n - 1) " " + "*" + "\n") (current + 1)
        else if current > 1 && current < n then 
            innerFun (result + String.replicate (n - current % n) " " + String.replicate (current % n * 2 - 1) "*" + "\n") (current + 1)
        else if current = n then 
            innerFun (result + String.replicate (current * 2 - 1) "*" + "\n") (current + 1)
        else if current > 1 && current < n * 2 - 1 then 
            innerFun (result + String.replicate (current % n) " " + String.replicate (2 * (current - current % n * 2) - 1) "*" + "\n") (current + 1)
        else 
            result
    if n < 1 then 
        ""
    else 
        innerFun "" 1


type ConcurrentStack<'T>() =    
    let mutable stack : List<'T> = []

    member this.Push value =
      lock stack (fun () -> 
         stack <- value :: stack)

    member this.TryPop() =
      lock stack (fun () ->
         match stack with
         | result :: newStack ->
            stack <- newStack
            Some(result)
         | [] -> None
      )