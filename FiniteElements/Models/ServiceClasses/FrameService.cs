using Bytes2you.Validation;
using FiniteElements.Models.Contracts;
using MathNet.Numerics.LinearAlgebra;
using MathNet.Numerics.LinearAlgebra.Double;
using System;
using System.Text;

namespace FiniteElements.Models.ServiceClasses
{
    internal static class FrameService
    {
        public static Matrix<double> GenerateLocalMatrix(IFrameElement element)
        {
            Guard.WhenArgument(element, "element").IsNull().Throw();

            IMaterial materialProp = element.MaterialProp;
            IFrameSection sectionProp = element.SectionProp;

            Guard.WhenArgument(materialProp, "materialProp").IsNull().Throw();
            Guard.WhenArgument(sectionProp, "sectionProp").IsNull().Throw();

            double eModule = materialProp.EModule;
            double gModule = materialProp.GModule;
            double area = sectionProp.Area;
            double momentY = sectionProp.MomentOfInertiaY;
            double momentZ = sectionProp.MomentOfInertiaZ;
            double torsionX = sectionProp.TorsionalConstantX;
            double mju = sectionProp.Mju;

            double elementLength = element.ElementLength;

            double Alfa = element.Alfa;
            double cosineAlfa = Math.Cos(Alfa);
            double sineAlfa = Math.Sin(Alfa);

            double index11, index17, index22, index26, index28, index212, index33, index35, index39, index311,
            index44, index410, index55, index59, index511, index66, index68, index612, index77, index88,
            index812, index99, index911, index1010, index1111, index1212;

            //Check for invalid releases
            if ((element.ShearYReleaseNode1 == true && element.ShearYReleaseNode2 == true)
                || (element.ShearZReleaseNode1 == true && element.ShearZReleaseNode2 == true))
            {
                throw new ArgumentException("Invalid releases - you can not have shear releases at both ends in the same plane, the element is not stable.");
            }

            if ((element.MomentAroundZReleaseNode1 == true && element.MomentAroundZReleaseNode2 == true && (element.ShearYReleaseNode1 == true || element.ShearYReleaseNode2 == true))
                || (element.MomentAroundYReleaseNode1 == true && element.MomentAroundYReleaseNode2 == true && (element.ShearZReleaseNode1 == true || element.ShearZReleaseNode2 == true)))
            {
                throw new ArgumentException("Invalid releases - you can not have moment releases at both ends and a shear release at either end (in the same plane), the element is not stable.");
            }

            if (element.NormalReleaseNode1 == true && element.NormalReleaseNode2 == true)
            {
                throw new ArgumentException("Invalid releases - you can not have normal force releases at both ends, the element is not stable.");
            }

            if (element.TorsionReleaseNode1 == true && element.TorsionReleaseNode2 == true)
            {
                throw new ArgumentException("Invalid releases - you can not have torsion releases at both ends, the element is not stable.");
            }

            //Releases XY plane
            if (element.MomentAroundZReleaseNode1 == false && element.MomentAroundZReleaseNode2 == false
                && element.ShearYReleaseNode1 == false && element.ShearYReleaseNode2 == false)
            {
                index22 = (12.0 * eModule * momentZ * gModule * area) / (gModule * area * elementLength * elementLength * elementLength + mju * elementLength * 12.0 * eModule * momentZ);
                index26 = (6.0 * eModule * momentZ * gModule * area) / (gModule * area * elementLength * elementLength + mju * 12.0 * eModule * momentZ);
                index28 = (12.0 * eModule * momentZ * gModule * area) / (gModule * area * elementLength * elementLength * elementLength + mju * elementLength * 12.0 * eModule * momentZ);
                index212 = (6.0 * eModule * momentZ * gModule * area) / (gModule * area * elementLength * elementLength + mju * 12.0 * eModule * momentZ);

                index66 = ((4.0 * elementLength * eModule * momentZ * gModule * area) / (elementLength * elementLength * gModule * area + mju * 12.0 * eModule * momentZ))
                + ((12.0 * mju * eModule * eModule * momentZ * momentZ) / (elementLength * elementLength * elementLength * gModule * area + 12.0 * elementLength * mju * eModule * momentZ));
                index68 = (6.0 * eModule * momentZ * gModule * area) / (gModule * area * elementLength * elementLength + mju * 12.0 * eModule * momentZ);
                index612 = ((2.0 * elementLength * eModule * momentZ * gModule * area) / (elementLength * elementLength * gModule * area + 12.0 * mju * eModule * momentZ))
                    - ((12.0 * mju * eModule * eModule * momentZ * momentZ) / (elementLength * elementLength * elementLength * gModule * area + 12.0 * elementLength * mju * eModule * momentZ));

                index88 = (12.0 * eModule * momentZ * gModule * area) / (gModule * area * elementLength * elementLength * elementLength + mju * elementLength * 12.0 * eModule * momentZ);
                index812 = (6.0 * eModule * momentZ * gModule * area) / (gModule * area * elementLength * elementLength + mju * 12.0 * eModule * momentZ);

                index1212 = ((4.0 * elementLength * eModule * momentZ * gModule * area) / (elementLength * elementLength * gModule * area + mju * 12.0 * eModule * momentZ))
               + ((12.0 * mju * eModule * eModule * momentZ * momentZ) / (elementLength * elementLength * elementLength * gModule * area + 12.0 * elementLength * mju * eModule * momentZ));
            }

            else if (element.MomentAroundZReleaseNode1 == true && element.MomentAroundZReleaseNode2 == true
                && element.ShearYReleaseNode1 == false && element.ShearYReleaseNode2 == false)
            {
                index22 = double.Epsilon;
                index26 = 0.0;
                index28 = 0.0;
                index212 = 0.0;

                index66 = double.Epsilon;
                index68 = 0.0;
                index612 = 0.0;

                index88 = double.Epsilon;
                index812 = 0.0;

                index1212 = double.Epsilon;
            }

            else if (element.MomentAroundZReleaseNode1 == true && element.MomentAroundZReleaseNode2 == false
                && element.ShearYReleaseNode1 == false && element.ShearYReleaseNode2 == false)
            {
                index22 = (3.0 * eModule * momentZ * gModule * area) / (gModule * area * elementLength * elementLength * elementLength + mju * elementLength * 3.0 * eModule * momentZ);
                index26 = 0.0;
                index28 = (3.0 * eModule * momentZ * gModule * area) / (gModule * area * elementLength * elementLength * elementLength + mju * elementLength * 3.0 * eModule * momentZ);
                index212 = (3.0 * eModule * momentZ * gModule * area) / (gModule * area * elementLength * elementLength + mju * 3.0 * eModule * momentZ);

                index66 = double.Epsilon;
                index68 = 0.0;
                index612 = 0.0;

                index88 = (3.0 * eModule * momentZ * gModule * area) / (gModule * area * elementLength * elementLength * elementLength + mju * elementLength * 3.0 * eModule * momentZ);
                index812 = (3.0 * eModule * momentZ * gModule * area) / (gModule * area * elementLength * elementLength + mju * 3.0 * eModule * momentZ);

                index1212 = (3.0 * eModule * momentZ * gModule * area * elementLength) / (gModule * area * elementLength * elementLength + mju * 3.0 * eModule * momentZ);
            }

            else if (element.MomentAroundZReleaseNode1 == false && element.MomentAroundZReleaseNode2 == true
                && element.ShearYReleaseNode1 == false && element.ShearYReleaseNode2 == false)
            {
                index22 = (3.0 * eModule * momentZ * gModule * area) / (gModule * area * elementLength * elementLength * elementLength + mju * elementLength * 3.0 * eModule * momentZ);
                index26 = (3.0 * eModule * momentZ * gModule * area) / (gModule * area * elementLength * elementLength + mju * 3.0 * eModule * momentZ);
                index28 = (3.0 * eModule * momentZ * gModule * area) / (gModule * area * elementLength * elementLength * elementLength + mju * elementLength * 3.0 * eModule * momentZ);
                index212 = 0.0;

                index66 = (3.0 * eModule * momentZ * gModule * area * elementLength) / (gModule * area * elementLength * elementLength + mju * 3.0 * eModule * momentZ);
                index68 = (3.0 * eModule * momentZ * gModule * area) / (gModule * area * elementLength * elementLength + mju * 3.0 * eModule * momentZ);
                index612 = 0.0;

                index88 = (3.0 * eModule * momentZ * gModule * area) / (gModule * area * elementLength * elementLength * elementLength + mju * elementLength * 3.0 * eModule * momentZ);
                index812 = 0.0;

                index1212 = double.Epsilon;
            }

            else if (element.MomentAroundZReleaseNode1 == true && element.MomentAroundZReleaseNode2 == false
                && element.ShearYReleaseNode1 == true && element.ShearYReleaseNode2 == false)
            {
                index22 = double.Epsilon;
                index26 = 0.0;
                index28 = 0.0;
                index212 = 0.0;

                index66 = double.Epsilon;
                index68 = 0.0;
                index612 = 0.0;

                index88 = double.Epsilon;
                index812 = 0.0;

                index1212 = double.Epsilon;
            }

            else if (element.MomentAroundZReleaseNode1 == false && element.MomentAroundZReleaseNode2 == true
                && element.ShearYReleaseNode1 == false && element.ShearYReleaseNode2 == true)
            {
                index22 = double.Epsilon;
                index26 = 0.0;
                index28 = 0.0;
                index212 = 0.0;

                index66 = double.Epsilon;
                index68 = 0.0;
                index612 = 0.0;

                index88 = double.Epsilon;
                index812 = 0.0;

                index1212 = double.Epsilon;
            }

            else if (element.MomentAroundZReleaseNode1 == true && element.MomentAroundZReleaseNode2 == false
                && element.ShearYReleaseNode1 == false && element.ShearYReleaseNode2 == true)
            {
                index22 = double.Epsilon;
                index26 = 0.0;
                index28 = 0.0;
                index212 = 0.0;

                index66 = double.Epsilon;
                index68 = 0.0;
                index612 = 0.0;

                index88 = double.Epsilon;
                index812 = 0.0;

                index1212 = double.Epsilon;
            }

            else if (element.MomentAroundZReleaseNode1 == false && element.MomentAroundZReleaseNode2 == true
                && element.ShearYReleaseNode1 == true && element.ShearYReleaseNode2 == false)
            {
                index22 = double.Epsilon;
                index26 = 0.0;
                index28 = 0.0;
                index212 = 0.0;

                index66 = double.Epsilon;
                index68 = 0.0;
                index612 = 0.0;

                index88 = double.Epsilon;
                index812 = 0.0;

                index1212 = double.Epsilon;
            }

            else if (element.MomentAroundZReleaseNode1 == false && element.MomentAroundZReleaseNode2 == false
                && element.ShearYReleaseNode1 == true && element.ShearYReleaseNode2 == false)
            {
                index22 = double.Epsilon;
                index26 = 0.0;
                index28 = 0.0;
                index212 = 0.0;

                index66 = (eModule * momentZ) / elementLength;
                index68 = 0.0;
                index612 = (-1) * (eModule * momentZ) / elementLength;

                index88 = double.Epsilon;
                index812 = 0.0;

                index1212 = (eModule * momentZ) / elementLength;
            }

            else if (element.MomentAroundZReleaseNode1 == false && element.MomentAroundZReleaseNode2 == false
                && element.ShearYReleaseNode1 == false && element.ShearYReleaseNode2 == true)
            {
                index22 = double.Epsilon;
                index26 = 0.0;
                index28 = 0.0;
                index212 = 0.0;

                index66 = (eModule * momentZ) / elementLength;
                index68 = 0.0;
                index612 = (-1) * (eModule * momentZ) / elementLength;

                index88 = double.Epsilon;
                index812 = 0.0;

                index1212 = (eModule * momentZ) / elementLength;
            }

            else
            {
                index22 = double.NaN;
                index26 = double.NaN;
                index28 = double.NaN;
                index212 = double.NaN;

                index66 = double.NaN;
                index68 = double.NaN;
                index612 = double.NaN;

                index88 = double.NaN;
                index812 = double.NaN;

                index1212 = double.NaN;
            }

            //Releases XZ plane
            if (element.MomentAroundYReleaseNode1 == false && element.MomentAroundYReleaseNode2 == false
                && element.ShearZReleaseNode1 == false && element.ShearZReleaseNode2 == false)
            {
                index33 = (12.0 * eModule * momentY * gModule * area) / (gModule * area * elementLength * elementLength * elementLength + mju * elementLength * 12.0 * eModule * momentY);
                index35 = (6.0 * eModule * momentY * gModule * area) / (gModule * area * elementLength * elementLength + mju * 12.0 * eModule * momentY);
                index39 = (12.0 * eModule * momentY * gModule * area) / (gModule * area * elementLength * elementLength * elementLength + mju * elementLength * 12.0 * eModule * momentY);
                index311 = (6.0 * eModule * momentY * gModule * area) / (gModule * area * elementLength * elementLength + mju * 12.0 * eModule * momentY);

                index55 = ((4.0 * elementLength * eModule * momentY * gModule * area) / (elementLength * elementLength * gModule * area + mju * 12.0 * eModule * momentY))
               + ((12.0 * mju * eModule * eModule * momentY * momentY) / (elementLength * elementLength * elementLength * gModule * area + 12.0 * elementLength * mju * eModule * momentY));
                index59 = (6.0 * eModule * momentY * gModule * area) / (gModule * area * elementLength * elementLength + mju * 12.0 * eModule * momentY);
                index511 = ((2.0 * elementLength * eModule * momentY * gModule * area) / (elementLength * elementLength * gModule * area + 12.0 * mju * eModule * momentY))
                    - ((12.0 * mju * eModule * eModule * momentY * momentY) / (elementLength * elementLength * elementLength * gModule * area + 12.0 * elementLength * mju * eModule * momentY));

                index99 = (12.0 * eModule * momentY * gModule * area) / (gModule * area * elementLength * elementLength * elementLength + mju * elementLength * 12.0 * eModule * momentY);
                index911 = (6.0 * eModule * momentY * gModule * area) / (gModule * area * elementLength * elementLength + mju * 12.0 * eModule * momentY);

                index1111 = ((4.0 * elementLength * eModule * momentY * gModule * area) / (elementLength * elementLength * gModule * area + mju * 12.0 * eModule * momentY))
                + ((12.0 * mju * eModule * eModule * momentY * momentY) / (elementLength * elementLength * elementLength * gModule * area + 12.0 * elementLength * mju * eModule * momentY));
            }

            else if (element.MomentAroundYReleaseNode1 == true && element.MomentAroundYReleaseNode2 == true
                && element.ShearZReleaseNode1 == false && element.ShearZReleaseNode2 == false)
            {
                index33 = double.Epsilon;
                index35 = 0.0;
                index39 = 0.0;
                index311 = 0.0;

                index55 = double.Epsilon;
                index59 = 0.0;
                index511 = 0.0;

                index99 = double.Epsilon;
                index911 = 0.0;

                index1111 = double.Epsilon;
            }

            else if (element.MomentAroundYReleaseNode1 == true && element.MomentAroundYReleaseNode2 == false
                && element.ShearZReleaseNode1 == false && element.ShearZReleaseNode2 == false)
            {
                index33 = (3.0 * eModule * momentY * gModule * area) / (gModule * area * elementLength * elementLength * elementLength + mju * elementLength * 3.0 * eModule * momentY);
                index35 = 0.0;
                index39 = (3.0 * eModule * momentY * gModule * area) / (gModule * area * elementLength * elementLength * elementLength + mju * elementLength * 3.0 * eModule * momentY);
                index311 = (3.0 * eModule * momentY * gModule * area) / (gModule * area * elementLength * elementLength + mju * 3.0 * eModule * momentY);

                index55 = double.Epsilon;
                index59 = 0.0;
                index511 = 0.0;

                index99 = (3.0 * eModule * momentY * gModule * area) / (gModule * area * elementLength * elementLength * elementLength + mju * elementLength * 3.0 * eModule * momentY);
                index911 = (3.0 * eModule * momentY * gModule * area) / (gModule * area * elementLength * elementLength + mju * 3.0 * eModule * momentY);

                index1111 = (3.0 * eModule * momentY * gModule * area * elementLength) / (gModule * area * elementLength * elementLength + mju * 3.0 * eModule * momentY);
            }

            else if (element.MomentAroundYReleaseNode1 == false && element.MomentAroundYReleaseNode2 == true
                && element.ShearZReleaseNode1 == false && element.ShearZReleaseNode2 == false)
            {
                index33 = (3.0 * eModule * momentY * gModule * area) / (gModule * area * elementLength * elementLength * elementLength + mju * elementLength * 3.0 * eModule * momentY);
                index35 = (3.0 * eModule * momentY * gModule * area) / (gModule * area * elementLength * elementLength + mju * 3.0 * eModule * momentY);
                index39 = (3.0 * eModule * momentY * gModule * area) / (gModule * area * elementLength * elementLength * elementLength + mju * elementLength * 3.0 * eModule * momentY);
                index311 = 0.0;

                index55 = (3.0 * eModule * momentY * gModule * area * elementLength) / (gModule * area * elementLength * elementLength + mju * 3.0 * eModule * momentY);
                index59 = (3.0 * eModule * momentY * gModule * area) / (gModule * area * elementLength * elementLength + mju * 3.0 * eModule * momentY);
                index511 = 0.0;

                index99 = (3.0 * eModule * momentY * gModule * area) / (gModule * area * elementLength * elementLength * elementLength + mju * elementLength * 3.0 * eModule * momentY);
                index911 = 0.0;

                index1111 = double.Epsilon;
            }

            else if (element.MomentAroundYReleaseNode1 == true && element.MomentAroundYReleaseNode2 == false
                && element.ShearZReleaseNode1 == true && element.ShearZReleaseNode2 == false)
            {
                index33 = double.Epsilon;
                index35 = 0.0;
                index39 = 0.0;
                index311 = 0.0;

                index55 = double.Epsilon;
                index59 = 0.0;
                index511 = 0.0;

                index99 = double.Epsilon;
                index911 = 0.0;

                index1111 = double.Epsilon;
            }

            else if (element.MomentAroundYReleaseNode1 == false && element.MomentAroundYReleaseNode2 == true
                && element.ShearZReleaseNode1 == false && element.ShearZReleaseNode2 == true)
            {
                index33 = double.Epsilon;
                index35 = 0.0;
                index39 = 0.0;
                index311 = 0.0;

                index55 = double.Epsilon;
                index59 = 0.0;
                index511 = 0.0;

                index99 = double.Epsilon;
                index911 = 0.0;

                index1111 = double.Epsilon;
            }

            else if (element.MomentAroundYReleaseNode1 == true && element.MomentAroundYReleaseNode2 == false
                && element.ShearZReleaseNode1 == false && element.ShearZReleaseNode2 == true)
            {
                index33 = double.Epsilon;
                index35 = 0.0;
                index39 = 0.0;
                index311 = 0.0;

                index55 = double.Epsilon;
                index59 = 0.0;
                index511 = 0.0;

                index99 = double.Epsilon;
                index911 = 0.0;

                index1111 = double.Epsilon;
            }

            else if (element.MomentAroundYReleaseNode1 == false && element.MomentAroundYReleaseNode2 == true
                && element.ShearZReleaseNode1 == true && element.ShearZReleaseNode2 == false)
            {
                index33 = double.Epsilon;
                index35 = 0.0;
                index39 = 0.0;
                index311 = 0.0;

                index55 = double.Epsilon;
                index59 = 0.0;
                index511 = 0.0;

                index99 = double.Epsilon;
                index911 = 0.0;

                index1111 = double.Epsilon;
            }

            else if (element.MomentAroundYReleaseNode1 == false && element.MomentAroundYReleaseNode2 == false
                && element.ShearZReleaseNode1 == true && element.ShearZReleaseNode2 == false)
            {
                index33 = double.Epsilon;
                index35 = 0.0;
                index39 = 0.0;
                index311 = 0.0;

                index55 = (eModule * momentY) / elementLength;
                index59 = 0.0;
                index511 = (-1) * (eModule * momentY) / elementLength;

                index99 = double.Epsilon;
                index911 = 0.0;

                index1111 = (eModule * momentY) / elementLength;
            }

            else if (element.MomentAroundYReleaseNode1 == false && element.MomentAroundYReleaseNode2 == false
                && element.ShearZReleaseNode1 == false && element.ShearZReleaseNode2 == true)
            {
                index33 = double.Epsilon;
                index35 = 0.0;
                index39 = 0.0;
                index311 = 0.0;

                index55 = (eModule * momentY) / elementLength;
                index59 = 0.0;
                index511 = (-1) * (eModule * momentY) / elementLength;

                index99 = double.Epsilon;
                index911 = 0.0;

                index1111 = (eModule * momentY) / elementLength;
            }

            else
            {
                index33 = double.NaN;
                index35 = double.NaN;
                index39 = double.NaN;
                index311 = double.NaN;

                index55 = double.NaN;
                index59 = double.NaN;
                index511 = double.NaN;

                index99 = double.NaN;
                index911 = double.NaN;

                index1111 = double.NaN;
            }

            //Normal Releases
            if (element.NormalReleaseNode1 == false && element.NormalReleaseNode2 == false)
            {
                index11 = (eModule * area) / elementLength;
                index17 = (eModule * area) / elementLength;

                index77 = (eModule * area) / elementLength;
            }

            else if ((element.NormalReleaseNode1 == true && element.NormalReleaseNode2 == false)
                || (element.NormalReleaseNode1 == false && element.NormalReleaseNode2 == true))
            {
                index11 = double.Epsilon;
                index17 = 0.0;

                index77 = double.Epsilon;
            }

            else
            {
                index11 = double.NaN;
                index17 = double.NaN;

                index77 = double.NaN;
            }

            //Torsional Releases
            if (element.TorsionReleaseNode1 == false && element.TorsionReleaseNode2 == false)
            {
                index44 = (gModule * torsionX) / elementLength;
                index410 = (gModule * torsionX) / elementLength;

                index1010 = (gModule * torsionX) / elementLength;
            }

            else if ((element.TorsionReleaseNode1 == true && element.TorsionReleaseNode2 == false)
                || (element.TorsionReleaseNode1 == false && element.TorsionReleaseNode2 == true))
            {
                index44 = double.Epsilon;
                index410 = 0.0;

                index1010 = double.Epsilon;
            }

            else
            {
                index44 = double.NaN;
                index410 = double.NaN;

                index1010 = double.NaN;
            }

            Matrix<double> localMatrix = SparseMatrix.OfArray(new double[,]
                {     
                        //First row
                     { index11, 0.0, 0.0, 0.0, 0.0, 0.0, (-1) * index17, 0.0, 0.0, 0.0, 0.0, 0.0 },
                        //Second row
                     { 0.0, index22, 0.0, 0.0, 0.0, index26, 0.0, (-1) * index28, 0.0, 0.0, 0.0, index212 },
                        //Third row
                     { 0.0, 0.0, index33, 0.0, (-1) * index35, 0.0, 0.0, 0.0, (-1) * index39, 0.0, (-1) * index311, 0.0 },
                        //Fourth row
                     { 0.0, 0.0, 0.0, index44, 0.0, 0.0, 0.0, 0.0, 0.0, (-1) * index410, 0.0, 0.0 },
                        //Fifth row
                     { 0.0, 0.0, (-1) * index35, 0.0, index55, 0.0, 0.0, 0.0, index59, 0.0, index511, 0.0 },
                        //Sixth row
                     { 0.0, index26, 0.0, 0.0, 0.0, index66, 0.0, (-1) * index68, 0.0, 0.0, 0.0, index612 },
                        //Seventh row
                     { (-1) * index17, 0.0, 0.0, 0.0, 0.0, 0.0, index77, 0.0, 0.0, 0.0, 0.0, 0.0 },
                        //Eighth row
                     { 0.0, (-1) * index28, 0.0, 0.0, 0.0, (-1) * index68, 0.0, index88, 0.0, 0.0, 0.0, (-1) * index812 },
                        //Ninth row
                     { 0.0, 0.0, (-1) * index39, 0.0, index59, 0.0, 0.0, 0.0, index99, 0.0, index911, 0.0 },
                        //Tenth row
                     { 0.0, 0.0, 0.0, (-1) * index410, 0.0, 0.0, 0.0, 0.0, 0.0, index1010, 0.0, 0.0 },
                        //Eleventh row
                     { 0.0, 0.0, (-1) * index311, 0.0, index511, 0.0, 0.0, 0.0, index911, 0.0, index1111, 0.0 },
                        //Twelfth row
                     { 0.0, index212, 0.0, 0.0, 0.0, index612, 0.0, (-1) * index812, 0.0, 0.0, 0.0, index1212 }
                });

            return localMatrix;
        }

