module Control 
 
let supermap func list =
    let rec innerFun acc list =
        match list with
        | [] -> acc  
        | head::tail -> innerFun (List.append acc (func head)) (tail)
    innerFun [] list

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