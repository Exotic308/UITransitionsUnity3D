using UnityEngine;
using System.Collections;

public class ExampleScript : MonoBehaviour {

	public void BackToMenu()
    {
        UITransitions.SetOnlyActive("MainMenu");
    }

    public void Options()
    {
        UITransitions.SetOnlyActive("Options");
    }

    public void Credits()
    {
        UITransitions.SetOnlyActive("Credits");
    }
}
