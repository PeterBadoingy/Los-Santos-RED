using LosSantosRED.lsr.Helper;
using LosSantosRED.lsr.Interface;
using Rage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class VehicleRaces : IVehicleRaces
{
    private readonly string ConfigFileName = "Plugins\\LosSantosRED\\VehicleRaces.xml";
    public VehicleRaceTypeManager VehicleRaceTypeManager { get; private set; }
    public void ReadConfig(string configName)
    {
        string fileName = string.IsNullOrEmpty(configName) ? "VehicleRaces_*.xml" : $"VehicleRaces_{configName}.xml";

        DirectoryInfo LSRDirectory = new DirectoryInfo("Plugins\\LosSantosRED");
        FileInfo ConfigFile = LSRDirectory.GetFiles(fileName).Where(x => !x.Name.Contains("+")).OrderByDescending(x => x.Name).FirstOrDefault();
        if (ConfigFile != null && !configName.Equals("Default"))
        {
            EntryPoint.WriteToConsole($"Loaded VehicleRaces config: {ConfigFile.FullName}", 0);
            VehicleRaceTypeManager = Serialization.DeserializeParam<VehicleRaceTypeManager>(ConfigFile.FullName);
        }
        else if (File.Exists(ConfigFileName))
        {
            EntryPoint.WriteToConsole($"Loaded VehicleRaces config  {ConfigFileName}", 0);
            VehicleRaceTypeManager = Serialization.DeserializeParam<VehicleRaceTypeManager>(ConfigFileName);
        }
        else
        {
            EntryPoint.WriteToConsole($"No VehicleRaces config found, creating default", 0);
            DefaultConfig();
            //DefaultConfig_Liberty();
            DefaultConfig_LibertyPP();
        }
        foreach (FileInfo fileInfo in LSRDirectory.GetFiles("VehicleRaces+_*.xml").OrderByDescending(x => x.Name))
        {
            EntryPoint.WriteToConsole($"Loaded ADDITIVE Vehicle Races config  {fileInfo.FullName}", 0);
            VehicleRaceTypeManager additivePossibleItems = Serialization.DeserializeParam<VehicleRaceTypeManager>(fileInfo.FullName);
            foreach (VehicleRaceTrack newItem in additivePossibleItems.VehicleRaceTracks)
            {
                VehicleRaceTypeManager.VehicleRaceTracks.RemoveAll(x => x.ID == newItem.ID);
                VehicleRaceTypeManager.VehicleRaceTracks.Add(newItem);
            }
        }
    }

    private void DefaultConfig_Liberty()
    {
        VehicleRaces_Liberty vehicleRaces_Liberty = new VehicleRaces_Liberty(this);
        vehicleRaces_Liberty.DefaultConfig();
    }
    private void DefaultConfig_LibertyPP()
    {
        VehicleRaces_LibertyPP vehicleRaces_Liberty = new VehicleRaces_LibertyPP(this);
        vehicleRaces_Liberty.DefaultConfig();
    }
    private void DefaultConfig()
    {
        VehicleRaceTypeManager = new VehicleRaceTypeManager();
        VehicleRaceTypeManager.VehicleRaceTracks = new List<VehicleRaceTrack>();

        SandyTracks();
        VineWoodTracks();
        PaletoTracks();
        CentralTracks();
        LaMesaTracks();

        Serialization.SerializeParam(VehicleRaceTypeManager, ConfigFileName);
    }
    private void SandyTracks()
    {
        List<VehicleRaceStartingPosition> vehicleRaceStartingPositions = new List<VehicleRaceStartingPosition>()
        {
            new VehicleRaceStartingPosition(0, new Vector3(1868.027f, 3226.604f, 44.5677f), 39.27186f),
            new VehicleRaceStartingPosition(1, new Vector3(1876.75f, 3215.834f, 44.83164f), 39.09522f),
            new VehicleRaceStartingPosition(2, new Vector3(1866.469f, 3220.694f, 44.6372f), 43.98711f),
            new VehicleRaceStartingPosition(3, new Vector3(1874.058f, 3211.186f, 44.86393f), 38.87733f),
        };
        List<VehicleRaceCheckpoint> vehicleRaceCheckpoints = new List<VehicleRaceCheckpoint>()
        {
            //new VehicleRaceCheckpoint(0, new Vector3(1775.803f, 3375.738f, 39.1007f)),
            //new VehicleRaceCheckpoint(1, new Vector3(1583.795f, 3483.779f, 36.04169f)),
            //new VehicleRaceCheckpoint(2, new Vector3(951.4559f, 3536.375f, 33.44981f)),
            //new VehicleRaceCheckpoint(3,new Vector3(927.9109f, 3630.1f, 31.85251f)),
            //new VehicleRaceCheckpoint(4,new Vector3(1309.275f, 3653.17f, 32.52422f)),
            //new VehicleRaceCheckpoint(5,new Vector3(1663.282f, 3858.711f, 34.23738f)),
            //new VehicleRaceCheckpoint(6,new Vector3(1743.253f, 3758.429f, 33.24446f)),
            //new VehicleRaceCheckpoint(7,new Vector3(1968.987f, 3878.23f, 31.663f)),





            new VehicleRaceCheckpoint(0, new Vector3(1775.803f, 3375.738f, 39.1007f)),
            new VehicleRaceCheckpoint(1,new Vector3(1582.85f, 3480.25f, 36.21559f)),
            new VehicleRaceCheckpoint(2,new Vector3(984.0595f, 3535.763f, 33.54565f)),
            new VehicleRaceCheckpoint(3,new Vector3(956.1648f, 3634.594f, 32.08199f)),
            new VehicleRaceCheckpoint(4,new Vector3(1308.131f, 3652.568f, 32.76283f)),
            new VehicleRaceCheckpoint(5,new Vector3(1628.509f, 3824.556f, 34.63056f)),
            new VehicleRaceCheckpoint(6,new Vector3(1740.17f, 3764.768f, 33.48697f)),
            new VehicleRaceCheckpoint(7,new Vector3(1975.885f, 3888.242f, 31.93978f)),


            //new VehicleRaceCheckpoint(0, new Vector3(1775.803f, 3375.738f, 39.1007f)),
            //new VehicleRaceCheckpoint(1,new Vector3(1702.318f, 3499.852f, 35.91494f)),
            //new VehicleRaceCheckpoint(2,new Vector3(935.6216f, 3535.946f, 33.43148f)),
            //new VehicleRaceCheckpoint(3,new Vector3(931.0949f, 3626.907f, 31.86987f)),
            //new VehicleRaceCheckpoint(4,new Vector3(1540.138f, 3751.758f, 33.91103f)),
            //new VehicleRaceCheckpoint(5,new Vector3(1603.251f, 3673.23f, 33.89013f)),
            //new VehicleRaceCheckpoint(6,new Vector3(1979.965f, 3889.917f, 31.88055f)),

        };
        VehicleRaceTrack sandyDebug = new VehicleRaceTrack("sandyloop1", "Sandy Shores Loop", "Simple loop around Sandy Shores", vehicleRaceCheckpoints, vehicleRaceStartingPositions);
        VehicleRaceTypeManager.VehicleRaceTracks.Add(sandyDebug);

        List<VehicleRaceCheckpoint> vehicleRaceCheckpoints7 = new List<VehicleRaceCheckpoint>()
        {
            new VehicleRaceCheckpoint(0, new Vector3(1775.803f, 3375.738f, 39.1007f)),
            new VehicleRaceCheckpoint(1,new Vector3(1582.85f, 3480.25f, 36.21559f)),
            new VehicleRaceCheckpoint(2,new Vector3(984.0595f, 3535.763f, 33.54565f)),
            new VehicleRaceCheckpoint(3,new Vector3(1979.965f, 3889.917f, 31.88055f)),
        };
        VehicleRaceTrack sandyDebug2 = new VehicleRaceTrack("sandyloop2", "Sandy Shores Small Loop", "Smaller loop around Sandy Shores", vehicleRaceCheckpoints7, vehicleRaceStartingPositions);
        VehicleRaceTypeManager.VehicleRaceTracks.Add(sandyDebug2);
    }
    private void VineWoodTracks()
    {
        List<VehicleRaceStartingPosition> vehicleRaceStartingPositions2 = new List<VehicleRaceStartingPosition>()
        {
            //new VehicleRaceStartingPosition(0,new Vector3(594.9255f, 237.1765f, 102.4954f), 69.08444f),
            //new VehicleRaceStartingPosition(1,new Vector3(593.8934f, 231.983f, 102.473f), 76.16933f),
            //new VehicleRaceStartingPosition(2,new Vector3(603.9206f, 229.4215f, 101.9056f), 75.98711f),
            //new VehicleRaceStartingPosition(3,new Vector3(601.6921f, 235.5364f, 102.1932f), 76.84195f),

            //Player Starts at Rear
            new VehicleRaceStartingPosition(0, new Vector3(641.414f, 219.781f, 97.398f), 74.556f),
            new VehicleRaceStartingPosition(1, new Vector3(642.612f, 224.118f, 97.352f), 74.556f),
            new VehicleRaceStartingPosition(2, new Vector3(631.775f, 222.444f, 98.636f), 74.556f),
            new VehicleRaceStartingPosition(3, new Vector3(632.973f, 226.781f, 98.609f), 74.556f),
            new VehicleRaceStartingPosition(4, new Vector3(622.136f, 225.107f, 99.736f), 74.556f),
            new VehicleRaceStartingPosition(5, new Vector3(623.335f, 229.444f, 99.708f), 74.556f),
            new VehicleRaceStartingPosition(6, new Vector3(612.497f, 227.770f, 100.713f), 74.556f),
            new VehicleRaceStartingPosition(7, new Vector3(613.696f, 232.108f, 100.707f), 74.556f),
            new VehicleRaceStartingPosition(8, new Vector3(602.858f, 230.433f, 101.592f), 74.556f),
            new VehicleRaceStartingPosition(9, new Vector3(604.057f, 234.771f, 101.599f), 74.556f),
            new VehicleRaceStartingPosition(10, new Vector3(593.220f, 233.096f, 102.110f), 74.556f),
            new VehicleRaceStartingPosition(11, new Vector3(594.418f, 237.434f, 102.095f), 74.556f),

        };
        List<VehicleRaceCheckpoint> vehicleRaceCheckpoints2 = new List<VehicleRaceCheckpoint>()
        {
            //new VehicleRaceCheckpoint(0,new Vector3(423.3498f, 295.5466f, 102.4895f)),
            //new VehicleRaceCheckpoint(1,new Vector3(283.6923f, -73.34487f, 69.56183f)),
            //new VehicleRaceCheckpoint(2,new Vector3(-38.75998f, 32.98601f, 71.58444f)),
            //new VehicleRaceCheckpoint(3,new Vector3(-82.37482f, -110.0097f, 57.30961f)),
            //new VehicleRaceCheckpoint(4,new Vector3(-111.9359f, -220.4267f, 44.26889f)),
            //new VehicleRaceCheckpoint(5,new Vector3(-280.4997f, -172.5392f, 39.44448f)),
            //new VehicleRaceCheckpoint(6,new Vector3(-343.272f, -191.9327f, 37.79195f)),
            //new VehicleRaceCheckpoint(7,new Vector3(-418.2509f, -72.76836f, 42.19181f)),
            //new VehicleRaceCheckpoint(8,new Vector3(-391.8105f, 122.2213f, 65.06055f)),
            //new VehicleRaceCheckpoint(9,new Vector3(-643.3143f, 130.383f, 56.60829f)),
            //new VehicleRaceCheckpoint(10,new Vector3(-996.1489f, 71.36115f, 51.30039f)),


            new VehicleRaceCheckpoint(0, new Vector3(467.806f, 279.618f, 102.451f)),
            new VehicleRaceCheckpoint(1, new Vector3(385.774f, 213.875f, 102.448f)),
            new VehicleRaceCheckpoint(2, new Vector3(348.032f, 111.168f, 102.110f)),
            new VehicleRaceCheckpoint(3, new Vector3(312.919f, 14.082f, 82.591f)),
            new VehicleRaceCheckpoint(4, new Vector3(222.850f, -61.809f, 68.711f)),
            new VehicleRaceCheckpoint(5, new Vector3(18.952f, 11.798f, 69.847f)),
            new VehicleRaceCheckpoint(6, new Vector3(-91.485f, -127.899f, 57.197f)),
            new VehicleRaceCheckpoint(7, new Vector3(-128.882f, -215.658f, 44.191f)),
            new VehicleRaceCheckpoint(8, new Vector3(-330.207f, -184.122f, 38.348f)),
            new VehicleRaceCheckpoint(9, new Vector3(-418.537f, -70.090f, 42.420f)),
            new VehicleRaceCheckpoint(10, new Vector3(-390.899f, 70.795f, 58.081f)),
            new VehicleRaceCheckpoint(11, new Vector3(-453.634f, 128.309f, 63.866f)),
            new VehicleRaceCheckpoint(12, new Vector3(-692.969f, 120.730f, 55.783f)),
            new VehicleRaceCheckpoint(13, new Vector3(-878.130f, 79.802f, 51.369f)),
            new VehicleRaceCheckpoint(14, new Vector3(-984.524f, 78.406f, 51.258f)),


        };
        VehicleRaceTrack vinewoodDebug = new VehicleRaceTrack("vinewoodRace1", "Vinewood Twisted Loop", "Long race through Vinewood to the Golf Corse", vehicleRaceCheckpoints2, vehicleRaceStartingPositions2);
        VehicleRaceTypeManager.VehicleRaceTracks.Add(vinewoodDebug);

        List<VehicleRaceStartingPosition> vehicleRaceStartingPositions3 = new List<VehicleRaceStartingPosition>()
        {
            //new VehicleRaceStartingPosition(0,new Vector3(594.9255f, 237.1765f, 102.4954f), 69.08444f),
            //new VehicleRaceStartingPosition(1,new Vector3(593.8934f, 231.983f, 102.473f), 76.16933f),
            //new VehicleRaceStartingPosition(2,new Vector3(603.9206f, 229.4215f, 101.9056f), 75.98711f),
            //new VehicleRaceStartingPosition(3,new Vector3(601.6921f, 235.5364f, 102.1932f), 76.84195f),

            //Player Starts at Rear
            new VehicleRaceStartingPosition(0, new Vector3(641.414f, 219.781f, 97.398f), 74.556f),
            new VehicleRaceStartingPosition(1, new Vector3(642.612f, 224.118f, 97.352f), 74.556f),
            new VehicleRaceStartingPosition(2, new Vector3(631.775f, 222.444f, 98.636f), 74.556f),
            new VehicleRaceStartingPosition(3, new Vector3(632.973f, 226.781f, 98.609f), 74.556f),
            new VehicleRaceStartingPosition(4, new Vector3(622.136f, 225.107f, 99.736f), 74.556f),
            new VehicleRaceStartingPosition(5, new Vector3(623.335f, 229.444f, 99.708f), 74.556f),
            new VehicleRaceStartingPosition(6, new Vector3(612.497f, 227.770f, 100.713f), 74.556f),
            new VehicleRaceStartingPosition(7, new Vector3(613.696f, 232.108f, 100.707f), 74.556f),
            new VehicleRaceStartingPosition(8, new Vector3(602.858f, 230.433f, 101.592f), 74.556f),
            new VehicleRaceStartingPosition(9, new Vector3(604.057f, 234.771f, 101.599f), 74.556f),
            new VehicleRaceStartingPosition(10, new Vector3(593.220f, 233.096f, 102.110f), 74.556f),
            new VehicleRaceStartingPosition(11, new Vector3(594.418f, 237.434f, 102.095f), 74.556f),

        };
        List<VehicleRaceCheckpoint> vehicleRaceCheckpoints3 = new List<VehicleRaceCheckpoint>()
        {
            //new VehicleRaceCheckpoint(0,new Vector3(31.48836f, 256.0826f, 109.0203f)),
            //new VehicleRaceCheckpoint(1,new Vector3(-2172.701f, -344.3154f, 12.60608f)),


            new VehicleRaceCheckpoint(0, new Vector3(477.283f, 276.457f, 102.554f)),
            new VehicleRaceCheckpoint(1, new Vector3(209.676f, 359.033f, 105.607f)),
            new VehicleRaceCheckpoint(2, new Vector3(77.638f, 325.864f, 111.668f)),
            new VehicleRaceCheckpoint(3, new Vector3(-59.474f, 265.727f, 103.126f)),
            new VehicleRaceCheckpoint(4, new Vector3(-247.789f, 269.180f, 91.487f)),
            new VehicleRaceCheckpoint(5, new Vector3(-428.453f, 248.833f, 82.667f)),
            new VehicleRaceCheckpoint(6, new Vector3(-627.979f, 269.832f, 81.115f)),
            new VehicleRaceCheckpoint(7, new Vector3(-791.616f, 223.406f, 75.567f)),
            new VehicleRaceCheckpoint(8, new Vector3(-1039.056f, 271.329f, 64.114f)),
            new VehicleRaceCheckpoint(9, new Vector3(-1195.486f, 251.040f, 67.299f)),
            new VehicleRaceCheckpoint(10, new Vector3(-1347.520f, 222.601f, 58.250f)),
            new VehicleRaceCheckpoint(11, new Vector3(-1443.099f, 125.656f, 52.014f)),
            new VehicleRaceCheckpoint(12, new Vector3(-1439.997f, -53.240f, 52.047f)),
            new VehicleRaceCheckpoint(13, new Vector3(-1523.305f, -138.252f, 52.228f)),
            new VehicleRaceCheckpoint(14, new Vector3(-1617.469f, -238.535f, 53.619f)),
            new VehicleRaceCheckpoint(15, new Vector3(-1739.539f, -347.558f, 46.062f)),
            new VehicleRaceCheckpoint(16, new Vector3(-1860.202f, -221.560f, 38.450f)),
            new VehicleRaceCheckpoint(17, new Vector3(-2004.195f, -162.594f, 28.602f)),
            new VehicleRaceCheckpoint(18, new Vector3(-2172.433f, -326.268f, 12.638f)),
        };
        VehicleRaceTrack vinewoodLONGDebug = new VehicleRaceTrack("vinewoodRace2", "Vinewood Cross Town", "Long race through Vinewood to the coast many checkpoints.", vehicleRaceCheckpoints3, vehicleRaceStartingPositions3);
        VehicleRaceTypeManager.VehicleRaceTracks.Add(vinewoodLONGDebug);



        List<VehicleRaceStartingPosition> vinewood3start = new List<VehicleRaceStartingPosition>()
        {
            //new VehicleRaceStartingPosition(0, new Vector3(-1543.546f, -197.2341f, 54.76277f), 38.42368f),
            //new VehicleRaceStartingPosition(1, new Vector3(-1535.816f, -207.0271f, 54.03721f), 38.3179f),
            //new VehicleRaceStartingPosition(2, new Vector3(-1538.248f, -195.0614f, 54.58556f), 43.03611f),
            //new VehicleRaceStartingPosition(3, new Vector3(-1528.094f, -206.51f, 53.52767f), 43.48877f),

            //Player starts at rear
            new VehicleRaceStartingPosition(0, new Vector3(-1506.158f, -231.788f, 50.001f), 41.218f),
            new VehicleRaceStartingPosition(1, new Vector3(-1509.919f, -235.082f, 50.079f), 41.218f),
            new VehicleRaceStartingPosition(2, new Vector3(-1512.748f, -224.266f, 50.608f), 41.218f),
            new VehicleRaceStartingPosition(3, new Vector3(-1516.509f, -227.560f, 50.684f), 41.218f),
            new VehicleRaceStartingPosition(4, new Vector3(-1519.337f, -216.744f, 51.651f), 41.218f),
            new VehicleRaceStartingPosition(5, new Vector3(-1523.098f, -220.038f, 51.730f), 41.218f),
            new VehicleRaceStartingPosition(6, new Vector3(-1525.926f, -209.222f, 52.789f), 41.218f),
            new VehicleRaceStartingPosition(7, new Vector3(-1529.687f, -212.516f, 52.860f), 41.218f),
            new VehicleRaceStartingPosition(8, new Vector3(-1532.516f, -201.700f, 53.728f), 41.218f),
            new VehicleRaceStartingPosition(9, new Vector3(-1536.276f, -204.994f, 53.804f), 41.218f),
            new VehicleRaceStartingPosition(10, new Vector3(-1539.105f, -194.178f, 54.258f), 41.218f),
            new VehicleRaceStartingPosition(11, new Vector3(-1542.866f, -197.472f, 54.356f), 41.218f),

        };
        List<VehicleRaceCheckpoint> vinewood3checkpoints = new List<VehicleRaceCheckpoint>()
        {
            //new VehicleRaceCheckpoint(0, new Vector3(-1592.985f, -134.3829f, 55.47266f)),
            //new VehicleRaceCheckpoint(1, new Vector3(-1851.486f, 140.209f, 78.69758f)),
            //new VehicleRaceCheckpoint(2, new Vector3(-1746.352f, 812.6461f, 141.1693f)),
            //new VehicleRaceCheckpoint(3, new Vector3(-1633.375f, 1043.433f, 152.5267f)),
            //new VehicleRaceCheckpoint(4, new Vector3(-1471.54f, 1795.392f, 83.93646f)),
            //new VehicleRaceCheckpoint(5, new Vector3(-1531.019f, 2142.836f, 54.96165f)),
            //new VehicleRaceCheckpoint(6, new Vector3(-1654.215f, 2383.382f, 35.76158f)),
            //new VehicleRaceCheckpoint(7, new Vector3(-1754.635f, 2429.498f, 30.93673f)),
            //new VehicleRaceCheckpoint(8, new Vector3(-2012.238f, 2343.076f, 33.18634f)),


            new VehicleRaceCheckpoint(0, new Vector3(-1606.016f, -109.239f, 57.241f)),
            new VehicleRaceCheckpoint(1, new Vector3(-1779.288f, 84.953f, 69.394f)),
            new VehicleRaceCheckpoint(2, new Vector3(-1899.201f, 177.258f, 81.851f)),
            new VehicleRaceCheckpoint(3, new Vector3(-1977.112f, 438.280f, 99.459f)),
            new VehicleRaceCheckpoint(4, new Vector3(-1872.541f, 716.501f, 129.096f)),
            new VehicleRaceCheckpoint(5, new Vector3(-1708.338f, 865.341f, 146.084f)),
            new VehicleRaceCheckpoint(6, new Vector3(-1628.329f, 1062.243f, 152.495f)),
            new VehicleRaceCheckpoint(7, new Vector3(-1608.546f, 1337.047f, 132.748f)),
            new VehicleRaceCheckpoint(8, new Vector3(-1485.156f, 1510.304f, 114.724f)),
            new VehicleRaceCheckpoint(9, new Vector3(-1480.054f, 1771.965f, 86.603f)),
            new VehicleRaceCheckpoint(10, new Vector3(-1490.308f, 2050.227f, 61.804f)),
            new VehicleRaceCheckpoint(11, new Vector3(-1539.825f, 2184.522f, 54.722f)),
            new VehicleRaceCheckpoint(12, new Vector3(-1651.947f, 2378.044f, 36.826f)),
            new VehicleRaceCheckpoint(13, new Vector3(-1756.626f, 2427.221f, 31.015f)),
            new VehicleRaceCheckpoint(14, new Vector3(-2003.061f, 2346.842f, 33.066f)),

        };
        VehicleRaceTrack vinewood3 = new VehicleRaceTrack("vinewoodRace3", "Morning Wood Mountain Route", "Race through the mountain freeways to Lago Zancudo", vinewood3checkpoints, vinewood3start);
        VehicleRaceTypeManager.VehicleRaceTracks.Add(vinewood3);


    }
    private void PaletoTracks()
    {
        List<VehicleRaceStartingPosition> paletoLoop1Starting = new List<VehicleRaceStartingPosition>()
        {
            new VehicleRaceStartingPosition(0,new Vector3(218.0589f, 6565.234f, 31.52061f), 106.4273f),
            new VehicleRaceStartingPosition(1,new Vector3(205.2844f, 6560.81f, 31.64036f), 109.7968f),
            new VehicleRaceStartingPosition(2,new Vector3(190.9381f, 6561.395f, 31.71398f), 110.7484f),
            new VehicleRaceStartingPosition(3,new Vector3(182.8164f, 6552.707f, 31.65496f), 120.4496f),


            //Player Last
            new VehicleRaceStartingPosition(0, new Vector3(183.611f, 6562.822f, 30.980f), 119.115f),
            new VehicleRaceStartingPosition(1, new Vector3(185.800f, 6558.891f, 31.026f), 119.115f),
            new VehicleRaceStartingPosition(2, new Vector3(187.990f, 6554.959f, 30.997f), 119.115f),
            new VehicleRaceStartingPosition(3, new Vector3(174.874f, 6557.957f, 30.972f), 119.115f),
            new VehicleRaceStartingPosition(4, new Vector3(177.064f, 6554.025f, 30.988f), 119.115f),
            new VehicleRaceStartingPosition(5, new Vector3(179.253f, 6550.094f, 30.948f), 119.115f),
            new VehicleRaceStartingPosition(6, new Vector3(166.138f, 6553.091f, 30.924f), 119.115f),
            new VehicleRaceStartingPosition(7, new Vector3(168.327f, 6549.159f, 30.927f), 119.115f),
            new VehicleRaceStartingPosition(8, new Vector3(170.517f, 6545.228f, 30.896f), 119.115f),
            new VehicleRaceStartingPosition(9, new Vector3(157.401f, 6548.225f, 30.887f), 119.115f),
            new VehicleRaceStartingPosition(10, new Vector3(159.591f, 6544.294f, 30.865f), 119.115f),
            new VehicleRaceStartingPosition(11, new Vector3(161.780f, 6540.362f, 30.840f), 119.115f),

        };
        List<VehicleRaceCheckpoint> paletoLoop1Checkpoints = new List<VehicleRaceCheckpoint>()
        {
            //old
            //new VehicleRaceCheckpoint(0,new Vector3(143.2037f, 6526.385f, 31.3439f)),
            //new VehicleRaceCheckpoint(1,new Vector3(-202.2245f, 6173.541f, 30.57405f)),
            //new VehicleRaceCheckpoint(2,new Vector3(-181.1622f, 6468.749f, 30.21145f)),
            //new VehicleRaceCheckpoint(3,new Vector3(150.0628f, 6533.176f, 31.4289f)),

            // Already commentedout below
            //new VehicleRaceCheckpoint(2,new Vector3(-341.7607f, 6269.313f, 30.86405f)),
            //new VehicleRaceCheckpoint(3,new Vector3(-358.0514f, 6293.811f, 29.61264f)),
            //2 - 3
            //new VehicleRaceCheckpoint(0,new Vector3(143.2037f, 6526.385f, 31.3439f)),
            //new VehicleRaceCheckpoint(1,new Vector3(-215.3243f, 6169.238f, 30.88095f)),
            //new VehicleRaceCheckpoint(2,new Vector3(-294.1931f, 6220.725f, 31.19704f)),
            //new VehicleRaceCheckpoint(3,new Vector3(-358.0514f, 6293.811f, 29.61264f)),
            //new VehicleRaceCheckpoint(4,new Vector3(-181.1622f, 6468.749f, 30.21145f)),
            //new VehicleRaceCheckpoint(5,new Vector3(150.0628f, 6533.176f, 31.4289f)),

            new VehicleRaceCheckpoint(0, new Vector3(91.137f, 6473.549f, 30.921f)),
            new VehicleRaceCheckpoint(1, new Vector3(-187.700f, 6194.844f, 30.755f)),
            new VehicleRaceCheckpoint(2, new Vector3(-255.678f, 6182.249f, 31.006f)),
            new VehicleRaceCheckpoint(3, new Vector3(-332.893f, 6259.959f, 31.136f)),
            new VehicleRaceCheckpoint(4, new Vector3(-334.125f, 6333.259f, 29.752f)),
            new VehicleRaceCheckpoint(5, new Vector3(-77.900f, 6583.973f, 29.158f)),
            new VehicleRaceCheckpoint(6, new Vector3(112.571f, 6569.387f, 31.184f)),

        };
        VehicleRaceTrack paletoLoop1 = new VehicleRaceTrack("paletoloop1", "Paleto Bay Loop", "Do a loop around Paleto Bay", paletoLoop1Checkpoints, paletoLoop1Starting);
        VehicleRaceTypeManager.VehicleRaceTracks.Add(paletoLoop1);



        List<VehicleRaceStartingPosition> paletoLoop2Starting = new List<VehicleRaceStartingPosition>()
        {
            //new VehicleRaceStartingPosition(0,new Vector3(218.0589f, 6565.234f, 31.52061f), 106.4273f),
            //new VehicleRaceStartingPosition(1,new Vector3(205.2844f, 6560.81f, 31.64036f), 109.7968f),
            //new VehicleRaceStartingPosition(2,new Vector3(190.9381f, 6561.395f, 31.71398f), 110.7484f),
            //new VehicleRaceStartingPosition(3,new Vector3(182.8164f, 6552.707f, 31.65496f), 120.4496f),


            //Player Last
            new VehicleRaceStartingPosition(0, new Vector3(240.152f, 6574.713f, 30.455f), 106.063f),
            new VehicleRaceStartingPosition(1, new Vector3(241.397f, 6570.389f, 30.401f), 106.063f),
            new VehicleRaceStartingPosition(2, new Vector3(230.542f, 6571.946f, 30.679f), 106.063f),
            new VehicleRaceStartingPosition(3, new Vector3(231.787f, 6567.622f, 30.618f), 106.063f),
            new VehicleRaceStartingPosition(4, new Vector3(220.933f, 6569.179f, 30.838f), 106.063f),
            new VehicleRaceStartingPosition(5, new Vector3(222.178f, 6564.855f, 30.769f), 106.063f),
            new VehicleRaceStartingPosition(6, new Vector3(211.323f, 6566.413f, 30.963f), 106.063f),
            new VehicleRaceStartingPosition(7, new Vector3(212.568f, 6562.088f, 30.888f), 106.063f),
            new VehicleRaceStartingPosition(8, new Vector3(201.713f, 6563.646f, 31.017f), 106.063f),
            new VehicleRaceStartingPosition(9, new Vector3(202.959f, 6559.321f, 30.957f), 106.063f),
            new VehicleRaceStartingPosition(10, new Vector3(192.104f, 6560.878f, 31.034f), 106.063f),
            new VehicleRaceStartingPosition(11, new Vector3(193.349f, 6556.554f, 30.994f), 106.063f),

        };
        List<VehicleRaceCheckpoint> paletoLoop2Checkpoints = new List<VehicleRaceCheckpoint>()
        {
            //old
            //new VehicleRaceCheckpoint(0,new Vector3(141.9506f, 6543.649f, 31.27871f)),
            //new VehicleRaceCheckpoint(1,new Vector3(87.16878f, 6598.012f, 31.2261f)),
            //new VehicleRaceCheckpoint(2,new Vector3(-290.8184f, 6247.322f, 31.10103f)),
            //new VehicleRaceCheckpoint(3,new Vector3(-237.6497f, 6163.285f, 31.16849f)),
            //new VehicleRaceCheckpoint(4,new Vector3(152.6836f, 6522.836f, 31.30534f)),


            new VehicleRaceCheckpoint(0, new Vector3(100.584f, 6581.964f, 31.184f)),
            new VehicleRaceCheckpoint(1, new Vector3(33.868f, 6569.206f, 31.000f)),
            new VehicleRaceCheckpoint(2, new Vector3(-254.884f, 6279.208f, 31.050f)),
            new VehicleRaceCheckpoint(3, new Vector3(-262.779f, 6189.532f, 31.016f)),
            new VehicleRaceCheckpoint(4, new Vector3(-182.802f, 6189.950f, 30.752f)),
            new VehicleRaceCheckpoint(5, new Vector3(75.396f, 6445.447f, 30.879f)),
        };
        VehicleRaceTrack paletoLoop2 = new VehicleRaceTrack("paletoloop2", "Paleto Bay Alternate Loop", "Do a loop around Paleto Bay", paletoLoop2Checkpoints, paletoLoop2Starting);
        VehicleRaceTypeManager.VehicleRaceTracks.Add(paletoLoop2);



        List<VehicleRaceStartingPosition> paletoDrag1Starting = new List<VehicleRaceStartingPosition>()
        {
            //new VehicleRaceStartingPosition(0,new Vector3(218.0589f, 6565.234f, 31.52061f), 106.4273f),
            //new VehicleRaceStartingPosition(1,new Vector3(205.2844f, 6560.81f, 31.64036f), 109.7968f),
            //new VehicleRaceStartingPosition(2,new Vector3(190.9381f, 6561.395f, 31.71398f), 110.7484f),
            //new VehicleRaceStartingPosition(3,new Vector3(182.8164f, 6552.707f, 31.65496f), 120.4496f),

            //Player Last
            new VehicleRaceStartingPosition(0, new Vector3(1726.503f, 6373.702f, 33.484f), 75.969f),
            new VehicleRaceStartingPosition(1, new Vector3(1727.594f, 6378.067f, 33.495f), 75.969f),
            new VehicleRaceStartingPosition(2, new Vector3(1716.801f, 6376.126f, 32.717f), 75.969f),
            new VehicleRaceStartingPosition(3, new Vector3(1717.892f, 6380.492f, 32.723f), 75.969f),
            new VehicleRaceStartingPosition(4, new Vector3(1707.100f, 6378.550f, 31.948f), 75.969f),
            new VehicleRaceStartingPosition(5, new Vector3(1708.191f, 6382.916f, 31.952f), 75.969f),
            new VehicleRaceStartingPosition(6, new Vector3(1697.398f, 6380.975f, 31.189f), 75.969f),
            new VehicleRaceStartingPosition(7, new Vector3(1698.489f, 6385.341f, 31.190f), 75.969f),
            new VehicleRaceStartingPosition(8, new Vector3(1687.696f, 6383.399f, 30.483f), 75.969f),
            new VehicleRaceStartingPosition(9, new Vector3(1688.787f, 6387.765f, 30.481f), 75.969f),
            new VehicleRaceStartingPosition(10, new Vector3(1677.995f, 6385.824f, 29.829f), 75.969f),
            new VehicleRaceStartingPosition(11, new Vector3(1679.086f, 6390.189f, 29.826f), 75.969f),

        };
        List<VehicleRaceCheckpoint> paletoDrag1Checkpoints = new List<VehicleRaceCheckpoint>()
        {
            //new VehicleRaceCheckpoint(0,new Vector3(143.2037f, 6526.385f, 31.3439f)),
            //new VehicleRaceCheckpoint(1, new Vector3(-769.4749f, 5497.793f, 34.48269f)),

            new VehicleRaceCheckpoint(0, new Vector3(1537.639f, 6439.318f, 23.158f)),
            new VehicleRaceCheckpoint(1, new Vector3(1160.191f, 6492.126f, 20.605f)),
            new VehicleRaceCheckpoint(2, new Vector3(615.282f, 6536.960f, 27.776f)),
            new VehicleRaceCheckpoint(3, new Vector3(89.228f, 6471.545f, 30.907f)),
            new VehicleRaceCheckpoint(4, new Vector3(-455.263f, 5909.874f, 32.377f)),
            new VehicleRaceCheckpoint(5, new Vector3(-621.533f, 5602.841f, 38.632f)),
            new VehicleRaceCheckpoint(6, new Vector3(-805.678f, 5475.634f, 33.488f)),
        };
        VehicleRaceTrack paletoDrag1 = new VehicleRaceTrack("paletodrag1", "Paleto Bay Drag", "Drag race across paleto bay", paletoDrag1Checkpoints, paletoDrag1Starting);
        VehicleRaceTypeManager.VehicleRaceTracks.Add(paletoDrag1);

    }



    private void CentralTracks()
    {
        List<VehicleRaceStartingPosition> central1start = new List<VehicleRaceStartingPosition>()
        {
            //new VehicleRaceStartingPosition(0, new Vector3(68.09341f, -1183.503f, 28.72084f), 2.301179f),
            //new VehicleRaceStartingPosition(1, new Vector3(72.77296f, -1185.764f, 28.65525f), 8.259281f),
            //new VehicleRaceStartingPosition(2, new Vector3(67.94074f, -1197.815f, 28.72175f), 1.318574f),
            //new VehicleRaceStartingPosition(3, new Vector3(73.90773f, -1198.595f, 28.61956f), 0.1617375f),

            //Player starts at rear
            new VehicleRaceStartingPosition(0, new Vector3(72.262f, -1232.767f, 28.290f), 0.415f),
            new VehicleRaceStartingPosition(1, new Vector3(67.762f, -1232.800f, 28.317f), 0.415f),
            new VehicleRaceStartingPosition(2, new Vector3(72.189f, -1222.768f, 28.299f), 0.415f),
            new VehicleRaceStartingPosition(3, new Vector3(67.690f, -1222.800f, 28.341f), 0.415f),
            new VehicleRaceStartingPosition(4, new Vector3(72.117f, -1212.768f, 28.306f), 0.415f),
            new VehicleRaceStartingPosition(5, new Vector3(67.617f, -1212.801f, 28.343f), 0.415f),
            new VehicleRaceStartingPosition(6, new Vector3(72.044f, -1202.768f, 28.309f), 0.415f),
            new VehicleRaceStartingPosition(7, new Vector3(67.545f, -1202.801f, 28.343f), 0.415f),
            new VehicleRaceStartingPosition(8, new Vector3(71.972f, -1192.769f, 28.306f), 0.415f),
            new VehicleRaceStartingPosition(9, new Vector3(67.472f, -1192.801f, 28.342f), 0.415f),
            new VehicleRaceStartingPosition(10, new Vector3(71.900f, -1182.769f, 28.299f), 0.415f),
            new VehicleRaceStartingPosition(11, new Vector3(67.400f, -1182.801f, 28.342f), 0.415f),
        };
        List<VehicleRaceCheckpoint> central1checkpoints = new List<VehicleRaceCheckpoint>()
        {
            //new VehicleRaceCheckpoint(0, new Vector3(80.30048f, -1067.49f, 28.79053f)),
            //new VehicleRaceCheckpoint(1, new Vector3(172.9085f, -818.7173f, 30.55356f)),
            //new VehicleRaceCheckpoint(2, new Vector3(303.2614f, -470.1808f, 42.71596f)),
            //new VehicleRaceCheckpoint(3, new Vector3(183.5113f, -337.3925f, 43.44069f)),
            //new VehicleRaceCheckpoint(4, new Vector3(-61.29679f, -245.9679f, 44.78765f)),
            //new VehicleRaceCheckpoint(5, new Vector3(-506.2202f, -272.2784f, 35.05164f)),

            new VehicleRaceCheckpoint(0, new Vector3(98.905f, -1040.885f, 28.790f)),
            new VehicleRaceCheckpoint(1, new Vector3(167.667f, -854.560f, 30.313f)),
            new VehicleRaceCheckpoint(2, new Vector3(269.549f, -588.946f, 42.592f)),
            new VehicleRaceCheckpoint(3, new Vector3(307.401f, -451.388f, 42.946f)),
            new VehicleRaceCheckpoint(4, new Vector3(128.366f, -310.709f, 44.708f)),
            new VehicleRaceCheckpoint(5, new Vector3(-127.608f, -216.089f, 44.195f)),
            new VehicleRaceCheckpoint(6, new Vector3(-334.408f, -185.479f, 38.215f)),
            new VehicleRaceCheckpoint(7, new Vector3(-509.182f, -269.209f, 35.042f)),


        };
        VehicleRaceTrack central1 = new VehicleRaceTrack("centralRace1", "Strawberry To Rockford City Hall", "Race to rockford city hall from the Strawberry underpass", central1checkpoints, central1start);
        VehicleRaceTypeManager.VehicleRaceTracks.Add(central1);


        List<VehicleRaceStartingPosition> central2start = new List<VehicleRaceStartingPosition>()
        {
            //new VehicleRaceStartingPosition(0, new Vector3(-414.8134f, -5.814307f, 46.03317f), 264.2367f),
            //new VehicleRaceStartingPosition(1, new Vector3(-426.5735f, -4.847809f, 45.74813f), 265.0832f),
            //new VehicleRaceStartingPosition(2, new Vector3(-415.077f, -10.34778f, 46.00951f), 259.6769f),
            //new VehicleRaceStartingPosition(3, new Vector3(-426.7999f, -8.770337f, 45.73085f), 259.6824f),

            //Player starts at rear
            new VehicleRaceStartingPosition(0, new Vector3(-464.743f, -6.715f, 44.623f), 266.469f),
            new VehicleRaceStartingPosition(1, new Vector3(-464.466f, -2.224f, 44.659f), 266.469f),
            new VehicleRaceStartingPosition(2, new Vector3(-454.762f, -7.331f, 44.794f), 266.469f),
            new VehicleRaceStartingPosition(3, new Vector3(-454.485f, -2.840f, 44.829f), 266.469f),
            new VehicleRaceStartingPosition(4, new Vector3(-444.781f, -7.947f, 44.984f), 266.469f),
            new VehicleRaceStartingPosition(5, new Vector3(-444.504f, -3.456f, 45.012f), 266.469f),
            new VehicleRaceStartingPosition(6, new Vector3(-434.800f, -8.563f, 45.175f), 266.469f),
            new VehicleRaceStartingPosition(7, new Vector3(-434.523f, -4.071f, 45.203f), 266.469f),
            new VehicleRaceStartingPosition(8, new Vector3(-424.819f, -9.179f, 45.385f), 266.469f),
            new VehicleRaceStartingPosition(9, new Vector3(-424.542f, -4.687f, 45.409f), 266.469f),
            new VehicleRaceStartingPosition(10, new Vector3(-414.838f, -9.794f, 45.648f), 266.469f),
            new VehicleRaceStartingPosition(11, new Vector3(-414.561f, -5.303f, 45.656f), 266.469f),

        };
        List<VehicleRaceCheckpoint> central2checkpoints = new List<VehicleRaceCheckpoint>()
        {
            //new VehicleRaceCheckpoint(0, new Vector3(-323.7401f, -25.45497f, 47.50704f)),
            //new VehicleRaceCheckpoint(1, new Vector3(514.7919f, -333.9487f, 42.97514f)),

            new VehicleRaceCheckpoint(0, new Vector3(-321.946f, -32.526f, 47.674f)),
            new VehicleRaceCheckpoint(1, new Vector3(-159.945f, -88.957f, 53.536f)),
            new VehicleRaceCheckpoint(2, new Vector3(48.642f, -163.564f, 54.627f)),
            new VehicleRaceCheckpoint(3, new Vector3(193.841f, -215.883f, 53.487f)),
            new VehicleRaceCheckpoint(4, new Vector3(323.796f, -264.690f, 53.427f)),
            new VehicleRaceCheckpoint(5, new Vector3(508.883f, -337.069f, 43.169f)),
        };
        VehicleRaceTrack central2 = new VehicleRaceTrack("centralRace2", "Burton Cross Town Drag", "Drag race across central LS starting at Burton", central2checkpoints, central2start);
        VehicleRaceTypeManager.VehicleRaceTracks.Add(central2);

        List<VehicleRaceStartingPosition> central3start = new List<VehicleRaceStartingPosition>()
        {
            //new VehicleRaceStartingPosition(0, new Vector3(1180.448f, -2556.885f, 34.84329f), 289.645f),
            //new VehicleRaceStartingPosition(1, new Vector3(1171.138f, -2559.885f, 34.25787f), 287.5368f),
            //new VehicleRaceStartingPosition(2, new Vector3(1181.931f, -2560.759f, 34.80701f), 279.2413f),
            //new VehicleRaceStartingPosition(3, new Vector3(1171.136f, -2563.416f, 34.28861f), 286.6383f),

            //Player starts at rear
            new VehicleRaceStartingPosition(0, new Vector3(1035.512f, -2593.813f, 37.818f), 280.087f),
            new VehicleRaceStartingPosition(1, new Vector3(1034.636f, -2588.890f, 37.819f), 280.087f),
            new VehicleRaceStartingPosition(2, new Vector3(1045.357f, -2592.062f, 37.662f), 280.087f),
            new VehicleRaceStartingPosition(3, new Vector3(1044.482f, -2587.139f, 37.662f), 280.087f),
            new VehicleRaceStartingPosition(4, new Vector3(1055.203f, -2590.310f, 36.510f), 280.087f),
            new VehicleRaceStartingPosition(5, new Vector3(1054.327f, -2585.387f, 36.510f), 280.087f),
            new VehicleRaceStartingPosition(6, new Vector3(1065.048f, -2588.559f, 35.319f), 280.087f),
            new VehicleRaceStartingPosition(7, new Vector3(1064.172f, -2583.636f, 35.320f), 280.087f),
            new VehicleRaceStartingPosition(8, new Vector3(1074.894f, -2586.807f, 34.090f), 280.087f),
            new VehicleRaceStartingPosition(9, new Vector3(1074.018f, -2581.885f, 34.091f), 280.087f),
            new VehicleRaceStartingPosition(10, new Vector3(1084.739f, -2585.056f, 32.805f), 280.087f),
            new VehicleRaceStartingPosition(11, new Vector3(1083.863f, -2580.133f, 32.806f), 280.087f),
        };
        List<VehicleRaceCheckpoint> central3checkpoints = new List<VehicleRaceCheckpoint>()
        {
            //new VehicleRaceCheckpoint(0, new Vector3(1247.396f, -2525.508f, 41.12943f)),
            //new VehicleRaceCheckpoint(1, new Vector3(1240.541f, -2021.258f, 43.51336f)),
            //new VehicleRaceCheckpoint(2, new Vector3(1068.375f, -1284.138f, 25.21841f)),
            //new VehicleRaceCheckpoint(3, new Vector3(715.1257f, -598.6426f, 35.34497f)),
            //new VehicleRaceCheckpoint(4, new Vector3(-111.2042f, -495.9614f, 29.78688f)),
            //new VehicleRaceCheckpoint(5, new Vector3(-237.5093f, -477.4375f, 25.16191f)),
            //new VehicleRaceCheckpoint(6, new Vector3(-414.4864f, -694.7096f, 36.58041f)),
            //new VehicleRaceCheckpoint(7, new Vector3(-410.9584f, -1352.381f, 36.67314f)),
            //new VehicleRaceCheckpoint(8, new Vector3(-675.6441f, -1716.931f, 36.8155f)),
            //new VehicleRaceCheckpoint(9, new Vector3(-764.5367f, -2088.595f, 33.70555f)),
            //new VehicleRaceCheckpoint(10, new Vector3(189.1148f, -2666.291f, 17.49789f)),


            new VehicleRaceCheckpoint(0, new Vector3(1327.597f, -2427.613f, 49.625f)),
            new VehicleRaceCheckpoint(1, new Vector3(1260.462f, -2073.529f, 44.034f)),
            new VehicleRaceCheckpoint(2, new Vector3(1190.450f, -1911.867f, 35.290f)),
            new VehicleRaceCheckpoint(3, new Vector3(1091.047f, -1652.672f, 28.792f)),
            new VehicleRaceCheckpoint(4, new Vector3(1071.511f, -1363.538f, 28.431f)),
            new VehicleRaceCheckpoint(5, new Vector3(1018.357f, -901.596f, 29.853f)),
            new VehicleRaceCheckpoint(6, new Vector3(690.556f, -588.277f, 35.374f)),
            new VehicleRaceCheckpoint(7, new Vector3(384.841f, -498.243f, 34.346f)),
            new VehicleRaceCheckpoint(8, new Vector3(-0.748f, -496.042f, 33.133f)),
            new VehicleRaceCheckpoint(9, new Vector3(-172.361f, -483.356f, 27.390f)),
            new VehicleRaceCheckpoint(10, new Vector3(-318.186f, -476.817f, 32.911f)),
            new VehicleRaceCheckpoint(11, new Vector3(-412.963f, -758.419f, 36.633f)),
            new VehicleRaceCheckpoint(12, new Vector3(-413.164f, -1177.380f, 36.601f)),
            new VehicleRaceCheckpoint(13, new Vector3(-462.470f, -1607.070f, 38.656f)),
            new VehicleRaceCheckpoint(14, new Vector3(-913.739f, -1821.048f, 35.154f)),
            new VehicleRaceCheckpoint(15, new Vector3(-670.355f, -2154.294f, 47.292f)),
            new VehicleRaceCheckpoint(16, new Vector3(-465.309f, -2297.850f, 62.304f)),
            new VehicleRaceCheckpoint(17, new Vector3(-155.647f, -2514.686f, 47.267f)),
            new VehicleRaceCheckpoint(18, new Vector3(159.477f, -2664.617f, 17.998f)),
            new VehicleRaceCheckpoint(19, new Vector3(339.492f, -2676.335f, 19.197f)),
            new VehicleRaceCheckpoint(20, new Vector3(607.086f, -2666.979f, 43.691f)),
            new VehicleRaceCheckpoint(21, new Vector3(1086.766f, -2582.347f, 32.887f)),

        };
        VehicleRaceTrack central3 = new VehicleRaceTrack("centralRace3", "LS Freeway Outer Loop", "Outer Loop around the central LS freeway system", central3checkpoints, central3start);
        VehicleRaceTypeManager.VehicleRaceTracks.Add(central3);

    }
    private void LaMesaTracks() 
    {
        List<VehicleRaceStartingPosition> popdragstart = new List<VehicleRaceStartingPosition>()
        {
            new VehicleRaceStartingPosition(0, new Vector3(805.211f, -1839.172f, 28.910f), 171.446f),
            new VehicleRaceStartingPosition(1, new Vector3(801.255f, -1838.577f, 28.910f), 171.446f),
            new VehicleRaceStartingPosition(2, new Vector3(806.624f, -1829.777f, 28.910f), 171.446f),
            new VehicleRaceStartingPosition(3, new Vector3(802.668f, -1829.182f, 28.910f), 171.446f),
            new VehicleRaceStartingPosition(4, new Vector3(808.037f, -1820.383f, 28.910f), 171.446f),
            new VehicleRaceStartingPosition(5, new Vector3(804.081f, -1819.788f, 28.910f), 171.446f),
            new VehicleRaceStartingPosition(6, new Vector3(809.450f, -1810.989f, 28.910f), 171.446f),
            new VehicleRaceStartingPosition(7, new Vector3(805.494f, -1810.394f, 28.910f), 171.446f),
            new VehicleRaceStartingPosition(8, new Vector3(810.863f, -1801.594f, 28.910f), 171.446f),
            new VehicleRaceStartingPosition(9, new Vector3(806.907f, -1801.000f, 28.910f), 171.446f),
        };
        List<VehicleRaceCheckpoint> popdragcheckpoints = new List<VehicleRaceCheckpoint>()
        {
            new VehicleRaceCheckpoint(0, new Vector3(759.017f, -2111.120f, 28.810f)),
            new VehicleRaceCheckpoint(1, new Vector3(730.069f, -2444.229f, 19.500f)),
        };
        VehicleRaceTrack popdrag = new VehicleRaceTrack("popDrag", "Popular Street Drag", "Go side by side down Popular Street", popdragcheckpoints, popdragstart);
        VehicleRaceTypeManager.VehicleRaceTracks.Add(popdrag); // large bump halfway down that can cause ai drivers to lose control/crash

        List<VehicleRaceStartingPosition> eastsidecircuitstart = new List<VehicleRaceStartingPosition>()
        {
            new VehicleRaceStartingPosition(0, new Vector3(649.959f, -2064.435f, 28.276f), 265.049f),
            new VehicleRaceStartingPosition(1, new Vector3(650.390f, -2059.454f, 28.334f), 265.049f),
            new VehicleRaceStartingPosition(2, new Vector3(659.921f, -2065.298f, 28.276f), 265.049f),
            new VehicleRaceStartingPosition(3, new Vector3(660.353f, -2060.317f, 28.335f), 265.049f),
            new VehicleRaceStartingPosition(4, new Vector3(669.884f, -2066.161f, 28.276f), 265.049f),
            new VehicleRaceStartingPosition(5, new Vector3(670.315f, -2061.180f, 28.335f), 265.049f),
            new VehicleRaceStartingPosition(6, new Vector3(679.847f, -2067.024f, 28.280f), 265.049f),
            new VehicleRaceStartingPosition(7, new Vector3(680.278f, -2062.043f, 28.337f), 265.049f),
            new VehicleRaceStartingPosition(8, new Vector3(689.809f, -2067.887f, 28.281f), 265.049f),
            new VehicleRaceStartingPosition(9, new Vector3(690.241f, -2062.906f, 28.337f), 265.049f),
            new VehicleRaceStartingPosition(10, new Vector3(699.772f, -2068.751f, 28.277f), 265.049f),
            new VehicleRaceStartingPosition(11, new Vector3(700.203f, -2063.769f, 28.336f), 265.049f),
        };
        List<VehicleRaceCheckpoint> eastsidecircuitcheckpoints = new List<VehicleRaceCheckpoint>()
        {
            new VehicleRaceCheckpoint(0, new Vector3(861.172f, -2081.351f, 29.768f)),
            new VehicleRaceCheckpoint(1, new Vector3(1181.717f, -2080.419f, 42.421f)),
            new VehicleRaceCheckpoint(2, new Vector3(1347.013f, -2016.215f, 49.469f)),
            new VehicleRaceCheckpoint(3, new Vector3(1429.498f, -1798.976f, 67.465f)),
            new VehicleRaceCheckpoint(4, new Vector3(1367.893f, -1643.015f, 52.973f)),
            new VehicleRaceCheckpoint(5, new Vector3(1279.461f, -1482.953f, 37.083f)),
            new VehicleRaceCheckpoint(6, new Vector3(1167.861f, -1431.006f, 34.274f)),
            new VehicleRaceCheckpoint(7, new Vector3(866.750f, -1433.706f, 28.753f)),
            new VehicleRaceCheckpoint(8, new Vector3(815.008f, -1518.153f, 28.252f)),
            new VehicleRaceCheckpoint(9, new Vector3(829.001f, -1665.183f, 28.834f)),
            new VehicleRaceCheckpoint(10, new Vector3(772.995f, -1982.281f, 28.807f)),
        };
        VehicleRaceTrack eastsidecircuit = new VehicleRaceTrack("eastsideCircuit", "Eastside Circuit", "Take a ride around the Eastside", eastsidecircuitcheckpoints, eastsidecircuitstart);
        VehicleRaceTypeManager.VehicleRaceTracks.Add(eastsidecircuit);       
        // ai prone to losing control coming over the hill,no shortcut on a corner causing a significant slow down of ai

        List<VehicleRaceStartingPosition> elburropointstart = new List<VehicleRaceStartingPosition>()
        {
            new VehicleRaceStartingPosition(0, new Vector3(1271.024f, -2600.127f, 44.300f), 285.878f),
            new VehicleRaceStartingPosition(1, new Vector3(1275.277f, -2604.115f, 44.449f), 285.878f),
            new VehicleRaceStartingPosition(2, new Vector3(1280.642f, -2597.391f, 44.781f), 285.878f),
            new VehicleRaceStartingPosition(3, new Vector3(1284.896f, -2601.379f, 44.923f), 285.878f),
            new VehicleRaceStartingPosition(4, new Vector3(1290.260f, -2594.655f, 45.258f), 285.878f),
            new VehicleRaceStartingPosition(5, new Vector3(1294.514f, -2598.643f, 45.401f), 285.878f),
            new VehicleRaceStartingPosition(6, new Vector3(1299.879f, -2591.919f, 45.733f), 285.878f),
            new VehicleRaceStartingPosition(7, new Vector3(1304.132f, -2595.907f, 45.868f), 285.878f),
            new VehicleRaceStartingPosition(8, new Vector3(1309.497f, -2589.183f, 46.183f), 285.878f),
            new VehicleRaceStartingPosition(9, new Vector3(1313.751f, -2593.171f, 46.309f), 285.878f),
            new VehicleRaceStartingPosition(10, new Vector3(1319.116f, -2586.447f, 46.600f), 285.878f),
            new VehicleRaceStartingPosition(11, new Vector3(1323.369f, -2590.436f, 46.714f), 285.878f),
        };
        List<VehicleRaceCheckpoint> elburropointcheckpoints = new List<VehicleRaceCheckpoint>()
        {
            new VehicleRaceCheckpoint(0, new Vector3(1451.340f, -2579.668f, 47.779f)),
            new VehicleRaceCheckpoint(1, new Vector3(1618.824f, -2534.294f, 70.578f)),
            new VehicleRaceCheckpoint(2, new Vector3(1632.008f, -2431.224f, 90.022f)),
            new VehicleRaceCheckpoint(3, new Vector3(1677.693f, -2266.232f, 110.673f)),
            new VehicleRaceCheckpoint(4, new Vector3(1681.042f, -2122.632f, 106.833f)),
            new VehicleRaceCheckpoint(5, new Vector3(1726.409f, -1947.849f, 116.160f)),
            new VehicleRaceCheckpoint(6, new Vector3(1719.182f, -1793.383f, 110.499f)),
            new VehicleRaceCheckpoint(7, new Vector3(1807.052f, -1668.285f, 117.398f)),
            new VehicleRaceCheckpoint(8, new Vector3(1813.757f, -1508.802f, 116.337f)),
            new VehicleRaceCheckpoint(9, new Vector3(1894.101f, -1376.753f, 135.831f)),
            new VehicleRaceCheckpoint(10, new Vector3(1917.956f, -1193.461f, 114.702f)),
            new VehicleRaceCheckpoint(11, new Vector3(1966.270f, -1039.826f, 90.024f)),
            new VehicleRaceCheckpoint(12, new Vector3(1974.646f, -926.345f, 78.651f)),
        };
        VehicleRaceTrack elburropoint = new VehicleRaceTrack("ElBurroPoint", "Palomino Highland View", "Take a ride along Palomino Highlands", elburropointcheckpoints, elburropointstart);
        VehicleRaceTypeManager.VehicleRaceTracks.Add(elburropoint);  

        List<VehicleRaceStartingPosition> vinewoodhillsstart = new List<VehicleRaceStartingPosition>()
        {
            new VehicleRaceStartingPosition(0, new Vector3(1087.445f, 794.219f, 152.399f), 331.501f),
            new VehicleRaceStartingPosition(1, new Vector3(1092.831f, 794.708f, 152.310f), 331.501f),
            new VehicleRaceStartingPosition(2, new Vector3(1092.216f, 803.007f, 152.140f), 331.501f),
            new VehicleRaceStartingPosition(3, new Vector3(1097.603f, 803.497f, 152.061f), 331.501f),
            new VehicleRaceStartingPosition(4, new Vector3(1096.988f, 811.796f, 151.930f), 331.501f),
            new VehicleRaceStartingPosition(5, new Vector3(1102.374f, 812.285f, 151.864f), 331.501f),
            new VehicleRaceStartingPosition(6, new Vector3(1101.759f, 820.584f, 151.751f), 331.501f),
            new VehicleRaceStartingPosition(7, new Vector3(1107.145f, 821.073f, 151.692f), 331.501f),
            new VehicleRaceStartingPosition(8, new Vector3(1106.531f, 829.372f, 151.585f), 331.501f),
            new VehicleRaceStartingPosition(9, new Vector3(1111.917f, 829.862f, 151.525f), 331.501f),
            new VehicleRaceStartingPosition(10, new Vector3(1111.302f, 838.161f, 151.417f), 331.501f),
            new VehicleRaceStartingPosition(11, new Vector3(1116.688f, 838.650f, 151.361f), 331.501f),
        };
        List<VehicleRaceCheckpoint> vinewoodhillscheckpoints = new List<VehicleRaceCheckpoint>()
        {
            new VehicleRaceCheckpoint(0, new Vector3(1200.368f, 941.630f, 145.742f)),
            new VehicleRaceCheckpoint(1, new Vector3(1165.210f, 1072.673f, 166.015f)),
            new VehicleRaceCheckpoint(2, new Vector3(1192.937f, 1200.597f, 157.797f)),
            new VehicleRaceCheckpoint(3, new Vector3(1162.098f, 1376.803f, 153.745f)),
            new VehicleRaceCheckpoint(4, new Vector3(1035.945f, 1599.265f, 167.980f)),
            new VehicleRaceCheckpoint(5, new Vector3(855.056f, 1710.118f, 170.038f)),
            new VehicleRaceCheckpoint(6, new Vector3(636.211f, 1770.973f, 194.442f)),
            new VehicleRaceCheckpoint(7, new Vector3(371.088f, 1723.698f, 239.632f)),
            new VehicleRaceCheckpoint(8, new Vector3(147.515f, 1651.960f, 228.470f)),
        };
        VehicleRaceTrack vinewoodhills = new VehicleRaceTrack("Vinewoodhills", "Vinewood Hills Drive", "Take a ride through the scenic Vinewood Hills", vinewoodhillscheckpoints, vinewoodhillsstart);
        VehicleRaceTypeManager.VehicleRaceTracks.Add(vinewoodhills);


        List<VehicleRaceStartingPosition> elyfreewaystart = new List<VehicleRaceStartingPosition>()
        {
            new VehicleRaceStartingPosition(0, new Vector3(1191.207f, -2542.344f, 35.586f), 102.893f),
            new VehicleRaceStartingPosition(1, new Vector3(1192.211f, -2546.731f, 35.535f), 102.893f),
            new VehicleRaceStartingPosition(2, new Vector3(1181.459f, -2544.575f, 34.806f), 102.893f),
            new VehicleRaceStartingPosition(3, new Vector3(1182.464f, -2548.962f, 34.790f), 102.893f),
            new VehicleRaceStartingPosition(4, new Vector3(1171.711f, -2546.807f, 34.071f), 102.893f),
            new VehicleRaceStartingPosition(5, new Vector3(1172.716f, -2551.193f, 34.083f), 102.893f),
            new VehicleRaceStartingPosition(6, new Vector3(1161.964f, -2549.038f, 33.468f), 102.893f),
            new VehicleRaceStartingPosition(7, new Vector3(1162.968f, -2553.425f, 33.559f), 102.893f),
            new VehicleRaceStartingPosition(8, new Vector3(1152.216f, -2551.269f, 32.860f), 102.893f),
            new VehicleRaceStartingPosition(9, new Vector3(1153.220f, -2555.656f, 32.961f), 102.893f),
            new VehicleRaceStartingPosition(10, new Vector3(1142.468f, -2553.501f, 32.093f), 102.893f),
            new VehicleRaceStartingPosition(11, new Vector3(1143.472f, -2557.887f, 32.193f), 102.893f),
        };
        List<VehicleRaceCheckpoint> elyfreewaycheckpoints = new List<VehicleRaceCheckpoint>()
        {
            new VehicleRaceCheckpoint(0, new Vector3(1084.144f, -2568.609f, 32.999f)),
            new VehicleRaceCheckpoint(1, new Vector3(824.331f, -2614.426f, 51.968f)),
            new VehicleRaceCheckpoint(2, new Vector3(346.888f, -2663.600f, 20.109f)),
            new VehicleRaceCheckpoint(3, new Vector3(-13.252f, -2593.288f, 29.215f)),
            new VehicleRaceCheckpoint(4, new Vector3(-266.544f, -2419.965f, 58.516f)),
            new VehicleRaceCheckpoint(5, new Vector3(-543.010f, -2226.366f, 58.557f)),
            new VehicleRaceCheckpoint(6, new Vector3(-816.902f, -2033.817f, 27.716f)),
        };
        VehicleRaceTrack elyfreeway = new VehicleRaceTrack("ely_freeway", "Elysian Freeway Drag", "Over the Bridge and Drag Away", elyfreewaycheckpoints, elyfreewaystart);
        VehicleRaceTypeManager.VehicleRaceTracks.Add(elyfreeway);

        List<VehicleRaceStartingPosition> elyinnerloopracestart = new List<VehicleRaceStartingPosition>()
        {
            new VehicleRaceStartingPosition(0, new Vector3(1232.927f, -2075.496f, 43.315f), 199.310f),
            new VehicleRaceStartingPosition(1, new Vector3(1237.646f, -2073.843f, 43.359f), 199.310f),
            new VehicleRaceStartingPosition(2, new Vector3(1236.234f, -2084.933f, 43.718f), 199.310f),
            new VehicleRaceStartingPosition(3, new Vector3(1240.953f, -2083.280f, 43.745f), 199.310f),
            new VehicleRaceStartingPosition(4, new Vector3(1239.541f, -2094.371f, 44.121f), 199.310f),
            new VehicleRaceStartingPosition(5, new Vector3(1244.260f, -2092.717f, 44.176f), 199.310f),
            new VehicleRaceStartingPosition(6, new Vector3(1242.848f, -2103.808f, 44.517f), 199.310f),
            new VehicleRaceStartingPosition(7, new Vector3(1247.566f, -2102.155f, 44.576f), 199.310f),
            new VehicleRaceStartingPosition(8, new Vector3(1246.154f, -2113.246f, 44.936f), 199.310f),
            new VehicleRaceStartingPosition(9, new Vector3(1250.873f, -2111.592f, 45.004f), 199.310f),
            new VehicleRaceStartingPosition(10, new Vector3(1249.461f, -2122.683f, 45.346f), 199.310f),
            new VehicleRaceStartingPosition(11, new Vector3(1254.180f, -2121.030f, 45.423f), 199.310f),
        };
        List<VehicleRaceCheckpoint> elyinnerloopcheckpoints = new List<VehicleRaceCheckpoint>()
        {
            new VehicleRaceCheckpoint(0, new Vector3(1309.534f, -2253.692f, 51.079f)),
            new VehicleRaceCheckpoint(1, new Vector3(1136.084f, -2557.278f, 31.951f)),
            new VehicleRaceCheckpoint(2, new Vector3(581.342f, -2657.267f, 41.515f)),
            new VehicleRaceCheckpoint(3, new Vector3(185.025f, -2653.570f, 17.685f)),
            new VehicleRaceCheckpoint(4, new Vector3(-182.812f, -2478.665f, 51.261f)),
            new VehicleRaceCheckpoint(5, new Vector3(-661.380f, -2143.569f, 47.413f)),
            new VehicleRaceCheckpoint(6, new Vector3(-911.512f, -1899.979f, 29.305f)),
            new VehicleRaceCheckpoint(7, new Vector3(-825.772f, -1756.479f, 37.096f)),
            new VehicleRaceCheckpoint(8, new Vector3(-494.840f, -1666.855f, 36.880f)),
            new VehicleRaceCheckpoint(9, new Vector3(-396.115f, -1457.365f, 37.889f)),
            new VehicleRaceCheckpoint(10, new Vector3(-343.515f, -1259.813f, 36.700f)),
            new VehicleRaceCheckpoint(11, new Vector3(-32.843f, -1241.850f, 36.629f)),
            new VehicleRaceCheckpoint(12, new Vector3(390.007f, -1230.592f, 39.341f)),
            new VehicleRaceCheckpoint(13, new Vector3(833.033f, -1218.405f, 44.888f)),
            new VehicleRaceCheckpoint(14, new Vector3(989.812f, -1245.690f, 41.714f)),
            new VehicleRaceCheckpoint(15, new Vector3(1068.817f, -1656.846f, 28.800f)),
            new VehicleRaceCheckpoint(16, new Vector3(1258.601f, -2137.953f, 47.13123f)),
        };
        VehicleRaceTrack elyinnerlooprace = new VehicleRaceTrack("ely_freeloop", "LS Freeway Inner Short Loop", "Over the Bridge and Back Around", elyinnerloopcheckpoints, elyinnerloopracestart);
        VehicleRaceTypeManager.VehicleRaceTracks.Add(elyinnerlooprace);


        List<VehicleRaceStartingPosition> lsfreewaydragstart = new List<VehicleRaceStartingPosition>()
        {
            new VehicleRaceStartingPosition(0, new Vector3(1204.193f, -1926.248f, 36.647f), 28.027f),
            new VehicleRaceStartingPosition(1, new Vector3(1198.897f, -1929.067f, 36.787f), 28.027f),
            new VehicleRaceStartingPosition(2, new Vector3(1193.600f, -1931.886f, 36.827f), 28.027f),
            new VehicleRaceStartingPosition(3, new Vector3(1199.494f, -1917.420f, 35.670f), 28.027f),
            new VehicleRaceStartingPosition(4, new Vector3(1194.198f, -1920.240f, 35.788f), 28.027f),
            new VehicleRaceStartingPosition(5, new Vector3(1188.901f, -1923.059f, 35.845f), 28.027f),
            new VehicleRaceStartingPosition(6, new Vector3(1194.795f, -1908.593f, 34.691f), 28.027f),
            new VehicleRaceStartingPosition(7, new Vector3(1189.499f, -1911.412f, 34.830f), 28.027f),
            new VehicleRaceStartingPosition(8, new Vector3(1184.202f, -1914.232f, 34.866f), 28.027f),
            new VehicleRaceStartingPosition(9, new Vector3(1190.096f, -1899.766f, 33.726f), 28.027f),
            new VehicleRaceStartingPosition(10, new Vector3(1184.800f, -1902.585f, 33.882f), 28.027f),
            new VehicleRaceStartingPosition(11, new Vector3(1179.504f, -1905.404f, 33.908f), 28.027f),
        };
        List<VehicleRaceCheckpoint> lsfreewaydragcheckpoints = new List<VehicleRaceCheckpoint>()
        {
            new VehicleRaceCheckpoint(0, new Vector3(1077.277f, -1589.104f, 28.750f)),
            new VehicleRaceCheckpoint(1, new Vector3(1067.916f, -1291.552f, 25.754f)),
            new VehicleRaceCheckpoint(2, new Vector3(1017.853f, -900.812f, 30.098f)),
            new VehicleRaceCheckpoint(3, new Vector3(791.397f, -635.828f, 38.991f)),
            new VehicleRaceCheckpoint(4, new Vector3(364.814f, -495.167f, 33.937f)),
            new VehicleRaceCheckpoint(5, new Vector3(19.593f, -495.979f, 33.673f)),
            new VehicleRaceCheckpoint(6, new Vector3(-301.537f, -499.462f, 24.944f)),
            new VehicleRaceCheckpoint(7, new Vector3(-704.658f, -499.638f, 24.776f)),
            new VehicleRaceCheckpoint(8, new Vector3(-1138.336f, -640.478f, 11.442f)),
            new VehicleRaceCheckpoint(9, new Vector3(-1749.647f, -639.876f, 10.125f)),
            new VehicleRaceCheckpoint(10, new Vector3(-1968.95f, -461.5478f, 11.23273f)),
        };
        VehicleRaceTrack lsfreewaydrag = new VehicleRaceTrack("freewaydrag", "LS Freeway Drag", "El Burro to Pacific Bluffs", lsfreewaydragcheckpoints, lsfreewaydragstart);
        VehicleRaceTypeManager.VehicleRaceTracks.Add(lsfreewaydrag);




    }
}

