using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject tittleUI, scoreUI, restartMenuUI;
    [SerializeField] private TextMeshProUGUI scoreText, highScoreText;
    [SerializeField] private GameManager gameManager;

    private void Update()
    {
        if (gameManager.CurrentGameState == GameManager.GameState.Playing)
        {
            if (tittleUI.activeSelf)
            {
                tittleUI.SetActive(false);
                scoreUI.SetActive(true);
            }
            scoreText.text = $"Score = {GameManager.Points}";
            highScoreText.text = $"High Score = {GameManager.HighScore}";
        }
        else if (gameManager.CurrentGameState == GameManager.GameState.Ended)
        {
            if (!scoreUI.activeSelf) return;
            scoreUI.SetActive(false);
            restartMenuUI.SetActive(true);
        }
    }
    
    public void LoadSceneButton(int scene)
    {
        SceneManager.LoadScene(scene);
    }
}