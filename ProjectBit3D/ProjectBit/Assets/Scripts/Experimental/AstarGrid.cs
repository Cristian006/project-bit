using UnityEngine;
using Pathfinding;

public class AstarGrid : MonoBehaviour
{
    AstarData data;
    GridGraph gg;

    public void setGraph()
    {
        data = AstarData.active.astarData;
        gg = data.AddGraph(typeof(GridGraph)) as GridGraph;
        gg.width = 50;
        gg.depth = 50;
        gg.nodeSize = 1;
        gg.center = new Vector3(25, 0, 25);

        gg.UpdateSizeFromWidthDepth();

        AstarPath.active.Scan();
    }
}
