namespace PFSE

[<AutoOpen>]
module ResultTypeExtensions =
  type Result<'T, 'TError> with
    member this.IsOk =
      match this with
      | Ok _ -> true
      | Error _ -> false
    
    member this.IsError =
      match this with
      | Ok _ -> false
      | Error _ -> true

    member this.ResultValue = 
      match this with
      | Ok x -> x
      | Error _ -> raise (new System.InvalidOperationException("Result.ResultValue"))
    
    member this.ErrorValue =
      match this with
      | Ok _ -> raise (new System.InvalidOperationException("Result.ErrorValue"))
      | Error x -> x

[<AutoOpen>]
[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module Result = 

    [<CompiledName("TryGetOk")>]
    let tryGetOk result = 
      match result with 
      | Ok x -> Some x
      | Error _ -> None

    [<CompiledName("TryGetError")>]    
    let tryGetError result = 
      match result with 
      | Ok _ -> None
      | Error x -> Some x

    [<CompiledName("GetOk")>]
    let getOk result = 
      match result with 
      | Ok x -> x
      | Error _ -> invalidArg "result" "Attempted to get the Ok union case on a Result which was Error." 

    [<CompiledName("GetError")>]
    let getError result = 
      match result with 
      | Ok _ -> invalidArg "result" "Attempted to get the Error union case on a Result which was Ok." 
      | Error x -> x

    [<CompiledName("IsOk")>]
    let inline isOk result = 
      match result with 
      | Ok _ -> true 
      | Error _ -> false

    [<CompiledName("IsError")>]
    let inline isError result = 
      match result with 
      | Ok _ -> false 
      | Error _ -> true

    [<CompiledName("DefaultValue")>]
    let defaultValue value result = 
      match result with 
      | Ok x -> x
      | Error _ -> value 

    [<CompiledName("DefaultWith")>]
    let defaultWith defThunk result = 
      match result with 
      | Ok x -> x
      | Error _ -> defThunk () 

    [<CompiledName("OrElse")>]
    let orElse ifError result = 
      match result with 
      | Ok _ -> result
      | Error _ -> ifError 

    [<CompiledName("OrElseWith")>]
    let orElseWith ifErrorThunk result = 
      match result with 
      | Ok _ -> result
      | Error _ -> ifErrorThunk () 

    [<CompiledName("Count")>]
    let count result = 
      match result with 
      | Ok _ -> 1
      | Error _ -> 0 

    [<CompiledName("Fold")>]
    let fold<'T, 'TError,'State> folder (state:'State) (result: Result<'T, 'TError>) = 
      match result with 
      | Ok x -> folder state x
      | Error _ -> state 

    [<CompiledName("FoldBack")>]
    let foldBack<'T, 'TError, 'State> folder (result: Result<'T, 'TError>) (state:'State) =  
      match result with 
      | Ok x -> folder x state
      | Error _ -> state 

    [<CompiledName("Exists")>]
    let exists predicate result = 
      match result with 
      | Ok x -> predicate x
      | Error _ -> false 

    [<CompiledName("ForAll")>]
    let forall predicate result = 
      match result with 
      | Ok x -> predicate x
      | Error _ -> true 

    [<CompiledName("Contains")>]
    let inline contains value result = 
      match result with 
      | Ok v -> v = value
      | Error _ -> false 

    [<CompiledName("Iterate")>]
    let iter action result = 
      match result with
      | Ok x -> action x
      | Error _ -> () 

    [<CompiledName("ToArray")>]
    let toArray result = 
      match result with 
        | Ok x -> [| x |]
        | Error _ -> [| |] 

    [<CompiledName("ToList")>]
    let toList result = 
      match result with 
        | Ok x -> [ x ]
        | Error _ -> [ ] 
