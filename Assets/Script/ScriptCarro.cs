using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCarro : MonoBehaviour
{
    public float driftFactor = 0.95f;
    public float aceleracao = 30.0f;
    public float velocidadeVirada = 3.5f;
    public float velocidadeMaxima = 20f;

    float inputAceleracao = 0, inputVirada = 0;
    float anguloRotacao = 0;

    float velocidadeVsUp = 0;

    Rigidbody2D rbd;
    void Awake()
    {
        rbd = GetComponent<Rigidbody2D>();
    }
    
    void eliminarVelocidadeOrtogonal()
    {
        Vector2 velocidadeFrontal = transform.up * Vector2.Dot(rbd.velocity, transform.up);
        Vector2 velocidadeLateral = transform.right * Vector2.Dot(rbd.velocity, transform.right);
    
        rbd.velocity = velocidadeFrontal + velocidadeLateral * driftFactor;
    }

    private void FixedUpdate()
    {
        AplicarForcaMotor();
        eliminarVelocidadeOrtogonal();
        aplicarDirecao();

    }

    void AplicarForcaMotor()
    {
        velocidadeVsUp = Vector2.Dot(transform.up, rbd.velocity);

        //Limita velocidade de frente
        if((velocidadeVsUp > velocidadeMaxima && inputAceleracao > 0))
        {
            return;
        }
        //Limita velocidade de ré
        if(velocidadeVsUp < -velocidadeMaxima*0.5 && inputAceleracao < 0)
        {
            return;
        }
        if(rbd.velocity.magnitude > velocidadeMaxima * velocidadeMaxima && inputAceleracao > 0)
        {
            return;
        }

        if(inputAceleracao == 0)
        {
            rbd.drag = Mathf.Lerp(rbd.drag, 3.0f, Time.fixedDeltaTime * 3);
        }
        else
        {
            rbd.drag = 0;
        }
        Vector2 forcaMotorVector = transform.up * inputAceleracao * aceleracao;

        rbd.AddForce(forcaMotorVector, ForceMode2D.Force);
    }

    void aplicarDirecao()
    {
        //Da para virar o oito para verificar o quão bom vai ficando
        float velocidadeMinimaParaVirar = (rbd.velocity.magnitude / 8);
        velocidadeMinimaParaVirar = Mathf.Clamp01(velocidadeMinimaParaVirar);

        anguloRotacao -= inputVirada * velocidadeVirada * velocidadeMinimaParaVirar;

        rbd.MoveRotation(anguloRotacao);
    }



    public void definirInput(Vector2 inputVector)
    {
        inputVirada = inputVector.x;
        inputAceleracao = inputVector.y;
    }

}
