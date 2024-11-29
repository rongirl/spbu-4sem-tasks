module PointFreeTest

open FsCheck
open NUnit.Framework

[<Test>]
let funcAndfun'1Test() =
    let check x list = PointFree.func x list = PointFree.func'1 x list
    Check.Quick check

[<Test>]
let func'1Andfun'2Test() =
    let check x list = PointFree.func'1 x list = PointFree.func'2 x list
    Check.Quick check

[<Test>]
let func'2Andfun'3Test() =
    let check x list = PointFree.func'2 x list = PointFree.func'3 x list
    Check.Quick check

[<Test>]
let func'3Andfun'4Test() =
    let check x list = PointFree.func'3 x list = PointFree.func'4 x list
    Check.Quick check
 
[<Test>]
let func'4Andfun'5Test() =
    let check x list = PointFree.func'4 x list = PointFree.func'5 x list
    Check.Quick check