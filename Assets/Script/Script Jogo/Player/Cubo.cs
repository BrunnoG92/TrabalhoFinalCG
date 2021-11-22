using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cubo : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody P_Cubo;
    public float Velocidade = 1f;
    private Vector3 PraFrente;
    public int Qtnd_Pulo =1;
    public float Forca_Pulo = 1;
    public AudioSource SomMoeda;
    public AudioSource SomImpacto;
    public Text Pontuacao;
    public Text Tempo_Decorrido;
    private float Tempo;
    private int Pontos;
    public string NomeDaCena;


    void Start()
    {
        Pontos = 0;
        P_Cubo = GetComponent<Rigidbody>();
        PegaMoeda();

    }

    // Update is called once per frame
    public void MudarCena()
    {
        SceneManager.LoadScene(NomeDaCena);
    }

    void Update()
    {
       
        PraFrente = new Vector3(0, 0, 1) * Velocidade; // Vetor de movimento. Sempre movimenta pra frente
        if (Input.GetKeyDown (KeyCode.Space) && Qtnd_Pulo > 0)
        {
            P_Cubo.AddForce(new Vector3(0, 7, 0) * Forca_Pulo, ForceMode.Impulse);
            print("Pulou");
            Qtnd_Pulo--;
        }
        if (Qtnd_Pulo == 0)
        {
            P_Cubo.AddForce(new Vector3(0, -0.03f, 0) * Forca_Pulo, ForceMode.Impulse); // For�a negativa, aumentar vel queda quando no ar
        }

        // Cronometro
            Tempo += Time.deltaTime;
            TimeSpan time = TimeSpan.FromSeconds(Tempo);
            Tempo_Decorrido.text = time.ToString(@"hh\:mm\:ss");

        




    }

    IEnumerator TrocarCenario()
    {   // IE numerator para aguardar antes da troca do cen�rio. usado para tocar o som de colis�o com o inimigo
        yield return new WaitForSeconds(0.7f);
        MudarCena();
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);
        Destroy(Camera.main.gameObject);


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
           // Cubo est� no ch�o. A quantidade de pulo � definida em 1 
            Qtnd_Pulo = 1;
        }
        else
        {
            PraFrente = new Vector3(0, -1, 1) * Velocidade; // Vetor de movimento. Sempre movimenta pra frente
           
        }
        if (Posicao_Cubo == "Inimigo")
        {
            // Colis�o com inimigo
            SomImpacto.Play();
            StartCoroutine(TrocarCenario());
            Destroy(collision.gameObject);
           
           



        }

    }
   
    private void OnTriggerEnter(Collider other)
    {
        
        var Posicao = other.gameObject.tag;
        if (Posicao == "Moeda")
        {
            Destroy(other.gameObject);
            SomMoeda.Play();
            Pontos += 10;
            PegaMoeda();
          
        }
    }

    private void PegaMoeda()
    {
        Pontuacao.text = "Pontos: " + Pontos.ToString();
    }

}
