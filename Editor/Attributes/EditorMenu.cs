using Scripts.Tools.CustomEdit;
using UnityEditor;

namespace Scripts.Tools.Attributes.CustomEdit
{
    internal class EditorMenu : EditorWindow
    {
        [MenuItem(RootDN.CEM_ROOT + nameof(Attributes) + DirectoryNames.SLASH + nameof(Controller.InitializeScene))]
        static private void GetComponents() {
            InvokerOnScriptsReload.StoreAllMonoBehaviorsFromScene();
        }
    }
}