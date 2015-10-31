using UnityEngine;

public class Hero : Entity
{
    GameObject goPanel;

    void Start()
    {
        goPanel = GameObject.FindGameObjectWithTag("GameOverPanel");
        goPanel.SetActive(false);
        stats = new statContainer("Entity");
        stats[Health, Max] = 100;
        stats[Health, Current] = 100;
    }
    
    public override void Death()
    {
        goPanel.SetActive(true);
        Destroy(this.gameObject);
    }
}
