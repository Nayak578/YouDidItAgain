using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool switched;
    public GameObject Borde_1;
    public GameObject Borde_2;
    public GameObject Borde_3;
    public TextMeshProUGUI switchCanvas;
    public Image switchImage;
    public bool change = false;
    public bool switching = false;
    public bool red_variable = false;
    public bool green_variable = false;
    public bool cyan_variable = false;
    public bool yellow_variable = false;
    public GameObject gameOverPanel; // Assign this in Inspector
    public Canvas canvas;
    public TextMeshProUGUI scoreText;
    public Image fadeImage;
    public GameObject endImage;
    private int i = 1;
    public Spawner sp;
    private int popcount = 0;
    private Color[] hdrColors;
    Renderer renderer1;
    Renderer renderer2;
    Renderer renderer3;
    public float intensity = 3f;
    private void Start()
    {
        StartCoroutine(ToggleChange());
    }

    private void Awake()
    {
        renderer1 = Borde_1.GetComponent<Renderer>();
        renderer2 = Borde_2.GetComponent<Renderer>();
        renderer3 = Borde_3.GetComponent<Renderer>();

        hdrColors = new Color[4];
        Color hdrRed = new Color(1f, 0f, 0f) * intensity;
        Color hdrCyan = new Color(0f, 1f, 1f) * intensity;
        Color hdrYellow = new Color(1f, 1f, 0f) * intensity;
        Color hdrGreen = new Color(0f, 1f, 0f) * intensity;

        hdrColors[0] = hdrRed;
        hdrColors[1] = hdrCyan;
        hdrColors[2] = hdrYellow;
        hdrColors[3] = hdrGreen;

        //Randomize_color();
        UpdateScoreUI();
    }

    private void Update()
    {
        if (change)
        {
            Randomize_color();
            change = false;
        }

    }
    private IEnumerator ToggleChange()
    {
        while (true)
        {
            sp.condition = false;              // Stop spawning
            yield return new WaitForSeconds(3f); // Wait before color change

            change = !change;
            if (i % 3 == 0 || i % 4 == 0) { switching = !switching;
                switchImage.gameObject.SetActive(true);
                yield return new WaitForSeconds(1f);
                switchImage.gameObject.SetActive(false);
                switched = true;
            }
            
            i++;
            sp.condition = true;              // Resume spawning

            // ❌ DO NOT restart the coroutine manually
            // sp.StopCoroutine("Spawn");
            // sp.StartCoroutine("Spawn");

            yield return new WaitForSeconds(14f); // Wait until next cycle
        }
    }



    private void Randomize_color()
    {
        ResetVariables();
        int i = Random.Range(0, 4);
        int j = Random.Range(0, 4);
        int k = Random.Range(0, 4);

        renderer1.material.SetColor("_Color", hdrColors[i]);
        renderer2.material.SetColor("_Color", hdrColors[j]);
        renderer3.material.SetColor("_Color", hdrColors[k]);

        SetVariables(i);
        SetVariables(j);
        SetVariables(k);
    }

    private void SetVariables(int i)
    {
        switch (i)
        {
            case 0: red_variable = true; break;
            case 1: cyan_variable = true; break;
            case 2: yellow_variable = true; break;
            case 3: green_variable = true; break;
        }
        
    }

    public void IncreaseScore()
    {
        popcount++;
        UpdateScoreUI();
    }
    public void DecreaseScore() {
        popcount--;
        if (popcount < 0) popcount = 0;
        UpdateScoreUI();
    }

    private void NewGame()
    {
        popcount = 0;
        UpdateScoreUI();
        sp.condition = false;
        GameObject[] orbs = GameObject.FindGameObjectsWithTag("Orbs");
        foreach (GameObject orb in orbs)
        {
            Destroy(orb);
        }
        
    }

    public void UpdateScoreUI()
    {
        if (scoreText != null)
        {

            scoreText.text = "Score: " + popcount.ToString();
        }
    }

    private void ResetVariables()
    {
        red_variable = false;
        green_variable = false;
        cyan_variable = false;
        yellow_variable = false;
    }
    public void TriggerGameOver1()
    {
        gameOverPanel.SetActive(true);
        endImage.SetActive(true);
        StartCoroutine(ReloadSceneAfterDelay());
    }

    private IEnumerator ReloadSceneAfterDelay()
    {
        yield return new WaitForSeconds(3f);  // Wait for 3 seconds
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Reload the current scene
    }


    private IEnumerator RestartAfterDelay()
    {
        float delay = 2f;
        float elapsed = 0f;

        while (elapsed < delay)
        {
            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }

        Time.timeScale = 1f;
        NewGame();
        gameOverPanel.SetActive(false);
        yield return new WaitForSecondsRealtime(2f);
        sp.condition = true;
        //sp.ResetSpawnTimer(); // Add this line
        sp.RestartSpawner();
    }

    private void SwitchVariables()
    {
        red_variable = !red_variable;
        green_variable = !green_variable;
        cyan_variable = !cyan_variable;
        yellow_variable = !yellow_variable;
    }
}
