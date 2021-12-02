using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfuseConsumable : Consumable
{
    [SerializeField]
    private float confusionTimer = 3f;

    public override void OtherEffects()
    {
        PlayerMovement.Instance.Confusion(confusionTimer);
    }
}
