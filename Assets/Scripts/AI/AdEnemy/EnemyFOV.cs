using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BT;

public class EnemyFOV : Node
{
    // Start is called before the first frame update
    private Transform _transform;
    private int _enemyLayerMask = 1 << 6;

    public EnemyFOV(Transform transform)
    {
        _transform = transform;
    }

    public override NodeState Evaluate()
    {
        object target = GetDAta("target");
        if (target == null)
        {
            Collider[] colliders = Physics.OverlapSphere(_transform.position, EnemyBT.FOVrange, _enemyLayerMask);
            if (colliders.Length > 0)
            {
                parent.parent.SetData("target", colliders[0].transform);

                state = NodeState.SUCCESS;
                return state;
            }
            state = NodeState.FAILURE;
            return state;
        }

        state = NodeState.SUCCESS;
        return state;
    }
}
