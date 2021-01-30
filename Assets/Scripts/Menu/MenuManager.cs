using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private ParamTrackData paramTrack;

    [SerializeField]
    private TMP_InputField popInput;

    [SerializeField]
    private Toggle saveToggle;

    private void Start()
    {
        popInput.text = paramTrack.populationSize.ToString();
        saveToggle.isOn = paramTrack.SaveFile;
    }

    public void PlayTrackOne()
    {
        SceneManager.LoadScene("Track1");
    }

    public void OnPopulationChange()
    {
        int.TryParse(popInput.text, out int result);
        paramTrack.populationSize = result;
    }

    public void OnToggleChange()
    {
        paramTrack.SaveFile = saveToggle.isOn;
    }
}