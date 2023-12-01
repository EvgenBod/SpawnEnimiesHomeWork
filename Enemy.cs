using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private int _timeLife = 25;

    private void Start()
    {
        Destroy(gameObject, _timeLife);
    }
}