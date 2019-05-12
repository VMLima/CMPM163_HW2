using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainController : MonoBehaviour {

    public MapGenerator mapGen;
    public float treeProbability = 0.025f;
    public float rockProbability = 0.1f;
    public List<GameObject> trees;
    public List<GameObject> rocks;

    private Vector3 pos;
    private MeshFilter mf;

    // Start is called before the first frame update
    void Awake() {
        GetComponent<MeshCollider>().sharedMesh = GetComponent<MeshFilter>().sharedMesh;
        mf = GetComponent<MeshFilter>();
        mapGen.GenerateMap();
        PlaceTrees();
    }

    void PlaceTrees() {
        for (int i = 0; i < mf.sharedMesh.vertexCount; i++) {
            float probablity = Random.Range(0f, 1f);
            if (probablity < treeProbability) {
                pos = mf.sharedMesh.vertices[i];
                pos = mf.transform.TransformPoint(pos);
                GameObject tree = Instantiate(trees[Random.Range(0, trees.Count)]);
                tree.transform.position = pos;
            } else if (probablity > treeProbability && probablity < rockProbability) {
                pos = mf.sharedMesh.vertices[i];
                pos = mf.transform.TransformPoint(pos);
                GameObject rock = Instantiate(rocks[Random.Range(0, rocks.Count)]);
                rock.transform.position = pos;
            }
        }

    }
}
