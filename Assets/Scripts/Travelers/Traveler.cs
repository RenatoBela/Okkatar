using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public abstract class Traveler : Agent
{
    [SerializeField] private List<Transform> Cities;

    public string Name { get; set; }
    public int TravelerID { get; set; }
    public float TravelSpeed { get; set; }
    private Dictionary<string, int> Inventory { get; set; }
    private int MonthlyCost { get; set; }
    private int Money { get; set; }

    public Traveler(string name, int travelerID, Dictionary<string, int> inventory = null)
    {
        Name = name;
        TravelerID = travelerID;
        Inventory = inventory ?? new Dictionary<string, int>();
    }

    public abstract override void OnActionReceived(ActionBuffers actions);
    public abstract override void CollectObservations(VectorSensor sensor);
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetAxisRaw("Horizontal");
        continuousActions[1] = Input.GetAxisRaw("Vertical");
    }

    public abstract override void OnEpisodeBegin();
    public abstract void OnEpisodeEnd();
}
