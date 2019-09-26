using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nvp.events;

public class BallController : MonoBehaviour
{
    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [SerializeField] private Vector3 _directon;
    [SerializeField] private float _moveSpeed;

    void OnEnable()
    {
        
    }

    private void OnDisable()
    {
        
    }
}
