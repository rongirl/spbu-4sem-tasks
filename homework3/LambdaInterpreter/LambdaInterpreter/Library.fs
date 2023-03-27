module LambdaInterpreter

type Variable = string

type Term =
    | Variable of Variable
    | Application of Term * Term
    | LambdaAbstraction of Variable * Term

let rec freeVariables term =
    match term with
    | Variable x -> Set.singleton(x)
    | Application (term1, term2) -> Set.union (freeVariables term1) (freeVariables term2)
    | LambdaAbstraction (variable, term2) -> freeVariables term2 |> Set.remove variable

let isFree variable term =
    freeVariables term |> Set.contains variable   
    
let getNewVariable set =
    let rec getNextVariable var =
        match Set.contains var set with
        | true -> getNextVariable("*" + var)
        | false -> var 
    getNextVariable "a"

let rec substitute variable body term =
    match body with 
    | Variable var when var = variable -> term
    | Variable var -> body
    | Application (term1, term2) -> Application (substitute variable term1 term, substitute variable term2 term)
    | LambdaAbstraction (var, term1) when var = variable -> body 
    | LambdaAbstraction (var, term1) when isFree var term && isFree variable term1 |> not ->
        LambdaAbstraction (var, substitute variable term1 term)
    | LambdaAbstraction (var, term1) -> 
        let newVariable = Set.union (freeVariables term1) (freeVariables term) |> getNewVariable 
        LambdaAbstraction(newVariable, substitute variable (substitute var term1 (Variable(newVariable))) term)

let rec betaReduce term =
    match term with
    | Variable x -> term 
    | LambdaAbstraction (variable, term1) -> LambdaAbstraction (variable, betaReduce term1)
    | Application (LambdaAbstraction(variable, term1), term2) -> substitute variable term1 term2
    | Application (term1, term2) -> Application (betaReduce term1, betaReduce term2)