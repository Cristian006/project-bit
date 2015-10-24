using UnityEngine;
using System.Collections;
/// <summary>
/// Handle the Take Damage Function.
/// Anything that is destructible is also selectable.
/// </summary>
public class Destructible : MonoBehaviour
{
    private SecondaryStat health;
    //TODO create properties for health and maxhealth


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //TODO
    //handle entity death when health <0;
    public void TakeDamage(int damage)
    {
        health.Current -= damage;
    }
}
