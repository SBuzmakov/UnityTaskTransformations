using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private float _speed;
    
    private void Update()
    {
        RotateAroundAxisY();
    }

    private void RotateAroundAxisY()
    {
            transform.RotateAround(transform.position, transform.up, _speed * Time.deltaTime);
    }
}