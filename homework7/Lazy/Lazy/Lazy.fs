module Lazy

open ILazy 

type Lazy<'a>(supplier: unit -> 'a) =
    let mutable result = None
    
    interface ILazy<'a> with
        member this.Get () =
            match result with 
            | None -> 
                result <- Some(supplier())
                result.Value
            | Some value -> value 