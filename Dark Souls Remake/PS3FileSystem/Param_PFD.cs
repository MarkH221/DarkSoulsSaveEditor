/* Copyright (c) 2013 - 2014 Jappi88 (Jappi88 at Gmail dot com)
*
* This(software Is provided) 'as-is', without any express or implied
* warranty. In no event will the authors be held liable for any damages arising from the use of this software.
*
* Permission is granted to anyone to use this software for any purpose,
* including commercial applications*, and to alter it and redistribute it
* freely, subject to the following restrictions:
*
* 1. The origin of this software must not be misrepresented; you must not
*   claim that you wrote the original software. If you use this software
*   in a product, an acknowledge in the product documentation is required.
*
* 2. Altered source versions must be plainly marked as such, and must not
*    be misrepresented as being the original software.
*
* 3. This notice may not be removed or altered from any source distribution.
*
* *Contact must be made to discuses permission and terms.
*/

using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PS3FileSystem
{
    public class Param_PFD
    {
        #region static variables

        internal static bool pfd_istropy = false;
        internal static byte[] pfdheaderkey = new byte[16];
        internal static byte[] pfdkey = new byte[16];
        internal static byte[] pfdhashkey = new byte[20];
        internal static byte[] pfdhash = new byte[20];
        internal static byte[] entrykey = new byte[64];
        internal static byte[] realkey = new byte[20];
        internal static byte[] consoleid = new byte[32];
        internal static byte[] userid = { 0, 0, 0, 0, 0, 0, 0, 1 };
        internal static byte[] securefileid;
        internal static byte[] authenticationid = { 0x10, 0x10, 0x00, 0x00, 0x01, 0x00, 0x00, 0x03 };

        internal static byte[] dischashkey =
        {
            0xD1, 0xC1, 0xE1, 0x0B, 0x9C, 0x54, 0x7E, 0x68, 0x9B, 0x80, 0x5D, 0xCD,
            0x97, 0x10, 0xCE, 0x8D
        };

        #endregion static variables

        #region internal/Private methods

        internal byte[] GenerateHashkeyForSFO(int hashindex)
        {
            if (hashindex > 3)
                return null;
            switch (hashindex)
            {
                case 0:
                    return Functions.GetStaticKey("savegame_param_sfo_key");

                case 1:
                    return ConsoleID;

                case 2:
                    return DiscHashKey;

                case 3:
                    return AuthenticationID;

                default:
                    return null;
            }
        }

        internal byte[] GerateHashKeyForSecureFileID(byte[] secureid)
        {
            if (secureid.Length != 16)
                throw new Exception("SecureFileID must be 16 bytes in length");
            var key = new byte[20];
            Array.Copy(secureid, 0, key, 0, 16);
            for (int i = 0, j = 0; i < key.Length; i++)
            {
                switch (i)
                {
                    case 1:
                        key[i] = 11;
                        break;

                    case 2:
                        key[i] = 15;
                        break;

                    case 5:
                        key[i] = 14;
                        break;

                    case 8:
                        key[i] = 10;
                        break;

                    default:
                        key[i] = secureid[j++];
                        break;
                }
            }
            return key;
        }

        internal byte[] GetEntryHashKey(PFDEntry entry, int hashindex)
        {
            switch (entry.file_name.ToLower())
            {
                case "param.sfo":
                    return GenerateHashkeyForSFO(hashindex);

                case "tropsys.dat":
                    return Functions.GetStaticKey("tropsys_dat_key");

                case "tropusr.dat":
                    return Functions.GetStaticKey("tropusr_dat_key");

                case "troptrns.dat":
                    return Functions.GetStaticKey("troptrns_dat_key");

                case "tropconf.sfm":
                    return Functions.GetStaticKey("tropconf_sfm_key");

                default:
                    return GerateHashKeyForSecureFileID(SecureFileID);
            }
        }

        internal byte[] GetEntryKey(PFDEntry entry)
        {
            var key = GetEntryHashKey(entry, 0);
            return Functions.DecryptWithPortability(key, entry.key, entry.key.Length);
        }

        internal byte[] GetTopHash()
        {
            var buffer = PFDHashTable.Buffer;
            buffer = Functions.GetHMACSHA1(realkey, buffer, 0, buffer.Length);
            return buffer;
        }

        internal byte[] GetBottomHash()
        {
            var buffer = PFDEntrySignatureTable.Buffer;
            buffer = Functions.GetHMACSHA1(realkey, buffer, 0, buffer.Length);
            return buffer;
        }

        internal byte[] GetDefaultHash()
        {
            return new HMACSHA1(realkey).ComputeHash(new byte[] { });
        }

        internal ulong CalculateHashTableEntryIndex(string name)
        {
            var len = name.Length;
            ulong hash = 0;
            for (var i = 0; i < len; ++i)
                hash = (hash << 5) - hash + (byte)name[i];
            return hash % PFDHashTable.capacity;
            ;
        }

        internal void Init(Stream input)
        {
            DoProgress("Initializing Param.PFD stream..", MessageType.Info);
            using (var br = new BinaryReader(input))
            {
                PFDHeader.magic = br.ReadUInt64().SwapByteOrder();
                if (PFDHeader.magic != 0x50464442ul)
                {
                    DoProgress("Invalid PFD File!", MessageType.Error);
                    throw new Exception("Invalid PFD File!");
                }
                PFDHeader.version = br.ReadUInt64().SwapByteOrder();
                if (PFDHeader.version != 3ul && PFDHeader.version != 4ul)
                {
                    DoProgress("Unsupported PFD version!", MessageType.Error);
                    throw new Exception("Unsupported PFD version!");
                }
                DoProgress("Allocating Header Data..", MessageType.Info);
                pfdheaderkey = br.ReadBytes(16);
                var header = br.ReadBytes(64);
                header = Functions.DecryptWithPortability(pfdheaderkey, header, header.Length);
                PFDSignature.bottom_hash = new byte[20];
                Array.Copy(header, 0, PFDSignature.bottom_hash, 0, 20);
                PFDSignature.top_hash = new byte[20];
                Array.Copy(header, 20, PFDSignature.top_hash, 0, 20);
                PFDSignature.hash_key = new byte[20];
                Array.Copy(header, 40, PFDSignature.hash_key, 0, 20);
                PFDSignature.padding = new byte[4];
                Array.Copy(header, 60, PFDSignature.padding, 0, 4);
                header = null;

                if (PFDHeader.version == 4ul)
                    realkey = Functions.GetHMACSHA1(Functions.GetStaticKey("keygen_key"), PFDSignature.hash_key, 0, 20);
                else
                    realkey = PFDSignature.hash_key;
                DoProgress("Reading Entries..", MessageType.Info);
                PFDHashTable.capacity = br.ReadUInt64().SwapByteOrder();
                PFDHashTable.num_reserved = br.ReadUInt64().SwapByteOrder();
                PFDHashTable.num_used = br.ReadUInt64().SwapByteOrder();
                PFDHashTable.entries = new List<ulong>();
                DoProgress("Reading table capicity (" + PFDHashTable.capacity + " entries)..", MessageType.Info);
                for (ulong i = 0; i < PFDHashTable.capacity; i++)
                    PFDHashTable.entries.Add(br.ReadUInt64().SwapByteOrder());

                PFDEntries.entries = new List<PFDEntry>();
                DoProgress("Reading used tables (" + PFDHashTable.num_used + " entries)..", MessageType.Info);
                for (ulong i = 0; i < PFDHashTable.num_used; i++)
                {
                    var x = new PFDEntry
                    {
                        additional_index = br.ReadUInt64().SwapByteOrder(),
                        file_name = Encoding.ASCII.GetString(br.ReadBytes(65)).Replace("\0", ""),
                        __padding_0 = br.ReadBytes(7),
                        key = br.ReadBytes(64),
                        file_hashes = new List<byte[]>()
                    };
                    for (var j = 0; j < 4; j++)
                        x.file_hashes.Add(br.ReadBytes(20));
                    x.__padding_1 = br.ReadBytes(40);
                    x.file_size = br.ReadUInt64().SwapByteOrder();
                    PFDEntries.entries.Add(x);
                }
                var offset =
                    (long)
                        ((ulong)(br.BaseStream.Position) + (0x110 * (PFDHashTable.num_reserved - PFDHashTable.num_used)));
                br.BaseStream.Position = offset;
                PFDEntrySignatureTable.hashes = new List<byte[]>();
                DoProgress("Reading file table hashes (" + PFDHashTable.capacity + " entries)..", MessageType.Info);
                for (ulong i = 0; i < PFDHashTable.capacity; i++)
                    PFDEntrySignatureTable.hashes.Add(br.ReadBytes(20));
                br.Close();
            }
        }

        internal static int AlignedSize(int size)
        {
            return (size + 16 - 1) & ~(16 - 1);
        }

        internal byte[] GetEntryHash(int entryindex)
        {
            if (entryindex >= PFDEntries.entries.Count)
                throw new Exception("entryindex is out of bounds");
            var ent = PFDEntries.entries[entryindex];
            var tableindex = CalculateHashTableEntryIndex(ent.file_name);
            var currententryindex = PFDHashTable.entries[(int)tableindex];

            if (currententryindex < PFDHashTable.num_reserved)
            {
                var sha1 = new HMACSHA1(realkey);
                var hashdata = new List<byte>();
                while (currententryindex < PFDHashTable.num_reserved)
                {
                    ent = PFDEntries.entries[(int)currententryindex];
                    hashdata.AddRange(ent.HashData);
                    currententryindex = ent.additional_index;
                }
                sha1.ComputeHash(hashdata.ToArray());
                hashdata.Clear();
                return sha1.Hash;
            }
            return null;
        }

        private void DoProgress(string message, MessageType type)
        {
            ProgressChanged?.Invoke(this, message, type);
        }

        internal struct PFDEntries
        {
            internal static List<PFDEntry> entries;
        }

        /// <summary>A PFD Entry contains child file info</summary>
        public class PFDEntry
        {
            internal byte[] __padding_0;
            internal byte[] __padding_1;
            internal ulong additional_index;
            internal List<byte[]> file_hashes;
            internal string file_name;
            internal ulong file_size;
            internal byte[] key;

            internal byte[] EntryData
            {
                get
                {
                    var ms = new MemoryStream();
                    using (var bw = new BinaryWriter(ms))
                    {
                        bw.Write(additional_index.SwapByteOrder());
                        var name = new byte[65];
                        Array.Copy(Encoding.ASCII.GetBytes(file_name), 0, name, 0, file_name.Length);
                        bw.Write(name, 0, name.Length);
                        bw.Write(__padding_0, 0, __padding_0.Length);
                        bw.Write(key, 0, key.Length);
                        for (var i = 0; i < file_hashes.Count; i++)
                            bw.Write(file_hashes[i], 0, file_hashes[i].Length);
                        bw.Write(__padding_1, 0, __padding_1.Length);
                        bw.Write(file_size.SwapByteOrder());
                        return ms.ToArray();
                    }
                }
            }

            internal byte[] HashData
            {
                get
                {
                    var ms = new MemoryStream();
                    using (var bw = new BinaryWriter(ms))
                    {
                        var name = new byte[65];
                        Array.Copy(Encoding.ASCII.GetBytes(file_name), 0, name, 0, file_name.Length);
                        bw.Write(name, 0, name.Length);
                        bw.Write(key, 0, key.Length);
                        for (var i = 0; i < file_hashes.Count; i++)
                            bw.Write(file_hashes[i], 0, file_hashes[i].Length);
                        bw.Write(__padding_1, 0, __padding_1.Length);
                        bw.Write(file_size.SwapByteOrder());
                        return ms.ToArray();
                    }
                }
            }
        }

        internal struct PFDEntrySignatureTable
        {
            internal static List<byte[]> hashes = new List<byte[]>();

            internal static byte[] Buffer
            {
                get
                {
                    var buffer = new byte[(hashes.Count * 20)];
                    for (var i = 0; i < hashes.Count; i++)
                        Array.Copy(hashes[i], 0, buffer, (i * 20), 20);
                    return buffer;
                }
            }
        }

        internal struct PFDHashTable
        {
            public static ulong capacity;
            public static ulong num_reserved;
            public static ulong num_used;
            public static List<ulong> entries = new List<ulong>();

            public static byte[] Buffer
            {
                get
                {
                    var ms = new MemoryStream();
                    using (var bw = new BinaryWriter(ms))
                    {
                        bw.Write(capacity.SwapByteOrder());
                        bw.Write(num_reserved.SwapByteOrder());
                        bw.Write(num_used.SwapByteOrder());
                        foreach (var value in entries)
                            bw.Write(value.SwapByteOrder());
                        return ms.ToArray();
                    }
                }
            }
        }

        internal struct PFDHeader
        {
            internal static ulong magic;
            internal static ulong version;
        }

        internal struct PFDSignature
        {
            internal static byte[] bottom_hash;
            internal static byte[] top_hash;
            internal static byte[] hash_key;
            internal static byte[] padding;

            internal static byte[] Buffer
            {
                get
                {
                    var data = new byte[64];
                    Array.Copy(bottom_hash, 0, data, 0, 20);
                    Array.Copy(top_hash, 0, data, 20, 20);
                    Array.Copy(hash_key, 0, data, 40, 20);
                    Array.Copy(padding, 0, data, 60, 4);
                    return data;
                }
            }
        }

        #endregion internal/Private methods

        #region Constructors

        /// <summary>Initialize new PARAM.PFD Instance</summary>
        public Param_PFD()
        {
        }

        /// <summary>Initialize new PARAM.PFD Instance</summary>
        /// <param name="filepath">the param.pfd filepath</param>
        public Param_PFD(string filepath)
        {
            Init(new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read));
        }

        /// <summary>Initialize new PARAM.PFD Instance</summary>
        /// <param name="inputdata">Param.pfd as byte array</param>
        public Param_PFD(byte[] inputdata)
        {
            Init(new MemoryStream(inputdata));
        }

        /// <summary> Initialize new PARAM.PFD Instance </summary> <param
        /// name="input">System.IO.Stream for Param.pfd</param> nput"> </param>
        public Param_PFD(Stream input)
        {
            Init(input);
        }

        #endregion Constructors

        #region public methods

        #region Validations

        /// <summary>Check if Top hash is valid, fix if needed</summary>
        /// <param name="fix">set 'true' if you wish to fix it if hash is invalid</param>
        /// <returns>true if top hash is valid</returns>
        public bool ValidTopHash(bool fix)
        {
            var hash = GetTopHash();
            if (!Functions.CompareBytes(hash, PFDSignature.top_hash))
                if (fix)
                    PFDSignature.top_hash = hash;
                else
                    return false;
            return true;
        }

        /// <summary>Check if Bottom hash is valid, fix if needed</summary>
        /// <param name="fix">set 'true' if you wish to fix it if hash is invalid</param>
        /// <returns>true if bottom hash is valid</returns>
        public bool ValidBottomHash(bool fix)
        {
            var hash = GetBottomHash();
            if (!Functions.CompareBytes(hash, PFDSignature.bottom_hash))
                if (fix)
                    PFDSignature.bottom_hash = hash;
                else
                    return false;
            return true;
        }

        /// <summary>validate all Empty bottom hashes and fix it if needed</summary>
        /// <param name="fix">set 'true' if you wish to fix all invalid hashes</param>
        /// <returns>true if File CID is valid</returns>
        public bool ValidFileCID(bool fix)
        {
            var buffer = GetDefaultHash();
            if (buffer == null)
                return false;
            var indexes = new List<int>();
            foreach (var ent in PFDEntries.entries)
                indexes.Add((int)CalculateHashTableEntryIndex(ent.file_name));
            for (var i = 0; i < PFDEntrySignatureTable.hashes.Count; i++)
            {
                if (indexes.IndexOf(i) > -1)
                    continue;
                if (!Functions.CompareBytes(buffer, PFDEntrySignatureTable.hashes[i]))
                    if (fix)
                        PFDEntrySignatureTable.hashes[i] = buffer;
                    else
                        return false;
            }
            return true;
        }

        /// <summary>Check if File CID2 is valid, fix if needed</summary>
        /// <param name="fix">set 'true' if you wish to fix it if hash is invalid</param>
        /// <returns>true if File CID2 is valid</returns>
        public bool ValidDHKCID2(bool fix)
        {
            for (var i = 0; i < PFDEntries.entries.Count; i++)
            {
                var hash = GetEntryHash(i);
                var index = (int)CalculateHashTableEntryIndex(PFDEntries.entries[i].file_name);
                if (!Functions.CompareBytes(hash, PFDEntrySignatureTable.hashes[index]))
                    if (fix)
                        PFDEntrySignatureTable.hashes[index] = hash;
                    else
                        return false;
            }
            return true;
        }

        /// <summary>Check if entry hash is valid, fix if needed</summary>
        /// <param name="input">the input stream of the real file</param>
        /// <param name="entryname">filename that is also specified inside the Param.PFD file entries</param>
        /// <param name="fix">set true if you wish to fix the file entry hash if invalid</param>
        /// <returns>true if file entry hash is valid</returns>
        public bool ValidEntryHash(Stream input, string entryname, bool fix)
        {
            if (!input.CanRead || !input.CanWrite)
                throw new Exception("Unable to Access stream");
            input.Position = 0;
            foreach (var t in PFDEntries.entries)
            {
                if (entryname.ToLower() == t.file_name.ToLower())
                {
                    if (t.file_name.ToLower() == "param.sfo")
                    {
                        Console.WriteLine("Here!");
                    }
                    for (var i = 0; i < 4; i++)
                    {
                        if (t.file_name.ToLower() == "param.sfo" && i != 0)
                            continue;
                        if (!pfd_istropy && i > 0)
                            continue;
                        var key = GetEntryHashKey(t, i);
                        key = Functions.CalculateFileHMACSha1(input, key);
                        if (!Functions.CompareBytes(key, t.file_hashes[i]))
                            if (fix)
                                t.file_hashes[i] = key;
                            else
                                return false;
                    }

                    return true;
                }
            }
            return false;
        }

        /// <summary>Check if entry hash is valid, fix if needed</summary>
        /// <param name="filepath">
        /// the filepath of the file that is specified inside the Param.PFD file entries
        /// </param>
        /// <param name="fix">set true if you wish to fix the file entry hash if invalid</param>
        /// <returns>true if file entry hash is valid</returns>
        public bool ValidEntryHash(string filepath, bool fix)
        {
            if (SecureFileID == null)
                return false;
            if (!File.Exists(filepath))
                throw new Exception(filepath + " does not exist!");
            var filename = new FileInfo(filepath).Name;
            var x = false;
            using (var fs = new FileStream(filepath, FileMode.Open, FileAccess.ReadWrite, FileShare.Read))
            {
                x = ValidEntryHash(fs, filename, fix);
            }
            return x;
        }

        /// <summary> Check if all entry hashes are valid, and fix them if needed </summary> <param
        /// name="rootdirectory">The root directory where the PARAM.PFD and al its child files are
        /// located</param> <param name="fix">set true if you wish to fix all invalid entry
        /// hashes</param> <returns> true if all file entry hashes are valid<</returns>
        public bool ValidAllEntryHashes(string rootdirectory, bool fix)
        {
            for (var i = 0; i < PFDEntries.entries.Count; i++)
            {
                var filepath = rootdirectory + "\\" + PFDEntries.entries[i].file_name;
                if (!File.Exists(filepath))
                    return false;
                if (!ValidEntryHash(filepath, fix))
                    return false;
            }
            return true;
        }

        /// <summary>Check if All Param.PFD Hashes are valid,and Fix them if needed</summary>
        /// <param name="rootdirectory">
        /// The root directory where the PARAM.PFD and al its child files are located
        /// </param>
        /// <param name="fix">set true if you wish to fix all invalid hashes</param>
        /// <returns>true if all hashes are valid</returns>
        public bool ValidAllParamHashes(string rootdirectory, bool fix)
        {
            return (ValidAllEntryHashes(rootdirectory, fix) && ValidDHKCID2(fix) && ValidFileCID(fix) &&
                    ValidTopHash(fix) && ValidBottomHash(fix));
        }

        #endregion Validations

        /// <summary>initialize new PARAM.PFD instance</summary>
        /// <param name="filepath">valid Param.PFD filepath</param>
        public void INIT(string filepath)
        {
            Init(new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read));
        }

        /// <summary>Rebuild the Param.PFD with all changes made</summary>
        /// <param name="rootdirectory">The root path where all the Entry files are stored</param>
        /// <param name="encryptfiles">True if you wish to encrypt all files that are decrypted</param>
        /// <returns>true if PARAM.PFD is succesfully Rebuilded</returns>
        public bool RebuilParamPFD(string rootdirectory, bool encryptfiles)
        {
            try
            {
                if (!File.Exists(rootdirectory + "\\PARAM.SFO"))
                    return false;
                DoProgress("Rebuilding Param.PFD..", MessageType.Info);
                if (encryptfiles)
                {
                    DoProgress("ReEncrypting Files..", MessageType.Info);
                    if (EncryptAllFiles(rootdirectory) == -1)
                        return false;
                }
                DoProgress("Validating Param.PFD Hashes..", MessageType.Info);
                if (!ValidAllParamHashes(rootdirectory, true))
                    return false;
                DoProgress("Writing new Param.PFD..", MessageType.Info);
                File.WriteAllBytes(rootdirectory + "\\PARAM.PFD", GetParamPFDCombinedData());
                DoProgress("Param.PFD Rebuilding complete! Rebuilded FilePath => " + rootdirectory + "\\PARAM.PFD",
                    MessageType.Info);
                return true;
            }
            catch (Exception ex)
            {
                DoProgress(ex.Message, MessageType.Error);
                return false;
            }
        }

        /// <summary>Combine and get the loaded PARAM.PFD file as byte array</summary>
        /// <returns>Compiled PARAM.PFD as a byte array</returns>
        public byte[] GetParamPFDCombinedData()
        {
            byte[] buffer = null;
            DoProgress("Rebuilding new Param.PFD..", MessageType.Info);
            using (var ms = new MemoryStream())
            {
                using (var bw = new BinaryWriter(ms))
                {
                    bw.Write(PFDHeader.magic.SwapByteOrder());
                    bw.Write(PFDHeader.version.SwapByteOrder());
                    bw.Write(pfdheaderkey, 0, pfdheaderkey.Length);
                    buffer = PFDSignature.Buffer;
                    buffer = Functions.EncryptWithPortability(pfdheaderkey, buffer, buffer.Length);
                    bw.Write(buffer, 0, buffer.Length);
                    buffer = PFDHashTable.Buffer;
                    bw.Write(buffer, 0, buffer.Length);
                    foreach (var t in PFDEntries.entries)
                    {
                        buffer = t.EntryData;
                        bw.Write(buffer, 0, buffer.Length);
                    }
                    buffer = new byte[(0x110 * (PFDHashTable.num_reserved - PFDHashTable.num_used))];
                    bw.Write(buffer, 0, buffer.Length);
                    buffer = PFDEntrySignatureTable.Buffer;
                    bw.Write(buffer, 0, buffer.Length);
                    buffer = new byte[0x8000 - ms.Length];
                    if (buffer.Length > 0)
                        bw.Write(buffer, 0, buffer.Length);
                    buffer = ms.ToArray();
                    bw.Close();
                }
            }
            DoProgress("Rebuild Completed!", MessageType.Info);
            return buffer;
        }

        public bool EntryExists(string name)
        {
            if (PFDEntries.entries == null || PFDEntries.entries.Count == 0)
                return false;
            foreach (var ent in PFDEntries.entries)
                if (ent.file_name.ToLower() == name.ToLower())
                    return true;
            return false;
        }

        /// <summary>Progress Changed event, use this to recieve any progress made by this instance</summary>
        public event PS3Action ProgressChanged;

        #region Properties

        public byte[] ConsoleID
        {
            get { return consoleid; }
            set
            {
                if (value.Length != 32) throw new Exception("ConsoleID must be 32 bytes in length");
                consoleid = value;
            }
        }

        public byte[] DiscHashKey
        {
            get { return dischashkey; }
            set
            {
                if (value.Length != 16) throw new Exception("DiscHashKey must be 16 bytes in length");
                dischashkey = value;
            }
        }

        public byte[] AuthenticationID
        {
            get { return authenticationid; }
            set
            {
                if (value.Length != 8) throw new Exception("AuthenticationID must be 8 bytes in length");
                authenticationid = value;
            }
        }

        public byte[] SecureFileID
        {
            get { return securefileid; }
            set
            {
                if (value.Length != 16) throw new Exception("SecureFileID must nbe 16 bytes in length");
                securefileid = value;
            }
        }

        public byte[] UserID
        {
            get { return userid; }
            set
            {
                if (value.Length != 8) throw new Exception("UserID must be 8 bytes in length");
                userid = value;
            }
        }

        public PFDEntry[] Entries
        {
            get { return PFDEntries.entries.ToArray(); }
        }

        #endregion Properties

        #region Decryption

        /// <summary>Decrypts System.IO.Stream into a Byte Array</summary>
        /// <param name="stream">
        /// the input stream of the file that is located inside the Param.PFD Entries
        /// </param>
        /// <param name="entryname">the name of the entry that the stream belongs to</param>
        /// <returns>byte array of the decrypted file</returns>
        public byte[] Decrypt(Stream stream, string entryname)
        {
            if (SecureFileID == null || SecureFileID.Length != 16)
            {
                DoProgress(
                    (SecureFileID == null
                        ? "SecureFileID needed to preform the encryption!"
                        : "SecureFileID is not valid! length must be 16 bytes long (128bit)"), MessageType.Error);
                return null;
            }
            var ent = new PFDEntry();
            var found = false;
            foreach (var t in PFDEntries.entries)
                if (t.file_name.ToLower() == entryname.ToLower())
                {
                    ent = t;
                    found = true;
                    break;
                }
            if (!found)
                throw new Exception("entryname does not exist inside the initialized Param.PFD");
            if (!stream.CanRead || !stream.CanWrite)
                throw new Exception("Unable to Access stream");

            if (!ValidEntryHash(stream, entryname, false))
                throw new Exception(
                    "Encrypted data seems to be invalid, a validated file is required for this operation");

            var size = AlignedSize((int)stream.Length);
            DoProgress("Allocating memory (" + size + " bytes)..", MessageType.Info);
            var data = new byte[size];
            stream.Seek(0, SeekOrigin.Begin);
            stream.Read(data, 0, data.Length);
            DoProgress("Allocating decryption key..", MessageType.Info);
            var key = GetEntryKey(ent);
            DoProgress("Decrypting data (" + size + " bytes)..", MessageType.Info);
            data = Functions.Decrypt(key, data, size);
            if (data == null)
                throw new Exception("Unable to decrypt data");
            DoProgress("Free memory..", MessageType.Info);
            key = null;
            DoProgress("Resizing data to its original size..", MessageType.Info);
            Array.Resize(ref data, (int)ent.file_size);
            return data;
        }

        /// <summary>decrypts input data</summary>
        /// <param name="inputdata">the data to decrypt</param>
        /// <param name="entryname">the name of the entry that the data belongs to</param>
        /// <returns>true if data is succesfully decrypted</returns>
        public bool Decrypt(ref byte[] inputdata, string entryname)
        {
            try
            {
                var data = Decrypt(new MemoryStream(inputdata), entryname);
                if (data == null)
                    return false;
                Array.Resize(ref inputdata, data.Length);
                Array.Copy(data, 0, inputdata, 0, data.Length);
                return true;
            }
            catch (Exception ex)
            {
                DoProgress(ex.Message, MessageType.Error);
                return false;
            }
        }

        /// <summary>Decrypts specified filepath, file must be located inside the Param.PFD Entries</summary>
        /// <param name="filepath">the filepath that should be decrypted</param>
        /// <returns>true if file is succesfully decrypted</returns>
        public bool Decrypt(string filepath)
        {
            try
            {
                if (!File.Exists(filepath) || !ValidEntryHash(filepath, false))
                    return false;
                var name = new FileInfo(filepath).Name;
                byte[] data = null;
                using (var fs = File.Open(filepath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    data = Decrypt(fs, name);
                    fs.Close();
                }
                if (data != null)
                    File.WriteAllBytes(filepath, data);
                else return false;
                data = null;
                return true;
            }
            catch (Exception ex)
            {
                DoProgress(ex.Message, MessageType.Error);
                return false;
            }
        }

        /// <summary>decrypts filepath to a new filepath destination</summary>
        /// <param name="filepath">
        /// the filepath of the file to decrypt, file must be located inside the Param.PFD Entries
        /// </param>
        /// <param name="outpath">the new filepath that you wish to use for the decrypted file</param>
        /// <returns>true if file is succesfully decrypted</returns>
        public bool Decrypt(string filepath, string outpath)
        {
            try
            {
                if (!File.Exists(filepath) || !ValidEntryHash(filepath, false))
                    return false;
                var name = new FileInfo(filepath).Name;
                var fs = File.Open(filepath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                var data = Decrypt(fs, name);
                fs.Close();
                fs.Dispose();
                File.WriteAllBytes(outpath, data);
                return true;
            }
            catch (Exception ex)
            {
                DoProgress(ex.Message, MessageType.Error);
                return false;
            }
        }

        /// <summary>
        /// Decrypt all files that are inside the specified root path, andalso availible inside one
        /// of the Param.PFD entries
        /// </summary>
        /// <param name="root">
        /// the root path of the directory containing all files to be decypted, The initialized
        /// param.PFD should also be in the same path
        /// </param>
        /// <returns>true if all files are succesfully decrypted</returns>
        public int DecryptAllFiles(string root)
        {
            try
            {
                var decrypted = 0;
                foreach (var t in PFDEntries.entries)
                {
                    if (t.file_name.ToLower() == "param.sfo")
                        continue;
                    var filepath = root + "\\" + t.file_name;
                    if (File.Exists(filepath))
                        if (ValidEntryHash(filepath, false))
                            if (Decrypt(filepath))
                                decrypted++;
                }
                return decrypted;
            }
            catch (Exception ex)
            {
                DoProgress(ex.Message, MessageType.Error);
                return -1;
            }
        }

        /// <summary>Decrypts specified filepath into a byte array</summary>
        /// <param name="filepath">
        /// the filepath to decrypt, file must be located inside the Param.PFD Entries
        /// </param>
        /// <returns>byte array of the decrypted file</returns>
        public byte[] DecryptToBytes(string filepath)
        {
            if (!File.Exists(filepath))
                return null;
            var name = new FileInfo(filepath).Name;
            var fs = File.Open(filepath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            var data = Decrypt(fs, name);
            fs.Close();
            fs.Dispose();
            return data;
        }

        /// <summary>Decrypts specified filepath into a System.IO.Stream</summary>
        /// <param name="filepath">
        /// the filepath to decrypt, file must be located inside the Param.PFD Entries
        /// </param>
        /// <returns>System.IO.Stream of the decrypted file</returns>
        public Stream DecryptToStream(string filepath)
        {
            var data = DecryptToBytes(filepath);
            if (data == null)
                return null;
            return new MemoryStream(data);
        }

        #endregion Decryption

        #region Encryption

        /// <summary>Encrypt a specified System.IO.Stream to a byte array</summary>
        /// <param name="stream">Input System.IO.Stream of the file to encrypt</param>
        /// <param name="entryname">the name of the entry inside the PARAM.PFD</param>
        /// <returns>a byte array of theencrypted stream</returns>
        public byte[] Encrypt(Stream stream, string entryname)
        {
            if (SecureFileID == null || SecureFileID.Length != 16)
            {
                DoProgress(
                    (SecureFileID == null
                        ? "SecureFileID needed to preform the encryption!"
                        : "SecureFileID is not valid! length must be 16 bytes long (128bit)"), MessageType.Error);
                return null;
            }
            if (ValidEntryHash(stream, entryname, false))
            {
                DoProgress("File already valid, same data will be returned instead", MessageType.Info);
                var data = new byte[stream.Length];
                stream.Seek(0, SeekOrigin.Begin);
                stream.Read(data, 0, data.Length);
                return data;
            }
            else
            {
                var ent = new PFDEntry();
                var found = false;
                foreach (var t in PFDEntries.entries)
                {
                    if (t.file_name.ToLower() == entryname.ToLower())
                    {
                        ent = t;
                        found = true;
                        break;
                    }
                }
                if (!found)
                    throw new Exception("entryname does not exist inside the initialized Param.PFD");
                if (!stream.CanRead || !stream.CanWrite)
                    throw new Exception("Unable to Access stream");
                ent.file_size = (ulong)stream.Length;
                stream.Seek(0, SeekOrigin.Begin);
                var size = AlignedSize((int)stream.Length);
                DoProgress("Allocating memory (" + size + " bytes)..", MessageType.Info);
                var data = new byte[size];
                DoProgress("Reading stream into memory..", MessageType.Info);
                stream.Read(data, 0, (int)stream.Length);
                DoProgress("Allocating encryption key..", MessageType.Info);
                var key = GetEntryKey(ent);
                DoProgress("Encrypting Data (" + size + "bytes)..", MessageType.Info);
                data = Functions.Encypt(key, data, data.Length);
                if (data == null)
                    throw new Exception("Unable to decrypt data");
                DoProgress("Free allocated memory..", MessageType.Info);
                key = null;
                return data;
            }
        }

        /// <summary>Encrypts inputdata</summary>
        /// <param name="inputdata">the byte array of the file to encrypt</param>
        /// <param name="entry">the the entry inside the PARAM.PFD</param>
        /// <returns>true if succesfully encrypted</returns>
        public bool Encrypt(byte[] inputdata, Ps3File entry)
        {
            try
            {
                entry.PFDEntry.file_size = (ulong)inputdata.Length;
                var data = Encrypt(new MemoryStream(inputdata), entry.PFDEntry.file_name);
                if (data == null)
                    return false;
                File.WriteAllBytes(entry.FilePath, data);
                data = null;
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>Encrypts specified filepath</summary>
        /// <param name="filepath">
        /// the filepath to encrypt, file must be in the same directory as the PARAM.PFD
        /// </param>
        /// <returns>true if file is succesfully encrypted</returns>
        public bool Encrypt(string filepath)
        {
            try
            {
                if (!File.Exists(filepath))
                {
                    DoProgress(filepath + " Does not exist!", MessageType.Error);
                    return false;
                }
                var name = new FileInfo(filepath).Name;
                if (!EntryExists(name))
                {
                    DoProgress("There is no \"" + name + "\" inside the PARAM.PFD Entries!", MessageType.Error);
                    return false;
                }
                DoProgress("Initializing file stream..", MessageType.Info);
                byte[] data = null;
                using (var fs = File.Open(filepath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
                {
                    for (var i = 0; i < PFDEntries.entries.Count; i++)
                    {
                        if (PFDEntries.entries[i].file_name.ToLower() == name.ToLower())
                        {
                            var t = PFDEntries.entries[i];
                            t.file_size = (ulong)fs.Length;
                            PFDEntries.entries[i] = t;
                            break;
                        }
                    }

                    data = Encrypt(fs, name);
                    //DoProgress("Rehashing PARAM.PFD..", MessageType.Info);
                    //bool x = ValidEntryHash(fs, name, true) && ValidFileCID(true) && ValidDHKCID2(true) && ValidBottomHash(true);
                    fs.Dispose();
                }
                if (data == null)
                    return false;
                DoProgress("Writing Encrypted data to : " + filepath, MessageType.Info);
                File.WriteAllBytes(filepath, data);
                DoProgress(name + " is succesfully encrypted", MessageType.Info);
                return true;
            }
            catch (Exception ex)
            {
                DoProgress(ex.Message, MessageType.Error);
                return false;
            }
        }

        /// <summary>Encrypts specified filepath into a new filepath</summary>
        /// <param name="filepath">
        /// the filepath of the file to encrypt, path must be in the same location as the PARAM.PFD
        /// </param>
        /// <param name="newfilepath">the new filepath to encrypt the file to</param>
        /// <returns>true if file is succesfully encrypted</returns>
        public bool Encrypt(string filepath, string newfilepath)
        {
            try
            {
                if (!File.Exists(filepath))
                    return false;
                var name = new FileInfo(filepath).Name;
                DoProgress("Encrypting " + name + "..", MessageType.Info);
                var fs = File.Open(filepath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                var data = Encrypt(fs, name);
                fs.Close();
                fs.Dispose();
                DoProgress("Encrypting " + name + "..", MessageType.Info);
                File.WriteAllBytes(newfilepath, data);
                if (filepath == newfilepath)
                    return ValidEntryHash(filepath, true);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public int EncryptAllFiles(string root)
        {
            try
            {
                var encrypted = 0;
                for (var i = 0; i < PFDEntries.entries.Count; i++)
                {
                    var t = PFDEntries.entries[i];
                    if (t.file_name.ToLower() == "param.sfo")
                        continue;
                    var filepath = root + "\\" + t.file_name;
                    if (File.Exists(filepath))
                    {
                        if (!ValidEntryHash(filepath, false))
                        {
                            if (Encrypt(filepath))
                            {
                                if (!ValidEntryHash(filepath, true))
                                    return -1;
                                encrypted++;
                            }
                        }
                    }
                }
                return encrypted;
            }
            catch
            {
                return -1;
            }
        }

        public byte[] EncryptToBytes(string filepath)
        {
            if (!File.Exists(filepath))
                return null;
            var name = new FileInfo(filepath).Name;
            var fs = File.Open(filepath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
            var data = Encrypt(fs, name);
            fs.Close();
            fs.Dispose();
            return data;
        }

        public Stream EncryptToStream(string filepath)
        {
            var data = EncryptToBytes(filepath);
            if (data == null)
                return null;
            return new MemoryStream(data);
        }

        #endregion Encryption

        #endregion public methods
    }
}