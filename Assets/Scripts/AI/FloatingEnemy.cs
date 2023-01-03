using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingEnemy : MonoBehaviour, IBasicEnemy
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _hp;
    [SerializeField]
    private float _damage;
    [SerializeField]
    private Vector3 _startPoint;
    [SerializeField]
    private Vector3 _endPoint;
    [SerializeField]
    private float _duration;
    private bool _reached = false;


    // Start is called before the first frame update

    void Start()
    {
        _startPoint = transform.position + _startPoint;
        _endPoint = transform.position + _endPoint;
        _reached = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void OnCollisionStay(Collision collision)
    {
        DealDamage(50);
    }

    // IBasicEnemy
    public void DealDamage(float damage)
    {
        Debug.Log("damaging");
    }

    public void Die()
    {
        if (_hp <= 0)
        {
            Destroy(this);
        }
    }

    public void Move()
    {
        if (_reached)
        {
            StartCoroutine(RepeatLerp());
            _reached = false;
        }

    }

    public void TakeDamage(float damage)
    {
        _hp = _hp - damage;
    }

    IEnumerator RepeatLerp()
    {
        float timeElapsed = 0;
        while (timeElapsed < _duration)
        {
            transform.position = Vector3.Lerp(_startPoint, _endPoint, timeElapsed / _duration);
            timeElapsed += Time.deltaTime;

            yield return null;
        }
        Vector3 temp = transform.position;
        temp = _endPoint;
        _endPoint = _startPoint;
        _startPoint = temp;
        _reached = true;
        Debug.Log(_endPoint + "      "+ _startPoint);
    }
}

public interface IBasicEnemy
{
    void Move();
    void DealDamage(float damage);
    void Die();
}

public interface IDamagable
{
    void TakeDamage(float damage);
}