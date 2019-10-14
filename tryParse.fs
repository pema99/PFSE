module TryParse =
  let tryParseWrapper (func: string -> bool * _) param =
    match func param with
    | true, value -> Some value
    | _ -> None
  
  let parseInt = tryParseWrapper System.Int32.TryParse
  let parseLong = tryParseWrapper System.Int64.TryParse
  let parseULong = tryParseWrapper System.UInt64.TryParse
  let parseFloat = tryParseWrapper System.Single.TryParse
  let parseDouble = tryParseWrapper System.Double.TryParse
  let parseBool = tryParseWrapper System.Boolean.TryParse
  let parseChar = tryParseWrapper System.Char.TryParse
  let parseUInt = tryParseWrapper System.UInt32.TryParse
  let parseUShort = tryParseWrapper System.UInt16.TryParse
  let parseSByte = tryParseWrapper System.SByte.TryParse
  let parseByte = tryParseWrapper System.Byte.TryParse