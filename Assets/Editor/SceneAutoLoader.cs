using UnityEngine;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine.SceneManagement;

/// <summary>
/// Scene auto loader.
/// </summary>
/// <description>
/// This class adds a File > Scene Autoload menu containing options to select
/// a "master scene" enable it to be auto-loaded when the user presses play
/// in the editor. When enabled, the selected scene will be loaded on play,
/// then the original scene will be reloaded on stop.
///
/// Based on an idea on this thread:
/// http://forum.unity3d.com/threads/157502-Executing-first-scene-in-build-settings-when-pressing-play-button-in-editor
/// </description>
[InitializeOnLoad]
public static class SceneAutoLoader
{
    // Static constructor binds a playmode-changed callback.
    // [InitializeOnLoad] above makes sure this gets executed.
    static SceneAutoLoader()
    {
        EditorApplication.playModeStateChanged += OnPlayModeChanged;
    }

    // Menu items to select the "master" scene and control whether or not to load it.
    [MenuItem("File/Scene Autoload/Select Master Scene...")]
    private static void SelectMasterScene()
    {
        string masterScene = EditorUtility.OpenFilePanel("Select Master Scene", Application.dataPath, "unity");
        if (!string.IsNullOrEmpty(masterScene))
        {
            MasterScene = masterScene;
            LoadMasterOnPlay = true;
        }
    }

    [MenuItem("File/Scene Autoload/Load Master On Play", true)]
    private static bool ShowLoadMasterOnPlay()
    {
        return !LoadMasterOnPlay;
    }

    [MenuItem("File/Scene Autoload/Load Master On Play")]
    private static void EnableLoadMasterOnPlay()
    {
        LoadMasterOnPlay = true;
    }

    [MenuItem("File/Scene Autoload/Don't Load Master On Play", true)]
    private static bool ShowDontLoadMasterOnPlay()
    {
        return LoadMasterOnPlay;
    }

    [MenuItem("File/Scene Autoload/Don't Load Master On Play")]
    private static void DisableLoadMasterOnPlay()
    {
        LoadMasterOnPlay = false;
    }

    // Play mode change callback handles the scene load/reload.
    private static void OnPlayModeChanged(PlayModeStateChange change)
    {
        if (!LoadMasterOnPlay) return;
        if (!EditorApplication.isPlaying && EditorApplication.isPlayingOrWillChangePlaymode)
        {
            // User pressed play -- autoload master scene.
            PreviousScene = SceneManager.GetActiveScene().path;
            if (EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
            {
                EditorSceneManager.OpenScene(MasterScene, OpenSceneMode.Single);
            }
            else
            {
                // User cancelled the save operation -- cancel play as well.
                EditorApplication.isPlaying = false;
            }
        }

        if (EditorApplication.isPlaying && !EditorApplication.isPlayingOrWillChangePlaymode)
        {
            // User pressed stop -- reload previous scene.
            if (SceneAutoLoader.PreviousScene != SceneAutoLoader.MasterScene)
                EditorApplication.update += ReloadLastScene;
        }
    }

    private static void ReloadLastScene()
    {
        Debug.Log("Reloading..");
        if (!EditorApplication.isPlaying && SceneManager.GetActiveScene().path != SceneAutoLoader.PreviousScene)
        {
            EditorSceneManager.OpenScene(SceneAutoLoader.PreviousScene);
            EditorApplication.update -= ReloadLastScene;
        }
    }

    // Properties are remembered as editor preferences.
    private const string CEditorPrefLoadMasterOnPlay = "SceneAutoLoader.LoadMasterOnPlay";
    private const string CEditorPrefMasterScene = "SceneAutoLoader.MasterScene";
    private const string CEditorPrefPreviousScene = "SceneAutoLoader.PreviousScene";

    private static bool LoadMasterOnPlay
    {
        get => EditorPrefs.GetBool(CEditorPrefLoadMasterOnPlay, false);
        set => EditorPrefs.SetBool(CEditorPrefLoadMasterOnPlay, value);
    }

    private static string MasterScene
    {
        get => EditorPrefs.GetString(CEditorPrefMasterScene, "Master.unity");
        set => EditorPrefs.SetString(CEditorPrefMasterScene, value);
    }

    private static string _previousScene;

    private static string PreviousScene
    {
        get => EditorPrefs.GetString(CEditorPrefPreviousScene, _previousScene);
        set
        {
            _previousScene = value;
            EditorPrefs.SetString(CEditorPrefPreviousScene, value);
        }
    }
}