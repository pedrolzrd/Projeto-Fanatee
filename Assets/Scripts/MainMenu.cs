using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.InputSystem.UI;

public class MainMenu : MonoBehaviour
{
    public Animator transition;
    [Space(10)]
    public GameObject playerSelectionMenu;

    public GameObject gameModeMenu;
    public GameObject gameModeButtons;

    [SerializeField]GameObject creditsMenu;

    public float transitionTime = 1;

    public GameObject timeisOverMenu;

    public GameObject crossfade;

    public GameObject mainMenu;

    [Header("Buttons")]
    public Button creditsButton;
    public Button playButton;
    public Button quitButton;
    public Button backButton;
    public Button freeForAllButton;
    public Button twoPlayerButton;

    [Header("Event System")]
    public MultiplayerEventSystem mEventSystem; //Usado pra controlar principalmente os botoes.  

    public void OpenGameModeMenu() //Abre o Menu com as opções FREE FOR ALL E COOP
    {
        gameModeMenu.SetActive(true); //Seta o Game Object gameModeMenu como Ativo.
        mEventSystem.SetSelectedGameObject(freeForAllButton.gameObject); //Força o Event System a dizer que o botao de Free For All é o primeiro botão Selecionado.
    }

    public void OpenPlayerSelection()
    {
        gameModeButtons.SetActive(false); // Seta o gameObject gameModeButtons como Falso pra sumir só os botoes e manter o fundo verde e o titulo.
        playerSelectionMenu.SetActive(true); //Seta o gameObject playerSelectionMenu como true. 
        mEventSystem.SetSelectedGameObject (twoPlayerButton.gameObject); // Força o eventSystem a dizer que o botao de 2 jogadores é o primeiro botao selecionavel.
    }

    public void CloseGameModeMenu()
    {
        gameModeMenu.SetActive(false);
        gameModeButtons.SetActive(true);
        playerSelectionMenu.SetActive(false);
        mEventSystem.SetSelectedGameObject(playButton.gameObject);  // Força o eventSystem a dizer que o botao PLAY é o primeiro botao selecionavel.
    }

    public void PlayGame()
    {
        StartCoroutine(LoadGame());
    }

    IEnumerator LoadGame()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene("Game");
    }

    public void backToMainMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void backtoMenu()
    {
        creditsMenu.GetComponent<CanvasGroup>().LeanAlpha(0, 0.2f); //Leva o alpha do Credits menu pra 0 em 0.2segundos pra ficar mais smooth.
        mainMenu.GetComponent<CanvasGroup>().LeanAlpha(1, 0.2f); //Leva o alpha do MainMenu pra 1 em 0.2 seg.

        mEventSystem.SetSelectedGameObject(playButton.gameObject); //Seta o Playbutton como o primeiro botao selecionavel.
        playButton.interactable = true; // seta o playbutton como interagivel.
        quitButton.interactable = true; //seta o quitbutton como interagivel.
    }

    public void OpenCreditsMenu()
    {
        creditsMenu.SetActive(true); //Seta o credits Menu como ativo.
        mainMenu.GetComponent<CanvasGroup>().LeanAlpha(0, 0.2f); //Leva o alpha do mainmenu pra 0 e 0.2segundos
        mEventSystem.SetSelectedGameObject(backButton.gameObject); //marca o BACK button como o primeiro selecionalve.
        if (backButton.interactable == false) //
        {
            backButton.interactable = true;  //Se o botao back está como falso seta como true. 
        }

        if (creditsMenu.GetComponent<CanvasGroup>().alpha == 0) //
        {
            creditsMenu.GetComponent<CanvasGroup>().LeanAlpha(1, 0.2f);//Se o creditsMenu alpha é 0 seta pra 1 em 0.2segundos.
        } //
        
        playButton.interactable = false; //Seta o playbutton pra NAO interagivel pra o player n ativar sem querer qunado ele ta transparente.
        quitButton.interactable = false; //Seta o playbutton pra NAO interagivel pra o player n ativar sem querer qunado ele ta transparente.

    }
    public void QuitGame()
    {
        print("quit game");
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void QuitMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
