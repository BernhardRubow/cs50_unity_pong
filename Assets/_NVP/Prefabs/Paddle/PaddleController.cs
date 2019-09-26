using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nvp.events;


public class PaddleController : MonoBehaviour
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

    private void OnEnable()
    {
        NvpEventBus.Events(_upEvent).GameEventHandler += OnUpEventCalled;
        NvpEventBus.Events(_downEvent).GameEventHandler += OnDownEventCalled;
    }

    private void OnDisable()
    {
        NvpEventBus.Events(_upEvent).GameEventHandler -= OnUpEventCalled;
        NvpEventBus.Events(_downEvent).GameEventHandler -= OnDownEventCalled;
    }


    // +++ event handling +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    private void OnDownEventCalled(object sender, EventArgs e)
    {
        _rb.AddForce(Vector3.down * _moveForce, ForceMode.Force);
    }

    private void OnUpEventCalled(object sender, System.EventArgs e)
    {
        _rb.AddForce(Vector3.up * _moveForce, ForceMode.Force);
    }
}
