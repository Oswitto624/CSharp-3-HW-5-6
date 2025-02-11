﻿using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MatrixMultipler
{
    enum MatrixFill
    {
        Random, Value, None
    }

    class Matrix
    {
        int[,] a;
        static Random rand = new Random();
        public string Name { get; }
        public int N { get { return a.GetLength(0); } }
        public int M { get { return a.GetLength(1); } }
        public int[,] A { get { return a; } }
        public int this[int i, int j]
        {
            get
            {
                return a[i, j];
            }
            set
            {
                a[i, j] = value;
            }
        }

        public Matrix(int n = 5, int m = 5, MatrixFill fill = MatrixFill.None, string name = "", int value = 0, int minRandom = 0, int maxRandom = 10)
        {
            a = new int[n, m];
            this.Name = name;
            if (fill == MatrixFill.None) return;
            if (fill == MatrixFill.Random)
            {
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < M; j++) a[i, j] = rand.Next(minRandom, maxRandom + 1);
                }
            }
            else
            {
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < M; j++) a[i, j] = value;
                }
            }
        }

        public Matrix Multiply(Matrix other)    //без использования TPL
        {
            Matrix result = new Matrix(this.N, other.M, MatrixFill.None, name: "Result");
            for (int row = 0; row < this.N; row++)
                for (int col = 0; col < other.M; col++)
                {
                    for (int inner = 0; inner < other.N; inner++) result[row, col] += this[row, inner] * other[inner, col];
                }
            return result;
        }

        public async Task<Matrix> MultiplyAsync(Matrix other)
        {
            return await Task<Matrix>.Factory.StartNew(() => Multiply(other));
        }

        public Matrix MultiplyOverThread(Matrix other)
        {
            Matrix result = new Matrix(this.N, other.M, MatrixFill.None, name: "Result");
            for (int row = 0; row < this.N; row++)
            {
                Parallel.For(0, other.M, (col) =>
                {
                    for (int inner = 0; inner < other.N; inner++) result[row, col] += this[row, inner] * other[inner, col];
                });
            }
            return result;
        }

        public Matrix MultiplyOverThread2(Matrix other)
        {
            Matrix result = new Matrix(this.N, other.M, MatrixFill.None, name: "Result");
            Parallel.For(0, this.N, (row) =>
            {
                Parallel.For(0, other.M,
                (col) =>
                {
                    for (int inner = 0; inner < other.N; inner++) result[row, col] += this[row, inner] * other[inner, col];
                });
            });
            return result;
        }

        public void Print()
        {
            Console.WriteLine(this.Name);
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++) Console.Write("{0,10}", a[i, j]);
                Console.WriteLine();
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            int N = 500;
            int M = 500;
            int Count = 1;

            Matrix A=new Matrix(name:"Matrix A",fill:MatrixFill.Value,value:2,n:N,m:M),
                   B=new Matrix(name:"Matrix B",fill:MatrixFill.Random,n:N,m:M);
          
            Console.WriteLine("Start simple multiply");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Matrix C;
            for (int i = 0; i < Count; i++) C= A.Multiply(B); 
            stopwatch.Stop();            
            Console.WriteLine("Without Parallel thread:{0}",stopwatch.ElapsedMilliseconds);

            Console.WriteLine("Start simple multiply async");
            stopwatch = new Stopwatch();
            stopwatch.Start();            
            for (int i = 0; i < Count; i++)
            {
                Task<Matrix> task = A.MultiplyAsync(B);
                Console.WriteLine(task.Result); 
            }
            stopwatch.Stop();
            Console.WriteLine("Async result:{0}", stopwatch.ElapsedMilliseconds);

            stopwatch = new Stopwatch();
            stopwatch.Reset();
            Console.WriteLine("Start multiply with Parallel");
            stopwatch.Start();
            for (int i = 0; i < Count; i++) C = A.MultiplyOverThread(B);
            stopwatch.Stop();
            Console.WriteLine("With Parallel thread:{0}", stopwatch.ElapsedMilliseconds);
            
            stopwatch.Reset();
            Console.WriteLine("Start multiply with Parallel 2");
            stopwatch.Start();
            for (int i = 0; i < Count; i++) C = A.MultiplyOverThread2(B);
            stopwatch.Stop();
            Console.WriteLine("With Parallel thread version 2:{0}", stopwatch.ElapsedMilliseconds);
            Console.WriteLine("Press any key");
            Console.ReadLine();
        }
    }
}
