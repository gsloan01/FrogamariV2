using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerEffects : SingletonComponent<PlayerEffects>
{
    [SerializeField] private List<EffectVisual> visuals = new List<EffectVisual>();
    private GameObject currentEffect;
    [SerializeField] private Transform effectPosition;
    
    [Serializable]
    public struct EffectVisual
    {
        public string name;
        public GameObject effectPrefab;
    }


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
        SetEffect("Stun");
        yield return new WaitForSeconds(stunTime);

        PlayerMovement.Instance.canMove = true;
        RemoveEffect();

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

    public void SetEffect(string effectName)
    {
        GameObject prefab = visuals.Where(ctx => ctx.name == effectName).FirstOrDefault().effectPrefab;
        currentEffect = Instantiate(prefab, effectPosition);
    }

    public void RemoveEffect()
    {
        if (currentEffect != null) Destroy(currentEffect.gameObject);
    }
}
