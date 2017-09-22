// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using QuickType;
//
//    var data = LegData.FromJson(jsonString);
//
// For POCOs visit quicktype.io?poco
//
namespace Rest
{
    using System;
    using System.Net;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public partial class LegData
    {
        [JsonProperty("data")]
        public Data Data { get; set; }
    }

    public partial class Data
    {
        [JsonProperty("legSpecVersion")]
        public string LegSpecVersion { get; set; }

        [JsonProperty("fisData")]
        public object[] FisData { get; set; }

        [JsonProperty("blockDatagramVersion")]
        public long BlockDatagramVersion { get; set; }

        [JsonProperty("lastDatagramTimestamp")]
        public string LastDatagramTimestamp { get; set; }

        [JsonProperty("processDatagramVersion")]
        public long ProcessDatagramVersion { get; set; }

        [JsonProperty("trainConfig")]
        public TrainConfig TrainConfig { get; set; }

        [JsonProperty("lifesign")]
        public long Lifesign { get; set; }

        [JsonProperty("trainComponent")]
        public TrainComponent TrainComponent { get; set; }

        [JsonProperty("trainLocation")]
        public TrainLocation TrainLocation { get; set; }

        [JsonProperty("trainState")]
        public TrainState TrainState { get; set; }
    }

    public partial class TrainConfig
    {
        [JsonProperty("trainConfigCoachConfig")]
        public TrainConfigCoachConfig[] TrainConfigCoachConfig { get; set; }

        [JsonProperty("trainConfigActDCNum")]
        public string TrainConfigActDCNum { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("trainConfigActivatedDC")]
        public string TrainConfigActivatedDC { get; set; }

        [JsonProperty("trainConfigLEGCoach")]
        public string TrainConfigLEGCoach { get; set; }

        [JsonProperty("trainConfigUnitConfig")]
        public TrainConfigUnitConfig[] TrainConfigUnitConfig { get; set; }

        [JsonProperty("trainConfigCoaches")]
        public long TrainConfigCoaches { get; set; }

        [JsonProperty("trainConfigLEGUnitName")]
        public string TrainConfigLEGUnitName { get; set; }

        [JsonProperty("trainConfigUnits")]
        public long TrainConfigUnits { get; set; }
    }

    public partial class TrainConfigCoachConfig
    {
        [JsonProperty("coachConfigNumber")]
        public string CoachConfigNumber { get; set; }

        [JsonProperty("coachConfigOrient")]
        public string CoachConfigOrient { get; set; }
    }

    public partial class TrainConfigUnitConfig
    {
        [JsonProperty("unitConfigCoachNum")]
        public string UnitConfigCoachNum { get; set; }

        [JsonProperty("unitConfigName")]
        public string UnitConfigName { get; set; }

        [JsonProperty("unitConfigCoachList")]
        public UnitConfigCoachList[] UnitConfigCoachList { get; set; }

        [JsonProperty("unitConfigNLEGCoach")]
        public string UnitConfigNLEGCoach { get; set; }

        [JsonProperty("unitConfigNum")]
        public string UnitConfigNum { get; set; }

        [JsonProperty("unitConfigOPTrainNum")]
        public string UnitConfigOPTrainNum { get; set; }
    }

    public partial class UnitConfigCoachList
    {
        [JsonProperty("coachListUICNumber")]
        public string CoachListUICNumber { get; set; }
    }

    public partial class TrainComponent
    {
        [JsonProperty("trainCompEBreak")]
        public TrainCompEBreak[] TrainCompEBreak { get; set; }

        [JsonProperty("trainCompAudioTrainState")]
        public string TrainCompAudioTrainState { get; set; }

        [JsonProperty("trainCompAirCondCoach")]
        public TrainCompAirCondCoach[] TrainCompAirCondCoach { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("trainCompAirCondUnit")]
        public TrainCompAirCondUnit[] TrainCompAirCondUnit { get; set; }

        [JsonProperty("trainCompCallStation ")]
        public TrainCompCallStation[] TrainCompCallStation { get; set; }

        [JsonProperty("trainCompAudioUnitState")]
        public string TrainCompAudioUnitState { get; set; }

        [JsonProperty("trainCompCoil")]
        public TrainCompCoil[] TrainCompCoil { get; set; }

