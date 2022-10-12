using BenchmarkDotNet.Attributes;

namespace Test;

[MemoryDiagnoser(false)]
public class Benchmark
{
    [Params(10, 50)] 
    public int Size { get; set; }

    //[Benchmark]
    public void Recursive()
    {
        var result = Fibonacci.FibonacciRecursive(Size);
    }
    
    [Benchmark]
    public void Queue()
    {
        var result = Fibonacci.FibonacciQueue(Size);
    }
    
    [Benchmark]
    public void Stack()
    {
        var result = Fibonacci.FibonacciStack(Size);
    }
    
    [Benchmark]
    public void Matrix()
    {
        var result = Fibonacci.FibonacciMatrix(Size);
    }
}