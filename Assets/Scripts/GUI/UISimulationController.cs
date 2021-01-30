/// Author: PsykoDev
/// Date: May 2019

#region Includes

using UnityEngine.UI;
using UnityEngine;
using TMPro;

#endregion Includes

/// <summary>
/// Class for controlling the various ui elements of the simulation
/// </summary>
public class UISimulationController : MonoBehaviour
{
    #region Members

    private CarController target;

    /// <summary>
    /// The Car to fill the GUI data with.
    /// </summary>
    public CarController Target
    {
        get { return target; }
        set
        {
            if (target != value)
            {
                target = value;

                if (target != null)
                    NeuralNetPanel.Display(target.Agent.FNN);
            }
        }
    }

    // GUI element references to be set in Unity Editor.
    [SerializeField]
    private TMP_Text turnTxt;

    [SerializeField]
    private TMP_Text engineTxt;

    [SerializeField]
    private TMP_Text evalTxt;

    [SerializeField]
    private TMP_Text genCountTxt;

    [SerializeField]
    private UINeuralNetworkPanel NeuralNetPanel;

    #endregion Members

    private void Update()
    {
        if (target != null)
        {
            //Display controls
            turnTxt.text = target.GetTurnInput().ToString();
            engineTxt.text = target.GetEngineInput().ToString();

            //Display evaluation and generation count
            evalTxt.text = target.Agent.Genotype.Evaluation.ToString();
            genCountTxt.text = EvolutionManager.Instance.GenerationCount.ToString();
        }
    }
}