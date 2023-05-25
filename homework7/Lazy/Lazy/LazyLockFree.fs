﻿module Lazy.LazyLockFree

open System.Threading
open LazyInterface

type LazyLockFree<'a>(supplier: unit -> 'a) =
    let mutable result = None
    
    interface ILazy<'a> with
        member this.Get () =
            if result.IsNone then 
                let calculated = Some(supplier ())
                Interlocked.CompareExchange(&result, calculated, None) |> ignore
            result.Value