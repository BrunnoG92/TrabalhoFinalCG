using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Troca_Cena : MonoBehaviour
{
    public string NomeDaCena;
    
    public void MudarCena()
    {
        SceneManager.LoadScene(NomeDaCena);
    }
    public void Sair()
    {
        Application.Quit();
    }
}
