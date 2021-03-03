using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using xiaoye97;

namespace r0uv3n
{
    [BepInDependency("me.xiaoye97.plugin.Dyson.LDBTool", BepInDependency.DependencyFlags.HardDependency)]
    [BepInPlugin("r0uv3n.DSP.plugins.betterlogisticstations", "Better Logistics Stations", "1.0.0")]
    [BepInProcess("DSPGAME.exe")]
    public class BetterLogisticsStation : BaseUnityPlugin
    {
        public static ManualLogSource logger;

        // Need to patch a few different functions to implement this
        // public static ConfigEntry<bool> LogisticsStationMaxItemCountScalesWithStackSize;


        public static ConfigEntry<int> PlanetaryLogisticsStationMaxItemKinds;
        public static ConfigEntry<int> PlanetaryLogisticsStationMaxItemCount;
        public static ConfigEntry<int> InterstellarLogisticsStationMaxItemKinds;
        public static ConfigEntry<int> InterstellarLogisticsStationMaxItemCount;
        void Start()
        {
            logger = Logger;

            // LogisticsStationMaxItemCountScalesWithStackSize = Config.Bind<bool>("General", "LogisticsStationMaxItemCountScalesWithStackSize", false, "If true, scales the maximum item capacity with the stack size of the selected item");
            PlanetaryLogisticsStationMaxItemKinds = Config.Bind<int>("General", "PlanetaryLogisticsStationMaxItemKinds", 6, "Number of different items planetary logistics stations can hold, shouldn't be larger than 6");
            PlanetaryLogisticsStationMaxItemCount = Config.Bind<int>("General", "PlanetaryLogisticsStationMaxItemCount", 5000, "Capacity the planetary logistics station can hold of one item"); // (if scaling with stack size is activated, this will be the value for items with stack size 200)
            InterstellarLogisticsStationMaxItemKinds = Config.Bind<int>("General", "InterstellarLogisticsStationMaxItemKinds", 6, "Number of different items interstellar logistics stations can hold, shouldn't be larger than 6");
            InterstellarLogisticsStationMaxItemCount = Config.Bind<int>("General", "InterstellarLogisticsStationMaxItemCount", 10000, "Capacity the interstellar logistics station can hold of one item"); // (if scaling with stack size is activated, this will be the value for items with stack size 200)

            LDBTool.EditDataAction += Edit;

            // if (LogisticsStationMaxItemCountScalesWithStackSize.Value) {
            // }

            logger.LogInfo("BetterLogisticStations loaded!");
        }

        void Edit(Proto proto)
        {
            if (proto is ItemProto)
            {
                var item = proto as ItemProto;
                if (item.prefabDesc.isStation)
                {
                    if (item.prefabDesc.isStellarStation)
                    {
                        item.prefabDesc.stationMaxItemKinds = InterstellarLogisticsStationMaxItemKinds.Value;
                        item.prefabDesc.stationMaxItemCount = InterstellarLogisticsStationMaxItemCount.Value;
                    }
                    else
                    {
                        item.prefabDesc.stationMaxItemKinds = PlanetaryLogisticsStationMaxItemKinds.Value;
                        item.prefabDesc.stationMaxItemCount = PlanetaryLogisticsStationMaxItemCount.Value;
                    }
                }
            }
        }
    }
}