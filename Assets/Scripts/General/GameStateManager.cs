/// Author: PsykoDev
/// Date: May 2019

#region Includes

using UnityEngine;
using UnityEngine.SceneManagement;

#endregion Includes

/// <summary>
/// Singleton class managing the overall simulation.
/// </summary>
public class GameStateManager : MonoBehaviour
{
    #region Members

    // The camera object, to be referenced in Unity Editor.
    [SerializeField]
    private CameraMovement Camera;

    [SerializeField]
    private Camera globalCam;

    [SerializeField]
    private Camera followCam;

    // The name of the track to be loaded
    [SerializeField]
    public string TrackName;

    [SerializeField]
    private GameObject bestcarSave;

    /// <summary>
    /// The UIController object.
    /// </summary>
    public UIController UIController;

    public static GameStateManager Instance
    {
        get;
        private set;
    }

    private CarController prevBest, prevSecondBest;
    private bool globalCamera = false;

    #endregion Members

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple GameStateManagers in the Scene.");
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        TrackManager.Instance.BestCarChanged += OnBestCarChanged;
        EvolutionManager.Instance.StartEvolution();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.G))
        {
            globalCamera = !globalCamera;

            if (globalCamera)
            {
                Camera.gameObject.SetActive(false);
                globalCam.gameObject.SetActive(true);
            }
            else
            {
                globalCam.gameObject.SetActive(false);
                Camera.gameObject.SetActive(true);
                Camera.SetTarget(bestcarSave);
            }
        }
    }

    // Callback method for when the best car has changed.
    private void OnBestCarChanged(CarController bestCar)
    {
        if (!globalCamera)
        {
            if (bestCar == null)
                Camera.SetTarget(null);
            else
                Camera.SetTarget(bestCar.gameObject);
        }
        else
        {
            Camera.SetTarget(null);
        }

        if (UIController != null)
            UIController.SetDisplayTarget(bestCar);
        if (bestCar)
        {
            bestcarSave = bestCar.gameObject;
        }
    }
}