
namespace ContestApp.Models;

/// <summary>
/// Отрезок, соединяющий две точки
/// </summary>
public class Segment
{
    public Point StartPoint { get; set; }
    public Point EndPoint { get; set; }

    public Segment(Point start, Point end) {
        StartPoint = start;
        EndPoint = end;
    }

    //Для сравнения двух отрезков
    public override bool Equals(object obj) {
        return obj is Segment segment && 
            StartPoint.Equals(segment.StartPoint) &&
            EndPoint.Equals(segment.EndPoint);
    }

    public override int GetHashCode() {
        return HashCode.Combine(StartPoint, EndPoint);
    }
}
