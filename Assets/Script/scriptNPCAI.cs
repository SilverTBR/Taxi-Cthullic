using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptNPCAI : MonoBehaviour
{
    public enum AIMode { seguirPC, seguirRota};

    public AIMode aimode;

    Vector3 posicaoAlvo = Vector3.zero;
    Transform transformAlvo = null;

    ScriptCarro scriptCarro;
    // Start is called before the first frame update
    void Awake()
    {
        scriptCarro = GetComponent<ScriptCarro>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 inputVector = Vector2.zero;


        detectarPC();
        inputVector.x = virarAoAlvo();
        inputVector.y = 1f;

        scriptCarro.definirInput(inputVector);
    }

    void detectarParede()
    {
        //RaycastHit2D hitParede = Physics2D.Raycast
    }

    void detectarPC()
    {
        posicaoAlvo = GameObject.FindGameObjectWithTag("Player").transform.position;
    }

    float virarAoAlvo()
    {
        Vector2 distanciaAlvo = posicaoAlvo - transform.position;
        distanciaAlvo.Normalize();

        float anguloAoAlvo = Vector2.SignedAngle(transform.up, distanciaAlvo);
        anguloAoAlvo *= -1;

        float quantoVirar = anguloAoAlvo / 45.0f;

        quantoVirar = Mathf.Clamp(quantoVirar, -1f, 1f);

        return quantoVirar;
    }
}
