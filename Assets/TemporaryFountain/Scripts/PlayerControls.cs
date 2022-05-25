using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] private float _speed;

    private float _borderRadius = 6.06f;

    private void Start()
    {
        _borderRadius = GameManager.Instance.BorderRadius;
    }

    private void FixedUpdate()
    {
        float horisontalAxis = Input.GetAxis("Horizontal") * _speed * Time.deltaTime;
        float verticalAxis = Input.GetAxis("Vertical") * _speed * Time.deltaTime;

        transform.Translate(new Vector2(horisontalAxis, verticalAxis));        
        //transform.position = Vector3.ClampMagnitude(transform.position, _borderRadius);
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
