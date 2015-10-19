using UnityEngine;
using System.Collections;
/// <summary>
/// Depending on what your hitting the damage will decrease more or less
/// </summary>
public class Weapon : MonoBehaviour
{
    private float _durability;
    public float durability
    {
        get { return _durability; }
        set { _durability = Mathf.Clamp(value, 0, Mathf.Infinity); }
    }

    bool fix = false;
    bool usable = true;

    public void TakeDamage(float damage)
    {
        if (durability <= 0)
        {
            fix = true;
            Break();
        }
    }

    public void Break()
    {
        if (fix)
        {
            usable = false;
        }
    }

    void OnTriggerEnter(Collider outside)
    {
        Entity enemy = (Entity)outside.gameObject.GetComponent("Entity");
        if(enemy.name=="Entity")
            enemy.TakeDamage(10);
    }

}
