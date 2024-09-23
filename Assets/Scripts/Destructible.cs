using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public GameObject destroyedVersion;    // Prefab da versão destruída (com pedaços)
    public float scatterForce = 500f;      // Força aplicada aos pedaços

    void OnCollisionEnter(Collision collision)
    {
        // Se colidir com o player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Loop para instanciar os pedaços destruídos
            for (int i = 0; i < destroyedVersion.transform.childCount; i++)
            {
                // Instancia o pedaço do objeto destruído
                GameObject part = Instantiate(destroyedVersion.transform.GetChild(i).gameObject, 
                                              this.transform.position, 
                                              this.transform.rotation);
                
                // Verifica se o pedaço tem um Rigidbody, se não tiver, adiciona
                Rigidbody rb = part.GetComponent<Rigidbody>();
                if (rb == null)
                {
                    rb = part.AddComponent<Rigidbody>();
                }

                // Calcula uma direção de espalhamento baseada na posição do pedaço
                Vector3 direction = (part.transform.position - this.transform.position).normalized;

                // Aplica força na direção oposta ao centro do objeto destruído
                rb.AddForce(direction * scatterForce);
            }

            // Destroi o objeto original
            Destroy(gameObject);
            Debug.Log("Destruição e espalhamento funcionam!");
        }
    }
}
