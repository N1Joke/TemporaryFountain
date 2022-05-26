using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private TypeMovement _typeMovement;
    [SerializeField] private float _speed;
    [SerializeField] private float _speedRotation;
    [SerializeField] private float _startAnimationTime = 1f;

    //private float _borderRadius = 6.06f;
    private Rigidbody2D _rigidbody2d;
    private BoxCollider2D _collider2D;
    private float _lastAngle;
    private bool _freezMovements = false;

    public enum TypeMovement
    {
        Simple,
        Hard
    }

    private void Awake()
    {
        _collider2D = GetComponent<BoxCollider2D>();
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _freezMovements = true;
        _collider2D.enabled = false;
        SoundManager.Instance.SwimSound(true);
        LeanTween.move(gameObject, Vector2.zero, _startAnimationTime).setEaseOutSine().setOnComplete(() =>
         {
             _freezMovements = false;
             _collider2D.enabled = true;
             SoundManager.Instance.SwimSound(false);
         });

        //_borderRadius = GameManager.Instance.BorderRadius;
        _lastAngle = transform.rotation.eulerAngles.z;
    }

    private void FixedUpdate()
    {
        UpdateMovement();
    }

    private void UpdateMovement()
    {
        if (_freezMovements)
            return;

        float horisontalAxis = Input.GetAxis("Horizontal") * Time.deltaTime;
        float verticalAxis = Input.GetAxis("Vertical") * Time.deltaTime;

        if (horisontalAxis != 0 || verticalAxis != 0)
            SoundManager.Instance.SwimSound(true);
        else
            SoundManager.Instance.SwimSound(false);

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
