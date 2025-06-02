using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using UnityEngine;
using System.Collections.Generic;

namespace UnityToolbarExtender.Examples
{
	static class ToolbarStyles
	{
		public static readonly GUIStyle commandButtonStyle;

		static ToolbarStyles()
		{
			commandButtonStyle = new GUIStyle("Command")
			{
				fontSize = 16,
				alignment = TextAnchor.MiddleCenter,
				imagePosition = ImagePosition.ImageAbove,
				fontStyle = FontStyle.Bold
			};
		}
	}

	[InitializeOnLoad]
	public class SceneSwitchLeftButton
	{
		static SceneSwitchLeftButton()
		{
			ToolbarExtender.LeftToolbarGUI.Add(OnToolbarGUI);
		}

		static void OnToolbarGUI()
		{
			GUILayout.FlexibleSpace();

			if (GUILayout.Button("SELECT"))
			{
				SceneView.lastActiveSceneView.FrameSelected();
			}if (GUILayout.Button("CENTER"))
			{
                Selection.activeGameObject.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

            }
			if (GUILayout.Button("CANVAS"))
			{
				Selection.activeGameObject = GameObject.FindAnyObjectByType<Canvas>().gameObject;
				SceneView.lastActiveSceneView.FrameSelected();
			}
			if (GUILayout.Button("Camera"))
			{
				Selection.activeGameObject = Camera.main.gameObject;
				SceneView.lastActiveSceneView.FrameSelected();
			}
			if (GUILayout.Button("Duplicate"))
			{
				GameObject old = Selection.activeGameObject;
				GameObject nG = GameObject.Instantiate(Selection.activeGameObject,old.transform.parent);
				Tools.current = Tool.Move;

				nG.transform.position = old.transform.position;
				Selection.activeGameObject = nG;
			}
			
			if (GUILayout.Button("SAVE"))
			{
				EditorApplication.ExecuteMenuItem("File/Save");
				EditorApplication.ExecuteMenuItem("File/Save Project");

			}
			if (GUILayout.Button("BUILD"))
			{
				EditorApplication.ExecuteMenuItem("File/Save");
				EditorApplication.ExecuteMenuItem("File/Build Profiles");

			}
		}
	}
	public static class Vector3Extension
    {
		public static Vector3 SetX(this Vector3 v,float newX)
        {

			return new Vector3(newX, v.y, v.z);
        }
    }

	static class SceneHelper
	{
		static string sceneToOpen;

		public static void StartScene(string sceneName)
		{
			if(EditorApplication.isPlaying)
			{
				EditorApplication.isPlaying = false;
			}

			sceneToOpen = sceneName;
			EditorApplication.update += OnUpdate;
		}

		static void OnUpdate()
		{
			if (sceneToOpen == null ||
			    EditorApplication.isPlaying || EditorApplication.isPaused ||
			    EditorApplication.isCompiling || EditorApplication.isPlayingOrWillChangePlaymode)
			{
				return;
			}

			EditorApplication.update -= OnUpdate;

			if(EditorSceneManager.SaveCurrentModifiedScenesIfUserWantsTo())
			{
				// need to get scene via search because the path to the scene
				// file contains the package version so it'll change over time
				string[] guids = AssetDatabase.FindAssets("t:scene " + sceneToOpen, null);
				if (guids.Length == 0)
				{
					Debug.LogWarning("Couldn't find scene file");
				}
				else
				{
					string scenePath = AssetDatabase.GUIDToAssetPath(guids[0]);
					EditorSceneManager.OpenScene(scenePath);
					EditorApplication.isPlaying = true;
				}
			}
			sceneToOpen = null;
		}
	}
}