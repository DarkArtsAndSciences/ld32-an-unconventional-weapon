using UnityEngine;
using System.Collections;

public abstract class UnconventionalVictim : MonoBehaviour 
{
    public bool debug = false;

    public abstract void OnLookAt(UnconventionalWeapon eye);
    public abstract void OnLookAway(UnconventionalWeapon eye);
    public abstract void OnStareAt(UnconventionalWeapon eye);
}
