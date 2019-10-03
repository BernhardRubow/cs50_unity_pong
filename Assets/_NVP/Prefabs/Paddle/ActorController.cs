using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nvp.events;


public class ActorController : MonoBehaviour, IActor
{
    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [SerializeField] private float _moveForce;

    [SerializeField] private GameEvents _upEvent;
    [SerializeField] private GameEvents _downEvent;

    private Rigidbody _rb;


    // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void Start()
    {
        _rb = this.GetComponent<Rigidbody>();
    }



    // +++ IPaddle Implementation +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    public void MoveUp()
    {
        _rb.AddForce(Vector3.up * _moveForce, ForceMode.Force);
    }

    public void MoveDown()
    {
        _rb.AddForce(Vector3.down * _moveForce, ForceMode.Force);
    }
}