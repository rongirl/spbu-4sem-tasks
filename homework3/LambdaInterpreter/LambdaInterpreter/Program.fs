module LambdaInterpreter

type Variable = string

type Term =
    | Variable of Variable
    | Application of Term * Term
    | LambdaAbstraction of Variable * Term

let rec freeVariables term =
    match term with
    | Variable x -> Set.singleton(x)
    | Application (S, T) -> Set.union (freeVariables S) (freeVariables T)
    | LambdaAbstraction (variable, T) -> freeVariables T |> Set.remove variable

let isFree variable term =
    freeVariables term |> Set.contains variable