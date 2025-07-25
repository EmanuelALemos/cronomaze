using UnityEngine;
using UnityEngine.SceneManagement;

public class movimentacaoScript : MonoBehaviour
{
    public float velocidade = 0.05f;
    public Transform cameraTransform;
    private Rigidbody rb;
    private bool caiu = false;
    private statusJogadorScript status;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        status = GetComponent<statusJogadorScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A)){
            // this.gameObject.transform.position = this.gameObject.transform.position + Vector3.left * velocidade;
            this.gameObject.transform.Rotate(Vector3.up,-1f);
        }
        if(Input.GetKey(KeyCode.D)){
            // this.gameObject.transform.position = this.gameObject.transform.position + Vector3.right * velocidade;
            this.gameObject.transform.Rotate(Vector3.up,1f);
        }
        Vector3 cameraForward = cameraTransform.forward;
        cameraForward.y = 0;
        cameraForward.Normalize();
        if(Input.GetKey(KeyCode.S)){
            // this.gameObject.transform.position = this.gameObject.transform.position + this.gameObject.transform.forward * -1f* velocidade;
            // this.gameObject.transform.position += Vector3.back * velocidade;
            transform.position -= cameraForward * velocidade;
        }
        if(Input.GetKey(KeyCode.W)){
            // this.gameObject.transform.position = this.gameObject.transform.position + this.gameObject.transform.forward * velocidade;
            // this.gameObject.transform.position += Vector3.forward * velocidade; 
            transform.position += cameraForward * velocidade;
        }
        if(caiu = false && transform.position.y < 0){
            status.removeVida();
            caiu = true;
        }
    }

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag.Equals("Enemy")){
            rb.AddForce(Vector3.back*700);
            status.removeVida();
        }
        if(other.gameObject.tag.Equals("Fence") || other.gameObject.tag.Equals("Pillar")){
            rb.AddForce(Vector3.back*100);
        }
    }
}
