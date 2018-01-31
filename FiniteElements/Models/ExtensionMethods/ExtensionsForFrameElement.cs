using Bytes2you.Validation;
using FiniteElements.Models.Contracts;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Text;

namespace FiniteElements.Models.ExtensionMethods
{
    internal static class ExtensionsForFrameElement
    {
        public static void GenerateLocalMatrix(this IFrameElement element)
        {
            IMaterial materialProp = element.MaterialProp;
            IFrameSection sectionProp = element.SectionProp;

            Guard.WhenArgument(materialProp, "materialProp").IsNull().Throw();
            Guard.WhenArgument(sectionProp, "sectionProp").IsNull().Throw();

            double eModule = (materialProp != null) ? materialProp.EModule : 0.0;
            double gModule = (materialProp != null) ? materialProp.GModule : 0.0;
            double Area = (sectionProp != null) ? sectionProp.Area : 0.0;
            double momentY = (sectionProp != null) ? sectionProp.MomentOfInertiaY : 0.0;
            double mju = (sectionProp != null) ? sectionProp.Mju : 0.0;

            double elementLength = element.ElementLength;

            double Alfa = element.Alfa;
            double cosineAlfa = Math.Cos(Alfa);
            double sineAlfa = Math.Sin(Alfa);

            element.LocalMatrix = DenseMatrix.OfArray(new double[,]
                {     
                        //First row
                     {(eModule * Area)/elementLength, 0.0, 0.0, - (eModule * Area)/elementLength, 0.0, 0.0 },
                        //Second row
                     { 0.0, (12.0 * eModule * momentY * gModule * Area) / (gModule * Area * elementLength * elementLength * elementLength + mju * elementLength * 12.0 * eModule * momentY),
                (6.0 * eModule * momentY * gModule * Area) / (gModule * Area * elementLength * elementLength + mju * 12.0 * eModule * momentY), 0.0,
                - (12.0 * eModule * momentY * gModule * Area) / (gModule * Area * elementLength * elementLength * elementLength + mju * elementLength * 12.0 * eModule * momentY),
                (6.0 * eModule * momentY * gModule * Area) / (gModule * Area * elementLength * elementLength + mju * 12.0 * eModule * momentY)},
                        //Third row
                     {0.0, (6.0 * eModule * momentY * gModule * Area) / (gModule * Area * elementLength * elementLength + mju * 12.0 * eModule * momentY),
                ((4.0 * elementLength * eModule * momentY * gModule * Area) / ((elementLength * elementLength * gModule * Area) + 12.0 * mju * eModule * momentY)) +
                ((12.0 * mju * eModule * eModule * momentY * momentY) / (elementLength * elementLength * elementLength * gModule * Area + 12.0 * elementLength * mju * eModule * momentY)), 0.0,
                - (6.0 * eModule * momentY * gModule * Area) / (gModule * Area * elementLength * elementLength + mju * 12.0 * eModule * momentY),
                ((2.0 * elementLength * eModule * momentY * gModule * Area) / ((elementLength * elementLength * gModule * Area) + 12.0 * mju * eModule * momentY)) -
                ((12.0 * mju * eModule * eModule * momentY * momentY) / (elementLength * elementLength * elementLength * gModule * Area + 12.0 * elementLength * mju * eModule * momentY))},
                        //Fourth row
                     { - (eModule * Area)/elementLength, 0.0, 0.0, (eModule * Area)/elementLength, 0.0, 0.0  },
                        //Fifth row
                     { 0.0, - (12.0 * eModule * momentY * gModule * Area) / (gModule * Area * elementLength * elementLength * elementLength + mju * elementLength * 12.0 * eModule * momentY),
                - (6.0 * eModule * momentY * gModule * Area) / (gModule * Area * elementLength * elementLength + mju * 12.0 * eModule * momentY), 0.0,
                (12.0 * eModule * momentY * gModule * Area) / (gModule * Area * elementLength * elementLength * elementLength + mju * elementLength * 12.0 * eModule * momentY),
                - (6.0 * eModule * momentY * gModule * Area) / (gModule * Area * elementLength * elementLength + mju * 12.0 * eModule * momentY)},
                        //Sixth row
                     {0.0, (6.0 * eModule * momentY * gModule * Area) / (gModule * Area * elementLength * elementLength + mju * 12.0 * eModule * momentY),
                     ((2.0 * elementLength * eModule * momentY * gModule * Area) / ((elementLength * elementLength * gModule * Area) + 12.0 * mju * eModule * momentY)) -
                ((12.0 * mju * eModule * eModule * momentY * momentY) / (elementLength * elementLength * elementLength * gModule * Area + 12.0 * elementLength * mju * eModule * momentY)), 0.0,
                     - (6.0 * eModule * momentY * gModule * Area) / (gModule * Area * elementLength * elementLength + mju * 12.0 * eModule * momentY),
                     ((4.0 * elementLength * eModule * momentY * gModule * Area) / ((elementLength * elementLength * gModule * Area) + 12.0 * mju * eModule * momentY)) +
                ((12.0 * mju * eModule * eModule * momentY * momentY) / (elementLength * elementLength * elementLength * gModule * Area + 12.0 * elementLength * mju * eModule * momentY))}
                });
        }

