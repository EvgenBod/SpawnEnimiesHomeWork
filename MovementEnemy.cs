using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementEnemy : MonoBehaviour
{
    [SerializeField] private float _speed = 1f;

    private Transform _target;

    private void Update()
    {
        transform.LookAt(_target.transform.position);
        transform.position = Vector3.MoveTowards(transform.position, _target.position, Time.deltaTime * _speed);
    }

    public void SetTarget(Transform target)
    {
        _target = target;
    }
}
