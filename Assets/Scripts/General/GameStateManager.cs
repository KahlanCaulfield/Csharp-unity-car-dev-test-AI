/// Author: PsykoDev
/// Date: May 2019

using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    #region Members

    [SerializeField]
    private Camera globalCam;

    [SerializeField]
    private Camera followCam;

    [SerializeField]
    private UISimulationController uISimulationController;

    public static GameStateManager Instance
    {
        get;
        private set;
    }

    private bool globalCamera = false;
    private CameraMovement cameraMovement;
    private GameObject bestcarSave;

    #endregion Members

    private void Start()
    {
        TrackManager.Instance.BestCarChanged += OnBestCarChanged;
        EvolutionManager.Instance.StartEvolution();

        cameraMovement = followCam.GetComponent<CameraMovement>();
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.G))
        {
            globalCamera = !globalCamera;

            if (globalCamera)
            {
                followCam.gameObject.SetActive(false);
                globalCam.gameObject.SetActive(true);
            }
            else
            {
                globalCam.gameObject.SetActive(false);
                followCam.gameObject.SetActive(true);
                cameraMovement.SetTarget(bestcarSave);
            }
        }
    }

    // Callback method for when the best car has changed.
    private void OnBestCarChanged(CarController bestCar)
    {
        if (!globalCamera)
        {
            if (bestCar == null)
                cameraMovement.SetTarget(null);
            else
                cameraMovement.SetTarget(bestCar.gameObject);
        }
        else
        {
            cameraMovement.SetTarget(null);
        }

        uISimulationController.Target = bestCar;
        if (bestCar)
        {
            bestcarSave = bestCar.gameObject;
        }
    }
}