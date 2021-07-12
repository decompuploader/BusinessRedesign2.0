using GTA;
using GTA.Math;
using System;
using System.Collections.Generic;

namespace HKH191SBusinessHelper
{
  public class Reset : Script
  {
    public LoadFile FiletoFind = new LoadFile();
    public bool MethLab_InitialSetupDone = false;
    public bool MethLab_EquipmentUpgrade;
    public bool MethLab_StaffUpgrade;
    public bool MethLab_SecurityUpgrade;
    public float MethLab_TotalEarnings = 0.0f;
    public int MethLab_TotalResupplySuccess = 0;
    public int MethLab_TotalResupplyFails = 0;
    public int MethLab_TotalSales_LS = 0;
    public int MethLab_TotalFails_LS = 0;
    public int MethLab_TotalSales_BC = 0;
    public int MethLab_TotalFails_BC = 0;
    public int MethLab_Supplies = 0;
    public int MethLab_ProductionCeased_NoSupplies = 0;
    public int MethLab_ProductionCeased_NoRaided = 0;
    public int MethLab_ProductionCeased_NoCapacity = 0;
    public bool MethLab_StoppedProducing;
    public float MethLab_BuySuppliesMultiplier = 1f;
    public float MethLab_SellProductMutliplier = 1f;
    public int MethLab_ProductMax = 100;
    public int MethLab_ProductBags = 0;
    public float MethLab_ProductValue = 0.0f;
    public float SETMethLab_ProductValue = 0.0f;
    private float SETMethLab_SellPrice;
    public List<Reset.PedSpawn> MethLab_ActiveSpawns = new List<Reset.PedSpawn>();
    public List<Reset.PedSpawn> MethLab_NotActiveSpawns = new List<Reset.PedSpawn>();
    public bool WeedFarm_InitialSetupDone = false;
    public bool WeedFarm_EquipmentUpgrade;
    public bool WeedFarm_StaffUpgrade;
    public bool WeedFarm_SecurityUpgrade;
    public float WeedFarm_TotalEarnings = 0.0f;
    public int WeedFarm_TotalResupplySuccess = 0;
    public int WeedFarm_TotalResupplyFails = 0;
    public int WeedFarm_TotalSales_LS = 0;
    public int WeedFarm_TotalFails_LS = 0;
    public int WeedFarm_TotalSales_BC = 0;
    public int WeedFarm_TotalFails_BC = 0;
    public int WeedFarm_Supplies = 0;
    public int WeedFarm_ProductionCeased_NoSupplies = 0;
    public int WeedFarm_ProductionCeased_NoRaided = 0;
    public int WeedFarm_ProductionCeased_NoCapacity = 0;
    public bool WeedFarm_StoppedProducing;
    public float WeedFarm_BuySuppliesMultiplier = 1f;
    public float WeedFarm_SellProductMutliplier = 1f;
    public int WeedFarm_ProductMax = 100;
    public int WeedFarm_ProductBags = 0;
    public float WeedFarm_ProductValue = 0.0f;
    public float SETWeedFarm_ProductValue = 0.0f;
    private float SETWeedFarm_SellPrice;
    public List<Reset.PedSpawn> WeedFarm_NotActiveSpawns = new List<Reset.PedSpawn>();
    public List<Reset.PedSpawn> WeedFarm_ActiveSpawns = new List<Reset.PedSpawn>();
    public bool CocaineLockup_InitialSetupDone;
    public bool CocaineLockup_EquipmentUpgrade;
    public bool CocaineLockup_StaffUpgrade;
    public bool CocaineLockup_SecurityUpgrade;
    public float CocaineLockup_TotalEarnings;
    public int CocaineLockup_TotalResupplySuccess;
    public int CocaineLockup_TotalResupplyFails;
    public int CocaineLockup_TotalSales_LS = 0;
    public int CocaineLockup_TotalFails_LS = 0;
    public int CocaineLockup_TotalSales_BC = 0;
    public int CocaineLockup_TotalFails_BC = 0;
    public int CocaineLockup_Supplies = 0;
    public int CocaineLockup_ProductionCeased_NoSupplies;
    public int CocaineLockup_ProductionCeased_NoRaided;
    public int CocaineLockup_ProductionCeased_NoCapacity;
    public bool CocaineLockup_StoppedProducing;
    public float CocaineLockup_BuySuppliesMultiplier = 1f;
    public float CocaineLockup_SellProductMutliplier = 1f;
    public int CocaineLockup_ProductMax = 100;
    public int CocaineLockup_ProductBags = 0;
    public float CocaineLockup_ProductValue = 0.0f;
    public float SETCocaineLockup_ProductValue = 0.0f;
    private float SETCocaineLockup_SellPrice;
    public List<Reset.PedSpawn> CocaineLockup_NotActiveSpawns = new List<Reset.PedSpawn>();
    public List<Reset.PedSpawn> CocaineLockup_ActiveSpawns = new List<Reset.PedSpawn>()
    {
      new Reset.PedSpawn(new Vector3(1090.189f, -3191.248f, -39.4f), -11f),
      new Reset.PedSpawn(new Vector3(1099.549f, -3194.2f, -38.99344f), 99.86244f),
      new Reset.PedSpawn(new Vector3(1095.407f, -3196.616f, -38.99344f), 358.3549f),
      new Reset.PedSpawn(new Vector3(1093.495f, -3196.669f, -38.99344f), 358.5891f),
      new Reset.PedSpawn(new Vector3(1090.971f, -3196.684f, -38.99344f), 359.8737f),
      new Reset.PedSpawn(new Vector3(1089.828f, -3196.61f, -38.99344f), 1.603552f),
      new Reset.PedSpawn(new Vector3(1092.486f, -3196.584f, -38.99344f), 345.0735f),
      new Reset.PedSpawn(new Vector3(1088.683f, -3196.114f, -38.99344f), 278.4438f),
      new Reset.PedSpawn(new Vector3(1090.24f, -3194.675f, -38.99344f), 191.1207f),
      new Reset.PedSpawn(new Vector3(1092.473f, -3194.918f, -38.99344f), 179.8266f),
      new Reset.PedSpawn(new Vector3(1093.432f, -3194.917f, -38.99344f), 172.7995f),
      new Reset.PedSpawn(new Vector3(1094.812f, -3194.861f, -38.99344f), 194.5334f),
      new Reset.PedSpawn(new Vector3(1096.109f, -3194.825f, -38.99344f), 173.2655f),
      new Reset.PedSpawn(new Vector3(1097.029f, -3195.612f, -38.99344f), 88.36512f)
    };
    public bool CounterfeitOffice_InitialSetupDone = false;
    public bool CounterfeitOffice_EquipmentUpgrade;
    public bool CounterfeitOffice_StaffUpgrade;
    public bool CounterfeitOffice_SecurityUpgrade;
    public float CounterfeitOffice_TotalEarnings = 0.0f;
    public int CounterfeitOffice_TotalResupplySuccess = 0;
    public int CounterfeitOffice_TotalResupplyFails = 0;
    public int CounterfeitOffice_TotalSales_LS = 0;
    public int CounterfeitOffice_TotalFails_LS = 0;
    public int CounterfeitOffice_TotalSales_BC = 0;
    public int CounterfeitOffice_TotalFails_BC = 0;
    public int CounterfeitOffice_Supplies = 0;
    public int CounterfeitOffice_ProductionCeased_NoSupplies = 0;
    public int CounterfeitOffice_ProductionCeased_NoRaided = 0;
    public int CounterfeitOffice_ProductionCeased_NoCapacity = 0;
    public bool CounterfeitOffice_StoppedProducing;
    public float CounterfeitOffice_BuySuppliesMultiplier = 1f;
    public float CounterfeitOffice_SellProductMutliplier = 1f;
    public int CounterfeitOffice_ProductMax = 100;
    public int CounterfeitOffice_ProductBags = 0;
    public float CounterfeitOffice_ProductValue = 0.0f;
    public float SETCounterfeitOffice_ProductValue = 0.0f;
    private float SETCounterfeitOffice_SellPrice;
    public List<Reset.PedSpawn> CounterfeitOffice_NotActiveSpawns = new List<Reset.PedSpawn>();
    public List<Reset.PedSpawn> CounterfeitOffice_ActiveSpawns = new List<Reset.PedSpawn>();
    public bool DocumentForgery_InitialSetupDone = false;
    public bool DocumentForgery_EquipmentUpgrade;
    public bool DocumentForgery_StaffUpgrade;
    public bool DocumentForgery_SecurityUpgrade;
    public float DocumentForgery_TotalEarnings = 0.0f;
    public int DocumentForgery_TotalResupplySuccess = 0;
    public int DocumentForgery_TotalResupplyFails = 0;
    public int DocumentForgery_TotalSales_LS = 0;
    public int DocumentForgery_TotalFails_LS = 0;
    public int DocumentForgery_TotalSales_BC = 0;
    public int DocumentForgery_TotalFails_BC = 0;
    public int DocumentForgery_Supplies = 0;
    public int DocumentForgery_ProductionCeased_NoSupplies = 0;
    public int DocumentForgery_ProductionCeased_NoRaided = 0;
    public int DocumentForgery_ProductionCeased_NoCapacity = 0;
    public bool DocumentForgery_StoppedProducing;
    public float DocumentForgery_BuySuppliesMultiplier = 1f;
    public float DocumentForgery_SellProductMutliplier = 1f;
    public int DocumentForgery_ProductMax = 100;
    public int DocumentForgery_ProductBags = 0;
    public float DocumentForgery_ProductValue = 0.0f;
    public float SETDocumentForgery_ProductValue = 0.0f;
    private float SETDocumentForgery_SellPrice;
    public List<Reset.PedSpawn> DocumentForgery_NotActiveSpawns = new List<Reset.PedSpawn>();
    public List<Reset.PedSpawn> DocumentForgery_ActiveSpawns = new List<Reset.PedSpawn>()
    {
      new Reset.PedSpawn(new Vector3(1170.115f, -3196.448f, -39.95631f), 270f),
      new Reset.PedSpawn(new Vector3(1167.173f, -3196.401f, -39.95631f), 90f),
      new Reset.PedSpawn(new Vector3(1165.655f, -3197.064f, -39.95553f), 270f),
      new Reset.PedSpawn(new Vector3(1162.715f, -3196.934f, -39.95631f), 90f),
      new Reset.PedSpawn(new Vector3(1160.879f, -3198.542f, -39.95631f), 270f),
      new Reset.PedSpawn(new Vector3(1159.19f, -3195.834f, -39.95536f), 0.0f),
      new Reset.PedSpawn(new Vector3(1157.964f, -3198.534f, -39.95631f), 90f)
    };
    public int ForgeryBought;
    public int MoneyPrinterBought;
    public int WeedFarmBought;
    public int CocaineBought;
    public int MethLabBought;
    public int MethMCbusinessLoc = 0;
    public int WeedMCbusinessLoc = 0;
    public int CocaineMCbusinessLoc = 0;
    public int CounterfietMCbusinessLoc = 0;
    public int ForgeryMCbusinessLoc = 0;
    private ScriptSettings Config;

    public void print(string Inp) => UI.Notify(Inp);

    public void ExecutiveFullKit(string Ini)
    {
      try
      {
        try
        {
          this.print("#StartRead");
          this.FiletoFind.Open(Ini, false);
          this.FiletoFind.WriteValue("SETUP", "GUNLOCKERBOUGHT", "1");
          this.FiletoFind.WriteValue("SETUP", "MONEYVAULTBOUGHT", "1");
          this.FiletoFind.WriteValue("GARAGE", "PURCHASEDGARAGELEVEL1", "1");
          this.FiletoFind.WriteValue("GARAGE", "PURCHASEDGARAGELEVEL1", "1");
          this.FiletoFind.WriteValue("GARAGE", "PURCHASEDGARAGELEVEL1", "1");
          this.FiletoFind.WriteValue("GARAGE", "PURCHASEDGARAGEMODSHOP", "1");
          this.print("#EndRead");
        }
        catch (Exception ex)
        {
          this.print("Error : Null Reference Execption!");
        }
      }
      catch (Exception ex)
      {
        this.print("Error : File Not Found!");
      }
    }

    private void LoadIniFile(string iniName)
    {
      try
      {
        this.Config = ScriptSettings.Load(iniName);
      }
      catch (Exception ex)
      {
        UI.Notify("~r~Error~w~: Config.ini Failed To Load.");
      }
    }

