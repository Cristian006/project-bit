using UnityEngine;
using System.Collections;

public class Hero : Entity
{
    Targeting targeting;
    newAI ai;
    ThirdPersonMovement tpm;
    ThirdPersonMotor tmotor;
    void Awake()
    {
        entityType = EntityType.Player;
        ai = GetComponent<newAI>();
        targeting = GetComponent<Targeting>();
        tpm = GetComponent<ThirdPersonMovement>();
        tmotor = GetComponent<ThirdPersonMotor>();
    }

    void Start()
    {
        stats = new statContainer(statContainer.Entity);
        maxHealth = 100;
        CurrentHealth = 100;
    }
    
    void FixedUpdate()
    {
        if(ai.isActiveAndEnabled)
        {
            targeting.Begin();
        }
    }

    void Update()
    {
        //TODO: ENABLE OR DISABLE THE AI SCRIPT COMPLETLY
        if (GameManager.gm.isInThirdPersonView)
        {
            ai.AIOn = false;
            tpm.enabled = true;
            tmotor.enabled = true;
        }
        else
        {
            ai.AIOn = true;
            tpm.enabled = false;
            tmotor.enabled = false;
        }
    }

    public override void Death()
    {
        Destroy(this.gameObject);
    }
}
