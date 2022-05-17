using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsLocal : MonoBehaviour
{
    public bool isLocal;
    public static bool isLocalStatic;

    public void Start()
    {
        isLocalStatic = isLocal;
    }

    public void Update()
    {
        if (isLocalStatic != isLocal)
        {
            isLocalStatic = isLocal;
        }
    }
}
