using ContestApp.Models;

namespace ContestApp.Services;

/// <summary>
/// Сервис для нахождения кратчайшего пути между участками
/// </summary>
public class GraphService
{
    public Dictionary<Segment, List<(Segment, double)>> AdjacencyList { get; } = new Dictionary<Segment, List<(Segment, double)>>();

    // Метод для добавления ребра в граф
    public void AddEdge(Segment start, Segment end, double weight) {
        AddSegment(start);
        AddSegment(end);
        AdjacencyList[start].Add((end, weight));
        AdjacencyList[end].Add((start, weight));
    }

    // Метод для добавления вершины (отрезка) в граф
    private void AddSegment(Segment segment) {
        if (!AdjacencyList.ContainsKey(segment)) {
            AdjacencyList[segment] = new List<(Segment, double)>();
        }
    }

    // Метод для поиска кратчайшего пути с использованием алгоритма Дейкстры
    public List<Segment> FindShortestPath(Segment start, Segment end) {
        var distances = InitializeDistances();
        var previous = InitializePrevious();
        var priorityQueue = InitializePriorityQueue(start);

        distances[start] = 0;

        while (priorityQueue.Count > 0) {
            var (currentDistance, currentSegment) = ExtractMin(priorityQueue);

            if (currentSegment.Equals(end)) {
                return ReconstructPath(previous, start, end);
            }

            UpdateNeighbors(distances, previous, priorityQueue, currentDistance, currentSegment);
        }

        return null; // Путь не найден
    }

    // Метод для инициализации словаря расстояний
    private Dictionary<Segment, double> InitializeDistances() {
        var distances = new Dictionary<Segment, double>();
        foreach (var vertex in AdjacencyList.Keys) {
            distances[vertex] = double.MaxValue;
        }
        return distances;
    }

    // Метод для инициализации словаря предыдущих вершин
    private Dictionary<Segment, Segment> InitializePrevious() {
        var previous = new Dictionary<Segment, Segment>();
        foreach (var vertex in AdjacencyList.Keys) {
            previous[vertex] = null;
        }
        return previous;
    }

    // Метод для инициализации приоритетной очереди
    private SortedSet<(double, Segment)> InitializePriorityQueue(Segment start) {
        var priorityQueue = new SortedSet<(double, Segment)>(Comparer<(double, Segment)>.Create((x, y) => {
            int result = x.Item1.CompareTo(y.Item1);
            return result == 0 ? x.Item2.GetHashCode().CompareTo(y.Item2.GetHashCode()) : result;
        }));
        priorityQueue.Add((0, start));
        return priorityQueue;
    }

    // Метод для извлечения вершины с минимальным расстоянием
    private (double, Segment) ExtractMin(SortedSet<(double, Segment)> priorityQueue) {
        var min = priorityQueue.Min;
        priorityQueue.Remove(min);
        return min;
    }

    // Метод для обновления соседей текущей вершины
    private void UpdateNeighbors(Dictionary<Segment, double> distances, Dictionary<Segment, Segment> previous, SortedSet<(double, Segment)> priorityQueue, double currentDistance, Segment currentSegment) {
        foreach (var (neighbor, weight) in AdjacencyList[currentSegment]) {
            double distance = currentDistance + weight;

            if (distance < distances[neighbor]) {
                priorityQueue.Remove((distances[neighbor], neighbor));
                distances[neighbor] = distance;
                previous[neighbor] = currentSegment;
                priorityQueue.Add((distance, neighbor));
            }
        }
    }

    // Метод для реконструкции пути
    private List<Segment> ReconstructPath(Dictionary<Segment, Segment> previous, Segment start, Segment end) {
        var path = new List<Segment>();
        for (var at = end; at != null; at = previous[at]) {
            path.Add(at);
        }
        path.Reverse();
        return path;
    }
}
