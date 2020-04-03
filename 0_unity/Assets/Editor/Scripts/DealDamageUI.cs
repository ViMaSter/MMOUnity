using UnityEditor;

[CustomPropertyDrawer(typeof(UI.Combat.Canvases.AreaOfEffectStorage))] public class AreaOfEffectStoragePropertyDrawer : SerializableDictionaryStoragePropertyDrawer {} 
[CustomPropertyDrawer(typeof(UI.Combat.Canvases.AreaOfEffectDictionary))] public class AreaOfEffectDictionaryPropertyDrawer : SerializableDictionaryPropertyDrawer {} 