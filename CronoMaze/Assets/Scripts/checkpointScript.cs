using UnityEngine;

public class checkpointScript : MonoBehaviour
{
    public GameObject salvarUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        salvarUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other){
        if (other.gameObject.tag.Equals("Player")){
            salvarUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other){
        if (other.gameObject.tag.Equals("Player")){
            salvarUI.SetActive(false);
        }
    }

    public void SalvarPosicao(){
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        movimentacaoScript controller = player.GetComponent<movimentacaoScript>();
        controller.SalvarPosicaoAtual(transform.position);
        salvarUI.SetActive(false);
    }

    public void NaoSalvar(){
        salvarUI.SetActive(false);
    }
}
