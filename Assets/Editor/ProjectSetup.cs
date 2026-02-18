using UnityEngine;
using UnityEditor;

// Editor script per l'import dei layer e tag, NON RIGUARDA L'ESAME
[InitializeOnLoad]
public class ProjectSetup
{
    static ProjectSetup()
    {
        CreateLayer("Cannon");
        CreateTag("GameOverZone");
        CreateTag("Projectile");
    }

    static void CreateLayer(string layerName)
    {
        SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
        SerializedProperty layers = tagManager.FindProperty("layers");
        
        for (int i = 0; i < layers.arraySize; i++)
        {
            if (layers.GetArrayElementAtIndex(i).stringValue == layerName)
            {
                return; 
            }
        }
        for (int i = 6; i < layers.arraySize; i++)
        {
            SerializedProperty layerSP = layers.GetArrayElementAtIndex(i);
            if (string.IsNullOrEmpty(layerSP.stringValue))
            {
                layerSP.stringValue = layerName;
                tagManager.ApplyModifiedProperties();
                Debug.Log($"<color=green>Layer '{layerName}' configurato nello slot {i}.</color>");
                return;
            }
        }
    }

    static void CreateTag(string tagName)
    {
        SerializedObject tagManager = new SerializedObject(AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset")[0]);
        SerializedProperty tags = tagManager.FindProperty("tags");

        for (int i = 0; i < tags.arraySize; i++)
        {
            if (tags.GetArrayElementAtIndex(i).stringValue == tagName) return;
        }

        tags.InsertArrayElementAtIndex(0);
        tags.GetArrayElementAtIndex(0).stringValue = tagName;
        tagManager.ApplyModifiedProperties();
        Debug.Log($"<color=green>Tag '{tagName}' configurato.</color>");
    }
}