﻿namespace FrameSections.Contracts
{
    public interface ISection
    {
        string Type { get; }

        string Name { get; set; }

        double Area { get; }

        double MomentOfInertiaY { get; }

        double MomentOfInertiaZ { get; }

        double TorsionalConstantX { get; }

        double Mju { get; }

        int Number { get; set; }
    }
}
