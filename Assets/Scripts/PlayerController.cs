using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public void OnMove(float x, float y)
    {
        this.gameObject.transform.position += new Vector3(x,y,0);
        Debug.Log(String.Format("{0} {1}", x, y));
    }
}
