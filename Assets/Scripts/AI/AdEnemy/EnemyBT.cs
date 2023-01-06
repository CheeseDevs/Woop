using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BT;

public class EnemyBT : BT.Tree
{
    public Transform[] waypoints;

    public static float speed = 2f;
    public static float FOVrange = 6f;



    // Start is called before the first frame update

    protected override Node SetupTree()
    {
        Node root = new TaskPatrol(transform, waypoints);
        return root;
    }
}
