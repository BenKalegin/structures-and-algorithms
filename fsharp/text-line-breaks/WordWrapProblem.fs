module WordWrapProblem

let pageWidth = 10
let overflowPenalty = 1000000000
let words = ["I";  "am"; "wondering"; "around"; "why"; "the"; "weather"; "is"; "so"; "found" ]


//  dp[i] = min(dp[j] + weight(i,j)) | j = i+1..n

// function that returns penalty for the line starting at word i and next line starting at j  
let penaltyForTheLine(i : int, j: int) : int =  
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

let dp : int array =  Array.zeroCreate (words.Length + 1)
let mutable breakPositions: int list = [] 
dp.[dp.Length-1] <- 0

let solve =
    for i = dp.Length-2 downto 0 do
        let s = [i+1..dp.Length-1] |> Seq.map(fun (j) -> (j, dp.[j] + penaltyForTheLine(i,j))) |> Seq.minBy snd 
        let (nextBestBreak, nextLeastPenalty) = s 
        dp.[i] <- nextLeastPenalty
        //breakPositions. nextBestBreak




