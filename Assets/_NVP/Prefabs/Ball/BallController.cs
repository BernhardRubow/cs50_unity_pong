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
        NvpEventBus.Events(GameEvents.OnLaunchBall).GameEventHandler += OnServeBall;
    }

    private void OnDisable()
    {
        NvpEventBus.Events(GameEvents.OnLaunchBall).GameEventHandler -= OnServeBall;
    }

    void Update()
    {
        if (_paused) return;

        _t.Translate(_direction * _moveSpeed * Time.deltaTime,Space.World);

        CheckPlayerScored();

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

    // +++ class methods ++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
    private Vector3 ChangeAfterPaddleHit(Vector3 directon)
    {
        float mag = directon.magnitude;
        directon = directon.normalized;

        directon.y = UnityEngine.Random.Range(-_YReflectionRange, _YReflectionRange);
        directon = directon.normalized * mag;

        return directon;
    }

    private void CheckPlayerScored()
    {
        var x = _t.position.x;
        if(Mathf.Abs(x) > 33f){
            
            var eventArgs = new StringEventArgs();

            if(x < 0){
                // right player scores
                eventArgs.Value = "right";
            }
            else{
                 // left player scores
                eventArgs.Value = "left";
            }

            NvpEventBus.Events(GameEvents.OnPlayerScores).TriggerEvent(this, eventArgs);

            PrepareBallForServe();
        }
    }

    private void PrepareBallForServe()
    {
        _t.position = Vector3.zero;
        _paused = true;
    }
}
