using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubo : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody P_Cubo;
    public float Velocidade = 1f;
    private Vector3 PraFrente;
    public int Qtnd_Pulo =1;
    public float Forca_Pulo = 1;
    void Start()
    {
        P_Cubo = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        PraFrente = new Vector3(0, 0, 1) * Velocidade; // Vetor de movimento. Sempre movimenta pra frente
        if (Input.GetKeyDown (KeyCode.Space) && Qtnd_Pulo > 0)
        {
            P_Cubo.AddForce(new Vector3(0, 5, 0) * Forca_Pulo, ForceMode.Impulse);
            print("Pulou");
            Qtnd_Pulo--;
        }
        if (Qtnd_Pulo == 0)
        {
            P_Cubo.AddForce(new Vector3(0, -0.03f, 0) * Forca_Pulo, ForceMode.Impulse); // Força negativa, aumentar vel queda quando no ar
        }
        

      
    }
    private void FixedUpdate()
    {
        P_Cubo.velocity = PraFrente;
    }
    private void OnCollisionEnter(Collision collision)
    {   
        var Posicao_Cubo = collision.gameObject.tag;
        if (Posicao_Cubo == "Cenario")
        {
           // Cubo está no chão. A quantidade de pulo é definida em 1 
            Qtnd_Pulo = 1;
        }
        else
        {
            PraFrente = new Vector3(0, -1, 1) * Velocidade; // Vetor de movimento. Sempre movimenta pra frente
            print("No ar");
        }
        
    }
}
