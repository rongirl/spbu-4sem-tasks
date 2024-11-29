module PointFree

let func x l = List.map (fun y -> y * x) l

let func'1 x = List.map (fun y -> y * x)

let func'2 x = List.map (fun y -> ((*) x) y)

let func'3 x =  List.map ((*) x)

let func'4 x = x |> (*) |> List.map

let func'5 = (*) >> List.map