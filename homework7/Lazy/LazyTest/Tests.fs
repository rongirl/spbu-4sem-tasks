module Lazy.LazyTest 

open NUnit.Framework
open FsUnit
open System.Threading
open LazyInterface

[<Test>]
let lazyLockFreeTest () =
    let mutable x = 0
    let lazyLockFree: ILazy<int> = Lazy.LazyLockFree.LazyLockFree<int>(fun () -> Interlocked.Increment(ref x))
    let tasks = Seq.init 100 (fun _ ->
        async { return lazyLockFree.Get() |> should equal 1})
    tasks
    |> Async.Parallel
    |> Async.RunSynchronously |> ignore

[<Test>]
let lazyWithLockTest () =
    let x = ref 1
    let lazyWithLock: ILazy<int> = Lazy.LazyWithLock.LazyWithLock<int>(fun () -> Interlocked.Increment(x))
    let task = async { return lazyWithLock.Get() |> should equal 2}
    let tasks = Seq.init 100 (fun _ -> task)
    tasks
    |> Async.Parallel
    |> Async.RunSynchronously
    |> ignore
    x.Value |> should equal 2

[<Test>]
let lockFreeAndWithLockInSingleThread () =
    let x = 0
    let lazyLockFree: ILazy<int> = Lazy.LazyLockFree.LazyLockFree<int>(fun () -> x + 1)
    let lazyWithLock: ILazy<int> = Lazy.LazyWithLock.LazyWithLock<int>(fun () -> x + 1)
    lazyLockFree.Get() |> should equal 1
    lazyWithLock.Get() |> should equal 1

[<Test>]
let lazyInSingleThread () =
    let x = 0
    let myLazy: ILazy<int> = Lazy.Lazy.Lazy<int>(fun () -> x + 1)
    let firstRes = myLazy.Get() 
    let secondRes = myLazy.Get()
    firstRes |> should equal secondRes