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
        private List<ILoad> loads;
        private bool uConstraint;
        private bool vConstraint;
        private bool wConstraint;
        private bool rxConstraint;
        private bool ryConstraint;
        private bool rzConstraint;


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

        public List<ILoad> Loads
        {
            get
            {
                return this.loads;
            }
        }

        public bool UConstraint
        {
            get
            {
                return uConstraint;
            }

            set
            {
                uConstraint = value;
            }
        }

        public bool VConstraint
        {
            get
            {
                return vConstraint;
            }

            set
            {
                vConstraint = value;
            }
        }

        public bool WConstraint
        {
            get
            {
                return wConstraint;
            }

            set
            {
                wConstraint = value;
            }
        }

        public bool RxConstraint
        {
            get
            {
                return rxConstraint;
            }

            set
            {
                rxConstraint = value;
            }
        }

        public bool RyConstraint
        {
            get
            {
                return ryConstraint;
            }

            set
            {
                ryConstraint = value;
            }
        }

        public bool RzConstraint
        {
            get
            {
                return rzConstraint;
            }

            set
            {
                rzConstraint = value;
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
