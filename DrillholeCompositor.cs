using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrillholeCompositing
{
    public class DrillholeSample
    {
        public double Depth { get; set; }
        public double Length { get; set; }
        public double Grade { get; set; }

        public DrillholeSample(double depth, double length, double grade)
        {
            Depth = depth;
            Length = length;
            Grade = grade;
        }

    }

    public class CompositeSample
    {
        public double StartDepth { get; set; }
        public double EndDepth { get; set; }
        public double AverageGrade { get; set; }
        public double TotalLength { get; set; }

        public CompositeSample(double startDepth, double endDepth, double averageGrade, double totalLength)
        {
            StartDepth = startDepth;
            EndDepth = endDepth;
            AverageGrade = averageGrade;
            TotalLength = totalLength;
        }

    }

    public class DrillholeCompositor
    {
        public List<CompositeSample> CompositeSamples(List<DrillholeSample> samples, double compositeLength)
        {
            var composites = new List<CompositeSample>();

            // Sort samples by Depth
            var sortedSamples = samples.OrderBy(s => s.Depth).ToList();

            double currentStartDepth = sortedSamples[0].Depth;
            double currentEndDepth = currentStartDepth + compositeLength;
            double totalGrade = 0;
            double totalLength = 0;
            int count = 0;

            foreach (var sample in sortedSamples)
            {
                while (sample.Depth >= currentEndDepth)
                {
                    if (count > 0)
                    {
                        composites.Add(new CompositeSample(currentStartDepth, currentEndDepth,
                            totalGrade / count, totalLength));
                    }

                    // Move to the next interval
                    currentStartDepth = currentEndDepth;
                    currentEndDepth += compositeLength;
                    totalGrade = 0;
                    totalLength = 0;
                    count = 0;
                }

                // Add sample to the current composite
                totalGrade += sample.Grade * sample.Length; // Weighted by length
                totalLength += sample.Length;
                count++;
            }

            // Handle the last composite if there were samples in it
            if (count > 0)
            {
                composites.Add(new CompositeSample(currentStartDepth, currentEndDepth,
                    totalGrade / totalLength, totalLength));
            }

            return composites;

        }
    }
}
