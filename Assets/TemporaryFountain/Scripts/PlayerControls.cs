using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private TypeMovement _typeMovement;
    [SerializeField] private float _speed;
    [SerializeField] private float _speedRotation;
    
    //private float _borderRadius = 6.06f;
    private Rigidbody2D _rigidbody2d;
    private float _lastAngle;

    public enum TypeMovement
    {
        Simple,
        Hard
    }

    private void Awake()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        //_borderRadius = GameManager.Instance.BorderRadius;
        _lastAngle = transform.rotation.eulerAngles.z;
    }

    private void FixedUpdate()
    {
        float horisontalAxis = Input.GetAxis("Horizontal") * Time.deltaTime;
        float verticalAxis = Input.GetAxis("Vertical") * Time.deltaTime;
        switch (_typeMovement)
        {
            case TypeMovement.Simple:
                //Simple movement
                horisontalAxis *= _speed;
                verticalAxis *= _speed;

                transform.Translate(new Vector2(horisontalAxis, verticalAxis));
                //transform.position = Vector3.ClampMagnitude(transform.position, _borderRadius);
                break;
            case TypeMovement.Hard:
                //Hard movement
                horisontalAxis *= _speedRotation * -1;
                horisontalAxis += _lastAngle;
                _rigidbody2d.MoveRotation(horisontalAxis);
                _lastAngle = horisontalAxis;

                Vector2 pos = (Vector2)transform.position + verticalAxis * _speed * (Vector2)transform.up;
                _rigidbody2d.MovePosition(pos);
                break;
        }
    }        

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            var collectable = collision.gameObject.GetComponent<Collectable>();
            if (collectable.Destructed)
                return;

            collectable.DestructCollectable();
        }
    }
}
