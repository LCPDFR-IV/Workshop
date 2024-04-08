using GTA;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

public class IVCapture : Script
{

    private Keys CaptureKey;
    private string CaptureDirectory;

    public IVCapture()
    {
        CaptureDirectory = Path.Combine(Environment.CurrentDirectory, "captures");

        if (!File.Exists(base.Settings.Filename))
        {
            base.Settings.SetValue("CaptureKey", 0x2C);
            base.Settings.Save();
        }

        CaptureKey = (Keys)base.Settings.GetValueInteger("CaptureKey", 0x2C);

        if (!Directory.Exists(CaptureDirectory))
        {
            Directory.CreateDirectory(CaptureDirectory);
        }

        base.KeyDown += IVCapture_KeyDown;
    }

    private void IVCapture_KeyDown(object sender, GTA.KeyEventArgs e)
    {
        if (e.Key == CaptureKey)
        {
            try
            {
                using (Bitmap bmp = new Bitmap(Game.Resolution.Width, Game.Resolution.Height, PixelFormat.Format32bppArgb))
                {
                    using (System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmp))
                    {
                        g.CopyFromScreen(
                            (Screen.PrimaryScreen.Bounds.Width / 2) - Game.Resolution.Width / 2,
                            (Screen.PrimaryScreen.Bounds.Height / 2) - Game.Resolution.Height / 2,
                            0,
                            0,
                            new Size(bmp.Width, bmp.Height),
                            CopyPixelOperation.SourceCopy
                        );
                        DateTime now = DateTime.UtcNow;
                        string file = Path.Combine(CaptureDirectory, $"{now.Month}.{now.Day}.{now.Year}-{now.Hour}.{now.Minute}.{now.Second}.png".Replace("/", "."));
                        bmp.Save(file);
                        Game.Console.Print("Screenshot Captured: " + file);
                    }
                }
            }
            catch (Exception ex) { 
				Game.Console.Print("Screenshot Capture: " + ex.ToString()); 
			}
        }
    }
}