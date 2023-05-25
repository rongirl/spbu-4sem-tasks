module MiniCrawlerTest

open NUnit.Framework
open FsUnit
open MiniCrawler



[<Test>]
let findSizeTest () =
    let pages = findSize "https://acmp.ru/" 
    Seq.length pages |> should equal 9
    let list =
        seq {
            ("https://www.youtube.com/@user-pn4qp7rl8h/playlists", Some(358270))
            ("https://vk.com/video-210818063_456239045", Some(148289))
            ("https://vk.com/video-210818063_456239045", Some(148289))
            ("https://docs.google.com/spreadsheets/d/1AUmp8plzvMXvqQf2tGpfkaByiDuvG9KSc9j7G7IeaXE/edit?usp=sharing", Some(370498))
            ("https://www.youtube.com/playlist?list=PLxVrp7RZ0ASiWwJLZNQt-EoNSrDcG269D", Some(361344))
            ("https://www.youtube.com/playlist?list=PLxVrp7RZ0ASicF-9hZ9GqQ6yQmFMtGLS5", Some(701072))
            ("https://youtu.be/ZkriIrw7Jfg", Some(688530))
            ("https://youtu.be/et8tLU6Z81Q", Some(693580))
            ("https://youtu.be/80rvOPYqhUE", Some(693718))
        }
    pages |> should equal list 

    