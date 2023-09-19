```

BenchmarkDotNet v0.13.7, macOS Ventura 13.5 (22G74) [Darwin 22.6.0]
Intel Core i7-9750H CPU 2.60GHz, 1 CPU, 12 logical and 6 physical cores
.NET SDK 7.0.400
  [Host]     : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.10 (7.0.1023.36312), X64 RyuJIT AVX2


```
|              Method |      Mean |    Error |   StdDev |    Median |
|-------------------- |----------:|---------:|---------:|----------:|
|      stringLiterals |  97.42 ns | 2.005 ns | 3.563 ns |  96.63 ns |
| stringInterpolation |  78.23 ns | 1.944 ns | 5.515 ns |  76.71 ns |
| stringStringBuilder | 112.64 ns | 2.319 ns | 3.399 ns | 112.37 ns |
|          stringJoin |  69.04 ns | 1.438 ns | 1.919 ns |  69.73 ns |
|      stringAgregate | 174.40 ns | 3.549 ns | 5.731 ns | 174.01 ns |
