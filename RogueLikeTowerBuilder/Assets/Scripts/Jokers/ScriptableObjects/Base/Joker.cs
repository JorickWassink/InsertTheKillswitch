using UnityEngine;

[CreateAssetMenu(fileName = "Joker", menuName = "Scriptable Objects/Joker")]
public class Joker : ScriptableObject
{
    public int id = 0;

    public string jokerName = "404";

    public Sprite sprite;

    public int price = 5;

    [SerializeReference, SubclassSelector]
    public IJoker joker;

}
