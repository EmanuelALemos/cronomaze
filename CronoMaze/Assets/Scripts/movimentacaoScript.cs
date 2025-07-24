using UnityEngine;

public class movimentacaoScript : MonoBehaviour
{
    public float velocidade = 0.05f;
    public Transform cameraTransform;
    private Rigidbody rb;
    private bool morreu = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow)){
            // this.gameObject.transform.position = this.gameObject.transform.position + Vector3.left * velocidade;
            this.gameObject.transform.Rotate(Vector3.up,-1f);
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            // this.gameObject.transform.position = this.gameObject.transform.position + Vector3.right * velocidade;
            this.gameObject.transform.Rotate(Vector3.up,1f);
        }
        Vector3 cameraForward = cameraTransform.forward;
        cameraForward.y = 0;
        cameraForward.Normalize();
        if(Input.GetKey(KeyCode.DownArrow)){
            // this.gameObject.transform.position = this.gameObject.transform.position + this.gameObject.transform.forward * -1f* velocidade;
            // this.gameObject.transform.position += Vector3.back * velocidade;
            transform.position -= cameraForward * velocidade;
        }
        if(Input.GetKey(KeyCode.UpArrow)){
            // this.gameObject.transform.position = this.gameObject.transform.position + this.gameObject.transform.forward * velocidade;
            // this.gameObject.transform.position += Vector3.forward * velocidade; 
            transform.position += cameraForward * velocidade;
        }
        if(morreu == false && transform.position.y < 0){
            Debug.Log("Morreu");
            morreu = true;
        }
    }

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag.Equals("Enemy")){
            rb.AddForce(Vector3.back*700);
        }
        if(other.gameObject.tag.Equals("Fence") || other.gameObject.tag.Equals("Pillar")){
            rb.AddForce(Vector3.back*100);
        }
    }
}
