using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BT;

public class EnemyBT : BT.Tree
{
    public Transform[] waypoints;

    public static float speed = 2f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override Node SetupTree()
    {
        Node root = new TaskPatrol(transform, waypoints);
        return root;
    }
}
