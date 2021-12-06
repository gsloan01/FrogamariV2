using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorInteractable : Consumable
{
    public float rotateSpeed = 1f;
    public float rotateAmount = 90f;
    public Transform rotatePoint;

    protected override void Interacted()
    {
        if (MassManager.Instance.CurrentMass >= mass * minGrabMultiplier && MassManager.Instance.CurrentMass <= mass * minEatMultiplier)
        {
            Quaternion rotation = Quaternion.AngleAxis(rotateAmount, rotatePoint.transform.up);
            rotatePoint.DORotateQuaternion(rotation, rotateSpeed);
        }
        else
        {
            base.Interacted();
        }
    }
}
