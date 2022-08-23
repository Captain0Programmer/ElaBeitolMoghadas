using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSize : MonoBehaviour
{
    private void Start()
    {
        Camera.main.aspect = 2160f / 1080f;
    }
}