        public static Matrix<double> GenerateGlobalMatrix(IFrameElement element)
        {
            Guard.WhenArgument(element, "element").IsNull().Throw();
            return element.TransformationMatrix.Transpose() * element.LocalMatrix * element.TransformationMatrix;
        }

        public static Vector<double> InternalForces(IFrameElement element, Vector<double> globalDisplacementVector, int loadCaseNumber)
        {
            Vector<double> globalElementDisplacements = Vector<double>.Build.Sparse(12, 0.0);

            globalElementDisplacements[0] += globalDisplacementVector[element.Node1.Number + 0];
            globalElementDisplacements[1] += globalDisplacementVector[element.Node1.Number + 1];
            globalElementDisplacements[2] += globalDisplacementVector[element.Node1.Number + 2];
            globalElementDisplacements[3] += globalDisplacementVector[element.Node1.Number + 3];
            globalElementDisplacements[4] += globalDisplacementVector[element.Node1.Number + 4];
            globalElementDisplacements[5] += globalDisplacementVector[element.Node1.Number + 5];

            globalElementDisplacements[6] += globalDisplacementVector[element.Node2.Number + 0];
            globalElementDisplacements[7] += globalDisplacementVector[element.Node2.Number + 1];
            globalElementDisplacements[8] += globalDisplacementVector[element.Node2.Number + 2];
            globalElementDisplacements[9] += globalDisplacementVector[element.Node2.Number + 3];
            globalElementDisplacements[10] += globalDisplacementVector[element.Node2.Number + 4];
            globalElementDisplacements[11] += globalDisplacementVector[element.Node2.Number + 5];

            return element.TransformationMatrix * globalElementDisplacements - element.GeneratedLocalLoadVectors[loadCaseNumber];
        }

