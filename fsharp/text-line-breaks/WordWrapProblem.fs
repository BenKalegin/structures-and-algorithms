module WordWrapProblem

let pageWidth = 20
let overflowPenalty = 1000000000
let text = "In a statement released shortly after Greitens announced his resignation, St. Louis Circuit Attorney Kimberly Gardner said, a fair and just resolution of pending charges against the governor has been reached and that additional information regarding the resolution would be released on Wednesday."
//let words = ["I";  "am"; "wondering"; "around"; "why"; "the"; "weather"; "is"; "so"; "found" ]



//  dp[i] = min(dp[j] + weight(i,j)) | j = i+1..n

// function that returns penalty for the line starting at word i and next line starting at j  
let penaltyForTheLine(words: string[], i, j) : int =  
    let wordLengths = 
        words 
            |> Seq.skip i 
            |> Seq.take (j-i) 
            |> Seq.map (fun s -> s.Length)
            |> Seq.sum
    
    let legitSpaces = j-i-1 
    
    let extraSpaces = pageWidth - wordLengths - legitSpaces
    match extraSpaces with 
    | var1 when var1 < 0 -> overflowPenalty
    | var2 -> pown var2 3


let solve =
    let words = text.Split[|' '|]
    let dp : int array =  Array.zeroCreate (words.Length + 1)
    let pos : int array =  Array.zeroCreate (words.Length + 1)
    let mutable breakPositions: int list = [] 
    dp.[dp.Length-1] <- 0
    for i = dp.Length-2 downto 0 do
        let s = [i+1..dp.Length-1] |> Seq.map(fun (j) -> (j, dp.[j] + penaltyForTheLine(words, i ,j))) |> Seq.minBy snd 
        let (nextBestBreak, nextLeastPenalty) = s 
        dp.[i] <- nextLeastPenalty
        pos.[i] <- nextBestBreak
        //breakPositions. nextBestBreak
    let breaks = pos |> Seq.distinct |>  Seq.map (fun i -> i-1) |> Seq.toList
    
    for i in  0 .. words.Length-1 do
        if (List.exists ((=) i) breaks) then 
            printfn "%s" words.[i]  
        else 
            printf "%s " words.[i]



