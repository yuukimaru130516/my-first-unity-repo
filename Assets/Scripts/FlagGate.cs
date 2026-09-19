using UnityEngine;

// 指定した進行フラグの値に応じて、同じGameObjectのInteractable.investigableを切り替える
public class FlagGate : MonoBehaviour
{
    public string flagName;
    public bool invert = false;

    private Interactable interactable;

    void Awake()
    {
        interactable = GetComponent<Interactable>();
    }

    void OnEnable()
    {
        GameFlags.OnFlagChanged += HandleFlagChanged;
        Apply(GameFlags.Get(flagName));
    }

    void OnDisable()
    {
        GameFlags.OnFlagChanged -= HandleFlagChanged;
    }

    void HandleFlagChanged(string changedFlag, bool value)
    {
        if (changedFlag != flagName) return;
        Apply(value);
    }

    void Apply(bool flagValue)
    {
        if (interactable != null) interactable.investigable = invert ? !flagValue : flagValue;
    }
}
