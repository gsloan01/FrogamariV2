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

        yield return null;
    }

    public void Shrink(float amount)
    {
        MassManager.Instance.ChangeMass(-amount);
    }

    public void StuckTongue(float stuckTime)
    {
        StartCoroutine(StuckTongue(stuckTime, "This is temporary"));
    }

    IEnumerator StuckTongue(float stuckTime, string idk)
    {
        yield return new WaitForSeconds(stuckTime);

        Mouth.Instance.tongueObject.transform.SetParent(null, true);
        Mouth.Instance.tongueObject.GetComponent<Tongue>().canMove = true;
        
        yield return null;
    }
}
