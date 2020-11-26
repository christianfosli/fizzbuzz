open System
open System.Linq

// Usage
// dotnet fsi fizzbuzz.fsx -- [max] OR dotnet fsi fizzbuzz.fsx -- [n1 n2 n3 n4]

module FizzBuzz =
    let parse n =
        if n % 15 = 0 then "Fizz Buzz"
        else if n % 3 = 0 then "Fizz"
        else if n % 5 = 0 then "Buzz"
        else string n

    let countTo n = [ 1 .. n ] |> Seq.map parse

let argsThatAreNumbers =
    fsi.CommandLineArgs
    |> Seq.map (fun (n: string) ->
        match Int32.TryParse n with
        | true, out -> Some out
        | _ -> None)
    |> Seq.choose id

match argsThatAreNumbers.Count() with
| 0 -> FizzBuzz.countTo 50
| 1 -> FizzBuzz.countTo (argsThatAreNumbers.First())
| _ -> argsThatAreNumbers |> Seq.map FizzBuzz.parse
|> List.ofSeq // just because List has a more suitable ToString()
|> printfn "%A"
