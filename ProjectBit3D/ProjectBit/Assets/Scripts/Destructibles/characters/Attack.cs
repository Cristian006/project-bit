using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour
{
    Animator anim;
    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void attack()
    {
        anim.SetTrigger("Attack");
    }
}
