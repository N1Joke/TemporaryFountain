using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private float _animationTime = 0.25f;

    private bool _destructed;

    public bool Destructed => _destructed;

    public virtual void PopUpCollectable()
    {
        Vector3 startScale = transform.localScale;
        transform.localScale = Vector3.zero;
        LeanTween.scale(gameObject, startScale, _animationTime).setEaseInBounce();
    }

    public virtual void DestructCollectable()
    {        
        _destructed = true;
        LeanTween.scale(gameObject, Vector3.zero, _animationTime).setEaseOutBounce().setOnComplete(() =>
        {
            Destroy(gameObject);
        });
    }
}
