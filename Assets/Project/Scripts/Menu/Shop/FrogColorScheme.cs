using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewColorScheme", menuName = "Data/ColorScheme")]
public class FrogColorScheme : ScriptableObject
{
    [SerializeField] Color main, secondary, eyeWhite, pupil;
}
