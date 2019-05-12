using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour {

    public Camera cameraTron;
    public Camera cameraLandscape;
    public Material cameraMatTron;
    public Material cameraMatLandscape;

    // Start is called before the first frame update
    void Start() {
        if (cameraTron.targetTexture != null) {
            cameraTron.targetTexture.Release();
        }
        cameraTron.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMatTron.mainTexture = cameraTron.targetTexture;

        if (cameraLandscape.targetTexture != null) {
            cameraLandscape.targetTexture.Release();
        }
        cameraLandscape.targetTexture = new RenderTexture(Screen.width, Screen.height, 24);
        cameraMatLandscape.mainTexture = cameraLandscape.targetTexture;
    }
}
