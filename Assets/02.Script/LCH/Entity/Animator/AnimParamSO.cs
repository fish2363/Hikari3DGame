using UnityEngine;

[CreateAssetMenu(fileName = "AnimParamSO", menuName = "SO/Animator/ParamSO")]
public class AnimParamSO : ScriptableObject
{
    public enum ParamType
    {
        Boolean, Float, Integer, Trigger
    }
    
    public string paramName;
    public ParamType paramType;
    public int hashValue;
        
    private void OnValidate()
    {
        hashValue = Animator.StringToHash(paramName);
    }

}
