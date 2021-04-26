using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public event System.Action<Block> OnBlockPressed;

    public Vector2Int coord;

    void OnMouseDown(){
        if(OnBlockPressed != null){
            OnBlockPressed(this);
        }
    }

    public void Initialize(Texture2D image, Vector2Int startingCoord){
        
        coord = startingCoord;

        GetComponent<MeshRenderer>().material.mainTexture = image;        

    }
}
