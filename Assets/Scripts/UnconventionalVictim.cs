using UnityEngine;

public class UnconventionalVictim : MonoBehaviour
{
    public bool debug = false;

    public virtual void OnLookAt(UnconventionalWeapon eye) { }
    public virtual void OnStareAt(UnconventionalWeapon eye) { }
    public virtual void OnLookAway(UnconventionalWeapon eye) { }
}
