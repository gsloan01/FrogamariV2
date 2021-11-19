using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SizeIndicatorUI : MonoBehaviour
{
    [SerializeField] public Image FillFrame, Fill;
    [SerializeField] public TMP_Text sizeTXT;


    //Testing
    [Range(0, 100)]
    public float size = 0;

    private void Update()
    {
        float ratio = size / 100;
        Fill.gameObject.transform.localScale = new Vector3(ratio, ratio, 1);
    }

}
