using UnityEngine;

public class UnconventionalVictim : MonoBehaviour
{
    public bool debug = false;

    public virtual void OnLookAt(UnconventionalWeapon uw) { }
    public virtual void OnStareAt(UnconventionalWeapon uw) { }
    public virtual void OnLookAway(UnconventionalWeapon uw) { }
}