    public void ResetMCBusiness(int b)
    {
      this.LoadIniFile("scripts//HKH191sBusinessMods//MethBusiness//Main.ini");
      if (b == 1)
      {
        this.MethLabBought = 0;
        this.Config.SetValue<int>("SubBusiness", "MethLabBought", this.MethLabBought);
        this.MethMCbusinessLoc = 0;
        this.Config.SetValue<int>("SubBusiness", "MethMCbusinessLoc", this.MethMCbusinessLoc);
        this.MethLab_InitialSetupDone = false;
        this.Config.SetValue<bool>("SubBusiness-Upgrades", "MethLab_InitialSetupDone", this.MethLab_InitialSetupDone);
        this.MethLab_EquipmentUpgrade = false;
        this.Config.SetValue<bool>("SubBusiness-Upgrades", "MethLab_EquipmentUpgrade", this.MethLab_EquipmentUpgrade);
        this.MethLab_StaffUpgrade = false;
        this.Config.SetValue<bool>("SubBusiness-Upgrades", "MethLab_StaffUpgrade", this.MethLab_StaffUpgrade);
        this.MethLab_SecurityUpgrade = false;
        this.Config.SetValue<bool>("SubBusiness-Upgrades", "MethLab_SecurityUpgrade", this.MethLab_SecurityUpgrade);
        this.MethLab_TotalEarnings = 0.0f;
        this.Config.SetValue<float>("SubBusiness-MethLab-Stats", "MethLab_TotalEarnings", this.MethLab_TotalEarnings);
        this.MethLab_TotalResupplySuccess = 0;
        this.Config.SetValue<int>("SubBusiness-MethLab-Stats", "MethLab_TotalResupplySuccess", this.MethLab_TotalResupplySuccess);
        this.MethLab_TotalResupplyFails = 0;
        this.Config.SetValue<int>("SubBusiness-MethLab-Stats", "MethLab_TotalResupplyFails", this.MethLab_TotalResupplyFails);
        this.MethLab_TotalSales_LS = 0;
        this.Config.SetValue<int>("SubBusiness-MethLab-Stats", "MethLab_TotalSales_LS", this.MethLab_TotalSales_LS);
        this.MethLab_TotalFails_LS = 0;
        this.Config.SetValue<int>("SubBusiness-MethLab-Stats", "MethLab_TotalFails_LS", this.MethLab_TotalFails_LS);
        this.MethLab_TotalSales_BC = 0;
        this.Config.SetValue<int>("SubBusiness-MethLab-Stats", "MethLab_TotalSales_BC", this.MethLab_TotalSales_BC);
        this.MethLab_TotalFails_BC = 0;
        this.Config.SetValue<int>("SubBusiness-MethLab-Stats", "MethLab_TotalFails_BC", this.MethLab_TotalFails_BC);
        this.MethLab_Supplies = 0;
        this.Config.SetValue<int>("SubBusiness-MethLab-Stats", "MethLab_Supplies", this.MethLab_Supplies);
        this.MethLab_ProductionCeased_NoSupplies = 0;
        this.Config.SetValue<int>("SubBusiness-MethLab-Stats", "MethLab_ProductionCeased_NoSupplies", this.MethLab_ProductionCeased_NoSupplies);
        this.MethLab_ProductionCeased_NoRaided = 0;
        this.Config.SetValue<int>("SubBusiness-MethLab-Stats", "MethLab_ProductionCeased_NoRaided", this.MethLab_ProductionCeased_NoRaided);
        this.MethLab_ProductionCeased_NoCapacity = 0;
        this.Config.SetValue<int>("SubBusiness-MethLab-Stats", "MethLab_ProductionCeased_NoCapacity", this.MethLab_ProductionCeased_NoCapacity);
        this.MethLab_StoppedProducing = false;
        this.Config.SetValue<bool>("SubBusiness-MethLab-Stats", "MethLab_StoppedProducing", this.MethLab_StoppedProducing);
        this.MethLab_BuySuppliesMultiplier = 1f;
        this.Config.SetValue<float>("SubBusiness-MethLab-Stats", "MethLab_BuySuppliesMultiplier", this.MethLab_BuySuppliesMultiplier);
        this.MethLab_SellProductMutliplier = 1f;
        this.Config.SetValue<float>("SubBusiness-MethLab-Stats", "MethLab_SellProductMutliplier", this.MethLab_SellProductMutliplier);
        this.MethLab_ProductMax = 100;
        this.Config.SetValue<int>("SubBusiness-MethLab-Stats", "MethLab_ProductMax", this.MethLab_ProductMax);
        this.MethLab_ProductBags = 0;
        this.Config.SetValue<int>("SubBusiness-MethLab-Stats", "MethLab_ProductBags", this.MethLab_ProductBags);
        this.SETMethLab_ProductValue = 0.0f;
        this.Config.SetValue<float>("SubBusiness-MethLab-Stats", "MethLab_ProductValue", this.SETMethLab_ProductValue);
        this.Config.Save();
        UI.Notify("Meth Lab MC Business has been Fully Reset");
      }
      if (b == 3)
      {
        this.WeedFarmBought = 0;
        this.Config.SetValue<int>("SubBusiness", "WeedFarmBought", this.WeedFarmBought);
        this.WeedMCbusinessLoc = 0;
        this.Config.SetValue<int>("SubBusiness", "WeedMCbusinessLoc", this.WeedMCbusinessLoc);
        this.WeedFarm_InitialSetupDone = false;
        this.Config.SetValue<bool>("SubBusiness-Upgrades", "WeedFarm_InitialSetupDone", this.WeedFarm_InitialSetupDone);
        this.WeedFarm_EquipmentUpgrade = false;
        this.Config.SetValue<bool>("SubBusiness-Upgrades", "WeedFarm_EquipmentUpgrade", this.WeedFarm_EquipmentUpgrade);
        this.WeedFarm_StaffUpgrade = false;
        this.Config.SetValue<bool>("SubBusiness-Upgrades", "WeedFarm_StaffUpgrade", this.WeedFarm_StaffUpgrade);
        this.WeedFarm_SecurityUpgrade = false;
        this.Config.SetValue<bool>("SubBusiness-Upgrades", "WeedFarm_SecurityUpgrade", this.WeedFarm_SecurityUpgrade);
        this.WeedFarm_TotalEarnings = 0.0f;
        this.Config.SetValue<float>("SubBusiness-Weedfarm-Stats", "MethLab_TotalEarnings", this.MethLab_TotalEarnings);
        this.WeedFarm_TotalResupplySuccess = 0;
        this.Config.SetValue<int>("SubBusiness-Weedfarm-Stats", "WeedFarm_TotalResupplySuccess", this.WeedFarm_TotalResupplySuccess);
        this.WeedFarm_TotalResupplyFails = 0;
        this.Config.SetValue<int>("SubBusiness-Weedfarm-Stats", "WeedFarm_TotalResupplyFails", this.WeedFarm_TotalResupplyFails);
        this.WeedFarm_TotalSales_LS = 0;
        this.Config.SetValue<int>("SubBusiness-Weedfarm-Stats", "WeedFarm_TotalSales_LS", this.WeedFarm_TotalSales_LS);
        this.WeedFarm_TotalFails_LS = 0;
        this.Config.SetValue<int>("SubBusiness-Weedfarm-Stats", "WeedFarm_TotalFails_LS", this.WeedFarm_TotalFails_LS);
        this.WeedFarm_TotalSales_BC = 0;
        this.Config.SetValue<int>("SubBusiness-Weedfarm-Stats", "WeedFarm_TotalSales_BC", this.WeedFarm_TotalSales_BC);
        this.WeedFarm_TotalFails_BC = 0;
        this.Config.SetValue<int>("SubBusiness-Weedfarm-Stats", "WeedFarm_TotalFails_BC", this.WeedFarm_TotalFails_BC);
        this.WeedFarm_Supplies = 0;
        this.Config.SetValue<int>("SubBusiness-Weedfarm-Stats", "WeedFarm_Supplies", this.WeedFarm_Supplies);
        this.WeedFarm_ProductionCeased_NoSupplies = 0;
        this.Config.SetValue<int>("SubBusiness-Weedfarm-Stats", "WeedFarm_ProductionCeased_NoSupplies", this.WeedFarm_ProductionCeased_NoSupplies);
        this.WeedFarm_ProductionCeased_NoRaided = 0;
        this.Config.SetValue<int>("SubBusiness-Weedfarm-Stats", "WeedFarm_ProductionCeased_NoRaided", this.WeedFarm_ProductionCeased_NoRaided);
        this.WeedFarm_ProductionCeased_NoCapacity = 0;
        this.Config.SetValue<int>("SubBusiness-Weedfarm-Stats", "WeedFarm_ProductionCeased_NoCapacity", this.WeedFarm_ProductionCeased_NoCapacity);
        this.WeedFarm_StoppedProducing = false;
        this.Config.SetValue<bool>("SubBusiness-Weedfarm-Stats", "WeedFarm_StoppedProducing", this.WeedFarm_StoppedProducing);
        this.WeedFarm_BuySuppliesMultiplier = 1f;
        this.Config.SetValue<float>("SubBusiness-Weedfarm-Stats", "WeedFarm_BuySuppliesMultiplier", this.WeedFarm_BuySuppliesMultiplier);
        this.WeedFarm_SellProductMutliplier = 1f;
        this.Config.SetValue<float>("SubBusiness-Weedfarm-Stats", "WeedFarm_SellProductMutliplier", this.WeedFarm_SellProductMutliplier);
        this.WeedFarm_ProductMax = 100;
        this.Config.SetValue<int>("SubBusiness-WeedFarm-Weedfarm-Stats", "WeedFarm_ProductMax", this.WeedFarm_ProductMax);
        this.WeedFarm_ProductBags = 0;
        this.Config.SetValue<int>("SubBusiness-WeedFarm-Stats", "WeedFarm_ProductBags", this.WeedFarm_ProductBags);
        this.SETWeedFarm_ProductValue = 0.0f;
        this.Config.SetValue<float>("SubBusiness-WeedFarm-Stats", "WeedFarm_ProductValue", this.SETWeedFarm_ProductValue);
        this.Config.Save();
        UI.Notify("Weed Farm MC Business has been Fully Reset");
      }
      if (b == 2)
      {
        this.CocaineBought = 0;
        this.Config.SetValue<int>("SubBusiness", "COCAINEBOUGHT", this.CocaineBought);
        this.CocaineMCbusinessLoc = 0;
        this.Config.SetValue<int>("SubBusiness", "CocaineMCbusinessLoc", this.CocaineMCbusinessLoc);
        this.CocaineLockup_InitialSetupDone = false;
        this.Config.SetValue<bool>("SubBusiness-Upgrades", "CocaineLockup_InitialSetupDone", this.CocaineLockup_InitialSetupDone);
        this.CocaineLockup_EquipmentUpgrade = false;
        this.Config.SetValue<bool>("SubBusiness-Upgrades", "CocaineLockup_EquipmentUpgrade", this.CocaineLockup_EquipmentUpgrade);
        this.CocaineLockup_StaffUpgrade = false;
        this.Config.SetValue<bool>("SubBusiness-Upgrades", "CocaineLockup_StaffUpgrade", this.CocaineLockup_StaffUpgrade);
        this.CocaineLockup_SecurityUpgrade = false;
        this.Config.SetValue<bool>("SubBusiness-Upgrades", "CocaineLockup_SecurityUpgrade", this.CocaineLockup_SecurityUpgrade);
        this.CocaineLockup_TotalEarnings = 0.0f;
        this.Config.SetValue<float>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_TotalEarnings", this.CocaineLockup_TotalEarnings);
        this.CocaineLockup_TotalResupplySuccess = 0;
        this.Config.SetValue<int>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_TotalResupplySuccess", this.CocaineLockup_TotalResupplySuccess);
        this.CocaineLockup_TotalResupplyFails = 0;
        this.Config.SetValue<int>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_TotalResupplyFails", this.CocaineLockup_TotalResupplyFails);
        this.CocaineLockup_TotalSales_LS = 0;
        this.Config.SetValue<int>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_TotalSales_LS", this.CocaineLockup_TotalSales_LS);
        this.CocaineLockup_TotalFails_LS = 0;
        this.Config.SetValue<int>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_TotalFails_LS", this.CocaineLockup_TotalFails_LS);
        this.CocaineLockup_TotalSales_BC = 0;
        this.Config.SetValue<int>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_TotalSales_BC", this.CocaineLockup_TotalSales_BC);
        this.CocaineLockup_TotalFails_BC = 0;
        this.Config.SetValue<int>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_TotalFails_BC", this.CocaineLockup_TotalFails_BC);
        this.CocaineLockup_Supplies = 0;
        this.Config.SetValue<int>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_Supplies", this.CocaineLockup_Supplies);
        this.CocaineLockup_ProductionCeased_NoSupplies = 0;
        this.Config.SetValue<int>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_ProductionCeased_NoSupplies", this.CocaineLockup_ProductionCeased_NoSupplies);
        this.CocaineLockup_ProductionCeased_NoRaided = 0;
        this.Config.SetValue<int>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_ProductionCeased_NoRaided", this.CocaineLockup_ProductionCeased_NoRaided);
        this.CocaineLockup_ProductionCeased_NoCapacity = 0;
        this.Config.SetValue<int>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_ProductionCeased_NoCapacity", this.CocaineLockup_ProductionCeased_NoCapacity);
        this.CocaineLockup_StoppedProducing = false;
        this.Config.SetValue<bool>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_StoppedProducing", this.CocaineLockup_StoppedProducing);
        this.CocaineLockup_BuySuppliesMultiplier = 1f;
        this.Config.SetValue<float>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_BuySuppliesMultiplier", this.CocaineLockup_BuySuppliesMultiplier);
        this.CocaineLockup_SellProductMutliplier = 1f;
        this.Config.SetValue<float>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_SellProductMutliplier", this.CocaineLockup_SellProductMutliplier);
        this.CocaineLockup_ProductMax = 100;
        this.Config.SetValue<int>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_ProductMax", this.CocaineLockup_ProductMax);
        this.CocaineLockup_ProductBags = 0;
        this.Config.SetValue<int>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_ProductBags", this.CocaineLockup_ProductBags);
        this.SETCocaineLockup_ProductValue = 0.0f;
        this.Config.SetValue<float>("SubBusiness-CocaineLockup-Stats", "CocaineLockup_ProductValue", this.SETCocaineLockup_ProductValue);
        this.Config.Save();
        UI.Notify("Cocaine Lockup MC Business has been Fully Reset");
      }
      if (b == 5)
      {
        this.MoneyPrinterBought = 0;
        this.Config.SetValue<int>("SubBusiness", "MoneyPrinterBought", this.MoneyPrinterBought);
        this.CounterfietMCbusinessLoc = 0;
        this.Config.SetValue<int>("SubBusiness", "CounterfietMCbusinessLoc", this.CounterfietMCbusinessLoc);
        this.CounterfeitOffice_InitialSetupDone = false;
        this.Config.SetValue<bool>("SubBusiness-Upgrades", "CounterfeitOffice_InitialSetupDone", this.CounterfeitOffice_InitialSetupDone);
        this.CounterfeitOffice_EquipmentUpgrade = false;
        this.Config.SetValue<bool>("SubBusiness-Upgrades", "CounterfeitOffice_EquipmentUpgrade", this.CounterfeitOffice_EquipmentUpgrade);
        this.CounterfeitOffice_StaffUpgrade = false;
        this.Config.SetValue<bool>("SubBusiness-Upgrades", "CounterfeitOffice_StaffUpgrade", this.CounterfeitOffice_StaffUpgrade);
        this.CounterfeitOffice_SecurityUpgrade = false;
        this.Config.SetValue<bool>("SubBusiness-Upgrades", "CounterfeitOffice_SecurityUpgrade", this.CounterfeitOffice_SecurityUpgrade);
        this.CounterfeitOffice_TotalEarnings = 0.0f;
        this.Config.SetValue<float>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_TotalEarnings", this.CounterfeitOffice_TotalEarnings);
        this.CounterfeitOffice_TotalResupplySuccess = 0;
        this.Config.SetValue<int>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_TotalResupplySuccess", this.CounterfeitOffice_TotalResupplySuccess);
        this.CounterfeitOffice_TotalResupplyFails = 0;
        this.Config.SetValue<int>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_TotalResupplyFails", this.CounterfeitOffice_TotalResupplyFails);
        this.CounterfeitOffice_TotalSales_LS = 0;
        this.Config.SetValue<int>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_TotalSales_LS", this.CounterfeitOffice_TotalSales_LS);
        this.CounterfeitOffice_TotalFails_LS = 0;
        this.Config.SetValue<int>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_TotalFails_LS", this.CounterfeitOffice_TotalFails_LS);
        this.CounterfeitOffice_TotalSales_BC = 0;
        this.Config.SetValue<int>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_TotalSales_BC", this.CounterfeitOffice_TotalSales_BC);
        this.CounterfeitOffice_TotalFails_BC = 0;
        this.Config.SetValue<int>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_TotalFails_BC", this.CounterfeitOffice_TotalFails_BC);
        this.CounterfeitOffice_Supplies = 0;
        this.Config.SetValue<int>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_Supplies", this.CounterfeitOffice_Supplies);
        this.CounterfeitOffice_ProductionCeased_NoSupplies = 0;
        this.Config.SetValue<int>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_ProductionCeased_NoSupplies", this.CounterfeitOffice_ProductionCeased_NoSupplies);
        this.CounterfeitOffice_ProductionCeased_NoRaided = 0;
        this.Config.SetValue<int>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_ProductionCeased_NoRaided", this.CounterfeitOffice_ProductionCeased_NoRaided);
        this.CounterfeitOffice_ProductionCeased_NoCapacity = 0;
        this.Config.SetValue<int>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_ProductionCeased_NoCapacity", this.CounterfeitOffice_ProductionCeased_NoCapacity);
        this.CounterfeitOffice_StoppedProducing = false;
        this.Config.SetValue<bool>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_StoppedProducing", this.CounterfeitOffice_StoppedProducing);
        this.CounterfeitOffice_BuySuppliesMultiplier = 1f;
        this.Config.SetValue<float>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_BuySuppliesMultiplier", this.CounterfeitOffice_BuySuppliesMultiplier);
        this.CounterfeitOffice_SellProductMutliplier = 1f;
        this.Config.SetValue<float>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_SellProductMutliplier", this.CounterfeitOffice_SellProductMutliplier);
        this.CounterfeitOffice_ProductMax = 100;
        this.Config.SetValue<int>("SubBusiness-DocumentForgery-Stats", "CounterfeitOffice_ProductMax", this.CounterfeitOffice_ProductMax);
        this.CounterfeitOffice_ProductBags = 0;
        this.Config.SetValue<int>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_ProductBags", this.CounterfeitOffice_ProductBags);
        this.SETCounterfeitOffice_ProductValue = 0.0f;
        this.Config.SetValue<float>("SubBusiness-CounterfeitOffice-Stats", "CounterfeitOffice_ProductValue", this.SETCounterfeitOffice_ProductValue);
        this.Config.Save();
        UI.Notify("Counterfeit Office MC Business has been Fully Reset");
      }
      if (b != 4)
        return;
      this.ForgeryBought = 0;
      this.Config.SetValue<int>("SubBusiness", "ForgeryBought", this.ForgeryBought);
      this.ForgeryMCbusinessLoc = 0;
      this.Config.SetValue<int>("SubBusiness", "ForgeryMCbusinessLoc", this.ForgeryMCbusinessLoc);
      this.DocumentForgery_InitialSetupDone = false;
      this.Config.SetValue<bool>("SubBusiness-Upgrades", "DocumentForgery_InitialSetupDone", this.DocumentForgery_InitialSetupDone);
      this.DocumentForgery_EquipmentUpgrade = false;
      this.Config.SetValue<bool>("SubBusiness-Upgrades", "DocumentForgery_EquipmentUpgrade", this.DocumentForgery_EquipmentUpgrade);
      this.DocumentForgery_StaffUpgrade = false;
      this.Config.SetValue<bool>("SubBusiness-Upgrades", "DocumentForgery_StaffUpgrade", this.DocumentForgery_StaffUpgrade);
      this.DocumentForgery_SecurityUpgrade = false;
      this.Config.SetValue<bool>("SubBusiness-Upgrades", "DocumentForgery_SecurityUpgrade", this.DocumentForgery_SecurityUpgrade);
      this.DocumentForgery_TotalEarnings = 0.0f;
      this.Config.SetValue<float>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_TotalEarnings", this.DocumentForgery_TotalEarnings);
      this.DocumentForgery_TotalResupplySuccess = 0;
      this.Config.SetValue<int>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_TotalResupplySuccess", this.DocumentForgery_TotalResupplySuccess);
      this.DocumentForgery_TotalResupplyFails = 0;
      this.Config.SetValue<int>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_TotalResupplyFails", this.DocumentForgery_TotalResupplyFails);
      this.DocumentForgery_TotalSales_LS = 0;
      this.Config.SetValue<int>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_TotalSales_LS", this.DocumentForgery_TotalSales_LS);
      this.DocumentForgery_TotalFails_LS = 0;
      this.Config.SetValue<int>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_TotalFails_LS", this.DocumentForgery_TotalFails_LS);
      this.DocumentForgery_TotalSales_BC = 0;
      this.Config.SetValue<int>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_TotalSales_BC", this.DocumentForgery_TotalSales_BC);
      this.DocumentForgery_TotalFails_BC = 0;
      this.Config.SetValue<int>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_TotalFails_BC", this.DocumentForgery_TotalFails_BC);
      this.DocumentForgery_Supplies = 0;
      this.Config.SetValue<int>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_Supplies", this.DocumentForgery_Supplies);
      this.DocumentForgery_ProductionCeased_NoSupplies = 0;
      this.Config.SetValue<int>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_ProductionCeased_NoSupplies", this.DocumentForgery_ProductionCeased_NoSupplies);
      this.DocumentForgery_ProductionCeased_NoRaided = 0;
      this.Config.SetValue<int>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_ProductionCeased_NoRaided", this.DocumentForgery_ProductionCeased_NoRaided);
      this.DocumentForgery_ProductionCeased_NoCapacity = 0;
      this.Config.SetValue<int>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_ProductionCeased_NoCapacity", this.DocumentForgery_ProductionCeased_NoCapacity);
      this.DocumentForgery_BuySuppliesMultiplier = 1f;
      this.Config.SetValue<float>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_BuySuppliesMultiplier", this.DocumentForgery_BuySuppliesMultiplier);
      this.DocumentForgery_SellProductMutliplier = 1f;
      this.Config.SetValue<float>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_SellProductMutliplier", this.DocumentForgery_SellProductMutliplier);
      this.DocumentForgery_StoppedProducing = false;
      this.Config.SetValue<bool>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_StoppedProducing", this.DocumentForgery_StoppedProducing);
      this.DocumentForgery_ProductMax = 100;
      this.Config.SetValue<int>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_ProductMax", this.DocumentForgery_ProductMax);
      this.DocumentForgery_ProductBags = 0;
      this.Config.SetValue<int>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_ProductBags", this.DocumentForgery_ProductBags);
      this.SETDocumentForgery_ProductValue = 0.0f;
      this.Config.SetValue<float>("SubBusiness-DocumentForgery-Stats", "DocumentForgery_ProductValue", this.SETDocumentForgery_ProductValue);
      this.Config.Save();
      UI.Notify("Document Forgery MC Business has been Fully Reset");
    }

