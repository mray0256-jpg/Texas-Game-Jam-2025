using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public static bool isPaused = false;

    [SerializeField] GameObject PauseMenu;
    [SerializeField] GameObject HatPanel;
    [SerializeField] GameObject NewAbility;
    [SerializeField] GameObject HatShop;
    [SerializeField] static GameObject WinScreen;
    [SerializeField] static GameObject GameOver;

    [SerializeField] GameObject SantaButton;
    [SerializeField] GameObject ChefButton;
    [SerializeField] GameObject BeanieButton;
    [SerializeField] GameObject PirateButton;
    [SerializeField] GameObject CowboyButton;
    [SerializeField] GameObject JesterButton;
    [SerializeField] GameObject TopHatButton;
    [SerializeField] GameObject PropellerButton;
    [SerializeField] GameObject CrownButton;

    public static bool isSanta = false;
    public static bool isChef = false;
    public static bool isBeanie = false;
    public static bool isPirate = false;
    public static bool isCowboy = false;
    public static bool isJester = false;
    public static bool isTopHat = false;
    public static bool isPropeller = false;
    public static bool isCrown = false;

    private bool hasJump = false;

    void Start()
    {
        WinScreen = transform.GetChild(7).gameObject;
        GameOver = transform.GetChild(8).gameObject;
    }
    // Update is called once per frame
    void Update()
    {
        if (!hasJump && LoopScript.CurrentState == Loop.State.Five)
        {
            hasJump = true;
            NewAbility.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        PauseMenu.SetActive(false);
        HatPanel.SetActive(false);
        HatShop.SetActive(false);
        isPaused = false;
        Player_Move.PlayPlayerMovement();
    }

    public void PauseGame()
    {
        Time.timeScale = 1f;
        HatPanel.SetActive(false);
        HatShop.SetActive(false);
        PauseMenu.SetActive(true);
        isPaused = true;
        Player_Move.PausePlayerMovement();
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void LoadHats()
    {
        Time.timeScale = 0f;
        PauseMenu.SetActive(false);
        HatPanel.SetActive(true);
        SantaButton.GetComponent<HatRefresh>().Refresh(isSanta);
        ChefButton.GetComponent<HatRefresh>().Refresh(isChef);
        BeanieButton.GetComponent<HatRefresh>().Refresh(isBeanie);
        PirateButton.GetComponent<HatRefresh>().Refresh(isPirate);
        CowboyButton.GetComponent<HatRefresh>().Refresh(isCowboy);
        JesterButton.GetComponent<HatRefresh>().Refresh(isJester);
        TopHatButton.GetComponent<HatRefresh>().Refresh(isTopHat);
        PropellerButton.GetComponent<HatRefresh>().Refresh(isPropeller);
        CrownButton.GetComponent<HatRefresh>().Refresh(isCrown);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LeaveAbility()
    {
        NewAbility.SetActive(false);
    }

    public void OpenShop()
    {
        Time.timeScale = 0f;
        HatShop.SetActive(true);
    }

    public void CloseShop()
    {
        HatShop.SetActive(false);
    }

    public void BuyHat(Button hat)
    {

        if (hat.name == "Santa" && !isSanta)
        {
            if (SetCounter.GetFlyCount() < 10)
            {
                return;
            }
            isSanta = true;
            TurnGreen.CompletedPurchase(hat);
        }
        else if (hat.name == "Pirate" && !isPirate)
        {
            if (SetCounter.GetFlyCount() < 20)
            {
                return;
            }
            isPirate = true;
            TurnGreen2.CompletedPurchase(hat);
        }
        else if (hat.name == "Cowboy" && !isCowboy)
        {
            if (SetCounter.GetFlyCount() < 30)
            {
                return;
            }
            isCowboy = true;
            TurnGreen3.CompletedPurchase(hat);
        }
        else if (hat.name == "TopHat" && !isTopHat)
        {
            if (SetCounter.GetFlyCount() < 40)
            {
                return;
            }
            isTopHat = true;
            TurnGreen4.CompletedPurchase(hat);
        }
        else if (hat.name == "Propeller" && !isPropeller)
        {
            if (SetCounter.GetFlyCount() < 50)
            {
                return;
            }
            isPropeller = true;
            TurnGreen5.CompletedPurchase(hat);
        }
    }
     
    public static void ActivateWinScreen()
    {
        WinScreen.SetActive(true);
    }

    public static void GameOverScreen()
    {
        GameOver.SetActive(true);
    }
}