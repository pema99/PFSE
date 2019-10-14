namespace PFSE

module Collections = 
  module List =     
    let select (pred: 'T -> bool) (lst: 'T list) =
      lst |> List.tryPick (fun x -> if pred x then Some(x) else None)

  module Array =
    let select (pred: 'T -> bool) (arr: 'T []) =
      arr |> Array.tryPick (fun x -> if pred x then Some(x) else None)

  module Seq =
    let select (pred: 'T -> bool) (seq: 'T []) =
      seq |> Seq.tryPick (fun x -> if pred x then Some(x) else None)