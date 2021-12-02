using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewColorScheme", menuName = "Data/ColorScheme")]
public class FrogColorScheme : ScriptableObject
{
    public string schemeName;
    [ColorUsage(true, true)]
    public Color main, secondary, eyeWhite, pupil;
    public Sprite icon;
}
