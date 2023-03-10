module MapForTrees


type Tree<'a> =
    | Node of 'a * Tree<'a> * Tree<'a>
    | Empty

let rec map tree func =
    match tree with 
    | Empty -> Empty
    | Node (value, left, right) -> Node(func value, map left func, map right func) 

