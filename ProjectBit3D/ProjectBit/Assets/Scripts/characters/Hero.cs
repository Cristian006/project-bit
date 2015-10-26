using UnityEngine;

public class Hero : Entity
{
    void Start()
    {

    }

    void Update()
    {
        Debug.Log(_health.Current);
    }
}
