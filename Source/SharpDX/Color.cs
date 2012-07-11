﻿// Copyright (c) 2010-2012 SharpDX - Alexandre Mutel
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
using System;
using System.Globalization;
using System.Runtime.InteropServices;

namespace SharpDX
{
    /// <summary>
    /// Represents a 32-bit color (4 bytes) in the form of argb.
    /// </summary>
#if !WIN8METRO
    [Serializable]
#endif
    [StructLayout(LayoutKind.Sequential, Size = 4)]
    public struct Color : IEquatable<Color>, IFormattable
    {
        /// <summary>
        /// The red component of the color.
        /// </summary>
        public byte Red;

        /// <summary>
        /// Gets or sets the red component of the color.
        /// </summary>
        public byte R { get { return Red; } set { Red = value; } }

        /// <summary>
        /// The green component of the color.
        /// </summary>
        public byte Green;

        /// <summary>
        /// Gets or sets the green component of the color.
        /// </summary>
        public byte G { get { return Green; } set { Green = value; } }

        /// <summary>
        /// The blue component of the color.
        /// </summary>
        public byte Blue;

        /// <summary>
        /// Gets or sets the blue component of the color.
        /// </summary>
        public byte B { get { return Blue; } set { Blue = value; } }

        /// <summary>
        /// The alpha component of the color.
        /// </summary>
        public byte Alpha;

        /// <summary>
        /// Gets or sets the alpha component of the color.
        /// </summary>
        public byte A { get { return Alpha; } set { Alpha = value; } }

