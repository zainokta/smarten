using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{

    public static sceneManager instance { get; private set; }

    public GameObject disastah;
    public GameObject waow;
    public int level = 1;
    public GameObject pauseScreen;
    private bool paused;

    private void Awake()
    {
        if (instance != null && instance != this) { Destroy(gameObject); }
        instance = this;
        DontDestroyOnLoad(gameObject);
        paused = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && paused == false)
        {
            pauseScreen.SetActive(true);
            paused = true;
            Time.timeScale = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && paused == true)
        {
            pauseScreen.SetActive(false);
            paused = false;
            Time.timeScale = 1;
        }
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(level);
    }

    public void GameExit()
    {
        Application.Quit();
    }
    
    public void PlayDisastah()
    {
        Instantiate(disastah, transform.position, Quaternion.identity);
    }
    public void PlayWaow()
    {
        Instantiate(waow, transform.position, Quaternion.identity);
    }
    
}