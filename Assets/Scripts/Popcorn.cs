using UnityEngine;

public class Popcorn : MonoBehaviour
{
    [SerializeField] private float _minForce = 100f;  
    [SerializeField] private float _maxForce = 300f;

    private Rigidbody _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Start()
    {
        InvokeRepeating("AddRandomForce", 5f, 5f);
    }

    private void AddRandomForce()
    {
        _rigidbody.AddForceAtPosition(Vector3.right * Random.Range(_minForce, _maxForce), transform.position);
        _rigidbody.AddTorque(Vector3.right * Random.Range(_minForce, _maxForce));
    }
}