using System;
using UnityEngine;

public class Scaler : MonoBehaviour
{
    [SerializeField, Range(0,100)] private float _speed;
    [SerializeField, Range(0,100)] private float _scaleStep;
    [SerializeField, Range(0,100)] private Vector3 _maxScale;

    private Vector3 _baseScale = new ();
    private bool _isScaleIncrease = true;
    
    private void Start()
    {
        _baseScale = transform.localScale;
    }
    
    private void Update()
    {
        ChangeScaleDirection();
        
        ChangeScale();
    }

    private void ChangeScale()
    {
        if (_speed < 0 || _scaleStep < 0 || _maxScale.x < 0 || _maxScale.y < 0 || _maxScale.z < 0)
            throw new Exception("wrong speed or scale parameters");
        
        if(_isScaleIncrease)
            transform.localScale += new Vector3(_scaleStep, _scaleStep, _scaleStep) * (_speed * Time.deltaTime) ;

        if (_isScaleIncrease == false)
            transform.localScale -= new Vector3(_scaleStep, _scaleStep, _scaleStep) * (_speed * Time.deltaTime) ;
    }

    private void ChangeScaleDirection()
    {
        if (transform.localScale.x >= _maxScale.x && transform.localScale.y >= _maxScale.y && transform.localScale.z >= _maxScale.z)
            _isScaleIncrease = false;

        if (transform.localScale.x <= _baseScale.x && transform.localScale.y <= _baseScale.y && transform.localScale.z <= _baseScale.z)
            _isScaleIncrease = true;
    }
}