    public void ResetExecutiveBusinessOption(string Ini)
    {
      try
      {
        try
        {
          this.print("#StartRead");
          this.FiletoFind.Open(Ini, false);
          this.FiletoFind.WriteValue("SETUP", "BUISNESSLEVEL", "0");
          this.FiletoFind.WriteValue("SETUP", "STOCKSLEVEL", "0");
          this.FiletoFind.WriteValue("SETUP", "STOCKSVALUE", "0");
          this.FiletoFind.WriteValue("SETUP", "DISPLAYWAIT", "0");
          this.FiletoFind.WriteValue("SETUP", "BUZZARDBOUGHT", "0");
          this.FiletoFind.WriteValue("SETUP", "FMJBOUGHT", "0");
          this.FiletoFind.WriteValue("SETUP", "911BOUGHT", "0");
          this.FiletoFind.WriteValue("SETUP", "X80BOUGHT", "0");
          this.FiletoFind.WriteValue("SETUP", "SEVEN70BOUGHT", "0");
          this.FiletoFind.WriteValue("SETUP", "CARGARAGEBOUGHT", "0");
          this.FiletoFind.WriteValue("SETUP", "WHEREHOSUEBOUGHT", "0");
          this.FiletoFind.WriteValue("SETUP", "AIRCRAFTSTORAGE", "0");
          this.FiletoFind.WriteValue("SETUP", "GUNLOCKERBOUGHT", "0");
          this.FiletoFind.WriteValue("SETUP", "MONEYVAULTBOUGHT", "0");
          this.FiletoFind.WriteValue("SETUP", "DOCKBOUGHT", "0");
          this.FiletoFind.WriteValue("SETUP", "VEHICLELOTBOUGHT", "0");
          this.FiletoFind.WriteValue("SETUP", "AATRAILERABOUGHT", "0");
          this.FiletoFind.WriteValue("SETUP", "AATRAILERBBOUGHT", "0");
          this.FiletoFind.WriteValue("SETUP", "AATRAILERCBOUGHT", "0");
          this.FiletoFind.WriteValue("SETUP", "SAVAGEBOUGHT", "0");
          this.FiletoFind.WriteValue("SETUP", "AKULABOUGHT", "0");
          this.FiletoFind.WriteValue("SETUP", "HUNTERBOUGHT", "0");
          this.FiletoFind.WriteValue("SETUP", "VALKYRIEBOUGHT", "0");
          this.FiletoFind.WriteValue("SETUP", "ANNIHILATORBOUGHT", "0");
          this.FiletoFind.WriteValue("SETUP", "A911BOUGHT", "0");
          this.FiletoFind.WriteValue("ADDON2", "MONEYSTORED", "0");
          this.FiletoFind.WriteValue("ADDON2", "COMMISSION", "0");
          this.FiletoFind.WriteValue("ADDON2", "KEY3", "E");
          this.FiletoFind.WriteValue("MISC", "CHAIRMODELASSISTANT", "ex_prop_offchair_exec_01");
          this.FiletoFind.WriteValue("MISC", "CHAIRMODELCEO", "ba_prop_battle_club_chair_01");
          this.FiletoFind.WriteValue("SETUP", "VEHICLEWAREHOUSEBOUGHT", "0");
          this.FiletoFind.WriteValue("SETUP", "SUBBUSINESSLOC", "0");
          this.FiletoFind.WriteValue("SETUP", "SUBBUSINESSBOUGHT", "0");
          this.FiletoFind.WriteValue("DESIGN", "INTERIORDESIGN", "1");
          this.FiletoFind.WriteValue("DESIGN", "AMOUNTOFCASH", "0");
          this.FiletoFind.WriteValue("DESIGN", "SWAG_SILVER ENABLED", "False");
          this.FiletoFind.WriteValue("DESIGN", "SWAG_SILVER2 ENABLED", "False");
          this.FiletoFind.WriteValue("DESIGN", "SWAG_SILVER3 ENABLED", "False");
          this.FiletoFind.WriteValue("DESIGN", "SWAG_DRUGBAGS ENABLED", "False");
          this.FiletoFind.WriteValue("DESIGN", "SWAG_DRUGBAGS2 ENABLED", "False");
          this.FiletoFind.WriteValue("DESIGN", "SWAG_DRUGBAGS3 ENABLED", "False");
          this.FiletoFind.WriteValue("DESIGN", "SWAG_BOOZE_CIGS ENABLED", "False");
          this.FiletoFind.WriteValue("DESIGN", "SWAG_BOOZE_CIGS2 ENABLED", "False");
          this.FiletoFind.WriteValue("DESIGN", "SWAG_BOOZE_CIGS3 ENABLED", "False");
          this.FiletoFind.WriteValue("DESIGN", "SWAG_ELECTRONIC ENABLED", "False");
          this.FiletoFind.WriteValue("DESIGN", "SWAG_ELECTRONIC2 ENABLED", "False");
          this.FiletoFind.WriteValue("DESIGN", "SWAG_ELECTRONIC3 ENABLED", "False");
          this.FiletoFind.WriteValue("DESIGN", "SWAG_DRUGSTATUE ENABLED", "False");
          this.FiletoFind.WriteValue("DESIGN", "SWAG_DRUGSTATUE2 ENABLED", "False");
          this.FiletoFind.WriteValue("DESIGN", "SWAG_DRUGSTATUE3 ENABLED", "False");
          this.FiletoFind.WriteValue("DESIGN", "SWAG_IVORY ENABLED", "False");
          this.FiletoFind.WriteValue("DESIGN", "SWAG_IVORY2 ENABLED", "False");
          this.FiletoFind.WriteValue("DESIGN", "SWAG_IVORY3 ENABLED", "False");
          this.FiletoFind.WriteValue("DESIGN", "SWAG_PILLS ENABLED", "False");
          this.FiletoFind.WriteValue("DESIGN", "SWAG_PILLS2 ENABLED", "False");
          this.FiletoFind.WriteValue("DESIGN", "SWAG_PILLS3 ENABLED", "False");
          this.FiletoFind.WriteValue("DESIGN", "SWAG_JEWELWATCH ENABLED", "False");
          this.FiletoFind.WriteValue("DESIGN", "SWAG_JEWELWATCH2 ENABLED", "False");
          this.FiletoFind.WriteValue("DESIGN", "SWAG_JEWELWATCH3 ENABLED", "False");
          this.FiletoFind.WriteValue("DESIGN", "SWAG_FURCOATS ENABLED", "False");
          this.FiletoFind.WriteValue("DESIGN", "SWAG_FURCOATS2 ENABLED", "False");
          this.FiletoFind.WriteValue("DESIGN", "SWAG_FURCOATS3 ENABLED", "False");
          this.FiletoFind.WriteValue("DESIGN", "SWAG_ART ENABLED", "False");
          this.FiletoFind.WriteValue("DESIGN", "SWAG_ART2 ENABLED", "False");
          this.FiletoFind.WriteValue("DESIGN", "SWAG_ART3 ENABLED", "False");
          this.FiletoFind.WriteValue("DESIGN", "SWAG_GUNS ENABLED", "False");
          this.FiletoFind.WriteValue("DESIGN", "SWAG_GUNS2 ENABLED", "False");
          this.FiletoFind.WriteValue("DESIGN", "SWAG_GUNS3 ENABLED", "False");
          this.FiletoFind.WriteValue("DESIGN", "SWAG_MED ENABLED", "False");
          this.FiletoFind.WriteValue("DESIGN", "SWAG_MED2 ENABLED", "False");
          this.FiletoFind.WriteValue("DESIGN", "SWAG_MED3 ENABLED", "False");
          this.FiletoFind.WriteValue("DESIGN", "SWAG_GEMS ENABLED", "False");
          this.FiletoFind.WriteValue("DESIGN", "SWAG_GEMS2 ENABLED", "False");
          this.FiletoFind.WriteValue("DESIGN", "SWAG_GEMS3 ENABLED", "False");
          this.FiletoFind.WriteValue("GARAGE", "PURCHASEDGARAGELEVEL1", "0");
          this.FiletoFind.WriteValue("GARAGE", "PURCHASEDGARAGELEVEL1", "0");
          this.FiletoFind.WriteValue("GARAGE", "PURCHASEDGARAGELEVEL1", "0");
          this.FiletoFind.WriteValue("GARAGE", "PURCHASEDGARAGEMODSHOP", "0");
          this.FiletoFind.WriteValue("CARGOWAREHOUSES", "WAREHOUSESOWNED", "0");
          this.FiletoFind.WriteValue("CARGOWAREHOUSES", "COLLECTIONSCOMPLETED", "0");
          this.FiletoFind.WriteValue("CARGOWAREHOUSES", "COLLECTIONSFAILED", "0");
          this.FiletoFind.WriteValue("CARGOWAREHOUSES-1", "WAREHOUSE1INDEX", "-1");
          this.FiletoFind.WriteValue("CARGOWAREHOUSES-1", "WAREHOUSE1STOCK", "0");
          this.FiletoFind.WriteValue("CARGOWAREHOUSES-1", "WAREHOUSE1SALESMADE", "0");
          this.FiletoFind.WriteValue("CARGOWAREHOUSES-1", "WAREHOUSE1SALESFAILED", "0");
          this.FiletoFind.WriteValue("CARGOWAREHOUSES-1", "WAREHOUSE1LIFETIMEEARNINGS", "0");
          this.FiletoFind.WriteValue("CARGOWAREHOUSES-2", "WAREHOUSE2INDEX", "-1");
          this.FiletoFind.WriteValue("CARGOWAREHOUSES-2", "WAREHOUSE2STOCK", "0");
          this.FiletoFind.WriteValue("CARGOWAREHOUSES-2", "WAREHOUSE2SALESMADE", "0");
          this.FiletoFind.WriteValue("CARGOWAREHOUSES-2", "WAREHOUSE2SALESFAILED", "0");
          this.FiletoFind.WriteValue("CARGOWAREHOUSES-2", "WAREHOUSE2LIFETIMEEARNINGS", "0");
          this.FiletoFind.WriteValue("CARGOWAREHOUSES-3", "WAREHOUSE3INDEX", "-1");
          this.FiletoFind.WriteValue("CARGOWAREHOUSES-3", "WAREHOUSE3STOCK", "0");
          this.FiletoFind.WriteValue("CARGOWAREHOUSES-3", "WAREHOUSE3SALESMADE", "0");
          this.FiletoFind.WriteValue("CARGOWAREHOUSES-3", "WAREHOUSE3SALESFAILED", "0");
          this.FiletoFind.WriteValue("CARGOWAREHOUSES-3", "WAREHOUSE3LIFETIMEEARNINGS", "0");
          this.FiletoFind.WriteValue("CARGOWAREHOUSES-4", "WAREHOUSE4INDEX", "-1");
          this.FiletoFind.WriteValue("CARGOWAREHOUSES-4", "WAREHOUSE4STOCK", "0");
          this.FiletoFind.WriteValue("CARGOWAREHOUSES-4", "WAREHOUSE4SALESMADE", "0");
          this.FiletoFind.WriteValue("CARGOWAREHOUSES-4", "WAREHOUSE4SALESFAILED", "0");
          this.FiletoFind.WriteValue("CARGOWAREHOUSES-4", "WAREHOUSE4LIFETIMEEARNINGS", "0");
          this.FiletoFind.WriteValue("CARGOWAREHOUSES-5", "WAREHOUSE5INDEX", "-1");
          this.FiletoFind.WriteValue("CARGOWAREHOUSES-5", "WAREHOUSE5STOCK", "0");
          this.FiletoFind.WriteValue("CARGOWAREHOUSES-5", "WAREHOUSE5SALESMADE", "0");
          this.FiletoFind.WriteValue("CARGOWAREHOUSES-5", "WAREHOUSE5SALESFAILED", "0");
          this.FiletoFind.WriteValue("CARGOWAREHOUSES-5", "WAREHOUSE5LIFETIMEEARNINGS", "0");
          this.FiletoFind.WriteValue("CARGOWAREHOUSES-MISC", "SOURCECRATECOSTMULTIPLIER", "1");
          this.FiletoFind.WriteValue("CARGOWAREHOUSES-MISC", "SELLCRATECOSTMULTIPLIER", "1");
          this.FiletoFind.WriteValue("CARGOWAREHOUSES-MISC", "SOURCECRATEAMTMULTIPLIER", "1");
          this.FiletoFind.WriteValue("CARGOWAREHOUSES-MISC", "SELLCRATEAMTMULTIPLIER", "1");
          this.FiletoFind.WriteValue("VEHICLEWAREHOUSES", "VEHICLEWAREHOUSEINDEX", "-1");
          this.FiletoFind.WriteValue("VEHICLEWAREHOUSES", "STYLE", "branded_style_set");
          this.FiletoFind.WriteValue("VEHICLEWAREHOUSES", "RUINER2000BOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLEWAREHOUSES", "RAMPBUGGYBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLEWAREHOUSES", "ABOXVILLEBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLEWAREHOUSES", "TECHNICALAQUABOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLEWAREHOUSES", "PHANTOMWBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLEWAREHOUSES", "RVOLTICBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLEWAREHOUSES", "BLAZERAQUABOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLEWAREHOUSES", "WASTELANDERBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLEWAREHOUSES", "VEHICLESEXPORTEDSUCCESS", "0");
          this.FiletoFind.WriteValue("VEHICLEWAREHOUSES", "VEHICLESEXPORTEDFAIL", "0");
          this.FiletoFind.WriteValue("VEHICLEWAREHOUSES", "VEHICLESTEALSUCCESS", "0");
          this.FiletoFind.WriteValue("VEHICLEWAREHOUSES", "VEHICLESTEALFAIL", "0");
          this.FiletoFind.WriteValue("VEHICLEWAREHOUSES", "VEHICLESSTOLENSUCCESS", "0");
          this.FiletoFind.WriteValue("VEHICLEWAREHOUSES", "VEHICLESSTOLENFAIL", "0");
          this.FiletoFind.WriteValue("VEHICLEWAREHOUSES", "TOTALEXPORTEARNINGS", "0");
          this.FiletoFind.WriteValue("VEHICLEWAREHOUSES", "VEHICLEWAREHOUSELOC", "-1");
          this.FiletoFind.WriteValue("VEHICLEWAREHOUSES", "VehicleWarehouseTotalEarnings", "0");
          this.print("#EndRead");
        }
        catch (Exception ex)
        {
          this.print("Error : Null Reference Execption!");
        }
      }
      catch (Exception ex)
      {
        this.print("Error : File Not Found!");
      }
    }

