using HostMgd.ApplicationServices;
using HostMgd.EditorInput;
using Multicad.Runtime;

using Application = HostMgd.ApplicationServices.Application;

namespace AstraMarkerWpf.Commands
{
    public class HealthCommand
    {
        /// <summary>
        /// Команда для проверки корректности загрузки.
        /// </summary>
        [CommandMethod(nameof(Health), CommandFlags.NoCheck | CommandFlags.NoPrefix)]
        public static void Health()
        {
            Document doc = Application.DocumentManager.MdiActiveDocument;
            if (doc == null)
            {
                return;
            }

            Editor ed = doc.Editor;

            ed.WriteMessage("Плагин загружен корректно.");
        }
    }
}
