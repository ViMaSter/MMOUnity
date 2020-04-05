using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;

namespace DataEditor
{
    [CustomEditor(typeof(Game.Data.Actions.Attacks.SingleTargetAttack))]
    [CanEditMultipleObjects]
    public class SingleTargetAttack : Editor
    { 
        private static readonly string[] propertiesToWatch = { "displayName", "hotbarImage", "regularAttackValue", "isPositional" }; 
        Dictionary<string, SerializedProperty> properties;
        
        void OnEnable()
        {
            properties = propertiesToWatch
                .Select(propertyName => {
                    var propertyData = serializedObject.FindProperty(propertyName);
                    if (propertyData == null)
                    {
                        throw new KeyNotFoundException($"Property {propertyName} couldn't be found on {serializedObject}");
                    }
                    return new KeyValuePair<string, SerializedProperty>(propertyName, propertyData);
                })
                .ToDictionary(item => item.Key, item => item.Value);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            foreach (SerializedProperty property in properties.Values)
            {
                EditorGUILayout.PropertyField(property);
            }
            serializedObject.ApplyModifiedProperties();
        }
    }
    
    [CustomEditor(typeof(Game.Data.Actions.Attacks.AreaOfEffectAttack))]
    [CanEditMultipleObjects]
    public class AreaOfEffectAttack : Editor
    { 
        private static readonly string[] propertiesToWatch = { "displayName", "icon", "attackValueAtCenter", "radius", "falloffByDistance" }; 
        Dictionary<string, SerializedProperty> properties;
        
        void OnEnable()
        {
            SceneView.duringSceneGui += this.OnSceneGUI;

            properties = propertiesToWatch
                .Select(propertyName => new KeyValuePair<string, SerializedProperty>(propertyName, serializedObject.FindProperty(propertyName)))
                .ToDictionary(item => item.Key, item => item.Value);
        }

        void OnSceneGUI(SceneView sceneView)
        {
            Game.Data.Actions.Attacks.AreaOfEffectAttack item = (Game.Data.Actions.Attacks.AreaOfEffectAttack)target;

            Handles.color = new Color(1, 0, 0, 0.1f);

            Vector3 mousePosition = Event.current.mousePosition;
            Ray ray = HandleUtility.GUIPointToWorldRay(mousePosition);
            
            if (Physics.Raycast(ray, out RaycastHit hit)) {
                Handles.DrawSolidDisc(hit.point, hit.normal, item.Radius);
            }

            SceneView.RepaintAll();
        }

        public override void OnInspectorGUI()
        {
            Game.Data.Actions.Attacks.AreaOfEffectAttack item = (Game.Data.Actions.Attacks.AreaOfEffectAttack)target;

            serializedObject.Update();
            foreach (SerializedProperty property in properties.Values)
            {
                EditorGUILayout.PropertyField(property);
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}
