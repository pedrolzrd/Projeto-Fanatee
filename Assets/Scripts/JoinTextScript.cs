using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.InputSystem.UI;
using TMPro;

public class JoinTextScript : MonoBehaviour
{

    [Header("PressAToJoinTexts")]
    [SerializeField] public TextMeshProUGUI pressAtoJoinText;

    private void Start()
    {
        pressAtoJoinText.gameObject.LeanScale(new Vector3(1.2f, 1.2f), 0.9f).setLoopPingPong();
    }
}
