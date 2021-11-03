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
    private float moveDistance;
    [SerializeField]
    private float moveDelayFrame;

    private AttackHitbox attackHitbox;

    public int Frame { get => frame; set => frame = value; }
    public PlayerRenderer.PlayerRenderState RenderState { get => renderState; set => renderState = value; }
    public int Stamina { get => stamina; set => stamina = value; }
    public float MoveDistance { get => moveDistance; set => moveDistance = value; }
    public float MoveDelayFrame { get => moveDelayFrame; set => moveDelayFrame = value; }

    // Start is called before the first frame update
    void Start()
    {
        attackHitbox = GetComponent<AttackHitbox>();
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
