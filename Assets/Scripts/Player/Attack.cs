using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]
    private PlayerRenderer.PlayerRenderState renderState;
    [SerializeField]
    private int frame;
    [SerializeField]
    private int damage;
    [SerializeField]
    private int stamina;
    [SerializeField]
    private MonoBehaviour specialAttack;
    [SerializeField]
    private int turningPointFrame;
    [SerializeField]
    private int moveDelayFrame;
    [SerializeField]
    private float maxVelocity;

    private AttackHitbox attackHitbox;
    private float accelerateRate;
    private float slowRate;

    public int Frame { get => frame; set => frame = value; }
    public PlayerRenderer.PlayerRenderState RenderState { get => renderState; set => renderState = value; }
    public int Stamina { get => stamina; set => stamina = value; }
    public int MoveDelayFrame { get => moveDelayFrame; set => moveDelayFrame = value; }
    public int TurningPointFrame { get => turningPointFrame; set => turningPointFrame = value; }
    public float MaxVelocity { get => maxVelocity; set => maxVelocity = value; }
    public float AccelerateRate { get => accelerateRate; set => accelerateRate = value; }
    public float SlowRate { get => slowRate; set => slowRate = value; }

    // Start is called before the first frame update
    void Start()
    {
        attackHitbox = GetComponent<AttackHitbox>();
        int accelerateFrame = turningPointFrame - moveDelayFrame;
        int slowFrame = frame - turningPointFrame;
        accelerateRate = maxVelocity / accelerateFrame;
        slowRate = maxVelocity / slowFrame;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DoDamage(List<Modifier> mods = null)
    {   
        attackHitbox.DoDamageAll(damage, mods);
        if(specialAttack != null)
        {
            ((SpecialAttack)specialAttack).DoSpecial();
        }
    }
}
