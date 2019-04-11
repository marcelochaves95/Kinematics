﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Mathematics
{
    /// <summary>
    /// Represents a 4x4 mathematical matrix
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Matrix : IEquatable<Matrix>
    {
        /// <summary>
        /// A matrix with all of its components set to zero
        /// </summary>
        public static readonly Matrix Zero = new Matrix();

        /// <summary>
        /// The identity <see cref="SlimMath.Matrix"/>.
        /// </summary>
        public static readonly Matrix Identity = new Matrix() { M11 = 1f, M22 = 1f, M33 = 1f, M44 = 1f };

        /// <summary>
        /// Value at row 1 column 1 of the matrix
        /// </summary>
        public float M11 { get; set; }

        /// <summary>
        /// Value at row 1 column 2 of the matrix
        /// </summary>
        public float M12 { get; set; }

        /// <summary>
        /// Value at row 1 column 3 of the matrix
        /// </summary>
        public float M13 { get; set; }

        /// <summary>
        /// Value at row 1 column 4 of the matrix
        /// </summary>
        public float M14 { get; set; }

        /// <summary>
        /// Value at row 2 column 1 of the matrix
        /// </summary>
        public float M21 { get; set; }

        /// <summary>
        /// Value at row 2 column 2 of the matrix
        /// </summary>
        public float M22 { get; set; }

        /// <summary>
        /// Value at row 2 column 3 of the matrix
        /// </summary>
        public float M23 { get; set; }

        /// <summary>
        /// Value at row 2 column 4 of the matrix
        /// </summary>
        public float M24 { get; set; }

        /// <summary>
        /// Value at row 3 column 1 of the matrix
        /// </summary>
        public float M31 { get; set; }

        /// <summary>
        /// Value at row 3 column 2 of the matrix
        /// </summary>
        public float M32 { get; set; }

        /// <summary>
        /// Value at row 3 column 3 of the matrix
        /// </summary>
        public float M33 { get; set; }

        /// <summary>
        /// Value at row 3 column 4 of the matrix
        /// </summary>
        public float M34 { get; set; }

        /// <summary>
        /// Value at row 4 column 1 of the matrix
        /// </summary>
        public float M41 { get; set; }

        /// <summary>
        /// Value at row 4 column 2 of the matrix
        /// </summary>
        public float M42 { get; set; }

        /// <summary>
        /// Value at row 4 column 3 of the matrix
        /// </summary>
        public float M43 { get; set; }

        /// <summary>
        /// Value at row 4 column 4 of the matrix
        /// </summary>
        public float M44 { get; set; }

        /// <summary>
        /// Initializes a new instance of the matrix struct
        /// </summary>
        /// <param name="M11">The value to assign at row 1 column 1 of the matrix</param>
        /// <param name="M12">The value to assign at row 1 column 2 of the matrix</param>
        /// <param name="M13">The value to assign at row 1 column 3 of the matrix</param>
        /// <param name="M14">The value to assign at row 1 column 4 of the matrix</param>
        /// <param name="M21">The value to assign at row 2 column 1 of the matrix</param>
        /// <param name="M22">The value to assign at row 2 column 2 of the matrix</param>
        /// <param name="M23">The value to assign at row 2 column 3 of the matrix</param>
        /// <param name="M24">The value to assign at row 2 column 4 of the matrix</param>
        /// <param name="M31">The value to assign at row 3 column 1 of the matrix</param>
        /// <param name="M32">The value to assign at row 3 column 2 of the matrix</param>
        /// <param name="M33">The value to assign at row 3 column 3 of the matrix</param>
        /// <param name="M34">The value to assign at row 3 column 4 of the matrix</param>
        /// <param name="M41">The value to assign at row 4 column 1 of the matrix</param>
        /// <param name="M42">The value to assign at row 4 column 2 of the matrix</param>
        /// <param name="M43">The value to assign at row 4 column 3 of the matrix</param>
        /// <param name="M44">The value to assign at row 4 column 4 of the matrix</param>
        public Matrix(float M11, float M12, float M13, float M14,
            float M21, float M22, float M23, float M24,
            float M31, float M32, float M33, float M34,
            float M41, float M42, float M43, float M44)
        {
            this.M11 = M11;
            this.M12 = M12;
            this.M13 = M13;
            this.M14 = M14;
            this.M21 = M21;
            this.M22 = M22;
            this.M23 = M23;
            this.M24 = M24;
            this.M31 = M31;
            this.M32 = M32;
            this.M33 = M33;
            this.M34 = M34;
            this.M41 = M41;
            this.M42 = M42;
            this.M43 = M43;
            this.M44 = M44;
        }

        /// <summary>
        /// Initializes a new instance of the matrix struct
        /// </summary>
        /// <param name="values">The values to assign to the components of the matrix. This must be an array with sixteen elements</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="values"/> is <c>null</c></exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="values"/> contains more or less than sixteen elements</exception>
        public Matrix(float[] values)
        {
            if (values == null)
                throw new ArgumentNullException("values");
            if (values.Length != 16)
                throw new ArgumentOutOfRangeException("values", "There must be sixteen and only sixteen input values for Matrix.");

            M11 = values[0];
            M12 = values[1];
            M13 = values[2];
            M14 = values[3];

            M21 = values[4];
            M22 = values[5];
            M23 = values[6];
            M24 = values[7];

            M31 = values[8];
            M32 = values[9];
            M33 = values[10];
            M34 = values[11];

            M41 = values[12];
            M42 = values[13];
            M43 = values[14];
            M44 = values[15];
        }

        /// <summary>
        /// Get's or set's the basis matrix for the rotation.
        /// </summary>
        public Matrix Basis
        {
            get
            {
                return new Matrix(
                    M11, M12, M13, 0,
                    M21, M22, M23, 0,
                    M31, M32, M33, 0,
                    0, 0, 0, 1);
            }
            set
            {
                M11 = value.M11;
                M12 = value.M12;
                M13 = value.M13;
                M21 = value.M21;
                M22 = value.M22;
                M23 = value.M23;
                M31 = value.M31;
                M32 = value.M32;
                M33 = value.M33;
            }
        }

        /// <summary>
        /// Get's or set's the first row in the matrix; that is M11, M12, M13, and M14
        /// </summary>
        public Vector4D Row1
        {
            get { return new Vector4D(M11, M12, M13, M14); }
            set { M11 = value.X; M12 = value.Y; M13 = value.Z; M14 = value.W; }
        }

        /// <summary>
        /// Get's or set's the second row in the matrix; that is M21, M22, M23, and M24
        /// </summary>
        public Vector4D Row2
        {
            get { return new Vector4D(M21, M22, M23, M24); }
            set { M21 = value.X; M22 = value.Y; M23 = value.Z; M24 = value.W; }
        }

        /// <summary>
        /// Gets or sets the third row in the matrix; that is M31, M32, M33, and M34
        /// </summary>
        public Vector4D Row3
        {
            get { return new Vector4D(M31, M32, M33, M34); }
            set { M31 = value.X; M32 = value.Y; M33 = value.Z; M34 = value.W; }
        }

        /// <summary>
        /// Gets or sets the fourth row in the matrix; that is M41, M42, M43, and M44
        /// </summary>
        public Vector4D Row4
        {
            get { return new Vector4D(M41, M42, M43, M44); }
            set { M41 = value.X; M42 = value.Y; M43 = value.Z; M44 = value.W; }
        }

        /// <summary>
        /// Gets or sets the first column in the matrix; that is M11, M21, M31, and M41
        /// </summary>
        public Vector4D Column1
        {
            get { return new Vector4D(M11, M21, M31, M41); }
            set { M11 = value.X; M21 = value.Y; M31 = value.Z; M41 = value.W; }
        }

        /// <summary>
        /// Gets or sets the second column in the matrix; that is M12, M22, M32, and M42
        /// </summary>
        public Vector4D Column2
        {
            get { return new Vector4D(M12, M22, M32, M42); }
            set { M12 = value.X; M22 = value.Y; M32 = value.Z; M42 = value.W; }
        }

        /// <summary>
        /// Gets or sets the third column in the matrix; that is M13, M23, M33, and M43
        /// </summary>
        public Vector4D Column3
        {
            get { return new Vector4D(M13, M23, M33, M43); }
            set { M13 = value.X; M23 = value.Y; M33 = value.Z; M43 = value.W; }
        }

        /// <summary>
        /// Gets or sets the fourth column in the matrix; that is M14, M24, M34, and M44
        /// </summary>
        public Vector4D Column4
        {
            get { return new Vector4D(M14, M24, M34, M44); }
            set { M14 = value.X; M24 = value.Y; M34 = value.Z; M44 = value.W; }
        }

        /// <summary>
        /// Gets or sets the translation of the matrix; that is M41, M42, and M43
        /// </summary>
        public Vector3D Origin
        {
            get { return new Vector3D(M41, M42, M43); }
            set { M41 = value.X; M42 = value.Y; M43 = value.Z; }
        }

        public Quaternion Orientation
        {
            get
            {
                float trace = M11 + M22 + M33;

                float[] temp = new float[4];

                if (trace > 0f)
                {
                    float s = Mathematics.Sqrt(trace + (1f));
                    temp[3] = (s * (0.5f));
                    s = (0.5f) / s;

                    temp[0] = ((M32 - M23) * s);
                    temp[1] = ((M13 - M31) * s);
                    temp[2] = ((M21 - M12) * s);
                }
                else
                {
                    int i = M11 < M22 ? (M22 < M33 ? 2 : 1) : (M11 < M33 ? 2 : 0);
                    int j = (i + 1) % 3;
                    int k = (i + 2) % 3;

                    float s = Mathematics.Sqrt(this [i, i] - this [j, j] - this [k, k] + 1f);
                    temp[i] = s * 0.5f;
                    s = 0.5f / s;

                    temp[3] = (this [k, j] - this [j, k]) * s;
                    temp[j] = (this [j, i] + this [i, j]) * s;
                    temp[k] = (this [k, i] + this [i, k]) * s;
                }
                return new Quaternion(temp[0], temp[1], temp[2], temp[3]);
            }
            set
            {
                float d = value.X * value.X + value.Y * value.Y + value.Z * value.Z + value.W * value.W;
                float s = 2f / d;
                float xs = value.X * s, ys = value.Y * s, zs = value.Z * s;
                float wx = value.W * xs, wy = value.W * ys, wz = value.W * zs;
                float xx = value.X * xs, xy = value.X * ys, xz = value.X * zs;
                float yy = value.Y * ys, yz = value.Y * zs, zz = value.Z * zs;

                M11 = 1f - (yy + zz);
                M12 = xy - wz;
                M13 = xz + wy;
                M21 = xy + wz;
                M22 = 1f - (xx + zz);
                M23 = yz - wx;
                M31 = xz - wy;
                M32 = yz + wx;
                M33 = 1f - (xx + yy);
            }
        }

        /// <summary>
        /// Get's or set's the scale of the matrix; that is M11, M22, and M33
        /// </summary>
        public Vector3D ScaleVector
        {
            get { return new Vector3D(M11, M22, M33); }
            set { M11 = value.X; M22 = value.Y; M33 = value.Z; }
        }

        /// <summary>
        /// Decomposes a matrix into an orthonormalized matrix Q and a right traingular matrix R
        /// </summary>
        /// <param name="temp">When the method completes, contains the orthonormalized matrix of the decomposition</param>
        /// <param name="R">When the method completes, contains the right triangular matrix of the decomposition</param>
        public void DecomposeQR(out Matrix Q, out Matrix R)
        {
            Matrix temp;
            Q = Orthonormalize(this);
            temp = Q.Transpose();

            R = new Matrix();
            R.M11 = Vector4D.DotProduct(temp.Column1, Column1);
            R.M12 = Vector4D.DotProduct(temp.Column1, Column2);
            R.M13 = Vector4D.DotProduct(temp.Column1, Column3);
            R.M14 = Vector4D.DotProduct(temp.Column1, Column4);

            R.M22 = Vector4D.DotProduct(temp.Column2, Column2);
            R.M23 = Vector4D.DotProduct(temp.Column2, Column3);
            R.M24 = Vector4D.DotProduct(temp.Column2, Column4);

            R.M33 = Vector4D.DotProduct(temp.Column3, Column3);
            R.M34 = Vector4D.DotProduct(temp.Column3, Column4);

            R.M44 = Vector4D.DotProduct(temp.Column4, Column4);
        }

        /// <summary>
        /// Decomposes a matrix into a lower triangular matrix L and an orthonormalized matrix Q
        /// </summary>
        /// <param name="L">When the method completes, contains the lower triangular matrix of the decomposition</param>
        /// <param name="Q">When the method completes, contains the orthonormalized matrix of the decomposition</param>
        public void DecomposeLQ(out Matrix L, out Matrix Q)
        {
            Q = Orthonormalize(ref this);

            L = new Matrix();
            L.M11 = Vector4D.DotProduct(Q.Row1, Row1);

            L.M21 = Vector4D.DotProduct(Q.Row1, Row2);
            L.M22 = Vector4D.DotProduct(Q.Row2, Row2);

            L.M31 = Vector4D.DotProduct(Q.Row1, Row3);
            L.M32 = Vector4D.DotProduct(Q.Row2, Row3);
            L.M33 = Vector4D.DotProduct(Q.Row3, Row3);

            L.M41 = Vector4D.DotProduct(Q.Row1, Row4);
            L.M42 = Vector4D.DotProduct(Q.Row2, Row4);
            L.M43 = Vector4D.DotProduct(Q.Row3, Row4);
            L.M44 = Vector4D.DotProduct(Q.Row4, Row4);
        }

        /// <summary>
        /// Decomposes a matrix into a scale, rotation, and translation
        /// </summary>
        /// <param name="scale">When the method completes, contains the scaling component of the decomposed matrix</param>
        /// <param name="rotation">When the method completes, contains the rtoation component of the decomposed matrix</param>
        /// <param name="translation">When the method completes, contains the translation component of the decomposed matrix</param>
        public bool Decompose(out Vector3D scale, out Quaternion rotation, out Vector3D translation)
        {
            translation.X = M41;
            translation.Y = M42;
            translation.Z = M43;

            scale.X = Mathematics.Sqrt((M11 * M11) + (M12 * M12) + (M13 * M13));
            scale.Y = Mathematics.Sqrt((M21 * M21) + (M22 * M22) + (M23 * M23));
            scale.Z = Mathematics.Sqrt((M31 * M31) + (M32 * M32) + (M33 * M33));

            if (Mathematics.Abs(scale.X) < Utilities.ZeroTolerance || Mathematics.Abs(scale.Y) < Utilities.ZeroTolerance ||
                Mathematics.Abs(scale.Z) < Utilities.ZeroTolerance)
            {
                rotation = Quaternion.Identity;
                return false;
            }

            //The rotation is the left over matrix after dividing out the scaling.
            Matrix rotationmatrix = new Matrix();
            rotationmatrix.M11 = M11 / scale.X;
            rotationmatrix.M12 = M12 / scale.X;
            rotationmatrix.M13 = M13 / scale.X;

            rotationmatrix.M21 = M21 / scale.Y;
            rotationmatrix.M22 = M22 / scale.Y;
            rotationmatrix.M23 = M23 / scale.Y;

            rotationmatrix.M31 = M31 / scale.Z;
            rotationmatrix.M32 = M32 / scale.Z;
            rotationmatrix.M33 = M33 / scale.Z;

            rotationmatrix.M44 = 1f;

            Quaternion.RotationMatrix(ref rotationmatrix, out rotation);
            return true;
        }

        /// <summary>
        /// Exchanges two rows in the matrix.
        /// </summary>
        /// <param name="firstRow">The first row to exchange. This is an index of the row starting at zero.</param>
        /// <param name="secondRow">The second row to exchange. This is an index of the row starting at zero.</param>
        public void ExchangeRows(int firstRow, int secondRow)
        {
            if (firstRow < 0)
                throw new ArgumentOutOfRangeException("firstRow", "The parameter firstRow must be greater than or equal to zero.");
            if (firstRow > 3)
                throw new ArgumentOutOfRangeException("firstRow", "The parameter firstRow must be less than or equal to three.");
            if (secondRow < 0)
                throw new ArgumentOutOfRangeException("secondRow", "The parameter secondRow must be greater than or equal to zero.");
            if (secondRow > 3)
                throw new ArgumentOutOfRangeException("secondRow", "The parameter secondRow must be less than or equal to three.");

            if (firstRow == secondRow)
                return;

            float temp0 = this [secondRow, 0];
            float temp1 = this [secondRow, 1];
            float temp2 = this [secondRow, 2];
            float temp3 = this [secondRow, 3];

            this [secondRow, 0] = this [firstRow, 0];
            this [secondRow, 1] = this [firstRow, 1];
            this [secondRow, 2] = this [firstRow, 2];
            this [secondRow, 3] = this [firstRow, 3];

            this [firstRow, 0] = temp0;
            this [firstRow, 1] = temp1;
            this [firstRow, 2] = temp2;
            this [firstRow, 3] = temp3;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="firstColumn"></param>
        /// <param name="secondColumn"></param>
        public void ExchangeColumns(int firstColumn, int secondColumn)
        {
            if (firstColumn < 0)
                throw new ArgumentOutOfRangeException("firstColumn", "The parameter firstColumn must be greater than or equal to zero.");
            if (firstColumn > 3)
                throw new ArgumentOutOfRangeException("firstColumn", "The parameter firstColumn must be less than or equal to three.");
            if (secondColumn < 0)
                throw new ArgumentOutOfRangeException("secondColumn", "The parameter secondColumn must be greater than or equal to zero.");
            if (secondColumn > 3)
                throw new ArgumentOutOfRangeException("secondColumn", "The parameter secondColumn must be less than or equal to three.");

            if (firstColumn == secondColumn)
                return;

            float temp0 = this [0, secondColumn];
            float temp1 = this [1, secondColumn];
            float temp2 = this [2, secondColumn];
            float temp3 = this [3, secondColumn];

            this [0, secondColumn] = this [0, firstColumn];
            this [1, secondColumn] = this [1, firstColumn];
            this [2, secondColumn] = this [2, firstColumn];
            this [3, secondColumn] = this [3, firstColumn];

            this [0, firstColumn] = temp0;
            this [1, firstColumn] = temp1;
            this [2, firstColumn] = temp2;
            this [3, firstColumn] = temp3;
        }

        /// <summary>
        /// Creates an array containing the elements of the matrix.
        /// </summary>
        /// <returns>A sixteen-element array containing the components of the matrix.</returns>
        public float[] ToArray()
        {
            return new [] { M11, M12, M13, M14, M21, M22, M23, M24, M31, M32, M33, M34, M41, M42, M43, M44 };
        }

        /// <summary>
        /// Performs the exponential operation on a matrix.
        /// </summary>
        /// <param name="value">The matrix to perform the operation on</param>
        /// <param name="exponent">The exponent to raise the matrix to</param>
        /// <returns>The exponential matrix.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the <paramref name="exponent"/> is negative</exception>
        public static Matrix Exponent(Matrix value, int exponent)
        {
            Matrix result;

            if (exponent < 0)
                throw new ArgumentOutOfRangeException("exponent", "The exponent can not be negative.");

            if (exponent == 0)
            {
                result = Matrix.Identity;
                return;
            }

            if (exponent == 1)
            {
                result = value;
                return;
            }

            Matrix identity = Matrix.Identity;
            Matrix temp = value;

            while (true)
            {
                if ((exponent & 1) != 0)
                    identity = identity * temp;

                exponent /= 2;

                if (exponent > 0)
                    temp *= temp;
                else
                    break;
            }

            result = identity;

            return result;
        }

        /// <summary>
        /// Negates a matrix.
        /// </summary>
        /// <param name="value">The matrix to be negated.</param>
        /// <returns>The negated matrix.</returns>
        public static Matrix Negate(Matrix value)
        {
            Matrix result;
            Negate(ref value, out result);
            return result;
        }

        /// <summary>
        /// Performs a linear interpolation between two matricies.
        /// </summary>
        /// <param name="start">Start matrix.</param>
        /// <param name="end">End matrix.</param>
        /// <param name="amount">Value between 0 and 1 indicating the weight of <paramref name="end"/>.</param>
        /// <param name="result">When the method completes, contains the linear interpolation of the two matricies.</param>
        /// <remarks>
        /// This method performs the linear interpolation based on the following formula.
        /// <code>start + (end - start) * amount</code>
        /// Passing <paramref name="amount"/> a value of 0 will cause <paramref name="start"/> to be returned; a value of 1 will cause <paramref name="end"/> to be returned. 
        /// </remarks>
        public static void Lerp(ref Matrix start, ref Matrix end, float amount, out Matrix result)
        {
            result.M11 = start.M11 + ((end.M11 - start.M11) * amount);
            result.M12 = start.M12 + ((end.M12 - start.M12) * amount);
            result.M13 = start.M13 + ((end.M13 - start.M13) * amount);
            result.M14 = start.M14 + ((end.M14 - start.M14) * amount);
            result.M21 = start.M21 + ((end.M21 - start.M21) * amount);
            result.M22 = start.M22 + ((end.M22 - start.M22) * amount);
            result.M23 = start.M23 + ((end.M23 - start.M23) * amount);
            result.M24 = start.M24 + ((end.M24 - start.M24) * amount);
            result.M31 = start.M31 + ((end.M31 - start.M31) * amount);
            result.M32 = start.M32 + ((end.M32 - start.M32) * amount);
            result.M33 = start.M33 + ((end.M33 - start.M33) * amount);
            result.M34 = start.M34 + ((end.M34 - start.M34) * amount);
            result.M41 = start.M41 + ((end.M41 - start.M41) * amount);
            result.M42 = start.M42 + ((end.M42 - start.M42) * amount);
            result.M43 = start.M43 + ((end.M43 - start.M43) * amount);
            result.M44 = start.M44 + ((end.M44 - start.M44) * amount);
        }

        /// <summary>
        /// Performs a linear interpolation between two matricies.
        /// </summary>
        /// <param name="start">Start matrix.</param>
        /// <param name="end">End matrix.</param>
        /// <param name="amount">Value between 0 and 1 indicating the weight of <paramref name="end"/>.</param>
        /// <returns>The linear interpolation of the two matrices.</returns>
        /// <remarks>
        /// This method performs the linear interpolation based on the following formula.
        /// <code>start + (end - start) * amount</code>
        /// Passing <paramref name="amount"/> a value of 0 will cause <paramref name="start"/> to be returned; a value of 1 will cause <paramref name="end"/> to be returned. 
        /// </remarks>
        public static Matrix Lerp(Matrix start, Matrix end, float amount)
        {
            Matrix result;
            Lerp(ref start, ref end, amount, out result);
            return result;
        }

        /// <summary>
        /// Performs a cubic interpolation between two matricies.
        /// </summary>
        /// <param name="start">Start matrix.</param>
        /// <param name="end">End matrix.</param>
        /// <param name="amount">Value between 0 and 1 indicating the weight of <paramref name="end"/>.</param>
        /// <param name="result">When the method completes, contains the cubic interpolation of the two matrices.</param>
        public static void SmoothStep(ref Matrix start, ref Matrix end, float amount, out Matrix result)
        {
            amount = (amount > 1f) ? 1f : ((amount < 0f) ? 0f : amount);
            amount = (amount * amount) * (3f - (2f * amount));

            result.M11 = start.M11 + ((end.M11 - start.M11) * amount);
            result.M12 = start.M12 + ((end.M12 - start.M12) * amount);
            result.M13 = start.M13 + ((end.M13 - start.M13) * amount);
            result.M14 = start.M14 + ((end.M14 - start.M14) * amount);
            result.M21 = start.M21 + ((end.M21 - start.M21) * amount);
            result.M22 = start.M22 + ((end.M22 - start.M22) * amount);
            result.M23 = start.M23 + ((end.M23 - start.M23) * amount);
            result.M24 = start.M24 + ((end.M24 - start.M24) * amount);
            result.M31 = start.M31 + ((end.M31 - start.M31) * amount);
            result.M32 = start.M32 + ((end.M32 - start.M32) * amount);
            result.M33 = start.M33 + ((end.M33 - start.M33) * amount);
            result.M34 = start.M34 + ((end.M34 - start.M34) * amount);
            result.M41 = start.M41 + ((end.M41 - start.M41) * amount);
            result.M42 = start.M42 + ((end.M42 - start.M42) * amount);
            result.M43 = start.M43 + ((end.M43 - start.M43) * amount);
            result.M44 = start.M44 + ((end.M44 - start.M44) * amount);
        }

        /// <summary>
        /// Performs a cubic interpolation between two matrices.
        /// </summary>
        /// <param name="start">Start matrix.</param>
        /// <param name="end">End matrix.</param>
        /// <param name="amount">Value between 0 and 1 indicating the weight of <paramref name="end"/>.</param>
        /// <returns>The cubic interpolation of the two matrices.</returns>
        public static Matrix SmoothStep(Matrix start, Matrix end, float amount)
        {
            Matrix result;
            SmoothStep(ref start, ref end, amount, out result);
            return result;
        }

        /// <summary>
        /// Calculates the transpose of the specified matrix
        /// </summary>
        /// <param name="value">The matrix whose transpose is to be calculated</param>
        /// <returns>The transpose of the specified matrix</returns>
        public static Matrix Transpose(Matrix value)
        {
            return new Matrix(
                value.M11, value.M12, value.M13, value.M14,
                value.M21, value.M22, value.M23, value.M24,
                value.M31, value.M32, value.M33, value.M34,
                value.M41, value.M42, value.M43, value.M44
            );
        }

        /// <summary>
        /// Calculates the inverse of the specified matrix
        /// </summary>
        /// <param name="value">The matrix whose inverse is to be calculated</param>
        /// <returns>The inverse of the specified matrix</returns>
        public static Matrix Invert(Matrix value)
        {
            Matrix result;

            float b0 = (value.M31 * value.M42) - (value.M32 * value.M41);
            float b1 = (value.M31 * value.M43) - (value.M33 * value.M41);
            float b2 = (value.M34 * value.M41) - (value.M31 * value.M44);
            float b3 = (value.M32 * value.M43) - (value.M33 * value.M42);
            float b4 = (value.M34 * value.M42) - (value.M32 * value.M44);
            float b5 = (value.M33 * value.M44) - (value.M34 * value.M43);

            float d11 = value.M22 * b5 + value.M23 * b4 + value.M24 * b3;
            float d12 = value.M21 * b5 + value.M23 * b2 + value.M24 * b1;
            float d13 = value.M21 * -b4 + value.M22 * b2 + value.M24 * b0;
            float d14 = value.M21 * b3 + value.M22 * -b1 + value.M23 * b0;

            float det = value.M11 * d11 - value.M12 * d12 + value.M13 * d13 - value.M14 * d14;
            if (Mathematics.Abs(det) <= Utilities.ZeroTolerance)
            {
                result = Matrix.Zero;
                return;
            }

            det = 1f / det;

            float a0 = (value.M11 * value.M22) - (value.M12 * value.M21);
            float a1 = (value.M11 * value.M23) - (value.M13 * value.M21);
            float a2 = (value.M14 * value.M21) - (value.M11 * value.M24);
            float a3 = (value.M12 * value.M23) - (value.M13 * value.M22);
            float a4 = (value.M14 * value.M22) - (value.M12 * value.M24);
            float a5 = (value.M13 * value.M24) - (value.M14 * value.M23);

            float d21 = value.M12 * b5 + value.M13 * b4 + value.M14 * b3;
            float d22 = value.M11 * b5 + value.M13 * b2 + value.M14 * b1;
            float d23 = value.M11 * -b4 + value.M12 * b2 + value.M14 * b0;
            float d24 = value.M11 * b3 + value.M12 * -b1 + value.M13 * b0;

            float d31 = value.M42 * a5 + value.M43 * a4 + value.M44 * a3;
            float d32 = value.M41 * a5 + value.M43 * a2 + value.M44 * a1;
            float d33 = value.M41 * -a4 + value.M42 * a2 + value.M44 * a0;
            float d34 = value.M41 * a3 + value.M42 * -a1 + value.M43 * a0;

            float d41 = value.M32 * a5 + value.M33 * a4 + value.M34 * a3;
            float d42 = value.M31 * a5 + value.M33 * a2 + value.M34 * a1;
            float d43 = value.M31 * -a4 + value.M32 * a2 + value.M34 * a0;
            float d44 = value.M31 * a3 + value.M32 * -a1 + value.M33 * a0;

            result.M11 = +d11 * det;
            result.M12 = -d21 * det;
            result.M13 = +d31 * det;
            result.M14 = -d41 * det;
            result.M21 = -d12 * det;
            result.M22 = +d22 * det;
            result.M23 = -d32 * det;
            result.M24 = +d42 * det;
            result.M31 = +d13 * det;
            result.M32 = -d23 * det;
            result.M33 = +d33 * det;
            result.M34 = -d43 * det;
            result.M41 = -d14 * det;
            result.M42 = +d24 * det;
            result.M43 = -d34 * det;
            result.M44 = +d44 * det;

            return result;
        }

        /// <summary>
        /// Orthogonalizes the specified matrix
        /// </summary>
        /// <param name="value">The matrix to orthogonalize</param>
        /// <returns>The orthogonalized matrix</returns>
        public static Matrix Orthogonalize(Matrix value)
        {
            Matrix result;

            result = value;

            result.Row2 = result.Row2 - (Vector4D.DotProduct(result.Row1, result.Row2) / Vector4D.DotProduct(result.Row1, result.Row1)) * result.Row1;

            result.Row3 = result.Row3 - (Vector4D.DotProduct(result.Row1, result.Row3) / Vector4D.DotProduct(result.Row1, result.Row1)) * result.Row1;
            result.Row3 = result.Row3 - (Vector4D.DotProduct(result.Row2, result.Row3) / Vector4D.DotProduct(result.Row2, result.Row2)) * result.Row2;

            result.Row4 = result.Row4 - (Vector4D.DotProduct(result.Row1, result.Row4) / Vector4D.DotProduct(result.Row1, result.Row1)) * result.Row1;
            result.Row4 = result.Row4 - (Vector4D.DotProduct(result.Row2, result.Row4) / Vector4D.DotProduct(result.Row2, result.Row2)) * result.Row2;
            result.Row4 = result.Row4 - (Vector4D.DotProduct(result.Row3, result.Row4) / Vector4D.DotProduct(result.Row3, result.Row3)) * result.Row3;

            return result;
        }

        /// <summary>
        /// Orthonormalizes the specified matrix
        /// </summary>
        /// <param name="value">The matrix to orthonormalize</param>
        /// <returns>The orthonormalized matrix</returns>
        /// <remarks>
        public static Matrix Orthonormalize(Matrix value)
        {
            Matrix result;

            result = value;

            result.Row1 = Vector4D.Normalize(result.Row1);

            result.Row2 = result.Row2 - Vector4D.DotProduct(result.Row1, result.Row2) * result.Row1;
            result.Row2 = Vector4D.Normalize(result.Row2);

            result.Row3 = result.Row3 - Vector4D.DotProduct(result.Row1, result.Row3) * result.Row1;
            result.Row3 = result.Row3 - Vector4D.DotProduct(result.Row2, result.Row3) * result.Row2;
            result.Row3 = Vector4D.Normalize(result.Row3);

            result.Row4 = result.Row4 - Vector4D.DotProduct(result.Row1, result.Row4) * result.Row1;
            result.Row4 = result.Row4 - Vector4D.DotProduct(result.Row2, result.Row4) * result.Row2;
            result.Row4 = result.Row4 - Vector4D.DotProduct(result.Row3, result.Row4) * result.Row3;
            result.Row4 = Vector4D.Normalize(result.Row4);

            return result;
        }

        /// <summary>
        /// Brings the matrix into upper triangular form using elementry row operations.
        /// </summary>
        /// <param name="value">The matrix to put into upper triangular form.</param>
        /// <param name="result">When the method completes, contains the upper triangular matrix.</param>
        /// <remarks>
        /// If the matrix is not invertable (i.e. its determinant is zero) than the result of this
        /// method may produce Single.Nan and Single.Inf values. When the matrix represents a system
        /// of linear equations, than this often means that either no solution exists or an infinite
        /// number of solutions exist.
        /// </remarks>
        public static void UpperTriangularForm(ref Matrix value, out Matrix result)
        {
            //Adapted from the row echelon code
            result = value;
            int lead = 0;
            int rowcount = 4;
            int columncount = 4;

            for (int r = 0; r < rowcount; ++r)
            {
                if (columncount <= lead)
                    return;

                int i = r;

                while (Mathematics.Abs(result[i, lead]) < Utilities.ZeroTolerance)
                {
                    i++;

                    if (i == rowcount)
                    {
                        i = r;
                        lead++;

                        if (lead == columncount)
                            return;
                    }
                }

                if (i != r)
                {
                    result.ExchangeRows(i, r);
                }

                float multiplier = 1f / result[r, lead];

                for (; i < rowcount; ++i)
                {
                    if (i != r)
                    {
                        result[i, 0] -= result[r, 0] * multiplier * result[i, lead];
                        result[i, 1] -= result[r, 1] * multiplier * result[i, lead];
                        result[i, 2] -= result[r, 2] * multiplier * result[i, lead];
                        result[i, 3] -= result[r, 3] * multiplier * result[i, lead];
                    }
                }

                lead++;
            }
        }

        /// <summary>
        /// Brings the matrix into upper triangular form using elementry row operations.
        /// </summary>
        /// <param name="value">The matrix to put into upper triangular form.</param>
        /// <returns>The upper triangular matrix.</returns>
        /// <remarks>
        /// If the matrix is not invertable (i.e. its determinant is zero) than the result of this
        /// method may produce Single.Nan and Single.Inf values. When the matrix represents a system
        /// of linear equations, than this often means that either no solution exists or an infinite
        /// number of solutions exist.
        /// </remarks>
        public static Matrix UpperTriangularForm(Matrix value)
        {
            Matrix result;
            UpperTriangularForm(ref value, out result);
            return result;
        }

        /// <summary>
        /// Brings the matrix into lower triangular form using elementry row operations.
        /// </summary>
        /// <param name="value">The matrix to put into lower triangular form.</param>
        /// <param name="result">When the method completes, contains the lower triangular matrix.</param>
        /// <remarks>
        /// If the matrix is not invertable (i.e. its determinant is zero) than the result of this
        /// method may produce Single.Nan and Single.Inf values. When the matrix represents a system
        /// of linear equations, than this often means that either no solution exists or an infinite
        /// number of solutions exist.
        /// </remarks>
        public static void LowerTriangularForm(ref Matrix value, out Matrix result)
        {
            //Adapted from the row echelon code
            Matrix temp = value;
            Matrix.Transpose(ref temp, out result);

            int lead = 0;
            int rowcount = 4;
            int columncount = 4;

            for (int r = 0; r < rowcount; ++r)
            {
                if (columncount <= lead)
                    return;

                int i = r;

                while (Mathematics.Abs(result[i, lead]) < Utilities.ZeroTolerance)
                {
                    i++;

                    if (i == rowcount)
                    {
                        i = r;
                        lead++;

                        if (lead == columncount)
                            return;
                    }
                }

                if (i != r)
                {
                    result.ExchangeRows(i, r);
                }

                float multiplier = 1f / result[r, lead];

                for (; i < rowcount; ++i)
                {
                    if (i != r)
                    {
                        result[i, 0] -= result[r, 0] * multiplier * result[i, lead];
                        result[i, 1] -= result[r, 1] * multiplier * result[i, lead];
                        result[i, 2] -= result[r, 2] * multiplier * result[i, lead];
                        result[i, 3] -= result[r, 3] * multiplier * result[i, lead];
                    }
                }

                lead++;
            }

            Matrix.Transpose(ref result, out result);
        }

        /// <summary>
        /// Brings the matrix into lower triangular form using elementry row operations.
        /// </summary>
        /// <param name="value">The matrix to put into lower triangular form.</param>
        /// <returns>The lower triangular matrix.</returns>
        /// <remarks>
        /// If the matrix is not invertable (i.e. its determinant is zero) than the result of this
        /// method may produce Single.Nan and Single.Inf values. When the matrix represents a system
        /// of linear equations, than this often means that either no solution exists or an infinite
        /// number of solutions exist.
        /// </remarks>
        public static Matrix LowerTriangularForm(Matrix value)
        {
            Matrix result;
            LowerTriangularForm(ref value, out result);
            return result;
        }

        /// <summary>
        /// Brings the matrix into row echelon form using elementry row operations;
        /// </summary>
        /// <param name="value">The matrix to put into row echelon form.</param>
        /// <param name="result">When the method completes, contains the row echelon form of the matrix.</param>
        public static void RowEchelonForm(ref Matrix value, out Matrix result)
        {
            //Source: Wikipedia psuedo code
            //Reference: http://en.wikipedia.org/wiki/Row_echelon_form#Pseudocode

            result = value;
            int lead = 0;
            int rowcount = 4;
            int columncount = 4;

            for (int r = 0; r < rowcount; ++r)
            {
                if (columncount <= lead)
                    return;

                int i = r;

                while (Mathematics.Abs(result[i, lead]) < Utilities.ZeroTolerance)
                {
                    i++;

                    if (i == rowcount)
                    {
                        i = r;
                        lead++;

                        if (lead == columncount)
                            return;
                    }
                }

                if (i != r)
                {
                    result.ExchangeRows(i, r);
                }

                float multiplier = 1f / result[r, lead];
                result[r, 0] *= multiplier;
                result[r, 1] *= multiplier;
                result[r, 2] *= multiplier;
                result[r, 3] *= multiplier;

                for (; i < rowcount; ++i)
                {
                    if (i != r)
                    {
                        result[i, 0] -= result[r, 0] * result[i, lead];
                        result[i, 1] -= result[r, 1] * result[i, lead];
                        result[i, 2] -= result[r, 2] * result[i, lead];
                        result[i, 3] -= result[r, 3] * result[i, lead];
                    }
                }

                lead++;
            }
        }

        /// <summary>
        /// Brings the matrix into row echelon form using elementry row operations;
        /// </summary>
        /// <param name="value">The matrix to put into row echelon form.</param>
        /// <returns>When the method completes, contains the row echelon form of the matrix.</returns>
        public static Matrix RowEchelonForm(Matrix value)
        {
            Matrix result;
            RowEchelonForm(ref value, out result);
            return result;
        }

        /// <summary>
        /// Brings the matrix into reduced row echelon form using elementry row operations.
        /// </summary>
        /// <param name="value">The matrix to put into reduced row echelon form.</param>
        /// <param name="augment">The fifth column of the matrix.</param>
        /// <param name="result">When the method completes, contains the resultant matrix after the operation.</param>
        /// <param name="augmentResult">When the method completes, contains the resultant fifth column of the matrix.</param>
        /// <remarks>
        /// <para>The fifth column is often called the agumented part of the matrix. This is because the fifth
        /// column is really just an extension of the matrix so that there is a place to put all of the
        /// non-zero components after the operation is complete.</para>
        /// <para>Often times the resultant matrix will the identity matrix or a matrix similar to the identity
        /// matrix. Sometimes, however, that is not possible and numbers other than zero and one may appear.</para>
        /// <para>This method can be used to solve systems of linear equations. Upon completion of this method,
        /// the <paramref name="augmentResult"/> will contain the solution for the system. It is up to the user
        /// to analyze both the input and the result to determine if a solution really exists.</para>
        /// </remarks>
        public static void ReducedRowEchelonForm(ref Matrix value, ref Vector4D augment, out Matrix result, out Vector4D augmentResult)
        {
            //Source: http://rosettacode.org
            //Reference: http://rosettacode.org/wiki/Reduced_row_echelon_form

            float[, ] matrix = new float[4, 5];

            matrix[0, 0] = value[0, 0];
            matrix[0, 1] = value[0, 1];
            matrix[0, 2] = value[0, 2];
            matrix[0, 3] = value[0, 3];
            matrix[0, 4] = augment[0];

            matrix[1, 0] = value[1, 0];
            matrix[1, 1] = value[1, 1];
            matrix[1, 2] = value[1, 2];
            matrix[1, 3] = value[1, 3];
            matrix[1, 4] = augment[1];

            matrix[2, 0] = value[2, 0];
            matrix[2, 1] = value[2, 1];
            matrix[2, 2] = value[2, 2];
            matrix[2, 3] = value[2, 3];
            matrix[2, 4] = augment[2];

            matrix[3, 0] = value[3, 0];
            matrix[3, 1] = value[3, 1];
            matrix[3, 2] = value[3, 2];
            matrix[3, 3] = value[3, 3];
            matrix[3, 4] = augment[3];

            int lead = 0;
            int rowcount = 4;
            int columncount = 5;

            for (int r = 0; r < rowcount; r++)
            {
                if (columncount <= lead)
                    break;

                int i = r;

                while (matrix[i, lead] == 0)
                {
                    i++;

                    if (i == rowcount)
                    {
                        i = r;
                        lead++;

                        if (columncount == lead)
                            break;
                    }
                }

                for (int j = 0; j < columncount; j++)
                {
                    float temp = matrix[r, j];
                    matrix[r, j] = matrix[i, j];
                    matrix[i, j] = temp;
                }

                float div = matrix[r, lead];

                for (int j = 0; j < columncount; j++)
                {
                    matrix[r, j] /= div;
                }

                for (int j = 0; j < rowcount; j++)
                {
                    if (j != r)
                    {
                        float sub = matrix[j, lead];
                        for (int k = 0; k < columncount; k++)matrix[j, k] -= (sub * matrix[r, k]);
                    }
                }

                lead++;
            }

            result.M11 = matrix[0, 0];
            result.M12 = matrix[0, 1];
            result.M13 = matrix[0, 2];
            result.M14 = matrix[0, 3];

            result.M21 = matrix[1, 0];
            result.M22 = matrix[1, 1];
            result.M23 = matrix[1, 2];
            result.M24 = matrix[1, 3];

            result.M31 = matrix[2, 0];
            result.M32 = matrix[2, 1];
            result.M33 = matrix[2, 2];
            result.M34 = matrix[2, 3];

            result.M41 = matrix[3, 0];
            result.M42 = matrix[3, 1];
            result.M43 = matrix[3, 2];
            result.M44 = matrix[3, 3];

            augmentResult.X = matrix[0, 4];
            augmentResult.Y = matrix[1, 4];
            augmentResult.Z = matrix[2, 4];
            augmentResult.W = matrix[3, 4];
        }

        /// <summary>
        /// Creates a spherical billboard that rotates around a specified object position.
        /// </summary>
        /// <param name="objectPosition">The position of the object around which the billboard will rotate.</param>
        /// <param name="cameraPosition">The position of the camera.</param>
        /// <param name="cameraUpVector">The up vector of the camera.</param>
        /// <param name="cameraForwardVector">The forward vector of the camera.</param>
        /// <param name="result">When the method completes, contains the created billboard matrix.</param>
        public static void Billboard(ref Vector3D objectPosition, ref Vector3D cameraPosition, ref Vector3D cameraUpVector, ref Vector3D cameraForwardVector, out Matrix result)
        {
            Vector3D crossed;
            Vector3D final;
            Vector3D difference = objectPosition - cameraPosition;

            float lengthsq = difference.LengthSquared;
            if (lengthsq < Utilities.ZeroTolerance)
                difference = -cameraForwardVector;
            else
                difference *= (1 / Mathematics.Sqrt(lengthsq));

            Vector3D.Cross(ref cameraUpVector, ref difference, out crossed);
            crossed.Normalize();
            Vector3D.Cross(ref difference, ref crossed, out final);

            result.M11 = crossed.X;
            result.M12 = crossed.Y;
            result.M13 = crossed.Z;
            result.M14 = 0f;
            result.M21 = final.X;
            result.M22 = final.Y;
            result.M23 = final.Z;
            result.M24 = 0f;
            result.M31 = difference.X;
            result.M32 = difference.Y;
            result.M33 = difference.Z;
            result.M34 = 0f;
            result.M41 = objectPosition.X;
            result.M42 = objectPosition.Y;
            result.M43 = objectPosition.Z;
            result.M44 = 1f;
        }

        /// <summary>
        /// Creates a spherical billboard that rotates around a specified object position.
        /// </summary>
        /// <param name="objectPosition">The position of the object around which the billboard will rotate.</param>
        /// <param name="cameraPosition">The position of the camera.</param>
        /// <param name="cameraUpVector">The up vector of the camera.</param>
        /// <param name="cameraForwardVector">The forward vector of the camera.</param>
        /// <returns>The created billboard matrix.</returns>
        public static Matrix Billboard(Vector3D objectPosition, Vector3D cameraPosition, Vector3D cameraUpVector, Vector3D cameraForwardVector)
        {
            Matrix result;
            Billboard(ref objectPosition, ref cameraPosition, ref cameraUpVector, ref cameraForwardVector, out result);
            return result;
        }

        /// <summary>
        /// Creates a left-handed, look-at matrix.
        /// </summary>
        /// <param name="eye">The position of the viewer's eye.</param>
        /// <param name="target">The camera look-at target.</param>
        /// <param name="up">The camera's up vector.</param>
        /// <param name="result">When the method completes, contains the created look-at matrix.</param>
        public static void LookAtLH(ref Vector3D eye, ref Vector3D target, ref Vector3D up, out Matrix result)
        {
            Vector3D xaxis, yaxis, zaxis;
            Vector3D.Subtract(ref target, ref eye, out zaxis);
            zaxis.Normalize();
            Vector3D.Cross(ref up, ref zaxis, out xaxis);
            xaxis.Normalize();
            Vector3D.Cross(ref zaxis, ref xaxis, out yaxis);

            result = Matrix.Identity;
            result.M11 = xaxis.X;
            result.M21 = xaxis.Y;
            result.M31 = xaxis.Z;
            result.M12 = yaxis.X;
            result.M22 = yaxis.Y;
            result.M32 = yaxis.Z;
            result.M13 = zaxis.X;
            result.M23 = zaxis.Y;
            result.M33 = zaxis.Z;

            Vector3D.DotProduct(ref xaxis, ref eye, out result.M41);
            Vector3D.DotProduct(ref yaxis, ref eye, out result.M42);
            Vector3D.DotProduct(ref zaxis, ref eye, out result.M43);
            result.M41 = -result.M41;
            result.M42 = -result.M42;
            result.M43 = -result.M43;
        }

        /// <summary>
        /// Creates a left-handed, look-at matrix.
        /// </summary>
        /// <param name="eye">The position of the viewer's eye.</param>
        /// <param name="target">The camera look-at target.</param>
        /// <param name="up">The camera's up vector.</param>
        /// <returns>The created look-at matrix.</returns>
        public static Matrix LookAtLH(Vector3D eye, Vector3D target, Vector3D up)
        {
            Matrix result;
            LookAtLH(ref eye, ref target, ref up, out result);
            return result;
        }

        /// <summary>
        /// Creates a right-handed, look-at matrix.
        /// </summary>
        /// <param name="eye">The position of the viewer's eye.</param>
        /// <param name="target">The camera look-at target.</param>
        /// <param name="up">The camera's up vector.</param>
        /// <param name="result">When the method completes, contains the created look-at matrix.</param>
        public static void LookAtRH(ref Vector3D eye, ref Vector3D target, ref Vector3D up, out Matrix result)
        {
            Vector3D xaxis, yaxis, zaxis;
            Vector3D.Subtract(ref eye, ref target, out zaxis);
            zaxis.Normalize();
            Vector3D.Cross(ref up, ref zaxis, out xaxis);
            xaxis.Normalize();
            Vector3D.Cross(ref zaxis, ref xaxis, out yaxis);

            result = Matrix.Identity;
            result.M11 = xaxis.X;
            result.M21 = xaxis.Y;
            result.M31 = xaxis.Z;
            result.M12 = yaxis.X;
            result.M22 = yaxis.Y;
            result.M32 = yaxis.Z;
            result.M13 = zaxis.X;
            result.M23 = zaxis.Y;
            result.M33 = zaxis.Z;

            Vector3D.DotProduct(ref xaxis, ref eye, out result.M41);
            Vector3D.DotProduct(ref yaxis, ref eye, out result.M42);
            Vector3D.DotProduct(ref zaxis, ref eye, out result.M43);
            result.M41 = -result.M41;
            result.M42 = -result.M42;
            result.M43 = -result.M43;
        }

        /// <summary>
        /// Creates a right-handed, look-at matrix.
        /// </summary>
        /// <param name="eye">The position of the viewer's eye.</param>
        /// <param name="target">The camera look-at target.</param>
        /// <param name="up">The camera's up vector.</param>
        /// <returns>The created look-at matrix.</returns>
        public static Matrix LookAtRH(Vector3D eye, Vector3D target, Vector3D up)
        {
            Matrix result;
            LookAtRH(ref eye, ref target, ref up, out result);
            return result;
        }

        /// <summary>
        /// Creates a left-handed, orthographic projection matrix.
        /// </summary>
        /// <param name="width">Width of the viewing volume.</param>
        /// <param name="height">Height of the viewing volume.</param>
        /// <param name="znear">Minimum z-value of the viewing volume.</param>
        /// <param name="zfar">Maximum z-value of the viewing volume.</param>
        /// <param name="result">When the method completes, contains the created projection matrix.</param>
        public static void OrthoLH(float width, float height, float znear, float zfar, out Matrix result)
        {
            float halfWidth = width * 0.5f;
            float halfHeight = height * 0.5f;

            OrthoOffCenterLH(-halfWidth, halfWidth, -halfHeight, halfHeight, znear, zfar, out result);
        }

        /// <summary>
        /// Creates a left-handed, orthographic projection matrix.
        /// </summary>
        /// <param name="width">Width of the viewing volume.</param>
        /// <param name="height">Height of the viewing volume.</param>
        /// <param name="znear">Minimum z-value of the viewing volume.</param>
        /// <param name="zfar">Maximum z-value of the viewing volume.</param>
        /// <returns>The created projection matrix.</returns>
        public static Matrix OrthoLH(float width, float height, float znear, float zfar)
        {
            Matrix result;
            OrthoLH(width, height, znear, zfar, out result);
            return result;
        }

        /// <summary>
        /// Creates a right-handed, orthographic projection matrix.
        /// </summary>
        /// <param name="width">Width of the viewing volume.</param>
        /// <param name="height">Height of the viewing volume.</param>
        /// <param name="znear">Minimum z-value of the viewing volume.</param>
        /// <param name="zfar">Maximum z-value of the viewing volume.</param>
        /// <param name="result">When the method completes, contains the created projection matrix.</param>
        public static void OrthoRH(float width, float height, float znear, float zfar, out Matrix result)
        {
            float halfWidth = width * 0.5f;
            float halfHeight = height * 0.5f;

            OrthoOffCenterRH(-halfWidth, halfWidth, -halfHeight, halfHeight, znear, zfar, out result);
        }

        /// <summary>
        /// Creates a right-handed, orthographic projection matrix.
        /// </summary>
        /// <param name="width">Width of the viewing volume.</param>
        /// <param name="height">Height of the viewing volume.</param>
        /// <param name="znear">Minimum z-value of the viewing volume.</param>
        /// <param name="zfar">Maximum z-value of the viewing volume.</param>
        /// <returns>The created projection matrix.</returns>
        public static Matrix OrthoRH(float width, float height, float znear, float zfar)
        {
            Matrix result;
            OrthoRH(width, height, znear, zfar, out result);
            return result;
        }

        /// <summary>
        /// Creates a left-handed, customized orthographic projection matrix.
        /// </summary>
        /// <param name="left">Minimum x-value of the viewing volume.</param>
        /// <param name="right">Maximum x-value of the viewing volume.</param>
        /// <param name="bottom">Minimum y-value of the viewing volume.</param>
        /// <param name="top">Maximum y-value of the viewing volume.</param>
        /// <param name="znear">Minimum z-value of the viewing volume.</param>
        /// <param name="zfar">Maximum z-value of the viewing volume.</param>
        /// <param name="result">When the method completes, contains the created projection matrix.</param>
        public static void OrthoOffCenterLH(float left, float right, float bottom, float top, float znear, float zfar, out Matrix result)
        {
            float zRange = 1f / (zfar - znear);

            result = Matrix.Identity;
            result.M11 = 2f / (right - left);
            result.M22 = 2f / (top - bottom);
            result.M33 = zRange;
            result.M41 = (left + right) / (left - right);
            result.M42 = (top + bottom) / (bottom - top);
            result.M43 = -znear * zRange;
        }

        /// <summary>
        /// Creates a left-handed, customized orthographic projection matrix.
        /// </summary>
        /// <param name="left">Minimum x-value of the viewing volume.</param>
        /// <param name="right">Maximum x-value of the viewing volume.</param>
        /// <param name="bottom">Minimum y-value of the viewing volume.</param>
        /// <param name="top">Maximum y-value of the viewing volume.</param>
        /// <param name="znear">Minimum z-value of the viewing volume.</param>
        /// <param name="zfar">Maximum z-value of the viewing volume.</param>
        /// <returns>The created projection matrix.</returns>
        public static Matrix OrthoOffCenterLH(float left, float right, float bottom, float top, float znear, float zfar)
        {
            Matrix result;
            OrthoOffCenterLH(left, right, bottom, top, znear, zfar, out result);
            return result;
        }

        /// <summary>
        /// Creates a right-handed, customized orthographic projection matrix.
        /// </summary>
        /// <param name="left">Minimum x-value of the viewing volume.</param>
        /// <param name="right">Maximum x-value of the viewing volume.</param>
        /// <param name="bottom">Minimum y-value of the viewing volume.</param>
        /// <param name="top">Maximum y-value of the viewing volume.</param>
        /// <param name="znear">Minimum z-value of the viewing volume.</param>
        /// <param name="zfar">Maximum z-value of the viewing volume.</param>
        /// <param name="result">When the method completes, contains the created projection matrix.</param>
        public static void OrthoOffCenterRH(float left, float right, float bottom, float top, float znear, float zfar, out Matrix result)
        {
            OrthoOffCenterLH(left, right, bottom, top, znear, zfar, out result);
            result.M33 *= -1f;
        }

        /// <summary>
        /// Creates a right-handed, customized orthographic projection matrix.
        /// </summary>
        /// <param name="left">Minimum x-value of the viewing volume.</param>
        /// <param name="right">Maximum x-value of the viewing volume.</param>
        /// <param name="bottom">Minimum y-value of the viewing volume.</param>
        /// <param name="top">Maximum y-value of the viewing volume.</param>
        /// <param name="znear">Minimum z-value of the viewing volume.</param>
        /// <param name="zfar">Maximum z-value of the viewing volume.</param>
        /// <returns>The created projection matrix.</returns>
        public static Matrix OrthoOffCenterRH(float left, float right, float bottom, float top, float znear, float zfar)
        {
            Matrix result;
            OrthoOffCenterRH(left, right, bottom, top, znear, zfar, out result);
            return result;
        }

        /// <summary>
        /// Creates a left-handed, perspective projection matrix.
        /// </summary>
        /// <param name="width">Width of the viewing volume.</param>
        /// <param name="height">Height of the viewing volume.</param>
        /// <param name="znear">Minimum z-value of the viewing volume.</param>
        /// <param name="zfar">Maximum z-value of the viewing volume.</param>
        /// <param name="result">When the method completes, contains the created projection matrix.</param>
        public static void PerspectiveLH(float width, float height, float znear, float zfar, out Matrix result)
        {
            float halfWidth = width * 0.5f;
            float halfHeight = height * 0.5f;

            PerspectiveOffCenterLH(-halfWidth, halfWidth, -halfHeight, halfHeight, znear, zfar, out result);
        }

        /// <summary>
        /// Creates a left-handed, perspective projection matrix.
        /// </summary>
        /// <param name="width">Width of the viewing volume.</param>
        /// <param name="height">Height of the viewing volume.</param>
        /// <param name="znear">Minimum z-value of the viewing volume.</param>
        /// <param name="zfar">Maximum z-value of the viewing volume.</param>
        /// <returns>The created projection matrix.</returns>
        public static Matrix PerspectiveLH(float width, float height, float znear, float zfar)
        {
            Matrix result;
            PerspectiveLH(width, height, znear, zfar, out result);
            return result;
        }

        /// <summary>
        /// Creates a right-handed, perspective projection matrix.
        /// </summary>
        /// <param name="width">Width of the viewing volume.</param>
        /// <param name="height">Height of the viewing volume.</param>
        /// <param name="znear">Minimum z-value of the viewing volume.</param>
        /// <param name="zfar">Maximum z-value of the viewing volume.</param>
        /// <param name="result">When the method completes, contains the created projection matrix.</param>
        public static void PerspectiveRH(float width, float height, float znear, float zfar, out Matrix result)
        {
            float halfWidth = width * 0.5f;
            float halfHeight = height * 0.5f;

            PerspectiveOffCenterRH(-halfWidth, halfWidth, -halfHeight, halfHeight, znear, zfar, out result);
        }

        /// <summary>
        /// Creates a right-handed, perspective projection matrix.
        /// </summary>
        /// <param name="width">Width of the viewing volume.</param>
        /// <param name="height">Height of the viewing volume.</param>
        /// <param name="znear">Minimum z-value of the viewing volume.</param>
        /// <param name="zfar">Maximum z-value of the viewing volume.</param>
        /// <returns>The created projection matrix.</returns>
        public static Matrix PerspectiveRH(float width, float height, float znear, float zfar)
        {
            Matrix result;
            PerspectiveRH(width, height, znear, zfar, out result);
            return result;
        }

        /// <summary>
        /// Creates a left-handed, perspective projection matrix based on a field of view.
        /// </summary>
        /// <param name="fov">Field of view in the y direction, in radians.</param>
        /// <param name="aspect">Aspect ratio, defined as view space width divided by height.</param>
        /// <param name="znear">Minimum z-value of the viewing volume.</param>
        /// <param name="zfar">Maximum z-value of the viewing volume.</param>
        /// <param name="result">When the method completes, contains the created projection matrix.</param>
        public static void PerspectiveFovLH(float fov, float aspect, float znear, float zfar, out Matrix result)
        {
            float yScale = (1 / Mathematics.Tan(fov * 0.5f));
            float xScale = yScale / aspect;

            float halfWidth = znear / xScale;
            float halfHeight = znear / yScale;

            PerspectiveOffCenterLH(-halfWidth, halfWidth, -halfHeight, halfHeight, znear, zfar, out result);
        }

        /// <summary>
        /// Creates a left-handed, perspective projection matrix based on a field of view.
        /// </summary>
        /// <param name="fov">Field of view in the y direction, in radians.</param>
        /// <param name="aspect">Aspect ratio, defined as view space width divided by height.</param>
        /// <param name="znear">Minimum z-value of the viewing volume.</param>
        /// <param name="zfar">Maximum z-value of the viewing volume.</param>
        /// <returns>The created projection matrix.</returns>
        public static Matrix PerspectiveFovLH(float fov, float aspect, float znear, float zfar)
        {
            Matrix result;
            PerspectiveFovLH(fov, aspect, znear, zfar, out result);
            return result;
        }

        /// <summary>
        /// Creates a right-handed, perspective projection matrix based on a field of view.
        /// </summary>
        /// <param name="fov">Field of view in the y direction, in radians.</param>
        /// <param name="aspect">Aspect ratio, defined as view space width divided by height.</param>
        /// <param name="znear">Minimum z-value of the viewing volume.</param>
        /// <param name="zfar">Maximum z-value of the viewing volume.</param>
        /// <param name="result">When the method completes, contains the created projection matrix.</param>
        public static void PerspectiveFovRH(float fov, float aspect, float znear, float zfar, out Matrix result)
        {
            float yScale = (1 / Mathematics.Tan(fov * 0.5f));
            float xScale = yScale / aspect;

            float halfWidth = znear / xScale;
            float halfHeight = znear / yScale;

            PerspectiveOffCenterRH(-halfWidth, halfWidth, -halfHeight, halfHeight, znear, zfar, out result);
        }

        /// <summary>
        /// Creates a right-handed, perspective projection matrix based on a field of view.
        /// </summary>
        /// <param name="fov">Field of view in the y direction, in radians.</param>
        /// <param name="aspect">Aspect ratio, defined as view space width divided by height.</param>
        /// <param name="znear">Minimum z-value of the viewing volume.</param>
        /// <param name="zfar">Maximum z-value of the viewing volume.</param>
        /// <returns>The created projection matrix.</returns>
        public static Matrix PerspectiveFovRH(float fov, float aspect, float znear, float zfar)
        {
            Matrix result;
            PerspectiveFovRH(fov, aspect, znear, zfar, out result);
            return result;
        }

        /// <summary>
        /// Creates a left-handed, customized perspective projection matrix.
        /// </summary>
        /// <param name="left">Minimum x-value of the viewing volume.</param>
        /// <param name="right">Maximum x-value of the viewing volume.</param>
        /// <param name="bottom">Minimum y-value of the viewing volume.</param>
        /// <param name="top">Maximum y-value of the viewing volume.</param>
        /// <param name="znear">Minimum z-value of the viewing volume.</param>
        /// <param name="zfar">Maximum z-value of the viewing volume.</param>
        /// <param name="result">When the method completes, contains the created projection matrix.</param>
        public static void PerspectiveOffCenterLH(float left, float right, float bottom, float top, float znear, float zfar, out Matrix result)
        {
            float zRange = zfar / (zfar - znear);

            result = new Matrix();
            result.M11 = 2f * znear / (right - left);
            result.M22 = 2f * znear / (top - bottom);
            result.M31 = (left + right) / (left - right);
            result.M32 = (top + bottom) / (bottom - top);
            result.M33 = zRange;
            result.M34 = 1f;
            result.M43 = -znear * zRange;
        }

        /// <summary>
        /// Creates a left-handed, customized perspective projection matrix.
        /// </summary>
        /// <param name="left">Minimum x-value of the viewing volume.</param>
        /// <param name="right">Maximum x-value of the viewing volume.</param>
        /// <param name="bottom">Minimum y-value of the viewing volume.</param>
        /// <param name="top">Maximum y-value of the viewing volume.</param>
        /// <param name="znear">Minimum z-value of the viewing volume.</param>
        /// <param name="zfar">Maximum z-value of the viewing volume.</param>
        /// <returns>The created projection matrix.</returns>
        public static Matrix PerspectiveOffCenterLH(float left, float right, float bottom, float top, float znear, float zfar)
        {
            Matrix result;
            PerspectiveOffCenterLH(left, right, bottom, top, znear, zfar, out result);
            return result;
        }

        /// <summary>
        /// Creates a right-handed, customized perspective projection matrix.
        /// </summary>
        /// <param name="left">Minimum x-value of the viewing volume.</param>
        /// <param name="right">Maximum x-value of the viewing volume.</param>
        /// <param name="bottom">Minimum y-value of the viewing volume.</param>
        /// <param name="top">Maximum y-value of the viewing volume.</param>
        /// <param name="znear">Minimum z-value of the viewing volume.</param>
        /// <param name="zfar">Maximum z-value of the viewing volume.</param>
        /// <param name="result">When the method completes, contains the created projection matrix.</param>
        public static void PerspectiveOffCenterRH(float left, float right, float bottom, float top, float znear, float zfar, out Matrix result)
        {
            PerspectiveOffCenterLH(left, right, bottom, top, znear, zfar, out result);
            result.M31 *= -1f;
            result.M32 *= -1f;
            result.M33 *= -1f;
            result.M34 *= -1f;
        }

        /// <summary>
        /// Creates a right-handed, customized perspective projection matrix.
        /// </summary>
        /// <param name="left">Minimum x-value of the viewing volume.</param>
        /// <param name="right">Maximum x-value of the viewing volume.</param>
        /// <param name="bottom">Minimum y-value of the viewing volume.</param>
        /// <param name="top">Maximum y-value of the viewing volume.</param>
        /// <param name="znear">Minimum z-value of the viewing volume.</param>
        /// <param name="zfar">Maximum z-value of the viewing volume.</param>
        /// <returns>The created projection matrix.</returns>
        public static Matrix PerspectiveOffCenterRH(float left, float right, float bottom, float top, float znear, float zfar)
        {
            Matrix result;
            PerspectiveOffCenterRH(left, right, bottom, top, znear, zfar, out result);
            return result;
        }

        /// <summary>
        /// Creates a matrix that scales along the x-axis, y-axis, and y-axis.
        /// </summary>
        /// <param name="scale">Scaling factor for all three axes.</param>
        /// <param name="result">When the method completes, contains the created scaling matrix.</param>
        public static void Scaling(ref Vector3D scale, out Matrix result)
        {
            Scaling(scale.X, scale.Y, scale.Z, out result);
        }

        /// <summary>
        /// Creates a matrix that scales along the x-axis, y-axis, and y-axis.
        /// </summary>
        /// <param name="scale">Scaling factor for all three axes.</param>
        /// <returns>The created scaling matrix.</returns>
        public static Matrix Scaling(Vector3D scale)
        {
            Matrix result;
            Scaling(ref scale, out result);
            return result;
        }

        /// <summary>
        /// Creates a matrix that uniformally scales along all three axis.
        /// </summary>
        /// <param name="scale">The uniform scale that is applied along all axis.</param>
        /// <param name="result">When the method completes, contains the created scaling matrix.</param>
        public static void Scaling(float scale, out Matrix result)
        {
            result = Matrix.Identity;
            result.M11 = result.M22 = result.M33 = scale;
        }

        /// <summary>
        /// Creates a matrix that uniformally scales along all three axis.
        /// </summary>
        /// <param name="scale">The uniform scale that is applied along all axis.</param>
        /// <returns>The created scaling matrix.</returns>
        public static Matrix Scaling(float scale)
        {
            Matrix result;
            Scaling(scale, out result);
            return result;
        }

        /// <summary>
        /// Creates a matrix that scales along the x-axis, y-axis, and y-axis.
        /// </summary>
        /// <param name="x">Scaling factor that is applied along the x-axis.</param>
        /// <param name="y">Scaling factor that is applied along the y-axis.</param>
        /// <param name="z">Scaling factor that is applied along the z-axis.</param>
        /// <param name="result">When the method completes, contains the created scaling matrix.</param>
        public static void Scaling(float x, float y, float z, out Matrix result)
        {
            result = Matrix.Identity;
            result.M11 = x;
            result.M22 = y;
            result.M33 = z;
        }

        /// <summary>
        /// Creates a matrix that scales along the x-axis, y-axis, and y-axis.
        /// </summary>
        /// <param name="x">Scaling factor that is applied along the x-axis.</param>
        /// <param name="y">Scaling factor that is applied along the y-axis.</param>
        /// <param name="z">Scaling factor that is applied along the z-axis.</param>
        /// <returns>The created scaling matrix.</returns>
        public static Matrix Scaling(float x, float y, float z)
        {
            Matrix result;
            Scaling(x, y, z, out result);
            return result;
        }

        /// <summary>
        /// Creates a matrix that rotates around the x-axis.
        /// </summary>
        /// <param name="angle">Angle of rotation in radians. Angles are measured clockwise when looking along the rotation axis toward the origin.</param>
        /// <param name="result">When the method completes, contains the created rotation matrix.</param>
        public static void RotationX(float angle, out Matrix result)
        {
            float cos = Mathematics.Cos(angle);
            float sin = Mathematics.Sin(angle);

            result = Matrix.Identity;
            result.M22 = cos;
            result.M23 = sin;
            result.M32 = -sin;
            result.M33 = cos;
        }

        /// <summary>
        /// Creates a matrix that rotates around the x-axis.
        /// </summary>
        /// <param name="angle">Angle of rotation in radians. Angles are measured clockwise when looking along the rotation axis toward the origin.</param>
        /// <returns>The created rotation matrix.</returns>
        public static Matrix RotationX(float angle)
        {
            Matrix result;
            RotationX(angle, out result);
            return result;
        }

        /// <summary>
        /// Creates a matrix that rotates around the y-axis.
        /// </summary>
        /// <param name="angle">Angle of rotation in radians. Angles are measured clockwise when looking along the rotation axis toward the origin.</param>
        /// <param name="result">When the method completes, contains the created rotation matrix.</param>
        public static void RotationY(float angle, out Matrix result)
        {
            float cos = Mathematics.Cos(angle);
            float sin = Mathematics.Sin(angle);

            result = Matrix.Identity;
            result.M11 = cos;
            result.M13 = -sin;
            result.M31 = sin;
            result.M33 = cos;
        }

        /// <summary>
        /// Creates a matrix that rotates around the y-axis.
        /// </summary>
        /// <param name="angle">Angle of rotation in radians. Angles are measured clockwise when looking along the rotation axis toward the origin.</param>
        /// <returns>The created rotation matrix.</returns>
        public static Matrix RotationY(float angle)
        {
            Matrix result;
            RotationY(angle, out result);
            return result;
        }

        /// <summary>
        /// Creates a matrix that rotates around the z-axis.
        /// </summary>
        /// <param name="angle">Angle of rotation in radians. Angles are measured clockwise when looking along the rotation axis toward the origin.</param>
        /// <param name="result">When the method completes, contains the created rotation matrix.</param>
        public static void RotationZ(float angle, out Matrix result)
        {
            float cos = Mathematics.Cos(angle);
            float sin = Mathematics.Sin(angle);

            result = Matrix.Identity;
            result.M11 = cos;
            result.M12 = sin;
            result.M21 = -sin;
            result.M22 = cos;
        }

        /// <summary>
        /// Creates a matrix that rotates around the z-axis.
        /// </summary>
        /// <param name="angle">Angle of rotation in radians. Angles are measured clockwise when looking along the rotation axis toward the origin.</param>
        /// <returns>The created rotation matrix.</returns>
        public static Matrix RotationZ(float angle)
        {
            Matrix result;
            RotationZ(angle, out result);
            return result;
        }

        /// <summary>
        /// Creates a matrix that rotates around an arbitary axis.
        /// </summary>
        /// <param name="axis">The axis around which to rotate. This parameter is assumed to be normalized.</param>
        /// <param name="angle">Angle of rotation in radians. Angles are measured clockwise when looking along the rotation axis toward the origin.</param>
        /// <param name="result">When the method completes, contains the created rotation matrix.</param>
        public static void RotationAxis(ref Vector3D axis, float angle, out Matrix result)
        {
            float x = axis.X;
            float y = axis.Y;
            float z = axis.Z;
            float cos = Mathematics.Cos(angle);
            float sin = Mathematics.Sin(angle);
            float xx = x * x;
            float yy = y * y;
            float zz = z * z;
            float xy = x * y;
            float xz = x * z;
            float yz = y * z;

            result = Matrix.Identity;
            result.M11 = xx + (cos * (1f - xx));
            result.M12 = (xy - (cos * xy)) + (sin * z);
            result.M13 = (xz - (cos * xz)) - (sin * y);
            result.M21 = (xy - (cos * xy)) - (sin * z);
            result.M22 = yy + (cos * (1f - yy));
            result.M23 = (yz - (cos * yz)) + (sin * x);
            result.M31 = (xz - (cos * xz)) + (sin * y);
            result.M32 = (yz - (cos * yz)) - (sin * x);
            result.M33 = zz + (cos * (1f - zz));
        }

        /// <summary>
        /// Creates a matrix that rotates around an arbitary axis.
        /// </summary>
        /// <param name="axis">The axis around which to rotate. This parameter is assumed to be normalized.</param>
        /// <param name="angle">Angle of rotation in radians. Angles are measured clockwise when looking along the rotation axis toward the origin.</param>
        /// <returns>The created rotation matrix.</returns>
        public static Matrix RotationAxis(Vector3D axis, float angle)
        {
            Matrix result;
            RotationAxis(ref axis, angle, out result);
            return result;
        }

        /// <summary>
        /// Creates a rotation matrix from a quaternion.
        /// </summary>
        /// <param name="rotation">The quaternion to use to build the matrix.</param>
        /// <param name="result">The created rotation matrix.</param>
        public static void RotationQuaternion(ref Quaternion rotation, out Matrix result)
        {
            float xx = rotation.X * rotation.X;
            float yy = rotation.Y * rotation.Y;
            float zz = rotation.Z * rotation.Z;
            float xy = rotation.X * rotation.Y;
            float zw = rotation.Z * rotation.W;
            float zx = rotation.Z * rotation.X;
            float yw = rotation.Y * rotation.W;
            float yz = rotation.Y * rotation.Z;
            float xw = rotation.X * rotation.W;

            result = Matrix.Identity;
            result.M11 = 1f - (2f * (yy + zz));
            result.M12 = 2f * (xy + zw);
            result.M13 = 2f * (zx - yw);
            result.M21 = 2f * (xy - zw);
            result.M22 = 1f - (2f * (zz + xx));
            result.M23 = 2f * (yz + xw);
            result.M31 = 2f * (zx + yw);
            result.M32 = 2f * (yz - xw);
            result.M33 = 1f - (2f * (yy + xx));
        }

        /// <summary>
        /// Creates a rotation matrix from a quaternion.
        /// </summary>
        /// <param name="rotation">The quaternion to use to build the matrix.</param>
        /// <returns>The created rotation matrix.</returns>
        public static Matrix RotationQuaternion(Quaternion rotation)
        {
            Matrix result;
            RotationQuaternion(ref rotation, out result);
            return result;
        }

        /// <summary>
        /// Creates a rotation matrix with a specified yaw, pitch, and roll.
        /// </summary>
        /// <param name="yaw">Yaw around the y-axis, in radians.</param>
        /// <param name="pitch">Pitch around the x-axis, in radians.</param>
        /// <param name="roll">Roll around the z-axis, in radians.</param>
        /// <param name="result">When the method completes, contains the created rotation matrix.</param>
        public static void RotationYawPitchRoll(float yaw, float pitch, float roll, out Matrix result)
        {
            Quaternion quaternion = new Quaternion();
            Quaternion.RotationYawPitchRoll(yaw, pitch, roll, out quaternion);
            RotationQuaternion(ref quaternion, out result);
        }

        /// <summary>
        /// Creates a rotation matrix with a specified yaw, pitch, and roll.
        /// </summary>
        /// <param name="yaw">Yaw around the y-axis, in radians.</param>
        /// <param name="pitch">Pitch around the x-axis, in radians.</param>
        /// <param name="roll">Roll around the z-axis, in radians.</param>
        /// <returns>The created rotation matrix.</returns>
        public static Matrix RotationYawPitchRoll(float yaw, float pitch, float roll)
        {
            Matrix result;
            RotationYawPitchRoll(yaw, pitch, roll, out result);
            return result;
        }

        /// <summary>
        /// Creates a translation matrix using the specified offsets.
        /// </summary>
        /// <param name="value">The offset for all three coordinate planes.</param>
        /// <param name="result">When the method completes, contains the created translation matrix.</param>
        public static void Translation(ref Vector3D value, out Matrix result)
        {
            Translation(value.X, value.Y, value.Z, out result);
        }

        /// <summary>
        /// Creates a translation matrix using the specified offsets.
        /// </summary>
        /// <param name="value">The offset for all three coordinate planes.</param>
        /// <returns>The created translation matrix.</returns>
        public static Matrix Translation(Vector3D value)
        {
            Matrix result;
            Translation(ref value, out result);
            return result;
        }

        /// <summary>
        /// Creates a translation matrix using the specified offsets.
        /// </summary>
        /// <param name="x">X-coordinate offset.</param>
        /// <param name="y">Y-coordinate offset.</param>
        /// <param name="z">Z-coordinate offset.</param>
        /// <param name="result">When the method completes, contains the created translation matrix.</param>
        public static void Translation(float x, float y, float z, out Matrix result)
        {
            result = Matrix.Identity;
            result.M41 = x;
            result.M42 = y;
            result.M43 = z;
        }

        /// <summary>
        /// Creates a translation matrix using the specified offsets.
        /// </summary>
        /// <param name="x">X-coordinate offset.</param>
        /// <param name="y">Y-coordinate offset.</param>
        /// <param name="z">Z-coordinate offset.</param>
        /// <returns>The created translation matrix.</returns>
        public static Matrix Translation(float x, float y, float z)
        {
            Matrix result;
            Translation(x, y, z, out result);
            return result;
        }

        /// <summary>
        /// Creates a 3D affine transformation matrix.
        /// </summary>
        /// <param name="scaling">Scaling factor.</param>
        /// <param name="rotation">The rotation of the transformation.</param>
        /// <param name="translation">The translation factor of the transformation.</param>
        /// <param name="result">When the method completes, contains the created affine transformation matrix.</param>
        public static void AffineTransformation(float scaling, ref Quaternion rotation, ref Vector3D translation, out Matrix result)
        {
            result = Scaling(scaling) * RotationQuaternion(rotation) * Translation(translation);
        }

        /// <summary>
        /// Creates a 3D affine transformation matrix.
        /// </summary>
        /// <param name="scaling">Scaling factor.</param>
        /// <param name="rotation">The rotation of the transformation.</param>
        /// <param name="translation">The translation factor of the transformation.</param>
        /// <returns>The created affine transformation matrix.</returns>
        public static Matrix AffineTransformation(float scaling, Quaternion rotation, Vector3D translation)
        {
            Matrix result;
            AffineTransformation(scaling, ref rotation, ref translation, out result);
            return result;
        }

        /// <summary>
        /// Creates a 3D affine transformation matrix.
        /// </summary>
        /// <param name="scaling">Scaling factor.</param>
        /// <param name="rotationCenter">The center of the rotation.</param>
        /// <param name="rotation">The rotation of the transformation.</param>
        /// <param name="translation">The translation factor of the transformation.</param>
        /// <param name="result">When the method completes, contains the created affine transformation matrix.</param>
        public static void AffineTransformation(float scaling, ref Vector3D rotationCenter, ref Quaternion rotation, ref Vector3D translation, out Matrix result)
        {
            result = Scaling(scaling) * Translation(-rotationCenter) * RotationQuaternion(rotation) *
                Translation(rotationCenter) * Translation(translation);
        }

        /// <summary>
        /// Creates a 3D affine transformation matrix.
        /// </summary>
        /// <param name="scaling">Scaling factor.</param>
        /// <param name="rotationCenter">The center of the rotation.</param>
        /// <param name="rotation">The rotation of the transformation.</param>
        /// <param name="translation">The translation factor of the transformation.</param>
        /// <returns>The created affine transformation matrix.</returns>
        public static Matrix AffineTransformation(float scaling, Vector3D rotationCenter, Quaternion rotation, Vector3D translation)
        {
            Matrix result;
            AffineTransformation(scaling, ref rotationCenter, ref rotation, ref translation, out result);
            return result;
        }

        /// <summary>
        /// Creates a transformation matrix.
        /// </summary>
        /// <param name="scalingCenter">Center point of the scaling operation.</param>
        /// <param name="scalingRotation">Scaling rotation amount.</param>
        /// <param name="scaling">Scaling factor.</param>
        /// <param name="rotationCenter">The center of the rotation.</param>
        /// <param name="rotation">The rotation of the transformation.</param>
        /// <param name="translation">The translation factor of the transformation.</param>
        /// <param name="result">When the method completes, contains the created transformation matrix.</param>
        public static void Transformation(ref Vector3D scalingCenter, ref Quaternion scalingRotation, ref Vector3D scaling, ref Vector3D rotationCenter, ref Quaternion rotation, ref Vector3D translation, out Matrix result)
        {
            Matrix sr = RotationQuaternion(scalingRotation);

            result = Translation(-scalingCenter) * Transpose(sr) * Scaling(scaling) * sr * Translation(scalingCenter) * Translation(-rotationCenter) *
                RotationQuaternion(rotation) * Translation(rotationCenter) * Translation(translation);
        }

        /// <summary>
        /// Creates a transformation matrix.
        /// </summary>
        /// <param name="scalingCenter">Center point of the scaling operation.</param>
        /// <param name="scalingRotation">Scaling rotation amount.</param>
        /// <param name="scaling">Scaling factor.</param>
        /// <param name="rotationCenter">The center of the rotation.</param>
        /// <param name="rotation">The rotation of the transformation.</param>
        /// <param name="translation">The translation factor of the transformation.</param>
        /// <returns>The created transformation matrix.</returns>
        public static Matrix Transformation(Vector3D scalingCenter, Quaternion scalingRotation, Vector3D scaling, Vector3D rotationCenter, Quaternion rotation, Vector3D translation)
        {
            Matrix result;
            Transformation(ref scalingCenter, ref scalingRotation, ref scaling, ref rotationCenter, ref rotation, ref translation, out result);
            return result;
        }

        /// <summary>
        /// Adds two matricies
        /// </summary>
        /// <param name="value1">The first matrix to add</param>
        /// <param name="value2">The second matrix to add</param>
        /// <returns>The sum of the two matricies</returns>
        public static Matrix operator +(Matrix value1, Matrix value2)
        {
            return new Matrix(
                value1.M11 + value2.M11, value1.M12 + value2.M12, value1.M13 + value2.M13, value1.M14 + value2.M14,
                value1.M21 + value2.M21, value1.M22 + value2.M22, value1.M23 + value2.M23, value1.M24 + value2.M24,
                value1.M31 + value2.M31, value1.M32 + value2.M32, value1.M33 + value2.M33, value1.M34 + value2.M34,
                value1.M41 + value2.M41, value1.M42 + value2.M42, value1.M43 + value2.M43, value1.M44 + value2.M44
            );
        }

        /// <summary>
        /// Subtracts two matricies
        /// </summary>
        /// <param name="value1">The first matrix to subtract</param>
        /// <param name="value2">The second matrix to subtract</param>
        /// <returns>The difference between the two matricies</returns>
        public static Matrix operator -(Matrix value1, Matrix value2)
        {
            return new Matrix(
                value1.M11 - value2.M11, value1.M12 - value2.M12, value1.M13 - value2.M13, value1.M14 - value2.M14,
                value1.M21 - value2.M21, value1.M22 - value2.M22, value1.M23 - value2.M23, value1.M24 - value2.M24,
                value1.M31 - value2.M31, value1.M32 - value2.M32, value1.M33 - value2.M33, value1.M34 - value2.M34,
                value1.M41 - value2.M41, value1.M42 - value2.M42, value1.M43 - value2.M43, value1.M44 - value2.M44
            );
        }

        /// <summary>
        /// Negates a matrix.
        /// </summary>
        /// <param name="value">The matrix to negate</param>
        /// <returns>The negated matrix.</returns>
        public static Matrix operator -(Matrix value)
        {
            return new Matrix(-value.M11, -value.M12, -value.M13, -value.M14, -value.M21, -value.M22, -value.M23, -value.M24, -value.M31, -value.M32, -value.M33, -value.M34, -value.M41, -value.M42, -value.M43, -value.M44);
        }

        /// <summary>
        /// Scales a matrix by a given value
        /// </summary>
        /// <param name="value">The matrix to scale</param>
        /// <param name="scalar">The amount by which to scale</param>
        /// <returns>The scaled matrix</returns>
        public static Matrix operator *(float scalar, Matrix value)
        {
            return new Matrix(
                value.M11 * scalar, value.M12 * scalar, value.M13 * scalar, value.M14 * scalar,
                value.M21 * scalar, value.M22 * scalar, value.M23 * scalar, value.M24 * scalar,
                value.M31 * scalar, value.M32 * scalar, value.M33 * scalar, value.M34 * scalar,
                value.M41 * scalar, value.M42 * scalar, value.M43 * scalar, value.M44 * scalar
            );
        }

        /// <summary>
        /// Scales a matrix by a given value
        /// </summary>
        /// <param name="value">The matrix to scale</param>
        /// <param name="scalar">The amount by which to scale</param>
        /// <returns>The scaled matrix</returns>
        public static Matrix operator *(Matrix value, float scalar)
        {
            return new Matrix(
                value.M11 * scalar, value.M12 * scalar, value.M13 * scalar, value.M14 * scalar,
                value.M21 * scalar, value.M22 * scalar, value.M23 * scalar, value.M24 * scalar,
                value.M31 * scalar, value.M32 * scalar, value.M33 * scalar, value.M34 * scalar,
                value.M41 * scalar, value.M42 * scalar, value.M43 * scalar, value.M44 * scalar
            );
        }

        /// <summary>
        /// Multiplies two matricies
        /// </summary>
        /// <param name="value1">The first matrix to multiply</param>
        /// <param name="value2">The second matrix to multiply</param>
        /// <returns>The product of the two matricies</returns>
        public static Matrix operator *(Matrix value1, Matrix value2)
        {
            Matrix result;

            result.M11 = (value1.M11 * value2.M11) + (value1.M12 * value2.M21) + (value1.M13 * value2.M31) + (value1.M14 * value2.M41);
            result.M12 = (value1.M11 * value2.M12) + (value1.M12 * value2.M22) + (value1.M13 * value2.M32) + (value1.M14 * value2.M42);
            result.M13 = (value1.M11 * value2.M13) + (value1.M12 * value2.M23) + (value1.M13 * value2.M33) + (value1.M14 * value2.M43);
            result.M14 = (value1.M11 * value2.M14) + (value1.M12 * value2.M24) + (value1.M13 * value2.M34) + (value1.M14 * value2.M44);
            result.M21 = (value1.M21 * value2.M11) + (value1.M22 * value2.M21) + (value1.M23 * value2.M31) + (value1.M24 * value2.M41);
            result.M22 = (value1.M21 * value2.M12) + (value1.M22 * value2.M22) + (value1.M23 * value2.M32) + (value1.M24 * value2.M42);
            result.M23 = (value1.M21 * value2.M13) + (value1.M22 * value2.M23) + (value1.M23 * value2.M33) + (value1.M24 * value2.M43);
            result.M24 = (value1.M21 * value2.M14) + (value1.M22 * value2.M24) + (value1.M23 * value2.M34) + (value1.M24 * value2.M44);
            result.M31 = (value1.M31 * value2.M11) + (value1.M32 * value2.M21) + (value1.M33 * value2.M31) + (value1.M34 * value2.M41);
            result.M32 = (value1.M31 * value2.M12) + (value1.M32 * value2.M22) + (value1.M33 * value2.M32) + (value1.M34 * value2.M42);
            result.M33 = (value1.M31 * value2.M13) + (value1.M32 * value2.M23) + (value1.M33 * value2.M33) + (value1.M34 * value2.M43);
            result.M34 = (value1.M31 * value2.M14) + (value1.M32 * value2.M24) + (value1.M33 * value2.M34) + (value1.M34 * value2.M44);
            result.M41 = (value1.M41 * value2.M11) + (value1.M42 * value2.M21) + (value1.M43 * value2.M31) + (value1.M44 * value2.M41);
            result.M42 = (value1.M41 * value2.M12) + (value1.M42 * value2.M22) + (value1.M43 * value2.M32) + (value1.M44 * value2.M42);
            result.M43 = (value1.M41 * value2.M13) + (value1.M42 * value2.M23) + (value1.M43 * value2.M33) + (value1.M44 * value2.M43);
            result.M44 = (value1.M41 * value2.M14) + (value1.M42 * value2.M24) + (value1.M43 * value2.M34) + (value1.M44 * value2.M44);

            return result;
        }

        /// <summary>
        /// Scales a matrix by a given value
        /// </summary>
        /// <param name="value">The matrix to scale</param>
        /// <param name="scalar">The amount by which to scale</param>
        /// <returns>The scaled matrix.</returns>
        public static Matrix operator /(Matrix value, float scalar)
        {
            return new Matrix(
                value.M11 * (1f / scalar), value.M12 * (1f / scalar), value.M13 * (1f / scalar), value.M14 * (1f / scalar),
                value.M21 * (1f / scalar), value.M22 * (1f / scalar), value.M23 * (1f / scalar), value.M24 * (1f / scalar),
                value.M31 * (1f / scalar), value.M32 * (1f / scalar), value.M33 * (1f / scalar), value.M34 * (1f / scalar),
                value.M41 * (1f / scalar), value.M42 * (1f / scalar), value.M43 * (1f / scalar), value.M44 * (1f / scalar)
            );
        }

        /// <summary>
        /// Divides two matricies
        /// </summary>
        /// <param name="value1">The first matrix to divide</param>
        /// <param name="value2">The second matrix to divide</param>
        /// <returns>The quotient of the two matricies</returns>
        public static Matrix operator /(Matrix value1, Matrix value2)
        {
            return new Matrix(
                value1.M11 * value2.M11, value1.M12 * value2.M12, value1.M13 * value2.M13, value1.M14 * value2.M14,
                value1.M21 * value2.M21, value1.M22 * value2.M22, value1.M23 * value2.M23, value1.M24 * value2.M24,
                value1.M31 * value2.M31, value1.M32 * value2.M32, value1.M33 * value2.M33, value1.M34 * value2.M34,
                value1.M41 * value2.M41, value1.M42 * value2.M42, value1.M43 * value2.M43, value1.M44 * value2.M44
            );
        }

        /// <summary>
        /// Tests for equality between two objects
        /// </summary>
        /// <param name="value1">The first value to compare</param>
        /// <param name="value2">The second value to compare</param>
        /// <returns><c>true</c> if <paramref name="value1"/> has the same value as <paramref name="value2"/>; otherwise, <c>false</c></returns>
        public static bool operator ==(Matrix value1, Matrix value2) => value1.Equals(value2);

        /// <summary>
        /// Tests for inequality between two objects
        /// </summary>
        /// <param name="left">The first value to compare</param>
        /// <param name="right">The second value to compare</param>
        /// <returns><c>true</c> if <paramref name="left"/> has a different value than <paramref name="right"/>; otherwise, <c>false</c></returns>
        public static bool operator !=(Matrix value1, Matrix value2) => !value1.Equals(value2);

        /// <summary>
        /// Determines whether the specified object is equal to this instance
        /// </summary>
        /// <param name="obj">The object to compare with this instance</param>
        /// <returns>
        /// <c>true</c> if the specified object is equal to this instance; otherwise, <c>false</c>
        /// </returns>
        public override bool Equals(object obj) => (obj is Matrix) && Equals((Matrix)obj);

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "[M11:{0} M12:{1} M13:{2} M14:{3}] [M21:{4} M22:{5} M23:{6} M24:{7}] [M31:{8} M32:{9} M33:{10} M34:{11}] [M41:{12} M42:{13} M43:{14} M44:{15}]",
                M11, M12, M13, M14, M21, M22, M23, M24, M31, M32, M33, M34, M41, M42, M43, M44);
        }

        /// <summary>
        /// Returns a hash code for this instance
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table
        /// </returns>
        public override int GetHashCode()
        {
            return M11.GetHashCode() + M12.GetHashCode() + M13.GetHashCode() + M14.GetHashCode() +
                M21.GetHashCode() + M22.GetHashCode() + M23.GetHashCode() + M24.GetHashCode() +
                M31.GetHashCode() + M32.GetHashCode() + M33.GetHashCode() + M34.GetHashCode() +
                M41.GetHashCode() + M42.GetHashCode() + M43.GetHashCode() + M44.GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified matrix is equal to this instance
        /// </summary>
        /// <param name="other">The matrix to compare with this instance</param>
        /// <returns>
        /// <c>true</c> if the specified matrix is equal to this instance; otherwise, <c>false</c>
        /// </returns>
        public bool Equals(Matrix other)
        {
            return (M11.Equals(other.M11) && M12.Equals(other.M12) && M13.Equals(other.M13) && M14.Equals(other.M14) &&
                M21.Equals(other.M21) && M22.Equals(other.M22) && M23.Equals(other.M23) && M24.Equals(other.M24) &&
                M31.Equals(other.M31) && M32.Equals(other.M32) && M33.Equals(other.M33) && M34.Equals(other.M34) &&
                M41.Equals(other.M41) && M42.Equals(other.M42) && M43.Equals(other.M43) && M44.Equals(other.M44));
        }
    }
}