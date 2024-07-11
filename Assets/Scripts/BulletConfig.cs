using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BulletConfig", menuName = "ScriptableObjects/BulletConfig", order = 1)]
public class BulletConfig : ScriptableObject
{
    public float Speed;
    public float Lifetime;
    public int Damage;
    public float CollisionThreshold;
}
