﻿using MathNet.Numerics;
using MathNet.Numerics.LinearAlgebra;

namespace DigiClass.Methods.Extensions
{
    /// <summary>
    ///     Zawiera rozszerzenia do klasy Matrix.
    /// </summary>
    internal static class MatrixExtensions
    {
        /// <summary>
        ///     Każdej wartości macierzy wejściowej zastosowano funkcję logistyczną (sigmoidalną) σ(t) = (1/(1+exp(-t)).
        ///     Zwraca nową macierz.
        /// </summary>
        /// <param name="input">Macierz wejściowa.</param>
        /// <returns>Macierz wyjściowa.</returns>
        public static Matrix<float> Sigmoid(this Matrix<float> input)
        {
            return input.Map(f => (float) SpecialFunctions.Logistic(f));
            //return input.Map(f => SpecialFunctions.Logistic((float)f));
        }

        /// <summary>
        ///     Każdej wartości macierzy wejściowej zastosowano pierwszą pochodną funkcji sigmoidalnej σ'(t) = σ(t)⋅(1 - σ(t)).
        ///     Zwraca nową macierz.
        /// </summary>
        /// <param name="input">Macierz wejściowa.</param>
        /// <returns>Macierz wyjściowa.</returns>
        public static Matrix<float> SigmoidPrime(this Matrix<float> input)
        {
            var sig = Sigmoid(input);
            return sig.PointwiseMultiply(sig.SubtractFrom(1));
        }

        /// <summary>
        ///     Tworzy nową macierz o identycznych wymiarach wypełnioną zerami.
        /// </summary>
        /// <param name="source">Macierz której wymiary mają zostać użyte.</param>
        /// <returns>Nowa wyzerowana macierz.</returns>
        public static Matrix<float> CreateMatrixOfSameShape(this Matrix<float> source)
        {
            return Matrix<float>.Build.Dense(source.RowCount, source.ColumnCount, 0);
        }

        /// <summary>
        ///     Tworzy nową macierz o identycznych wymiarach wypełnioną zerami.
        /// </summary>
        /// <param name="source">Macierz której wymiary mają zostać użyte.</param>
        /// <returns>Nowa wyzerowana macierz.</returns>
        public static Matrix<Complex32> CreateMatrixOfSameShape(this Matrix<Complex32> source)
        {
            return Matrix<Complex32>.Build.Dense(source.RowCount, source.ColumnCount, 0);
        }
    }
}