namespace 그래프
{
    public class PathNodeInfo<T>
    {
        public GraphNode<T> Previous { get; private set; }

        public PathNodeInfo(GraphNode<T> previous)
        {
            this.Previous = previous; 
        }
    }
}