using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    private Renderer msh;
    [SerializeField] float speed = 0.5f;

    void Start()
    {
        msh = GetComponent<Renderer>();
    }

    
    void Update()
    {
        /*
        Vector2 offset = meshRenderer.material.mainTextureOffset;
        offset = offset + new Vector2(0,speed * Time.deltaTime);
        meshRenderer.material.mainTextureOffset = offset;
        */

        msh.material.mainTextureOffset += new Vector2(0, speed * Time.deltaTime);
    }
}
