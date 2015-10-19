using UnityEngine;
using System.Collections;

public class Building : MonoBehaviour
{
    /// <summary>
    /// grid space, Example: 3 = 3x3 grid space.
    /// </summary>
    public int size;
    
    public enum PositionState
    {

    }

    PositionState currentPosition = new PositionState();

    public void OnDrag()
    {

    }

}
