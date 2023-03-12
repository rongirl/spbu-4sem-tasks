module ParseTree

type Tree<'a> =
    | Operand of 'a
    | Addition of Tree<'a> * Tree<'a>
    | Multiplication of Tree<'a> * Tree<'a>
    | Division of Tree<'a> * Tree<'a>
    | Subtraction of Tree<'a> * Tree<'a>

let rec calculate tree = 
    match tree with 
    | Operand(number) -> number
    | Addition(left, right) -> calculate left + calculate right
    | Multiplication(left, right) -> calculate left * calculate right
    | Subtraction(left, right) -> calculate left - calculate right 
    | Division(left, right) -> calculate left / calculate right 