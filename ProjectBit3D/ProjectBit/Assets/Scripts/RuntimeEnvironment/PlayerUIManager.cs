using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Put this script on the player UI Canvas and drag in the player for testing or call the Find GameObject with tag
/// </summary>
public class PlayerUIManager : MonoBehaviour
{
    GameObject Player;
    Hero hero;
    
    public Slider HealthBar;
    public Text health;

    void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        hero = Player.GetComponent<Hero>();
        HealthBar.maxValue = hero.maxHealth;
        HealthBar.value = hero.CurrentHealth;
        health.text = HealthBar.value.ToString();
    }
	
	void Update ()
    {
        HealthBar.value = hero.CurrentHealth;
        health.text = HealthBar.value.ToString();
    }
}
