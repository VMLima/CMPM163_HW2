using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCamera : MonoBehaviour {

    public Transform playerCamera;
    public Transform portal;
    public Transform otherPortal;

    // Update is called once per frame
    void Update() {
        Vector3 playerOffsetFromPortal = playerCamera.position - otherPortal.position;
        transform.position = portal.position + playerOffsetFromPortal;

        float angularDiff = Quaternion.Angle(portal.rotation, otherPortal.rotation);
        angularDiff += 180;
        Quaternion portalRoataionalDiff = Quaternion.AngleAxis(angularDiff, Vector3.up);
        Vector3 newCameraDirection = portalRoataionalDiff * playerCamera.forward;
        transform.rotation = Quaternion.LookRotation(newCameraDirection, Vector3.up);
        //transform.eulerAngles = new Vector3(transform.rotation.x, -transform.rotation.y, transform.rotation.z);
        //transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y + 180, transform.rotation.z);
    }
}
