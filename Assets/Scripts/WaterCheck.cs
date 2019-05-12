using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterCheck : MonoBehaviour {

    void OnTriggerEnter(Collider other) {
        //Debug.Log("Trigger");
        if (other.CompareTag("Tree")) {
            //Debug.Log(other.name);
            Destroy(other.gameObject);
        }
    }
}
