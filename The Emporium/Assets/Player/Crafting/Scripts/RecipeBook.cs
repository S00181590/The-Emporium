using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RecipeBook", menuName = "Crafting/RecipeBook")]
public class RecipeBook : ScriptableObject
{
    public List<Recipe> recipes;
}
