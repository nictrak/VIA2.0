using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//ref - > https://gamedev.stackexchange.com/questions/162976/how-do-i-create-a-weighted-collection-and-then-pick-a-random-element-from-it
class WeightedRandomBag<T>  {

    private struct Entry {
        public int accumulatedWeight;
        public T item;
    }

    private List<Entry> entries = new List<Entry>();
    private int accumulatedWeight;

    public void AddEntry(T item, int weight) {
        accumulatedWeight += weight;
        entries.Add(new Entry { item = item, accumulatedWeight = accumulatedWeight });
    }

    public int EntrySize {
        get { return entries.Count; }
    }

    public void ClearEntry() {
        entries.Clear();
        accumulatedWeight = 0;
    }

    public T GetRandom() {
        int r = Random.Range(0, accumulatedWeight);

        foreach (Entry entry in entries) {
            if (entry.accumulatedWeight >= r) {
                return entry.item;
            }
        }
        return default(T);
    }
}

public class GeneralBossRandom : BossStateBehaviour
{

    [SerializeField]
    private List<BossStateBehaviour> states;

    [SerializeField]
    private List<int> probabilities;

    private WeightedRandomBag<BossStateBehaviour> rand;
    
    // Start is called before the first frame update
    void Start() {

        rand = new WeightedRandomBag<BossStateBehaviour>();

    }

    public override void ExitState()
    {

    }

    public override BossStateMachine.BossState RunState(int energy, out int energyOut)
    {
        for (int i=states.Count - 1; i > -1; i--)
        {
            if(states[i].EnergyCost <= energy)
            {
                rand.AddEntry(states[i], probabilities[i]);
            }
        }

        if(rand.EntrySize != 0) {
            BossStateBehaviour state = rand.GetRandom();
            energyOut = energy - energyCost;
            return state.StateEnum;
        } else {
            energyOut = energy - energyCost;
            return NormalNextState;
        }
    }

    public override void StartState()
    {
        rand.ClearEntry();
    }

}
