using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunConsumable : Consumable
{
    public float stunTime;

    public override void OtherEffects()
    {
        PlayerEffects.Instance.Stun(stunTime);
    }
}
