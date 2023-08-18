using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paralax : MonoBehaviour
{
    [SerializeField] private float _scrollSpeed = 0.5f;
    public bool _isScrolling = true;
    private float _offset;
    private Material mat;

    void Start()
    {
        mat = GetComponent<Renderer>().material;

    } //start

    void Update()
    {
        if (_isScrolling)
        {
            _offset += (Time.deltaTime * _scrollSpeed) / 10;
            mat.SetTextureOffset("_MainTex", new Vector2(_offset, 0));
        }
        else
        {
            _offset = 0;     //stop scrooling the background
        }
    }//update
}
