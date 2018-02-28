using Bytes2you.Validation;
using FiniteElements.Models.Contracts;
using System.Collections.Generic;

namespace FiniteElements.Models.Nodes
{
    internal class Node
    {
        private double xCoord;
        private double yCoord;
        private double zCoord;
        private double number;
        private List<INodalLoad> loads;

        private bool xSupport;
        private bool ySupport;
        private bool zSupport;
        private bool rxSupport;
        private bool rySupport;
        private bool rzSupport;

        private double xSpring;
        private double ySpring;
        private double zSpring;
        private double rxSpring;
        private double rySpring;
        private double rzSpring;

        public Node(double xCoord, double yCoord, double zCoord = 0)
        {
            Guard.WhenArgument(xCoord, "xCoord").IsNaN().Throw();
            Guard.WhenArgument(yCoord, "yCoord").IsNaN().Throw();
            Guard.WhenArgument(zCoord, "zCoord").IsNaN().Throw();

            this.XCoord = xCoord;
            this.YCoord = yCoord;
            this.ZCoord = zCoord;
        }

        public double XCoord
        {
            get
            {
                return this.xCoord;
            }

            set
            {
                Guard.WhenArgument(value, "xCoord").IsNaN();
                this.xCoord = value;
            }
        }

        public double YCoord
        {
            get
            {
                return this.yCoord;
            }

            set
            {
                Guard.WhenArgument(value, "yCoord").IsNaN();
                this.yCoord = value;
            }
        }

        public double ZCoord
        {
            get
            {
                return this.zCoord;
            }

            set
            {
                Guard.WhenArgument(value, "zCoord").IsNaN();
                this.zCoord = value;
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
                Guard.WhenArgument(value, "number").IsNaN();
                this.number = value;
            }
        }

        public List<INodalLoad> Loads
        {
            get
            {
                return this.loads;
            }
        }

        public bool XSupport
        {
            get
            {
                return xSupport;
            }

            set
            {
                xSupport = value;
            }
        }

        public bool YSupport
        {
            get
            {
                return ySupport;
            }

            set
            {
                ySupport = value;
            }
        }

        public bool ZSupport
        {
            get
            {
                return zSupport;
            }

            set
            {
                zSupport = value;
            }
        }

        public bool RxSupport
        {
            get
            {
                return rxSupport;
            }

            set
            {
                rxSupport = value;
            }
        }

        public bool RySupport
        {
            get
            {
                return rySupport;
            }

            set
            {
                rySupport = value;
            }
        }

        public bool RzSupport
        {
            get
            {
                return rzSupport;
            }

            set
            {
                rzSupport = value;
            }
        }

        public double XSpring
        {
            get
            {
                return this.xSpring;
            }

            set
            {
                Guard.WhenArgument(value, "Spring X").IsLessThan(0.0).Throw();
                this.xSpring = value;
            }
        }

        public double YSpring
        {
            get
            {
                return this.ySpring;
            }

            set
            {
                Guard.WhenArgument(value, "Spring Y").IsLessThan(0.0).Throw();
                this.ySpring = value;
            }
        }

        public double ZSpring
        {
            get
            {
                return this.zSpring;
            }

            set
            {
                Guard.WhenArgument(value, "Spring Z").IsLessThan(0.0).Throw();
                this.zSpring = value;
            }
        }

        public double RxSpring
        {
            get
            {
                return this.rxSpring;
            }

            set
            {
                Guard.WhenArgument(value, "Spring Rx").IsLessThan(0.0).Throw();
                this.rxSpring = value;
            }
        }

        public double RySpring
        {
            get
            {
                return this.rySpring;
            }

            set
            {
                Guard.WhenArgument(value, "Spring Ry").IsLessThan(0.0).Throw();
                this.rySpring = value;
            }
        }

        public double RzSpring
        {
            get
            {
                return this.rzSpring;
            }

            set
            {
                Guard.WhenArgument(value, "Spring Rz").IsLessThan(0.0).Throw();
                this.rzSpring = value;
            }
        }

        public int CompareTo(Node that)
        {
            if (this.xCoord == that.xCoord
                && this.yCoord == that.yCoord
                && this.zCoord == that.zCoord)
            {
                return 0;
            }

            else
            {
                return 1;
            }
        }
    }
}