        [JsonProperty("trainCompLift")]
        public TrainCompLift[] TrainCompLift { get; set; }

        [JsonProperty("trainCompGalley")]
        public TrainCompGalley[] TrainCompGalley { get; set; }

        [JsonProperty("trainCompExtDoors")]
        public TrainCompExtDoor[] TrainCompExtDoors { get; set; }

        [JsonProperty("trainCompIntDoors")]
        public TrainCompIntDoor[] TrainCompIntDoors { get; set; }

        [JsonProperty("trainCompService")]
        public TrainCompService[] TrainCompService { get; set; }

        [JsonProperty("trainCompLight")]
        public TrainCompLight[] TrainCompLight { get; set; }

        [JsonProperty("trainCompSmokeDet")]
        public TrainCompSmokeDet[] TrainCompSmokeDet { get; set; }

        [JsonProperty("trainCompWC")]
        public TrainCompWC[] TrainCompWC { get; set; }
    }

    public partial class TrainCompEBreak
    {
        [JsonProperty("trainCompEBreakState")]
        public string TrainCompEBreakState { get; set; }

        [JsonProperty("trainCompEBreakName")]
        public string TrainCompEBreakName { get; set; }

        [JsonProperty("trainCompEBreakTime")]
        public string TrainCompEBreakTime { get; set; }

        [JsonProperty("trainCompEBreakUICNum")]
        public string TrainCompEBreakUICNum { get; set; }
    }

    public partial class TrainCompAirCondCoach
    {
        [JsonProperty("trainCompAirCondReq")]
        public string TrainCompAirCondReq { get; set; }

        [JsonProperty("trainCompAirCondCTemp")]
        public string TrainCompAirCondCTemp { get; set; }

        [JsonProperty("trainCompAirCondCO2")]
        public long TrainCompAirCondCO2 { get; set; }

        [JsonProperty("trainCompAirCondHumid")]
        public long TrainCompAirCondHumid { get; set; }

        [JsonProperty("trainCompAirCondTemp")]
        public long TrainCompAirCondTemp { get; set; }

        [JsonProperty("trainCompAirCondState")]
        public string TrainCompAirCondState { get; set; }

        [JsonProperty("trainCompAirCondUICNum")]
        public string TrainCompAirCondUICNum { get; set; }
    }

    public partial class TrainCompAirCondUnit
    {
        [JsonProperty("trainCompAirCondTemp")]
        public string TrainCompAirCondTemp { get; set; }

        [JsonProperty("trainCompAirCondHumid")]
        public string TrainCompAirCondHumid { get; set; }

        [JsonProperty("trainCompAirCondUnitNum")]
        public string TrainCompAirCondUnitNum { get; set; }
    }

    public partial class TrainCompCallStation
    {
        [JsonProperty("trainCompCallStationState")]
        public string TrainCompCallStationState { get; set; }

        [JsonProperty("trainCompCallStationName")]
        public string TrainCompCallStationName { get; set; }

        [JsonProperty("trainCompCallStationUICNum")]
        public string TrainCompCallStationUICNum { get; set; }
    }

    public partial class TrainCompCoil
    {
        [JsonProperty("trainCompCoilMaxP")]
        public string TrainCompCoilMaxP { get; set; }

        [JsonProperty("trainCompCoilName")]
        public string TrainCompCoilName { get; set; }

        [JsonProperty("trainCompCoilActP")]
        public string TrainCompCoilActP { get; set; }

        [JsonProperty("trainCompCoilMinP")]
        public string TrainCompCoilMinP { get; set; }

        [JsonProperty("trainCompCoilState")]
        public string TrainCompCoilState { get; set; }

        [JsonProperty("trainCompCoilUICNum")]
        public string TrainCompCoilUICNum { get; set; }
    }

    public partial class TrainCompLift
    {
        [JsonProperty("trainCompLiftReqState")]
        public string TrainCompLiftReqState { get; set; }

        [JsonProperty("trainCompLiftDoorName")]
        public string TrainCompLiftDoorName { get; set; }

        [JsonProperty("trainCompLiftState")]
        public string TrainCompLiftState { get; set; }

        [JsonProperty("trainCompLiftUICNum")]
        public string TrainCompLiftUICNum { get; set; }
    }

    public partial class TrainCompGalley
    {
        [JsonProperty("trainCompGalleyState")]
        public string TrainCompGalleyState { get; set; }

