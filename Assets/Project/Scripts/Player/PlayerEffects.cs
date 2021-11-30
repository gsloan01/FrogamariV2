using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEffects : SingletonComponent<PlayerEffects>
{
    private void Awake()
    {
        base.Awake();
    }

    public void Stun(float stunTime)
    {
        PlayerMovement.Instance.canMove = false;
        StartCoroutine(Stun(stunTime, "This is temporary"));
    }

    IEnumerator Stun(float stunTime, string idk)
    {
        yield return new WaitForSeconds(stunTime);

        PlayerMovement.Instance.canMove = true;
    }

    public void Shrink(float amount)
    {
        MassManager.Instance.ChangeMass(-amount);
    }
}
