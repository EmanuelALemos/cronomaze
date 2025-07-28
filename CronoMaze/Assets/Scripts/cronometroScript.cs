using UnityEngine;
using TMPro;

public class cronometroScript : MonoBehaviour
{
    public TextMeshProUGUI textoCronometro;
    public float tempoRestante = 600f;
    public bool contando = true;

    // Update is called once per frame
    void Update()
    {
        if (contando && tempoRestante > 0) {
            tempoRestante -= Time.deltaTime;
            if(tempoRestante < 0){
                tempoRestante = 0;
            }
            int minutos = Mathf.FloorToInt(tempoRestante / 60);
            int segundos = Mathf.FloorToInt(tempoRestante % 60);

            if(textoCronometro != null) {
                textoCronometro.text = string.Format("{0:00}:{1:00}", minutos, segundos);

            }


            if(tempoRestante <= 0){
                TempoEsgotado();
            }
        }
    }

    void TempoEsgotado(){
        contando = false;
    }

    public void PausarCronometro(){
        contando = false;
    }

    public void ContinuarCronometro(){
        contando = true;
    }

    public void ResetarCroometro(){
        tempoRestante = 0f;
        textoCronometro.text = "00:00";
    }
}
