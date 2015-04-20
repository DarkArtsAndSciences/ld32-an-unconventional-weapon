using UnityEngine;
using System.Collections;

public class Stepchild : MonoBehaviour
{
    public GameObject stepParent;

    public enum InheritType
    {
        world, local, ignore
    }
    public InheritType inheritPositionX, inheritPositionY, inheritPositionZ;
    public InheritType inheritRotationX, inheritRotationY, inheritRotationZ;

    void Update()
    {
        switch (inheritPositionX)
        {
            case InheritType.world:
                transform.position = new Vector3(stepParent.transform.position.x, transform.position.y, transform.position.z);
                break;
            case InheritType.local:
                transform.localPosition = new Vector3(stepParent.transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
                break;
        }
        switch (inheritPositionY)
        {
            case InheritType.world:
                transform.position = new Vector3(transform.position.x, stepParent.transform.position.y, transform.position.z);
                break;
            case InheritType.local:
                transform.localPosition = new Vector3(transform.localPosition.x, stepParent.transform.localPosition.y, transform.localPosition.z);
                break;
        }
        switch (inheritPositionZ)
        {
            case InheritType.world:
                transform.position = new Vector3(transform.position.x, transform.position.y, stepParent.transform.position.z);
                break;
            case InheritType.local:
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, stepParent.transform.localPosition.z);
                break;
        }

        switch (inheritRotationX)
        {
            case InheritType.world:
                transform.rotation = Quaternion.Euler(stepParent.transform.rotation.x, transform.rotation.y, transform.rotation.z);
                break;
            case InheritType.local:
                transform.localRotation = Quaternion.Euler(stepParent.transform.localRotation.x, transform.localRotation.y, transform.localRotation.z);
                break;
        }
        switch (inheritRotationY)
        {
            case InheritType.world:
                transform.rotation = Quaternion.Euler(transform.rotation.x, stepParent.transform.rotation.y, transform.rotation.z);
                break;
            case InheritType.local:
                transform.localRotation = Quaternion.Euler(transform.localRotation.x, stepParent.transform.localRotation.y, transform.localRotation.z);
                break;
        }
        switch (inheritRotationZ)
        {
            case InheritType.world:
                transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, stepParent.transform.rotation.z);
                break;
            case InheritType.local:
                transform.localRotation = Quaternion.Euler(transform.localRotation.x, transform.localRotation.y, stepParent.transform.localRotation.z);
                break;
        }
    }
}
