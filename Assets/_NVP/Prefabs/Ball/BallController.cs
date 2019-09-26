using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nvp.events;
using System;

public class BallController : MonoBehaviour
{
    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [SerializeField] private Vector3 _directon;
    [SerializeField] private float _moveSpeed;

    private Vector3 _lastSpeed;

    private bool _paused = true;
    private Transform _t;


    // +++ life cycle +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    void Start()
    {
        _t = this.transform;
    }

    void OnEnable()
    {
        NvpEventBus.Events(GameEvents.ServeBall).GameEventHandler += OnServeBall;
    }

    private void OnDisable()
    {
        NvpEventBus.Events(GameEvents.ServeBall).GameEventHandler -= OnServeBall;
    }

    void Update()
    {
        if (_paused) return;

        _t.Translate(_directon * _moveSpeed * Time.deltaTime,Space.World);

    }

    // +++ Event handler ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private void OnServeBall(object sender, EventArgs e)
    {
        _paused = false;
    }
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hit " + other.tag);   
        if(other.tag == "Wall"){
            _directon.y *= -1;
            if(_t.position.y > 0){
                _t.position = new Vector3(_t.position.x, _t.position.y - _t.localScale.y, 0);
            }
            else {                
                _t.position = new Vector3(_t.position.x, _t.position.y + _t.localScale.y, 0);
            }
        }
        else if(other.tag == "Paddle"){
            _directon.x *= -1;
            _directon *= 1.03f;
            if(_t.position.x > 0){
                _t.position = new Vector3(_t.position.x - _t.localScale.x, _t.position.y - _t.localScale.x, 0);
            }
            else {                
                _t.position = new Vector3(_t.position.x  + _t.localScale.x, _t.position.y, 0);
            }
        }
    }
}
