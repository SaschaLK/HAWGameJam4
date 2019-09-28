// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/New Controls.inputactions'

using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class NewControls : IInputActionCollection
{
    private InputActionAsset asset;
    public NewControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""New Controls"",
    ""maps"": [
        {
            ""name"": ""New action map"",
            ""id"": ""a00d9f37-bbfe-48ff-b4b2-3bb5594e3cd3"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""4927c97e-7a84-45fb-a477-eb12a978db70"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""ec3a9e95-29b0-4c24-8e54-54144235bfbc"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // New action map
        m_Newactionmap = asset.FindActionMap("New action map", throwIfNotFound: true);
        m_Newactionmap_Move = m_Newactionmap.FindAction("Move", throwIfNotFound: true);
    }

    ~NewControls()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // New action map
    private readonly InputActionMap m_Newactionmap;
    private INewactionmapActions m_NewactionmapActionsCallbackInterface;
    private readonly InputAction m_Newactionmap_Move;
    public struct NewactionmapActions
    {
        private NewControls m_Wrapper;
        public NewactionmapActions(NewControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Newactionmap_Move;
        public InputActionMap Get() { return m_Wrapper.m_Newactionmap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(NewactionmapActions set) { return set.Get(); }
        public void SetCallbacks(INewactionmapActions instance)
        {
            if (m_Wrapper.m_NewactionmapActionsCallbackInterface != null)
            {
                Move.started -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnMove;
                Move.performed -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnMove;
                Move.canceled -= m_Wrapper.m_NewactionmapActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_NewactionmapActionsCallbackInterface = instance;
            if (instance != null)
            {
                Move.started += instance.OnMove;
                Move.performed += instance.OnMove;
                Move.canceled += instance.OnMove;
            }
        }
    }
    public NewactionmapActions @Newactionmap => new NewactionmapActions(this);
    public interface INewactionmapActions
    {
        void OnMove(InputAction.CallbackContext context);
    }
}
