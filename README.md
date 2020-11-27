## Functional FizzBuzz

Demonstrates some simple pattern matching and scripting with fsharp

### Usage - Count to 50

```console
dotnet fsi fizzbuzz.fsx -- 50
```

### Usage - From 10 to 12

```console
dotnet fsi fizzbuzz.fsx -- 10 11 12
```

### If you don't have dotnet sdk installed or you prefer Docker

```console
docker run --rm -v "$(pwd)/fizzbuzz.fsx:/app/fizzbuzz.fsx" \
    mcr.microsoft.com/dotnet/sdk:5.0 dotnet fsi /app/fizzbuzz.fsx
```
