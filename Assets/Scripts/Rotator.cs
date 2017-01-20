using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField, Range(0, 300)] private float _rotationSpeed = 5f;
    [SerializeField] private RotationDirection _rotationDirection;

    public enum RotationDirection
    {
        Left = -1,
        Right = 1
    }

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void SetRotation(RotationDirection rotationDirection)
    {
        _rotationDirection = rotationDirection;
    }

    private void FixedUpdate()
    {
        var angularVelocity = new Vector3(0, _rotationSpeed * (int)_rotationDirection, 0);
        Quaternion deltaRotation = Quaternion.Euler(angularVelocity * Time.deltaTime);
        _rigidbody.MoveRotation(_rigidbody.rotation * deltaRotation);
    }
}