using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPcInput : MonoBehaviour
{
    ScriptCarro scriptCarro;
    private void Awake()
    {
        scriptCarro = GetComponent<ScriptCarro>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector2 vectorInput = Vector2.zero;
        vectorInput.x = Input.GetAxis("Horizontal");
        vectorInput.y = Input.GetAxis("Vertical");

        scriptCarro.definirInput(vectorInput);        
    }
}
