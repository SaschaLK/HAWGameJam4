using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseWallBehaviour : MonoBehaviour {
    private float scrollingSpeed;
    private float ceiling;
    private float floor;
    public int id;
    public int idLeader;

    [SerializeField] Material[] wallMaterials;

    private void Start() {
        scrollingSpeed = ScrollingManagerBehaviour.instance.outerWallSpeed;
        ceiling = ScrollingManagerBehaviour.instance.ceiling;
        
        GetComponent<MeshRenderer>().material = wallMaterials[Random.Range(0, wallMaterials.Length)];
        
        if (id % 2 == 0)
        {
            GetComponent<MeshRenderer>().material.SetTextureScale("_MainTex", new Vector2(-1,1));
        }
    }

    private void Update() {
        if(gameObject.transform.position.y >= ceiling) {
            ScrollingManagerBehaviour.instance.ResetWallTile(id, idLeader);
        }
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + scrollingSpeed*Time.deltaTime, gameObject.transform.position.z);
    }
}