    public void ResetExecutiveWarehouse(string Ini)
    {
      try
      {
        try
        {
          this.print("#StartRead");
          this.FiletoFind.Open(Ini, false);
          for (int index = 1; index < 17; ++index)
            this.FiletoFind.WriteValue("CRATES-SMALL-WAREHOUSE", "CRATEID_" + index.ToString(), "-1");
          for (int index = 17; index < 43; ++index)
            this.FiletoFind.WriteValue("CRATES-MEDIUM-WAREHOUSE", "CRATEID_" + index.ToString(), "-1");
          for (int index = 43; index < 112; ++index)
            this.FiletoFind.WriteValue("CRATES-MEDIUM-WAREHOUSE", "CRATEID_" + index.ToString(), "-1");
          this.print("#EndRead");
        }
        catch (Exception ex)
        {
          this.print("Error : Null Reference Execption!");
        }
      }
      catch (Exception ex)
      {
        this.print("Error : File Not Found!");
      }
    }

    public void ResetBikerBusinessOption(string Ini)
    {
      try
      {
        try
        {
          this.print("#StartRead");
          this.FiletoFind.Open(Ini, false);
          this.FiletoFind.WriteValue("SETUP", "BUISNESSLEVEL", "0");
          this.FiletoFind.WriteValue("SETUP", "STOCKSLEVEL", "0");
          this.FiletoFind.WriteValue("SETUP", "STOCKSVALUE", "0");
          this.FiletoFind.WriteValue("SETUP", "DISPLAYWAIT", "0");
          this.FiletoFind.WriteValue("SETUP", "WAITTIME", "4000");
          this.FiletoFind.WriteValue("SETUP", "HEXERBOUGHT", "0");
          this.FiletoFind.WriteValue("SETUP", "SLAMVANBOUGHT", "0");
          this.FiletoFind.WriteValue("SETUP", "DUNEBOUGHT", "0");
          this.FiletoFind.WriteValue("SETUP", "DUNELOADERBOUGHT", "0");
          this.FiletoFind.WriteValue("SETUP", "ZOMBIECBOUGHT", "0");
          this.FiletoFind.WriteValue("SETUP", "ZOMBIEBBOUGHT", "0");
          this.FiletoFind.WriteValue("SETUP", "WOLFSBANEBOUGHT", "0");
          this.FiletoFind.WriteValue("SETUP", "RATBIKEBOUGHT", "0");
          this.FiletoFind.WriteValue("SETUP", "NIGHTBLADEBOUGHT", "0");
          this.FiletoFind.WriteValue("SETUP", "LCCDAEMONBOUGHT", "0");
          this.FiletoFind.WriteValue("SETUP", "DAEMONBOUGHT", "0");
          this.FiletoFind.WriteValue("SETUP", "INNOVATIONBOUGHT", "0");
          this.FiletoFind.WriteValue("SETUP", "SANCTUSBOUGHT", "0");
          this.FiletoFind.WriteValue("SETUP", "AVURUSBOUGHT", "0");
          this.FiletoFind.WriteValue("SETUP", "CHIMEABOUGHT", "0");
          this.FiletoFind.WriteValue("SETUP", "PURCHASEDSECONDBUSINESS", "0");
          this.FiletoFind.WriteValue("SETUP", "MONEYPRINTERBOUGHT", "0");
          this.FiletoFind.WriteValue("SETUP", "FORGERYBOUGHT", "0");
          this.FiletoFind.WriteValue("SETUP", "SHOWSTOCKINCREASE", "true");
          this.FiletoFind.WriteValue("SUBBUSINESS", "FORGERYBOUGHT", "0");
          this.FiletoFind.WriteValue("SUBBUSINESS", "WEEDFARMBOUGHT", "0");
          this.FiletoFind.WriteValue("SUBBUSINESS", "MONEYPRINTERBOUGHT", "0");
          this.FiletoFind.WriteValue("SUBBUSINESS", "METHLABBOUGHT", "0");
          this.FiletoFind.WriteValue("SUBBUSINESS", "COCAINEBOUGHT", "0");
          this.print("#EndRead");
        }
        catch (Exception ex)
        {
          this.print("Error : Null Reference Execption!");
        }
      }
      catch (Exception ex)
      {
        this.print("Error : File Not Found!");
      }
    }

