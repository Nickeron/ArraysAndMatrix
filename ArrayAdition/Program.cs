using System;

namespace ArraysAndMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Give me 2 numbers. The size of 2 arrays.\nSize of arrays: ");
            int sizeOfArray = ReadInput<int>();
            int[] array1 = new int[sizeOfArray];
            int[] array2 = new int[sizeOfArray];

            Console.WriteLine("\nNow give me their elements.\nElements of Array 1");
            ReadElementsOfArray(sizeOfArray, ref array1);

            Console.WriteLine("\nNow elements of Array 2");
            ReadElementsOfArray(sizeOfArray, ref array2);

            Console.Write("\nThis is the result of adding the arrays into one:\nSumArray ");
            int[] sumArray = AddTwoArrays(sizeOfArray, array1, array2);
            PrintElementsOfArray(sizeOfArray, sumArray);

            double[,] matrix;
            int sizeOfMatrix;
            if (sizeOfArray == 2)
            {
                Console.WriteLine("\nThat could also be a " + sizeOfArray + 'X' + sizeOfArray + " matrix.\nLike so");
                matrix = CreateAMatrixFrom2Arrays(sizeOfArray, array1, array2);
                sizeOfMatrix = 2;
            }
            else
            {
                Console.Write("\n\nWell you know what? We have to create a matrix.\nSo give me it's size\nSize of Matrix: ");
                sizeOfMatrix = ReadInput<int>();
                matrix = new double[sizeOfMatrix, sizeOfMatrix];
                Console.WriteLine("\nNow give me its elements.");
                ReadElementsOfMatrix(sizeOfMatrix, ref matrix);
                Console.WriteLine("\nNow we have a " + sizeOfMatrix + 'X' + sizeOfMatrix + " matrix.\nLike so");
            }
            
            PrintElementsOfMatrix(sizeOfMatrix, matrix);

            Console.Write("\nAnd this is the sum of left and right diagonals of the matrix:\nSumMatrix ");
            Tuple<double, double> Diagonals = SumDiagonalsOfMatrix(sizeOfMatrix, matrix);
            Console.WriteLine("LeftSum (\\): " + Diagonals.Item1 + " RightSum (/): " + Diagonals.Item2);

            Console.ReadKey();
        }

        public static T ReadInput<T>()
        {
            var method = typeof(T).GetMethod("Parse", new[] { typeof(string) });

            while (true)
            {
                try
                {
                    var value = (T)method.Invoke(null, new[] { Console.ReadLine() });
                    return value;
                }
                catch (Exception)
                {
                    Console.WriteLine("You need to type it correctly");
                }
            }
        }

        public static void ReadElementsOfArray(int sizeOfArray, ref int[] array)
        {
            for (int element = 0; element < sizeOfArray; element++)
            {
                Console.Write($"Element [{element+1}]: ");
                array[element] = ReadInput<int>();
            }
        }

        public static void ReadElementsOfMatrix(int sizeOfMatrix, ref double[,] matrix)
        {
            for (int line = 0; line < sizeOfMatrix; line++)
            {
                for (int column = 0; column < sizeOfMatrix; column++)
                {
                    Console.Write($"Element [{line + 1},{column + 1}]: ");
                    matrix[line, column] = ReadInput<double>();
                }
            }
        }

        public static double[,] CreateAMatrixFrom2Arrays(int sizeOfArray, int[] array1, int[] array2)
        {
            double[,] matrix = new double[sizeOfArray, sizeOfArray];
            for (int element = 0; element < sizeOfArray; element++)
            {
                    matrix[0, element] = array1[element];
                    matrix[1, element] = array2[element];
            }
            return matrix;                
        }

        public static void PrintElementsOfMatrix(int sizeOfMatrix, double[,] matrix)
        {
            for (int line = 0; line < sizeOfMatrix; line++)
            {
                Console.Write("[");
                for (int column = 0; column < sizeOfMatrix - 1; column++)
                {
                    Console.Write(matrix[line, column].ToString() + ", ");
                }
                Console.Write(matrix[line, sizeOfMatrix - 1].ToString() + "]\n");
            }
        }

        public static void PrintElementsOfArray(int sizeOfArray, int[] array)
        {
            Console.Write('[');
            for (int element = 0; element < sizeOfArray-1; element++)
            {
                Console.Write(array[element].ToString() + ", ");
            }
            Console.Write(array[sizeOfArray-1].ToString() + ']');
        }

        public static int[] AddTwoArrays(int sizeOfArray, int[] array1, int[] array2)
        {
            int[] sumArray = new int[sizeOfArray];

            for (int element = 0; element < sizeOfArray; element++)
            {
                sumArray[element] = array1[element] + array2[element];
            }
            return sumArray;
        }

        public static Tuple<double, double> SumDiagonalsOfMatrix(int sizeOfMatrix, double[,] matrix)
        {
            double leftDiagonal = 0, rightDiagonal = 0;

            for (int line = 0; line < sizeOfMatrix; line++)
            {
                for (int column = 0; column < sizeOfMatrix; column++)
                {
                    if (column == line)
                    {
                        leftDiagonal += matrix[line, column];
                    }
                    if (column + line == sizeOfMatrix - 1)
                    {
                        rightDiagonal += matrix[line, column];
                    }
                }

            }
            return new Tuple<double, double>(leftDiagonal, rightDiagonal);
        }
    }
}