using BenchmarkDotNet.Attributes;

namespace Test;

[MemoryDiagnoser(false)]
public class Benchmark
{
    // [Params(10, 50)]
    public int Size { get; set; }

    public IEnumerable<object[]> Data()
    {
        yield return new object[]
                     {
                         new long[,] { { 1, 1 }, { 1, 0 } }, 
                         new long[,] { { 1, 1 }, { 1, 0 } }
                     };
        yield return new object[]
                     {
                         new long[,] { { 1, 0, 1 }, { 1, 0, 1 }, { 1, 0, 1 } },
                         new long[,] { { 1, 0, 1 }, { 1, 0, 1 }, { 1, 0, 1 } }
                     };
        yield return new object[]
                     {
                         new long[,] { { 1, 1, 1, 1 }, { 1, 0, 1, 0 }, { 1, 1, 1, 1 }, { 1, 0, 1, 0 } },
                         new long[,] { { 1, 1, 1, 1 }, { 1, 0, 1, 0 }, { 1, 1, 1, 1 }, { 1, 0, 1, 0 } }
                     };
        yield return new object[]
                     {
                         new long[,] { { 1, 1, 1, 1 }, { 1, 0, 1, 0 } },
                         new long[,] { { 1, 1 }, { 1, 0 }, { 1, 1 }, { 1, 0 } }
                     };
    }

    //[Benchmark]
    public void Recursive()
    {
        var result = Fibonacci.FibonacciRecursive(Size);
    }
    
    //[Benchmark]
    public void Queue()
    {
        var result = Fibonacci.FibonacciQueue(Size);
    }
    
    //[Benchmark]
    public void Stack()
    {
        var result = Fibonacci.FibonacciStack(Size);
    }
    
    //[Benchmark]
    public void Matrix()
    {
        var result = Fibonacci.FibonacciMatrix(Size);
    }

    [Benchmark]
    [ArgumentsSource(nameof(Data))]
    public void MultiplyMatrix(long[,] aMatrix, long[,] bMatrix)
    {
        var result = Fibonacci.MultiplyMatrix(aMatrix, bMatrix);
    }
}