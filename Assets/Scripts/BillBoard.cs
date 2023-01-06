using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    private Transform _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = PlayerMovement.instance.transform;
        _spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        _spriteRenderer.flipX = true;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_player.position, -Vector3.forward);
    }
}
