using System.Collections;
using UnityEngine;

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
        transform.Rotate(-45f, 0, 0);
        destroyCoroutine = destroyLifetime();
        numberSpawner = GameObject.FindGameObjectWithTag("Spawner");

        player = GameObject.FindGameObjectWithTag("Player"); //Coleta referencia do Player 1
        player2 = GameObject.FindGameObjectWithTag("Player 2"); // Coleta referencia do Player 2

        StartCoroutine(destroyCoroutine); // Starta corrotina que destroi o numero.
    }

    private void Update()
    {
        if (colected == true)
        {
            transform.position = new Vector3(player.transform.position.x, 4, player.transform.position.z);
        }

        if (colectedByPlayer2 == true)
        {
            transform.position = new Vector3(player2.transform.position.x, 4, player2.transform.position.z);
        }


        // Implementaçao do Drop Number.
        if (Input.GetKeyDown(KeyCode.F) && colected == true)
        {
            Destroy(gameObject);
            player.GetComponent<SimpleSampleCharacterControl>().colected = false;
        }

        if (Input.GetKeyDown(KeyCode.RightControl) && colectedByPlayer2 == true)
        {
            Destroy(gameObject);
            player2.GetComponent<SimpleSampleCharacterControl>().colectedByPlayer2 = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player 2") && player2.GetComponent<SimpleSampleCharacterControl>().colectedByPlayer2 == false)
        {
            colectedByPlayer2 = true;
            player2.GetComponent<SimpleSampleCharacterControl>().colectedByPlayer2 = true;
            this.GetComponent<AudioSource>().Play();
            StopCoroutine(destroyCoroutine);
            //StartCoroutine(colect());
        }

        if (other.CompareTag("Player") && player.GetComponent<SimpleSampleCharacterControl>().colected == false)
        {
            colected = true;
            player.GetComponent<SimpleSampleCharacterControl>().colected = true;
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