    public void ResetArenaWarBusinessOption(string Ini)
    {
      try
      {
        try
        {
          this.print("#StartRead");
          this.FiletoFind.Open(Ini, false);
          this.FiletoFind.WriteValue("SETUP", "BUISNESSLEVEL", "0");
          this.FiletoFind.WriteValue("SETUP", "WAITTIME", "4000");
          this.FiletoFind.WriteValue("SETUP", "STOCKSLEVEL", "0");
          this.FiletoFind.WriteValue("SETUP", "STOCKSVALUE", "0");
          this.FiletoFind.WriteValue("SETUP", "DISPLAYWAIT", "0");
          this.FiletoFind.WriteValue("SETUP", "CURRENTCERBERUS", "1");
          this.FiletoFind.WriteValue("SETUP", "CURRENTSCARAB", "1");
          this.FiletoFind.WriteValue("SETUP", "CURRENTDOMINATOR", "1");
          this.FiletoFind.WriteValue("SETUP", "CURRENTIMPERATOR", "1");
          this.FiletoFind.WriteValue("SETUP", "CURRENTDEATHBIKE", "1");
          this.FiletoFind.WriteValue("SETUP", "GUNLOCKERBOUGHT", "0");
          this.FiletoFind.WriteValue("SETUP", "MONEYVAULTBOUGHT", "0");
          this.FiletoFind.WriteValue("SETUP", "MARKERCOLOR", "Magenta");
          this.FiletoFind.WriteValue("SETUP", "USEMISSILESINVDM", "true");
          this.FiletoFind.WriteValue("SETUP", "SHOWSTOCKINCREASE", "true");
          this.FiletoFind.WriteValue("VEHICLES", "NIGHTMAREIMPALERBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLES", "APOCALYPSEBRUTUSBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLES", "NIGHTMARECERBERUSBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLES", "APOCALYPSECERBERUSBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLES", "FUTURESHOCKCERBERUSBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLES", "NIGHTMARESCARABBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLES", "APOCALYPSESCARABBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLES", "FUTURESHOCKSCARABBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLES", "NIGHTMAREDOMINATORBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLES", "APOCALYPSEDOMINATORBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLES", "FUTURESHOCKDOMINATORBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTSLAMVAN", "0");
          this.FiletoFind.WriteValue("VEHICLES", "NIGHTMAREIMPERATORBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLES", "APOCALYPSEIMPERATORBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLES", "FUTURESHOCKIMPERATORBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLES", "NIGHTMAREDEATHBIKEBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLES", "APOCALYPSEDEATHBIKEBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLES", "FUTURESHOCKDEATHBIKEBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLES", "NIGHTMAREISSIBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLES", "APOCALYPSEISSIBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLES", "FUTURESHOCKISSIBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLES", "NIGHTMAREMONSTERBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLES", "APOCALYPSEMONSTERBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLES", "FUTURESHOCKMONSTERBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLES", "FUTURESHOCKMONSTERBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLES", "APOCALYPSEIMPALERBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLES", "FUTURESHOCKIMPALERBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLES", "NIGHTMARESLAMVANBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLES", "APOCALYPSESLAMVANBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLES", "FUTURESHOCKSLAMVANBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLES", "NIGHTMAREBRUTUSBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLES", "FUTURESHOCKBRUTUSBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTBRUISER", "0");
          this.FiletoFind.WriteValue("VEHICLES", "NIGHTMAREBRUISERBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLES", "APOCALYPSEBRUISERBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLES", "FUTURESHOCKBRUISERBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTZR380", "0");
          this.FiletoFind.WriteValue("VEHICLES", "NIGHTMAREZR380BOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLES", "APOCALYPSEZR380BOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLES", "FUTURESHOCKZR380BOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTCERBERUS", "0");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTSCARAB", "0");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTIMPALER", "0");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTDOMINATOR", "0");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTMONSTER", "0");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTIMPERATOR", "0");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTDEATHBIKE", "0");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTISSI", "0");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTBRUTUS", "0");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTBRUTUS", "0");
          this.FiletoFind.WriteValue("VEHICLES", "CLIQUEBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLES", "ITALIGTOBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTCERBERUS", "0");
          this.FiletoFind.WriteValue("VEHICLES", "TULIPBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLES", "DEVIANTBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLES", "SCHLAGENBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLES", "TOROSBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLES", "VAMOSBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLES", "DEVESTEBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLES", "RCBANDITOBOUGHT", "0");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTBRUITUS", "0");
          this.FiletoFind.WriteValue("ADDON2", "MONEYSTORED[1]", "0");
          this.FiletoFind.WriteValue("ADDON2", "MONEYSTORED[2]", "0");
          this.FiletoFind.WriteValue("ADDON2", "MONEYSTORED[3]", "0");
          this.FiletoFind.WriteValue("ADDON2", "MONEYSTORED[4]", "0");
          this.FiletoFind.WriteValue("ADDON2", "MONEYSTORED[5]", "0");
          this.FiletoFind.WriteValue("ADDON2", "MONEYSTORED[6]", "0");
          this.FiletoFind.WriteValue("ADDON2", "MONEYSTORED[7]", "0");
          this.FiletoFind.WriteValue("ADDON2", "MONEYSTORED[8]", "0");
          this.FiletoFind.WriteValue("ADDON2", "MONEYSTORED[9]", "0");
          this.FiletoFind.WriteValue("ADDON2", "MONEYSTORED[10]", "0");
          this.print("#EndRead");
        }
        catch (Exception ex)
        {
          this.print("Error : Null Reference Execption!");
        }
      }
      catch (Exception ex)
      {
        this.print("Error : File Not Found!");
      }
    }

    public void SourceAllArenaWarVehicles(string Ini)
    {
      try
      {
        try
        {
          this.print("#StartRead");
          this.FiletoFind.Open(Ini, false);
          this.FiletoFind.WriteValue("SETUP", "CURRENTCERBERUS", "1");
          this.FiletoFind.WriteValue("SETUP", "CURRENTSCARAB", "1");
          this.FiletoFind.WriteValue("SETUP", "CURRENTDOMINATOR", "1");
          this.FiletoFind.WriteValue("SETUP", "CURRENTIMPERATOR", "1");
          this.FiletoFind.WriteValue("SETUP", "CURRENTDEATHBIKE", "1");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTSLAMVAN", "1");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTBRUISER", "1");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTZR380", "1");
          this.FiletoFind.WriteValue("VEHICLES", "NIGHTMAREIMPALERBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "APOCALYPSEBRUTUSBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "NIGHTMARECERBERUSBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "APOCALYPSECERBERUSBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "FUTURESHOCKCERBERUSBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "NIGHTMARESCARABBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "APOCALYPSESCARABBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "FUTURESHOCKSCARABBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "NIGHTMAREDOMINATORBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "APOCALYPSEDOMINATORBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "FUTURESHOCKDOMINATORBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "NIGHTMAREIMPERATORBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "APOCALYPSEIMPERATORBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "FUTURESHOCKIMPERATORBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "NIGHTMAREDEATHBIKEBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "APOCALYPSEDEATHBIKEBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "FUTURESHOCKDEATHBIKEBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "NIGHTMAREISSIBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "APOCALYPSEISSIBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "FUTURESHOCKISSIBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "NIGHTMAREMONSTERBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "APOCALYPSEMONSTERBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "FUTURESHOCKMONSTERBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "FUTURESHOCKMONSTERBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "APOCALYPSEIMPALERBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "FUTURESHOCKIMPALERBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "NIGHTMARESLAMVANBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "APOCALYPSESLAMVANBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "FUTURESHOCKSLAMVANBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "NIGHTMAREBRUTUSBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "FUTURESHOCKBRUTUSBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "NIGHTMAREBRUISERBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "APOCALYPSEBRUISERBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "FUTURESHOCKBRUISERBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "NIGHTMAREZR380BOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "APOCALYPSEZR380BOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "FUTURESHOCKZR380BOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTCERBERUS", "1");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTSCARAB", "1");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTIMPALER", "1");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTDOMINATOR", "1");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTMONSTER", "1");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTIMPERATOR", "1");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTDEATHBIKE", "1");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTISSI", "1");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTBRUTUS", "1");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTBRUTUS", "1");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTBRUITUS", "1");
          this.print("#EndRead");
        }
        catch (Exception ex)
        {
          this.print("Error : Null Reference Execption!");
        }
      }
      catch (Exception ex)
      {
        this.print("Error : File Not Found!");
      }
    }

    public void SourceAllFutureShockArenaWarVehicles(string Ini)
    {
      try
      {
        try
        {
          this.print("#StartRead");
          this.FiletoFind.Open(Ini, false);
          this.FiletoFind.WriteValue("SETUP", "CURRENTCERBERUS", "3");
          this.FiletoFind.WriteValue("SETUP", "CURRENTSCARAB", "3");
          this.FiletoFind.WriteValue("SETUP", "CURRENTDOMINATOR", "3");
          this.FiletoFind.WriteValue("SETUP", "CURRENTIMPERATOR", "3");
          this.FiletoFind.WriteValue("SETUP", "CURRENTDEATHBIKE", "3");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTSLAMVAN", "3");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTBRUISER", "3");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTZR380", "3");
          this.FiletoFind.WriteValue("VEHICLES", "FUTURESHOCKCERBERUSBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "FUTURESHOCKSCARABBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "FUTURESHOCKDOMINATORBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "FUTURESHOCKIMPERATORBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "FUTURESHOCKDEATHBIKEBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "FUTURESHOCKISSIBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "FUTURESHOCKMONSTERBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "FUTURESHOCKMONSTERBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "FUTURESHOCKIMPALERBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "FUTURESHOCKSLAMVANBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "FUTURESHOCKBRUTUSBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "FUTURESHOCKBRUISERBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "FUTURESHOCKZR380BOUGHT", "3");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTCERBERUS", "3");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTSCARAB", "3");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTIMPALER", "3");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTDOMINATOR", "3");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTMONSTER", "3");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTIMPERATOR", "3");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTDEATHBIKE", "3");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTISSI", "3");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTBRUTUS", "3");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTBRUTUS", "3");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTBRUITUS", "3");
          this.print("#EndRead");
        }
        catch (Exception ex)
        {
          this.print("Error : Null Reference Execption!");
        }
      }
      catch (Exception ex)
      {
        this.print("Error : File Not Found!");
      }
    }

    public void SourceAllNightmareArenaWarVehicles(string Ini)
    {
      try
      {
        try
        {
          this.print("#StartRead");
          this.FiletoFind.Open(Ini, false);
          this.FiletoFind.WriteValue("SETUP", "CURRENTCERBERUS", "2");
          this.FiletoFind.WriteValue("SETUP", "CURRENTSCARAB", "2");
          this.FiletoFind.WriteValue("SETUP", "CURRENTDOMINATOR", "2");
          this.FiletoFind.WriteValue("SETUP", "CURRENTIMPERATOR", "2");
          this.FiletoFind.WriteValue("SETUP", "CURRENTDEATHBIKE", "2");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTSLAMVAN", "2");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTBRUISER", "2");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTZR380", "2");
          this.FiletoFind.WriteValue("VEHICLES", "NIGHTMAREIMPALERBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "NIGHTMARECERBERUSBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "NIGHTMARESCARABBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "NIGHTMAREDOMINATORBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "NIGHTMAREIMPERATORBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "NIGHTMAREDEATHBIKEBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "NIGHTMAREISSIBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "NIGHTMAREMONSTERBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "NIGHTMARESLAMVANBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "NIGHTMAREBRUTUSBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "NIGHTMAREBRUISERBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "NIGHTMAREZR380BOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTCERBERUS", "2");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTSCARAB", "2");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTIMPALER", "2");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTDOMINATOR", "2");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTMONSTER", "2");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTIMPERATOR", "2");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTDEATHBIKE", "2");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTISSI", "2");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTBRUTUS", "2");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTBRUTUS", "2");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTBRUITUS", "2");
          this.print("#EndRead");
        }
        catch (Exception ex)
        {
          this.print("Error : Null Reference Execption!");
        }
      }
      catch (Exception ex)
      {
        this.print("Error : File Not Found!");
      }
    }

    public void SourceAllApocalypseArenaWarVehicles(string Ini)
    {
      try
      {
        try
        {
          this.print("#StartRead");
          this.FiletoFind.Open(Ini, false);
          this.FiletoFind.WriteValue("SETUP", "CURRENTCERBERUS", "1");
          this.FiletoFind.WriteValue("SETUP", "CURRENTSCARAB", "1");
          this.FiletoFind.WriteValue("SETUP", "CURRENTDOMINATOR", "1");
          this.FiletoFind.WriteValue("SETUP", "CURRENTIMPERATOR", "1");
          this.FiletoFind.WriteValue("SETUP", "CURRENTDEATHBIKE", "1");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTSLAMVAN", "1");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTBRUISER", "1");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTZR380", "1");
          this.FiletoFind.WriteValue("VEHICLES", "APOCALYPSEBRUTUSBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "APOCALYPSECERBERUSBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "APOCALYPSESCARABBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "APOCALYPSEDOMINATORBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "APOCALYPSEIMPERATORBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "APOCALYPSEDEATHBIKEBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "FUTURESHOCKDEATHBIKEBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "APOCALYPSEISSIBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "APOCALYPSEMONSTERBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "APOCALYPSEIMPALERBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "APOCALYPSESLAMVANBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "APOCALYPSEBRUISERBOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "APOCALYPSEZR380BOUGHT", "1");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTCERBERUS", "1");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTSCARAB", "1");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTIMPALER", "1");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTDOMINATOR", "1");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTMONSTER", "1");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTIMPERATOR", "1");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTDEATHBIKE", "1");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTISSI", "1");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTBRUTUS", "1");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTBRUTUS", "1");
          this.FiletoFind.WriteValue("VEHICLES", "CURRENTBRUITUS", "1");
          this.print("#EndRead");
        }
        catch (Exception ex)
        {
          this.print("Error : Null Reference Execption!");
        }
      }
      catch (Exception ex)
      {
        this.print("Error : File Not Found!");
      }
    }

    public void ResetDoomsdayHeistBusinessOption(string Ini)
    {
      try
      {
        try
        {
          this.print("#StartRead");
          this.FiletoFind.Open(Ini, false);
          this.FiletoFind.WriteValue("SETUP", "BUISNESSLEVEL", "0");
          this.FiletoFind.WriteValue("SETUP", "STOCKSLEVEL", "0");
          this.FiletoFind.WriteValue("SETUP", "STOCKSVALUE", "0");
          this.FiletoFind.WriteValue("SETUP", "DISPLAYWAIT", "0");
          this.FiletoFind.WriteValue("EXTRA", "GUNLOCKERBOUGHT", "0");
          this.FiletoFind.WriteValue("EXTRA", "VEHICLEBAYBOUGHT", "0");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "AVENGERBOUGHT", "1");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "AKULABOUGHT", "1");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "THRUSTERBOUGHT", "1");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "CHERNOBOGBOUGHT", "1");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "BARRAGEBOUGHT", "1");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "DELUXOBOUGHT", "1");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "STROMBERGBOUGHT", "1");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "KHANJALIBOUGHT", "1");
          this.FiletoFind.WriteValue("PRIVACYGLASS", "PRIVACYGLASSON", "false");
          this.FiletoFind.WriteValue("PRIVACYGLASS", "PRIVACYGLASSBOUGHT", "0");
          this.print("#EndRead");
        }
        catch (Exception ex)
        {
          this.print("Error : Null Reference Execption!");
        }
      }
      catch (Exception ex)
      {
        this.print("Error : File Not Found!");
      }
    }

    public void ResetGunrunningBusinessOption(string Ini)
    {
      try
      {
        try
        {
          this.print("#StartRead");
          this.FiletoFind.Open(Ini, false);
          this.FiletoFind.WriteValue("SETUP", "BUISNESSLEVEL", "0");
          this.FiletoFind.WriteValue("SETUP", "STOCKSLEVEL", "0");
          this.FiletoFind.WriteValue("SETUP", "STOCKSVALUE", "0");
          this.FiletoFind.WriteValue("SETUP", "DISPLAYWAIT", "0");
          this.FiletoFind.WriteValue("EXTRA", "GUNLOCKERBOUGHT", "0");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "APC", "0");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "APCBOUGHT", "0");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "DUNEFAV", "0");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "DUNEFAVBOUGHT", "0");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "HALFTRACK", "0");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "HALFTRACKBOUGHT", "0");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "INSURGENT3", "0");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "INSURGENT3BOUGHT", "0");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "OPPRESSOR", "0");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "OPPRESSORBOUGHT", "0");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "TECHNICAL3", "0");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "TECHNICAL3BOUGHT", "0");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "NIGHTSHARK", "0");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "NIGHTSHARKBOUGHT", "0");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "TAMPA3", "0");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "TAMPA3BOUGHT", "0");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "TRAILERSMALL2", "0");
          this.FiletoFind.WriteValue("DISRUPTIONLOGISTICS", "BUNKEROPERATIONSTATUS", "0");
          this.FiletoFind.WriteValue("DISRUPTIONLOGISTICS", "STOCKLEVEL", "0");
          this.FiletoFind.WriteValue("DISRUPTIONLOGISTICS", "RESEARCHPROGRESS", "0");
          this.FiletoFind.WriteValue("DISRUPTIONLOGISTICS", "SUPPLIESLEVEL", "0");
          this.FiletoFind.WriteValue("DISRUPTIONLOGISTICS", "TOTALEARNINGS", "0");
          this.FiletoFind.WriteValue("DISRUPTIONLOGISTICS", "TOTALSALES", "0");
          this.FiletoFind.WriteValue("DISRUPTIONLOGISTICS", "RESUPPLYSUCCESS", "0");
          this.FiletoFind.WriteValue("DISRUPTIONLOGISTICS", "RESUPPLYFAILS", "0");
          this.FiletoFind.WriteValue("DISRUPTIONLOGISTICS", "SELLSUCCESS_BCSUCCESS", "0");
          this.FiletoFind.WriteValue("DISRUPTIONLOGISTICS", "SELLSUCCESS_BCFAILS", "0");
          this.FiletoFind.WriteValue("DISRUPTIONLOGISTICS", "SELLSUCCESS_LSSUCCESS", "0");
          this.FiletoFind.WriteValue("DISRUPTIONLOGISTICS", "SELLSUCCESS_LSFAILS", "0");
          this.FiletoFind.WriteValue("DISRUPTIONLOGISTICS", "RESEARCHCOMPLETEDCRT", "0");
          this.FiletoFind.WriteValue("DISRUPTIONLOGISTICS", "UNITSMANUFACTURED", "0");
          this.FiletoFind.WriteValue("DISRUPTIONLOGISTICS", "STAFFASSIGNMENT", "1");
          this.FiletoFind.WriteValue("DISRUPTIONLOGISTICS", "UPGRADE1UNLOCKED", "2");
          this.FiletoFind.WriteValue("DISRUPTIONLOGISTICS", "UPGRADE2UNLOCKED", "2");
          this.FiletoFind.WriteValue("DISRUPTIONLOGISTICS", "UPGRADE3UNLOCKED", "2");
          this.FiletoFind.WriteValue("DISRUPTIONLOGISTICS-MISC", "BNKR_MULTIPLIERSELL", "1");
          this.FiletoFind.WriteValue("DISRUPTIONLOGISTICS-MISC", "BNKR_MULTIPLIERBUYCRATE", "1");
          this.FiletoFind.WriteValue("DISRUPTIONLOGISTICS-MISC", "BNKR_MULTIPLIERBUYFT", "1");
          this.FiletoFind.WriteValue("DISRUPTIONLOGISTICS-MISC", "BNKR_MULTIPLIERUPG", "1");
          this.FiletoFind.WriteValue("RESEARCH", "NAVAL_BATTLE_LIVERY_SET", "False");
          this.FiletoFind.WriteValue("RESEARCH", "FRACTAL_LIVERY_SET", "False");
          this.FiletoFind.WriteValue("RESEARCH", "GEOMETRIC_LIVERY_SET", "False");
          this.FiletoFind.WriteValue("RESEARCH", "NATURE_RESERVE_LIVERY_SET", "False");
          this.FiletoFind.WriteValue("RESEARCH", "DIGITAL_LIVERY_SET", "False");
          this.FiletoFind.WriteValue("RESEARCH", "WEAPONIZED_TAMPA_DUAL_REMOTE_MINIGUN", "False");
          this.FiletoFind.WriteValue("RESEARCH", "HALFTRACK_20MM_QUAD_AUTOCANNON", "False");
          this.FiletoFind.WriteValue("RESEARCH", "JUGGERNAUT_SUIT", "False");
          this.FiletoFind.WriteValue("RESEARCH", "WEAPONIZED_TAMPA_FRONT_MISSILE_LAUNCHERS", "False");
          this.FiletoFind.WriteValue("RESEARCH", "DUNE_FAV_7.62MM_MINIGUN", "False");
          this.FiletoFind.WriteValue("RESEARCH", "TECHNICAL_CUSTOM_RAM - BAR", "False");
          this.FiletoFind.WriteValue("RESEARCH", "TECHNICAL_CUSTOM_HEAVY_CHASSIS_UPGRADE", "False");
          this.FiletoFind.WriteValue("RESEARCH", "APC_SAM_BATTERY", "False");
          this.FiletoFind.WriteValue("RESEARCH", "WEAPONIZED_TAMPA_REAR - FIRING_MORTAR", "False");
          this.FiletoFind.WriteValue("RESEARCH", "WEAPONIZED_TAMPA_HEAVY_CHASSIS_UPGRADE", "False");
          this.FiletoFind.WriteValue("RESEARCH", "DUNE_FAV_40MM_GRENADE_LAUNCHER", "False");
          this.FiletoFind.WriteValue("RESEARCH", "INSURGENT_PICK - UP_CUSTOM_.50_CAL_MINIGUN", "False");
          this.FiletoFind.WriteValue("RESEARCH", "INSURGENT_PICK - UP_CUSTOM_HEAVY_ARMOR_PLATING", "False");
          this.FiletoFind.WriteValue("RESEARCH", "TECHNICAL_CUSTOM_7.62MM_MINIGUN", "False");
          this.FiletoFind.WriteValue("RESEARCH", "TECHNICAL_CUSTOM_BRUTE - BAR", "False");
          this.FiletoFind.WriteValue("RESEARCH", "OPPRESSOR_MISSILE_LAUNCHERS", "False");
          this.FiletoFind.WriteValue("MOC", "BOUGHT", "0");
          this.print("#EndRead");
        }
        catch (Exception ex)
        {
          this.print("Error : Null Reference Execption!");
        }
      }
      catch (Exception ex)
      {
        this.print("Error : File Not Found!");
      }
    }

    public void SourceAllDoomsdayHeistVehicles(string Ini)
    {
      try
      {
        try
        {
          this.print("#StartRead");
          this.FiletoFind.Open(Ini, false);
          this.FiletoFind.WriteValue("EXTRA", "VEHICLEBAYBOUGHT", "1");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "AVENGERBOUGHT", "1");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "AKULABOUGHT", "1");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "THRUSTERBOUGHT", "1");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "CHERNOBOGBOUGHT", "1");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "BARRAGEBOUGHT", "1");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "DELUXOBOUGHT", "1");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "STROMBERGBOUGHT", "1");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "KHANJALIBOUGHT", "1");
          this.print("#EndRead");
        }
        catch (Exception ex)
        {
          this.print("Error : Null Reference Execption!");
        }
      }
      catch (Exception ex)
      {
        this.print("Error : File Not Found!");
      }
    }

    public void SourceAllGunrunningVehicles(string Ini)
    {
      try
      {
        try
        {
          this.print("#StartRead");
          this.FiletoFind.Open(Ini, false);
          this.FiletoFind.WriteValue("EXTRA", "VEHICLEBAYBOUGHT", "1");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "APC", "1");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "APCBOUGHT", "1");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "DUNEFAV", "1");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "DUNEFAVBOUGHT", "1");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "HALFTRACK", "1");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "HALFTRACKBOUGHT", "1");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "INSURGENT3", "1");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "INSURGENT3BOUGHT", "1");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "OPPRESSOR", "1");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "OPPRESSORBOUGHT", "1");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "TECHNICAL3", "1");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "TECHNICAL3BOUGHT", "1");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "NIGHTSHARK", "1");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "NIGHTSHARKBOUGHT", "1");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "TAMPA3", "1");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "TAMPA3BOUGHT", "1");
          this.FiletoFind.WriteValue("SPECIALVEHICLES", "TRAILERSMALL2", "1");
          this.FiletoFind.WriteValue("MOC", "BOUGHT", "1");
          this.print("#EndRead");
        }
        catch (Exception ex)
        {
          this.print("Error : Null Reference Execption!");
        }
      }
      catch (Exception ex)
      {
        this.print("Error : File Not Found!");
      }
    }

    public void ResetSmugglersRunBusinessOption(string Ini)
    {
      try
      {
        try
        {
          this.print("#StartRead");
          this.FiletoFind.Open(Ini, false);
          this.FiletoFind.WriteValue("SETUP", "BUISNESSLEVEL", "0");
          this.FiletoFind.WriteValue("SETUP", "STOCKSLEVEL", "0");
          this.FiletoFind.WriteValue("SETUP", "STOCKSVALUE", "0");
          this.FiletoFind.WriteValue("SETUP", "DISPLAYWAIT", "0");
          this.FiletoFind.WriteValue("EXTRA", "GUNLOCKERBOUGHT", "0");
          this.FiletoFind.WriteValue("EXTRA", "VEHICLEBAYBOUGHT", "0");
          this.FiletoFind.WriteValue("EXTRACARS", "CYCLONEBOUGHT", "0");
          this.FiletoFind.WriteValue("EXTRACARS", "RAPIDGTBOUGHT", "0");
          this.FiletoFind.WriteValue("EXTRACARS", "RETINUEBOUGHT", "0");
          this.FiletoFind.WriteValue("EXTRACARS", "VISIONEBOUGHT", "0");
          this.FiletoFind.WriteValue("FREETRADESHIPPING", "STEALSCOMPLETED", "0");
          this.FiletoFind.WriteValue("FREETRADESHIPPING", "STEALSFAILED", "0");
          this.FiletoFind.WriteValue("FREETRADESHIPPING", "SALESCOMPLETED", "0");
          this.FiletoFind.WriteValue("FREETRADESHIPPING", "SALESFAILED", "0");
          this.FiletoFind.WriteValue("FREETRADESHIPPING", "MAXCRATESPERCARGO", "50");
          this.FiletoFind.WriteValue("FREETRADESHIPPING", "NARCOTICS_CURRENTSTOCK", "0");
          this.FiletoFind.WriteValue("FREETRADESHIPPING", "NARCOTICS_STOCKMAX", "50");
          this.FiletoFind.WriteValue("FREETRADESHIPPING", "CHEMICALS_CURRENTSTOCK", "0");
          this.FiletoFind.WriteValue("FREETRADESHIPPING", "CHEMICALS_STOCKMAX", "50");
          this.FiletoFind.WriteValue("FREETRADESHIPPING", "MEDICALSUPPLIES_CURRENTSTOCK", "0");
          this.FiletoFind.WriteValue("FREETRADESHIPPING", "MEDICALSUPPLIES_STOCKMAX", "50");
          this.FiletoFind.WriteValue("FREETRADESHIPPING", "ANIMALMATERIALS_CURRENTSTOCK", "0");
          this.FiletoFind.WriteValue("FREETRADESHIPPING", "ANIMALMATERIALS_STOCKMAX", "50");
          this.FiletoFind.WriteValue("FREETRADESHIPPING", "ARTAANTIQUES_CURRENTSTOCK", "0");
          this.FiletoFind.WriteValue("FREETRADESHIPPING", "ARTAANTIQUES_STOCKMAX", "50");
          this.FiletoFind.WriteValue("FREETRADESHIPPING", "JEWELRYAGEMSTONES_CURRENTSTOCK", "0");
          this.FiletoFind.WriteValue("FREETRADESHIPPING", "JEWELRYAGEMSTONES_STOCKMAX", "50");
          this.FiletoFind.WriteValue("FREETRADESHIPPING", "TABACCOAALCOHOL_CURRENTSTOCK", "0");
          this.FiletoFind.WriteValue("FREETRADESHIPPING", "TABACCOAALCOHOL_STOCKMAX", "50");
          this.FiletoFind.WriteValue("FREETRADESHIPPING", "COUNTERFEITGOODS_CURRENTSTOCK", "0");
          this.FiletoFind.WriteValue("FREETRADESHIPPING", "COUNTERFEITGOODS_STOCKMAX", "50");
          this.FiletoFind.WriteValue("FREETRADESHIPPING", "RIVALCRATESSTOLEN", "0");
          this.FiletoFind.WriteValue("FREETRADESHIPPING", "EARNINGS", "0");
          this.FiletoFind.WriteValue("FREETRADESHIPPING", "SELLMULTIPLIER", "1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_1", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_2", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_3", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_4", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_5", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_6", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_7", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_8", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_9", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_10", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_11", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_12", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_13", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_14", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_15", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_16", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_17", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_18", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_19", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_20", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_21", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_22", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_23", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_24", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_25", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_26", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_27", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_28", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_29", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_30", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_31", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_32", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_33", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_34", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_35", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_36", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_37", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_38", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_39", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_40", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_41", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_42", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_43", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_44", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_45", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_46", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_47", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_48", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_49", "-1");
          this.FiletoFind.WriteValue("FREETRADESHIPPING_CRATES", "CRATEID_50", "-1");
          this.FiletoFind.WriteValue("SETUP", "UNRESTICTEDACCESSINFORTZANCUDO", "0");
          this.FiletoFind.WriteValue("SETUP", "UNRESTICTEDACCESSINFORTZANCUDOVIP", "0");
          this.print("#EndRead");
        }
        catch (Exception ex)
        {
          this.print("Error : Null Reference Execption!");
        }
      }
      catch (Exception ex)
      {
        this.print("Error : File Not Found!");
      }
    }

    public void ResetLCCBusinessOption(string Ini)
    {
      try
      {
        try
        {
          this.print("#StartRead");
          this.FiletoFind.Open(Ini, false);
          this.FiletoFind.WriteValue("SETUP", "BUISNESSLEVEL", "0");
          this.FiletoFind.WriteValue("SETUP", "STOCKSLEVEL", "0");
          this.FiletoFind.WriteValue("SETUP", "STOCKSVALUE", "0");
          this.FiletoFind.WriteValue("SETUP", "DISPLAYWAIT", "0");
          this.FiletoFind.WriteValue("SETUP", "CLEARVEHICLSINRIVALSRACE", "false");
          this.print("#EndRead");
        }
        catch (Exception ex)
        {
          this.print("Error : Null Reference Execption!");
        }
      }
      catch (Exception ex)
      {
        this.print("Error : File Not Found!");
      }
    }

    public void ResetAGarage(string Path, int Slots)
    {
      try
      {
        this.print("#StartRead");
        int num1 = Slots;
        string str = "\\Slot";
        int num2 = num1 + 1;
        for (int index = 1; index < num2; ++index)
        {
          string Ini = Path + str + index.ToString() + ".ini";
          try
          {
            this.FiletoFind.Open(Ini, false);
            this.FiletoFind.WriteValue("CONFIGURATIONS", "VEHICLENAME", "null");
          }
          catch (Exception ex)
          {
            this.print("Error : Null Reference Execption!");
          }
        }
        this.print("#EndRead");
      }
      catch (Exception ex)
      {
        this.print("Error : File Not Found!");
      }
    }

    public void ResetDCARBusiness(string Path)
    {
      this.print("#StartRead");
      this.FiletoFind.Open(Path, false);
      this.FiletoFind.WriteValue("SETUP", "BUISNESSLEVEL", "0");
      this.FiletoFind.WriteValue("SETUP", "STOCKSLEVEL", "0");
      this.FiletoFind.WriteValue("SETUP", "STOCKSVALUE", "0");
      this.FiletoFind.WriteValue("SETUP", "DISPLAYWAIT", "0");
      this.FiletoFind.WriteValue("SETUP", "CASINOI_UPGRADE_LEVEL", "0");
      this.FiletoFind.WriteValue("SETUP", "CHIPS_AMOUNT", "0");
      this.FiletoFind.WriteValue("SETUP", "THRAXUNLOCKED", "0");
      this.FiletoFind.WriteValue("SETUP", "DIS_UNLOCKED", "0");
      this.FiletoFind.WriteValue("ADDON2", "MONEYSTORED", "0");
      this.FiletoFind.WriteValue("ADDON2", "COMMISSION", "0");
      this.FiletoFind.WriteValue("ADDON2", "KEY3", "E");
      this.FiletoFind.WriteValue("MISC", "HOSTNAME", "Tao Cheng");
      this.FiletoFind.WriteValue("MISC", "UICOLOUR", "p");
      this.FiletoFind.WriteValue("PENTHOUSE", "PENTHOUSE_STYLE", "1");
      this.FiletoFind.WriteValue("PENTHOUSE", "PENTHOUSE_MEDIA", "0");
      this.FiletoFind.WriteValue("PENTHOUSE", "PENTHOUSE_SPA", "0");
      this.FiletoFind.WriteValue("PENTHOUSE", "PENTHOUSE_BAR", "0");
      this.FiletoFind.WriteValue("PENTHOUSE", "PENTHOUSE_COLOUR", "0");
      this.FiletoFind.WriteValue("PENTHOUSE", "PENTHOUSE_ARCADE", "0");
      this.FiletoFind.WriteValue("PENTHOUSE", "PENTHOUSE_BARLIGHT", "0");
      this.FiletoFind.WriteValue("PENTHOUSE", "PENTHOUSE_POKERDEALER", "0");
      this.FiletoFind.WriteValue("PENTHOUSE", "PENTHOUSE_EXTRABEDROOM", "0");
      this.FiletoFind.WriteValue("PENTHOUSE", "PEDTYPE", "0");
      this.FiletoFind.WriteValue("PENTHOUSE", "TERRACEPEDTYPE", "0");
      this.FiletoFind.WriteValue("INTERIOR PEDS", "RANDOMWANDERPEDS", "True");
      this.FiletoFind.WriteValue("INTERIOR PEDS", "MAINPEDS", "True");
      this.FiletoFind.WriteValue("INTERIOR PEDS", "SLOTPEDS", "True");
      this.FiletoFind.WriteValue("INTERIOR PEDS", "MAINWANDERPEDS", "True");
      this.FiletoFind.WriteValue("INTERIOR PEDS", "BARPEDS", "True");
      this.FiletoFind.WriteValue("CARDDECK", "PLAYERDECK", "1");
      this.FiletoFind.WriteValue("CARDDECK", "ELITEDECKUNLOCKED", "0");
      this.FiletoFind.WriteValue("CARDDECK -TMD", "TMDUNLOCKED", "0");
      this.FiletoFind.WriteValue("CARDDECK - TMD", "TMD_USENORMALDECKCARDS", "True");
      this.FiletoFind.WriteValue("CARDDECK - TMD", "TMD_USENORMALDECKCARDS", "True");
      this.FiletoFind.WriteValue("CARDDECK - TMD", "TMD_USEACE", "True");
      this.FiletoFind.WriteValue("CARDDECK - TMD", "TMD_USEKING", "True");
      this.FiletoFind.WriteValue("CARDDECK - TMD", "TMD_USEQUEEN", "True");
      this.FiletoFind.WriteValue("CARDDECK - TMD", "TMD_USEJACK", "True");
      this.FiletoFind.WriteValue("CARDDECK - TMD", "TMD_USE02", "True");
      this.FiletoFind.WriteValue("CARDDECK - TMD", "TMD_USE03", "True");
      this.FiletoFind.WriteValue("CARDDECK - TMD", "TMD_USE04", "True");
      this.FiletoFind.WriteValue("CARDDECK - TMD", "TMD_USE05", "True");
      this.FiletoFind.WriteValue("CARDDECK - TMD", "TMD_USE06", "True");
      this.FiletoFind.WriteValue("CARDDECK - TMD", "TMD_USE07", "True");
      this.FiletoFind.WriteValue("CARDDECK - TMD", "TMD_USE08", "True");
      this.FiletoFind.WriteValue("CARDDECK - TMD", "TMD_USE09", "True");
      this.FiletoFind.WriteValue("CARDDECK - TMD", "TMD_USE10", "True");
      this.FiletoFind.WriteValue("CARDDECK - TMD", "TMD_DEALER", "False");
      this.FiletoFind.WriteValue("ARCADE", "ARCADEOWNED", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADEBUSINESSLEVEL", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADEVERSION", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADEFLOODID", "0");
      this.FiletoFind.WriteValue("ARCADE", "MURALID", "0");
      this.FiletoFind.WriteValue("ARCADE", "NEONARTID", "0");
      this.FiletoFind.WriteValue("ARCADE", "PUSHIEID", "0");
      this.FiletoFind.WriteValue("ARCADE", "NEONMURAL", "false");
      this.FiletoFind.WriteValue("ARCADE", "UNLOCKEDDILLLEQUIPMENT", "0");
      this.FiletoFind.WriteValue("ARCADE", "UNLOCKEDBREACHINGEQUIPMENT", "0");
      this.FiletoFind.WriteValue("ARCADE", "UNLOCKEDOUTFITSEQUIPMENT", "0");
      this.FiletoFind.WriteValue("ARCADE", "UNLOCKEDPLANSEQUIPMENT", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADEMONEYVAULT", "0");
      this.FiletoFind.WriteValue("ARCADE", "UNDERGRONDAREALOCKED", "0");
      this.FiletoFind.WriteValue("ARCADE", "UNLOCKEDHACKINGEQUIPMENT", "0");
      this.FiletoFind.WriteValue("ARCADE", "UNLOCKEDGARAGE", "0");
      this.FiletoFind.WriteValue("ARCADE", "UNLOCKEDGUNLOCKER", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADE1VER", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADE2VER", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADE3VER", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADE4VER", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADE5VER", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADE6VER", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADE7VER", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADE8VER", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADE9VER", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADE10VER", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADE11VER", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADE12VER", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADE13VER", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADE14VER", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADE15VER", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADE16VER", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADE17VER", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADE18VER", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADE19VER", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADE20VER", "0");
      this.FiletoFind.WriteValue("ARCADE", "PLAYRADIOMUSIC", "false");
      this.FiletoFind.WriteValue("ARCADE", "DEFAULTRADIOSTATION ", "1_Non-Stop-Pop FM");
      this.FiletoFind.WriteValue("ARCADE", "CURRENTRADIOSTATION", "1");
      this.FiletoFind.WriteValue("ARCADE", "ARCADESTYLE", "0");
      this.FiletoFind.WriteValue("ARCADE", "RADIOON", "False");
      this.FiletoFind.WriteValue("ARCADE", "ARCADECLUTTER", "False");
      this.print("#EndRead");
    }

    public void ResetDCARARCADE(string Path)
    {
      this.print("#StartRead");
      this.FiletoFind.Open(Path, false);
      this.FiletoFind.WriteValue("ARCADE", "ARCADEOWNED", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADEBUSINESSLEVEL", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADEVERSION", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADEFLOODID", "0");
      this.FiletoFind.WriteValue("ARCADE", "MURALID", "0");
      this.FiletoFind.WriteValue("ARCADE", "NEONARTID", "0");
      this.FiletoFind.WriteValue("ARCADE", "PUSHIEID", "0");
      this.FiletoFind.WriteValue("ARCADE", "NEONMURAL", "false");
      this.FiletoFind.WriteValue("ARCADE", "UNLOCKEDDILLLEQUIPMENT", "0");
      this.FiletoFind.WriteValue("ARCADE", "UNLOCKEDBREACHINGEQUIPMENT", "0");
      this.FiletoFind.WriteValue("ARCADE", "UNLOCKEDOUTFITSEQUIPMENT", "0");
      this.FiletoFind.WriteValue("ARCADE", "UNLOCKEDPLANSEQUIPMENT", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADEMONEYVAULT", "0");
      this.FiletoFind.WriteValue("ARCADE", "UNDERGRONDAREALOCKED", "0");
      this.FiletoFind.WriteValue("ARCADE", "UNLOCKEDHACKINGEQUIPMENT", "0");
      this.FiletoFind.WriteValue("ARCADE", "UNLOCKEDGARAGE", "0");
      this.FiletoFind.WriteValue("ARCADE", "UNLOCKEDGUNLOCKER", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADE1VER", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADE2VER", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADE3VER", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADE4VER", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADE5VER", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADE6VER", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADE7VER", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADE8VER", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADE9VER", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADE10VER", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADE11VER", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADE12VER", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADE13VER", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADE14VER", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADE15VER", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADE16VER", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADE17VER", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADE18VER", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADE19VER", "0");
      this.FiletoFind.WriteValue("ARCADE", "ARCADE20VER", "0");
      this.FiletoFind.WriteValue("ARCADE", "PLAYRADIOMUSIC", "false");
      this.FiletoFind.WriteValue("ARCADE", "DEFAULTRADIOSTATION ", "1_Non-Stop-Pop FM");
      this.FiletoFind.WriteValue("ARCADE", "CURRENTRADIOSTATION", "1");
      this.FiletoFind.WriteValue("ARCADE", "ARCADESTYLE", "0");
      this.FiletoFind.WriteValue("ARCADE", "RADIOON", "False");
      this.FiletoFind.WriteValue("ARCADE", "ARCADECLUTTER", "False");
      this.print("#EndRead");
    }

    public void ResetAfterHoursHeavyStorage(string Path)
    {
      this.print("#StartRead");
      this.FiletoFind.Open(Path, false);
      this.FiletoFind.WriteValue("SETUP", "BUISNESSLEVEL", "0");
      this.FiletoFind.WriteValue("SETUP", "STOCKSLEVEL", "0");
      this.FiletoFind.WriteValue("SETUP", "STOCKSVALUE", "0");
      this.FiletoFind.WriteValue("SETUP", "DISPLAYWAIT", "0");
      this.FiletoFind.WriteValue("SETUP", "CASINOI_UPGRADE_LEVEL", "0");
      this.FiletoFind.WriteValue("SETUP", "CHIPS_AMOUNT", "0");
      this.FiletoFind.WriteValue("SETUP", "THRAXUNLOCKED", "0");
      this.FiletoFind.WriteValue("SETUP", "DIS_UNLOCKED", "0");
      this.FiletoFind.WriteValue("ADDON2", "MONEYSTORED", "0");
      this.FiletoFind.WriteValue("ADDON2", "COMMISSION", "0");
      this.FiletoFind.WriteValue("ADDON2", "KEY3", "E");
      this.FiletoFind.WriteValue("MISC", "HOSTNAME", "Gay Tony");
      this.FiletoFind.WriteValue("MISC", "UICOLOUR", "p");
      this.FiletoFind.WriteValue("PENTHOUSE", "PENTHOUSE_STYLE", "1");
      this.FiletoFind.WriteValue("PENTHOUSE", "PENTHOUSE_MEDIA", "0");
      this.FiletoFind.WriteValue("PENTHOUSE", "PENTHOUSE_SPA", "0");
      this.FiletoFind.WriteValue("PENTHOUSE", "PENTHOUSE_BAR", "0");
      this.FiletoFind.WriteValue("PENTHOUSE", "PENTHOUSE_COLOUR", "0");
      this.FiletoFind.WriteValue("PENTHOUSE", "PENTHOUSE_ARCADE", "0");
      this.FiletoFind.WriteValue("PENTHOUSE", "PENTHOUSE_BARLIGHT", "0");
      this.FiletoFind.WriteValue("PENTHOUSE", "PENTHOUSE_POKERDEALER", "0");
      this.FiletoFind.WriteValue("PENTHOUSE", "PENTHOUSE_EXTRABEDROOM", "0");
      this.FiletoFind.WriteValue("PENTHOUSE", "PEDTYPE", "0");
      this.FiletoFind.WriteValue("PENTHOUSE", "TERRACEPEDTYPE", "0");
      this.FiletoFind.WriteValue("INTERIOR PEDS", "RANDOMWANDERPEDS", "True");
      this.FiletoFind.WriteValue("INTERIOR PEDS", "MAINPEDS", "True");
      this.FiletoFind.WriteValue("INTERIOR PEDS", "SLOTPEDS", "True");
      this.FiletoFind.WriteValue("INTERIOR PEDS", "MAINWANDERPEDS", "True");
      this.FiletoFind.WriteValue("INTERIOR PEDS", "BARPEDS", "True");
      this.FiletoFind.WriteValue("CARDDECK", "PLAYERDECK", "1");
      this.FiletoFind.WriteValue("CARDDECK", "ELITEDECKUNLOCKED", "0");
      this.FiletoFind.WriteValue("CARDDECK -TMD", "TMDUNLOCKED", "0");
      this.FiletoFind.WriteValue("CARDDECK - TMD", "TMD_USENORMALDECKCARDS", "True");
      this.FiletoFind.WriteValue("CARDDECK - TMD", "TMD_USENORMALDECKCARDS", "True");
      this.FiletoFind.WriteValue("CARDDECK - TMD", "TMD_USEACE", "True");
      this.FiletoFind.WriteValue("CARDDECK - TMD", "TMD_USEKING", "True");
      this.FiletoFind.WriteValue("CARDDECK - TMD", "TMD_USEQUEEN", "True");
      this.FiletoFind.WriteValue("CARDDECK - TMD", "TMD_USEJACK", "True");
      this.FiletoFind.WriteValue("CARDDECK - TMD", "TMD_USE02", "True");
      this.FiletoFind.WriteValue("CARDDECK - TMD", "TMD_USE03", "True");
      this.FiletoFind.WriteValue("CARDDECK - TMD", "TMD_USE04", "True");
      this.FiletoFind.WriteValue("CARDDECK - TMD", "TMD_USE05", "True");
      this.FiletoFind.WriteValue("CARDDECK - TMD", "TMD_USE06", "True");
      this.FiletoFind.WriteValue("CARDDECK - TMD", "TMD_USE07", "True");
      this.FiletoFind.WriteValue("CARDDECK - TMD", "TMD_USE08", "True");
      this.FiletoFind.WriteValue("CARDDECK - TMD", "TMD_USE09", "True");
      this.FiletoFind.WriteValue("CARDDECK - TMD", "TMD_USE10", "True");
      this.FiletoFind.WriteValue("CARDDECK - TMD", "TMD_DEALER", "False");
      this.print("#EndRead");
    }

    public void SourceAllAfterHoursVehicles(string Path)
    {
      this.print("#StartRead");
      this.FiletoFind.WriteValue("VEHICLES", "MENACERBOUGHT", "1");
      this.FiletoFind.WriteValue("VEHICLES", "SCRAMJETBOUGHT", "1");
      this.FiletoFind.WriteValue("VEHICLES", "OPPRESSORMKIIBOUGHT", "1");
      this.FiletoFind.WriteValue("VEHICLES", "PATRIOTSTRETCHBOUGHT", "1");
      this.FiletoFind.WriteValue("VEHICLES", "SWINGERBOUGHT", "1");
      this.FiletoFind.WriteValue("VEHICLES", "STRAFFORDBOUGHT", "1");
      this.FiletoFind.WriteValue("VEHICLES", "SPEEDOCUSTOMUNLOCKED", "1");
      this.FiletoFind.WriteValue("VEHICLES", "MULECUSTOMUNLOCKED", "1");
      this.FiletoFind.WriteValue("VEHICLES", "POUNDERCUSTOMUNLOCKED", "1");
      this.FiletoFind.WriteValue("MISC", "TERROYBITEBOUGHT", "1");
      this.print("#EndRead");
    }

    public void ResetAfterHoursBusiness(string Path)
    {
      this.print("#StartRead");
      this.FiletoFind.Open(Path, false);
      this.FiletoFind.WriteValue("SETUP", "BUISNESSLEVEL", "0");
      this.FiletoFind.WriteValue("SETUP", "STOCKSVALUE", "0");
      this.FiletoFind.WriteValue("SETUP", "STOCKSCOUNT", "0");
      this.FiletoFind.WriteValue("SETUP", "NIGHTCLUBLOC", "0");
      this.FiletoFind.WriteValue("SETUP", "DESIGN", "ba_case2_taleofus");
      this.FiletoFind.WriteValue("SETUP", "DJ", "IG_Sol");
      this.FiletoFind.WriteValue("SETUP", "THRAXUNLOCKED", "0");
      this.FiletoFind.WriteValue("SETUP", "DIS_UNLOCKED", "0");
      this.FiletoFind.WriteValue("VEHICLES", "MENACERBOUGHT", "0");
      this.FiletoFind.WriteValue("VEHICLES", "SCRAMJETBOUGHT", "0");
      this.FiletoFind.WriteValue("VEHICLES", "OPPRESSORMKIIBOUGHT", "0");
      this.FiletoFind.WriteValue("VEHICLES", "PATRIOTSTRETCHBOUGHT", "0");
      this.FiletoFind.WriteValue("VEHICLES", "SWINGERBOUGHT", "0");
      this.FiletoFind.WriteValue("VEHICLES", "STRAFFORDBOUGHT", "0");
      this.FiletoFind.WriteValue("VEHICLES", "SPEEDOCUSTOMUNLOCKED", "0");
      this.FiletoFind.WriteValue("VEHICLES", "MULECUSTOMUNLOCKED", "0");
      this.FiletoFind.WriteValue("VEHICLES", "POUNDERCUSTOMUNLOCKED", "0");
      this.FiletoFind.WriteValue("MISC", "HOSTNAME", "Gay Tony");
      this.FiletoFind.WriteValue("MISC", "UICOLOUR", "p");
      this.FiletoFind.WriteValue("CONFIGURATIONS", "KEY1", "E");
      this.FiletoFind.WriteValue("MISC", "HOSTNAME", "Gay Tony");
      this.FiletoFind.WriteValue("MISC", "BLIP_COLOUR ", "Blue");
      this.FiletoFind.WriteValue("MISC", "UICOLOUR", "b");
      this.FiletoFind.WriteValue("MISC", "MARKERCOLOR", "Blue");
      this.FiletoFind.WriteValue("MISC", "TERROYBITEBOUGHT", "0");
      this.FiletoFind.WriteValue("MISC", "ISININTERIOR", "False");
      this.FiletoFind.WriteValue("MISC", "ISINGARAGE", "False");
      this.FiletoFind.WriteValue("MISC", "ISINSTORAGE", "False");
      this.FiletoFind.WriteValue("PENTHOUSE", "PEDTYPE", "0");
      this.FiletoFind.WriteValue("PENTHOUSE", "TERRACEPEDTYPE", "0");
      this.FiletoFind.WriteValue("INTERIOR PEDS", "RANDOMWANDERPEDS", "True");
      this.FiletoFind.WriteValue("INTERIOR PEDS", "MAINPEDS", "True");
      this.FiletoFind.WriteValue("INTERIOR PEDS", "SLOTPEDS", "True");
      this.FiletoFind.WriteValue("INTERIOR PEDS", "MAINWANDERPEDS", "True");
      this.FiletoFind.WriteValue("INTERIOR PEDS", "BARPEDS", "True");
      this.FiletoFind.WriteValue("INTERIOR", "N_STYLE", "1");
      this.FiletoFind.WriteValue("INTERIOR", "N_PODIUMSTYLE", "1");
      this.FiletoFind.WriteValue("INTERIOR", "N_BOOZE", "0");
      this.FiletoFind.WriteValue("INTERIOR", "N_DJLIGHTS", "0");
      this.FiletoFind.WriteValue("INTERIOR", "N_LIGHTS", "0");
      this.FiletoFind.WriteValue("INTERIOR", "N_LIGHTSRIG", "1");
      this.FiletoFind.WriteValue("INTERIOR", "N_UPGRADE", "0");
      this.FiletoFind.WriteValue("INTERIOR", "N_CLUBNAME", "1");
      this.FiletoFind.WriteValue("INTERIOR", "N_TROPHIES", "0");
      this.FiletoFind.WriteValue("INTERIOR", "N_WORKLIGHTS", "0");
      this.FiletoFind.WriteValue("INTERIOR", "N_CLUTTER", "0");
      this.FiletoFind.WriteValue("INTERIOR", "N_DRYICE", "0");
      this.FiletoFind.WriteValue("INTERIOR", "N_GUNLOCKER", "0");
      this.FiletoFind.WriteValue("INTERIOR", "N_MONEYVAULT", "0");
      this.FiletoFind.WriteValue("INTERIOR", "N_PRIVACYGLASS", "0");
      this.FiletoFind.WriteValue("INTERIOR", "N_DELIVTRUCK", "0");
      this.FiletoFind.WriteValue("INTERIOR", " N_WAREDROBE", "0");
      this.FiletoFind.WriteValue("INTERIOR", "SPAWNDANCERSINNIGHTCLUB", "1");
      this.FiletoFind.WriteValue("INTERIOR", "N_DJ", "1");
      this.FiletoFind.WriteValue("INTERIOR", "N_DANCERAGENDER", "0");
      this.FiletoFind.WriteValue("INTERIOR", "N_DANCERASTYLE", "0");
      this.FiletoFind.WriteValue("INTERIOR", "N_DANCERBGENDER", "0");
      this.FiletoFind.WriteValue("INTERIOR", "N_DANCERBSTYLE", "0");
      this.FiletoFind.WriteValue("INTERIOR", "N_CEILINGCOLOUR", "White");
      this.FiletoFind.WriteValue("INTERIOR", "N_SPOTLIGHTCOLOUR", "White");
      this.FiletoFind.WriteValue("INTERIOR", "MOVINGSPOTLIGHTS", "False");
      this.FiletoFind.WriteValue("INTERIOR", "RANDOMSPOTLIGHTCOLOUR", "false");
      this.FiletoFind.WriteValue("INTERIOR", "LIGHTCHANGEINTERVAL", "100");
      this.FiletoFind.WriteValue("INTERIOR", "LIGHTMOVEINTERVAL", "24");
      this.FiletoFind.WriteValue("INTERIOR", "PLAYRADIOMUSIC", "False");
      this.FiletoFind.WriteValue("INTERIOR", "DEFAULTRADIOSTATION", "0_Los Santos Rock Radio");
      this.FiletoFind.WriteValue("INTERIOR", "SPOTLIGHTTYPE", "0");
      this.FiletoFind.WriteValue("INTERIOR", "CELINGLIGHTCHANGEINTERVAL", "24");
      this.FiletoFind.WriteValue("INTERIOR", "RANDOMCELINGLIGHTCOLOR", "False");
      this.FiletoFind.WriteValue("INTERIOR", "DRYICEPARTICLEMULTIPLIER", "1");
      this.FiletoFind.WriteValue("8PLAYERPOKER", "STARTINGBANK", "500000");
      this.FiletoFind.WriteValue("8PLAYERPOKER", "MAXRAISEAMT", "10000");
      this.FiletoFind.WriteValue("NIGHTCLUB_MANAGEMENT", "POPULARITY", "10");
      this.FiletoFind.WriteValue("NIGHTCLUB_MANAGEMENT", "NIGHTCLUBJOBSCOMPLETED", "0");
      this.FiletoFind.WriteValue("NIGHTCLUB_MANAGEMENT", "NIGHTCLUBEARNINGS", "0");
      this.FiletoFind.WriteValue("NIGHTCLUB_MANAGEMENT", "WAREHOUSESALESCOMPLETED", "0");
      this.FiletoFind.WriteValue("NIGHTCLUB_MANAGEMENT", "UPGRADE1UNLOCKED", "2");
      this.FiletoFind.WriteValue("NIGHTCLUB_MANAGEMENT", "UPGRADE2UNLOCKED", "2");
      this.FiletoFind.WriteValue("NIGHTCLUB_MANAGEMENT", "UPGRADE3UNLOCKED", "2");
      this.FiletoFind.WriteValue("NIGHTCLUB_MANAGEMENT", "WAREHOUSEEARNINGS", "0");
      this.FiletoFind.WriteValue("NIGHTCLUB_MANAGEMENT", "TOTALEARNINGS", "0");
      this.FiletoFind.WriteValue("NIGHTCLUB_MANAGEMENT", "SAFECAPACITYMAX", "1250000");
      this.FiletoFind.WriteValue("NIGHTCLUB_MANAGEMENT", "SAFECAPACITYCRT", "0");
      this.FiletoFind.WriteValue("NIGHTCLUB_MANAGEMENT", "DAILYINCOME", "0");
      this.FiletoFind.WriteValue("NIGHTCLUB_MANAGEMENT", "GOODSAQUIRED", "0");
      this.FiletoFind.WriteValue("NIGHTCLUB_MANAGEMENT", "GOODSSOLD", "0");
      this.FiletoFind.WriteValue("NIGHTCLUB_MANAGEMENT", "TECHNICIAN1STATUS", "1");
      this.FiletoFind.WriteValue("NIGHTCLUB_MANAGEMENT", "TECHNICIAN1TASK", "0");
      this.FiletoFind.WriteValue("NIGHTCLUB_MANAGEMENT", "TECHNICIAN2STATUS", "0");
      this.FiletoFind.WriteValue("NIGHTCLUB_MANAGEMENT", "TECHNICIAN2TASK", "-1");
      this.FiletoFind.WriteValue("NIGHTCLUB_MANAGEMENT", "TECHNICIAN3STATUS", "0");
      this.FiletoFind.WriteValue("NIGHTCLUB_MANAGEMENT", "TECHNICIAN3TASK", "-1");
      this.FiletoFind.WriteValue("NIGHTCLUB_MANAGEMENT", "TECHNICIAN4STATUS", "0");
      this.FiletoFind.WriteValue("NIGHTCLUB_MANAGEMENT", "TECHNICIAN4TASK", "-1");
      this.FiletoFind.WriteValue("NIGHTCLUB_MANAGEMENT", "TECHNICIAN5STATUS", "0");
      this.FiletoFind.WriteValue("NIGHTCLUB_MANAGEMENT", "TECHNICIAN5TASK", "-1");
      this.FiletoFind.WriteValue("NIGHTCLUB_MANAGEMENT", "CELEBAPPEARANCES", "0");
      this.FiletoFind.WriteValue("NIGHTCLUB_MANAGEMENT_MISC", "MULTIPLIERSELL", "1");
      this.FiletoFind.WriteValue("NIGHTCLUB_MANAGEMENT_MISC", "MULTIPLIERBUYCRATE", "1");
      this.FiletoFind.WriteValue("NIGHTCLUB_MANAGEMENT_MISC", "MULTIPLIERUPG", "1");
      this.FiletoFind.WriteValue("NM_CARGOSTOCK", "CARGOSTOCKCURRENT", "0");
      this.FiletoFind.WriteValue("NM_CARGOSTOCK", "CARGOSTOCKMAX", "50");
      this.FiletoFind.WriteValue("NM_CARGOSTOCK", "CARGOPRICEPERCRATE", "4200");
      this.FiletoFind.WriteValue("NM_SAISTOCK", "SAISTOCKCURRENT", "0");
      this.FiletoFind.WriteValue("NM_SAISTOCK", "SAISTOCKMAX", "50");
      this.FiletoFind.WriteValue("NM_SAISTOCK", "SAIPRICEPERCRATE", "4000");
      this.FiletoFind.WriteValue("NM_PHARSTOCK", "PHARSTOCKCURRENT", "0");
      this.FiletoFind.WriteValue("NM_PHARSTOCK", "PHARSTOCKMAX", "50");
      this.FiletoFind.WriteValue("NM_PHARSTOCK", "PHARPRICEPERCRATE", "5500");
      this.FiletoFind.WriteValue("NM_SPORTINGGOODSSTOCK", "SPORTINGGOODSSTOCKCURRENT", "0");
      this.FiletoFind.WriteValue("NM_SPORTINGGOODSSTOCK", "SPORTINGGOODSSTOCKMAX", "50");
      this.FiletoFind.WriteValue("NM_SPORTINGGOODSSTOCK", "SPORTINGGOODSPRICEPERCRATE", "4400");
      this.FiletoFind.WriteValue("NM_PRINTCOPYSTOCK", "PRINTCOPYSTOCKCURRENT", "0");
      this.FiletoFind.WriteValue("NM_PRINTCOPYSTOCK", "PRINTCOPYSTOCKMAX", "50");
      this.FiletoFind.WriteValue("NM_PRINTCOPYSTOCK", "PRINTCOPYPRICEPERCRATE", "7800");
      this.FiletoFind.WriteValue("NM_COUNTERFEITSTOCKSTOCK", "COUNTERFEITSTOCKCURRENT", "0");
      this.FiletoFind.WriteValue("NM_COUNTERFEITSTOCKSTOCK", "COUNTERFEITSTOCKMAX", "50");
      this.FiletoFind.WriteValue("NM_COUNTERFEITSTOCKSTOCK", "COUNTERFEITPRICEPERCRATE", "8800");
      this.FiletoFind.WriteValue("NM_ORGPRODUCESTOCKSTOCK", "ORGPRODUCESTOCKCURRENT", "0");
      this.FiletoFind.WriteValue("NM_ORGPRODUCESTOCKSTOCK", "ORGPRODUCESTOCKMAX", "50");
      this.FiletoFind.WriteValue("NM_ORGPRODUCESTOCKSTOCK", "ORGPRODUCEPRICEPERCRATE", "6200");
      this.print("#EndRead");
    }

    public void ResetStockTimer(string Path)
    {
      this.print("#StartRead");
      this.FiletoFind.Open(Path, false);
      this.FiletoFind.WriteValue("SETUP", "NEXTDAY", "1");
      this.FiletoFind.WriteValue("SETUP", "NEXTMONTH", "1");
      this.FiletoFind.WriteValue("SETUP", "DAYSWAIT", "3");
      this.FiletoFind.WriteValue("SETUP", "NEXTYEAR", "11");
      this.FiletoFind.WriteValue("SETUP", "SHOWSTOCKINCREASE", "true");
      this.FiletoFind.WriteValue("SETUP", "BYPASS_NOSAVE_OR_CRASH", "true");
      this.FiletoFind.WriteValue("SETUP", "DAYSTORESET_UPDATETIME", "6");
      this.FiletoFind.WriteValue("SETUP", "USEGLOBALBUSINESSINCREASEDECEASEMESSAGE", "false");
      this.FiletoFind.WriteValue("PRICES", "BUSINESSUPGRADEINCREASEGAIN", "75000");
      this.FiletoFind.WriteValue("PRICES", "BUSINESSUPGRADEBASEPRICE", "125000");
      this.FiletoFind.WriteValue("PRICES", "INCREASESTOCKMINAMOUNT", "25000");
      this.FiletoFind.WriteValue("PRICES", "INCREASESTOCKMAXAMOUNT", "125000");
      this.FiletoFind.WriteValue("PRICES", "DECREASESTOCKMINAMOUNT", "25000");
      this.FiletoFind.WriteValue("PRICES", "DECREASESTOCKMAXAMOUNT", "125000");
      this.print("#EndRead");
    }

    public void ResetExecutiveYacht(string Path)
    {
    }

    public void ResetBikerClubhouse(string Path)
    {
      try
      {
        try
        {
          string Ini = Path + "SafeHouse.ini";
          try
          {
            this.FiletoFind.Open(Ini, false);
            this.FiletoFind.WriteValue("SETUP", "PURCHASEDSAFEHOUSE", "0");
            this.print("Success");
          }
          catch (Exception ex)
          {
            this.print("Error : Null Reference Execption!");
          }
        }
        catch (Exception ex)
        {
          this.print("Error : File Not Found!");
        }
      }
      catch (Exception ex)
      {
        this.print("Error : File Not Found!");
      }
    }

    public void ResetBikerSubbusiness(string Ini)
    {
      try
      {
        try
        {
          this.print("#StartRead");
          this.FiletoFind.Open(Ini, false);
          this.FiletoFind.WriteValue("SETUP", "METHVALUE", "0");
          this.FiletoFind.WriteValue("SETUP", "COCAINEVALUE", "0");
          this.FiletoFind.WriteValue("SETUP", "MONEYVALUE", "0");
          this.FiletoFind.WriteValue("SETUP", "FORGERYVALUE", "0");
          this.FiletoFind.WriteValue("SETUP", "WEEDVALUE", "0");
          this.FiletoFind.WriteValue("SETUP", "FORGERYPRODUCT", "0");
          this.FiletoFind.WriteValue("SETUP", "MONEYPRODUCT", "0");
          this.FiletoFind.WriteValue("SETUP", "FORGERYBOUGHT", "0");
          this.FiletoFind.WriteValue("SETUP", "MONEYPRINTERBOUGHT", "0");
          this.FiletoFind.WriteValue("SETUP", "METHPRODUCT", "0");
          this.FiletoFind.WriteValue("SETUP", "WEEDPRODUCT", "0");
          this.FiletoFind.WriteValue("SETUP", "COCAINEPRODUCT", "0");
          this.FiletoFind.WriteValue("PRODUCTION", "WEEDWAIT", "0");
          this.FiletoFind.WriteValue("PRODUCTION", "WEEDBAGS", "0");
          this.FiletoFind.WriteValue("PRODUCTION", "COCAINEWAIT", "0");
          this.FiletoFind.WriteValue("PRODUCTION", "COCAINEBAGS", "0");
          this.FiletoFind.WriteValue("PRODUCTION", "METHWAIT", "0");
          this.FiletoFind.WriteValue("PRODUCTION", "METHBAGS", "0");
          this.FiletoFind.WriteValue("PRODUCTION", "SHOWCOMPLETION", "0");
          this.FiletoFind.WriteValue("PRODUCTION", "COUNTERFEITBAGS", "0");
          this.FiletoFind.WriteValue("PRODUCTION", "COUNTERFEITWAIT", "0");
          this.FiletoFind.WriteValue("PRODUCTION", "FORGERYWAIT", "0");
          this.FiletoFind.WriteValue("PRODUCTION", "FORGERYBAGS", "0");
          this.FiletoFind.WriteValue("PRODUCTION", "MAXWAITBASEDONPURCHASELEVEL", "true");
          this.print("#EndRead");
        }
        catch (Exception ex)
        {
          this.print("Error : Null Reference Execption!");
        }
      }
      catch (Exception ex)
      {
        this.print("Error : File Not Found!");
      }
    }

    public void ResetExecutiveSubbusiness(string Ini)
    {
      try
      {
        try
        {
          this.print("#StartRead");
          this.FiletoFind.Open(Ini, false);
          this.FiletoFind.WriteValue("WAREHOUSE", "SMALLBOUGHT", "0");
          this.FiletoFind.WriteValue("WAREHOUSE", "MEDIUMBOUGHT", "0");
          this.FiletoFind.WriteValue("WAREHOUSE", "LARGEBOUGHT", "0");
          this.FiletoFind.WriteValue("SETUP", "BUISNESSLEVEL", "0");
          this.FiletoFind.WriteValue("NARCOTICS", "NBBOUGHT", "0");
          this.FiletoFind.WriteValue("NARCOTICS", "NSTOCK", "0");
          this.FiletoFind.WriteValue("NARCOTICS", "NPROFIT", "0");
          this.FiletoFind.WriteValue("GEMSTONES", "GPROFIT", "0");
          this.FiletoFind.WriteValue("GEMSTONES", "GSTOCK", "0");
          this.FiletoFind.WriteValue("GEMSTONES", "GBBOUGHT", "0");
          this.FiletoFind.WriteValue("MUNITIONS", "MBBOUGHT", "0");
          this.FiletoFind.WriteValue("MUNITIONS", "MSTOCK", "0");
          this.FiletoFind.WriteValue("MUNITIONS", "MPROFIT", "0");
          this.print("#EndRead");
        }
        catch (Exception ex)
        {
          this.print("Error : Null Reference Execption!");
        }
      }
      catch (Exception ex)
      {
        this.print("Error : File Not Found!");
      }
    }

    public void ResetWarehouse(string NPath)
    {
      try
      {
        try
        {
          try
          {
            this.FiletoFind.Open(NPath, false);
            this.FiletoFind.WriteValue("SETUP", "RUINER2000BOUGHT", "0");
            this.FiletoFind.WriteValue("SETUP", "RAMPBUGGYBOUGHT", "0");
            this.FiletoFind.WriteValue("SETUP", "ABOXVILLEBOUGHT", "0");
            this.FiletoFind.WriteValue("SETUP", "TECHNICALAQUABOUGHT", "0");
            this.FiletoFind.WriteValue("SETUP", "PHANTOMWBOUGHT", "0");
            this.FiletoFind.WriteValue("SETUP", "RVOLTICBOUGHT", "0");
            this.FiletoFind.WriteValue("SETUP", "BLAZERAQUABOUGHT", "0");
            this.FiletoFind.WriteValue("SETUP", "WASTELANDERBOUGHT", "0");
            this.print("Success");
          }
          catch (Exception ex)
          {
            this.print("Error : Null Reference Execption!");
          }
        }
        catch (Exception ex)
        {
          this.print("Error : File Not Found!");
        }
      }
      catch (Exception ex)
      {
        this.print("Error : File Not Found!");
      }
    }

    public class PedSpawn : Script
    {
      public Vector3 Spawn { get; set; }

      public float Heading { get; set; }

      public int Scene { get; set; }

      public PedSpawn()
      {
      }

      public PedSpawn(Vector3 P, float S)
      {
        this.Spawn = P;
        this.Heading = S;
      }
    }
  }
}
