using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {

    public GameObject water;

    private float smoothness;
    private float speed;
    private float height;
    private float refraction;
    private Material waterMat;

    // Start is called before the first frame update
    void Start() {
        waterMat = water.GetComponent<MeshRenderer>().material;
        smoothness = waterMat.GetFloat("_Glossiness");
        speed = waterMat.GetFloat("_Speed");
        height = waterMat.GetFloat("_HeightScale");
        refraction = waterMat.GetFloat("_RefractionAmount");
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.Alpha1)) {
            smoothness += Input.mouseScrollDelta.y * 0.05f;
            smoothness = Mathf.Clamp(smoothness, 0f, 1f);
            waterMat.SetFloat("_Glossiness", smoothness);

        } else if (Input.GetKey(KeyCode.Alpha2)) {
            speed += Input.mouseScrollDelta.y * 0.01f;
            speed = Mathf.Clamp(speed, 0f, 1f);
            waterMat.SetFloat("_Speed", speed);

        } else if (Input.GetKey(KeyCode.Alpha3)) {
            height += Input.mouseScrollDelta.y * 0.1f;
            height = Mathf.Clamp(height, 0f, 5f);
            waterMat.SetFloat("_HeightScale", height);

        } else if (Input.GetKey(KeyCode.Alpha4)) {
            refraction += Input.mouseScrollDelta.y * 0.1f;
            refraction = Mathf.Clamp(refraction, 0f, 1f);
            waterMat.SetFloat("_RefractionAmount", refraction);
        }

    }
}
