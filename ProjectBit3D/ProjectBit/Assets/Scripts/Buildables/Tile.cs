using UnityEngine;
using System.Collections;

public class Tile : MonoBehaviour
{
    public enum tileState
    {
        free,
        used
    }

    public tileState currentState = new tileState();

    public void used()
    {
        currentState = tileState.used;
    }

    public void free()
    {
        currentState = tileState.free;
    }
}
