using UnityEngine;
using System.Collections;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyAll;
    public GameObject enemyBre;
    public GameObject enemyTrp;
    public GameObject enemyRes;
    public GameObject enemyDef;

    public Transform spwanPoint1;
    public Transform spwanPoint2;
    public Transform spwanPoint3;
    public Transform spwanPoint4;

    public void Breech()
    {
        Instantiate(enemyBre, spwanPoint1.position, spwanPoint1.rotation);
    }
    public void Troop()
    {
        Instantiate(enemyTrp, spwanPoint2.position, spwanPoint2.rotation);
    }
    public void All()
    {
        Instantiate(enemyAll, spwanPoint1.position, spwanPoint1.rotation);
    }
    public void Resource()
    {
        Instantiate(enemyRes, spwanPoint4.position, spwanPoint4.rotation);
    }
    public void Defence()
    {
        Instantiate(enemyDef, spwanPoint3.position, spwanPoint3.rotation);
    }
}
