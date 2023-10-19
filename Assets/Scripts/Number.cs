using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Number : MonoBehaviour
{
    public int value;
    [SerializeField]
    float timeToDestroy;
    bool colected = false;
    bool colectedByPlayer2 = false;

    GameObject numberSpawner;
    GameObject player;
    GameObject player2;
    IEnumerator destroyCoroutine;

    private void Start()
    {
        gameObject.LeanScale(new Vector3(70f, 70f, 70f), 0.9f).setLoopPingPong();
        transform.Rotate(-45f, 0, 0);
        destroyCoroutine = destroyLifetime();
        numberSpawner = GameObject.FindGameObjectWithTag("Spawner");

        player = GameObject.FindGameObjectWithTag("Player"); //Coleta referencia do Player 1
        player2 = GameObject.FindGameObjectWithTag("Player 2"); // Coleta referencia do Player 2

        StartCoroutine(destroyCoroutine); // Starta corrotina que destroi o numero.
    }

    private void Update()
    {
        if (colected == true) //Faz o numero ficar acima da cabe�a do player.
        {
            transform.position = new Vector3(player.transform.position.x, 4, player.transform.position.z);
            gameObject.tag = "CollectedP1";
        }

        if (colectedByPlayer2 == true) //Faz o numero ficar acima da cabe�a do player.
        {
            transform.position = new Vector3(player2.transform.position.x, 4, player2.transform.position.z);
            gameObject.tag = "CollectedP2";
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        //Mecanica de Coletar o Numero. 
        if (other.CompareTag("Player 2") && player2.GetComponent<CharacterControl>().colectedByPlayer2 == false)
        {
            colected = false;
            colectedByPlayer2 = true;
            player2.GetComponent<CharacterControl>().colectedByPlayer2 = true;
            this.GetComponent<AudioSource>().Play();
            StopCoroutine(destroyCoroutine);

        }

        if (other.CompareTag("Player") && player.GetComponent<CharacterControl>().colected == false)
        {
            colected = true;
            player.GetComponent<CharacterControl>().colected = true;
            this.GetComponent<AudioSource>().Play();
            StopCoroutine(destroyCoroutine);

        }
    }

    IEnumerator destroyLifetime()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
        numberSpawner.GetComponent<Spawner>().spawned--;
    }
}
