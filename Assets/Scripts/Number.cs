using System.Collections;
using UnityEngine;

public class Number : MonoBehaviour
{
    public int value;
    [SerializeField]
    float timeToDestroy;
    public bool colected = false;
    public bool colectedByPlayer2 = false;

    GameObject numberSpawner;
    GameObject player;
    GameObject player2;
    IEnumerator destroyCoroutine;

    private void Start()
    {
        transform.Rotate(-45f, 0, 0);
        destroyCoroutine = destroyLifetime();
        numberSpawner = GameObject.FindGameObjectWithTag("Spawner");

        player = GameObject.FindGameObjectWithTag("Player"); //Coleta referencia do Player 1
        player2 = GameObject.FindGameObjectWithTag("Player 2"); // Coleta referencia do Player 2

        StartCoroutine(destroyCoroutine); // Starta corrotina que destroi o numero.
    }

    private void Update()
    {
        if (colected == true) // Faz o numero ficar acima da cabeça quando coletado.
        {
            transform.position = new Vector3(player.transform.position.x, 4, player.transform.position.z);
            gameObject.tag = "CollectedNumberP1"; //Marca o prefab do numero como Coletado por player1
        }

        if (colectedByPlayer2 == true) // Faz o numero ficar acima da cabeça quando coletado.
        {
            transform.position = new Vector3(player2.transform.position.x, 4, player2.transform.position.z);
            gameObject.tag = "CollectedNumberP2"; //marca o prefab como coletado pelo player 2
        }


        // Implementaçao do Drop Number.
        if (Input.GetKeyDown(KeyCode.F) && colected == true)
        {
            Destroy(gameObject);
            player.GetComponent<Player1>().colected = false;
        }



        if (Input.GetKeyDown(KeyCode.RightShift) && colectedByPlayer2 == true)
        {
            Destroy(gameObject);
            player2.GetComponent<Player2>().colectedByPlayer2 = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player 2") && player2.GetComponent<Player2>().colectedByPlayer2 == false)
        {
            colectedByPlayer2 = true;
            player2.GetComponent<Player2>().colectedByPlayer2 = true;
            player2.GetComponent<Player2>().p2CanSteal = false;
            this.GetComponent<AudioSource>().Play();
            StopCoroutine(destroyCoroutine);
            //StartCoroutine(colect());
        }

        if (other.CompareTag("Player") && player.GetComponent<Player1>().colected == false)
        {
            colected = true;
            player.GetComponent<Player1>().colected = true;
            player.GetComponent<Player1>().p1CanSteal = false;
            this.GetComponent<AudioSource>().Play();
            StopCoroutine(destroyCoroutine);
            //StartCoroutine(colect());
        }
    }

    IEnumerator destroyLifetime()
    {
        yield return new WaitForSeconds(timeToDestroy);
        Destroy(gameObject);
        numberSpawner.GetComponent<Spawner>().spawned--;
    }
}
