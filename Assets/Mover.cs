using System;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField, Range(0, 100)] private float _speed;
    [SerializeField, Range(1, 100)] private float _moveDistance;
    [SerializeField] private bool _isTargetExist;

    private Vector3 _basePosition = new();
    private Vector3 _targetPosition = new();
    private bool _isMoveToTargetPosition = true;

    private void Start()
    {
        _basePosition = transform.position;
        _targetPosition = _basePosition + transform.forward * _moveDistance;
    }

    private void Update()
    {
        Move();

        if (_isTargetExist)
            ChangeMoveDirection();
    }

    private void Move()
    {
        if (_speed < 0 || _moveDistance < 0)
            throw new Exception("wrong speed or distance");

        if (_isMoveToTargetPosition)
            transform.Translate(transform.forward * (_speed * Time.deltaTime));

        if (_isMoveToTargetPosition == false)
            transform.Translate(-transform.forward * (_speed * Time.deltaTime));
    }

    private void ChangeMoveDirection()
    {
        if (transform.position.x >= _targetPosition.x && transform.position.y >= _targetPosition.y &&
            transform.position.z >= _targetPosition.z)
            _isMoveToTargetPosition = false;

        if (transform.position.x <= _basePosition.x && transform.position.y <= _basePosition.y &&
            transform.position.z <= _basePosition.z)
            _isMoveToTargetPosition = true;
    }
}