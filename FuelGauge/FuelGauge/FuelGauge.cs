using System;
using System.Drawing;
using GTA;

namespace FuelScriptCS
{
    // Token: 0x02000003 RID: 3
    public class FuelGauge : Script
    {
        // Token: 0x06000004 RID: 4 RVA: 0x0000231C File Offset: 0x0000051C
        public FuelGauge()
        {
            this.Gauges = base.Resources.GetTexture("fuel_gauge.png");
            this.Needles = base.Resources.GetTexture("fuel_needle.png");
            this.Marks = base.Resources.GetTexture("fuel_mark.png");
            base.PerFrameDrawing += this.FuelGauge_PerFrameDrawing;
        }

        // Token: 0x06000005 RID: 5 RVA: 0x00002384 File Offset: 0x00000584
        private void FuelGauge_PerFrameDrawing(object sender, GraphicsEventArgs e)
        {
            if (FuelScript.FuelMeter && base.Player != null && base.Player.Character != null && base.Player.Character.CurrentVehicle != null)
            {
                float num = FuelScript.CurrentFuel / 100f;
                RectangleF radarRectangle = e.Graphics.GetRadarRectangle(FontScaling.Pixel);
                float width = radarRectangle.Width;
                float height = radarRectangle.Height * 0.15f;
                float num2 = (float)(Game.Resolution.Width / 2) - width / 2f;
                float num3 = radarRectangle.Y + radarRectangle.Height;
                e.Graphics.Scaling = FontScaling.Pixel;
                e.Graphics.DrawSprite(this.Gauges, new RectangleF(num2, num3, width, height), Color.White);
                float x = num2 + radarRectangle.Width * 0.17f + radarRectangle.Width * 0.78f * num;
                float y = num3 + radarRectangle.Height * 0.02f;
                float width2 = radarRectangle.Width * 0.02f;
                float height2 = radarRectangle.Height * 0.08f;
                e.Graphics.DrawSprite(this.Needles, new RectangleF(x, y, width2, height2), Color.Red);
                float width3 = radarRectangle.Width * 0.125f;
                float height3 = radarRectangle.Height * 0.15f;
                if ((double)num > 0.15)
                {
                    e.Graphics.DrawSprite(this.Marks, new RectangleF(num2, num3, width3, height3), Color.White);
                    return;
                }
                if (this.flamecount >= 60)
                {
                    this.flamecount = 0;
                }
                if (this.flamecount <= 30)
                {
                    e.Graphics.DrawSprite(this.Marks, new RectangleF(num2, num3, width3, height3), Color.Red);
                    this.flamecount++;
                    return;
                }
                e.Graphics.DrawSprite(this.Marks, new RectangleF(num2, num3, width3, height3), Color.DimGray);
                this.flamecount++;
            }
        }

        // Token: 0x0400000B RID: 11
        private Texture Gauges;

        // Token: 0x0400000C RID: 12
        private Texture Needles;

        // Token: 0x0400000D RID: 13
        private Texture Marks;

        // Token: 0x0400000E RID: 14
        private int flamecount;
    }
}
