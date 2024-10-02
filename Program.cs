// See https://aka.ms/new-console-template for more information
using DrillholeCompositing;

// Sample drillhole data
var samples = new List<DrillholeSample>
        {
            new DrillholeSample(0.0, 1.0, 2.5),
            new DrillholeSample(1.0, 1.0, 3.0),
            new DrillholeSample(2.0, 1.0, 1.5),
            new DrillholeSample(3.0, 2.0, 4.0),
            new DrillholeSample(5.0, 1.0, 2.0),
            new DrillholeSample(6.0, 1.0, 3.5),
            new DrillholeSample(7.0, 2.0, 1.0)
        };

double compositeLength = 3.0; // Length of each composite sample

var compositor = new DrillholeCompositor();
var composites = compositor.CompositeSamples(samples, compositeLength);

// Output the composite samples
foreach (var composite in composites)
{
    Console.WriteLine($"Composite from {composite.StartDepth} to {composite.EndDepth}: " +
                      $"Average Grade = {composite.AverageGrade}, Total Length = {composite.TotalLength}");
}