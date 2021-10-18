using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopDialogue : Dialogue
{
    [SerializeField]
    private Dialogue next;

    public override void EndDialogue()
    {
        GameObject finded = GameObject.FindGameObjectWithTag("HUDController");
        if (finded != null)
        {
            HudController hudCon = finded.GetComponent<HudController>();
            hudCon.CloseShop();
        }
    }

    public override List<string> GetChoicesString()
    {
        return null;
    }

    public override Dialogue GetNextDialogue(int param)
    {
        return next;
    }

    public override bool IsClicknext()
    {
        return false;
    }

    public override void StartDialogue()
    {
        GameObject finded = GameObject.FindGameObjectWithTag("HUDController");
        if(finded != null)
        {
            HudController hudCon = finded.GetComponent<HudController>();
            hudCon.OpenShop();
        }
    }
}
