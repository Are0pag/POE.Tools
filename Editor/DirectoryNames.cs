
namespace Scripts.Tools.CustomEdit
{
    /// <summary>
    /// usings with this directory and lines of code with this class MUST be surrounded by #if Unity_Editor 
    /// </summary>
    static public class DirectoryNames
    {
        public const string SLASH = "/";

        #region Grid

        public const string GRID_CELLS_PATH = RootDN.GAME_OBJECTS_DATA_PATH + "GridCellData/";
        public const string GRID_SYSTEM_DATA_PATH = RootDN.SYSTEMS_DATA_PATH + "GridSettings/";
        public const string GRID_STATS_DATA_PATH = RootDN.STATS_DATA_PATH + "GridStats/";

        #endregion
        
        public const string GRID_VIEW_SETTINGS_PATH = RootDN.SYSTEMS_DATA_PATH + "GridViewSettings/";
        
        public const string GET_COMPONENT_PATH = RootDN.CEM_ROOT + "GetComponents";
    }


    static public class RootDN
    {
        /// <summary>
        /// "GameDataProviders/" - root Game Data Providers directory path
        /// </summary>
        internal const string GDP_ROOT = "GameDataProviders/";
        
        internal const string GAME_OBJECTS_DATA_PATH = GDP_ROOT + "GameObjects/";
        internal const string STATS_DATA_PATH = GDP_ROOT + "Stats/";
        internal const string SYSTEMS_DATA_PATH = GDP_ROOT + "SystemsData/";
        
        /// <summary>
        /// "CustomEditorMenu/" - root directory name for Custom Editor Menu
        /// </summary>
        public const string CEM_ROOT = "CustomEditorMenu/";
    }

    static internal class PathExtension
    {
        static internal string ToPath(this string value) {
            return value + "/";
        }
    }
}