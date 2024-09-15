using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FortuneCookie : MonoBehaviour
{
    // Fortunes array (visible in Inspector)
    [Header("Fortune Data")]
    [Tooltip("Array of fortune messages to display.")]
    [SerializeField] private string[] fortunes;

    // Text objects for displaying fortune and lucky numbers
    [Header("UI Elements")]
      [Tooltip("Text component for displaying the header.")]
    [SerializeField] private TextMeshProUGUI headerText;  
    [Tooltip("Text component for displaying the fortune message.")]
    [SerializeField] private TextMeshProUGUI fortuneText;
    [Tooltip("Text component for displaying the lucky numbers.")]
    [SerializeField] private TextMeshProUGUI luckyNumbersText;

    // Image components for the fortune cookie sprite
    [Header("Fortune Cookie Sprites")]
    [Tooltip("Image component for the fortune cookie.")]
    [SerializeField] private Image cookieImage;
    [Tooltip("Sprite for the closed fortune cookie.")]
    [SerializeField] private Sprite closedCookieSprite;
    [Tooltip("Sprite for the cracked open fortune cookie.")]
    [SerializeField] private Sprite openCookieSprite;

    // Panel that holds the fortune and lucky numbers text
    [Header("Fortune Panel")]
    [Tooltip("The panel that will be shown when the cookie is cracked open.")]
    [SerializeField] private GameObject fortunePanel;

    // Audio source for the cookie crack sound
    [Header("Sound Effects")]
    [Tooltip("AudioSource component for the cookie crack sound effect.")]
    [SerializeField] private AudioSource cookieCrackSound;

    // Internal state
    private bool isCracked = false;  // Tracks whether the cookie is cracked or not

    void Start()
    {
        // Ensure the cookie is in the closed state at the beginning
        if (cookieImage != null)
        {
            cookieImage.sprite = closedCookieSprite;
        }
        if (fortuneText != null)
        {
            fortuneText.text = "";  // Start with no fortune text
        }
        if (luckyNumbersText != null)
        {
            luckyNumbersText.text = "";  // Start with no lucky numbers
        }
        if (fortunePanel != null)
        {
            fortunePanel.SetActive(false);  // Hide the panel at the beginning
        }
    }

    // Function to handle when the cookie is clicked
    public void ToggleFortune()
    {
        if (!isCracked)
        {
            // Crack the cookie, show the panel, and display a random fortune and lucky numbers
            if (cookieImage != null)
            {
                cookieImage.sprite = openCookieSprite;
            }
            if (fortuneText != null)
            {
                fortuneText.text = GetRandomFortune();
            }
            if (luckyNumbersText != null)
            {
                luckyNumbersText.text = "Lucky numbers: " + GenerateLuckyNumbers();
            }
            if (headerText != null)
            {
                headerText.enabled = false;
            }
            if (fortunePanel != null)
            {
                fortunePanel.SetActive(true);  // Show the panel
            }
            if (cookieCrackSound != null)
            {
                cookieCrackSound.Play();  // Play the crack sound
            }

            isCracked = true;
        }
        else
        {
            // Reset the cookie to its default closed state and hide the panel
            if (cookieImage != null)
            {
                cookieImage.sprite = closedCookieSprite;
            }
            if (fortuneText != null)
            {
                fortuneText.text = "";  // Clear the fortune text
            }
            if (luckyNumbersText != null)
            {
                luckyNumbersText.text = "";  // Clear the lucky numbers
            }
            if (headerText != null)
            {
                headerText.enabled = true;
            }
            if (fortunePanel != null)
            {
                fortunePanel.SetActive(false);  // Hide the panel
            }
            isCracked = false;  // Ready to crack again
        }
    }

    // Function to get a random fortune from the list
    private string GetRandomFortune()
    {
        if (fortunes != null && fortunes.Length > 0)
        {
            int randomIndex = Random.Range(0, fortunes.Length);
            return fortunes[randomIndex];
        }
        return "No fortunes available.";  // Fallback message
    }

    // Function to generate lucky numbers (6 random numbers from 1 to 99)
    private string GenerateLuckyNumbers()
    {
        int[] luckyNumbers = new int[6];

        for (int i = 0; i < 6; i++)
        {
            luckyNumbers[i] = Random.Range(1, 100);  // Generate numbers between 1 and 99
        }

        // Format the numbers without leading zeros
        return $"{luckyNumbers[0]}-{luckyNumbers[1]}-{luckyNumbers[2]}-{luckyNumbers[3]}-{luckyNumbers[4]}-{luckyNumbers[5]}";
    }
}
