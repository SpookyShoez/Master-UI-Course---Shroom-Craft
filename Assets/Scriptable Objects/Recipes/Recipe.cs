using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Recipe", menuName = "Recipes/Recipe")]
public class Recipe : ScriptableObject
{
   public Item[] ingredients;
   public Item result;
}
