using System;
using System.Collections.Generic;

namespace LosSantosRED.lsr.Data
{
    [Serializable]
    public class GangTerritoryOwnershipSave
    {
        public string ZoneInternalGameName { get; set; }
        public List<GangTerritory> PreviousTerritories { get; set; } = new List<GangTerritory>();
    }
}
