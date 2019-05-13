using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporterScript : MonoBehaviour {

    public Transform player;
    public Transform reciever;
    public bool tron;
    public GameObject tronObj;
    private bool isOverlapping;

    // Update is called once per frame
    void Update() {
        if (isOverlapping) {
            Vector3 portalToPlayer = (player.position - transform.position);
            //portalToPlayer.y -= 2;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            if (dotProduct < 0) {
                float rotationDiff = Quaternion.Angle(transform.rotation, reciever.rotation);
                rotationDiff += 180;
                player.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                player.position = reciever.position - positionOffset;

                isOverlapping = false;
            }
        }
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            isOverlapping = true;
            if (tron) {
                tronObj.GetComponent<MeshRenderer>().material.SetInt("_ZTest", 1);
                player.GetChild(0).GetComponent<RenderEffectBloom>().BloomFactor = 0;
            }
            else {
                tronObj.GetComponent<MeshRenderer>().material.SetInt("_ZTest", 0);
                player.GetChild(0).GetComponent<RenderEffectBloom>().BloomFactor = 8;
            }
        }
    }

    void OnTriggerExit(Collider other) {
        if (other.CompareTag("Player")) {
            isOverlapping = false;
        }
    }
}
