using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UITransitions : MonoBehaviour {

    public GameObject UIParent;
	static List<GameObject> multiCanvas; 
	static List<string> names; 


	void Awake(){
		if(UIParent) {
            multiCanvas = new List<GameObject>();
            names = new List<string>();
            foreach (Transform child in UIParent.transform){
			    RectTransform rt = child.gameObject.GetComponent<RectTransform>();
			    if(rt) {
                    multiCanvas.Add(child.gameObject);
                    names.Add(child.name);
                }
            }
        } else Debug.LogError("UIParent is null, please point to it and restart the game.");
	}

	public static void SetActive(string name, bool state){
		for(int i = 0; i < multiCanvas.Count; i++){
			if(name == names[i]){
                multiCanvas[i].SendMessage("SetActive", state);
                return;
			}	
		}

        double closest = 0;
        int index = 0;
        for(int i = 0; i < multiCanvas.Count; i++){
            double cur = StringSimilarity.CalculateSimilarity(name, names[i]);
            if(cur > closest){
                closest = cur;
                index = i;
            }
        }

        if(closest == 0) Debug.LogError("UILib could not find menu by name : " + name);
        else Debug.LogError("UILib could not find menu by name : " + name + ", did you think : " + names[index]);
    }

}
