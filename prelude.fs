namespace PFSE 

[<AutoOpen>]
module Prelude =
  let inline curry f a b = f (a, b)
  let inline uncurry f (a, b) = f a b
  let inline swap (a, b) = b, a
  let inline konst a _ = a