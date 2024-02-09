using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCamera : MonoBehaviour
{
    public GameObject pc;
    //Seria os x e y de deslocamento da camera para ela não ficar centralizda certin no pc
    public float x_offseat = 0;
    public float y_offseat = 0;
    // Start is called before the first frame update
    void Start()
    {        

    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 pos = new Vector3(pc.transform.position.x + x_offseat, pc.transform.position.y + y_offseat, -10);

        transform.position = pos;
    }
}
