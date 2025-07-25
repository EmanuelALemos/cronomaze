using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class statusJogadorScript : MonoBehaviour
{
    public Image barraVida;
    public TextMeshProUGUI vidaJogadorTexto;
    private int maximoVidas = 100;
    int vidasAtual;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.vidasAtual = this.maximoVidas;
        AtualizarUI();
    }

    public void removeVida() {
        this.vidasAtual = this.vidasAtual - 2;
        this.vidasAtual = Mathf.Clamp(vidasAtual, 0, maximoVidas);
        AtualizarUI();
        if(this.vidasAtual == 0){
            SceneManager.LoadScene("morreuScene");
        }
    }

    public void adicionaVida() {
        this.vidasAtual = this.vidasAtual + 20;
        this.vidasAtual = Mathf.Clamp(vidasAtual, 0, maximoVidas);
        AtualizarUI();
    }

    void AtualizarUI()
    {
        if(vidaJogadorTexto != null){
            vidaJogadorTexto.text = this.vidasAtual.ToString();
        }
        if(barraVida != null){
            barraVida.fillAmount = (float)this.vidasAtual / maximoVidas;
        }
    }
}
