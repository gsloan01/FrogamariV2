using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuckTongueConsumable : Consumable
{
    public float stickTime;

    protected override void Interacted()
    {
        if (MassManager.Instance.CurrentMass <= mass * minGrabMultiplier)
        {
            PlayerEffects.Instance.StuckTongue(stickTime);

            Mouth.Instance.tongueObject.transform.SetParent(transform, true);
            Mouth.Instance.tongueObject.GetComponent<Tongue>().canMove = false;
        }
        else
        {
            base.Interacted();
        }
    }
}
