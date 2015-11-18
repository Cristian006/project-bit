using UnityEngine;
using System.Collections;

/// <summary>
/// Manage the town
/// THIS: needs to handle building placement mechanics
/// This needs to handle all town variables and functions
/// This will basically be doing most of all the city building aspects of the game.
/// </summary>
public class TownManager : MonoBehaviour
{
    bool firstTime = false;

    void Awake()
    {
        if (!firstTime) //if the player has never loaded up the game before
        {
            Init();     //load up the game
        }
    }

	public void Init()
    {
        //Create A TownHall
    }
}
