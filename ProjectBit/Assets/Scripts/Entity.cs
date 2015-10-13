using UnityEngine;
using System.Collections;

public class Entitiy : MonoBehaviour
{
    //[HideInInspector]
    public Stats health;
    //[HideInInspector]
    public Stats armor;

    public void TakeDamage(int damageAmount)
    {
        if (armor.currentValue > 0)
        {


        }
        else
        {
            health.currentValue -= damageAmount;
        }

    }
}
