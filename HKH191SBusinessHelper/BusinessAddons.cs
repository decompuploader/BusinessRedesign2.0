using GTA;
using GTA.Math;
using GTA.Native;
using Microsoft.CSharp.RuntimeBinder;
using NativeUI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace HKH191SBusinessHelper
{
  public class BusinessAddons : Script
  {
    public List<Vector3> WordrobePositions = new List<Vector3>();
    public List<Vector3> SHowerPositions = new List<Vector3>();
    public MenuPool Woredrobepool;
    public UIMenu WoredrobeMainMenu;
    public UIMenu WoredrobeMenu;
    public int CompMax;
    public int DrawableMax;
    public bool InShower;
    private ScriptSettings Config;
    public WeaponTint Liv;
    public int ID_O;
    public string ID_C;
    public int Comp;
    public Model OldCharacter;
    public bool isSeated;
    public string SeatDict;
    public List<Vector3> SeatPos = new List<Vector3>();
    public List<float> Seatrot = new List<float>();
    public List<Vector3> DisanceVec = new List<Vector3>();
    public List<float> DisanceFloat = new List<float>();
    public Vector3 CurrentPos;
    public bool gotCurrent;
    public MenuPool DrinksPool;
    public UIMenu DrinksMenu;
    public UIMenu DrinksMainMenu;
    public Prop Champaine;
    public bool IsDrinking;
    public int DrinkTimer;
    public List<Vector3> DrinkPos = new List<Vector3>();
    public List<Prop> Champ = new List<Prop>();
    public int Effect;
    public static Prop Whiskey;
    public static Prop WhiskeyGlass;
    public static Prop Wheat;
    public float DrunkLevel;
    public int DrinkScene;
    public int DrinkType;
    public static Prop Wine;
    public static Prop WineGlass;
    public static Vector3 WinePosition;
    public static Vector3 WineGlassPosition;
    public static Vector3 WineRotation;
    public static Vector3 WineGlassRotation;
    public static int DrunkStage = 1;
    public static int WhiskeyTaskScriptStatus = -1;
    public static int WineTaskScriptStatus = -1;
    public static int WheatTaskScriptStatus = -1;
    public static List<Model> WineModels = new List<Model>()
    {
      (Model) 21833643
    };
    public static List<Model> WineGlassModels = new List<Model>()
    {
      (Model) -35679191
    };
    public static List<Model> WheatModels = new List<Model>()
    {
      (Model) 469594741
    };
    public static List<Model> WhiskeyModels = new List<Model>()
    {
      (Model) 488156118
    };
    public static List<Model> WhiskeyGlassModels = new List<Model>()
    {
      (Model) -1533900808,
      (Model) 1480049515
    };
    public static Vector3 WhiskeyPosition;
    public static Vector3 WhiskeyGlassPosition;
    public static Vector3 WhiskeyRotation;
    public static Vector3 WhiskeyGlassRotation;
    public static Vector3 WheatPosition;
    public static Vector3 WheatRotation;
    public int DrunkCamTimer;
    public int BottleType;
    public Prop Bottle;
    public Prop Glass;
    public bool RadioOn;
    public int Station;
    public List<Vector3> RadioPos = new List<Vector3>();
    public Vector3 CurrentRadio;
    public int CurrentInt;
    public float Z_min;
    public float Z_max;
    public UIResRectangle RectangleGUI = new UIResRectangle(new Point(0, 0), new Size(0, 0));
    public List<UIMenu> GUIMenus = new List<UIMenu>();
    public int Scene1;
    public bool SwitchScene;
    public Keys Key;
    public bool UseLShift;
    public bool UseLCTRL;
    public bool UseContoller;
    public List<Bed> LeftBeds = new List<Bed>()
    {
      new Bed(new Vector3(973.8195f, 76.553f, 116.17f), 58.97f),
      new Bed(new Vector3(988.3521f, 71.86349f, 116.1642f), -119.4195f),
      new Bed(new Vector3(985.809f, 73.31565f, 116.1642f), -120.7491f),
      new Bed(new Vector3(363.5026f, 4821.034f, -58.99344f), -8.954158f)
    };
    public List<Bed> RightBeds = new List<Bed>()
    {
      new Bed(new Vector3(-83.447f, -811.2223f, 243.38f), 9.77f),
      new Bed(new Vector3(-127.2519f, -631.508f, 168.8205f), -154.3245f),
      new Bed(new Vector3(-1382.403f, -466.2151f, 72.04217f), -48.61733f),
      new Bed(new Vector3(-1562.269f, -567.2115f, 108.523f), -114.8341f),
      new Bed(new Vector3(-1562.269f, -567.2115f, 108.523f), -114.8341f)
    };

    public void AddSeatPos()
    {
      this.SeatPos.Add(new Vector3(-66.67178f, -822.3694f, 243.8156f));
      this.Seatrot.Add(-16.04f);
      this.SeatPos.Add(new Vector3(-65.20499f, -822.8921f, 243.8156f));
      this.Seatrot.Add(-24.04135f);
      this.SeatPos.Add(new Vector3(-63.71706f, -822.3007f, 243.8182f));
      this.Seatrot.Add(73.76846f);
      this.SeatPos.Add(new Vector3(-63.14892f, -820.9191f, 243.818f));
      this.Seatrot.Add(67.78606f);
      this.SeatPos.Add(new Vector3(-71.54662f, -806.9418f, 243.8441f));
      this.Seatrot.Add(-70.41522f);
      this.SeatPos.Add(new Vector3(-69.23227f, -803.9342f, 243.8155f));
      this.Seatrot.Add(157.4493f);
      this.SeatPos.Add(new Vector3(-67.67493f, -804.4633f, 243.8155f));
      this.Seatrot.Add(155.9558f);
      this.SeatPos.Add(new Vector3(-147.2515f, -629.1166f, 159.2501f));
      this.Seatrot.Add(-178.8413f);
      this.SeatPos.Add(new Vector3(-149.0478f, -629.3021f, 169.2501f));
      this.Seatrot.Add(-174.0546f);
      this.SeatPos.Add(new Vector3(-150.0277f, -630.5875f, 169.2528f));
      this.Seatrot.Add(-91.69424f);
      this.SeatPos.Add(new Vector3(-149.9828f, -631.8755f, 169.2526f));
      this.Seatrot.Add(-85.3838f);
      this.SeatPos.Add(new Vector3(-136.2988f, -640.9444f, 169.2785f));
      this.Seatrot.Add(132.1691f);
      this.SeatPos.Add(new Vector3(-137.133f, -644.6409f, 169.2501f));
      this.Seatrot.Add(8.298168f);
      this.SeatPos.Add(new Vector3(-138.5867f, -644.6381f, 169.2501f));
      this.Seatrot.Add(0.6f);
      this.SeatPos.Add(new Vector3(-1580.531f, -574.931f, 108.9525f));
      this.Seatrot.Add(-144.4652f);
      this.SeatPos.Add(new Vector3(-1581.932f, -575.9481f, 108.9525f));
      this.Seatrot.Add(-142.0595f);
      this.SeatPos.Add(new Vector3(-1582.173f, -577.585f, 108.9551f));
      this.Seatrot.Add(-53.8382f);
      this.SeatPos.Add(new Vector3(-1581.376f, -578.6484f, 108.9551f));
      this.Seatrot.Add(-53.09078f);
      this.SeatPos.Add(new Vector3(-1565.178f, -579.6127f, 108.9811f));
      this.Seatrot.Add(163.9803f);
      this.SeatPos.Add(new Vector3(-1563.857f, -583.144f, 108.9526f));
      this.Seatrot.Add(41.33947f);
      this.SeatPos.Add(new Vector3(-1565.34f, -584.2143f, 108.9526f));
      this.Seatrot.Add(35.13739f);
      this.SeatPos.Add(new Vector3(-1384.257f, -485.9651f, 72.47179f));
      this.Seatrot.Add(-84.4781f);
      this.SeatPos.Add(new Vector3(-1384.016f, -487.6932f, 72.4717f));
      this.Seatrot.Add(-79.57191f);
      this.SeatPos.Add(new Vector3(-1382.735f, -488.8167f, 72.47272f));
      this.Seatrot.Add(9.020525f);
      this.SeatPos.Add(new Vector3(-1381.34f, -488.4853f, 72.47435f));
      this.Seatrot.Add(14.12658f);
      this.SeatPos.Add(new Vector3(-1372.847f, -474.6076f, 72.5003f));
      this.Seatrot.Add(-133.1861f);
      this.SeatPos.Add(new Vector3(-1369.092f, -475.1668f, 72.47179f));
      this.Seatrot.Add(105.7902f);
      this.SeatPos.Add(new Vector3(-1368.86f, -476.8094f, 72.47179f));
      this.Seatrot.Add(102.4102f);
      this.SeatPos.Add(new Vector3(1125.353f, -3146.414f, -36.58086f));
      this.Seatrot.Add(83.52718f);
      this.SeatPos.Add(new Vector3(1125.429f, -3144.897f, -36.61121f));
      this.Seatrot.Add(92.69582f);
      this.SeatPos.Add(new Vector3(1125.256f, -3143.649f, -36.61121f));
      this.Seatrot.Add(87.18952f);
      this.SeatPos.Add(new Vector3(1123.775f, -3142.763f, -36.61115f));
      this.Seatrot.Add(-173.4477f);
      this.SeatPos.Add(new Vector3(1124.081f, -3152.629f, -36.50807f));
      this.Seatrot.Add(5.25504f);
      this.SeatPos.Add(new Vector3(1008.954f, -3168.126f, -33.63366f));
      this.Seatrot.Add(8.411994f);
      this.SeatPos.Add(new Vector3(1007.812f, -3168.093f, -33.63366f));
      this.Seatrot.Add(-6.344473f);
      this.SeatPos.Add(new Vector3(1005.825f, -3166.64f, -33.63366f));
      this.Seatrot.Add(-74.41931f);
      this.SeatPos.Add(new Vector3(1005.724f, -3165.146f, -33.63366f));
      this.Seatrot.Add(-92.51505f);
      this.SeatPos.Add(new Vector3(-1239.456f, -3015.363f, -42.41042f));
      this.Seatrot.Add(3.784568f);
      this.SeatPos.Add(new Vector3(-1237.919f, -3015.364f, -42.41042f));
      this.Seatrot.Add(-0.08942f);
      this.SeatPos.Add(new Vector3(-1240.854f, -3014.181f, -42.41704f));
      this.Seatrot.Add(-94.16585f);
      this.SeatPos.Add(new Vector3(-1240.023f, -3012.518f, -42.41704f));
      this.Seatrot.Add(-141.2868f);
      this.SeatPos.Add(new Vector3(366.7062f, 4840.808f, -58.54266f));
      this.Seatrot.Add(19.6571f);
      this.SeatPos.Add(new Vector3(362.5725f, 4841.933f, -58.54595f));
      this.Seatrot.Add(-74.27504f);
      this.SeatPos.Add(new Vector3(364.7543f, 4845.134f, -58.54667f));
      this.Seatrot.Add(156.5527f);
      this.SeatPos.Add(new Vector3(366.3707f, 4844.639f, -58.54668f));
      this.Seatrot.Add(163.3151f);
      this.SeatPos.Add(new Vector3(369.9072f, 4826.709f, -58.53629f));
      this.Seatrot.Add(159.5838f);
    }

    public static string LoadDict(string dict)
    {
      while (true)
      {
        if (!Function.Call<bool>(Hash._0xD031A9162D01088C, (InputArgument) dict))
        {
          Function.Call(Hash._0xD3BD40951412FEF6, (InputArgument) dict);
          Script.Yield();
        }
        else
          break;
      }
      return dict;
    }

    public Model RequestModel(int Prop)
    {
      Model model = new Model(Prop);
      model.Request(250);
      if (model.IsInCdImage && model.IsValid)
      {
        while (!model.IsLoaded)
          Script.Wait(50);
        return model;
      }
      model.MarkAsNoLongerNeeded();
      return model;
    }

    public Model RequestModel(string Prop)
    {
      Model model = new Model(Prop);
      model.Request(250);
      if (model.IsInCdImage && model.IsValid)
      {
        while (!model.IsLoaded)
          Script.Wait(50);
        return model;
      }
      model.MarkAsNoLongerNeeded();
      return model;
    }

    public void WhiskeyMethod()
    {
      try
      {
        switch (BusinessAddons.WhiskeyTaskScriptStatus)
        {
          case 0:
            this.Bottle.IsVisible = false;
            this.Glass.IsVisible = false;
            BusinessAddons.WhiskeyTaskScriptStatus = 1;
            break;
          case 1:
            BusinessAddons.Whiskey = this.Bottle;
            BusinessAddons.WhiskeyGlass = this.Glass;
            BusinessAddons.WhiskeyPosition = BusinessAddons.Whiskey.Position;
            BusinessAddons.WhiskeyRotation = BusinessAddons.Whiskey.Rotation;
            BusinessAddons.WhiskeyTaskScriptStatus = 2;
            break;
          case 2:
            Game.Player.Character.Task.PlayAnimation("mp_safehousewhiskey@", "enter", 2f, 15500, false, -1f);
            Script.Wait(1500);
            this.Bottle.IsVisible = true;
            if (this.BottleType == 0)
              BusinessAddons.Whiskey.AttachTo((Entity) Game.Player.Character, Game.Player.Character.GetBoneIndex(Bone.PH_R_Hand), new Vector3(0.06f, -0.04f, -0.06f), new Vector3(-60f, 0.0f, 0.0f));
            if (this.BottleType == 1)
              BusinessAddons.Whiskey.AttachTo((Entity) Game.Player.Character, Game.Player.Character.GetBoneIndex(Bone.PH_R_Hand), new Vector3(0.06f, -0.04f, -0.06f), new Vector3(-60f, 0.0f, 0.0f));
            else if (this.BottleType == 2)
              BusinessAddons.Whiskey.AttachTo((Entity) Game.Player.Character, Game.Player.Character.GetBoneIndex(Bone.PH_R_Hand), new Vector3(0.06f, -0.04f, -0.06f), new Vector3(-60f, 0.0f, 0.0f));
            else if (this.BottleType == 3)
              BusinessAddons.Whiskey.AttachTo((Entity) Game.Player.Character, Game.Player.Character.GetBoneIndex(Bone.PH_R_Hand), new Vector3(0.06f, -0.04f, -0.06f), new Vector3(-60f, 0.0f, 0.0f));
            else if (this.BottleType == 4)
              BusinessAddons.Whiskey.AttachTo((Entity) Game.Player.Character, Game.Player.Character.GetBoneIndex(Bone.PH_R_Hand), new Vector3(0.06f, -0.04f, -0.06f), new Vector3(-60f, 0.0f, 0.0f));
            else
              BusinessAddons.Whiskey.AttachTo((Entity) Game.Player.Character, Game.Player.Character.GetBoneIndex(Bone.PH_R_Hand), new Vector3(0.06f, -0.04f, -0.06f), new Vector3(-60f, 0.0f, 0.0f));
            BusinessAddons.WhiskeyTaskScriptStatus = 3;
            break;
          case 3:
            if (BusinessAddons.Whiskey.IsAttachedTo((Entity) Game.Player.Character))
            {
              Script.Wait(2000);
              BusinessAddons.WhiskeyGlass.Position = BusinessAddons.Whiskey.GetOffsetInWorldCoords(new Vector3(0.0f, 0.2f, 0.0f));
              BusinessAddons.WhiskeyGlass.IsVisible = true;
              BusinessAddons.WhiskeyGlassPosition = BusinessAddons.WhiskeyGlass.Position;
              BusinessAddons.WhiskeyGlassRotation = BusinessAddons.WhiskeyGlass.Rotation;
              Script.Wait(1000);
              BusinessAddons.WhiskeyGlass.AttachTo((Entity) Game.Player.Character, Game.Player.Character.GetBoneIndex(Bone.IK_L_Hand), new Vector3(0.1f, 0.0f, 0.04f), new Vector3(-100f, 10f, 0.0f));
              Script.Wait(2000);
              BusinessAddons.Whiskey.Detach();
              BusinessAddons.Whiskey.Position = BusinessAddons.WhiskeyPosition;
              BusinessAddons.Whiskey.Rotation = BusinessAddons.WhiskeyRotation;
              BusinessAddons.WhiskeyTaskScriptStatus = 4;
              BusinessAddons.Whiskey.IsVisible = false;
              break;
            }
            break;
          case 4:
            if (BusinessAddons.WhiskeyGlass.IsAttachedTo((Entity) Game.Player.Character))
            {
              Script.Wait(4000);
              BusinessAddons.WhiskeyGlass.Detach();
              BusinessAddons.WhiskeyGlass.Position = BusinessAddons.WhiskeyGlassPosition;
              BusinessAddons.WhiskeyGlass.Rotation = BusinessAddons.WhiskeyGlassRotation;
              BusinessAddons.WhiskeyTaskScriptStatus = 5;
              this.DrunkLevel += 2f;
              break;
            }
            break;
          case 5:
            if (BusinessAddons.DrunkStage == 1)
              ++BusinessAddons.DrunkStage;
            BusinessAddons.WhiskeyTaskScriptStatus = -1;
            this.Bottle.Delete();
            this.Glass.Delete();
            break;
        }
        if (!Game.Player.IsDead && !Game.Player.Character.IsRagdoll)
          return;
        BusinessAddons.Whiskey.Detach();
        BusinessAddons.WhiskeyGlass.Detach();
        BusinessAddons.Whiskey.Position = BusinessAddons.WhiskeyPosition;
        BusinessAddons.Whiskey.Rotation = BusinessAddons.WhiskeyRotation;
        BusinessAddons.WhiskeyGlass.Position = BusinessAddons.WhiskeyGlassPosition;
        BusinessAddons.WhiskeyGlass.Rotation = BusinessAddons.WhiskeyGlassRotation;
        BusinessAddons.WhiskeyTaskScriptStatus = -1;
      }
      catch (Exception ex)
      {
      }
    }

    public void WineMethod()
    {
      try
      {
        Ped character = Game.Player.Character;
        switch (BusinessAddons.WineTaskScriptStatus)
        {
          case 0:
            this.Bottle.IsVisible = false;
            this.Glass.IsVisible = false;
            BusinessAddons.Wine = this.Bottle;
            BusinessAddons.WineGlass = this.Glass;
            BusinessAddons.WineTaskScriptStatus = 1;
            break;
          case 1:
            BusinessAddons.WinePosition = BusinessAddons.Wine.Position;
            BusinessAddons.WineRotation = BusinessAddons.Wine.Rotation;
            BusinessAddons.WineTaskScriptStatus = 2;
            break;
          case 2:
            Game.Player.Character.Task.PlayAnimation("mp_safehousewine@", "drinking_wine", 2f, 15500, false, -1f);
            Script.Wait(1000);
            this.Bottle.IsVisible = true;
            BusinessAddons.Wine.AttachTo((Entity) character, character.GetBoneIndex(Bone.PH_R_Hand), new Vector3(0.13f, 0.05f, -0.06f), new Vector3(-60f, 0.0f, 0.0f));
            BusinessAddons.WineTaskScriptStatus = 3;
            break;
          case 3:
            if (BusinessAddons.Wine.IsAttachedTo((Entity) character))
            {
              BusinessAddons.WineGlassPosition = BusinessAddons.WineGlass.Position;
              BusinessAddons.WineGlassRotation = BusinessAddons.WineGlass.Rotation;
              Script.Wait(500);
              this.Glass.IsVisible = true;
              BusinessAddons.WineGlass.AttachTo((Entity) character, character.GetBoneIndex(Bone.PH_L_Hand), new Vector3(0.1f, 0.0f, 0.04f), new Vector3(-100f, 10f, 0.0f));
              BusinessAddons.WineTaskScriptStatus = 4;
              ++this.DrunkLevel;
              break;
            }
            break;
          case 4:
            if (BusinessAddons.WineGlass.IsAttachedTo((Entity) character))
            {
              Script.Wait(5000);
              BusinessAddons.Wine.Detach();
              this.Bottle.IsVisible = false;
              BusinessAddons.Wine.Position = BusinessAddons.WinePosition;
              BusinessAddons.Wine.Rotation = BusinessAddons.WineRotation;
              Script.Wait(9000);
              this.Glass.IsVisible = false;
              BusinessAddons.WineGlass.Detach();
              BusinessAddons.WineGlass.Position = BusinessAddons.WineGlassPosition;
              BusinessAddons.WineGlass.Rotation = BusinessAddons.WineGlassRotation;
              BusinessAddons.WineTaskScriptStatus = 5;
              break;
            }
            break;
          case 5:
            BusinessAddons.WineTaskScriptStatus = -1;
            break;
        }
        if (!Game.Player.IsDead && !Game.Player.Character.IsRagdoll)
          return;
        BusinessAddons.Wine.Detach();
        BusinessAddons.WineGlass.Detach();
        BusinessAddons.Wine.Position = BusinessAddons.WinePosition;
        BusinessAddons.Wine.Rotation = BusinessAddons.WineRotation;
        BusinessAddons.WineGlass.Position = BusinessAddons.WineGlassPosition;
        BusinessAddons.WineGlass.Rotation = BusinessAddons.WineGlassRotation;
        BusinessAddons.WineTaskScriptStatus = -1;
      }
      catch
      {
      }
    }

    public void Drinks()
    {
      UIMenu uiMenu = this.DrinksPool.AddSubMenu(this.DrinksMenu, nameof (Drinks));
      this.GUIMenus.Add(uiMenu);
      this.GUIMenus.Add(uiMenu);
      UIMenuItem DrinkA = new UIMenuItem("Pisswasser                                               $25");
      uiMenu.AddItem(DrinkA);
      UIMenuItem DrinkB = new UIMenuItem("Vodka Shot                                              $75");
      uiMenu.AddItem(DrinkB);
      UIMenuItem DrinkC = new UIMenuItem("The Mount Whiskey Shot                       $250");
      uiMenu.AddItem(DrinkC);
      UIMenuItem DrinkD = new UIMenuItem("Richard's Whiskey Shot                       $1,000");
      uiMenu.AddItem(DrinkD);
      UIMenuItem DrinkE = new UIMenuItem("Macbeth Whiskey Shot                       $5,000");
      uiMenu.AddItem(DrinkE);
      UIMenuItem DrinkF = new UIMenuItem("Bleuter'd Champaine Slver                $30,000");
      uiMenu.AddItem(DrinkF);
      UIMenuItem DrinkG = new UIMenuItem("Bleuter'd Champaine Gold                $50,000");
      uiMenu.AddItem(DrinkG);
      UIMenuItem DrinkH = new UIMenuItem("Bleuter'd Champaine Diamond        $150,000");
      uiMenu.AddItem(DrinkH);
      uiMenu.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == DrinkH)
        {
          if (Game.Player.Money >= 150000)
          {
            Game.Player.Money -= 150000;
            Game.Player.Character.Weapons.Select(WeaponHash.Unarmed);
            Prop prop = World.CreateProp(this.RequestModel("ba_prop_battle_champ_closed_03"), Game.Player.Character.GetOffsetInWorldCoords(new Vector3(5f, 0.0f, -1f)), false, false);
            prop.FreezePosition = true;
            prop.Position = Game.Player.Character.GetBoneCoord(Bone.IK_R_Hand, new Vector3(0.0f, 0.0f, 0.0f));
            this.Champaine = prop;
            this.Champ.Add(prop);
            this.IsDrinking = true;
            Game.Player.Character.Task.PlayAnimation("anim@heists@heist_safehouse_intro@wine@window", "wine_window_part_one", 5f, 5f, 4500, AnimationFlags.UpperBodyOnly, 0.0f);
            this.Effect = 6;
            Function.Call(Hash._0x6B9BBD38AB0796DF, (InputArgument) this.Champaine, (InputArgument) Game.Player.Character, (InputArgument) Game.Player.Character.GetBoneIndex(Bone.PH_R_Hand), (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 2, (InputArgument) 1);
            this.DrinksPool.CloseAllMenus();
            Game.Player.Character.Weapons.Select(WeaponHash.BZGas);
            Game.Player.Character.FreezePosition = true;
            Game.Player.Character.GetBoneCoord(Bone.PH_R_Hand, new Vector3(-0.05f, 0.0f, -0.05f));
            Script.Wait(5000);
            Game.Player.Character.HasGravity = true;
            Game.Player.Character.FreezePosition = false;
            this.Champaine.FreezePosition = false;
            this.Champaine.HasCollision = true;
            this.DrinkTimer = 0;
            Game.Player.Character.Task.ClearAnimation("anim@heists@heist_safehouse_intro@wine@window", "wine_window_part_one");
            Game.Player.Character.Task.ClearAll();
            Game.Player.Character.Task.ClearAllImmediately();
            this.Champaine.Detach();
            this.DrunkLevel += 5f;
            if ((double) this.DrunkLevel >= 8.0 && (double) this.DrunkLevel < 16.0)
            {
              Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@MODERATEDRUNK");
              Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
            }
            if ((double) this.DrunkLevel >= 16.0 && (double) this.DrunkLevel < 24.0)
            {
              Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@SLIGHTLYDRUNK");
              Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
            }
            if ((double) this.DrunkLevel >= 24.0 && (double) this.DrunkLevel < 36.0)
            {
              Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK");
              Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
            }
          }
          else
            UI.Notify("You do not have enough money for this Drink!");
        }
        if (item == DrinkG)
        {
          if (Game.Player.Money >= 50000)
          {
            Game.Player.Money -= 50000;
            Game.Player.Character.Weapons.Select(WeaponHash.Unarmed);
            Prop prop = World.CreateProp(this.RequestModel("ba_prop_battle_champ_closed_02"), Game.Player.Character.GetOffsetInWorldCoords(new Vector3(5f, 0.0f, -1f)), false, false);
            prop.FreezePosition = true;
            prop.Position = Game.Player.Character.GetBoneCoord(Bone.IK_R_Hand, new Vector3(0.0f, 0.0f, 0.0f));
            this.Champaine = prop;
            this.Champ.Add(prop);
            this.IsDrinking = true;
            Game.Player.Character.Task.PlayAnimation("anim@heists@heist_safehouse_intro@wine@window", "wine_window_part_one", 5f, 5f, 4500, AnimationFlags.UpperBodyOnly, 0.0f);
            this.Effect = 6;
            Function.Call(Hash._0x6B9BBD38AB0796DF, (InputArgument) this.Champaine, (InputArgument) Game.Player.Character, (InputArgument) Game.Player.Character.GetBoneIndex(Bone.PH_R_Hand), (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 2, (InputArgument) 1);
            this.DrinksPool.CloseAllMenus();
            Game.Player.Character.Weapons.Select(WeaponHash.BZGas);
            Game.Player.Character.FreezePosition = true;
            Game.Player.Character.GetBoneCoord(Bone.PH_R_Hand, new Vector3(-0.05f, 0.0f, -0.05f));
            Script.Wait(5000);
            Game.Player.Character.HasGravity = true;
            Game.Player.Character.FreezePosition = false;
            this.Champaine.FreezePosition = false;
            this.Champaine.HasCollision = true;
            this.DrinkTimer = 0;
            Game.Player.Character.Task.ClearAnimation("anim@heists@heist_safehouse_intro@wine@window", "wine_window_part_one");
            Game.Player.Character.Task.ClearAll();
            Game.Player.Character.Task.ClearAllImmediately();
            this.Champaine.Detach();
            this.DrunkLevel += 5f;
            if ((double) this.DrunkLevel >= 8.0 && (double) this.DrunkLevel < 16.0)
            {
              Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@MODERATEDRUNK");
              Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
            }
            if ((double) this.DrunkLevel >= 16.0 && (double) this.DrunkLevel < 24.0)
            {
              Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@SLIGHTLYDRUNK");
              Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
            }
            if ((double) this.DrunkLevel >= 24.0 && (double) this.DrunkLevel < 36.0)
            {
              Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK");
              Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
            }
          }
          else
            UI.Notify("You do not have enough money for this Drink!");
        }
        if (item == DrinkF)
        {
          if (Game.Player.Money >= 30000)
          {
            Game.Player.Money -= 30000;
            Game.Player.Character.Weapons.Select(WeaponHash.Unarmed);
            Prop prop = World.CreateProp(this.RequestModel("ba_prop_battle_champ_closed"), Game.Player.Character.GetOffsetInWorldCoords(new Vector3(5f, 0.0f, -1f)), false, false);
            prop.FreezePosition = true;
            prop.Position = Game.Player.Character.GetBoneCoord(Bone.IK_R_Hand, new Vector3(0.0f, 0.0f, 0.0f));
            this.Champaine = prop;
            this.Champ.Add(prop);
            this.IsDrinking = true;
            Game.Player.Character.Task.PlayAnimation("anim@heists@heist_safehouse_intro@wine@window", "wine_window_part_one", 5f, 5f, 4500, AnimationFlags.UpperBodyOnly, 0.0f);
            this.Effect = 6;
            Function.Call(Hash._0x6B9BBD38AB0796DF, (InputArgument) this.Champaine, (InputArgument) Game.Player.Character, (InputArgument) Game.Player.Character.GetBoneIndex(Bone.PH_R_Hand), (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0.0f, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 2, (InputArgument) 1);
            this.DrinksPool.CloseAllMenus();
            Game.Player.Character.Weapons.Select(WeaponHash.BZGas);
            Game.Player.Character.FreezePosition = true;
            Game.Player.Character.GetBoneCoord(Bone.PH_R_Hand, new Vector3(-0.05f, 0.0f, -0.05f));
            Script.Wait(5000);
            Game.Player.Character.HasGravity = true;
            Game.Player.Character.FreezePosition = false;
            this.Champaine.FreezePosition = false;
            this.Champaine.HasCollision = true;
            this.DrinkTimer = 0;
            Game.Player.Character.Task.ClearAnimation("anim@heists@heist_safehouse_intro@wine@window", "wine_window_part_one");
            Game.Player.Character.Task.ClearAll();
            Game.Player.Character.Task.ClearAllImmediately();
            this.Champaine.Detach();
            this.DrunkLevel += 5f;
            if ((double) this.DrunkLevel >= 8.0 && (double) this.DrunkLevel < 16.0)
            {
              Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@MODERATEDRUNK");
              Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
            }
            if ((double) this.DrunkLevel >= 16.0 && (double) this.DrunkLevel < 24.0)
            {
              Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@SLIGHTLYDRUNK");
              Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
            }
            if ((double) this.DrunkLevel >= 24.0 && (double) this.DrunkLevel < 36.0)
            {
              Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK");
              Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
            }
          }
          else
            UI.Notify("You do not have enough money for this Drink!");
        }
        if (item == DrinkE)
        {
          if (Game.Player.Money >= 5000)
          {
            BusinessAddons.WineTaskScriptStatus = 0;
            BusinessAddons.WhiskeyTaskScriptStatus = 0;
            Game.Player.Money -= 5000;
            Game.Player.Character.Weapons.Select(WeaponHash.Unarmed);
            Prop prop = World.CreateProp(this.RequestModel("prop_cs_whiskey_bottle"), Game.Player.Character.GetOffsetInWorldCoords(new Vector3(5f, 0.0f, -1f)), false, false);
            prop.FreezePosition = true;
            prop.Position = Game.Player.Character.GetBoneCoord(Bone.IK_R_Hand, new Vector3(0.0f, 0.0f, 0.0f));
            this.Champaine = prop;
            this.Champ.Add(prop);
            BusinessAddons.WhiskeyTaskScriptStatus = 0;
            this.Bottle = this.Champaine;
            this.Glass = World.CreateProp(this.RequestModel(1480049515), Game.Player.Character.Position, false, false);
            this.IsDrinking = true;
            this.Effect = 3;
            this.DrinksPool.CloseAllMenus();
            this.BottleType = 1;
            this.DrunkLevel += 9f;
            if ((double) this.DrunkLevel >= 8.0 && (double) this.DrunkLevel < 16.0)
            {
              Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@MODERATEDRUNK");
              Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
            }
            if ((double) this.DrunkLevel >= 16.0 && (double) this.DrunkLevel < 24.0)
            {
              Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@SLIGHTLYDRUNK");
              Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
            }
            if ((double) this.DrunkLevel >= 24.0 && (double) this.DrunkLevel < 36.0)
            {
              Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK");
              Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
            }
          }
          else
            UI.Notify(" : You do not have enough money for this Drink!");
        }
        if (item == DrinkD)
        {
          if (Game.Player.Money >= 1000)
          {
            BusinessAddons.WineTaskScriptStatus = 0;
            BusinessAddons.WhiskeyTaskScriptStatus = 0;
            Game.Player.Money -= 1000;
            Game.Player.Character.Weapons.Select(WeaponHash.Unarmed);
            Prop prop = World.CreateProp(this.RequestModel("prop_cs_whiskey_bottle"), Game.Player.Character.GetOffsetInWorldCoords(new Vector3(5f, 0.0f, -1f)), false, false);
            prop.Position = Game.Player.Character.GetBoneCoord(Bone.IK_R_Hand, new Vector3(0.0f, 0.0f, 0.0f));
            this.Champaine = prop;
            this.Champ.Add(prop);
            BusinessAddons.WhiskeyTaskScriptStatus = 0;
            this.Bottle = this.Champaine;
            this.Glass = World.CreateProp(this.RequestModel(1480049515), Game.Player.Character.Position, false, false);
            this.IsDrinking = true;
            this.Effect = 3;
            this.DrinksPool.CloseAllMenus();
            this.DrunkLevel += 12f;
            if ((double) this.DrunkLevel >= 8.0 && (double) this.DrunkLevel < 16.0)
            {
              Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@MODERATEDRUNK");
              Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
            }
            if ((double) this.DrunkLevel >= 16.0 && (double) this.DrunkLevel < 24.0)
            {
              Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@SLIGHTLYDRUNK");
              Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
            }
            if ((double) this.DrunkLevel >= 24.0 && (double) this.DrunkLevel < 36.0)
            {
              Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK");
              Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
            }
          }
          else
            UI.Notify("You do not have enough money for this Drink!");
        }
        if (item == DrinkC)
        {
          if (Game.Player.Money >= 250)
          {
            BusinessAddons.WineTaskScriptStatus = 0;
            BusinessAddons.WhiskeyTaskScriptStatus = 0;
            Game.Player.Money -= 250;
            Game.Player.Character.Weapons.Select(WeaponHash.Unarmed);
            Prop prop = World.CreateProp(this.RequestModel("prop_cs_whiskey_bottle"), Game.Player.Character.GetOffsetInWorldCoords(new Vector3(5f, 0.0f, -1f)), false, false);
            prop.Position = Game.Player.Character.GetBoneCoord(Bone.IK_R_Hand, new Vector3(0.0f, 0.0f, 0.0f));
            this.Champaine = prop;
            this.Champ.Add(prop);
            BusinessAddons.WhiskeyTaskScriptStatus = 0;
            this.Bottle = this.Champaine;
            this.Glass = World.CreateProp(this.RequestModel(1480049515), Game.Player.Character.Position, false, false);
            this.IsDrinking = true;
            this.Effect = 1;
            this.BottleType = 1;
            this.DrinksPool.CloseAllMenus();
            this.DrunkLevel += 14f;
            if ((double) this.DrunkLevel >= 8.0 && (double) this.DrunkLevel < 16.0)
            {
              Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@MODERATEDRUNK");
              Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
            }
            if ((double) this.DrunkLevel >= 16.0 && (double) this.DrunkLevel < 24.0)
            {
              Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@SLIGHTLYDRUNK");
              Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
            }
            if ((double) this.DrunkLevel >= 24.0 && (double) this.DrunkLevel < 36.0)
            {
              Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK");
              Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
            }
          }
          else
            UI.Notify("You do not have enough money for this Drink!");
        }
        if (item == DrinkB)
        {
          if (Game.Player.Money >= 75)
          {
            BusinessAddons.WineTaskScriptStatus = 0;
            BusinessAddons.WhiskeyTaskScriptStatus = 0;
            Game.Player.Money -= 75;
            Game.Player.Character.Weapons.Select(WeaponHash.Unarmed);
            Prop prop = World.CreateProp(this.RequestModel("prop_vodka_bottle"), Game.Player.Character.GetOffsetInWorldCoords(new Vector3(5f, 0.0f, -1f)), false, false);
            prop.Position = Game.Player.Character.GetBoneCoord(Bone.IK_R_Hand, new Vector3(0.0f, 0.0f, 0.0f));
            this.Champaine = prop;
            this.Champ.Add(prop);
            BusinessAddons.WhiskeyTaskScriptStatus = 0;
            this.Bottle = this.Champaine;
            this.Glass = World.CreateProp(this.RequestModel(1480049515), Game.Player.Character.Position, false, false);
            this.IsDrinking = true;
            this.Effect = 0;
            this.DrinksPool.CloseAllMenus();
            this.DrunkLevel += 16f;
            if ((double) this.DrunkLevel >= 8.0 && (double) this.DrunkLevel < 16.0)
            {
              Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@MODERATEDRUNK");
              Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
            }
            if ((double) this.DrunkLevel >= 16.0 && (double) this.DrunkLevel < 24.0)
            {
              Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@SLIGHTLYDRUNK");
              Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
            }
            if ((double) this.DrunkLevel >= 24.0 && (double) this.DrunkLevel < 36.0)
            {
              Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK");
              Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
            }
          }
          else
            UI.Notify("You do not have enough money for this Drink!");
        }
        if (item != DrinkA)
          return;
        if (Game.Player.Money >= 25)
        {
          BusinessAddons.WineTaskScriptStatus = 0;
          BusinessAddons.WhiskeyTaskScriptStatus = 0;
          Game.Player.Money -= 25;
          Game.Player.Character.Weapons.Select(WeaponHash.Unarmed);
          Prop prop = World.CreateProp(this.RequestModel("prop_sh_beer_pissh_01"), Game.Player.Character.GetOffsetInWorldCoords(new Vector3(5f, 0.0f, -1f)), false, false);
          prop.Position = Game.Player.Character.GetBoneCoord(Bone.IK_R_Hand, new Vector3(0.0f, 0.0f, 0.0f));
          this.Champaine = prop;
          this.Champ.Add(prop);
          BusinessAddons.WhiskeyTaskScriptStatus = 0;
          this.Bottle = this.Champaine;
          this.Glass = World.CreateProp(this.RequestModel(1480049515), Game.Player.Character.Position, false, false);
          this.IsDrinking = true;
          this.Effect = 0;
          this.DrinksPool.CloseAllMenus();
          this.DrunkLevel += 6f;
          if ((double) this.DrunkLevel >= 8.0 && (double) this.DrunkLevel < 16.0)
          {
            Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@MODERATEDRUNK");
            Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
          }
          if ((double) this.DrunkLevel >= 16.0 && (double) this.DrunkLevel < 24.0)
          {
            Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@SLIGHTLYDRUNK");
            Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
          }
          if ((double) this.DrunkLevel >= 24.0 && (double) this.DrunkLevel < 36.0)
          {
            Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK");
            Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
          }
        }
        else
          UI.Notify("You do not have enough money for this Drink!");
      });
    }

    public BusinessAddons()
    {
      this.AddSeatPos();
      this.Tick += new EventHandler(this.OnTick);
      this.Aborted += new EventHandler(this.OnShutdown);
      this.KeyDown += new KeyEventHandler(this.OnKeyDown);
      this.Interval = 1;
      this.Setup();
    }

    public void SetBanner(UIMenu menu) => menu.SetBannerType(this.RectangleGUI);

    public void CreateBanner()
    {
      this.RectangleGUI = new UIResRectangle();
      this.RectangleGUI.Color = Color.FromArgb((int) byte.MaxValue, 0, 0, 0);
    }

    public void Setup()
    {
      BusinessAddons.LoadDict("anim@amb@office@boss@male@");
      this.CreateBanner();
      this.WordrobePositions.Add(new Vector3(-1564.28f, -571.8f, 108f));
      this.WordrobePositions.Add(new Vector3(-132.01f, -634.7f, 168f));
      this.WordrobePositions.Add(new Vector3(-78.1f, -810.8f, 242f));
      this.WordrobePositions.Add(new Vector3(-1379.3f, -470.4f, 71f));
      this.WordrobePositions.Add(new Vector3(-1234.5f, -2981.2f, -42f));
      this.WordrobePositions.Add(new Vector3(365.2f, 4819.3f, -60f));
      this.WordrobePositions.Add(new Vector3(211.3f, 5162f, -90f));
      this.WordrobePositions.Add(new Vector3(1009.8f, -3168f, -40f));
      this.SHowerPositions.Add(new Vector3(-1568f, -567.4f, 107f));
      this.SHowerPositions.Add(new Vector3(-132.6f, -628.8f, 168f));
      this.SHowerPositions.Add(new Vector3(-79.9f, -815.9f, 242f));
      this.SHowerPositions.Add(new Vector3(-1384.9f, -471.4321f, 71f));
      this.SHowerPositions.Add(new Vector3(201.6f, 5161.8f, -90f));
      this.Woredrobepool = new MenuPool();
      this.WoredrobeMainMenu = new UIMenu("Wardrobe", "Select an Option");
      this.GUIMenus.Add(this.WoredrobeMainMenu);
      this.Woredrobepool.Add(this.WoredrobeMainMenu);
      this.WoredrobeMenu = this.Woredrobepool.AddSubMenu(this.WoredrobeMainMenu, "Change Clothes");
      this.GUIMenus.Add(this.WoredrobeMenu);
      this.WareDrobe();
      this.DrinksPool = new MenuPool();
      this.DrinksMainMenu = new UIMenu("Drinks", "Select an Option");
      this.GUIMenus.Add(this.DrinksMainMenu);
      this.DrinksPool.Add(this.DrinksMainMenu);
      this.DrinksMenu = this.DrinksPool.AddSubMenu(this.DrinksMainMenu, "Purchase Options");
      this.GUIMenus.Add(this.DrinksMenu);
      this.Drinks();
      this.DrinkPos.Add(new Vector3(-1375.089f, -468.0802f, 71.5f));
      this.RadioPos.Add(new Vector3(-1375.394f, -466.5916f, 71.5f));
      this.DrinkPos.Add(new Vector3(-129.7669f, -638.9494f, 167.8f));
      this.RadioPos.Add(new Vector3(-128.1932f, -638.8655f, 167.8f));
      this.DrinkPos.Add(new Vector3(-78.24243f, -806.0203f, 242.5f));
      this.RadioPos.Add(new Vector3(-79.64886f, -805.2764f, 242.5f));
      this.DrinkPos.Add(new Vector3(-998.5461f, -3168.538f, -34.5f));
      this.RadioPos.Add(new Vector3(-1235.498f, -3011.41f, -43.5f));
      this.DrinkPos.Add(new Vector3(-1560.735f, -574.652f, 107.5f));
      this.RadioPos.Add(new Vector3(-1559.386f, -573.8264f, 107.5f));
      for (int index = 0; index < this.GUIMenus.Count; ++index)
        this.SetBanner(this.GUIMenus[index]);
    }

    private void LoadIniFile(string iniName)
    {
      try
      {
        this.Config = ScriptSettings.Load(iniName);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: HKH191sBusinessHelper.ini Failed To Load.");
      }
    }

    private void OnShutdown(object sender, EventArgs e)
    {
      if (false)
        return;
      if ((Entity) this.Glass != (Entity) null)
        this.Glass.Delete();
      if ((Entity) this.Bottle != (Entity) null)
        this.Bottle.Delete();
      foreach (Prop prop in this.Champ)
      {
        if ((Entity) prop != (Entity) null)
          prop.Delete();
      }
      if (Game.Player.Character.Model == (Model) PedHash.FreemodeMale01 && this.OldCharacter != (Model) (string) null)
      {
        Model model = new Model(this.OldCharacter.Hash);
        model.Request(500);
        if (model.IsInCdImage && model.IsValid)
        {
          while (!model.IsLoaded)
            Script.Wait(100);
          Function.Call(Hash._0x00A1CADD00108836, (InputArgument) Game.Player, (InputArgument) model.Hash);
          Function.Call(Hash._0x45EEE61580806D63, (InputArgument) Game.Player.Character.Handle);
        }
        model.MarkAsNoLongerNeeded();
        Game.Player.MaxArmor = 400;
        Game.Player.Character.Armor = 0;
        Game.Player.Character.Health = 200;
        Game.Player.Character.MaxHealth = 200;
      }
    }

    public int CheckClothes(int T, int RComp, int RDraw)
    {
      int num = 0;
      if (T == 1)
      {
        if (Function.Call<bool>(Hash._0xE825F6B6CEA7671D, (InputArgument) Game.Player.Character, (InputArgument) RComp, (InputArgument) RDraw))
          num = Function.Call<int>(Hash._0x27561561732A7842, (InputArgument) Game.Player.Character, (InputArgument) RComp);
      }
      if (T == 2)
      {
        if (Function.Call<bool>(Hash._0xE825F6B6CEA7671D, (InputArgument) Game.Player.Character, (InputArgument) RComp, (InputArgument) RDraw))
          num = Function.Call<int>(Hash._0x8F7156A3142A6BAD, (InputArgument) Game.Player.Character, (InputArgument) RComp, (InputArgument) RDraw);
      }
      return num;
    }

    public void WareDrobe()
    {
      List<object> items1 = new List<object>();
      items1.Add((object) "Save");
      items1.Add((object) "Load");
      List<object> Slots = new List<object>();
      Slots.Add((object) "Slot1.ini");
      Slots.Add((object) "Slot2.ini");
      Slots.Add((object) "Slot3.ini");
      Slots.Add((object) "Slot4.ini");
      Slots.Add((object) "Slot5.ini");
      Slots.Add((object) "Slot6.ini");
      Slots.Add((object) "Slot7.ini");
      Slots.Add((object) "Slot8.ini");
      Slots.Add((object) "Slot9.ini");
      Slots.Add((object) "Slot10.ini");
      List<object> objectList = new List<object>()
      {
        (object) WeaponHash.Unarmed,
        (object) WeaponHash.Knife,
        (object) WeaponHash.Nightstick,
        (object) WeaponHash.Hammer,
        (object) WeaponHash.Hatchet,
        (object) WeaponHash.KnuckleDuster,
        (object) WeaponHash.Machete,
        (object) WeaponHash.PoolCue,
        (object) WeaponHash.Wrench,
        (object) WeaponHash.SwitchBlade,
        (object) WeaponHash.GolfClub,
        (object) WeaponHash.Flashlight
      };
      List<object> Colours = new List<object>();
      Colours.Add((object) "Outfit Default");
      Colours.Add((object) "Blue");
      Colours.Add((object) "Green");
      Colours.Add((object) "Red");
      Colours.Add((object) "Orange");
      Colours.Add((object) "Pink");
      Colours.Add((object) "Purple");
      Colours.Add((object) "White");
      Colours.Add((object) "Black");
      List<object> Outfits = new List<object>();
      Outfits.Add((object) "Soldier");
      Outfits.Add((object) "Cloaker");
      Outfits.Add((object) "Hacker");
      Outfits.Add((object) "Juggernaut");
      Outfits.Add((object) "Arena War A");
      Outfits.Add((object) "Arena War B");
      Outfits.Add((object) "Space Marine");
      Outfits.Add((object) "Commando");
      Outfits.Add((object) "Space Suit");
      Outfits.Add((object) "Tron");
      List<object> items2 = new List<object>();
      List<object> Draw = new List<object>();
      List<object> items3 = new List<object>();
      List<object> Tex = new List<object>();
      for (int index = 0; index < 999; ++index)
      {
        Tex.Add((object) index);
        Draw.Add((object) index);
        items3.Add((object) index);
        items2.Add((object) index);
      }
      List<object> items4 = new List<object>();
      items4.Add((object) " 0 FACE");
      items4.Add((object) "1 BEARD");
      items4.Add((object) "2 HAIRCUT");
      items4.Add((object) "3 SHIRT");
      items4.Add((object) "4 PANTS");
      items4.Add((object) "5 Hands / Gloves");
      items4.Add((object) "6 SHOES");
      items4.Add((object) "7 Eyes");
      items4.Add((object) "8 Accessories");
      items4.Add((object) "9 Mission Items/ Tasks");
      items4.Add((object) "10 Decals");
      items4.Add((object) "11 Collars and Inner Shirts");
      UIMenu uiMenu1 = this.Woredrobepool.AddSubMenu(this.WoredrobeMenu, "Change Outfit");
      this.GUIMenus.Add(uiMenu1);
      UIMenuListItem O = new UIMenuListItem("", Outfits, 0);
      uiMenu1.AddItem((UIMenuItem) O);
      O.Description = "While Using this outfit you will not be able to purchase anything due to being the MP male";
      UIMenuListItem C = new UIMenuListItem("Color : ", Colours, 0);
      uiMenu1.AddItem((UIMenuItem) C);
      C.Description = "Use this Colour Whenever possible or use Default";
      UIMenuItem Set = new UIMenuItem("Wear Outfit ");
      uiMenu1.AddItem(Set);
      Set.Description = "~y~ Warning ~w~ Lag is normal while applying outfits, simple alt tab out to avoid crash";
      UIMenuItem Remove = new UIMenuItem("Remove Outift ");
      uiMenu1.AddItem(Remove);
      UIMenu uiMenu2 = this.Woredrobepool.AddSubMenu(this.WoredrobeMenu, "Change Clothes");
      this.GUIMenus.Add(uiMenu2);
      UIMenu uiMenu3 = this.Woredrobepool.AddSubMenu(this.WoredrobeMenu, "Save/Load Outfit");
      this.GUIMenus.Add(uiMenu3);
      UIMenuListItem SVL = new UIMenuListItem("Function ", items1, 0);
      uiMenu3.AddItem((UIMenuItem) SVL);
      UIMenuListItem Sl = new UIMenuListItem("Slot ", Slots, 0);
      uiMenu3.AddItem((UIMenuItem) Sl);
      UIMenuItem Get = new UIMenuItem("Save");
      uiMenu3.AddItem(Get);
      uiMenu3.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item != Get)
          return;
        string str = "";
        if (Game.Player.Character.Model == (Model) PedHash.Franklin)
          str = "scripts//HKH191sBusinessMods//BusinessHelper//Waredrobe//Franklin//";
        if (Game.Player.Character.Model == (Model) PedHash.Michael)
          str = "scripts//HKH191sBusinessMods//BusinessHelper//Waredrobe//Michael//";
        if (Game.Player.Character.Model == (Model) PedHash.Trevor)
          str = "scripts//HKH191sBusinessMods//BusinessHelper//Waredrobe//Trevor//";
        if (Game.Player.Character.Model == (Model) PedHash.FreemodeFemale01 || Game.Player.Character.Model == (Model) PedHash.FreemodeMale01)
          str = "scripts//HKH191sBusinessMods//BusinessHelper//Waredrobe//Mp//";
        if (SVL.Index == 0)
        {
          Ped character = Game.Player.Character;
          Get.Text = "Save";
          // ISSUE: reference to a compiler-generated field
          if (BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__1 == null)
          {
            // ISSUE: reference to a compiler-generated field
            BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__1 = CallSite<Action<CallSite, BusinessAddons, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.InvokeSimpleName | CSharpBinderFlags.ResultDiscarded, "LoadIniFile", (IEnumerable<System.Type>) null, typeof (BusinessAddons), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Action<CallSite, BusinessAddons, object> target = BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__1.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Action<CallSite, BusinessAddons, object>> p1 = BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__1;
          // ISSUE: reference to a compiler-generated field
          if (BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__0 == null)
          {
            // ISSUE: reference to a compiler-generated field
            BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__0 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (BusinessAddons), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj = BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__0.Target((CallSite) BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__0, str, Slots[Sl.Index]);
          target((CallSite) p1, this, obj);
          int num1 = Function.Call<int>(Hash._0x898CC20EA75BACD8, (InputArgument) character, (InputArgument) 0);
          int num2 = Function.Call<int>(Hash._0xE131A28626F81AB2, (InputArgument) character, (InputArgument) 0);
          int num3 = Function.Call<int>(Hash._0xE3DD5F2A84B42281, (InputArgument) character, (InputArgument) 0);
          this.Config.SetValue<int>("-1 HAT", "Hat_Drawable", num1);
          this.Config.SetValue<int>("-1 Hat", "Hat_Tex", num2);
          this.Config.SetValue<int>("-1 Hat", "Hat_Palette", num3);
          int num4 = Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) character, (InputArgument) 0);
          int num5 = Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) character, (InputArgument) 0);
          this.Config.SetValue<int>("0 FACE", "Head_Drawable", num4);
          this.Config.SetValue<int>("0 FACE", "Head_Palette", num5);
          int num6 = Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) character, (InputArgument) 1);
          int num7 = Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) character, (InputArgument) 1);
          this.Config.SetValue<int>("1 BEARD", "BEARD_Drawable", num6);
          this.Config.SetValue<int>("1 BEARD", "BEARD_Palette", num7);
          int num8 = Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) character, (InputArgument) 2);
          int num9 = Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) character, (InputArgument) 2);
          this.Config.SetValue<int>("2 HAIRCUT", "HAIRCUT_Drawable", num8);
          this.Config.SetValue<int>("2 HAIRCUT", "HAIRCUT_Palette", num9);
          int num10 = Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) character, (InputArgument) 3);
          int num11 = Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) character, (InputArgument) 3);
          this.Config.SetValue<int>("3 SHIRT", "SHIRT_Drawable", num10);
          this.Config.SetValue<int>("3 SHIRT", "SHIRT_Palette", num11);
          int num12 = Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) character, (InputArgument) 4);
          int num13 = Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) character, (InputArgument) 4);
          this.Config.SetValue<int>("4 PANTS", "PANTS_Drawable", num12);
          this.Config.SetValue<int>("4 PANTS", "PANTS_Palette", num13);
          int num14 = Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) character, (InputArgument) 5);
          int num15 = Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) character, (InputArgument) 5);
          this.Config.SetValue<int>("5 Hands / Gloves", "Gloves_Drawable", num14);
          this.Config.SetValue<int>("5 Hands / Gloves", "Gloves_Palette", num15);
          int num16 = Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) character, (InputArgument) 6);
          int num17 = Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) character, (InputArgument) 6);
          this.Config.SetValue<int>("6 SHOES", "SHOES_Drawable", num16);
          this.Config.SetValue<int>("6 SHOES", "SHOES_Palette", num17);
          int num18 = Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) character, (InputArgument) 7);
          int num19 = Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) character, (InputArgument) 7);
          this.Config.SetValue<int>("7 Eyes", "Eyes_Drawable", num18);
          this.Config.SetValue<int>("7 Eyes", "Eyes_Palette", num19);
          int num20 = Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) character, (InputArgument) 8);
          int num21 = Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) character, (InputArgument) 8);
          this.Config.SetValue<int>("8 Accessories", "Accessories_Drawable", num20);
          this.Config.SetValue<int>("8 Accessories", "Accessories_Palette", num21);
          int num22 = Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) character, (InputArgument) 9);
          int num23 = Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) character, (InputArgument) 9);
          this.Config.SetValue<int>("9 Mission Items/ Tasks", "Mission_Drawable", num22);
          this.Config.SetValue<int>("9 Mission Items/ Tasks", "Mission_Palette", num23);
          int num24 = Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) character, (InputArgument) 10);
          int num25 = Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) character, (InputArgument) 10);
          this.Config.SetValue<int>("10 Decals", "Decals_Drawable", num24);
          this.Config.SetValue<int>("10 Decals", "Decals_Palette", num25);
          int num26 = Function.Call<int>(Hash._0x67F3780DD425D4FC, (InputArgument) character, (InputArgument) 11);
          int num27 = Function.Call<int>(Hash._0x04A355E041E004E6, (InputArgument) character, (InputArgument) 11);
          this.Config.SetValue<int>("11 Collars and Inner Shirts", "InnerShirts_Drawable", num26);
          this.Config.SetValue<int>("11 Collars and Inner Shirts", "InnerShirts_Palette", num27);
          this.Config.Save();
          UI.Notify("Outfit saved!");
        }
        if (SVL.Index == 1)
        {
          Get.Text = "Load";
          Ped character = Game.Player.Character;
          // ISSUE: reference to a compiler-generated field
          if (BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__3 == null)
          {
            // ISSUE: reference to a compiler-generated field
            BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__3 = CallSite<Action<CallSite, BusinessAddons, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.InvokeSimpleName | CSharpBinderFlags.ResultDiscarded, "LoadIniFile", (IEnumerable<System.Type>) null, typeof (BusinessAddons), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Action<CallSite, BusinessAddons, object> target = BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__3.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Action<CallSite, BusinessAddons, object>> p3 = BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__3;
          // ISSUE: reference to a compiler-generated field
          if (BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__2 == null)
          {
            // ISSUE: reference to a compiler-generated field
            BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__2 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (BusinessAddons), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj = BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__2.Target((CallSite) BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__2, str, Slots[Sl.Index]);
          target((CallSite) p3, this, obj);
          int num1 = this.Config.GetValue<int>("0 FACE", "Head_Drawable", 0);
          int num2 = this.Config.GetValue<int>("0 FACE", "Head_Palette", 0);
          int num3 = this.Config.GetValue<int>("1 BEARD", "BEARD_Drawable", 0);
          int num4 = this.Config.GetValue<int>("1 BEARD", "BEARD_Palette", 0);
          int num5 = this.Config.GetValue<int>("2 HAIRCUT", "HAIRCUT_Drawable", 0);
          int num6 = this.Config.GetValue<int>("2 HAIRCUT", "HAIRCUT_Palette", 0);
          int num7 = this.Config.GetValue<int>("3 SHIRT", "SHIRT_Drawable", 0);
          int num8 = this.Config.GetValue<int>("3 SHIRT", "SHIRT_Palette", 0);
          int num9 = this.Config.GetValue<int>("4 PANTS", "PANTS_Drawable", 0);
          int num10 = this.Config.GetValue<int>("4 PANTS", "PANTS_Palette", 0);
          int num11 = this.Config.GetValue<int>("5 Hands / Gloves", "Gloves_Drawable", 0);
          int num12 = this.Config.GetValue<int>("5 Hands / Gloves", "Gloves_Palette", 0);
          int num13 = this.Config.GetValue<int>("6 SHOES", "SHOES_Drawable", 0);
          int num14 = this.Config.GetValue<int>("6 SHOES", "SHOES_Palette", 0);
          int num15 = this.Config.GetValue<int>("7 Eyes", "Eyes_Drawable", 0);
          int num16 = this.Config.GetValue<int>("7 Eyes", "Eyes_Palette", 0);
          int num17 = this.Config.GetValue<int>("8 Accessories", "Accessories_Drawable", 0);
          int num18 = this.Config.GetValue<int>("8 Accessories", "Accessories_Palette", 0);
          int num19 = this.Config.GetValue<int>("9 Mission Items/ Tasks", "Mission_Drawable", 0);
          int num20 = this.Config.GetValue<int>("9 Mission Items/ Tasks", "Mission_Palette", 0);
          int num21 = this.Config.GetValue<int>("10 Decals", "Decals_Drawable", 0);
          int num22 = this.Config.GetValue<int>("10 Decals", "Decals_Palette", 0);
          int num23 = this.Config.GetValue<int>("11 Collars and Inner Shirts", "InnerShirts_Drawable", 0);
          int num24 = this.Config.GetValue<int>("11 Collars and Inner Shirts", "InnerShirts_Palette", 0);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) num1, (InputArgument) num2, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) num3, (InputArgument) num4, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) num5, (InputArgument) num6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) num7, (InputArgument) num8, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) num9, (InputArgument) num10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) num11, (InputArgument) num12, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) num13, (InputArgument) num14, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) num15, (InputArgument) num16, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) num17, (InputArgument) num18, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) num19, (InputArgument) num20, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) num21, (InputArgument) num22, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) num23, (InputArgument) num24, (InputArgument) 1);
          int num25 = this.Config.GetValue<int>("-1 HAT", "Hat_Drawable", 0);
          int num26 = this.Config.GetValue<int>("-1 Hat", "Hat_Tex", 0);
          int num27 = this.Config.GetValue<int>("-1 Hat", "Hat_Palette", 0);
          if (num25 >= 1)
            Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 0, (InputArgument) num25, (InputArgument) num26, (InputArgument) num27);
          else if (num25 < 1)
            Function.Call(Hash._0xCD8A7537A9B52F06, (InputArgument) Game.Player.Character);
        }
      });
      uiMenu3.OnListChange += (ListChangedEvent) ((sender, item, index) =>
      {
        if (SVL.Index == 0)
          Get.Text = "Save";
        if (SVL.Index != 1)
          return;
        Get.Text = "Load";
      });
      UIMenuListItem Comp1 = new UIMenuListItem("", items4, 0);
      uiMenu2.AddItem((UIMenuItem) Comp1);
      UIMenuListItem Drawable = new UIMenuListItem("Item : ", items2, 0);
      uiMenu2.AddItem((UIMenuItem) Drawable);
      UIMenuListItem Texture = new UIMenuListItem("Texture : ", items3, 0);
      uiMenu2.AddItem((UIMenuItem) Texture);
      uiMenu1.OnItemSelect += (ItemSelectEvent) ((sender, item, index) =>
      {
        if (item == Set)
        {
          this.LoadIniFile("scripts//HKH191sBusinessMods//BusinessHelper//Wardrobe//Weapons.ini");
          foreach (WeaponHash weaponHash in (WeaponHash[]) Enum.GetValues(typeof (WeaponHash)))
          {
            if (Game.Player.Character.Weapons.HasWeapon(weaponHash))
            {
              Game.Player.Character.Weapons.Select(weaponHash, false);
              this.Config.SetValue<WeaponHash>(weaponHash.ToString(), "WeaponName", weaponHash);
              WeaponHash hash = Game.Player.Character.Weapons.Current.Hash;
              this.Liv = Game.Player.Character.Weapons.Current.Tint;
              int num = 0;
              foreach (WeaponComponent component in (WeaponComponent[]) Enum.GetValues(typeof (WeaponComponent)))
              {
                try
                {
                  if (Function.Call<bool>(Hash._0x5CEE3DF569CECAB0, (InputArgument) weaponHash.GetHashCode(), (InputArgument) component.GetHashCode()))
                  {
                    if (Game.Player.Character.Weapons.Current.IsComponentActive(component))
                    {
                      this.Config.SetValue<bool>(weaponHash.ToString(), "HasComponent" + num.ToString(), true);
                      this.Config.SetValue<WeaponComponent>(weaponHash.ToString(), "Component" + num.ToString(), component);
                      ++num;
                      this.Config.Save();
                    }
                    if (!Game.Player.Character.Weapons.Current.IsComponentActive(component))
                    {
                      this.Config.SetValue<bool>(weaponHash.ToString(), "HasComponent" + num.ToString(), false);
                      this.Config.SetValue<WeaponComponent>(weaponHash.ToString(), "Component" + num.ToString(), component);
                      ++num;
                      this.Config.Save();
                    }
                  }
                }
                catch
                {
                  ++num;
                  UI.Notify("~y~ Warning ~w~: Weapon : " + weaponHash.ToString() + " Failed to save");
                }
              }
              this.Config.SetValue<WeaponTint>(weaponHash.ToString(), "Tint", this.Liv);
              this.Config.Save();
            }
          }
          this.ID_O = O.Index;
          // ISSUE: reference to a compiler-generated field
          if (BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__4 == null)
          {
            // ISSUE: reference to a compiler-generated field
            BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__4 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (BusinessAddons)));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          this.ID_C = BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__4.Target((CallSite) BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__4, Colours[C.Index]);
          this.Setoutfit(O.Index);
          UI.Notify("~y~ Warning ~w~ Lag is normal while applying outfits");
          Script.Wait(2000);
          // ISSUE: reference to a compiler-generated field
          if (BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__9 == null)
          {
            // ISSUE: reference to a compiler-generated field
            BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__9 = CallSite<Action<CallSite, System.Type, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Notify", (IEnumerable<System.Type>) null, typeof (BusinessAddons), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Action<CallSite, System.Type, object> target1 = BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__9.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Action<CallSite, System.Type, object>> p9 = BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__9;
          System.Type type = typeof (UI);
          // ISSUE: reference to a compiler-generated field
          if (BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__8 == null)
          {
            // ISSUE: reference to a compiler-generated field
            BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__8 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (BusinessAddons), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, string, object> target2 = BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__8.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, string, object>> p8 = BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__8;
          // ISSUE: reference to a compiler-generated field
          if (BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__7 == null)
          {
            // ISSUE: reference to a compiler-generated field
            BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__7 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (BusinessAddons), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, object, object> target3 = BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__7.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, object, object>> p7 = BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__7;
          // ISSUE: reference to a compiler-generated field
          if (BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__6 == null)
          {
            // ISSUE: reference to a compiler-generated field
            BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__6 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (BusinessAddons), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          Func<CallSite, object, string, object> target4 = BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__6.Target;
          // ISSUE: reference to a compiler-generated field
          CallSite<Func<CallSite, object, string, object>> p6 = BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__6;
          // ISSUE: reference to a compiler-generated field
          if (BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__5 == null)
          {
            // ISSUE: reference to a compiler-generated field
            BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__5 = CallSite<Func<CallSite, string, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Add, typeof (BusinessAddons), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[2]
            {
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
              CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null)
            }));
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          object obj1 = BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__5.Target((CallSite) BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__5, "Player is wearing outfit : ~y~", Outfits[O.Index]);
          object obj2 = target4((CallSite) p6, obj1, "~w~ with colour : ~y~");
          object obj3 = Colours[C.Index];
          object obj4 = target3((CallSite) p7, obj2, obj3);
          object obj5 = target2((CallSite) p8, obj4, "~y~");
          target1((CallSite) p9, type, obj5);
          this.LoadIniFile("scripts//HKH191sBusinessMods//BusinessHelper//Wardrobe//Weapons.ini");
          foreach (WeaponHash weaponHash1 in (WeaponHash[]) Enum.GetValues(typeof (WeaponHash)))
          {
            WeaponHash weaponHash2 = this.Config.GetValue<WeaponHash>(weaponHash1.ToString(), "WeaponName", weaponHash1);
            if (weaponHash1 == weaponHash2)
            {
              Game.Player.Character.Weapons.Give(weaponHash1, 9999, true, true);
              Game.Player.Character.Weapons.Select(weaponHash1, true);
              this.Liv = this.Config.GetValue<WeaponTint>(weaponHash1.ToString(), "Tint", this.Liv);
              WeaponHash hash = Game.Player.Character.Weapons.Current.Hash;
              Game.Player.Character.Weapons.Current.Tint = this.Liv;
              this.Comp = 0;
              foreach (WeaponComponent component in (WeaponComponent[]) Enum.GetValues(typeof (WeaponComponent)))
              {
                try
                {
                  if (Function.Call<bool>(Hash._0x5CEE3DF569CECAB0, (InputArgument) weaponHash1.GetHashCode(), (InputArgument) component.GetHashCode()))
                  {
                    if (this.Config.GetValue<bool>(weaponHash1.ToString(), "HasComponent" + this.Comp.ToString(), true))
                    {
                      Game.Player.Character.Weapons.Current.SetComponent(component, true);
                      ++this.Comp;
                    }
                    else if (!this.Config.GetValue<bool>(weaponHash1.ToString(), "HasComponent" + this.Comp.ToString(), true))
                      ++this.Comp;
                  }
                }
                catch
                {
                  ++this.Comp;
                }
              }
            }
          }
          Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 177293209, (InputArgument) 9999);
          Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 3686625920U, (InputArgument) 9999);
          Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 4208062921U, (InputArgument) 9999);
          Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 2024373456, (InputArgument) 9999);
          Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 961495388, (InputArgument) 9999);
          Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 3219281620U, (InputArgument) 9999);
          Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 1432025498, (InputArgument) 9999);
          Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) -2009644972, (InputArgument) 9999);
          Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) -879347409, (InputArgument) 9999);
          Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) -1768145561, (InputArgument) 9999);
          Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) -2066285827, (InputArgument) 9999);
          Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 1785463520, (InputArgument) 9999);
          Game.Player.Character.Weapons.Give(WeaponHash.Unarmed, 9999, true, true);
        }
        if (item != Remove || !(Game.Player.Character.Model == (Model) PedHash.FreemodeMale01))
          return;
        UI.Notify("taking off Outfit, this may take some time, lag spikes are normal");
        Model model = new Model(this.OldCharacter.Hash);
        model.Request(500);
        if (model.IsInCdImage && model.IsValid)
        {
          while (!model.IsLoaded)
            Script.Wait(100);
          Function.Call(Hash._0x00A1CADD00108836, (InputArgument) Game.Player, (InputArgument) model.Hash);
        }
        model.MarkAsNoLongerNeeded();
        this.LoadIniFile("scripts//HKH191sBusinessMods//BusinessHelper//Waredrobe//Weapons.ini");
        foreach (WeaponHash weaponHash1 in (WeaponHash[]) Enum.GetValues(typeof (WeaponHash)))
        {
          WeaponHash weaponHash2 = this.Config.GetValue<WeaponHash>(weaponHash1.ToString(), "WeaponName", weaponHash1);
          if (weaponHash1 == weaponHash2)
          {
            Game.Player.Character.Weapons.Give(weaponHash1, 9999, true, true);
            Game.Player.Character.Weapons.Select(weaponHash1, true);
            this.Liv = this.Config.GetValue<WeaponTint>(weaponHash1.ToString(), "Tint", this.Liv);
            WeaponHash hash = Game.Player.Character.Weapons.Current.Hash;
            Game.Player.Character.Weapons.Current.Tint = this.Liv;
            this.Comp = 0;
            foreach (WeaponComponent component in (WeaponComponent[]) Enum.GetValues(typeof (WeaponComponent)))
            {
              try
              {
                if (Function.Call<bool>(Hash._0x5CEE3DF569CECAB0, (InputArgument) weaponHash1.GetHashCode(), (InputArgument) component.GetHashCode()))
                {
                  if (this.Config.GetValue<bool>(weaponHash1.ToString(), "HasComponent" + this.Comp.ToString(), true))
                  {
                    Game.Player.Character.Weapons.Current.SetComponent(component, true);
                    ++this.Comp;
                  }
                  else if (!this.Config.GetValue<bool>(weaponHash1.ToString(), "HasComponent" + this.Comp.ToString(), true))
                    ++this.Comp;
                }
              }
              catch
              {
                ++this.Comp;
              }
            }
          }
        }
        Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 177293209, (InputArgument) 9999);
        Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 3686625920U, (InputArgument) 9999);
        Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 4208062921U, (InputArgument) 9999);
        Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 2024373456, (InputArgument) 9999);
        Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 961495388, (InputArgument) 9999);
        Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 3219281620U, (InputArgument) 9999);
        Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 1432025498, (InputArgument) 9999);
        Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) -2009644972, (InputArgument) 9999);
        Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) -879347409, (InputArgument) 9999);
        Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) -1768145561, (InputArgument) 9999);
        Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) -2066285827, (InputArgument) 9999);
        Function.Call(Hash._0x78F0424C34306220, (InputArgument) Game.Player.Character, (InputArgument) 1785463520, (InputArgument) 9999);
        Game.Player.Character.Weapons.Give(WeaponHash.Unarmed, 9999, true, true);
        UI.Notify("Removed Outfit!");
      });
      uiMenu1.OnListChange += (ListChangedEvent) ((sender, item, index) =>
      {
        if (item == O)
          this.ID_O = O.Index;
        if (item != C || C != O)
          return;
        // ISSUE: reference to a compiler-generated field
        if (BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__10 == null)
        {
          // ISSUE: reference to a compiler-generated field
          BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__10 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof (string), typeof (BusinessAddons)));
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.ID_C = BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__10.Target((CallSite) BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__10, Colours[C.Index]);
      });
      uiMenu2.OnListChange += (ListChangedEvent) ((sender, item, index) =>
      {
        try
        {
          if (item == Comp1 && (Entity) Game.Player.Character != (Entity) null)
          {
            if (Function.Call<int>(Hash._0x27561561732A7842, (InputArgument) Game.Player.Character, (InputArgument) Comp1.Index) > Drawable.Index)
            {
              // ISSUE: reference to a compiler-generated field
              if (BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__11 == null)
              {
                // ISSUE: reference to a compiler-generated field
                BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__11 = CallSite<Action<CallSite, System.Type, Hash, Ped, int, object, object, int>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Call", (IEnumerable<System.Type>) null, typeof (BusinessAddons), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[7]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__11.Target((CallSite) BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__11, typeof (Function), Hash._0x262B14F48D29DE80, Game.Player.Character, Comp1.Index, Draw[Drawable.Index], Tex[Texture.Index], 1);
            }
            else
            {
              Drawable.Index = 0;
              // ISSUE: reference to a compiler-generated field
              if (BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__12 == null)
              {
                // ISSUE: reference to a compiler-generated field
                BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__12 = CallSite<Action<CallSite, System.Type, Hash, Ped, int, object, object, int>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Call", (IEnumerable<System.Type>) null, typeof (BusinessAddons), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[7]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__12.Target((CallSite) BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__12, typeof (Function), Hash._0x262B14F48D29DE80, Game.Player.Character, Comp1.Index, Draw[Drawable.Index], Tex[Texture.Index], 1);
            }
            if (Function.Call<int>(Hash._0x8F7156A3142A6BAD, (InputArgument) Game.Player.Character, (InputArgument) Comp1.Index, (InputArgument) Drawable.Index) > Texture.Index)
            {
              // ISSUE: reference to a compiler-generated field
              if (BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__13 == null)
              {
                // ISSUE: reference to a compiler-generated field
                BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__13 = CallSite<Action<CallSite, System.Type, Hash, Ped, int, object, object, int>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Call", (IEnumerable<System.Type>) null, typeof (BusinessAddons), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[7]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__13.Target((CallSite) BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__13, typeof (Function), Hash._0x262B14F48D29DE80, Game.Player.Character, Comp1.Index, Draw[Drawable.Index], Tex[Texture.Index], 1);
            }
            else
            {
              Texture.Index = 0;
              // ISSUE: reference to a compiler-generated field
              if (BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__14 == null)
              {
                // ISSUE: reference to a compiler-generated field
                BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__14 = CallSite<Action<CallSite, System.Type, Hash, Ped, int, object, object, int>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Call", (IEnumerable<System.Type>) null, typeof (BusinessAddons), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[7]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__14.Target((CallSite) BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__14, typeof (Function), Hash._0x262B14F48D29DE80, Game.Player.Character, Comp1.Index, Draw[Drawable.Index], Tex[Texture.Index], 1);
            }
          }
          if (item == Drawable && (Entity) Game.Player.Character != (Entity) null)
          {
            if (Function.Call<int>(Hash._0x27561561732A7842, (InputArgument) Game.Player.Character, (InputArgument) Comp1.Index) > Drawable.Index)
            {
              // ISSUE: reference to a compiler-generated field
              if (BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__15 == null)
              {
                // ISSUE: reference to a compiler-generated field
                BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__15 = CallSite<Action<CallSite, System.Type, Hash, Ped, int, object, object, int>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Call", (IEnumerable<System.Type>) null, typeof (BusinessAddons), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[7]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__15.Target((CallSite) BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__15, typeof (Function), Hash._0x262B14F48D29DE80, Game.Player.Character, Comp1.Index, Draw[Drawable.Index], Tex[Texture.Index], 1);
            }
            else
            {
              Drawable.Index = 0;
              // ISSUE: reference to a compiler-generated field
              if (BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__16 == null)
              {
                // ISSUE: reference to a compiler-generated field
                BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__16 = CallSite<Action<CallSite, System.Type, Hash, Ped, int, object, object, int>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Call", (IEnumerable<System.Type>) null, typeof (BusinessAddons), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[7]
                {
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                  CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
                }));
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__16.Target((CallSite) BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__16, typeof (Function), Hash._0x262B14F48D29DE80, Game.Player.Character, Comp1.Index, Draw[Drawable.Index], Tex[Texture.Index], 1);
            }
          }
          if (item != Texture || !((Entity) Game.Player.Character != (Entity) null))
            return;
          if (Function.Call<int>(Hash._0x8F7156A3142A6BAD, (InputArgument) Game.Player.Character, (InputArgument) Comp1.Index, (InputArgument) Drawable.Index) > Texture.Index)
          {
            // ISSUE: reference to a compiler-generated field
            if (BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__17 == null)
            {
              // ISSUE: reference to a compiler-generated field
              BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__17 = CallSite<Action<CallSite, System.Type, Hash, Ped, int, object, object, int>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Call", (IEnumerable<System.Type>) null, typeof (BusinessAddons), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[7]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__17.Target((CallSite) BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__17, typeof (Function), Hash._0x262B14F48D29DE80, Game.Player.Character, Comp1.Index, Draw[Drawable.Index], Tex[Texture.Index], 1);
          }
          else
          {
            Texture.Index = 0;
            // ISSUE: reference to a compiler-generated field
            if (BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__18 == null)
            {
              // ISSUE: reference to a compiler-generated field
              BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__18 = CallSite<Action<CallSite, System.Type, Hash, Ped, int, object, object, int>>.Create(Binder.InvokeMember(CSharpBinderFlags.ResultDiscarded, "Call", (IEnumerable<System.Type>) null, typeof (BusinessAddons), (IEnumerable<CSharpArgumentInfo>) new CSharpArgumentInfo[7]
              {
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.IsStaticType, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, (string) null),
                CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, (string) null)
              }));
            }
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__18.Target((CallSite) BusinessAddons.\u003C\u003Eo__85.\u003C\u003Ep__18, typeof (Function), Hash._0x262B14F48D29DE80, Game.Player.Character, Comp1.Index, Draw[Drawable.Index], Tex[Texture.Index], 1);
          }
        }
        catch
        {
        }
      });
    }

    public void Setoutfit(int i)
    {
      Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) Game.Player.Character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
      if (Game.Player.Character.Model != (Model) PedHash.FreemodeMale01)
        this.OldCharacter = Game.Player.Character.Model;
      Function.Call(Hash._0xAA74EC0CB0AAEA2C, (InputArgument) Game.Player.Character, (InputArgument) 1.0);
      Function.Call(Hash._0x20510814175EA477, (InputArgument) Game.Player.Character);
      Model model = new Model(PedHash.FreemodeMale01);
      model.Request(500);
      if (model.IsInCdImage && model.IsValid)
      {
        while (!model.IsLoaded)
          Script.Wait(100);
        Function.Call(Hash._0x00A1CADD00108836, (InputArgument) Game.Player, (InputArgument) model.Hash);
      }
      model.MarkAsNoLongerNeeded();
      Ped character = Game.Player.Character;
      Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) -1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 17);
      bool flag = false;
      string idC = this.ID_C;
      if (i == 0)
      {
        if (idC.Equals("Outfit Default"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 125, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 17, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 34, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 69, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 128, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Green"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 125, (InputArgument) 4, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 17, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 34, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 69, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 128, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Purple"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 125, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 17, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 34, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 69, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 128, (InputArgument) 3, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Pink"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 125, (InputArgument) 7, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 17, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 34, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 69, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 128, (InputArgument) 4, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Orange"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 125, (InputArgument) 5, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 17, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 34, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 69, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 128, (InputArgument) 2, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (!flag)
        {
          if (!flag && !idC.Equals("Outfit Default"))
            UI.Notify("~y~Warning~w~ this Outfit did not have the specified color, setting to default, color chosen : " + idC);
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 125, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 17, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 34, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 69, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 128, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
      }
      if (i == 1)
      {
        if (idC.Equals("Outfit Default"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 89, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 17, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 34, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 69, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 55, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 54, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Black"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 89, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 17, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 34, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 69, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 55, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 54, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
      }
      if (i == 2 && idC.Equals("Outfit Default"))
      {
        if (!flag && !idC.Equals("Outfit Default"))
          UI.Notify("~y~Warning~w~ this Outfit did not have the specified color, setting to default, color chosen : " + idC);
        flag = true;
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        int num = new System.Random().Next(1, 100);
        if (num <= 25)
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 38, (InputArgument) 0, (InputArgument) 1);
        if (num > 25 && num <= 50)
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 112, (InputArgument) 0, (InputArgument) 1);
        if (num > 50 && num <= 75)
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 46, (InputArgument) 0, (InputArgument) 1);
        if (num > 75)
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 104, (InputArgument) 25, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 17, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 34, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 69, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 125, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 68, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      }
      if (i == 3)
      {
        if (idC.Equals("Blue"))
        {
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 1, (InputArgument) 91, (InputArgument) 3, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 3, (InputArgument) 46, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 4, (InputArgument) 84, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 6, (InputArgument) 10, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 8, (InputArgument) 97, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 11, (InputArgument) 186, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Green"))
        {
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 1, (InputArgument) 91, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 3, (InputArgument) 46, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 4, (InputArgument) 84, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 6, (InputArgument) 10, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 8, (InputArgument) 97, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 11, (InputArgument) 186, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Red"))
        {
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 1, (InputArgument) 91, (InputArgument) 5, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 3, (InputArgument) 46, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 4, (InputArgument) 84, (InputArgument) 5, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 6, (InputArgument) 10, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 8, (InputArgument) 97, (InputArgument) 5, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 11, (InputArgument) 186, (InputArgument) 5, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Orange"))
        {
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 1, (InputArgument) 91, (InputArgument) 2, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 3, (InputArgument) 46, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 4, (InputArgument) 84, (InputArgument) 2, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 6, (InputArgument) 10, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 8, (InputArgument) 97, (InputArgument) 2, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 11, (InputArgument) 186, (InputArgument) 2, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Purple"))
        {
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 1, (InputArgument) 91, (InputArgument) 4, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 3, (InputArgument) 46, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 4, (InputArgument) 84, (InputArgument) 3, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 6, (InputArgument) 10, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 8, (InputArgument) 97, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 11, (InputArgument) 186, (InputArgument) 3, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Pink"))
        {
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 1, (InputArgument) 91, (InputArgument) 4, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 3, (InputArgument) 46, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 4, (InputArgument) 84, (InputArgument) 4, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 6, (InputArgument) 10, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 8, (InputArgument) 97, (InputArgument) 4, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 11, (InputArgument) 186, (InputArgument) 4, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("White"))
        {
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 1, (InputArgument) 91, (InputArgument) 9, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 3, (InputArgument) 46, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 4, (InputArgument) 84, (InputArgument) 9, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 6, (InputArgument) 10, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 8, (InputArgument) 97, (InputArgument) 9, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 11, (InputArgument) 186, (InputArgument) 9, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Black") || idC.Equals("Outfit Default"))
        {
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 1, (InputArgument) 91, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 3, (InputArgument) 46, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 4, (InputArgument) 84, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 6, (InputArgument) 10, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 8, (InputArgument) 97, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 11, (InputArgument) 186, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
      }
      if (i == 4)
      {
        if (idC.Equals("Black"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 142, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 107, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 84, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 275, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("White"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 142, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 107, (InputArgument) 9, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 84, (InputArgument) 4, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 275, (InputArgument) 7, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Green"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 142, (InputArgument) 7, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 107, (InputArgument) 12, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 84, (InputArgument) 2, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 275, (InputArgument) 8, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Orange"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 142, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 107, (InputArgument) 13, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 84, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 275, (InputArgument) 9, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Purple"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 142, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 107, (InputArgument) 14, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 84, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 275, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Pink"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 142, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 107, (InputArgument) 15, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 84, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 275, (InputArgument) 11, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Red"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 142, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 107, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 84, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 275, (InputArgument) 14, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Outfit Default") || !flag)
        {
          if (!flag && !idC.Equals("Outfit Default"))
            UI.Notify("~y~Warning~w~ this Outfit did not have the specified color, setting to default, color chosen : " + idC);
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 142, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 107, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 84, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 275, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
      }
      if (i == 5)
      {
        if (idC.Equals("Black"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 142, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 107, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 84, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 276, (InputArgument) 5, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("White"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 142, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 107, (InputArgument) 9, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 84, (InputArgument) 4, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 276, (InputArgument) 2, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Green"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 142, (InputArgument) 7, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 107, (InputArgument) 12, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 84, (InputArgument) 2, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 276, (InputArgument) 9, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Orange"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 142, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 107, (InputArgument) 13, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 84, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 276, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Purple"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 142, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 107, (InputArgument) 14, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 84, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 276, (InputArgument) 11, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Pink"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 142, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 107, (InputArgument) 15, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 84, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 276, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Red"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 142, (InputArgument) 6, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 107, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 84, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 276, (InputArgument) 4, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Outfit Default") || !flag)
        {
          if (!flag && !idC.Equals("Outfit Default"))
            UI.Notify("~y~Warning~w~ this Outfit did not have the specified color, setting to default, color chosen : " + idC);
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 142, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 107, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 84, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 3, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 276, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
      }
      if (i == 6)
      {
        if (idC.Equals("Green"))
        {
          flag = true;
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 0, (InputArgument) 134, (InputArgument) 0, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 147, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 167, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 113, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 90, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 2, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 286, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 1, (InputArgument) 0, (InputArgument) 135, (InputArgument) 0);
        }
        if (idC.Equals("Outfit Default") || !flag)
        {
          if (!flag && !idC.Equals("Outfit Default"))
            UI.Notify("~y~Warning~w~ this Outfit did not have the specified color, setting to default, color chosen : " + idC);
          flag = true;
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 0, (InputArgument) 134, (InputArgument) 0, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 147, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 167, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 113, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 90, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 2, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 286, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 1, (InputArgument) 0, (InputArgument) 135, (InputArgument) 0);
        }
      }
      if (i == 7)
      {
        if (idC.Equals("Outfit Default"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 0, (InputArgument) 115, (InputArgument) 0, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 17, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 34, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 69, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 128, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Green"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 0, (InputArgument) 115, (InputArgument) 4, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 17, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 34, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 69, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 128, (InputArgument) 1, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Purple"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 0, (InputArgument) 115, (InputArgument) 6, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 17, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 34, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 69, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 128, (InputArgument) 3, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Pink"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 0, (InputArgument) 115, (InputArgument) 7, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 17, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 34, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 69, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 128, (InputArgument) 4, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Orange"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 0, (InputArgument) 115, (InputArgument) 5, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 17, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 34, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 69, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 128, (InputArgument) 2, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (!flag)
        {
          if (!flag && !idC.Equals("Outfit Default"))
            UI.Notify("~y~Warning~w~ this Outfit did not have the specified color, setting to default, color chosen : " + idC);
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 0, (InputArgument) 115, (InputArgument) 0, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 17, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 34, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 69, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 128, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
      }
      if (i == 8)
      {
        if (idC.Equals("Green"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 0, (InputArgument) 133, (InputArgument) 8, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 108, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 166, (InputArgument) 8, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 110, (InputArgument) 8, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 88, (InputArgument) 8, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 2, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 283, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Purple"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 0, (InputArgument) 133, (InputArgument) 10, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 108, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 166, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 110, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 88, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 2, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 283, (InputArgument) 10, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Pink"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 0, (InputArgument) 133, (InputArgument) 11, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 108, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 166, (InputArgument) 11, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 110, (InputArgument) 11, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 88, (InputArgument) 11, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 2, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 283, (InputArgument) 11, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Orange"))
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 0, (InputArgument) 133, (InputArgument) 9, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 108, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 166, (InputArgument) 9, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 110, (InputArgument) 9, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 88, (InputArgument) 9, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 2, (InputArgument) 9, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 283, (InputArgument) 9, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (!flag)
        {
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 0, (InputArgument) 133, (InputArgument) 0, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 108, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 166, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 110, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 88, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 2, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 283, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
        if (idC.Equals("Outfit Default") || !flag)
        {
          if (!flag && !idC.Equals("Outfit Default"))
            UI.Notify("~y~Warning~w~ this Outfit did not have the specified color, setting to default, color chosen : " + idC);
          flag = true;
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 0, (InputArgument) 133, (InputArgument) 0, (InputArgument) 17);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 108, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 166, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 110, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 88, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 2, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 283, (InputArgument) 0, (InputArgument) 1);
          Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        }
      }
      if (i != 9)
        return;
      if (idC.Equals("Outfit Default"))
      {
        flag = true;
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 0, (InputArgument) 91, (InputArgument) 0, (InputArgument) 17);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 77, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 55, (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 178, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      }
      if (idC.Equals("Green"))
      {
        flag = true;
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 0, (InputArgument) 91, (InputArgument) 1, (InputArgument) 17);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 77, (InputArgument) 1, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 55, (InputArgument) 1, (InputArgument) 0);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 178, (InputArgument) 1, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      }
      if (idC.Equals("White"))
      {
        flag = true;
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 0, (InputArgument) 91, (InputArgument) 9, (InputArgument) 17);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 77, (InputArgument) 7, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 55, (InputArgument) 7, (InputArgument) 0);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 178, (InputArgument) 7, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      }
      if (idC.Equals("Blue"))
      {
        flag = true;
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 0, (InputArgument) 91, (InputArgument) 3, (InputArgument) 17);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 77, (InputArgument) 3, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 55, (InputArgument) 3, (InputArgument) 0);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 178, (InputArgument) 3, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      }
      if (idC.Equals("Black"))
      {
        flag = true;
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 0, (InputArgument) 91, (InputArgument) 10, (InputArgument) 17);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 77, (InputArgument) 10, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 55, (InputArgument) 10, (InputArgument) 0);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 178, (InputArgument) 10, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      }
      if (!flag)
      {
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x93376B65A266EB5F, (InputArgument) character, (InputArgument) 0, (InputArgument) 91, (InputArgument) 0, (InputArgument) 17);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 1, (InputArgument) 0, (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 2, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 3, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 4, (InputArgument) 77, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 5, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 6, (InputArgument) 55, (InputArgument) 0, (InputArgument) 0);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 7, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 8, (InputArgument) 130, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 9, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 10, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 11, (InputArgument) 178, (InputArgument) 0, (InputArgument) 1);
        Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) character, (InputArgument) 12, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
      }
    }

    private void DisplayHelpTextThisFrame(string text)
    {
      Function.Call(Hash._0x8509B634FBE7DA11, (InputArgument) "STRING");
      Function.Call(Hash._0x6C188BE134E074AA, (InputArgument) text);
      Function.Call(Hash._0x238FFE5C7B0498A6, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1, (InputArgument) -1);
    }

    public float ReturnRot(Vector3 V)
    {
      float num = 0.0f;
      for (int index = 0; index < this.SeatPos.Count; ++index)
      {
        if (V == this.SeatPos[index])
          num = this.Seatrot[index];
      }
      return num;
    }

    private void OnKeyDown(object sender, KeyEventArgs e)
    {
    }

    public void OnTick(object sender, EventArgs e)
    {
      if (this.IsDrinking)
      {
        if (this.BottleType == 1)
          this.WineMethod();
        else
          this.WhiskeyMethod();
        if (this.Effect == 6)
          Game.Player.Character.Health += 10;
        if (this.Effect == 5)
          Game.Player.Character.Health += 5;
        if (this.Effect == 4)
          Game.Player.Character.Health += 2;
        if (this.Effect == 3)
        {
          for (int index = 0; index <= 1000; ++index)
          {
            System.Random random = new System.Random();
            if ((index == 250 || index == 500 || index == 750) && Game.Player.Character.Health > 25)
              Game.Player.Character.Health -= 10;
            if (index == 1000)
              this.Effect = -1;
          }
        }
        if (this.Effect == 2)
          Game.Player.Character.HasGravity = false;
        if (this.Effect != 1)
          ;
        if (this.Effect != 0)
          ;
        if (this.Effect != -1)
          ;
        if ((double) this.DrunkLevel >= 0.0)
          this.DrunkLevel -= 0.01f;
        if ((double) this.DrunkLevel <= 0.0)
        {
          Function.Call(Hash._0x0F07E7745A236711);
          Function.Call(Hash._0x3C8938D7D872211E);
          Function.Call(Hash._0x2C933ABF17A1DF41, (InputArgument) "default");
          if (Function.Call<int>(Hash._0xFDF3D97C674AFB66) != -1)
            Function.Call(Hash._0x0F07E7745A236711);
          BusinessAddons.WineTaskScriptStatus = 0;
          BusinessAddons.WhiskeyTaskScriptStatus = 0;
          this.IsDrinking = false;
          if ((Entity) this.Glass != (Entity) null)
            this.Glass.Delete();
          if ((Entity) this.Bottle != (Entity) null)
            this.Bottle.Delete();
          Function.Call(Hash._0xD75ACCF5E0FB5367, (InputArgument) Game.Player.Character, (InputArgument) false, (InputArgument) -1, (InputArgument) 0);
          Function.Call(Hash._0xAA74EC0CB0AAEA2C, (InputArgument) Game.Player.Character, (InputArgument) 1.0);
        }
        if ((double) this.DrunkLevel >= 8.0 && (double) this.DrunkLevel < 16.0)
        {
          Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@MODERATEDRUNK");
          Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
          Function.Call(Hash._0x2C933ABF17A1DF41, (InputArgument) "default");
          if (Function.Call<int>(Hash._0xFDF3D97C674AFB66) != -1)
            Function.Call(Hash._0x0F07E7745A236711);
          Function.Call(Hash._0x2C933ABF17A1DF41, (InputArgument) "Drunk");
          Function.Call(Hash._0x82E7FFCD5B2326B3, (InputArgument) (this.DrunkLevel / 100f * 4f));
          Function.Call(Hash._0x3BCF567485E1971C, (InputArgument) "Drunk", (InputArgument) (this.DrunkLevel / 100f * 4f));
        }
        if ((double) this.DrunkLevel >= 16.0 && (double) this.DrunkLevel < 24.0)
        {
          Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@SLIGHTLYDRUNK");
          Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
          if (Function.Call<int>(Hash._0xFDF3D97C674AFB66) != -1)
            Function.Call(Hash._0x0F07E7745A236711);
          Function.Call(Hash._0x2C933ABF17A1DF41, (InputArgument) "Drunk");
          Function.Call(Hash._0x82E7FFCD5B2326B3, (InputArgument) (this.DrunkLevel / 100f * 4f));
          Function.Call(Hash._0x3BCF567485E1971C, (InputArgument) "Drunk", (InputArgument) (this.DrunkLevel / 100f * 4f));
        }
        if ((double) this.DrunkLevel >= 24.0 && (double) this.DrunkLevel < 36.0)
        {
          Function.Call(Hash._0x6EA47DAE7FAD0EED, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK");
          Function.Call(Hash._0xAF8A94EDE7712BEF, (InputArgument) Game.Player.Character, (InputArgument) "MOVE_M@DRUNK@VERYDRUNK", (InputArgument) 1f);
          if (Function.Call<int>(Hash._0xFDF3D97C674AFB66) != -1)
            Function.Call(Hash._0x0F07E7745A236711);
          Function.Call(Hash._0x2C933ABF17A1DF41, (InputArgument) "Drunk");
          Function.Call(Hash._0x82E7FFCD5B2326B3, (InputArgument) (this.DrunkLevel / 100f * 4f));
          Function.Call(Hash._0x3BCF567485E1971C, (InputArgument) "Drunk", (InputArgument) (this.DrunkLevel / 100f * 4f));
        }
        ++this.DrinkTimer;
        if (this.DrinkTimer < 100)
          ;
      }
      if (this.RightBeds.Count > 0)
      {
        foreach (Bed rightBed in this.RightBeds)
        {
          if ((double) World.GetDistance(Game.Player.Character.Position, rightBed.Pos) < 3.0)
          {
            this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to Sleep");
            if (Game.IsControlJustPressed(2, GTA.Control.Context))
            {
              Game.Player.Character.Position = rightBed.Pos;
              Game.Player.Character.Heading = rightBed.Hed;
              string dict1 = "anim@mp_bedmid@right_var_01";
              string str1 = "f_getin_r_bighouse";
              BusinessAddons.LoadDict(dict1);
              Game.Player.Character.Position = Game.Player.Character.GetOffsetInWorldCoords(new Vector3(0.0f, 0.5f, 0.0f));
              Vector3 position = Game.Player.Character.Position;
              Script.Wait(100);
              this.Scene1 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) Game.Player.Character.Position.X, (InputArgument) Game.Player.Character.Position.Y, (InputArgument) (Game.Player.Character.Position.Z - 0.9f), (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) Game.Player.Character.Heading, (InputArgument) 2);
              Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) BusinessAddons.LoadDict(dict1), (InputArgument) str1, (InputArgument) 3000.0, (InputArgument) -2.0, (InputArgument) 128, (InputArgument) 0, (InputArgument) 1148846080, (InputArgument) 0);
              Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) this.Scene1, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) this.Scene1));
              Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) this.Scene1, (InputArgument) 0.0);
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) str1, (InputArgument) BusinessAddons.LoadDict(dict1), (InputArgument) 3000.0, (InputArgument) -2f, (InputArgument) -2f, (InputArgument) (Game.Player.Character.Heading + 30f), (InputArgument) 1148846080, (InputArgument) 0);
              Script.Wait(15000);
              string dict2 = "anim@mp_bedmid@right_var_01";
              string str2 = "f_sleep_r_loop_bighouse";
              BusinessAddons.LoadDict(dict2);
              Game.ShowSaveMenu();
              Script.Wait(100);
              this.Scene1 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) (position.Z - 1.9f), (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) (Game.Player.Character.Heading - 135f), (InputArgument) 2);
              Game.ShowSaveMenu();
              Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) BusinessAddons.LoadDict(dict2), (InputArgument) str2, (InputArgument) 3000.0, (InputArgument) -2.0, (InputArgument) 128, (InputArgument) 0, (InputArgument) 1148846080, (InputArgument) 0);
              Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) this.Scene1, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) this.Scene1));
              Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) this.Scene1, (InputArgument) 0.0);
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) str2, (InputArgument) BusinessAddons.LoadDict(dict2), (InputArgument) 3000.0, (InputArgument) -2f, (InputArgument) -2f, (InputArgument) Game.Player.Character.Heading, (InputArgument) 1148846080, (InputArgument) 0);
              Script.Wait(4000);
              string dict3 = "anim@mp_bedmid@right_var_01";
              string str3 = "f_getout_r_bighouse";
              BusinessAddons.LoadDict(dict3);
              Script.Wait(100);
              this.Scene1 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) (position.Z - 1.9f), (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) (Game.Player.Character.Heading - 135f), (InputArgument) 2);
              Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) BusinessAddons.LoadDict(dict3), (InputArgument) str3, (InputArgument) 3000.0, (InputArgument) -2.0, (InputArgument) 128, (InputArgument) 0, (InputArgument) 1148846080, (InputArgument) 0);
              Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) this.Scene1, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) this.Scene1));
              Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) this.Scene1, (InputArgument) 0.0);
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) str3, (InputArgument) BusinessAddons.LoadDict(dict3), (InputArgument) 3000.0, (InputArgument) -2f, (InputArgument) -2f, (InputArgument) Game.Player.Character.Heading, (InputArgument) 1148846080, (InputArgument) 0);
              Script.Wait(4000);
              Game.Player.Character.Task.ClearAll();
            }
          }
        }
      }
      if (this.LeftBeds.Count > 0)
      {
        foreach (Bed leftBed in this.LeftBeds)
        {
          if ((double) World.GetDistance(Game.Player.Character.Position, leftBed.Pos) < 3.0)
          {
            this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to Sleep");
            if (Game.IsControlJustPressed(2, GTA.Control.Context))
            {
              Game.Player.Character.Position = leftBed.Pos;
              Game.Player.Character.Heading = leftBed.Hed;
              string dict1 = "mp_bedmid";
              string str1 = "f_getin_l_bighouse";
              BusinessAddons.LoadDict(dict1);
              Game.Player.Character.Position = Game.Player.Character.GetOffsetInWorldCoords(new Vector3(0.0f, 2.2f, 0.0f));
              Vector3 position = Game.Player.Character.Position;
              Script.Wait(100);
              this.Scene1 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) Game.Player.Character.Position.X, (InputArgument) Game.Player.Character.Position.Y, (InputArgument) (Game.Player.Character.Position.Z - 1.5f), (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) Game.Player.Character.Heading, (InputArgument) 2);
              Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) BusinessAddons.LoadDict(dict1), (InputArgument) str1, (InputArgument) 3000.0, (InputArgument) -2.0, (InputArgument) 128, (InputArgument) 0, (InputArgument) 1148846080, (InputArgument) 0);
              Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) this.Scene1, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) this.Scene1));
              Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) this.Scene1, (InputArgument) 0.0);
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) str1, (InputArgument) BusinessAddons.LoadDict(dict1), (InputArgument) 3000.0, (InputArgument) -2f, (InputArgument) -2f, (InputArgument) Game.Player.Character.Heading, (InputArgument) 1148846080, (InputArgument) 0);
              Script.Wait(4000);
              string dict2 = "mp_bedmid";
              string str2 = "f_sleep_l_loop_bighouse";
              BusinessAddons.LoadDict(dict2);
              Game.ShowSaveMenu();
              Script.Wait(100);
              this.Scene1 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) (position.Z - 1.55f), (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) (Game.Player.Character.Heading + 90f), (InputArgument) 2);
              Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) BusinessAddons.LoadDict(dict2), (InputArgument) str2, (InputArgument) 3000.0, (InputArgument) -2.0, (InputArgument) 128, (InputArgument) 0, (InputArgument) 1148846080, (InputArgument) 0);
              Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) this.Scene1, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) this.Scene1));
              Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) this.Scene1, (InputArgument) 0.0);
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) str2, (InputArgument) BusinessAddons.LoadDict(dict2), (InputArgument) 3000.0, (InputArgument) -2f, (InputArgument) -2f, (InputArgument) Game.Player.Character.Heading, (InputArgument) 1148846080, (InputArgument) 0);
              Script.Wait(4000);
              string dict3 = "mp_bedmid";
              string str3 = "f_getout_l_bighouse";
              BusinessAddons.LoadDict(dict3);
              Script.Wait(100);
              this.Scene1 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) (position.Z - 1.5f), (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) (Game.Player.Character.Heading + 90f), (InputArgument) 2);
              Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) BusinessAddons.LoadDict(dict3), (InputArgument) str3, (InputArgument) 3000.0, (InputArgument) -2.0, (InputArgument) 128, (InputArgument) 0, (InputArgument) 1148846080, (InputArgument) 0);
              Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) this.Scene1, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) this.Scene1));
              Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) this.Scene1, (InputArgument) 0.0);
              Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) str3, (InputArgument) BusinessAddons.LoadDict(dict3), (InputArgument) 3000.0, (InputArgument) -2f, (InputArgument) -2f, (InputArgument) Game.Player.Character.Heading, (InputArgument) 1148846080, (InputArgument) 0);
              Script.Wait(4000);
              Game.Player.Character.Task.ClearAll();
            }
          }
        }
      }
      if (this.gotCurrent)
      {
        if ((double) World.GetDistance(Game.Player.Character.Position, this.CurrentPos) < 2.0)
        {
          if (!this.isSeated)
            this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to Sit");
          if (this.isSeated)
            this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to Get Up");
          if (Game.IsControlJustPressed(2, GTA.Control.Context))
          {
            if (!this.isSeated)
            {
              int num = new System.Random().Next(0, 5);
              if (num == 0)
                this.SeatDict = "anim@amb@office@seating@male@var_a@base@";
              if (num == 1)
                this.SeatDict = "anim@amb@office@seating@male@var_b@base@";
              if (num == 2)
                this.SeatDict = "anim@amb@office@seating@male@var_c@base@";
              if (num == 3)
                this.SeatDict = "anim@amb@office@seating@male@var_d@base@";
              if (num == 4)
                this.SeatDict = "anim@amb@office@seating@male@var_e@base@";
              Script.Wait(100);
              BusinessAddons.LoadDict(this.SeatDict);
              if (Function.Call<bool>(Hash._0xD031A9162D01088C, (InputArgument) this.SeatDict))
              {
                Game.Player.Character.Heading = this.ReturnRot(this.CurrentPos);
                this.CurrentPos = new Vector3(this.CurrentPos.X, this.CurrentPos.Y, this.CurrentPos.Z - 1f);
                Game.Player.Character.Position = this.CurrentPos;
                this.isSeated = true;
                this.Scene1 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) Game.Player.Character.Position.X, (InputArgument) Game.Player.Character.Position.Y, (InputArgument) (Game.Player.Character.Position.Z - 1.4f), (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) (Game.Player.Character.Rotation.Z - 180f), (InputArgument) 2);
                Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) BusinessAddons.LoadDict(this.SeatDict), (InputArgument) "enter", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) this.Scene1, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) this.Scene1));
                Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) "enter", (InputArgument) BusinessAddons.LoadDict(this.SeatDict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
              }
            }
            else if (this.isSeated)
            {
              Script.Wait(100);
              BusinessAddons.LoadDict(this.SeatDict);
              if (Function.Call<bool>(Hash._0xD031A9162D01088C, (InputArgument) this.SeatDict))
              {
                this.CurrentPos = new Vector3(this.CurrentPos.X, this.CurrentPos.Y, this.CurrentPos.Z + 1f);
                this.isSeated = false;
                this.Scene1 = Function.Call<int>(Hash._0x8C18E0F9080ADD73, (InputArgument) Game.Player.Character.Position.X, (InputArgument) Game.Player.Character.Position.Y, (InputArgument) (Game.Player.Character.Position.Z - 0.6f), (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) (Game.Player.Character.Rotation.Z - 180f), (InputArgument) 2);
                Function.Call(Hash._0xEEA929141F699854, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) BusinessAddons.LoadDict(this.SeatDict), (InputArgument) "exit", (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                Function.Call(Hash._0x734292F4F0ABF6D0, (InputArgument) this.Scene1, (InputArgument) Function.Call<int>(Hash._0xE4A310B1D7FA73CC, (InputArgument) this.Scene1));
                Function.Call(Hash._0xC77720A12FE14A86, (InputArgument) Game.Player.Character, (InputArgument) this.Scene1, (InputArgument) "exit", (InputArgument) BusinessAddons.LoadDict(this.SeatDict), (InputArgument) 16f, (InputArgument) -16f, (InputArgument) 0, (InputArgument) 1148846080);
                Script.Wait(3000);
                Game.Player.Character.Task.ClearAll();
                Game.Player.Character.FreezePosition = false;
                this.SwitchScene = false;
              }
            }
          }
        }
        if ((double) World.GetDistance(Game.Player.Character.Position, this.CurrentPos) > 2.0)
        {
          this.DisanceFloat.Clear();
          this.gotCurrent = false;
        }
      }
      if (!this.gotCurrent)
      {
        foreach (Vector3 seatPo in this.SeatPos)
        {
          if ((double) World.GetDistance(Game.Player.Character.Position, seatPo) < 1.25)
            this.DisanceFloat.Add(World.GetDistance(Game.Player.Character.Position, seatPo));
        }
        if (this.DisanceFloat.Count > 0)
        {
          this.DisanceFloat.Sort();
          foreach (Vector3 seatPo in this.SeatPos)
          {
            if ((double) World.GetDistance(Game.Player.Character.Position, seatPo) == (double) this.DisanceFloat[0])
            {
              this.gotCurrent = true;
              this.CurrentPos = seatPo;
            }
          }
        }
      }
      this.OnKeyDown();
      if (this.Woredrobepool != null && this.Woredrobepool.IsAnyMenuOpen())
        this.Woredrobepool.ProcessMenus();
      if (this.DrinksPool != null && this.DrinksPool.IsAnyMenuOpen())
        this.DrinksPool.ProcessMenus();
      foreach (Vector3 drinkPo in this.DrinkPos)
      {
        if ((double) World.GetDistance(Game.Player.Character.Position, drinkPo) < 1.5)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to grab a drink");
        if ((double) World.GetDistance(Game.Player.Character.Position, drinkPo) < 1.5 && Game.IsControlJustPressed(2, GTA.Control.Context))
          this.DrinksMenu.Visible = !this.DrinksMenu.Visible;
      }
      foreach (Vector3 radioPo in this.RadioPos)
      {
        if ((double) World.GetDistance(Game.Player.Character.Position, radioPo) < 80.0)
          World.DrawMarker(MarkerType.VerticalCylinder, radioPo, Vector3.Zero, Vector3.Zero, new Vector3(0.4f, 0.4f, 0.3f), Color.Yellow);
        if ((double) World.GetDistance(Game.Player.Character.Position, radioPo) < 1.5)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to turn Radio On/Off, ~INPUT_COVER~ to change station");
        if ((double) World.GetDistance(Game.Player.Character.Position, radioPo) < 1.5 && Game.IsControlJustPressed(2, GTA.Control.Context))
        {
          if (this.RadioOn)
          {
            this.RadioOn = false;
            Function.Call(Hash._0xBF286C554784F3DF, (InputArgument) false);
            Function.Call(Hash._0x1098355A16064BB3, (InputArgument) false);
          }
          else if (!this.RadioOn)
          {
            this.CurrentRadio = Game.Player.Character.Position;
            Vector3 position = Game.Player.Character.Position;
            this.CurrentInt = Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z);
            this.Z_min = Game.Player.Character.Position.Z - 7f;
            this.Z_max = Game.Player.Character.Position.Z + 7f;
            this.RadioOn = true;
            Function.Call(Hash._0xA619B168B8A8570F, (InputArgument) 1);
            Function.Call(Hash._0x1098355A16064BB3, (InputArgument) true);
          }
        }
      }
      if (this.RadioOn)
      {
        if ((double) World.GetDistance(Game.Player.Character.Position, this.CurrentRadio) > 150.0)
        {
          UI.Notify("Radio Off, due to Player being to far away from Radio");
          this.RadioOn = false;
          Function.Call(Hash._0xBF286C554784F3DF, (InputArgument) false);
          Function.Call(Hash._0x1098355A16064BB3, (InputArgument) false);
        }
        Vector3 position = Game.Player.Character.Position;
        if ((double) position.Z > (double) this.Z_max || (double) position.Z < (double) this.Z_min)
        {
          UI.Notify("Radio Off, due to Player Height, being too low or too High");
          this.RadioOn = false;
          Function.Call(Hash._0xBF286C554784F3DF, (InputArgument) false);
          Function.Call(Hash._0x1098355A16064BB3, (InputArgument) false);
        }
        if (Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) position.X, (InputArgument) position.Y, (InputArgument) position.Z) != Function.Call<int>(Hash._0xB0F7F8663821D9C3, (InputArgument) this.CurrentRadio.X, (InputArgument) this.CurrentRadio.Y, (InputArgument) this.CurrentRadio.Z))
        {
          UI.Notify("Radio Off, due to exiting Interior");
          this.RadioOn = false;
          Function.Call(Hash._0xBF286C554784F3DF, (InputArgument) false);
          Function.Call(Hash._0x1098355A16064BB3, (InputArgument) false);
        }
        if ((Entity) Game.Player.Character.CurrentVehicle != (Entity) null)
        {
          UI.Notify("Radio Off, due to being in Vehicle");
          this.RadioOn = false;
          Function.Call(Hash._0xBF286C554784F3DF, (InputArgument) false);
          Function.Call(Hash._0x1098355A16064BB3, (InputArgument) false);
        }
        if ((Entity) Game.Player.Character.CurrentVehicle == (Entity) null)
          Function.Call(Hash._0xBF286C554784F3DF, (InputArgument) true);
      }
      foreach (Vector3 showerPosition in this.SHowerPositions)
      {
        if ((double) World.GetDistance(Game.Player.Character.Position, showerPosition) < 80.0)
        {
          if (this.InShower)
            World.DrawMarker(MarkerType.VerticalCylinder, showerPosition, Vector3.Zero, Vector3.Zero, new Vector3(0.7f, 0.7f, 1f), Color.White);
          if (!this.InShower)
            World.DrawMarker(MarkerType.VerticalCylinder, showerPosition, Vector3.Zero, Vector3.Zero, new Vector3(0.7f, 0.7f, 1f), Color.White);
        }
      }
      foreach (Vector3 wordrobePosition in this.WordrobePositions)
      {
        if ((double) World.GetDistance(Game.Player.Character.Position, wordrobePosition) < 80.0)
          World.DrawMarker(MarkerType.VerticalCylinder, wordrobePosition, Vector3.Zero, Vector3.Zero, new Vector3(0.7f, 0.7f, 1f), Color.White);
      }
      foreach (Vector3 showerPosition in this.SHowerPositions)
      {
        if ((double) World.GetDistance(Game.Player.Character.Position, showerPosition) < 3.0)
        {
          if (this.InShower)
            this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to get out of shower");
          if (!this.InShower)
            this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to take a shower");
        }
      }
      foreach (Vector3 wordrobePosition in this.WordrobePositions)
      {
        if ((double) World.GetDistance(Game.Player.Character.Position, wordrobePosition) < 2.0)
          this.DisplayHelpTextThisFrame("Press ~INPUT_CONTEXT~ to access Wardrobe");
      }
    }

    public void OnKeyDown()
    {
      foreach (Vector3 wordrobePosition in this.WordrobePositions)
      {
        if ((double) World.GetDistance(Game.Player.Character.Position, wordrobePosition) < 2.0 && Game.IsControlJustPressed(2, GTA.Control.Context))
          this.WoredrobeMainMenu.Visible = !this.WoredrobeMainMenu.Visible;
      }
      foreach (Vector3 showerPosition in this.SHowerPositions)
      {
        if ((double) World.GetDistance(Game.Player.Character.Position, showerPosition) < 3.0 && Game.IsControlJustPressed(2, GTA.Control.Context))
        {
          if (this.InShower)
          {
            this.InShower = false;
            Game.Player.Character.Position = showerPosition;
            Game.Player.Character.FreezePosition = false;
            Game.Player.Character.Health = 500;
            Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 3, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
            Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 4, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
            Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 6, (InputArgument) 0, (InputArgument) 0, (InputArgument) 1);
            Game.Player.Character.Task.ClearAnimation("anim@mp_yacht@shower@male@", "male_shower_idle_a");
            Function.Call(Hash._0xB8FEAEEBCC127425, (InputArgument) Game.Player.Character);
          }
          else if (!this.InShower)
          {
            Function.Call(Hash._0xB80D8756B4668AB6, (InputArgument) "scr_fbi5a");
            Function.Call(Hash._0x6C38AF3693A69A91, (InputArgument) "scr_fbi5a");
            Function.Call(Hash._0x0D53A3B8DA0809D2, (InputArgument) "scr_fbi5_ped_water_splash", (InputArgument) Game.Player.Character, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) -0.5, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) 0.0, (InputArgument) 1.0, (InputArgument) false, (InputArgument) false, (InputArgument) false);
            this.InShower = true;
            Game.Player.Character.Position = showerPosition;
            Game.Player.Character.FreezePosition = true;
            if (Game.Player.Character.Model == (Model) PedHash.Franklin || Game.Player.Character.Model == (Model) PedHash.Michael)
            {
              Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 3, (InputArgument) 26, (InputArgument) 0, (InputArgument) 1);
              Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 4, (InputArgument) 5, (InputArgument) 0, (InputArgument) 1);
              Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 6, (InputArgument) 15, (InputArgument) 0, (InputArgument) 1);
            }
            else
            {
              Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 3, (InputArgument) 16, (InputArgument) 0, (InputArgument) 1);
              Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 4, (InputArgument) 19, (InputArgument) 0, (InputArgument) 1);
              Function.Call(Hash._0x262B14F48D29DE80, (InputArgument) Game.Player.Character, (InputArgument) 6, (InputArgument) 16, (InputArgument) 17, (InputArgument) 1);
            }
            Game.Player.Character.Task.PlayAnimation("anim@mp_yacht@shower@male@", "male_shower_idle_a", 8f, -1, true, -1f);
          }
        }
      }
    }
  }
}
