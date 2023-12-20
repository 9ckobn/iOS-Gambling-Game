using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OnBoardingHandler : MonoBehaviour
{
    [SerializeField] private OnBoardingSettings settings;

    [SerializeField] private TextMeshProUGUI h1, h2, h3;
    [SerializeField] private Image baseImage;

    private int _index = 0;

    public Button nextButton;

    void OnEnable()
    {
        NextScreen();
        nextButton.onClick.AddListener(NextScreen);
    }

    public void NextScreen()
    {
        if(_index >= 3)
        {
            var sceneTask = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);

            return;
        }
        

        SetScreen(_index);
        _index++;
    }

    public void SetScreen(int index)
    {
        h1.text = settings.screenInfos[index].h1;
        h2.text = settings.screenInfos[index].h2;
        h3.text = settings.screenInfos[index].h3;

        baseImage.sprite = settings.screenInfos[index].coreImage;
    }
}
