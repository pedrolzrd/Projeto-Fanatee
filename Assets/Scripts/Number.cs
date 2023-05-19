using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class Number : MonoBehaviour
{
    public int value;
    [SerializeField]
    float timeToDestroy;
    bool colected = false;

    PlayerInput playerInput;

    GameObject numberSpawner;
    GameObject player;
    IEnumerator destroyCoroutine;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        destroyCoroutine = destroyLifetime();
        numberSpawner = GameObject.FindGameObjectWithTag("Spawner");
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(destroyCoroutine);
    }

    private void Update()
    {
        if (colected == true)
        {
            transform.position = new Vector3(player.transform.position.x, 4, player.transform.position.z);
        }

#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.F) && colected == true)
        {
            Destroy(gameObject);
            player.GetComponent<SimpleSampleCharacterControl>().colected = false;
        }
#else
        if (playerInput.actions["DropNumber"].triggered && colected == true)
        {
            Destroy(gameObject);
            player.GetComponent<SimpleSampleCharacterControl>().colected = false;
        }
#endif


    }

    private void OnTriggerEnter(Collider other)
    {
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
