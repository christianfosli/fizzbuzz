open System

module FizzBuzz =
    let parse n =
        match (n % 3 = 0, n % 5 = 0) with
        | (true, false) -> "Fizz"
        | (false, true) -> "Buzz"
        | (true, true) -> "Fizz Buzz"
        | _ -> string n

    let countTo n = [ 1 .. n ] |> Seq.map parse

let argsThatAreNumbers =
    fsi.CommandLineArgs
    |> Seq.map (fun (n: string) ->
        match Int32.TryParse n with
        | true, out -> Some out
        | _ -> None)
    |> Seq.choose id

match Seq.length argsThatAreNumbers with
| 0 -> FizzBuzz.countTo 50
| 1 -> Seq.head argsThatAreNumbers |> FizzBuzz.countTo
| _ -> argsThatAreNumbers |> Seq.map FizzBuzz.parse
|> List.ofSeq // just because List has a more suitable ToString()
|> printfn "%A"
