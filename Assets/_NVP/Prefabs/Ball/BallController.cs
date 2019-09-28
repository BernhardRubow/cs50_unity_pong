using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using nvp.events;
using System;

public class BallController : MonoBehaviour
{
    // +++ fields +++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    [SerializeField] private Vector3 _direction;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _YReflectionRange;

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

        _t.Translate(_direction * _moveSpeed * Time.deltaTime,Space.World);

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
            _direction.y *= -1;
            
        }
        else if(other.tag == "Paddle"){
            _direction.x *= -1;
            _direction *= 1.03f;
            _direction *= 1;

            _direction = ChangeAfterPaddleHit(_direction);
            
        }
    }

    // +++ class methode ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private Vector3 ChangeAfterPaddleHit(Vector3 directon)
    {
        float mag = directon.magnitude;
        directon = directon.normalized;

        directon.y = UnityEngine.Random.Range(-_YReflectionRange, _YReflectionRange);
        Debug.Log (directon);
        directon = directon.normalized * mag;

        return directon;
    }
}
