using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public GameObject destroyedVersion;    // Prefab da vers�o destru�da (com peda�os)
    public float scatterForce = 500f;      // For�a aplicada aos peda�os

    void OnCollisionEnter(Collision collision)
    {
        // Se colidir com o player
        if (collision.gameObject.CompareTag("Player"))
        {
            // Loop para instanciar os peda�os destru�dos
            for (int i = 0; i < destroyedVersion.transform.childCount; i++)
            {
                // Instancia o peda�o do objeto destru�do
                GameObject part = Instantiate(destroyedVersion.transform.GetChild(i).gameObject, 
                                              this.transform.position, 
                                              this.transform.rotation);
                
                // Verifica se o peda�o tem um Rigidbody, se n�o tiver, adiciona
                Rigidbody rb = part.GetComponent<Rigidbody>();
                if (rb == null)
                {
                    rb = part.AddComponent<Rigidbody>();
                }

                // Calcula uma dire��o de espalhamento baseada na posi��o do peda�o
                Vector3 direction = (part.transform.position - this.transform.position).normalized;

                // Aplica for�a na dire��o oposta ao centro do objeto destru�do
                rb.AddForce(direction * scatterForce);
            }

            // Destroi o objeto original
            Destroy(gameObject);
            Debug.Log("Destrui��o e espalhamento funcionam!");
        }
    }
}
