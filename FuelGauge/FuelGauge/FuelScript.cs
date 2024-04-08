using System;
using GTA;

namespace FuelScriptCS
{
    // Token: 0x02000002 RID: 2
    public class FuelScript : Script
    {
        // Token: 0x06000001 RID: 1 RVA: 0x00002084 File Offset: 0x00000284
        public FuelScript()
        {
            FuelScript.fuelmileage = (float)base.Settings.GetValueInteger("FUELMILEAGE", "SETTINGS", 8);
            FuelScript.fuelmileage /= 50f;
            base.Wait(3000);
            base.Interval = 2000;
            base.Tick += this.FuelProgram;
        }

        // Token: 0x06000002 RID: 2 RVA: 0x0000211C File Offset: 0x0000031C
        private void FuelProgram(object sender, EventArgs e)
        {
            if (base.Exists(base.Player.Character.CurrentVehicle))
            {
                this.DrivingVehicle = base.Player.Character.CurrentVehicle;
                if (base.Exists(this.Vehicle1) && this.DrivingVehicle == this.Vehicle1)
                {
                    FuelScript.CurrentFuel = this.Vehicle1FuelAmount;
                    this.NewerVehicleNumber = 1;
                }
                else if (base.Exists(this.Vehicle2) && this.DrivingVehicle == this.Vehicle2)
                {
                    FuelScript.CurrentFuel = this.Vehicle2FuelAmount;
                    this.NewerVehicleNumber = 2;
                }
                else if (this.NewerVehicleNumber == 1)
                {
                    FuelScript.CurrentFuel = (float)FuelScript.rnd.Next(15, 100);
                    this.Vehicle2 = base.Player.Character.CurrentVehicle;
                    this.Vehicle2FuelAmount = FuelScript.CurrentFuel;
                    this.NewerVehicleNumber = 2;
                }
                else if (this.NewerVehicleNumber == 2)
                {
                    FuelScript.CurrentFuel = (float)FuelScript.rnd.Next(15, 100);
                    this.Vehicle1 = base.Player.Character.CurrentVehicle;
                    this.Vehicle1FuelAmount = FuelScript.CurrentFuel;
                    this.NewerVehicleNumber = 1;
                }
                if (base.Player == this.DrivingVehicle.GetPedOnSeat(VehicleSeat.Driver) && this.DrivingVehicle.EngineRunning)
                {
                    while (base.Player.Character.isInVehicle())
                    {
                        FuelScript.FuelMeter = true;
                        if (FuelScript.CurrentFuel > 0f)
                        {
                            float num = this.DrivingVehicle.CurrentRPM * FuelScript.fuelmileage;
                            FuelScript.CurrentFuel -= num;
                            base.Wait(2000);
                        }
                        else
                        {
                            this.DrivingVehicle.EngineRunning = false;
                            base.Wait(2000);
                        }
                    }
                    FuelScript.FuelMeter = false;
                    if (this.NewerVehicleNumber == 1)
                    {
                        this.Vehicle1FuelAmount = FuelScript.CurrentFuel;
                        return;
                    }
                    if (this.NewerVehicleNumber == 2)
                    {
                        this.Vehicle2FuelAmount = FuelScript.CurrentFuel;
                    }
                }
            }
        }

        // Token: 0x06000003 RID: 3 RVA: 0x00002050 File Offset: 0x00000250
        // Note: this type is marked as 'beforefieldinit'.
        static FuelScript()
        {
        }

        // Token: 0x04000001 RID: 1
        public static Random rnd = new Random();

        // Token: 0x04000002 RID: 2
        public static float CurrentFuel = (float)FuelScript.rnd.Next(0, 101);

        // Token: 0x04000003 RID: 3
        private Vehicle DrivingVehicle;

        // Token: 0x04000004 RID: 4
        private Vehicle Vehicle1;

        // Token: 0x04000005 RID: 5
        private Vehicle Vehicle2;

        // Token: 0x04000006 RID: 6
        private float Vehicle1FuelAmount = (float)FuelScript.rnd.Next(0, 101);

        // Token: 0x04000007 RID: 7
        private float Vehicle2FuelAmount = (float)FuelScript.rnd.Next(0, 101);

        // Token: 0x04000008 RID: 8
        private int NewerVehicleNumber = 2;

        // Token: 0x04000009 RID: 9
        public static bool FuelMeter = false;

        // Token: 0x0400000A RID: 10
        public static float fuelmileage = 0f;
    }
}
