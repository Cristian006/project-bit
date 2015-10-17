using UnityEngine;

public class Entity : MonoBehaviour
{
    private float _health;
	public float health {
        get { return _health; }
        set { _health = Mathf.Clamp(value, 0, Mathf.Infinity); }
    }

    public void TakeDamage(float damage)
    {
        if (health <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        //Kill Entity
    }
}
