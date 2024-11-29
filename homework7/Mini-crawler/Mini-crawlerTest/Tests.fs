module MiniCrawlerTest

open NUnit.Framework
open FsUnit
open MiniCrawler

[<Test>]
let findSizeTest () =
    let pages = findSize "https://ant.lanit-tercom.com/"
    Seq.length pages |> should equal 11
    let list =
        seq {
            ("https://ant.lanit-tercom.com/category/news/", Some(33516))
            ("https://ant.lanit-tercom.com/category/theses/", Some(133591))
            ("https://ant.lanit-tercom.com/category/lectures/", Some(33388))
            ("https://ant.lanit-tercom.com/public/", Some(22552))
            ("https://ant.lanit-tercom.com/category/stories/", Some(275736))
            ("https://ant.lanit-tercom.com/category/%d0%b2%d0%ba%d1%80/", Some(27906))
            ("https://ant.lanit-tercom.com/category/%d0%ba%d0%b0%d0%bd%d0%b4%d0%b8%d0%b4%d0%b0%d1%82%d1%81%d0%ba%d0%b0%d1%8f-%d0%b4%d0%b8%d1%81%d1%81%d0%b5%d1%80%d1%82%d0%b0%d1%86%d0%b8%d1%8f/", Some(17647))
            ("https://ant.lanit-tercom.com/category/%d0%b4%d0%be%d0%ba%d1%82%d0%be%d1%80%d1%81%d0%ba%d0%b0%d1%8f-%d0%b4%d0%b8%d1%81%d1%81%d0%b5%d1%80%d1%82%d0%b0%d1%86%d0%b8%d1%8f/", Some(17638))
            ("https://ant.lanit-tercom.com/category/%d0%b0%d1%81%d0%bf%d0%b8%d1%80%d0%b0%d0%bd%d1%82%d1%8b-%d0%b0-%d0%bd-%d1%82%d0%b5%d1%80%d0%b5%d1%85%d0%be%d0%b2%d0%b0/", Some(22439))
            ("https://russoft.org", None)
            ("https://ant.lanit-tercom.com/", Some(28691))
        }
    pages |> should equal list 


[<Test>]
let findSizeTestWithoutPages () =
    let pagesResult = findSize "https://russoft.org"
    Seq.length pagesResult |> should equal 0
    pagesResult |> should equal Seq.empty
