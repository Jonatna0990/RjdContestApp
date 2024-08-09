
using ContestApp.Models;
using ContestApp.Services;

namespace ContestAppTests;

[TestFixture]
internal class StationTests
{
    [Test]
    public void TestSchemeCreation() {
        StationSchemeService scheme = new StationSchemeService();
        Assert.AreEqual(4, scheme.Points.Count);
        Assert.AreEqual(4, scheme.Segments.Count);
        Assert.AreEqual(2, scheme.Paths.Count);
        Assert.AreEqual(2, scheme.Parks.Count);
    }

    [Test]
    public void TestParkFilling() {
        StationSchemeService scheme = new StationSchemeService();
        Park park = scheme.Parks[0];

        using (var sw = new StringWriter()) {
            Console.SetOut(sw);
            ParkService.FillPark(park);
            var result = sw.ToString().Trim();
            Assert.IsTrue(result.Contains("Заливка Парк 1:"));
        }
    }

    [Test]
    public void TestShortestPath() {
        StationSchemeService scheme = new StationSchemeService();
        GraphService graphService = new GraphService();

        foreach (var path in scheme.Paths) {
            for (int i = 0; i < path.Segments.Count - 1; i++) {
                graphService.AddEdge(path.Segments[i], path.Segments[i + 1], 1);
            }
        }

        Segment startSegment = scheme.Segments[0];
        Segment endSegment = scheme.Segments[1];
        var shorterstPath = graphService.FindShortestPath(startSegment, endSegment);

        Assert.IsNotNull(shorterstPath);
        Assert.AreEqual(2, shorterstPath.Count);
        Assert.AreEqual(startSegment, shorterstPath[0]);
        Assert.AreEqual(scheme.Segments[1], shorterstPath[1]);
    }

    [Test]
    public void TestShortestPath_Empty() {
        StationSchemeService scheme = new StationSchemeService();
        GraphService graphService = new GraphService();

        foreach (var path in scheme.Paths) {
            for (int i = 0; i < path.Segments.Count - 1; i++) {
                graphService.AddEdge(path.Segments[i], path.Segments[i + 1], 1);
            }
        }

        Segment startSegment = scheme.Segments[0];
        Segment endSegment = scheme.Segments[2];
        var shorterstPath = graphService.FindShortestPath(startSegment, endSegment);

        Assert.IsNull(shorterstPath);
    }
}
