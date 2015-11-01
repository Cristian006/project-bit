using UnityEngine;

public class Hero : Entity
{
    void Start()
    {
        stats = new statContainer(statContainer.Entity);
        maxHealth = 100;
        CurrentHealth = 100;
    }
    
    public override void Death()
    {
        Destroy(this.gameObject);
    }
}
