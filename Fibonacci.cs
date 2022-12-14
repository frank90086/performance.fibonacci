using System.Numerics;

namespace Test;

public static class Fibonacci
{
    public static long FibonacciRecursive(int n)
    {
        return n switch
               {
                   < 0 => throw new ArgumentOutOfRangeException($"{nameof(n)} must larger than 0"),
                   1 or 2 => 1,
                   _ => FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2)
               };
    }
    
    public static long FibonacciTailRecursive(int n, long sum, long accumulator)
    {
        return n switch
               {
                   < 0 => throw new ArgumentOutOfRangeException($"{nameof(n)} must larger than 0"),
                   0 => sum,
                   _ => FibonacciTailRecursive(n - 1, accumulator, sum + accumulator)
               };
    }
    
    public static long FibonacciQueue(int n)
    {
        switch (n)
        {
            case < 0:
                throw new ArgumentOutOfRangeException($"{nameof(n)} must larger than 0");
            case 1 or 2:
                return 1;
        }

        var queue = new Queue<long>(2);
        queue.Enqueue(1);
        queue.Enqueue(1);
        
        for (var i = 3; i <= n; i++)
        {
            var front = queue.Dequeue();
            var end = queue.Dequeue();
            var sum = front + end;
            
            queue.Enqueue(sum);
            queue.Enqueue(front);
        }
        return queue.Peek();
    }
    
    public static long FibonacciStack(int n)
    {
        switch (n)
        {
            case < 0:
                throw new ArgumentOutOfRangeException($"{nameof(n)} must larger than 0");
            case 1 or 2:
                return 1;
        }

        var stack = new Stack<long>(2);
        stack.Push(1);
        stack.Push(1);
        
        for (var i = 3; i <= n; i++)
        {
            var top = stack.Pop();
            var bottom = stack.Pop();
            var sum = top + bottom;
            stack.Push(top);
            stack.Push(sum);
        }
        return stack.Peek();
    }

    public static long FibonacciMatrix(int n)
    {
        var a = new long[2, 2] { { 1, 1 }, { 1, 0 } };
        var b = MatrixClub(a, n);
        return b[1, 0];
    }
    
    public static long[,] MatrixClub(long[,] a, int n)
    {
        switch (n)
        {
            case 1:
                return a;
            case 2:
                return MultiplyMatrix(a, a);
            default:
            {
                if (n % 2 == 0)
                {
                    var temp = MatrixClub(a, n / 2);
                    return MultiplyMatrix(temp, temp);
                }
                else
                {
                    var temp = MatrixClub(a, n / 2);
                    return MultiplyMatrix(MultiplyMatrix(temp, temp), a);
                }
            }
        }
    }

    public static long[,] MultiplyMatrix(long[,] a, long[,] b)
    {
        var aRowLength = a.GetLength(0);
        var aColumnLength = a.GetLength(1);
        var bRowLength = b.GetLength(0);
        var bColumnLength = b.GetLength(1);

        if (aColumnLength != bRowLength)
            throw new ArgumentException("Must follow the vector product rule");

        var c = new long[aRowLength, bColumnLength];
        for (var i = 0; i < aRowLength; i++)
        {
            for (var j = 0; j < bColumnLength; j++)
            {
                for (var k = 0; k < aColumnLength; k++)
                {
                    c[i, j] += a[i, k] * b[k, j];
                }
            }
        }
        return c;
    }
}