using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = ("Data/PlayerAbilityData"), fileName = ("PlayerAbilityData"))]
public class PlayerAbilityData : ScriptableObject
{
   public int intelligence = 0;
   public int virtue = 0;
   public int body = 0;
}
