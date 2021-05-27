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

    private AttackHitbox attackHitbox;

    public int Frame { get => frame; set => frame = value; }
    public PlayerRenderer.PlayerRenderState RenderState { get => renderState; set => renderState = value; }

    // Start is called before the first frame update
    void Start()
    {
        attackHitbox = GetComponent<AttackHitbox>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void DoDamage()
    {
        attackHitbox.DoDamageAll(damage);
    }
}
