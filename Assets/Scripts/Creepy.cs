using UnityEngine;
using System.Collections;

public class Creepy : UnconventionalWeapon
{
    public Material blush;
    private Material lastMaterial;

    protected override void OnLookAway()
    {
        base.OnLookAway();

        if (target == null) return;
        target.renderer.sharedMaterial = lastMaterial;
    }

    protected override void OnLookAt()
    {
        base.OnLookAt();

        lastMaterial = hit.collider.gameObject.renderer.sharedMaterial;
        hit.collider.gameObject.renderer.sharedMaterial = blush;
    }
}
