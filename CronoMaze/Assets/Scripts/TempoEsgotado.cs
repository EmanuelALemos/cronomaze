using UnityEngine;
using UnityEngine.SceneManagement;

public class TempoEsgotado : MonoBehaviour
{
    public void NovoJogo(){
        SceneManager.LoadScene("gameunity");
    }

    public void VoltarMenu(){
        SceneManager.LoadScene("menuInicialScene");
    }
}
