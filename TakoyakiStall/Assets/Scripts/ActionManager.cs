using UnityEngine;

public class ActionManager : MonoBehaviour
{
    [SerializeField] private Player player;

    public void SetActionToTAKO()
    {
        player.Action = Player.ACTION.TAKO;
        Debug.Log("Action was changed to TAKO");
    }

    public void SetActionToNEGI()
    {
        player.Action = Player.ACTION.NEGI;
        Debug.Log("Action was changed to NEGI");
    }

    public void SetActionToBENI()
    {
        player.Action = Player.ACTION.BENI;
        Debug.Log("Action was changed to BENI");
    }

    public void SetActionToBATTER()
    {
        player.Action = Player.ACTION.BATTER;
        Debug.Log("Action was changed to BATTER");
    }

    public void SetActionToPICK()
    {
        player.Action = Player.ACTION.PICK;
        Debug.Log("Action was changed to PICK");
    }
}
