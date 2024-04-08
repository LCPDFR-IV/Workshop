using System;
using System.Windows.Forms;
using GTA;

namespace FuelScriptCS
{
    // Token: 0x02000004 RID: 4
    public class GasStation : Script
    {
        // Token: 0x06000006 RID: 6 RVA: 0x000025A8 File Offset: 0x000007A8
        public GasStation()
        {
            base.Wait(8000);
            Blip blip = Blip.AddBlip(this.GS1);
            blip.Icon = BlipIcon.Building_Garage;
            blip.Name = "Gas Station";
            blip.ShowOnlyWhenNear = true;
            Blip blip2 = Blip.AddBlip(this.GS2);
            blip2.Icon = BlipIcon.Building_Garage;
            blip2.Name = "Gas Station";
            blip2.ShowOnlyWhenNear = true;
            Blip blip3 = Blip.AddBlip(this.GS3);
            blip3.Icon = BlipIcon.Building_Garage;
            blip3.Name = "Gas Station";
            blip3.ShowOnlyWhenNear = true;
            Blip blip4 = Blip.AddBlip(this.GS4);
            blip4.Icon = BlipIcon.Building_Garage;
            blip4.Name = "Gas Station";
            blip4.ShowOnlyWhenNear = true;
            Blip blip5 = Blip.AddBlip(this.GS5);
            blip5.Icon = BlipIcon.Building_Garage;
            blip5.Name = "Gas Station";
            blip5.ShowOnlyWhenNear = true;
            Blip blip6 = Blip.AddBlip(this.GS6);
            blip6.Icon = BlipIcon.Building_Garage;
            blip6.Name = "Gas Station";
            blip6.ShowOnlyWhenNear = true;
            Blip blip7 = Blip.AddBlip(this.GS7);
            blip7.Icon = BlipIcon.Building_Garage;
            blip7.Name = "Gas Station";
            blip7.ShowOnlyWhenNear = true;
            Blip blip8 = Blip.AddBlip(this.GS8);
            blip8.Icon = BlipIcon.Building_Garage;
            blip8.Name = "Gas Station";
            blip8.ShowOnlyWhenNear = true;
            Blip blip9 = Blip.AddBlip(this.GS9);
            blip9.Icon = BlipIcon.Building_Garage;
            blip9.Name = "Gas Station";
            blip9.ShowOnlyWhenNear = true;
            Blip blip10 = Blip.AddBlip(this.GS10);
            blip10.Icon = BlipIcon.Building_Garage;
            blip10.Name = "Gas Station";
            blip10.ShowOnlyWhenNear = true;
            Blip blip11 = Blip.AddBlip(this.GS11);
            blip11.Icon = BlipIcon.Building_Garage;
            blip11.Name = "Gas Station";
            blip11.ShowOnlyWhenNear = true;
            base.Interval = 2000;
            base.KeyDown += this.GasStation_KeyDown;
        }

        // Token: 0x06000007 RID: 7 RVA: 0x000028C0 File Offset: 0x00000AC0
        private void GasStation_KeyDown(object sender, GTA.KeyEventArgs e)
        {
            GasStation.fuelcostuser = base.Settings.GetValueInteger("FuelCost", "SETTINGS", 1);
            GasStation.fueladduser = base.Settings.GetValueInteger("FuelAdd", "SETTINGS", 1);
            AnimationSet animationSet = new AnimationSet("veh@low");
            AnimationFlags flags = AnimationFlags.Unknown12 | AnimationFlags.Unknown11 | AnimationFlags.Unknown09;
            if (e.Key == Keys.NumPad5 && (base.Player.Character.Position.DistanceTo2D(this.GS1) < 15f || base.Player.Character.Position.DistanceTo2D(this.GS2) < 5f || base.Player.Character.Position.DistanceTo2D(this.GS3) < 10f || base.Player.Character.Position.DistanceTo2D(this.GS4) < 15f || base.Player.Character.Position.DistanceTo2D(this.GS5) < 15f || base.Player.Character.Position.DistanceTo2D(this.GS6) < 20f || base.Player.Character.Position.DistanceTo2D(this.GS7) < 25f || base.Player.Character.Position.DistanceTo2D(this.GS8) < 10f || base.Player.Character.Position.DistanceTo2D(this.GS9) < 10f || base.Player.Character.Position.DistanceTo2D(this.GS10) < 5f || base.Player.Character.Position.DistanceTo2D(this.GS11) < 5f) && base.Exists(base.Player.Character.CurrentVehicle) && base.Player == base.Player.Character.CurrentVehicle.GetPedOnSeat(VehicleSeat.Driver))
            {
                base.Player.CanControlCharacter = false;
                base.Player.Character.Task.PlayAnimation(animationSet, "keystart", 16f, flags);
                base.Wait(500);
                base.Player.Character.CurrentVehicle.EngineRunning = false;
                while (FuelScript.CurrentFuel <= 99f)
                {
                    FuelScript.CurrentFuel += (float)GasStation.fueladduser;
                    this.FuelCost += GasStation.fuelcostuser;
                    base.Wait(50);
                }
                base.Player.CanControlCharacter = true;
                base.Player.Money -= this.FuelCost;
                this.FuelCost = 0;
            }
        }

        // Token: 0x06000008 RID: 8 RVA: 0x0000207F File Offset: 0x0000027F
        // Note: this type is marked as 'beforefieldinit'.
        static GasStation()
        {
        }

        // Token: 0x0400000F RID: 15
        private Vector3 GS1 = new Vector3(108.845f, 1136.19f, 14.5584f);

        // Token: 0x04000010 RID: 16
        private Vector3 GS2 = new Vector3(-1312.63f, 1735.93f, 27.9262f);

        // Token: 0x04000011 RID: 17
        private Vector3 GS3 = new Vector3(-1390.83f, 29.1277f, 6.96513f);

        // Token: 0x04000012 RID: 18
        private Vector3 GS4 = new Vector3(-434.543f, -20.781f, 9.86399f);

        // Token: 0x04000013 RID: 19
        private Vector3 GS5 = new Vector3(-480.111f, -210.643f, 7.74865f);

        // Token: 0x04000014 RID: 20
        private Vector3 GS6 = new Vector3(1453.58f, 1711.32f, 16.6932f);

        // Token: 0x04000015 RID: 21
        private Vector3 GS7 = new Vector3(1771.12f, 837.323f, 16.4377f);

        // Token: 0x04000016 RID: 22
        private Vector3 GS8 = new Vector3(1126.68f, 330.693f, 29.7729f);

        // Token: 0x04000017 RID: 23
        private Vector3 GS9 = new Vector3(1129.09f, -358.859f, 19.025f);

        // Token: 0x04000018 RID: 24
        private Vector3 GS10 = new Vector3(774.382f, 195.533f, 6.18214f);

        // Token: 0x04000019 RID: 25
        private Vector3 GS11 = new Vector3(1336.27f, 894.57f, 13.27f);

        // Token: 0x0400001A RID: 26
        private int FuelCost;

        // Token: 0x0400001B RID: 27
        public static int fuelcostuser;

        // Token: 0x0400001C RID: 28
        public static int fueladduser;
    }
}
