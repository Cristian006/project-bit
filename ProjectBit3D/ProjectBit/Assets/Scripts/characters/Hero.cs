using UnityEngine;

public class Hero : Entity
{
    GameObject goPanel;

    void Start()
    {
        goPanel = GameObject.FindGameObjectWithTag("GameOverPanel");
        goPanel.SetActive(false);
        stats = new statContainer(statContainer.Entity);
        maxHealth = 100;
        CurrentHealth = 100;
    }
    
    public override void Death()
    {
        goPanel.SetActive(true);
        Destroy(this.gameObject);
    }
}