        public static Matrix<double> GenerateGlobalMatrix(this IFrameElement element)
        {
            double alfa = element.Alfa;
            double cosineAlfa = Math.Cos(alfa);
            double sineAlfa = Math.Sin(alfa);

            Matrix<double> t = DenseMatrix.OfArray(new double[,]
                {
                //First row
                { cosineAlfa, sineAlfa, 0, 0, 0, 0 },
                //Second row
                {-sineAlfa, cosineAlfa, 0, 0, 0, 0 },
                //Third row
                {0, 0, 1, 0, 0, 0 },
                //Fourth row
                {0, 0, 0, cosineAlfa, sineAlfa, 0 },
                //Fifth row
                {0, 0, 0, -sineAlfa, cosineAlfa, 0 },
                //Sixth row
                {0, 0, 0, 0, 0, 1 }
                });

            return t.Transpose() * element.LocalMatrix * t;
        }

        public static Matrix<double> AddWinklerConstant(this IFrameElement element, double winklerConstant)
        {
            Guard.WhenArgument(winklerConstant, "winklerConstant").IsNaN().Throw();
            Guard.WhenArgument(winklerConstant, "winklerConstant").IsLessThan(0.0).Throw();

            double C = winklerConstant;
            double X1 = element.Node1.XCoord;
            double X2 = element.Node2.XCoord;
            double Y1 = element.Node1.YCoord;       
            double Y2 = element.Node2.YCoord;
            double elementLength = Math.Sqrt(Math.Pow(X1 - X2, 2) + Math.Pow(Y1 - Y2, 2));

            Matrix<double> winkler = DenseMatrix.OfArray(new double[,]
            {
                //First row
                {0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                //Second row
                {0.0, 156.0 * winklerConstant * elementLength / 420.0, 22.0 * elementLength * elementLength * winklerConstant / 420.0, 0.0, 54.0 * elementLength * winklerConstant / 420.0, - 13.0 * elementLength * elementLength * winklerConstant / 420 },
                //Third row
                {0.0, 22.0 * elementLength * elementLength * winklerConstant / 420.0, 4.0 * elementLength * elementLength *elementLength * winklerConstant / 420.0, 0.0, 13.0 * elementLength * elementLength * winklerConstant / 420.0, -3.0 * elementLength * elementLength * elementLength * winklerConstant / 420.0},
                //Fourth row
                {0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                //Fifth row
                {0.0, 54.0 * elementLength * winklerConstant / 420.0, 13.0 * elementLength * elementLength * winklerConstant / 420.0, 0.0, 156.0 * winklerConstant * elementLength / 420.0, - 22.0 * elementLength * elementLength * winklerConstant / 420.0 },
                //Sixth row
                {0.0, - 13.0 * elementLength * elementLength * winklerConstant / 420, -3.0 * elementLength * elementLength * elementLength * winklerConstant / 420.0, 0.0, -22.0 * elementLength * elementLength * winklerConstant / 420.0, 4.0 * elementLength * elementLength * elementLength * winklerConstant / 420.0}
            });

            return element.LocalMatrix + winkler;
        }

        public static void AddLoad(this IFrameElement element, ILoad load)
        {
            Guard.WhenArgument(load, "load").IsNull().Throw();
            element.Loads.Add(load);
        }

        public static string AsString(this IFrameElement element)
        {
            var result = new StringBuilder();
            string characters = "****";

            result.AppendLine($"Element ID: {element.Number}");
            result.AppendLine($"{element.SectionProp.AsString(characters)}");
            result.AppendLine($"{element.MaterialProp.AsString(characters)}");
            for (int i = 0; i < element.Loads.Count; i++)
            {
                result.AppendLine($"****Assigned Load: {i}");
                result.AppendLine($"{element.Loads[i].AsString(characters)}");
            }
            result.AppendLine("----");

            return result.ToString();
        }
    }
}