        [JsonProperty("trainCompGalleyUICNum")]
        public string TrainCompGalleyUICNum { get; set; }
    }

    public partial class TrainCompExtDoor
    {
        [JsonProperty("trainCompExtDoorsLocked")]
        public string TrainCompExtDoorsLocked { get; set; }

        [JsonProperty("trainCompExtDoorsPreState")]
        public string TrainCompExtDoorsPreState { get; set; }

        [JsonProperty("trainCompExtDoorsList")]
        public TrainCompExtDoorsList[] TrainCompExtDoorsList { get; set; }

        [JsonProperty("trainCompExtDoorsNum")]
        public string TrainCompExtDoorsNum { get; set; }

        [JsonProperty("trainCompExtDoorsState")]
        public string TrainCompExtDoorsState { get; set; }
    }

    public partial class TrainCompExtDoorsList
    {
        [JsonProperty("trainCompExtDoorsPre")]
        public string TrainCompExtDoorsPre { get; set; }

        [JsonProperty("trainCompExtDoorsStat")]
        public string TrainCompExtDoorsStat { get; set; }

        [JsonProperty("trainCompExtDoorsName")]
        public string TrainCompExtDoorsName { get; set; }

        [JsonProperty("trainCompExtDoorsRel")]
        public string TrainCompExtDoorsRel { get; set; }

        [JsonProperty("trainCompExtDoorsUICNum")]
        public string TrainCompExtDoorsUICNum { get; set; }
    }

    public partial class TrainCompIntDoor
    {
        [JsonProperty("trainCompIntDoorsUICNum")]
        public string TrainCompIntDoorsUICNum { get; set; }

        [JsonProperty("trainCompIntDoorsUICName")]
        public string TrainCompIntDoorsUICName { get; set; }

        [JsonProperty("trainCompIntDoorsUICStat")]
        public string TrainCompIntDoorsUICStat { get; set; }
    }

    public partial class TrainCompService
    {
        [JsonProperty("trainCompServiceState")]
        public string TrainCompServiceState { get; set; }

        [JsonProperty("trainCompServiceName")]
        public string TrainCompServiceName { get; set; }

        [JsonProperty("trainCompServiceUICNum")]
        public string TrainCompServiceUICNum { get; set; }
    }

    public partial class TrainCompLight
    {
        [JsonProperty("trainCompLightEmState")]
        public string TrainCompLightEmState { get; set; }

        [JsonProperty("trainCompLightColTemp")]
        public string TrainCompLightColTemp { get; set; }

        [JsonProperty("trainCompLightAreaName")]
        public string TrainCompLightAreaName { get; set; }

        [JsonProperty("trainCompLightColValue")]
        public string TrainCompLightColValue { get; set; }

        [JsonProperty("trainCompLightScenario")]
        public string TrainCompLightScenario { get; set; }

        [JsonProperty("trainCompLightIntensity")]
        public string TrainCompLightIntensity { get; set; }

        [JsonProperty("trainCompLightSceneList")]
        public string TrainCompLightSceneList { get; set; }

        [JsonProperty("trainCompLightUnitNum")]
        public string TrainCompLightUnitNum { get; set; }
    }

    public partial class TrainCompSmokeDet
    {
        [JsonProperty("trainCompSmokeDetState")]
        public string TrainCompSmokeDetState { get; set; }

        [JsonProperty("trainCompSmokeDetName")]
        public string TrainCompSmokeDetName { get; set; }

        [JsonProperty("trainCompSmokeDetTime")]
        public string TrainCompSmokeDetTime { get; set; }

        [JsonProperty("trainCompSmokeDetUICNum")]
        public string TrainCompSmokeDetUICNum { get; set; }
    }

    public partial class TrainCompWC
    {
        [JsonProperty("trainCompWCSewerage")]
        public string TrainCompWCSewerage { get; set; }

        [JsonProperty("trainCompWCState")]
        public string TrainCompWCState { get; set; }

        [JsonProperty("trainCompWCName")]
        public string TrainCompWCName { get; set; }

        [JsonProperty("trainCompWCSmokeDet")]
        public string TrainCompWCSmokeDet { get; set; }

        [JsonProperty("trainCompWCUICNum")]
        public string TrainCompWCUICNum { get; set; }

