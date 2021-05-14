using UnityEngine;


/**
 * Class used for updating the text on the status plane
 */ 
public class StatusPlane : MonoBehaviour
{
    public string description;
    public string title;

    TextMesh descriptionTextMesh;

    // will be updated by PhaseHandler
    public float timeLeft;
    public PhaseHandler.Phase phase;

    // determines what happens during the action phase
    void ActionPhase()
    {
        description = "Fight!";
    }

    // determines what happens during the decision phase
    void DecisionPhase()
    {
        description = "Select your opponent and weapon!";
    }

    // Start is called before the first frame update
    void Start()
    {
        descriptionTextMesh = GameObject.Find("DescriptionText").GetComponent<TextMesh>();
    }


    // Update is called once per frame
    void Update()
    {
            phase = PhaseHandler.phase;
            timeLeft = PhaseHandler.timeLeft;
            title = phase == PhaseHandler.Phase.Action ? "Action Phase" : "Decision Phase";
            descriptionTextMesh.text = $"{title}\n{description}\n{timeLeft.ToString("F2")}";

            if (phase == PhaseHandler.Phase.Action)
            {
                ActionPhase();
            }

            if (phase == PhaseHandler.Phase.Decision)
            {
                DecisionPhase();
            }   
    }
}
