
namespace ContestApp.Models;

/// <summary>
/// Точка на плоскости
/// </summary>
public class Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y) {
        X = x;
        Y = y;
    }

    public override bool Equals(object obj) {
        return obj is Point point && X == point.X && Y == point.Y;
    }

    public override int GetHashCode() {
        return HashCode.Combine(X, Y);
    }
}
