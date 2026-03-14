using AstraMarkerWpf.Models;
using Multicad.DatabaseServices;
using Multicad.Runtime;

namespace AstraMarkerWpf.Commands
{
    public class AstraMarkerCommand
    {
        /// <summary>
        /// Команда создания объекта типа AstraMarket.
        /// </summary>
        [CommandMethod(nameof(CreateAstraMarker), CommandFlags.NoCheck | CommandFlags.NoPrefix)]
        public void CreateAstraMarker()
        {
            try
            {
                AstraMarker astraMarker = new();
                astraMarker.PlaceObject();
                McObjectManager.UpdateAll();
            }
            catch (Exception ex)
            {
                return;
            }
        }

    }
}
