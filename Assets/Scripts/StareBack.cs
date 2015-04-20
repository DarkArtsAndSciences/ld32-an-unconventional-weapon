using UnityEngine;
using System.Collections;

public class StareBack : UnconventionalVictim
{
    public bool randomize = true;
    public float bodyTurnSpeed = 1.0f;
    public float headTurnSpeed = 0.5f;
    public GameObject head;
    public GameObject[] eyes;
    public Material normalHeadMaterial, angryHeadMaterial, normalEyeMaterial, angryEyeMaterial;

    void Start()
    {
        if (randomize)
        {
            bodyTurnSpeed = Random.Range(0.25f, 5.0f);
            headTurnSpeed = Random.Range(0.1f, 2.0f);
        }

        OnLookAway(null);
    }

    public override void OnLookAt(UnconventionalWeapon uw)
    {
        if (head && angryHeadMaterial) head.renderer.sharedMaterial = angryHeadMaterial;
        if ((eyes.Length > 1) && angryEyeMaterial) 
            foreach(GameObject eye in eyes)
                eye.renderer.sharedMaterial = angryEyeMaterial;
    }

    public override void OnLookAway(UnconventionalWeapon uw)
    {
        if (head && normalHeadMaterial) head.renderer.sharedMaterial = normalHeadMaterial;
        if ((eyes.Length > 1) && normalEyeMaterial)
            foreach (GameObject eye in eyes)
                eye.renderer.sharedMaterial = normalEyeMaterial;
    }

    public override void OnStareAt(UnconventionalWeapon uw)
    {
        transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(
            transform.forward, 
            new Vector3(uw.transform.position.x - transform.position.x, 0, uw.transform.position.z - transform.position.z), 
            bodyTurnSpeed * Time.deltaTime, 0.0f));

        if (head)
            head.transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(
                head.transform.forward, 
                uw.transform.position - head.transform.position, 
                headTurnSpeed * Time.deltaTime, 0.0f));
    }

    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward);
        if (head)
            Debug.DrawRay(head.transform.position, head.transform.forward);
    }
}