        /// <summary>
        /// Initializes a new instance of the <see cref="SharpDX.Color"/> struct.
        /// </summary>
        /// <param name="value">The value that will be assigned to all components.</param>
        public Color(byte value)
        {
            Alpha = Red = Green = Blue = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SharpDX.Color"/> struct.
        /// </summary>
        /// <param name="value">The value that will be assigned to all components.</param>
        public Color(float value)
        {
            Alpha = Red = Green = Blue = ToByte(value);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SharpDX.Color"/> struct.
        /// </summary>
        /// <param name="red">The red component of the color.</param>
        /// <param name="green">The green component of the color.</param>
        /// <param name="blue">The blue component of the color.</param>
        /// <param name="alpha">The alpha component of the color.</param>
        public Color(byte red, byte green, byte blue, byte alpha)
        {
            Red = red;
            Green = green;
            Blue = blue;
            Alpha = alpha;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SharpDX.Color"/> struct.
        /// </summary>
        /// <param name="red">The red component of the color.</param>
        /// <param name="green">The green component of the color.</param>
        /// <param name="blue">The blue component of the color.</param>
        /// <param name="alpha">The alpha component of the color.</param>
        public Color(float red, float green, float blue, float alpha)
        {
            Red = ToByte(red);
            Green = ToByte(green);
            Blue = ToByte(blue);
            Alpha = ToByte(alpha);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SharpDX.Color"/> struct.
        /// </summary>
        /// <param name="value">The red, green, blue, and alpha components of the color.</param>
        public Color(Vector4 value)
        {
            Red = ToByte(value.X);
            Green = ToByte(value.Y);
            Blue = ToByte(value.Z);
            Alpha = ToByte(value.W);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SharpDX.Color"/> struct.
        /// </summary>
        /// <param name="value">The red, green, and blue compoennts of the color.</param>
        /// <param name="alpha">The alpha component of the color.</param>
        public Color(Vector3 value, float alpha)
        {
            Red = ToByte(value.X);
            Green = ToByte(value.Y);
            Blue = ToByte(value.Z);
            Alpha = ToByte(alpha);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SharpDX.Color"/> struct.
        /// </summary>
        /// <param name="argb">A packed integer containing all four color components.</param>
        public Color(uint argb)
        {
            Alpha = (byte)((argb >> 24) & 255);
            Red = (byte)((argb >> 16) & 255);
            Green = (byte)((argb >> 8) & 255);
            Blue = (byte)(argb & 255);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SharpDX.Color"/> struct.
        /// </summary>
        /// <param name="argb">A packed integer containing all four color components.</param>
        public Color(int argb)
        {
            Alpha = (byte)((argb >> 24) & 255);
            Red = (byte)((argb >> 16) & 255);
            Green = (byte)((argb >> 8) & 255);
            Blue = (byte)(argb & 255);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SharpDX.Color"/> struct.
        /// </summary>
        /// <param name="values">The values to assign to the alpha, red, green, and blue components of the color. This must be an array with four elements.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="values"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="values"/> contains more or less than four elements.</exception>
        public Color(float[] values)
        {
            if (values == null)
                throw new ArgumentNullException("values");
            if (values.Length != 4)
                throw new ArgumentOutOfRangeException("values", "There must be four and only four input values for Color.");

            Alpha = ToByte(values[0]);
            Red = ToByte(values[1]);
            Green = ToByte(values[2]);
            Blue = ToByte(values[3]);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SharpDX.Color"/> struct.
        /// </summary>
        /// <param name="values">The values to assign to the alpha, red, green, and blue components of the color. This must be an array with four elements.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="values"/> is <c>null</c>.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when <paramref name="values"/> contains more or less than four elements.</exception>
        public Color(byte[] values)
        {
            if (values == null)
                throw new ArgumentNullException("values");
            if (values.Length != 4)
                throw new ArgumentOutOfRangeException("values", "There must be four and only four input values for Color.");

            Alpha = values[0];
            Red = values[1];
            Green = values[2];
            Blue = values[3];
        }

        /// <summary>
        /// Gets or sets the component at the specified index.
        /// </summary>
        /// <value>The value of the alpha, red, green, or blue component, depending on the index.</value>
        /// <param name="index">The index of the component to access. Use 0 for the alpha component, 1 for the red component, 2 for the green component, and 3 for the blue component.</param>
        /// <returns>The value of the component at the specified index.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the <paramref name="index"/> is out of the range [0, 3].</exception>
        public float this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return Alpha / 255.0f;
                    case 1: return Red / 255.0f;
                    case 2: return Green / 255.0f;
                    case 3: return Blue / 255.0f;
                }

                throw new ArgumentOutOfRangeException("index", "Indices for Color run from 0 to 3, inclusive.");
            }

            set
            {
                switch (index)
                {
                    case 0: Alpha = ToByte(value); break;
                    case 1: Red = ToByte(value); break;
                    case 2: Green = ToByte(value); break;
                    case 3: Blue = ToByte(value); break;
                    default: throw new ArgumentOutOfRangeException("index", "Indices for Color run from 0 to 3, inclusive.");
                }
            }
        }

        /// <summary>
        /// Converts the color into a packed integer.
        /// </summary>
        /// <returns>A packed integer containing all four color components.</returns>
        public int ToArgb()
        {
            int value = Blue;
            value |= Green << 8;
            value |= Red << 16;
            value |= Alpha << 24;

            return (int)value;
        }

        /// <summary>
        /// Converts the color into a three component vector.
        /// </summary>
        /// <returns>A three component vector containing the red, green, and blue components of the color.</returns>
        public Vector3 ToVector3()
        {
            return new Vector3(Red / 255.0f, Green / 255.0f, Blue / 255.0f);
        }

        /// <summary>
        /// Converts the color into a four component vector.
        /// </summary>
        /// <returns>A four component vector containing all four color components.</returns>
        public Vector4 ToVector4()
        {
            return new Vector4(Red / 255.0f, Green / 255.0f, Blue / 255.0f, Alpha / 255.0f);
        }

        /// <summary>
        /// Creates an array containing the elements of the color.
        /// </summary>
        /// <returns>A four-element array containing the components of the color.</returns>
        public float[] ToArray()
        {
            return new float[] { Alpha / 255.0f, Red / 255.0f, Green / 255.0f, Blue / 255.0f };
        }

        /// <summary>
        /// Adds two colors.
        /// </summary>
        /// <param name="left">The first color to add.</param>
        /// <param name="right">The second color to add.</param>
        /// <param name="result">When the method completes, completes the sum of the two colors.</param>
        public static void Add(ref Color left, ref Color right, out Color result)
        {
            result.Alpha = (byte)(left.Alpha + right.Alpha);
            result.Red = (byte)(left.Red + right.Red);
            result.Green = (byte)(left.Green + right.Green);
            result.Blue = (byte)(left.Blue + right.Blue);
        }

        /// <summary>
        /// Adds two colors.
        /// </summary>
        /// <param name="left">The first color to add.</param>
        /// <param name="right">The second color to add.</param>
        /// <returns>The sum of the two colors.</returns>
        public static Color Add(Color left, Color right)
        {
            return new Color(left.Red + right.Red, left.Green + right.Green, left.Blue + right.Blue, left.Alpha + right.Alpha);
        }

        /// <summary>
        /// Subtracts two colors.
        /// </summary>
        /// <param name="left">The first color to subtract.</param>
        /// <param name="right">The second color to subtract.</param>
        /// <param name="result">WHen the method completes, contains the difference of the two colors.</param>
        public static void Subtract(ref Color left, ref Color right, out Color result)
        {
            result.Alpha = (byte)(left.Alpha - right.Alpha);
            result.Red = (byte)(left.Red - right.Red);
            result.Green = (byte)(left.Green - right.Green);
            result.Blue = (byte)(left.Blue - right.Blue);
        }

        /// <summary>
        /// Subtracts two colors.
        /// </summary>
        /// <param name="left">The first color to subtract.</param>
        /// <param name="right">The second color to subtract</param>
        /// <returns>The difference of the two colors.</returns>
        public static Color Subtract(Color left, Color right)
        {
            return new Color(left.Red - right.Red, left.Green - right.Green, left.Blue - right.Blue, left.Alpha - right.Alpha);
        }

        /// <summary>
        /// Modulates two colors.
        /// </summary>
        /// <param name="left">The first color to modulate.</param>
        /// <param name="right">The second color to modulate.</param>
        /// <param name="result">When the method completes, contains the modulated color.</param>
        public static void Modulate(ref Color left, ref Color right, out Color result)
        {
            result.Alpha = (byte)(left.Alpha * right.Alpha / 255.0f);
            result.Red = (byte)(left.Red * right.Red / 255.0f);
            result.Green = (byte)(left.Green * right.Green / 255.0f);
            result.Blue = (byte)(left.Blue * right.Blue / 255.0f);
        }

        /// <summary>
        /// Modulates two colors.
        /// </summary>
        /// <param name="left">The first color to modulate.</param>
        /// <param name="right">The second color to modulate.</param>
        /// <returns>The modulated color.</returns>
        public static Color Modulate(Color left, Color right)
        {
            return new Color(left.Red * right.Red, left.Green * right.Green, left.Blue * right.Blue, left.Alpha * right.Alpha);
        }

        /// <summary>
        /// Scales a color.
        /// </summary>
        /// <param name="value">The color to scale.</param>
        /// <param name="scale">The amount by which to scale.</param>
        /// <param name="result">When the method completes, contains the scaled color.</param>
        public static void Scale(ref Color value, float scale, out Color result)
        {
            result.Alpha = (byte)(value.Alpha * scale);
            result.Red = (byte)(value.Red * scale);
            result.Green = (byte)(value.Green * scale);
            result.Blue = (byte)(value.Blue * scale);
        }

        /// <summary>
        /// Scales a color.
        /// </summary>
        /// <param name="value">The color to scale.</param>
        /// <param name="scale">The amount by which to scale.</param>
        /// <returns>The scaled color.</returns>
        public static Color Scale(Color value, float scale)
        {
            return new Color(value.Red / 255.0f * scale, value.Green / 255.0f * scale, value.Blue / 255.0f * scale, value.Alpha / 255.0f * scale);
        }

        /// <summary>
        /// Negates a color.
        /// </summary>
        /// <param name="value">The color to negate.</param>
        /// <param name="result">When the method completes, contains the negated color.</param>
        public static void Negate(ref Color value, out Color result)
        {
            result.Alpha = (byte)(255 - value.Alpha);
            result.Red = (byte)(255 - value.Red);
            result.Green = (byte)(255 - value.Green);
            result.Blue = (byte)(255 - value.Blue);
        }

        /// <summary>
        /// Negates a color.
        /// </summary>
        /// <param name="value">The color to negate.</param>
        /// <returns>The negated color.</returns>
        public static Color Negate(Color value)
        {
            return new Color(1.0f - value.Red / 255.0f, 1.0f - value.Green / 255.0f, 1.0f - value.Blue / 255.0f, 1.0f - value.Alpha / 255.0f);
        }

        /// <summary>
        /// Restricts a value to be within a specified range.
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <param name="result">When the method completes, contains the clamped value.</param>
        public static void Clamp(ref Color value, ref Color min, ref Color max, out Color result)
        {
            byte alpha = value.Alpha;
            alpha = (alpha > max.Alpha) ? max.Alpha : alpha;
            alpha = (alpha < min.Alpha) ? min.Alpha : alpha;

            byte red = value.Red;
            red = (red > max.Red) ? max.Red : red;
            red = (red < min.Red) ? min.Red : red;

            byte green = value.Green;
            green = (green > max.Green) ? max.Green : green;
            green = (green < min.Green) ? min.Green : green;

            byte blue = value.Blue;
            blue = (blue > max.Blue) ? max.Blue : blue;
            blue = (blue < min.Blue) ? min.Blue : blue;

            result = new Color(red, green, blue, alpha);
        }

        /// <summary>
        /// Restricts a value to be within a specified range.
        /// </summary>
        /// <param name="value">The value to clamp.</param>
        /// <param name="min">The minimum value.</param>
        /// <param name="max">The maximum value.</param>
        /// <returns>The clamped value.</returns>
        public static Color Clamp(Color value, Color min, Color max)
        {
            Color result;
            Clamp(ref value, ref min, ref max, out result);
            return result;
        }

        /// <summary>
        /// Performs a linear interpolation between two colors.
        /// </summary>
        /// <param name="start">Start color.</param>
        /// <param name="end">End color.</param>
        /// <param name="amount">Value between 0 and 1 indicating the weight of <paramref name="end"/>.</param>
        /// <param name="result">When the method completes, contains the linear interpolation of the two colors.</param>
        /// <remarks>
        /// This method performs the linear interpolation based on the following formula.
        /// <code>start + (end - start) * amount</code>
        /// Passing <paramref name="amount"/> a value of 0 will cause <paramref name="start"/> to be returned; a value of 1 will cause <paramref name="end"/> to be returned. 
        /// </remarks>
        public static void Lerp(ref Color start, ref Color end, float amount, out Color result)
        {
            result.Alpha = (byte)(start.Alpha + amount * (end.Alpha - start.Alpha));
            result.Red = (byte)(start.Red + amount * (end.Red - start.Red));
            result.Green = (byte)(start.Green + amount * (end.Green - start.Green));
            result.Blue = (byte)(start.Blue + amount * (end.Blue - start.Blue));
        }

        /// <summary>
        /// Performs a linear interpolation between two colors.
        /// </summary>
        /// <param name="start">Start color.</param>
        /// <param name="end">End color.</param>
        /// <param name="amount">Value between 0 and 1 indicating the weight of <paramref name="end"/>.</param>
        /// <returns>The linear interpolation of the two colors.</returns>
        /// <remarks>
        /// This method performs the linear interpolation based on the following formula.
        /// <code>start + (end - start) * amount</code>
        /// Passing <paramref name="amount"/> a value of 0 will cause <paramref name="start"/> to be returned; a value of 1 will cause <paramref name="end"/> to be returned. 
        /// </remarks>
        public static Color Lerp(Color start, Color end, float amount)
        {
            return new Color(
                (byte)(start.Red + amount * (end.Red - start.Red)),
                (byte)(start.Green + amount * (end.Green - start.Green)),
                (byte)(start.Blue + amount * (end.Blue - start.Blue)),
                (byte)(start.Alpha + amount * (end.Alpha - start.Alpha)));
        }

        /// <summary>
        /// Performs a cubic interpolation between two colors.
        /// </summary>
        /// <param name="start">Start color.</param>
        /// <param name="end">End color.</param>
        /// <param name="amount">Value between 0 and 1 indicating the weight of <paramref name="end"/>.</param>
        /// <param name="result">When the method completes, contains the cubic interpolation of the two colors.</param>
        public static void SmoothStep(ref Color start, ref Color end, float amount, out Color result)
        {
            amount = (amount > 1.0f) ? 1.0f : ((amount < 0.0f) ? 0.0f : amount);
            amount = (amount * amount) * (3.0f - (2.0f * amount));

            result.Alpha = (byte)(start.Alpha + ((end.Alpha - start.Alpha) * amount));
            result.Red = (byte)(start.Red + ((end.Red - start.Red) * amount));
            result.Green = (byte)(start.Green + ((end.Green - start.Green) * amount));
            result.Blue = (byte)(start.Blue + ((end.Blue - start.Blue) * amount));
        }

        /// <summary>
        /// Performs a cubic interpolation between two colors.
        /// </summary>
        /// <param name="start">Start color.</param>
        /// <param name="end">End color.</param>
        /// <param name="amount">Value between 0 and 1 indicating the weight of <paramref name="end"/>.</param>
        /// <returns>The cubic interpolation of the two colors.</returns>
        public static Color SmoothStep(Color start, Color end, float amount)
        {
            amount = (amount > 1.0f) ? 1.0f : ((amount < 0.0f) ? 0.0f : amount);
            amount = (amount * amount) * (3.0f - (2.0f * amount));

            return new Color(                
                (byte)(start.Red + ((end.Red - start.Red) * amount)),
                (byte)(start.Green + ((end.Green - start.Green) * amount)),
                (byte)(start.Blue + ((end.Blue - start.Blue) * amount)),
                (byte)(start.Alpha + ((end.Alpha - start.Alpha) * amount)));
        }

        /// <summary>
        /// Returns a color containing the smallest components of the specified colorss.
        /// </summary>
        /// <param name="left">The first source color.</param>
        /// <param name="right">The second source color.</param>
        /// <param name="result">When the method completes, contains an new color composed of the largest components of the source colorss.</param>
        public static void Max(ref Color left, ref Color right, out Color result)
        {
            result.Alpha = (left.Alpha > right.Alpha) ? left.Alpha : right.Alpha;
            result.Red = (left.Red > right.Red) ? left.Red : right.Red;
            result.Green = (left.Green > right.Green) ? left.Green : right.Green;
            result.Blue = (left.Blue > right.Blue) ? left.Blue : right.Blue;
        }

        /// <summary>
        /// Returns a color containing the largest components of the specified colorss.
        /// </summary>
        /// <param name="left">The first source color.</param>
        /// <param name="right">The second source color.</param>
        /// <returns>A color containing the largest components of the source colors.</returns>
        public static Color Max(Color left, Color right)
        {
            Color result;
            Max(ref left, ref right, out result);
            return result;
        }

        /// <summary>
        /// Returns a color containing the smallest components of the specified colors.
        /// </summary>
        /// <param name="left">The first source color.</param>
        /// <param name="right">The second source color.</param>
        /// <param name="result">When the method completes, contains an new color composed of the smallest components of the source colors.</param>
        public static void Min(ref Color left, ref Color right, out Color result)
        {
            result.Alpha = (left.Alpha < right.Alpha) ? left.Alpha : right.Alpha;
            result.Red = (left.Red < right.Red) ? left.Red : right.Red;
            result.Green = (left.Green < right.Green) ? left.Green : right.Green;
            result.Blue = (left.Blue < right.Blue) ? left.Blue : right.Blue;
        }

        /// <summary>
        /// Returns a color containing the smallest components of the specified colors.
        /// </summary>
        /// <param name="left">The first source color.</param>
        /// <param name="right">The second source color.</param>
        /// <returns>A color containing the smallest components of the source colors.</returns>
        public static Color Min(Color left, Color right)
        {
            Color result;
            Min(ref left, ref right, out result);
            return result;
        }

        /// <summary>
        /// Adjusts the contrast of a color.
        /// </summary>
        /// <param name="value">The color whose contrast is to be adjusted.</param>
        /// <param name="contrast">The amount by which to adjust the contrast.</param>
        /// <param name="result">When the method completes, contains the adjusted color.</param>
        public static void AdjustContrast(ref Color value, float contrast, out Color result)
        {
            result.Alpha = value.Alpha;
            result.Red = ToByte(0.5f + contrast * (value.Red / 255.0f - 0.5f));
            result.Green = ToByte(0.5f + contrast * (value.Green / 255.0f - 0.5f));
            result.Blue = ToByte(0.5f + contrast * (value.Blue / 255.0f - 0.5f));
        }

        /// <summary>
        /// Adjusts the contrast of a color.
        /// </summary>
        /// <param name="value">The color whose contrast is to be adjusted.</param>
        /// <param name="contrast">The amount by which to adjust the contrast.</param>
        /// <returns>The adjusted color.</returns>
        public static Color AdjustContrast(Color value, float contrast)
        {
            return new Color(                
                ToByte(0.5f + contrast * (value.Red / 255.0f - 0.5f)),
                ToByte(0.5f + contrast * (value.Green / 255.0f - 0.5f)),
                ToByte(0.5f + contrast * (value.Blue / 255.0f- 0.5f)),
                value.Alpha);
        }

        /// <summary>
        /// Adjusts the saturation of a color.
        /// </summary>
        /// <param name="value">The color whose saturation is to be adjusted.</param>
        /// <param name="saturation">The amount by which to adjust the saturation.</param>
        /// <param name="result">When the method completes, contains the adjusted color.</param>
        public static void AdjustSaturation(ref Color value, float saturation, out Color result)
        {
            float grey = value.Red  / 255.0f * 0.2125f + value.Green / 255.0f * 0.7154f + value.Blue / 255.0f * 0.0721f;

            result.Alpha = value.Alpha;
            result.Red = ToByte(grey + saturation * (value.Red / 255.0f - grey));
            result.Green = ToByte(grey + saturation * (value.Green / 255.0f- grey));
            result.Blue = ToByte(grey + saturation * (value.Blue / 255.0f - grey));
        }

        /// <summary>
        /// Adjusts the saturation of a color.
        /// </summary>
        /// <param name="value">The color whose saturation is to be adjusted.</param>
        /// <param name="saturation">The amount by which to adjust the saturation.</param>
        /// <returns>The adjusted color.</returns>
        public static Color AdjustSaturation(Color value, float saturation)
        {
            float grey = value.Red / 255.0f * 0.2125f + value.Green / 255.0f * 0.7154f + value.Blue / 255.0f * 0.0721f;

            return new Color(                
                ToByte(grey + saturation * (value.Red / 255.0f - grey)),
                ToByte(grey + saturation * (value.Green / 255.0f - grey)),
                ToByte(grey + saturation * (value.Blue / 255.0f - grey)),
                value.Alpha);
        }

        /// <summary>
        /// Adds two colors.
        /// </summary>
        /// <param name="left">The first color to add.</param>
        /// <param name="right">The second color to add.</param>
        /// <returns>The sum of the two colors.</returns>
        public static Color operator +(Color left, Color right)
        {
            return new Color(left.Red + right.Red, left.Green + right.Green, left.Blue + right.Blue, left.Alpha + right.Alpha);
        }

        /// <summary>
        /// Assert a color (return it unchanged).
        /// </summary>
        /// <param name="value">The color to assert (unchange).</param>
        /// <returns>The asserted (unchanged) color.</returns>
        public static Color operator +(Color value)
        {
            return value;
        }

        /// <summary>
        /// Subtracts two colors.
        /// </summary>
        /// <param name="left">The first color to subtract.</param>
        /// <param name="right">The second color to subtract.</param>
        /// <returns>The difference of the two colors.</returns>
        public static Color operator -(Color left, Color right)
        {
            return new Color(left.Red - right.Red, left.Green - right.Green, left.Blue - right.Blue, left.Alpha - right.Alpha);
        }

        /// <summary>
        /// Negates a color.
        /// </summary>
        /// <param name="value">The color to negate.</param>
        /// <returns>A negated color.</returns>
        public static Color operator -(Color value)
        {
            return new Color(-value.Red, -value.Green, -value.Blue, -value.Alpha);
        }

        /// <summary>
        /// Scales a color.
        /// </summary>
        /// <param name="scale">The factor by which to scale the color.</param>
        /// <param name="value">The color to scale.</param>
        /// <returns>The scaled color.</returns>
        public static Color operator *(float scale, Color value)
        {
            return new Color((byte)(value.Red * scale), (byte)(value.Green * scale), (byte)(value.Blue * scale), (byte)(value.Alpha * scale));
        }

        /// <summary>
        /// Scales a color.
        /// </summary>
        /// <param name="value">The factor by which to scale the color.</param>
        /// <param name="scale">The color to scale.</param>
        /// <returns>The scaled color.</returns>
        public static Color operator *(Color value, float scale)
        {
            return new Color((byte)(value.Red * scale), (byte)(value.Green * scale), (byte)(value.Blue * scale), (byte)(value.Alpha * scale));
        }

        /// <summary>
        /// Modulates two colors.
        /// </summary>
        /// <param name="left">The first color to modulate.</param>
        /// <param name="right">The second color to modulate.</param>
        /// <returns>The modulated color.</returns>
        public static Color operator *(Color left, Color right)
        {
            return new Color((byte)(left.Red * right.Red / 255.0f), (byte)(left.Green * right.Green / 255.0f), (byte)(left.Blue * right.Blue / 255.0f), (byte)(left.Alpha * right.Alpha / 255.0f));
        }

        /// <summary>
        /// Tests for equality between two objects.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns><c>true</c> if <paramref name="left"/> has the same value as <paramref name="right"/>; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Color left, Color right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Tests for inequality between two objects.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">The second value to compare.</param>
        /// <returns><c>true</c> if <paramref name="left"/> has a different value than <paramref name="right"/>; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Color left, Color right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="SharpDX.Color"/> to <see cref="SharpDX.Color3"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator Color3(Color value)
        {
            return new Color3(value.Red, value.Green, value.Blue);
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="SharpDX.Color"/> to <see cref="SharpDX.Vector3"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator Vector3(Color value)
        {
            return new Vector3(value.Red / 255.0f, value.Green / 255.0f, value.Blue / 255.0f);
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="SharpDX.Color"/> to <see cref="SharpDX.Vector4"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator Vector4(Color value)
        {
            return new Vector4(value.Red / 255.0f, value.Green / 255.0f, value.Blue / 255.0f, value.Alpha / 255.0f);
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="SharpDX.Color"/> to <see cref="SharpDX.Color4"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator Color4(Color value)
        {
            return new Color4(value.Red/255.0f, value.Green/255.0f, value.Blue/255.0f, value.Alpha/255.0f);
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="SharpDX.Vector3"/> to <see cref="SharpDX.Color"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator Color(Vector3 value)
        {
            return new Color(value.X, value.Y, value.Z, 1.0f);
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="SharpDX.Vector4"/> to <see cref="SharpDX.Color"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator Color(Vector4 value)
        {
            return new Color(value.X, value.Y, value.Z, value.W);
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="SharpDX.Color4"/> to <see cref="SharpDX.Color"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Color(Color4 value)
        {
            return new Color(value.Red, value.Green, value.Blue, value.Alpha);
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="SharpDX.Color"/> to <see cref="System.Int32"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator int(Color value)
        {
            return value.ToArgb();
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.Int32"/> to <see cref="SharpDX.Color"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator Color(int value)
        {
            return new Color(value);
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format(CultureInfo.CurrentCulture, "Alpha:{0} Red:{1} Green:{2} Blue:{3}", Alpha, Red, Green, Blue);
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public string ToString(string format)
        {
            if (format == null)
                return ToString();

            return string.Format(CultureInfo.CurrentCulture, "Alpha:{0} Red:{1} Green:{2} Blue:{3}", Alpha.ToString(format, CultureInfo.CurrentCulture),
                Red.ToString(format, CultureInfo.CurrentCulture), Green.ToString(format, CultureInfo.CurrentCulture), Blue.ToString(format, CultureInfo.CurrentCulture));
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public string ToString(IFormatProvider formatProvider)
        {
            return string.Format(formatProvider, "Alpha:{0} Red:{1} Green:{2} Blue:{3}", Alpha, Red, Green, Blue);
        }

        /// <summary>
        /// Returns a <see cref="System.String"/> that represents this instance.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="formatProvider">The format provider.</param>
        /// <returns>
        /// A <see cref="System.String"/> that represents this instance.
        /// </returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (format == null)
                return ToString(formatProvider);

            return string.Format(formatProvider, "Alpha:{0} Red:{1} Green:{2} Blue:{3}", Alpha.ToString(format, formatProvider),
                Red.ToString(format, formatProvider), Green.ToString(format, formatProvider), Blue.ToString(format, formatProvider));
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return Alpha.GetHashCode() + Red.GetHashCode() + Green.GetHashCode() + Blue.GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified <see cref="SharpDX.Color"/> is equal to this instance.
        /// </summary>
        /// <param name="other">The <see cref="SharpDX.Color"/> to compare with this instance.</param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="SharpDX.Color"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public bool Equals(Color other)
        {
            return Alpha == other.Alpha && Red == other.Red && Green == other.Green && Blue == other.Blue;
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="value">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object value)
        {
            if (value == null)
                return false;

            if (!ReferenceEquals(value.GetType(), typeof(Color)))
                return false;

            return Equals((Color)value);
        }

#if WPFInterop
        /// <summary>
        /// Performs an explicit conversion from <see cref="SharpDX.Color"/> to <see cref="System.Windows.Media.Color"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator System.Windows.Media.Color(Color value)
        {
            return new System.Windows.Media.Color()
            {
                A = (byte)(255f * value.Alpha),
                R = (byte)(255f * value.Red),
                G = (byte)(255f * value.Green),
                B = (byte)(255f * value.Blue)
            };
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="System.Windows.Media.Color"/> to <see cref="SharpDX.Color"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static explicit operator Color(System.Windows.Media.Color value)
        {
            return new Color()
            {
                Alpha = (float)value.A / 255f,
                Red = (float)value.R / 255f,
                Green = (float)value.G / 255f,
                Blue = (float)value.B / 255f
            };
        }
#endif

#if WinFormsInterop
        /// <summary>
        /// Performs an explicit conversion from <see cref="SharpDX.Color"/> to <see cref="System.Drawing.Color"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator System.Drawing.Color(Color value)
        {
            return System.Drawing.Color.FromArgb(value.Alpha, value.Red, value.Green, value.Blue);
        }

        /// <summary>
        /// Performs an explicit conversion from <see cref="System.Drawing.Color"/> to <see cref="SharpDX.Color"/>.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>The result of the conversion.</returns>
        public static implicit operator Color(System.Drawing.Color value)
        {
            return new Color(value.R, value.G, value.B, value.A);
        }
#endif

        private static byte ToByte(float component)
        {
            var value = (int)(component * 255.0f);
            return (byte)(value < 0 ? 0 : value > 255 ? 255 : value);
        }
    }
}