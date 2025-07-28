using UnityEngine;

public class ProjetilFantasmaScript : MonoBehaviour
{
    public float velocidade = 10f;
    public float tempoDeVida = 1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Destroy(gameObject, tempoDeVida);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.forward * velocidade * Time.deltaTime;
    }

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag.Equals("Player")){
            statusJogadorScript vidaJogador = other.GetComponent<statusJogadorScript>();
            vidaJogador.removeVida();
        }
    }
}
