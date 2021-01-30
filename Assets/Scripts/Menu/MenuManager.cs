using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private ParamTrackData paramTrack;

    [SerializeField]
    private TMP_InputField popInput;

    private void Start()
    {
        popInput.text = paramTrack.populationSize.ToString();
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
}