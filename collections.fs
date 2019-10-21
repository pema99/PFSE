namespace PFSE

module Collections = 
  module List =     
    let pairwise lst =
      lst
        |> Seq.pairwise
        |> List.ofSeq
    
  module Array =
    let pairwise arr =
      arr
        |> Seq.pairwise
        |> Array.ofSeq
