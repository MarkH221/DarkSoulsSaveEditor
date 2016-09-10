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
using System.Drawing;
using System.IO;
using System.Linq;

namespace PS3FileSystem
{
    public class Ps3SaveManager
    {
        public static SecureFileInfo[] GameConfigList;

        public Ps3SaveManager(string savedir, byte[] securefileid)
        {
            if (!Directory.Exists(savedir))
                throw new Exception("No such directory exist!");
            if (!File.Exists(savedir + "\\PARAM.PFD"))
                throw new Exception("Rootdirectory does not contain any PARAM.PFD, Please load a valid directory");
            if (!File.Exists(savedir + "\\PARAM.SFO"))
                throw new Exception("Rootdirectory does not contain any PARAM.SFO, Please load a valid directory");
            Param_PFD = new Param_PFD(savedir + "\\PARAM.PFD");
            Param_SFO = new PARAM_SFO(savedir + "\\PARAM.SFO");
            if (securefileid != null)
                Param_PFD.SecureFileID = securefileid;
            RootPath = savedir;
            if (File.Exists(savedir + "\\ICON0.PNG"))
            {
                //prevent file lock,reading to memory instead.
                SaveImage = Image.FromStream(new MemoryStream(File.ReadAllBytes(savedir + "\\ICON0.PNG")));
            }

            Files = (from ent in Param_PFD.Entries
                     let x = new FileInfo(savedir + "\\" + ent.file_name)
                     where x.Extension.ToUpper() != ".PFD" && x.Extension.ToUpper() != ".SFO"
                     select new Ps3File(savedir + "\\" + ent.file_name, ent, this)).ToArray();
        }

        public string RootPath { get; }
        public Param_PFD Param_PFD { get; }
        public PARAM_SFO Param_SFO { get; private set; }
        public Ps3File[] Files { get; private set; }
        public Image SaveImage { get; private set; }

        public int DecryptAllFiles()
        {
            try
            {
                if (Param_PFD == null || !Directory.Exists(RootPath))
                    return -1;
                return Param_PFD.DecryptAllFiles(RootPath);
            }
            catch
            {
                return -1;
            }
        }

        public int EncryptAllFiles()
        {
            try
            {
                if (Param_PFD == null || !Directory.Exists(RootPath))
                    return -1;
                var x = Param_PFD.EncryptAllFiles(RootPath);
                if (x > 0)
                    if (Param_PFD.RebuilParamPFD(RootPath, false))
                        return x;
                return -1;
            }
            catch
            {
                return -1;
            }
        }

        public bool ReBuildChanges()
        {
            return Param_PFD.RebuilParamPFD(RootPath, false);
        }

        public bool ReBuildChanges(bool encryptfiles)
        {
            return Param_PFD.RebuilParamPFD(RootPath, encryptfiles);
        }

        public int LoadGameConfigFile(string filepath)
        {
            try
            {
                var text = "";
                using (
                    var sr = new StreamReader(new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read)))
                {
                    text = sr.ReadToEnd();
                    sr.Close();
                }
                return (GameConfigList = Functions.ReadConfigFromtext(text)).Length;
            }
            catch
            {
                return -1;
            }
        }

        private byte[] GetSecureFileIdFromConfigFile(string titleid)
        {
            if (GameConfigList == null || GameConfigList.Length == 0)
                return null;
            return (from i in GameConfigList
                    from s in i.GameIDs
                    where s.ToLower() == titleid.ToLower()
                    where i.SecureFileID != null && i.SecureFileID.Length == 32
                    select i.SecureFileID.StringToByteArray()).FirstOrDefault();
        }
    }
}