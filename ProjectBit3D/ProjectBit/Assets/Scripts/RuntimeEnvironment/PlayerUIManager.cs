using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Put this script on the player UI Canvas and drag in the player for testing or call the Find GameObject with tag
/// </summary>
public class PlayerUIManager : MonoBehaviour
{
    public GameObject Player;
    public Hero hero;
    public GameObject PlayerUI;

    public Slider HealthBar;

	void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        HealthBar = GetComponentInChildren<Slider>();
        hero = Player.GetComponent<Hero>();
        HealthBar.maxValue = hero.maxHealth;
        HealthBar.value = hero.CurrentHealth;
    }
	
	void Update ()
    {
        HealthBar.value = hero.CurrentHealth;
    }
}
