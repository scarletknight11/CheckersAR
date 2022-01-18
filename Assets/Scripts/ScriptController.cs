using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptController : MonoBehaviour {

    private Transform scaleChange;
    public float size = 0.5f;

    public void ScaleUp()
    {
        scaleChange.localScale += new Vector3(size, 0, size);
    }

    public void ScaleDown()
    {
        scaleChange.localScale -= new Vector3(size, 0, size);
    }

}