        [JsonProperty("trainCompWCWater")]
        public string TrainCompWCWater { get; set; }
    }

    public partial class TrainLocation
    {
        [JsonProperty("trainLocationOSpeed")]
        public long TrainLocationOSpeed { get; set; }

        [JsonProperty("trainLocationDist")]
        public long TrainLocationDist { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("trainLocationGPS")]
        public double[] TrainLocationGPS { get; set; }

        [JsonProperty("trainlocationV0")]
        public string TrainlocationV0 { get; set; }

        [JsonProperty("trainLocationUnitKM")]
        public TrainLocationUnitKM[] TrainLocationUnitKM { get; set; }

        [JsonProperty("trainlocationV0Threshold")]
        public long TrainlocationV0Threshold { get; set; }
    }

    public partial class TrainLocationUnitKM
    {
        [JsonProperty("locationUnitKMNumber")]
        public string LocationUnitKMNumber { get; set; }

        [JsonProperty("locationUnitKMValue")]
        public string LocationUnitKMValue { get; set; }
    }

    public partial class TrainState
    {
        [JsonProperty("trainStateDiagTrigger")]
        public TrainStateDiagTrigger[] TrainStateDiagTrigger { get; set; }

        [JsonProperty("trainStateCompositionRun")]
        public string TrainStateCompositionRun { get; set; }

        [JsonProperty("trainStateAutomaticOp")]
        public string TrainStateAutomaticOp { get; set; }

        [JsonProperty("timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty("trainStateCleaning")]
        public string TrainStateCleaning { get; set; }

        [JsonProperty("trainStateCouplingPassive")]
        public string TrainStateCouplingPassive { get; set; }

        [JsonProperty("trainStateCouplingActive")]
        public string TrainStateCouplingActive { get; set; }

        [JsonProperty("trainStateDiagTrigEntries")]
        public long TrainStateDiagTrigEntries { get; set; }

        [JsonProperty("trainStateInauguration")]
        public string TrainStateInauguration { get; set; }

        [JsonProperty("trainStateTCS")]
        public string TrainStateTCS { get; set; }

        [JsonProperty("trainStateGenTrainMode")]
        public string TrainStateGenTrainMode { get; set; }

        [JsonProperty("trainStateDirection")]
        public string TrainStateDirection { get; set; }

        [JsonProperty("trainStateGenTrainSubMode")]
        public string TrainStateGenTrainSubMode { get; set; }

        [JsonProperty("trainStatePCConsumption")]
        public long TrainStatePCConsumption { get; set; }

        [JsonProperty("trainStateNoiseReduction")]
        public string TrainStateNoiseReduction { get; set; }

        [JsonProperty("trainStatePowerSystem")]
        public string TrainStatePowerSystem { get; set; }

        [JsonProperty("trainStateTrainSubMode")]
        public string TrainStateTrainSubMode { get; set; }

        [JsonProperty("trainStateUnitPCconsum")]
        public TrainStateUnitPCconsum[] TrainStateUnitPCconsum { get; set; }

        [JsonProperty("trainStateTrainMode")]
        public string TrainStateTrainMode { get; set; }

        [JsonProperty("trainStateTunnelOp")]
        public string TrainStateTunnelOp { get; set; }

        [JsonProperty("trainStateUpdate")]
        public string TrainStateUpdate { get; set; }

        [JsonProperty("trainStateWashing")]
        public string TrainStateWashing { get; set; }
    }

    public partial class TrainStateDiagTrigger
    {
        [JsonProperty("trainStateDiagTriggerEvent")]
        public string TrainStateDiagTriggerEvent { get; set; }

        [JsonProperty("trainStateDiagTriggerTime")]
        public string TrainStateDiagTriggerTime { get; set; }
    }

    public partial class TrainStateUnitPCconsum
    {
        [JsonProperty("trainStateUnitPCAvail")]
        public string TrainStateUnitPCAvail { get; set; }

        [JsonProperty("trainStateUnitNum")]
        public string TrainStateUnitNum { get; set; }

        [JsonProperty("trainStateUnitPCUsed")]
        public string TrainStateUnitPCUsed { get; set; }
    }


    public partial class LegData
    {
        public static LegData FromJson(string json)
        {
            return JsonConvert.DeserializeObject<LegData>(json, Converter.Settings);
        }
    }
}
