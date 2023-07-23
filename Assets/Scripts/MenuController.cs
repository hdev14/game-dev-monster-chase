using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void PlayGame()
    {
        var playerName = EventSystem.current.currentSelectedGameObject.name;
        var selectedPlayerIndex = int.Parse(playerName[playerName.Length - 1].ToString()) - 1;
        
        Debug.Log(selectedPlayerIndex);

        GameManager.instance.playerIndex = selectedPlayerIndex;
        
        SceneManager.LoadScene("Gameplay");
    }
}
