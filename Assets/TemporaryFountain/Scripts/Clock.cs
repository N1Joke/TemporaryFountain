using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : Collectable
{
    [SerializeField] private float _bonusTime = 5f;

    public override void PopUpCollectable()
    {        
        base.PopUpCollectable();
    }

    public override void DestructCollectable()
    {
        SoundManager.Instance.PlayClockSound();
        GameManager.Instance.AddTimeToGame(_bonusTime);
        base.DestructCollectable();
    }
}
