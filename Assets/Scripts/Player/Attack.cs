using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]
    private PlayerRenderer.PlayerRenderState renderState;
    [SerializeField]
    private int frame;

    public int Frame { get => frame; set => frame = value; }
    public PlayerRenderer.PlayerRenderState RenderState { get => renderState; set => renderState = value; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
