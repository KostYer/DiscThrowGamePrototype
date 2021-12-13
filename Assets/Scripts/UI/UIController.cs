using System.Collections;
using GamePlay;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace GameUI
{
    public class UIController: MonoBehaviour
    {
        [SerializeField] private GamePlayManager game;
        [SerializeField] private RectTransform startGamePanel;
     
        [SerializeField] Button startGameButton;
        [SerializeField] Button resumeButton;
        [SerializeField] Button quitButton;
        
        [SerializeField] Button pauseButton;
        [SerializeField] private TextMeshProUGUI levelNumber;
        private float nextLevelDelay => game.respawnDelay;
        
        private bool isGameStarted ;
        void Start()
        {   
            SubscribeButtons();
            SetStartUIScreen();
            game.OnLevelIncreased += OnLevelIncreased;

        }

        private void SubscribeButtons()
        {
            startGameButton.onClick.AddListener(OnStartButtonClicked);  
            quitButton.onClick.AddListener(QuitGameButtonClicked);
            resumeButton.onClick.AddListener(OnResumeButtonClicked);
            pauseButton.onClick.AddListener(OnPauseButtonClicked);
        }


        private void SetStartUIScreen()
        {
            ShowPanel(true);
            startGameButton.gameObject.SetActive(true);
            quitButton.gameObject.SetActive(true);
            resumeButton.gameObject.SetActive(false);
            pauseButton.gameObject.SetActive(false);
            levelNumber.gameObject.SetActive(false);
        }
        private void SetPauseUIScreen()
        {
            ShowPanel(true);
            startGameButton.gameObject.SetActive(false);
            quitButton.gameObject.SetActive(true);
            resumeButton.gameObject.SetActive(true);
            pauseButton.gameObject.SetActive(false);
            levelNumber.gameObject.SetActive(false);
        }


    
        private void OnPauseButtonClicked()
        {  
            SetPauseUIScreen();
            game.FreezeGame();
        }

        private void ShowPanel(bool show)
        {
            startGamePanel.gameObject.SetActive(show);
        }
 
        private void OnResumeButtonClicked()
        {
            ShowPanel(false);
            pauseButton.gameObject.SetActive(true);
            levelNumber.gameObject.SetActive(true);
            game.UnfreezeGame();
            
        }


        private void OnStartButtonClicked()
        {  
            ShowPanel(false);
            pauseButton.gameObject.SetActive(true);
            levelNumber.gameObject.SetActive(true);
            game.StartGame();
            
        }


        public void QuitGameButtonClicked()
        {    
            ShowPanel(false);
            Application.Quit();
        }
        
        private void OnLevelIncreased(int level)
        {
            StartCoroutine(UpdateTextAfterDelay(level));
        }

        private IEnumerator UpdateTextAfterDelay(int level)
        {
            yield return new WaitForSeconds(nextLevelDelay);
            levelNumber.text = level.ToString();
        }
    }
}