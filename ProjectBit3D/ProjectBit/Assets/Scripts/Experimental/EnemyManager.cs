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

    public Transform entityUnitLayer;

    GameObject obj;

    public void Breech()
    {
        obj = (GameObject)Instantiate(enemyBre, spwanPoint1.position, spwanPoint1.rotation);
        obj.transform.SetParent(entityUnitLayer);
        obj = null;
    }
    public void Troop()
    {
        obj = (GameObject)Instantiate(enemyTrp, spwanPoint2.position, spwanPoint2.rotation);
        obj.transform.SetParent(entityUnitLayer);
        obj = null;
    }
    public void All()
    {
        obj = (GameObject)Instantiate(enemyAll, spwanPoint1.position, spwanPoint1.rotation);
        obj.transform.SetParent(entityUnitLayer);
        obj = null;
    }
    public void Resource()
    {
        obj = (GameObject)Instantiate(enemyRes, spwanPoint4.position, spwanPoint4.rotation);
        obj.transform.SetParent(entityUnitLayer);
        obj = null;
    }
    public void Defence()
    {
        obj = (GameObject)Instantiate(enemyDef, spwanPoint3.position, spwanPoint3.rotation);
        obj.transform.SetParent(entityUnitLayer);
        obj = null;
    }
}
