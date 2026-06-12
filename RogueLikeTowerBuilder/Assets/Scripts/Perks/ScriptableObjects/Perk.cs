using UnityEngine;

[CreateAssetMenu(fileName = "Perk", menuName = "Scriptable Objects/Perk")]
public class Perk : ScriptableObject
{
    public PerkNames perk;

    public Sprite sprite;
    public string perkName;
    public string description;
}
