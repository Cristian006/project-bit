using UnityEngine;
using System.Collections;

public class Hero : Entity
{
    Targeting targeting;
    newAI ai;

    void Awake()
    {
        entityType = EntityType.Player;
        ai = GetComponent<newAI>();
    }

    void Start()
    {
        stats = new statContainer(statContainer.Entity);
        maxHealth = 100;
        CurrentHealth = 100;
        //ai.enabled = true;
    }
    
    void Update()
    {
        /*if (GameManager.gm.thirdPersonView)
        {
            ai.AIOn = true;
            targeting.Begin();
            StartCoroutine(ai.UpdatePath());
        }
        else
        {
            ai.AIOn = false;
            ai.ShutAIDown();
        }*/
    }

    public override void Death()
    {
        Destroy(this.gameObject);
    }
}
