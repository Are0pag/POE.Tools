using UnityEditor;

namespace Scripts.Tools.CustomEdit
{
    internal class EditorMenu : EditorWindow
    {
        [MenuItem(DirectoryNames.GET_COMPONENT_PATH)]
        static private void GetComponents() {
            GetComponentInitializer.InitializeComponents();
        }

        [MenuItem(DirectoryNames.FIND_OBJECT_IN_SCENE_PATH)]
        static private void FindObjectInScene() {
            FindInSceneInitializer.InitializeComponents();
        }
    }
}