        public static Matrix<double> AddWinklerConstant(IFrameElement element, double winklerConstant)
        {
            Guard.WhenArgument(winklerConstant, "winklerConstant").IsNaN().Throw();
            Guard.WhenArgument(winklerConstant, "winklerConstant").IsLessThan(0.0).Throw();

            double C = winklerConstant;
            double X1 = element.Node1.XCoord;
            double X2 = element.Node2.XCoord;
            double Y1 = element.Node1.YCoord;
            double Y2 = element.Node2.YCoord;
            double elementLength = Math.Sqrt(Math.Pow(X1 - X2, 2) + Math.Pow(Y1 - Y2, 2));
            //Should be fixed at some point!!!
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

        public static Vector<double> InclinedLoadVector(IFrameElement element, Vector<double> load)
        {
            //double l = (element.Node2.XCoord - element.Node1.XCoord) / element.ElementLength;
            //double m = (element.Node2.YCoord - element.Node1.YCoord) / element.ElementLength;
            //double n = (element.Node2.ZCoord - element.Node1.ZCoord) / element.ElementLength;
            //double d = Math.Sqrt(l * l + m * m);

            //double xP;
            //double yP;
            //double zP;

            //if (element.Node2.XCoord - element.Node1.XCoord == 0 && element.Node2.YCoord - element.Node1.YCoord == 0)
            //{
            //    xP = element.Node1.XCoord + 1.0;
            //    yP = element.Node1.YCoord;
            //    zP = element.Node1.ZCoord;
            //}

            //else
            //{
            //    xP = element.Node1.XCoord;
            //    yP = element.Node1.YCoord;
            //    zP = element.Node1.ZCoord + 1.0;
            //}

            //double pY;
            //double pZ;

            //if (l == 0 && m == 0)
            //{
            //    pY = (yP - element.Node1.YCoord);

            //    pZ = (-1) * n * (xP - element.Node1.XCoord);
            //}

            //else
            //{
            //    pY = (-1.0) * m * (xP - element.Node1.XCoord) / d + l * (yP - element.Node1.YCoord) / d;

            //    pZ = (-1.0) * l * n * (xP - element.Node1.XCoord) / d + d * (zP - element.Node1.ZCoord)
            //   - m * n * (yP - element.Node1.YCoord) / d;
            //}

            //double p = Math.Sqrt(pY * pY + pZ * pZ);

            //double alfa = element.Alfa + Math.Acos(pY / p); ;

            //double cosineAlfa = Math.Cos(alfa);
            //double sineAlfa = Math.Sin(alfa);

            //double b1 = ((-1.0) * (l * n * sineAlfa) / d - (m * cosineAlfa) / d);
            //double b2 = ((l * cosineAlfa) / d - (n * m * sineAlfa) / d);
            //double b3 = d * sineAlfa;

            //double a1 = ((-1) * (l * n * cosineAlfa) / d + (m * sineAlfa) / d);
            //double a2 = ((-1) * (l * sineAlfa) / d - (n * m * cosineAlfa) / d);
            //double a3 = d * cosineAlfa;

            //Matrix<double> t;

            //if (element.Node2.XCoord - element.Node1.XCoord == 0 && element.Node2.YCoord - element.Node1.YCoord == 0)
            //{
            //    t = SparseMatrix.OfArray(new double[,]
            //    {
            //        //First row
            //        { 0.0, 0.0, n },
            //        //Second row
            //        { (-1.0) * n * sineAlfa, cosineAlfa, 0.0 },
            //        //Third row
            //        { (-1.0) * n * cosineAlfa, (-1.0) * sineAlfa, 0.0 },
            //    });
            //}

            //else
            //{
            //    t = SparseMatrix.OfArray(new double[,]
            //    {
            //        //First row
            //        { l, m, n},
            //        //Second row
            //        { b1, b2, b3},
            //        //Third row
            //        { a1, a2, a3}
            //    });
            //}
            Guard.WhenArgument(element, "element").IsNull().Throw();
            Guard.WhenArgument(load, "load").IsNull().Throw();

            double l = (element.Node2.XCoord - element.Node1.XCoord) / element.ElementLength;
            double m = (element.Node2.YCoord - element.Node1.YCoord) / element.ElementLength;
            double n = (element.Node2.ZCoord - element.Node1.ZCoord) / element.ElementLength;
            double d = Math.Sqrt(l * l + m * m);

            double xP;
            double yP;
            double zP;

            if (element.Node2.XCoord - element.Node1.XCoord == 0 && element.Node2.YCoord - element.Node1.YCoord == 0)
            {
                xP = element.Node1.XCoord + 1.0;
                yP = element.Node1.YCoord;
                zP = element.Node1.ZCoord;
            }

            else
            {
                xP = element.Node1.XCoord;
                yP = element.Node1.YCoord;
                zP = element.Node1.ZCoord + 1.0;
            }

            double pY;
            double pZ;

            if (l == 0 && m == 0)
            {
                pY = n * (xP - element.Node1.XCoord);

                pZ = (yP - element.Node1.YCoord);
            }

            else
            {
                pY = (-1.0) * l * n * (xP - element.Node1.XCoord) / d + d * (zP - element.Node1.ZCoord)
               - m * n * (yP - element.Node1.YCoord) / d;

                pZ = m * (xP - element.Node1.XCoord) / d - l * (yP - element.Node1.YCoord) / d;
            }

            double p = Math.Sqrt(pY * pY + pZ * pZ);

            double alfa = element.Alfa + Math.Acos(pY / p); ;

            double cosineAlfa = Math.Cos(alfa);
            double sineAlfa = Math.Sin(alfa);

            double b1 = ((-1.0) * (l * n * cosineAlfa) / d + (m * sineAlfa) / d);
            double b2 = ((-1) * (l * sineAlfa) / d - (n * m * cosineAlfa) / d);
            double b3 = d * cosineAlfa;

            double a1 = ((l * n * sineAlfa) / d + (m * cosineAlfa) / d);
            double a2 = ((-1) * (l * cosineAlfa) / d + (n * m * sineAlfa) / d);
            double a3 = (-1) * d * sineAlfa;

            Matrix<double> t;

            if (element.Node2.XCoord - element.Node1.XCoord == 0 && element.Node2.YCoord - element.Node1.YCoord == 0)
            {
                t = SparseMatrix.OfArray(new double[,]
                {
                    //First row
                    { 0.0, 0.0, n },
                    //Second row
                    { n * cosineAlfa, sineAlfa, 0.0 },
                    //Third row
                    { (-1.0) * n * sineAlfa, cosineAlfa, 0.0 }
                });
            }

            else
            {
                t = SparseMatrix.OfArray(new double[,]
                {
                    //First row
                    { l, m, n},
                    //Second row
                    { b1, b2, b3 },
                    //Third row
                    { a1, a2, a3 }
                });
            }

            Vector<double> result = t * load;
            return result;
        }

        public static void AddLoad(IFrameElement element, IFrameLoad load)
        {
            Guard.WhenArgument(element, "element").IsNull().Throw();
            Guard.WhenArgument(load, "load").IsNull().Throw();
            element.Loads.Add(load);

            if (!element.GeneratedLocalLoadVectors.ContainsKey(load.LoadCase.Number))
            {
                element.GeneratedLocalLoadVectors.Add(load.LoadCase.Number, load.GenerateLoad());
            }

            else
            {
                element.GeneratedLocalLoadVectors[load.LoadCase.Number] += load.GenerateLoad();
            }
        }

        public static Matrix<double> TransformationMatrix(IFrameElement element)
        {
            Guard.WhenArgument(element, "element").IsNull().Throw();

            double l = (element.Node2.XCoord - element.Node1.XCoord) / element.ElementLength;
            double m = (element.Node2.YCoord - element.Node1.YCoord) / element.ElementLength;
            double n = (element.Node2.ZCoord - element.Node1.ZCoord) / element.ElementLength;
            double d = Math.Sqrt(l * l + m * m);

            double xP;
            double yP;
            double zP;

            if (element.Node2.XCoord - element.Node1.XCoord == 0 && element.Node2.YCoord - element.Node1.YCoord == 0)
            {
                xP = element.Node1.XCoord + 1.0;
                yP = element.Node1.YCoord;
                zP = element.Node1.ZCoord;
            }

            else
            {
                xP = element.Node1.XCoord;
                yP = element.Node1.YCoord;
                zP = element.Node1.ZCoord + 1.0;
            }

            double pY;
            double pZ;

            if (l == 0 && m == 0)
            {
                pY = n * (xP - element.Node1.XCoord);

                pZ = (yP - element.Node1.YCoord);
            }

            else
            {
                pY = (-1.0) * l * n * (xP - element.Node1.XCoord) / d + d * (zP - element.Node1.ZCoord)
               - m * n * (yP - element.Node1.YCoord) / d;

                pZ = m * (xP - element.Node1.XCoord) / d - l * (yP - element.Node1.YCoord) / d;
            }

            double p = Math.Sqrt(pY * pY + pZ * pZ);

            double alfa = element.Alfa + Math.Acos(pY / p); ;

            double cosineAlfa = Math.Cos(alfa);
            double sineAlfa = Math.Sin(alfa);

            double b1 = ((-1.0) * (l * n * cosineAlfa) / d + (m * sineAlfa) / d);
            double b2 = ((-1) * (l * sineAlfa) / d - (n * m * cosineAlfa) / d);
            double b3 = d * cosineAlfa;

            double a1 = ((l * n * sineAlfa) / d + (m * cosineAlfa) / d);
            double a2 = ((-1) * (l * cosineAlfa) / d + (n * m * sineAlfa) / d);
            double a3 = (-1) * d * sineAlfa;

            Matrix<double> t;

            if (element.Node2.XCoord - element.Node1.XCoord == 0 && element.Node2.YCoord - element.Node1.YCoord == 0)
            {
                t = SparseMatrix.OfArray(new double[,]
                {
                    //First row
                    { 0.0, 0.0, n, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    //Second row
                    { n * cosineAlfa, sineAlfa, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    //Third row
                    { (-1.0) * n * sineAlfa, cosineAlfa, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    //Fourth row
                    { 0.0, 0.0, 0.0, 0.0, 0.0, n, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    //Fifth row
                    { 0.0, 0.0, 0.0, n * cosineAlfa, sineAlfa, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    //Sixth row
                    { 0.0, 0.0, 0.0, (-1.0) * n * sineAlfa, cosineAlfa, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    //Seventh row
                    { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, n, 0.0, 0.0, 0.0 },
                    //Eighth row
                    { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, n * cosineAlfa, sineAlfa, 0.0, 0.0, 0.0, 0.0 },
                    //Ninth row
                    { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, (-1.0) * n * sineAlfa, cosineAlfa, 0.0, 0.0, 0.0, 0.0 },
                    //Tenth row
                    { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, n },
                    //Eleventh row
                    { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, n * cosineAlfa, sineAlfa, 0.0 },
                    //Twelfth row
                    { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, (-1.0) * n * sineAlfa, cosineAlfa, 0.0 }
                });
            }

            else
            {
                t = SparseMatrix.OfArray(new double[,]
                {
                    //First row
                    { l, m, n, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0},
                    //Second row
                    { b1, b2, b3, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    //Third row
                    { a1, a2, a3, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    //Fourth row
                    { 0.0, 0.0, 0.0, l, m, n, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    //Fifth row
                    { 0.0, 0.0, 0.0, b1, b2, b3, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    //Sixth row
                    { 0.0, 0.0, 0.0, a1, a2, a3, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 },
                    //Seventh row
                    { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, l, m, n, 0.0, 0.0, 0.0 },
                    //Eighth row
                    { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, b1, b2, b3, 0.0, 0.0, 0.0 },
                    //Ninth row
                    { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, a1, a2, a3, 0.0, 0.0, 0.0 },
                    //Tenth row
                    { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, l, m, n },
                    //Eleventh row
                    { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, b1, b2, b3 },
                    //Twelfth row
                    { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, a1, a2, a3 }
                });
            }

            return t;
        }

        public static string AsString(IFrameElement element)
        {
            Guard.WhenArgument(element, "element").IsNull().Throw();

            var result = new StringBuilder();
            string characters = "****";

            result.AppendLine($"Element ID: {element.Number}");
            result.AppendLine($"Releases:");
            result.AppendLine($"My: Node1 {element.MomentAroundYReleaseNode1}; Node2 {element.MomentAroundYReleaseNode2}");
            result.AppendLine($"Mz: Node1 {element.MomentAroundZReleaseNode1}; Node2 {element.MomentAroundZReleaseNode2}");
            result.AppendLine($"Mt: Node1 {element.TorsionReleaseNode1}; Node2 {element.TorsionReleaseNode2}");
            result.AppendLine($"Fxy: Node1 {element.ShearYReleaseNode1}; Node2 {element.ShearYReleaseNode2}");
            result.AppendLine($"Fxz: Node1 {element.ShearZReleaseNode1}; Node2 {element.ShearZReleaseNode2}");
            result.AppendLine($"Fn: Node1 {element.NormalReleaseNode1}; Node2 {element.NormalReleaseNode2}");
            result.AppendLine($"{SectionService.AsString(element.SectionProp, characters)}");
            result.AppendLine($"{MaterialService.AsString(element.MaterialProp, characters)}");
            for (int i = 0; i < element.Loads.Count; i++)
            {
                result.AppendLine($"****Assigned Load: {i}");
                result.AppendLine($"{FrameLoadService.AsString(element.Loads[i], characters)}");
            }
            result.AppendLine("----");

            return result.ToString();
        }
    }
}
