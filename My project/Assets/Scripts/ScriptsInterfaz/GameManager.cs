using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Cinemachine.DocumentationSortingAttribute;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PerfilJugador perfilJugador;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private GameObject gameOverMenu;
    [SerializeField] private GameObject victoryMenu;
    [SerializeField] private AudioSource music;
    private bool isPaused = false;
    private void Start()
    {
        pauseMenu.SetActive(false);
        gameOverMenu.SetActive(false);
        victoryMenu.SetActive(false);
        perfilJugador.RocososEnojadosEliminados = perfilJugador.ValorReinicioRocososEnojados;
        perfilJugador.RocososComunesEliminados = perfilJugador.ValorReinicioRocososComunes;
        perfilJugador.GranRocosoEliminado = perfilJugador.ValorReinicioGranRocoso;
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
        perfilJugador.RocososEnojadosEliminados = perfilJugador.ValorReinicioRocososEnojados;
        perfilJugador.RocososComunesEliminados = perfilJugador.ValorReinicioRocososComunes;
        perfilJugador.GranRocosoEliminado = perfilJugador.ValorReinicioGranRocoso;
    }
}
