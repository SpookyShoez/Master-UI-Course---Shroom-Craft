using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Scriptable Objects/Item")]

public class Item : ScriptableObject
{
  public string itemName;
  public int attack;
  public int defense;
  public int hp;
  public Sprite sprite;
  public ItemCategory category;
  public bool stackable = false;
}

public enum ItemCategory
{
    Helmet,
    Chest,
    Weapon,
    Potion,
    CraftingItem,
    Other
}
