module MiniCrawler

open System.Net.Http
open System.Text.RegularExpressions
open System.IO
open System.Net
open System.Text.RegularExpressions


let downloadPage (url: string) =
    let httpClient = new HttpClient()
    async {
        try
            use client = httpClient
            let! string = Async.AwaitTask (client.GetStringAsync(url))
            return Some string
            with
            | _ -> return None 
    }

let findAddresses page = 
    let regex = Regex("<a href=\"(https://[^\"]+)\">", RegexOptions.Compiled)
    [for m in regex.Matches page -> m.Groups.[1].Value]

let findSize url =
    match (downloadPage url |> Async.RunSynchronously) with 
    | Some page ->
        let addresses = findAddresses page 
        let length = List.map (fun x -> downloadPage x) addresses
        length 
        |> Async.Parallel
        |> Async.RunSynchronously 
        |> Seq.zip addresses
        |> Seq.map (fun (url, x) ->
        match x with
            | Some value -> (url, Some value.Length)
            | None -> (url, None))
    | _ -> Seq.empty

let printSizes url =
    let pages = findSize url
    Seq.iter
        (fun (url, result) ->
            match result with
            | Some value -> printfn $"%s{url} — %i{value}"
            | None -> printfn $":(")
        pages

