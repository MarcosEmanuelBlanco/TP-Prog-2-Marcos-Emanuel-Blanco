using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Cinemachine.DocumentationSortingAttribute;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    [SerializeField] private PerfilJugador perfilJugador;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject victoryMenu;
    [SerializeField] private AudioSource music;
    private bool isPaused = false;
    public int vidaSing;
    //public int RocESing;
    //public int RocCSing;
    //public int GranRocSing;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            //vidaSing = perfilJugador.Vida;
            perfilJugador.RocososEnojadosEliminados = perfilJugador.ValorReinicioRocososEnojados;
            perfilJugador.RocososComunesEliminados = perfilJugador.ValorReinicioRocososComunes;
            perfilJugador.GranRocosoEliminado = perfilJugador.ValorReinicioGranRocoso;
            //RocESing = perfilJugador.RocososEnojadosEliminados;
            //RocCSing = perfilJugador.RocososComunesEliminados;
            //GranRocSing = perfilJugador.GranRocosoEliminado;
            //perfilJugador.RocososEnojadosEliminados = GameManager.Instance.GetRocE();
            //perfilJugador.RocososComunesEliminados = GameManager.Instance.GetRocC();
            //perfilJugador.GranRocosoEliminado = GameManager.Instance.GetGranRoc();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void ModificarVidaSing(int puntos) { vidaSing += puntos; }
    //public void ModificarRocE(int puntos) { RocESing += puntos; }
    //public void ModificarRocC(int puntos) { RocCSing += puntos; }
    //public void ModificarGranRoc(int puntos) { GranRocSing += puntos; }
    public int GetVidaSing() {  return vidaSing; }
    //public int GetRocE() {  return RocESing; }
    //public int GetRocC() {  return RocCSing; }
    //public int GetGranRoc() {  return GranRocSing; }
    private void Start()
    {
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        victoryMenu.SetActive(false);

    }
    private void OnEnable()
    {
        GameEvents.OnGameOver += ShowGameOverMenu;
        GameEvents.OnVictory += ShowVictoryMenu;
        GameEvents.OnPause += Pause;
        GameEvents.OnResume += Resume;
    }
    private void OnDisable()
    {
        GameEvents.OnGameOver -= ShowGameOverMenu;
        GameEvents.OnVictory -= ShowVictoryMenu;
        GameEvents.OnPause -= Pause;
        GameEvents.OnResume -= Resume;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                GameEvents.TriggerResume();
            }
            else
            {
                GameEvents.TriggerPause();
            }
        }
        LoseLife();
        Win();
    }
    public void LoseLife()
    {
        if (perfilJugador.Vida <= 0)
        {
            GameEvents.TriggerGameOver();
        }
    }
    
    public void Win()
    {
        if (perfilJugador.GranRocosoEliminado == 1)
        {
            GameEvents.TriggerVictory();
        }
    }
    private void Pause()
    {
        isPaused = true;
        Time.timeScale = 0;
        pauseMenu.SetActive(true);
        music.Pause();
    }

    private void Resume()
    {
        isPaused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        music.Play();
    }

    private void ShowGameOverMenu()
    {
        gameOverMenu.SetActive(true);
        Invoke(nameof(RestartScene), 10f);
    }

    private void ShowVictoryMenu()
    {
        victoryMenu.SetActive(true);
    }

    private void RestartScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        perfilJugador.Vida = perfilJugador.VidaMaxima;
        perfilJugador.RocososEnojadosEliminados = perfilJugador.ValorReinicioRocososEnojados;
        perfilJugador.RocososComunesEliminados = perfilJugador.ValorReinicioRocososComunes;
        perfilJugador.GranRocosoEliminado = perfilJugador.ValorReinicioGranRocoso;
        //vidaSing = perfilJugador.Vida;
    }
}
