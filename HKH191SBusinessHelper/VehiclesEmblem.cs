using GTA;
using GTA.Native;
using System.Collections.Generic;

namespace HKH191SBusinessHelper
{
  public class VehiclesEmblem : Script
  {
    public List<VehiclesEmblem> Vehc = new List<VehiclesEmblem>();

    public void AddVehicles()
    {
      this.Vehc.Add(new VehiclesEmblem("Default", 0L, -1f, 0.0f, 0.295f, 1f, 0.0f, 0.0f, 0.0f, 0.0f, -1f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("TURISMOR", 408192225L, -1f, 0.3f, 0.27f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.35f));
      this.Vehc.Add(new VehiclesEmblem("ADDER", -1216765807L, 0.0f, 1.54f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("AKUMA", 1672195559L, 0.0f, 0.06f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.18f));
      this.Vehc.Add(new VehiclesEmblem("ASEA", -1809822327L, 0.0f, 1.5f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("ASTEROPE", -1903012613L, 0.0f, 1.7f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("BAGGER", -2140431165L, -1f, 0.16f, 0.283f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.09f));
      this.Vehc.Add(new VehiclesEmblem("BALLER", -808831384L, 0.0f, 1.4f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("BALLER2", 142944341L, 0.0f, 1.55f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("BANSHEE", -1041692462L, 0.0f, 0.94f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.4f));
      this.Vehc.Add(new VehiclesEmblem("BATI", -114291515L, 0.0f, 0.2f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.15f));
      this.Vehc.Add(new VehiclesEmblem("BATI2", -891462355L, 0.0f, 0.2f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.15f));
      this.Vehc.Add(new VehiclesEmblem("BFINJECTION", 1126868326L, -1f, 0.08f, 0.19f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("BISON", -16948145L, 0.0f, 1.99f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("BJXL", 850565707L, 0.0f, 1.2f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.4f));
      this.Vehc.Add(new VehiclesEmblem("BLISTA", -344943009L, 0.0f, 1.49f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.29f));
      this.Vehc.Add(new VehiclesEmblem("BOBCATXL", 1069929536L, 0.0f, 1.68f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.65f));
      this.Vehc.Add(new VehiclesEmblem("BODHI2", -1435919434L, 0.0f, 1.95f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("BUCCANEER", -682211828L, 0.0f, 2.01f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.37f));
      this.Vehc.Add(new VehiclesEmblem("BUFFALO", -304802106L, 0.0f, 1.6f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("BUFFALO2", 736902334L, 0.0f, 2.24f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.2f));
      this.Vehc.Add(new VehiclesEmblem("BULLET", -1696146015L, -1.57f, 0.07f, 0.16f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.3f));
      this.Vehc.Add(new VehiclesEmblem("CARBONRS", 11251904L, 0.0f, 0.09f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.18f));
      this.Vehc.Add(new VehiclesEmblem("CARBONIZZARE", 2072687711L, 0.0f, 1.45f, 1f, 0.0f, -0.11f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("CAVALCADE", 2006918058L, 0.0f, 1.51f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.55f));
      this.Vehc.Add(new VehiclesEmblem("CAVALCADE2", -789894171L, 0.0f, 1.59f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("CHEETAH", -1311154784L, -1.61f, 0.26f, 0.17f, 0.9f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.35f));
      this.Vehc.Add(new VehiclesEmblem("COGCABRIO", 330661258L, 0.0f, 1.42f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("COMET2", -1045541610L, 0.0f, 1.35f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("COQUETTE", 108773431L, 0.0f, 0.96f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.22f));
      this.Vehc.Add(new VehiclesEmblem("DAEMON", 2006142190L, 0.0f, 0.06f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.15f));
      this.Vehc.Add(new VehiclesEmblem("DILETTANTE", -1130810103L, 0.0f, 1.59f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("DLOADER", 1770332643L, 0.0f, 1.52f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("DOMINATOR", 80636076L, 0.0f, 1.4f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("DOUBLE", -1670998136L, 0.0f, 0.08f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.2f));
      this.Vehc.Add(new VehiclesEmblem("DUBSTA", 1177543287L, -1.71f, 0.31f, 0.27f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("DUBSTA2", -394074634L, 0.0f, 1.4f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.75f));
      this.Vehc.Add(new VehiclesEmblem("ELEGY2", -566387422L, 0.0f, 1.14f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.35f));
      this.Vehc.Add(new VehiclesEmblem("EMPEROR", -685276541L, 0.0f, 1.31f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("EMPEROR2", -1883002148L, 0.0f, 1.31f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("ENTITYXF", -1291952903L, -1.52f, 0.41f, 0.15f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.3f));
      this.Vehc.Add(new VehiclesEmblem("EXEMPLAR", -5153954L, 0.0f, 1.32f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("F620", -591610296L, 0.0f, 1.28f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.45f));
      this.Vehc.Add(new VehiclesEmblem("FAGGIO2", 55628203L, -1f, -0.48f, -0.11f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.15f));
      this.Vehc.Add(new VehiclesEmblem("FELON", -391594584L, 0.0f, 1.24f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.35f));
      this.Vehc.Add(new VehiclesEmblem("FELON2", -89291282L, 0.0f, 1.24f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.35f));
      this.Vehc.Add(new VehiclesEmblem("FELTZER2", -1995326987L, 0.0f, 1.4f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("FQ2", -1137532101L, 0.0f, 1.4f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("FUGITIVE", 1909141499L, 0.0f, 1.62f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("FUSILADE", 499169875L, 0.0f, 0.98f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.2f));
      this.Vehc.Add(new VehiclesEmblem("FUTO", 2016857647L, 0.0f, 1.28f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.45f));
      this.Vehc.Add(new VehiclesEmblem("GAUNTLET", -1800170043L, 0.0f, 1.735f, 1.05f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.33f));
      this.Vehc.Add(new VehiclesEmblem("GRANGER", -1775728740L, 0.0f, 2.07f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("GRESLEY", -1543762099L, 0.0f, 1.75f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("HABANERO", 884422927L, 0.0f, 1.69f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("HEXER", 301427732L, 0.0f, -0.46f, 1f, 0.0f, 1f, -1f, -1f, 0.0f, 0.0f, 0.14f));
      this.Vehc.Add(new VehiclesEmblem("HOTKNIFE", 37348240L, -1.43f, -0.14f, 0.18f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("INFERNUS", 418536135L, -1f, 0.33f, 0.08f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.06f, 0.25f));
      this.Vehc.Add(new VehiclesEmblem("INGOT", -1289722222L, 0.0f, 1.58f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("INTRUDER", 886934177L, 0.0f, 1.623f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("ISSI2", -1177863319L, 0.0f, 1.21f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.3f));
      this.Vehc.Add(new VehiclesEmblem("JACKAL", -624529134L, 0.0f, 1.36f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.4f));
      this.Vehc.Add(new VehiclesEmblem("JB700", 1051415893L, 0.0f, 1.2f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.37f));
      this.Vehc.Add(new VehiclesEmblem("KHAMELION", 544021352L, 0.0f, 1.46f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.475f));
      this.Vehc.Add(new VehiclesEmblem("LANDSTALKER", 1269098716L, 0.0f, 1.83f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("MANANA", -2124201592L, 0.0f, 0.86f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.37f));
      this.Vehc.Add(new VehiclesEmblem("MESA", 914654722L, 0.0f, 1.47f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("MESA3", -2064372143L, 0.0f, 1.47f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("MINIVAN", -310465116L, 0.0f, 1.95f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("MONROE", -433375717L, 0.0f, 1.23f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.43f));
      this.Vehc.Add(new VehiclesEmblem("NEMESIS", -634879114L, 0.0f, 0.14f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.1f));
      this.Vehc.Add(new VehiclesEmblem("NINEF", 1032823388L, 0.0f, 1.7f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("NINEF2", -1461482751L, 0.0f, 1.7f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("ORACLE", 1348744438L, 0.0f, 1.6f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("ORACLE2", -511601230L, 0.0f, 1.7f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("PATRIOT", -808457413L, 0.0f, 1.75f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("PCJ", -909201658L, 0.0f, 0.02f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.15f));
      this.Vehc.Add(new VehiclesEmblem("PENUMBRA", -377465520L, 0.0f, 1.46f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("PEYOTE", 1830407356L, -1f, -0.36f, 0.2125f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("PHOENIX", -2095439403L, 0.0f, 1.833f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.44f));
      this.Vehc.Add(new VehiclesEmblem("PICADOR", 1507916787L, 0.0f, 1.43f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.515f));
      this.Vehc.Add(new VehiclesEmblem("PRAIRIE", -1450650718L, 0.0f, 1.41f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.31f));
      this.Vehc.Add(new VehiclesEmblem("PREMIER", -1883869285L, 0.0f, 1.6f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("PRIMO", -1150599089L, 0.0f, 1.62f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("RADI", -1651067813L, 0.0f, 1.74f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("RANCHERXL", 1645267888L, 0.0f, 1.54f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("RAPIDGT", -1934452204L, 0.0f, 1.263f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("RAPIDGT2", 1737773231L, 0.0f, 1.263f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("RATLOADER", -667151410L, -1.78f, 0.52f, 0.52f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.45f));
      this.Vehc.Add(new VehiclesEmblem("REBEL", -1207771834L, -1.22f, 0.6f, 0.44f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("REBEL2", -2045594037L, 0.0f, 1.623f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("REGINA", -14495224L, 0.0f, 1.473f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("ROCOTO", 2136773105L, 0.0f, 1.623f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("ROMERO", 627094268L, 0.0f, 1.83f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("RUFFIAN", -893578776L, 0.0f, -0.02f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.19f));
      this.Vehc.Add(new VehiclesEmblem("RUINER", -227741703L, 0.0f, 1.34f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("SABREGT", -1685021548L, -1f, 0.0f, 0.14f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.015f, 0.35f));
      this.Vehc.Add(new VehiclesEmblem("SADLER", -599568815L, 0.0f, 2.26f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("SANDKING", -1189015600L, 0.0f, 2.496f, 1.55f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("SANDKING2", 989381445L, 0.0f, 2.286f, 1.55f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("SCHAFTER2", -1255452397L, 0.0f, 1.56f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.28f));
      this.Vehc.Add(new VehiclesEmblem("SCHWARZER", -746882698L, 0.0f, 1.43f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.28f));
      this.Vehc.Add(new VehiclesEmblem("SEMINOLE", 1221512915L, 0.0f, 1.45f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("SENTINEL", 1349725314L, 0.0f, 1.52f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("SENTINEL2", 873639469L, 0.0f, 1.52f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("SERRANO", 1337041428L, 0.0f, 1.68f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.49f));
      this.Vehc.Add(new VehiclesEmblem("STANIER", -1477580979L, 0.0f, 1.55f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("STINGER", 1545842587L, 0.0f, 1.3f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("STINGERGT", -2098947590L, -1f, -0.17f, 0.12f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.35f));
      this.Vehc.Add(new VehiclesEmblem("STRATUM", 1723137093L, 0.0f, 1.52f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("SULTAN", 970598228L, 0.0f, 1.77f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.33f));
      this.Vehc.Add(new VehiclesEmblem("SUPERD", 1123216662L, 0.0f, 1.62f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("SURANO", 384071873L, 0.0f, 1.38f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("SURFER", 699456151L, 0.0f, 2.48f, 0.26f, 0.0f, -1f, -0.212f, -1f, 0.0f, 0.0f, 0.32f));
      this.Vehc.Add(new VehiclesEmblem("SURFER2", -1311240698L, 0.0f, 2.48f, 0.26f, 0.0f, -1f, -0.212f, -1f, 0.0f, 0.0f, 0.32f));
      this.Vehc.Add(new VehiclesEmblem("SURGE", -1894894188L, 0.0f, 1.69f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("TAILGATER", -1008861746L, 0.0f, 1.783f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.4f));
      this.Vehc.Add(new VehiclesEmblem("TORNADO", 464687292L, -1.23f, 0.11f, -0.21f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.4f));
      this.Vehc.Add(new VehiclesEmblem("TORNADO2", 1531094468L, 0.0f, 1.44f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("TORNADO3", 1762279763L, 0.0f, 1.44f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("VACCA", 338562499L, 0.0f, 1.76f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.35f));
      this.Vehc.Add(new VehiclesEmblem("VADER", -140902153L, 0.0f, 0.08f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.15f));
      this.Vehc.Add(new VehiclesEmblem("VIGERO", -825837129L, -1f, 0.11f, -0.15f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.45f));
      this.Vehc.Add(new VehiclesEmblem("VOLTIC", -1622444098L, 0.0f, 1.763f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.29f));
      this.Vehc.Add(new VehiclesEmblem("VOODOO2", 523724515L, 0.0f, 1.48f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("WASHINGTON", 1777363799L, 0.0f, 1.61f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("YOUGA", 65402552L, 0.0f, 2.352f, 1.003f, 0.0f, -1f, -1f, -1f, 0.0f, 0.0f, 0.175f));
      this.Vehc.Add(new VehiclesEmblem("ZION", -1122289213L, 0.0f, 1.48f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.45f));
      this.Vehc.Add(new VehiclesEmblem("ZION2", -1193103848L, 0.0f, 1.48f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.45f));
      this.Vehc.Add(new VehiclesEmblem("ZTYPE", 758895617L, -0.96f, -0.69f, 0.35f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.4f));
      this.Vehc.Add(new VehiclesEmblem("KALAHARI", 92612664L, -1f, 0.18f, 0.1f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("PARADISE", 1488164764L, 0.0f, 2.23f, 1f, 0.0f, -0.22f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("ALPHA", 767087018L, -1f, 0.18f, -0.05f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("HUNTLEY", 486987393L, 0.0f, 1.52f, 0.99f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.4f));
      this.Vehc.Add(new VehiclesEmblem("ZENTORNO", -1403128555L, -1.24f, 0.42f, -0.14f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.035f, 0.3f));
      this.Vehc.Add(new VehiclesEmblem("JESTER", -1297672541L, -1f, 0.17f, 0.22f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.05f, 0.33f));
      this.Vehc.Add(new VehiclesEmblem("MASSACRO", -142942670L, 0.0f, 1.37f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.33f));
      this.Vehc.Add(new VehiclesEmblem("THRUST", 1836027715L, -1f, 0.405f, 0.4625f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.1625f));
      this.Vehc.Add(new VehiclesEmblem("BTYPE", 117401876L, 0.0f, 1.143f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.7125f));
      this.Vehc.Add(new VehiclesEmblem("RHAPSODY", 841808271L, -1f, -0.47f, -0.25f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.2625f));
      this.Vehc.Add(new VehiclesEmblem("GLENDALE", 75131841L, 0.0f, 1.683f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.775f));
      this.Vehc.Add(new VehiclesEmblem("WARRENER", 1373123368L, 0.0f, 1.623f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.775f));
      this.Vehc.Add(new VehiclesEmblem("BLADE", -1205801634L, -1f, 0.445f, 0.2075f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.325f));
      this.Vehc.Add(new VehiclesEmblem("PANTO", -431692672L, -1f, 0.0f, 0.335f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("DUBSTA3", -1237253773L, -1f, 0.34f, 0.2975f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("PIGALLE", 1078682497L, 0.0f, 1.623f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("COQUETTE2", 1011753235L, -1f, -0.1775f, 0.195f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.35f));
      this.Vehc.Add(new VehiclesEmblem("INNOVATION", -159126838L, 0.0f, 0.15f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.18f));
      this.Vehc.Add(new VehiclesEmblem("HAKUCHOU", 1265391242L, 0.0f, 0.27f, 0.845f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.16f));
      this.Vehc.Add(new VehiclesEmblem("FUROREGT", -1089039904L, -1f, 0.0f, 0.2075f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.45f));
      this.Vehc.Add(new VehiclesEmblem("RATLOADER2", -589178377L, -1.78f, 0.52f, 0.52f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.45f));
      this.Vehc.Add(new VehiclesEmblem("SLAMVAN", 729783779L, -1f, 0.275f, 0.195f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("DUKES2", -326143852L, -1f, 0.0f, 0.0f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.375f));
      this.Vehc.Add(new VehiclesEmblem("DUKES", 723973206L, -1f, 0.0f, 0.0375f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.3875f));
      this.Vehc.Add(new VehiclesEmblem("STALION", 1923400478L, -1f, 0.0f, 0.0925f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 7f / 16f));
      this.Vehc.Add(new VehiclesEmblem("BLISTA2", 1039032026L, -1f, 0.5325f, 0.245f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.2875f));
      this.Vehc.Add(new VehiclesEmblem("CASCO", 941800958L, 0.0f, 0.94f, 1.03f, 0.0f, -0.03f, -1f, -1f, 0.0f, 0.0f, 0.3f));
      this.Vehc.Add(new VehiclesEmblem("ENDURO", 1753414259L, 0.0f, -0.17f, 1f, 0.0f, 0.34f, -0.786f, -1f, 0.0f, 0.0f, 0.15f));
      this.Vehc.Add(new VehiclesEmblem("GBURRITO2", 296357396L, 0.0f, 2.32f, 0.94f, 0.0f, -0.182f, -1f, -1f, 0.0f, 0.0f, 0.4f));
      this.Vehc.Add(new VehiclesEmblem("GUARDIAN", -2107990196L, -1.94f, 1.07f, 0.38f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.35f));
      this.Vehc.Add(new VehiclesEmblem("KURUMA", -1372848492L, -1f, 0.2475f, -0.175f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.435f));
      this.Vehc.Add(new VehiclesEmblem("KURUMA2", 410882957L, -1f, 0.2475f, -0.175f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.435f));
      this.Vehc.Add(new VehiclesEmblem("LECTRO", 640818791L, 0.0f, 0.3f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.09f));
      this.Vehc.Add(new VehiclesEmblem("FELTZER3", -1566741232L, 0.0f, 1.4f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("OSIRIS", 1987142870L, -1f, 0.27f, -0.03f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.3f));
      this.Vehc.Add(new VehiclesEmblem("VIRGO", -498054846L, -1.05f, 0.0f, 0.075f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.45f));
      this.Vehc.Add(new VehiclesEmblem("WINDSOR", 1581459400L, -1.2f, -0.39f, 0.12f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.55f));
      this.Vehc.Add(new VehiclesEmblem("BRAWLER", -1479664699L, -1f, -0.21f, 0.0f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.45f));
      this.Vehc.Add(new VehiclesEmblem("CHINO", 349605904L, -1.05f, 0.0f, 0.075f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.45f));
      this.Vehc.Add(new VehiclesEmblem("COQUETTE3", 784565758L, -1f, -0.1775f, 0.195f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.35f));
      this.Vehc.Add(new VehiclesEmblem("T20", 1663218586L, -1f, 0.4f, -0.12f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.2f));
      this.Vehc.Add(new VehiclesEmblem("VINDICATOR", 2941886209L, -1f, 0.21f, 0.24f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.3f));
      this.Vehc.Add(new VehiclesEmblem("FACTION", -2119578145L, -1f, 0.0f, 0.15f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("FACTION2", -1790546981L, -1f, 0.0f, 0.15f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("BUCCANEER2", -1013450936L, 0.0f, 2.01f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.37f));
      this.Vehc.Add(new VehiclesEmblem("CHINO2", -1361687965L, -1.05f, 0.0f, 0.075f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.45f));
      this.Vehc.Add(new VehiclesEmblem("MOONBEAM", 525509695L, 0.0f, 1.713f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("MOONBEAM2", 1896491931L, 0.0f, 1.713f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("PRIMO2", -2040426790L, -1f, 0.42f, 0.0f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("VOODOO", 2006667053L, -1.12f, 0.0f, 0.0f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("FACTION3", -2039755226L, -1f, 0.0f, 0.5f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("SABREGT2", 223258115L, -1f, 0.0f, 0.14f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.015f, 0.35f));
      this.Vehc.Add(new VehiclesEmblem("TORNADO5", -1797613329L, -1f, 0.15f, -0.09f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.45f));
      this.Vehc.Add(new VehiclesEmblem("VIRGO2", -899509638L, -1f, 0.0f, 0.1225f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.375f));
      this.Vehc.Add(new VehiclesEmblem("VIRGO3", 16646064L, -1f, 0.0f, 0.1225f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.375f));
      this.Vehc.Add(new VehiclesEmblem("MINIVAN2", -1126264336L, 0.0f, 1.95f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("SLAMVAN3", 1119641113L, -1f, 0.275f, 0.195f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("BTYPE2", -831834716L, -1f, -0.1f, 0.4f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("LURCHER", 2068293287L, -1f, 0.0f, 0.3f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.45f));
      this.Vehc.Add(new VehiclesEmblem("BALLER3", 1878062887L, 0.0f, 1.4f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("BALLER4", 634118882L, 0.0f, 1.4f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("BALLER5", 470404958L, 0.0f, 1.4f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("BALLER6", 666166960L, 0.0f, 1.4f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("COG55", 906642318L, -1f, 0.37f, 0.13f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.45f));
      this.Vehc.Add(new VehiclesEmblem("COG552", 704435172L, -1f, 0.37f, 0.13f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.45f));
      this.Vehc.Add(new VehiclesEmblem("COGNOSCENTI", -2030171296L, -1f, 0.37f, 0.13f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.45f));
      this.Vehc.Add(new VehiclesEmblem("COGNOSCENTI2", -604842630L, -1f, 0.37f, 0.13f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.45f));
      this.Vehc.Add(new VehiclesEmblem("MAMBA", -1660945322L, -1f, -0.18f, 0.21f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.35f));
      this.Vehc.Add(new VehiclesEmblem("NIGHTSHADE", -1943285540L, -1f, -0.2f, 0.17f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.45f));
      this.Vehc.Add(new VehiclesEmblem("SCHAFTER3", -1485523546L, 0.0f, 1.56f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.28f));
      this.Vehc.Add(new VehiclesEmblem("SCHAFTER4", 1489967196L, 0.0f, 1.56f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.28f));
      this.Vehc.Add(new VehiclesEmblem("SCHAFTER5", -888242983L, 0.0f, 1.56f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.28f));
      this.Vehc.Add(new VehiclesEmblem("SCHAFTER6", 1922255844L, 0.0f, 1.56f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.28f));
      this.Vehc.Add(new VehiclesEmblem("VERLIERER2", 1102544804L, -1f, -0.21f, 0.03f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.4f));
      this.Vehc.Add(new VehiclesEmblem("TAMPA", 972671128L, -1f, 0.0f, 0.12f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.45f));
      this.Vehc.Add(new VehiclesEmblem("BANSHEE2", 633712403L, -1f, -0.4f, 0.075f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.4f));
      this.Vehc.Add(new VehiclesEmblem("SULTANRS", -295689028L, 0.0f, 1.77f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.33f));
      this.Vehc.Add(new VehiclesEmblem("BTYPE3", -602287871L, -1f, -0.1f, 0.4f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("BESTIAGTS", 1274868363L, -1f, -0.06f, 0.4f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.4f));
      this.Vehc.Add(new VehiclesEmblem("SEVEN70", 2537130571L, -1f, -0.21f, 0.25f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.35f));
      this.Vehc.Add(new VehiclesEmblem("FMJ", 1426219628L, -1f, -0.06f, 0.21f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.3f));
      this.Vehc.Add(new VehiclesEmblem("PFISTER811", -1829802492L, -1f, 0.06f, 0.25f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.45f));
      this.Vehc.Add(new VehiclesEmblem("PROTOTIPO", 2123327359L, -1f, 0.3f, 0.27f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.35f));
      this.Vehc.Add(new VehiclesEmblem("REAPER", 234062309L, -1f, 0.48f, 0.0f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.3f));
      this.Vehc.Add(new VehiclesEmblem("RUMPO3", 1475773103L, 0.0f, 2.103f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("WINDSOR2", 2364918497L, -1.2f, 0.03f, 0.24f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.55f));
      this.Vehc.Add(new VehiclesEmblem("XLS", 1203490606L, -1f, 0.36f, -0.15f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.45f));
      this.Vehc.Add(new VehiclesEmblem("XLS2", 3862958888L, -1f, 0.36f, -0.15f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.45f));
      this.Vehc.Add(new VehiclesEmblem("BRIOSO", 1549126457L, -1f, -0.06f, 0.565f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.3f));
      this.Vehc.Add(new VehiclesEmblem("CONTENDER", 683047626L, 0.0f, 2.33f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("LE7B", 3062131285L, -1f, -0.12f, 0.235f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.3f));
      this.Vehc.Add(new VehiclesEmblem("OMNIS", 3517794615L, -1f, 0.03f, 0.18f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.45f));
      this.Vehc.Add(new VehiclesEmblem("TROPOS", 1887331236L, -1f, 0.0f, 0.24f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.35f));
      this.Vehc.Add(new VehiclesEmblem("AVARUS", 2179174271L, -1f, 0.27f, 0.25f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.1f));
      this.Vehc.Add(new VehiclesEmblem("DAEMON2", 2890830793L, -1f, 0.27f, 0.29f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.1f));
      this.Vehc.Add(new VehiclesEmblem("DEFILER", 822018448L, -1f, 0.0f, 0.34f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.125f));
      this.Vehc.Add(new VehiclesEmblem("ESSKEY", 2035069708L, -1f, 0.335f, 0.31f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.09f));
      this.Vehc.Add(new VehiclesEmblem("HAKUCHOU2", 4039289119L, 0.0f, 0.27f, 0.845f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.15f));
      this.Vehc.Add(new VehiclesEmblem("NIGHTBLADE", 2688780135L, 0.0f, -0.133f, 0.61f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.125f));
      this.Vehc.Add(new VehiclesEmblem("RATBIKE", 1873600305L, -1f, 0.31f, 0.24f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.1f));
      this.Vehc.Add(new VehiclesEmblem("SHOTARO", 3889340782L, -1f, 0.06f, 0.325f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.1f));
      this.Vehc.Add(new VehiclesEmblem("ZOMBIEA", 3285698347L, -1f, 0.3f, 0.25f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.1f));
      this.Vehc.Add(new VehiclesEmblem("ZOMBIEB", 3724934023L, -1f, 0.2f, 0.25f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.1f));
      this.Vehc.Add(new VehiclesEmblem("VORTEX", 3685342204L, -1f, 0.18f, 0.37f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.095f));
      this.Vehc.Add(new VehiclesEmblem("TORNADO6", 2736567667L, -1f, -0.03f, -0.24f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.3f));
      this.Vehc.Add(new VehiclesEmblem("YOUGA2", 1026149675L, 0.0f, 2.352f, 0.253f, 0.0f, -1f, -0.256f, -1f, 0.0f, 0.0f, 0.175f));
      this.Vehc.Add(new VehiclesEmblem("WOLFSBANE", 3676349299L, -1f, 0.33f, 0.24f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.1f));
      this.Vehc.Add(new VehiclesEmblem("FAGGIO3", 3005788552L, -1f, -0.54f, -0.11f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.15f));
      this.Vehc.Add(new VehiclesEmblem("FAGGIO", 2452219115L, -0.9875f, -7f / 400f, -0.01f, 0.8975f, -0.26f, -0.0725f, 0.0f, -1f, 0.0f, 0.1625f));
      this.Vehc.Add(new VehiclesEmblem("COMET3", 2272483501L, -1f, 0.0f, 0.295f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.4f));
      this.Vehc.Add(new VehiclesEmblem("DIABLOUS", 4055125828L, -1f, 3f / 500f, 0.382f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.1f));
      this.Vehc.Add(new VehiclesEmblem("DIABLOUS2", 1790834270L, -1f, 0.225f, 0.541f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.1f));
      this.Vehc.Add(new VehiclesEmblem("ELEGY", 196747873L, 0.0f, 1.14f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.35f));
      this.Vehc.Add(new VehiclesEmblem("FCR", 627535535L, -1f, 0.234f, 0.376f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.1f));
      this.Vehc.Add(new VehiclesEmblem("FCR2", 3537231886L, -1f, 0.234f, 0.376f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.1f));
      this.Vehc.Add(new VehiclesEmblem("ITALIGTB", 2246633323L, -1f, -0.024f, 0.187f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.25f));
      this.Vehc.Add(new VehiclesEmblem("ITALIGTB2", 3812247419L, -1f, -0.024f, 0.187f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.25f));
      this.Vehc.Add(new VehiclesEmblem("NERO", 1034187331L, -1f, 0.237f, 0.09f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.25f));
      this.Vehc.Add(new VehiclesEmblem("NERO2", 1093792632L, -1f, 0.237f, 0.09f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.25f));
      this.Vehc.Add(new VehiclesEmblem("PENETRATOR", 2536829930L, -1f, 0.153f, 0.295f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.35f));
      this.Vehc.Add(new VehiclesEmblem("RUINER2", 941494461L, 0.363f, 1.34f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.4f));
      this.Vehc.Add(new VehiclesEmblem("RUINER3", 777714999L, 0.363f, 1.34f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.4f));
      this.Vehc.Add(new VehiclesEmblem("SPECTER", 1886268224L, -1f, -0.273f, -0.02f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.2f));
      this.Vehc.Add(new VehiclesEmblem("SPECTER2", 1074745671L, -1f, -0.273f, 0.286f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.2f));
      this.Vehc.Add(new VehiclesEmblem("TECHNICAL2", 1180875963L, 0.0f, 1.623f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("TEMPESTA", 272929391L, -1f, 0.0f, 0.253f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.25f));
      this.Vehc.Add(new VehiclesEmblem("VOLTIC2", 989294410L, 0.0f, 1.763f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.29f));
      this.Vehc.Add(new VehiclesEmblem("INFERNUS2", 2889029532L, -1f, 0.33f, 0.06f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.06f, 0.2f));
      this.Vehc.Add(new VehiclesEmblem("RUSTON", 719660200L, -1f, -0.273f, 0.084f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.15f));
      this.Vehc.Add(new VehiclesEmblem("TURISMO2", 3312836369L, -1f, 0.159f, -0.193f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.25f));
      this.Vehc.Add(new VehiclesEmblem("ARDENT", 159274291L, -1f, 0.309f, 0.276f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.2f));
      this.Vehc.Add(new VehiclesEmblem("CHEETAH2", 223240013L, -1f, 0.159f, -0.127f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.25f));
      this.Vehc.Add(new VehiclesEmblem("HALFTRACK", 4262731174L, -1f, 0.501f, 0.531f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.35f));
      this.Vehc.Add(new VehiclesEmblem("NIGHTSHARK", 433954513L, -1.5f, 0.42f, 0.584f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.3f));
      this.Vehc.Add(new VehiclesEmblem("OPPRESSOR", 884483972L, -1f, 0.306f, 0.355f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.08f));
      this.Vehc.Add(new VehiclesEmblem("TAMPA3", 3084515313L, 0.0f, 1.515f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.275f));
      this.Vehc.Add(new VehiclesEmblem("TECHNICAL3", 1356124575L, 0.0f, 1.623f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.43f));
      this.Vehc.Add(new VehiclesEmblem("TORERO", 1504306544L, -1f, 0.201f, 57f / 500f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.3f));
      this.Vehc.Add(new VehiclesEmblem("VAGNER", 1939284556L, -1.5f, 0.906f, 0.071f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.1f));
      this.Vehc.Add(new VehiclesEmblem("XA21", 917809321L, -1f, 0.441f, 0.13f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.25f));
      this.Vehc.Add(new VehiclesEmblem("PHANTOM3", 177270108L, -1.3f, 2.045f, 0.802f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.45f));
      this.Vehc.Add(new VehiclesEmblem("HAULER2", 387748548L, -1.627f, 2.456f, 0.745f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.45f));
      this.Vehc.Add(new VehiclesEmblem("CYCLONE", 1392481335L, -1f, 0.186f, 0.382f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.2f));
      this.Vehc.Add(new VehiclesEmblem("VISIONE", 3296789504L, -1f, 0.432f, 0.031f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.15f));
      this.Vehc.Add(new VehiclesEmblem("VIGILANTE", 3052358707L, -1f, 0.232f, 0.24f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.175f));
      this.Vehc.Add(new VehiclesEmblem("RAPIDGT3", 2049897956L, 0.0f, 1.972f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.18f));
      this.Vehc.Add(new VehiclesEmblem("RETINUE", 1841130506L, -1f, -0.018f, 0.253f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.3f));
      this.Vehc.Add(new VehiclesEmblem("AVENGER", 2176659152L, -2.02f, 6.45f, -0.716f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.35f));
      this.Vehc.Add(new VehiclesEmblem("AVENGER2", 408970549L, -2.02f, 6.45f, -0.716f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.35f));
      this.Vehc.Add(new VehiclesEmblem("DELUXO", 1483171323L, -1f, -0.291f, 0.247f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.2f));
      this.Vehc.Add(new VehiclesEmblem("STROMBERG", 886810209L, -1f, 0.23f, 0.247f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.2f));
      this.Vehc.Add(new VehiclesEmblem("RIOT2", -1693015116L, -1.891f, 2.144f, 0.657f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.35f));
      this.Vehc.Add(new VehiclesEmblem("CHERNOBOG", -692292317L, -2.127f, 5.413f, 1.132f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.34f));
      this.Vehc.Add(new VehiclesEmblem("KHANJALI", -1435527158L, -0.897f, 1.391f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.4f));
      this.Vehc.Add(new VehiclesEmblem("BARRAGE", -212993243L, -1.51f, 0.71f, 0.451f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.25f));
      this.Vehc.Add(new VehiclesEmblem("COMET4", 1561920505L, -1f, 0.298f, 0.257f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.36f));
      this.Vehc.Add(new VehiclesEmblem("NEON", -1848994066L, -1f, 0.181f, -0.066f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.3f));
      this.Vehc.Add(new VehiclesEmblem("STREITER", 1741861769L, -1f, 0.301f, 0.295f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.4f));
      this.Vehc.Add(new VehiclesEmblem("SENTINEL3", 1104234922L, 0.0f, 1.52f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("YOSEMITE", 1871995513L, -1f, 0.252f, 0.201f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.3f));
      this.Vehc.Add(new VehiclesEmblem("SC1", 1352136073L, -1f, 0.616f, -0.131f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.25f));
      this.Vehc.Add(new VehiclesEmblem("AUTARCH", -313185164L, -1f, 0.0f, 0.116f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.25f));
      this.Vehc.Add(new VehiclesEmblem("GT500", -2079788230L, -1f, 0.0f, 0.0f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.25f));
      this.Vehc.Add(new VehiclesEmblem("HUSTLER", 600450546L, -1f, -0.228f, 0.321f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.4f));
      this.Vehc.Add(new VehiclesEmblem("REVOLTER", -410205223L, -1f, 0.203f, 0.126f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.45f));
      this.Vehc.Add(new VehiclesEmblem("PARIAH", 867799010L, -1f, -0.126f, 0.208f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.35f));
      this.Vehc.Add(new VehiclesEmblem("RAIDEN", -1529242755L, -1f, 0.252f, -0.095f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.35f));
      this.Vehc.Add(new VehiclesEmblem("SAVESTRA", 903794909L, -1f, 0.0f, 0.25f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.35f));
      this.Vehc.Add(new VehiclesEmblem("RIATA", -1532697517L, -1.3f, 0.18f, 0.511f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.3f));
      this.Vehc.Add(new VehiclesEmblem("HERMES", 15219735L, -1f, -0.134f, 0.158f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.4f));
      this.Vehc.Add(new VehiclesEmblem("COMET5", 661493923L, -1f, 1f / 500f, 0.031f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.35f));
      this.Vehc.Add(new VehiclesEmblem("Z190", 838982985L, -1f, -0.175f, 0.242f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.4f));
      this.Vehc.Add(new VehiclesEmblem("VISERIS", -391595372L, -1f, 0.0f, 0.244f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.275f));
      this.Vehc.Add(new VehiclesEmblem("KAMACHO", -121446169L, -1.315f, 0.507f, 0.518f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.25f));
      this.Vehc.Add(new VehiclesEmblem("TURISMO", 2398307655L, 0.0f, 1.54f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("GB200", 1909189272L, -1f, 0.0f, 0.407f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.225f));
      this.Vehc.Add(new VehiclesEmblem("FAGALOA", 1617472902L, -1f, 0.0f, 0.225f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.4f));
      this.Vehc.Add(new VehiclesEmblem("ELLIE", -1267543371L, -1f, 0.441f, -0.128f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.35f));
      this.Vehc.Add(new VehiclesEmblem("ISSI3", 931280609L, -1f, 0.195f, 0.246f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.4f));
      this.Vehc.Add(new VehiclesEmblem("MICHELLI", 1046206681L, -1f, 0.0f, 0.0805f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.35f));
      this.Vehc.Add(new VehiclesEmblem("FLASHGT", -1259134696L, 0.0f, 1.592f, 1f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.0f, 0.25f));
      this.Vehc.Add(new VehiclesEmblem("HOTRING", 1115909093L, -1f, 0.0f, 0.0f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("TEZERACT", 1031562256L, -1f, 0.679f, 0.514f, 1f, 0.0f, -0.75f, 0.0f, -1f, 0.0f, 0.175f));
      this.Vehc.Add(new VehiclesEmblem("TYRANT", -376434238L, -1.588f, 0.315f, 0.337f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.3f));
      this.Vehc.Add(new VehiclesEmblem("DOMINATOR3", -986944621L, -1f, 0.0f, 0.221f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("TAIPAN", -1134706562L, -1f, 0.0f, 0.219f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.4f));
      this.Vehc.Add(new VehiclesEmblem("ENTITY2", -2120700196L, -1.52f, 0.41f, 0.15f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.3f));
      this.Vehc.Add(new VehiclesEmblem("JESTER3", -214906006L, -1f, 0.0f, 0.297f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.4f));
      this.Vehc.Add(new VehiclesEmblem("CHEBUREK", -988501280L, -1f, 0.393f, 0.162f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.375f));
      this.Vehc.Add(new VehiclesEmblem("CARACARA", 1254014755L, -1f, 1.266f, 0.4115f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.4f));
      this.Vehc.Add(new VehiclesEmblem("SPEEDO4", 219613597L, -1.5f, 0.833f, 0.391f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.2f));
      this.Vehc.Add(new VehiclesEmblem("MULE4", 1945374990L, -1.125f, 2.691f, 0.318f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.35f));
      this.Vehc.Add(new VehiclesEmblem("POUNDER2", 1653666139L, -1.5f, 1.853f, 0.779f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.38f));
      this.Vehc.Add(new VehiclesEmblem("SWINGER", 500482303L, -1f, 0.195f, 0.105f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.35f));
      this.Vehc.Add(new VehiclesEmblem("MENACER", 2044532910L, -1.73f, 0.159f, 0.61f, 1f, 0.12f, 0.0f, 0.0f, -1f, 0.0f, 0.4f));
      this.Vehc.Add(new VehiclesEmblem("SCRAMJET", -638562243L, -1f, -0.188f, 0.0f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.25f));
      this.Vehc.Add(new VehiclesEmblem("PATRIOT2", -420911112L, -1.213f, 1.546f, 0.511f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.3f));
      this.Vehc.Add(new VehiclesEmblem("STAFFORD", 321186144L, -1f, 0.036f, 0.096f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.4f));
      this.Vehc.Add(new VehiclesEmblem("FREECRAWLER", -54332285L, -1f, 0.249f, 0.511f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.4f));
      this.Vehc.Add(new VehiclesEmblem("OPPRESSOR2", 2069146067L, -1f, 0.306f, 0.355f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.08f));
      this.Vehc.Add(new VehiclesEmblem("TERBYTE", -1988428699L, -1.73f, 3.397f, 0.724f, 1f, 0.12f, 0.0f, 0.0f, -1f, 0.0f, 0.25f));
      this.Vehc.Add(new VehiclesEmblem("BRUISER", 668439077L, 0.0f, 2.12f, 1.241f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.084f, 0.775f));
      this.Vehc.Add(new VehiclesEmblem("BRUISER2", -1694081890L, 0.0f, 2.12f, 1.241f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.084f, 0.775f));
      this.Vehc.Add(new VehiclesEmblem("BRUISER3", -2042350822L, 0.0f, 2.12f, 1.241f, 0.0f, 0.0f, -1f, -1f, 0.0f, 0.084f, 0.775f));
      this.Vehc.Add(new VehiclesEmblem("BRUTUS", 2139203625L, -1f, 0.446f, 0.247f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.4f));
      this.Vehc.Add(new VehiclesEmblem("BRUTUS2", -1890996696L, -1f, 0.446f, 0.247f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.4f));
      this.Vehc.Add(new VehiclesEmblem("BRUTUS3", 2038858402L, -1f, 0.446f, 0.247f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.4f));
      this.Vehc.Add(new VehiclesEmblem("CERBERUS", -801550069L, -1.432f, 1.443f, 1.292f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("CERBERUS2", 679453769L, -1.432f, 1.443f, 1.292f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("CERBERUS3", 1909700336L, -1.432f, 1.443f, 1.292f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("CLIQUE", -1566607184L, -1f, 0.167f, 0.159f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.4f));
      this.Vehc.Add(new VehiclesEmblem("DEVESTE", 1591739866L, -1.5f, 1.066f, 0.13f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.15f));
      this.Vehc.Add(new VehiclesEmblem("DEVIANT", 1279262537L, -1f, 0.111f, 0.123f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.45f));
      this.Vehc.Add(new VehiclesEmblem("DOMINATOR4", -688189648L, -1f, 0.0f, 0.417f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.4f));
      this.Vehc.Add(new VehiclesEmblem("DOMINATOR5", -1375060657L, -1f, 0.0f, 0.417f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.4f));
      this.Vehc.Add(new VehiclesEmblem("DOMINATOR6", -1293924613L, -1f, 0.0f, 0.417f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.4f));
      this.Vehc.Add(new VehiclesEmblem("IMPALER", -2096690334L, -1f, 0.0f, 0.137f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.35f));
      this.Vehc.Add(new VehiclesEmblem("IMPALER2", 1009171724L, -1f, 0.0f, 0.137f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.35f));
      this.Vehc.Add(new VehiclesEmblem("IMPALER3", -1924800695L, -1f, 0.0f, 0.137f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.35f));
      this.Vehc.Add(new VehiclesEmblem("IMPALER4", -1744505657L, -1f, 0.0f, 0.137f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.35f));
      this.Vehc.Add(new VehiclesEmblem("IMPERATOR", 444994115L, -1f, 0.0f, 0.295f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.4f));
      this.Vehc.Add(new VehiclesEmblem("IMPERATOR2", 1637620610L, -1f, 0.0f, 0.295f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.4f));
      this.Vehc.Add(new VehiclesEmblem("IMPERATOR3", -755532233L, -1f, 0.0f, 0.295f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.4f));
      this.Vehc.Add(new VehiclesEmblem("ISSI4", 628003514L, -1f, 0.195f, 0.246f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.4f));
      this.Vehc.Add(new VehiclesEmblem("ISSI5", 1537277726L, -1f, 0.195f, 0.246f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.4f));
      this.Vehc.Add(new VehiclesEmblem("ISSI6", 1239571361L, -1f, 0.195f, 0.246f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.4f));
      this.Vehc.Add(new VehiclesEmblem("ITALIGTO", -331467772L, -1f, -0.091f, 0.207f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.25f));
      this.Vehc.Add(new VehiclesEmblem("MONSTER3", 1721676810L, -1.78f, 0.445f, 0.81f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.45f));
      this.Vehc.Add(new VehiclesEmblem("MONSTER4", 840387324L, -1.78f, 0.445f, 0.81f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.45f));
      this.Vehc.Add(new VehiclesEmblem("MONSTER5", -715746948L, -1.78f, 0.445f, 0.81f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.45f));
      this.Vehc.Add(new VehiclesEmblem("SCHLAGEN", -507495760L, -1f, -0.105f, 0.262f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.4f));
      this.Vehc.Add(new VehiclesEmblem("SLAMVAN4", -2061049099L, -1f, 0.152f, 0.537f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("SLAMVAN5", 373261600L, -1f, 0.152f, 0.537f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("SLAMVAN6", 1742022738L, -1f, 0.152f, 0.537f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.5f));
      this.Vehc.Add(new VehiclesEmblem("TOROS", -1168952148L, -1f, 0.415f, 0.394f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.4f));
      this.Vehc.Add(new VehiclesEmblem("TULIP", 1456744817L, -1f, 0.171f, 0.223f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.35f));
      this.Vehc.Add(new VehiclesEmblem("VAMOS", -49115651L, -1f, 0.0f, 0.163f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.4f));
      this.Vehc.Add(new VehiclesEmblem("ZR380", 540101442L, -1f, 0.0f, 0.286f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.45f));
      this.Vehc.Add(new VehiclesEmblem("ZR3802", -1106120762L, -1f, 0.0f, 0.286f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.45f));
      this.Vehc.Add(new VehiclesEmblem("ZR3803", -1478704292L, -1f, 0.0f, 0.286f, 1f, 0.0f, 0.0f, 0.0f, -1f, 0.0f, 0.45f));
    }

    public new string Name { get; set; }

    public long VHash { get; set; }

    public float xx { get; set; }

    public float xy { get; set; }

    public float xz { get; set; }

    public float yx { get; set; }

    public float yy { get; set; }

    public float yz { get; set; }

    public float zx { get; set; }

    public float zy { get; set; }

    public float zz { get; set; }

    public float scale { get; set; }

    public VehiclesEmblem()
    {
    }

    public VehiclesEmblem(
      string name,
      long hash,
      float XX,
      float XY,
      float XZ,
      float YX,
      float YY,
      float YZ,
      float ZX,
      float ZY,
      float ZZ,
      float Scale)
    {
      this.Name = name;
      this.VHash = hash;
      this.xx = XX;
      this.xy = XY;
      this.xz = XZ;
      this.yx = YX;
      this.yy = YY;
      this.yz = YZ;
      this.zx = ZX;
      this.zy = ZY;
      this.zz = ZZ;
      this.scale = Scale;
    }

    public bool ReturnClanEmblemOn(Vehicle V)
    {
      bool flag = Function.Call<bool>(Hash._0x060D935D3981A275, (InputArgument) V, (InputArgument) 0);
      if (flag)
        this.CreateVehEmblem(V, Game.Player.Character);
      return flag;
    }

    public void CheckforEmblem(Vehicle V)
    {
      if (!Function.Call<bool>(Hash._0x060D935D3981A275, (InputArgument) V, (InputArgument) 0))
        return;
      this.CreateVehEmblem(V, Game.Player.Character);
    }

    public void CreateVehEmblem(Vehicle vehicle, Ped playerPed)
    {
      int index1 = 0;
      bool flag = false;
      long num1 = Function.Call<long>(Hash._0x9F47B058362C84B5, (InputArgument) vehicle);
      List<VehiclesEmblem> vehc = this.Vehc;
      for (int index2 = 0; index2 < 370; ++index2)
      {
        if (num1 == vehc[index2].VHash)
        {
          index1 = index2;
          flag = true;
        }
      }
      int num2 = 200;
      if (num1 == 1581459400L)
        num2 = (int) byte.MaxValue;
      if (flag)
        Function.Call(Hash._0x428BDCB9DA58DA53, (InputArgument) vehicle, (InputArgument) playerPed, (InputArgument) Function.Call<int>(Hash._0xFB71170B7E76ACBA, (InputArgument) vehicle, (InputArgument) "chassis_dummy"), (InputArgument) vehc[index1].xx, (InputArgument) vehc[index1].xy, (InputArgument) vehc[index1].xz, (InputArgument) vehc[index1].yx, (InputArgument) vehc[index1].yy, (InputArgument) vehc[index1].yz, (InputArgument) vehc[index1].zx, (InputArgument) vehc[index1].zy, (InputArgument) vehc[index1].zz, (InputArgument) vehc[index1].scale, (InputArgument) 0, (InputArgument) num2);
      else
        Function.Call(Hash._0x428BDCB9DA58DA53, (InputArgument) vehicle, (InputArgument) playerPed, (InputArgument) Function.Call<int>(Hash._0xFB71170B7E76ACBA, (InputArgument) vehicle, (InputArgument) "chassis_dummy"), (InputArgument) vehc[0].xx, (InputArgument) vehc[0].xy, (InputArgument) vehc[0].xz, (InputArgument) vehc[0].yx, (InputArgument) vehc[0].yy, (InputArgument) vehc[0].yz, (InputArgument) vehc[0].zx, (InputArgument) vehc[0].zy, (InputArgument) vehc[0].zz, (InputArgument) vehc[0].scale, (InputArgument) 0, (InputArgument) num2);
    }
  }
}
