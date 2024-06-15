using System;
using System.Collections.Generic;
using Microsoft.Win32;
using ProtoBuf;

namespace Anarchy.Helpers.Helper
{
    public class RegistrySeeker
    {
        [ProtoContract]
        public class RegSeekerMatch
        {
            [ProtoMember(1)]
            public string Key { get; set; }

            [ProtoMember(2)]
            public RegValueData[] Data { get; set; }

            [ProtoMember(3)]
            public bool HasSubKeys { get; set; }

            public override string ToString()
            {
                return $"({this.Key}:{this.Data})";
            }
        }

        [ProtoContract]
        public class RegValueData
        {
            [ProtoMember(1)]
            public string Name { get; set; }

            [ProtoMember(2)]
            public RegistryValueKind Kind { get; set; }

            [ProtoMember(3)]
            public byte[] Data { get; set; }
        }

        private readonly List<RegSeekerMatch> _matches;

        public RegSeekerMatch[] Matches => this._matches?.ToArray();

        public RegistrySeeker()
        {
            this._matches = new List<RegSeekerMatch>();
        }

        public void BeginSeeking(string rootKeyName)
        {
            if (!string.IsNullOrEmpty(rootKeyName))
            {
                using (RegistryKey registryKey = RegistrySeeker.GetRootKey(rootKeyName))
                {
                    if (registryKey != null && registryKey.Name != rootKeyName)
                    {
                        using (RegistryKey registryKey2 = registryKey.OpenReadonlySubKeySafe(rootKeyName.Substring(registryKey.Name.Length + 1)))
                        {
                            if (registryKey2 != null)
                            {
                                this.Seek(registryKey2);
                            }
                            return;
                        }
                    }
                    this.Seek(registryKey);
                    return;
                }
            }
            this.Seek(null);
        }

        private void Seek(RegistryKey rootKey)
        {
            if (rootKey == null)
            {
                foreach (RegistryKey rootKey2 in RegistrySeeker.GetRootKeys())
                {
                    this.ProcessKey(rootKey2, rootKey2.Name);
                }
                return;
            }
            this.Search(rootKey);
        }

        private void Search(RegistryKey rootKey)
        {
            string[] subKeyNames;
            subKeyNames = rootKey.GetSubKeyNames();
            foreach (string text in subKeyNames)
            {
                this.ProcessKey(rootKey.OpenReadonlySubKeySafe(text), text);
            }
        }

        private void ProcessKey(RegistryKey key, string keyName)
        {
            if (key != null)
            {
                List<RegValueData> list;
                list = new List<RegValueData>();
                string[] valueNames;
                valueNames = key.GetValueNames();
                foreach (string name in valueNames)
                {
                    list.Add(RegistryKeyHelper.CreateRegValueData(name, key.GetValueKind(name), key.GetValue(name)));
                }
                this.AddMatch(keyName, RegistryKeyHelper.AddDefaultValue(list), key.SubKeyCount);
            }
            else
            {
                this.AddMatch(keyName, RegistryKeyHelper.GetDefaultValues(), 0);
            }
        }

        private void AddMatch(string key, RegValueData[] values, int subkeycount)
        {
            RegSeekerMatch item;
            item = new RegSeekerMatch
            {
                Key = key,
                Data = values,
                HasSubKeys = (subkeycount > 0)
            };
            this._matches.Add(item);
        }

        public static RegistryKey GetRootKey(string subkeyFullPath)
        {
            string[] array;
            array = subkeyFullPath.Split('\\');
            try
            {
                return array[0] switch
                {
                    "HKEY_CURRENT_CONFIG" => RegistryKey.OpenBaseKey(RegistryHive.CurrentConfig, RegistryView.Registry64), 
                    "HKEY_USERS" => RegistryKey.OpenBaseKey(RegistryHive.Users, RegistryView.Registry64), 
                    "HKEY_LOCAL_MACHINE" => RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64), 
                    "HKEY_CURRENT_USER" => RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64), 
                    "HKEY_CLASSES_ROOT" => RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry64), 
                    _ => throw new Exception("Invalid rootkey, could not be found."), 
                };
            }
            catch (SystemException)
            {
                throw new Exception("Unable to open root registry key, you do not have the needed permissions.");
            }
            catch (Exception ex2)
            {
                throw ex2;
            }
        }

        public static List<RegistryKey> GetRootKeys()
        {
            List<RegistryKey> list;
            list = new List<RegistryKey>();
            try
            {
                list.Add(RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, RegistryView.Registry64));
                list.Add(RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Registry64));
                list.Add(RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64));
                list.Add(RegistryKey.OpenBaseKey(RegistryHive.Users, RegistryView.Registry64));
                list.Add(RegistryKey.OpenBaseKey(RegistryHive.CurrentConfig, RegistryView.Registry64));
                return list;
            }
            catch (SystemException)
            {
                throw new Exception("Could not open root registry keys, you may not have the needed permission");
            }
            catch (Exception ex2)
            {
                throw ex2;
            }
        }
    }
}
