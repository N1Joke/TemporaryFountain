using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : Collectable
{
    public override void PopUpCollectable()
    {
        base.PopUpCollectable();
    }

    public override void DestructCollectable()
    {
        SoundManager.Instance.PlayCoinSound();
        UIManager.Instance.AddCoin();
        base.DestructCollectable();
    }
}
