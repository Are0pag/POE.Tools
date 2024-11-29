
namespace Scripts.Tools.CustomEdit
{
    /// <summary>
    /// usings with this directory and lines of code with this class MUST be surrounded by #if Unity_Editor 
    /// </summary>
    static public class DirectoryNames
    {
        /// <summary>
        /// "GameDataProviders/" - root Game Data Providers directory path
        /// </summary>
        private const string GDP_ROOT = "GameDataProviders/";
        public const string SLASH = "/";

        public const string GAME_OBJECTS_DATA_PATH = GDP_ROOT + "GameObjects/";
        public const string STATS_DATA_PATH = GDP_ROOT + "Stats/";
        public const string SYSTEMS_DATA_PATH = GDP_ROOT + "SystemsData/";
        
        /// <summary>
        /// Grid
        /// </summary>
        public const string GRID_CELLS_PATH = GAME_OBJECTS_DATA_PATH + "GridCellData/";
        public const string GRID_SYSTEM_DATA_PATH = SYSTEMS_DATA_PATH + "GridSettings/";
        
        
        public const string UNITS_DATA_PATH = GAME_OBJECTS_DATA_PATH + "UnitSystemData/";

        /// <summary>
        /// "CustomEditorMenu/" - root directory name for Custom Editor Menu
        /// </summary>
        public const string CEM_ROOT = "CustomEditorMenu/";

        public const string SERVICES_PATH = CEM_ROOT + "Services/";
    }

    static internal class PathExtension
    {
        static internal string ToPath(this string value) {
            return value + "/";
        }
    }
    
    
}