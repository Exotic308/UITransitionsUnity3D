using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class T_PositionInterpolation : MonoBehaviour {

    public enum InterpolationTypes
    {
        Linear, EaseOut, EaseIn, Exponentional, Smoothstep
    }
    public InterpolationTypes interpolationTypes;

    RectTransform rt;
    public Vector3 shownPos;
    public Vector3 hiddenPos;
    public bool state;
    public float speed;
    public float iCoef;

    void SetActive(bool active) { state = active; }

    void Awake()
    {
        rt = gameObject.GetComponent<RectTransform>();
        if (state)
        {
            iCoef = 1;
            rt.position = shownPos;
        }
        else rt.position = hiddenPos;
    }

    void Update()
    {
        if(state)
            iCoef += Time.deltaTime * speed;
        else
            iCoef -= Time.deltaTime * speed;
        iCoef = Mathf.Clamp(iCoef, 0f, 1f);

        float apliedICoef = 0;
        switch (interpolationTypes)
        {
            case InterpolationTypes.Linear:
                apliedICoef = iCoef; break;
            case InterpolationTypes.EaseIn:
                apliedICoef = Mathf.Sin(iCoef * Mathf.PI/2f); break;
            case InterpolationTypes.EaseOut:
                apliedICoef = 1-Mathf.Cos(iCoef * Mathf.PI / 2f); break;
            case InterpolationTypes.Exponentional:
                apliedICoef = iCoef * iCoef; break;
            case InterpolationTypes.Smoothstep:
                apliedICoef = iCoef * iCoef * (3f - 2f * iCoef); break;
        }

        rt.localPosition = Vector3.Lerp(hiddenPos, shownPos, apliedICoef);
    }
}
