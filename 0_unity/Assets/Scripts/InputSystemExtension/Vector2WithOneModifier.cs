using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.Utilities;

// Use InputBindingComposite<TValue> as a base class for a composite that returns
// values of type TValue.
// NOTE: It is possible to define a composite that returns different kinds of values
//       but doing so requires deriving directly from InputBindingComposite.
#if UNITY_EDITOR
[InitializeOnLoad] // Automatically register in editor.
#endif
// Determine how GetBindingDisplayString() formats the composite by applying
// the  DisplayStringFormat attribute.
[DisplayStringFormat("{modifier}+{vector2}")]
public class Vector2WithOneModifier : InputBindingComposite<Vector2>
{
    // Each part binding is represented as a field of type int and annotated with
    // InputControlAttribute. Setting "layout" restricts the controls that
    // are made available for picking in the UI.
    //
    // On creation, the int value is set to an integer identifier for the binding
    // part. This identifier can read values from InputBindingCompositeContext.
    // See ReadValue() below.
    [InputControl(layout = "Button")]
    public int modifier;

    [InputControl(layout = "Vector2")]
    public int vector2;

    // This method computes the resulting input value of the composite based
    // on the input from its part bindings.
    public override Vector2 ReadValue(ref InputBindingCompositeContext context)
    {
        if (context.ReadValueAsButton(modifier))
            return context.ReadValue<Vector2, Vector2MagnitudeComparer>(vector2);

        return default;
    }
    
    // This method computes the current actuation of the binding as a whole.
    public override float EvaluateMagnitude(ref InputBindingCompositeContext context)
    {
        var a = context.ReadValueAsButton(modifier);
        Debug.Log("f: " + a);
        return a ? 1.0f : 0.0f;
    }

    static Vector2WithOneModifier()
    {
        // Can give custom name or use default (type name with "Composite" clipped off).
        // Same composite can be registered multiple times with different names to introduce
        // aliases.
        //
        // NOTE: Registering from the static constructor using InitializeOnLoad and
        //       RuntimeInitializeOnLoadMethod is only one way. You can register the
        //       composite from wherever it works best for you. Note, however, that
        //       the registration has to take place before the composite is first used
        //       in a binding. Also, for the composite to show in the editor, it has
        //       to be registered from code that runs in edit mode.
        InputSystem.RegisterBindingComposite<Vector2WithOneModifier>();
    }

    [RuntimeInitializeOnLoadMethod]
    static void Init() {} // Trigger static constructor.
}