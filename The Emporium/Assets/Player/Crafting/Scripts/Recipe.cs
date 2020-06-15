using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Recipe",menuName ="Crafting/Recipes")]
public class Recipe : ScriptableObject
{
    public string id;

    public string RecipeCode;

    public Item result;
}
