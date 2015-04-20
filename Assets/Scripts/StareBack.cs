using UnityEngine;
using System.Collections;

public class StareBack : UnconventionalVictim
{
    public float bodyTurnSpeed = 1.0f;
    public float headTurnSpeed = 0.5f;
    public GameObject head;

    public override void OnStareAt(UnconventionalWeapon eye)
    {
        transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(
            transform.forward, 
            new Vector3(eye.transform.position.x - transform.position.x, 0, eye.transform.position.z - transform.position.z), 
            bodyTurnSpeed * Time.deltaTime, 0.0f));

        if (head)
            head.transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(
                head.transform.forward, 
                eye.transform.position - head.transform.position, 
                headTurnSpeed * Time.deltaTime, 0.0f));
    }

    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward);
        if (head)
            Debug.DrawRay(head.transform.position, head.transform.forward);
    }
}
