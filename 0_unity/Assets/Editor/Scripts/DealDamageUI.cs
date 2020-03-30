using UnityEditor;

[CustomPropertyDrawer(typeof(AreaOfEffectStorage))] public class AreaOfEffectStoragePropertyDrawer : SerializableDictionaryStoragePropertyDrawer {} 
[CustomPropertyDrawer(typeof(AreaOfEffectDictionary))] public class AreaOfEffectDictionaryPropertyDrawer : SerializableDictionaryPropertyDrawer {} 