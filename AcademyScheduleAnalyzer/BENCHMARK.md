# Benchmark Results

## Overview

This benchmark compares string concatenation using the `+` operator with
`StringBuilder` when building the academy schedule report.

The benchmark was created using BenchmarkDotNet with MemoryDiagnoser enabled.

## Results

| Method | Iterations | Mean | Allocated |
|---|---:|---:|---:|
| StringConcatenation | 100 | 104.68 us | 580.47 KB |
| StringBuilderConcatenation | 100 | 24.45 us | 2.83 KB |
| StringConcatenation | 1,000 | 847.26 us | 5,804.69 KB |
| StringBuilderConcatenation | 1,000 | 235.44 us | 2.83 KB |
| StringConcatenation | 10,000 | 6,904.75 us | 58,046.88 KB |
| StringBuilderConcatenation | 10,000 | 2,338.14 us | 2.83 KB |
| StringConcatenation | 100,000 | 65,212.64 us | 580,468.75 KB |
| StringBuilderConcatenation | 100,000 | 22,730.80 us | 2.83 KB |

## Observations

In this benchmark, `StringBuilder` had a lower mean execution time than
string concatenation for all tested iteration counts.

The memory allocation was also much lower when using `StringBuilder`.

For example, at 100,000 iterations:

- String concatenation allocated about 580,468.75 KB.
- StringBuilder allocated about 2.83 KB.

The benchmark results are specific to this implementation and environment.
They do not mean that `StringBuilder` is always faster for every string
building scenario.

## Benchmark Information

- Tool: BenchmarkDotNet
- Memory Diagnoser: Enabled
- Iterations tested: 100, 1,000, 10,000, 100,000
- Methods compared:
  - `StringConcatenation`
  - `StringBuilderConcatenation`

## Questions

### Which approach was faster?

`StringBuilderConcatenation` had a lower mean execution time in these tests.

### Which approach allocated less memory?

`StringBuilderConcatenation` allocated significantly less memory in these tests.

### Does this prove StringBuilder is always faster?

No. These results only describe the tested implementation and environment.
Performance can change depending on the amount of text, number of
concatenations, runtime, and other factors.