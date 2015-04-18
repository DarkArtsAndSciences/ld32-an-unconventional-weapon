using UnityEngine;
using System.Collections;

public class Shy : UnconventionalVictim
{
    private Vector3 startingPosition;
    private float anxiety = 0.0f;

    void Start()
    {
        startingPosition = transform.position;
    }

    void Update()
    {
        anxiety -= 0.01f;
        if (anxiety > 10.0f)
            transform.Translate(0.0f, 0.001f * anxiety, 0.0f);  // TODO: away from eye, maybe more random with more anxiety
        else
            transform.position = (transform.position + startingPosition) / 2.0f;
    }

    public override void OnLookAt(UnconventionalWeapon eye)
    {
        Debug.Log("Help! " + eye.name + " is looking at me!  " + anxiety);
    }

    public override void OnLookAway(UnconventionalWeapon eye)
    {
        Debug.Log("Nevermind, " + eye.name + " left me alone.  " + anxiety);
    }

    public override void OnStareAt(UnconventionalWeapon eye)
    {
        anxiety += 0.1f;  // TODO: * distance from self to eye
    }
}
