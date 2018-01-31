﻿using Bytes2you.Validation;
using FrameSections.Contracts;
using System;

namespace FrameSections.Sections
{
    internal class CircularSection : ISection
    {
        private double diameter;
        private string type = "Circular Section";
        private string name;
        private double area;
        private double momentOfInertiaY;
        private double momentOfInertiaZ;
        private double mju = 1.25;
        private double number;

        public CircularSection(double diameter)
        {
            Guard.WhenArgument(diameter, "diameter").IsNaN().Throw();
            Guard.WhenArgument(diameter, "diameter").IsLessThan(0.0).Throw();

            this.Diameter = diameter;
            this.area = Math.PI * diameter * diameter / 4.0;
            this.momentOfInertiaY = Math.PI * diameter * diameter * diameter * diameter / 64.0;
            this.momentOfInertiaZ = momentOfInertiaY;
        }

        public double Diameter
        {
            get
            {
                return this.diameter;
            }

            set
            {
                Guard.WhenArgument(value, "diameter").IsNaN().Throw();
                Guard.WhenArgument(value, "diameter").IsLessThan(0.0).Throw();

                this.diameter = value;
                this.area = Math.PI * this.diameter * this.diameter / 4.0;
                this.momentOfInertiaY = Math.PI * diameter * diameter * diameter * diameter / 64.0;
                this.momentOfInertiaZ = momentOfInertiaY;
            }
        }        

        public double Area
        {
            get
            {
                return this.area;
            }
        }

        public double MomentOfInertiaY
        {
            get
            {
                return this.momentOfInertiaY;
            }
        }

        public double MomentOfInertiaZ
        {
            get
            {
                return this.momentOfInertiaZ;
            }
        }

        public double Mju
        {
            get
            {
                return this.mju;
            }
        }

        public double Number
        {
            get
            {
                return this.number;
            }

            set
            {
                Guard.WhenArgument(value, "number").IsNaN().Throw();
                Guard.WhenArgument(value, "number").IsLessThan(0.0).Throw();
                this.number = value;
            }
        }

        public string Type
        {
            get
            {
                return type;
            }             
        }

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }
    }
}