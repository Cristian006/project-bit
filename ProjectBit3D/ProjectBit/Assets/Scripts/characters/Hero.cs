using UnityEngine;

public class Hero : Entity
{
    void Start()
    {

        stats = new statContainer("Entity");
        stats[Health, Max] = 100;
        stats[Health, Current] = 100;
    }

    void Update()
    {
        Debug.Log(stats[Health,Current]);
    }
}
