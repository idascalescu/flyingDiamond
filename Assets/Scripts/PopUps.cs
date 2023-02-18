using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PopUps : MonoBehaviour
{
    [SerializeField]
    public TextMeshProUGUI movementPopUp;
    [SerializeField]
    public TextMeshProUGUI jumpingPopUp;
    [SerializeField]
    public TextMeshProUGUI deacJumpPopUP;
    [SerializeField]
    public TextMeshProUGUI rampFlyingPopUP;

    private string emptyString;

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("PopUp1"))
        {
            UIMovementInstructions();
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("PopUp2"))
        {
            UIJumpInstructions();
            Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag("DeacPopUp2"))
        {
            EraseJumpInstructions();
            Destroy(other.gameObject);
        }

        if(other.gameObject.CompareTag("PopUp3"))
        {
            UIRampInstructions();
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("DeacPopUp3"))
        {
            EraseRampInstructions();
            Destroy(other.gameObject);
        }
    }

    private void UIMovementInstructions()
    {
        movementPopUp.text = emptyString;
    }

    private void UIJumpInstructions()
    {
        jumpingPopUp.text = "Press space to jump";
    }

    private void EraseJumpInstructions()
    {
        jumpingPopUp.text = "";
    }
    
    private void UIRampInstructions()
    {
        rampFlyingPopUP.text = "Jump+E = Fly-High";
    }

    private void EraseRampInstructions()
    {
        rampFlyingPopUP.text = "";
    }
}
