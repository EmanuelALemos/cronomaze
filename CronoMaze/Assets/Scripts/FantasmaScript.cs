using UnityEngine;

public class FantasmaScript : MonoBehaviour
{
    public Transform[] pontosPatrulha;
    float velocidadePatrulha = 2f;
    float distanciaAtaque = 6f;
    float tempoPerseguindo = 2f;
    public GameObject feixeLuzPrefab;

    private int indiceAtual = 0;
    private Transform jogador;
    private Rigidbody rb;
    private float tempoPerseguindoAtual = 0f;
    private bool perseguindo = false;
    public float tempoEntreAtaques = 1f;
    private float proximoAtaque = 0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        jogador = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float distanciaJogador = Vector3.Distance(transform.position, jogador.position);

        if(distanciaJogador <= distanciaAtaque){
            perseguindo = true;
            tempoPerseguindoAtual = tempoPerseguindo;
            AtacarJogador();
        }

        if(perseguindo){
            PerseguirJogador();
            tempoPerseguindoAtual -= Time.fixedDeltaTime;
            if(tempoPerseguindoAtual <= 0){
                perseguindo = false;
            }
        }else{
            Patrulhar();
        }
    }

    void Patrulhar(){
        Transform pontoDestino = pontosPatrulha[indiceAtual];
        Vector3 direcao = (pontoDestino.position - transform.position).normalized;
        rb.MovePosition(transform.position + direcao * velocidadePatrulha * Time.fixedDeltaTime);

        if(Vector3.Distance(transform.position, pontoDestino.position) < 0.5f){
            indiceAtual = (indiceAtual + 1) % pontosPatrulha.Length;
        }
    }

    void PerseguirJogador(){
        Vector3 direcao = (jogador.position - transform.position).normalized;
        rb.MovePosition(transform.position + direcao * velocidadePatrulha * Time.fixedDeltaTime);
    }

    void AtacarJogador(){
        if(Time.time >= proximoAtaque && feixeLuzPrefab != null){
            Vector3 direcao = (jogador.position - transform.position).normalized;
            Vector3 posicaoAtaque = transform.position + Vector3.up + direcao * 1f;
            Instantiate(feixeLuzPrefab, posicaoAtaque, Quaternion.LookRotation(jogador.position - transform.position));
            proximoAtaque = Time.time + tempoEntreAtaques;
        }
    }
}
