using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseWallBehaviour : MonoBehaviour {
    private float scrollingSpeed;
    private float ceiling;
    private float floor;
    public int id;
    public int idLeader;

    private void Start() {
        scrollingSpeed = ScrollingManagerBehaviour.instance.wallSpeed;
        ceiling = ScrollingManagerBehaviour.instance.ceiling;
    }

    private void Update() {
        if(gameObject.transform.position.y >= ceiling) {
            ScrollingManagerBehaviour.instance.ResetWallTile(id, idLeader);
        }
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + scrollingSpeed*Time.deltaTime, gameObject.transform.position.z);
    }
}
