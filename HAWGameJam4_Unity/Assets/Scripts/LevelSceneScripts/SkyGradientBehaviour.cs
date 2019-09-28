using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyGradientBehaviour : MonoBehaviour {
    private Renderer rend;
    private void Awake() {
        rend = transform.GetComponent<Renderer>();
        rend.receiveShadows = false;
    }
}
