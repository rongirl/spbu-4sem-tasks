module Lazy.LazyTest 

open NUnit.Framework
open FsUnit
open System.Threading
open LazyInterface

[<Test>]
let lazyLockFreeTest () =
    let mutable x = 1
    let lazyLockFree: ILazy<unit> = Lazy.LazyLockFree.LazyLockFree<unit>(fun () -> x <- Interlocked.Increment(ref x))
    let task = async { return lazyLockFree.Get() }
    let tasks = Seq.init 100 (fun _ -> task)
    tasks
    |> Async.Parallel
    |> Async.RunSynchronously
    |> ignore
    x |> should equal 2

[<Test>]
let lazyWithLockTest () =
    let mutable x = 1
    let lazyWithLock: ILazy<unit> = Lazy.LazyWithLock.LazyWithLock<unit>(fun () -> x <- Interlocked.Increment(ref x))
    let task = async { return lazyWithLock.Get() }
    let tasks = Seq.init 100 (fun _ -> task)
    tasks
    |> Async.Parallel
    |> Async.RunSynchronously
    |> ignore
    x |> should equal 2

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
    myLazy.Get() |> should equal 1 