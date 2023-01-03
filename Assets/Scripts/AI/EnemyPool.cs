using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{

    public List<GameObject> enemypool = new List<GameObject>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddItem(GameObject damagable)
    {
        IDamagable damagable1 = damagable.GetComponent<IDamagable>();
        Debug.Log(damagable1);
        if (damagable1 != null)
        {
            enemypool.Add(damagable);
            Debug.Log("adding");
        }
    }

    public void RemoveItem(GameObject damagable)
    {
        IDamagable damagable1 = damagable.GetComponent<IDamagable>();
        if (damagable1 != null)
        {
            enemypool.Remove(damagable);
            Debug.Log("adding");
        }
    }
}
