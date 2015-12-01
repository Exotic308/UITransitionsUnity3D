using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]

public class T_Fade : MonoBehaviour {

    void SetActive(bool active)
    {
        state = active;
        if(active)
            gameObject.SetActive(true);
    }

    public bool state;
    public float speed;

    float val;
    float oldVal;
    List<GameObject> el = new List<GameObject>();

    void Awake(){
        AddChildren(transform);
        if (state) val = 1; else val = 0;
        ApplyTransparency(val);
    }

    void AddChildren(Transform parent){
        foreach (Transform child in parent){
            el.Add(child.gameObject);
            AddChildren(child);
        }
    }

    void Update()
    {
        if (state)
        {
            if (val < 1) val += Time.deltaTime * speed;
        }
        else if (val > 0) val -= Time.deltaTime * speed;
        if (val != oldVal) ApplyTransparency(val);
    }

    void ApplyTransparency(float val){
        foreach (GameObject singleEl in el){
            if (singleEl.GetComponent<Image>()){
                Color temp = singleEl.GetComponent<Image>().color;
                temp.a = val;
                singleEl.GetComponent<Image>().color = temp;
            }
            else if (singleEl.GetComponent<Text>()){
                Color temp = singleEl.GetComponent<Text>().color;
                temp.a = val;
                singleEl.GetComponent<Text>().color = temp;
            }
        }
        oldVal = val;
        if (val < 0)
            gameObject.SetActive(false);
    }
}
