/// Author: PsykoDev
/// Date: May 2019

#region Includes

using UnityEngine.UI;
using UnityEngine;
using System;

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
    private Text[] InputTexts;

    [SerializeField]
    private Text Evaluation;

    [SerializeField]
    private Text GenerationCount;

    [SerializeField]
    private UINeuralNetworkPanel NeuralNetPanel;

    #endregion Members

    private void Update()
    {
        if (Target != null)
        {
            //Display controls
            if (Target.CurrentControlInputs != null)
            {
                for (int i = 0; i < InputTexts.Length; i++)
                    InputTexts[i].text = Target.CurrentControlInputs[i].ToString();
            }

            //Display evaluation and generation count
            Evaluation.text = Target.Agent.Genotype.Evaluation.ToString();
            GenerationCount.text = EvolutionManager.Instance.GenerationCount.ToString();
        }
    }
}