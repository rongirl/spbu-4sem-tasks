module BracketSequence

let checkBracketSequence input =
    let rec check list stack =
        match list with
        | [] -> List.isEmpty stack
        | head::tail -> 
            match head with 
            | '(' | '{' | '[' -> check (tail) (head::stack)
            | ')' -> if List.isEmpty stack || List.head stack <> '(' then false else check (tail) (List.tail stack)
            | ']' -> if List.isEmpty stack || List.head stack <> '[' then false else check (tail) (List.tail stack)
            | '}' -> if List.isEmpty stack || List.head stack <> '{' then false else check (tail) (List.tail stack)
            | _ -> false
    check (Seq.toList input) []