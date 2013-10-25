//
// This file is part of LinodeCSharpAPI.
//
// LinodeCSharpAPI is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// LinodeCSharpAPI is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with LinodeCSharpAPI.  If not, see <http://www.gnu.org/licenses/>.
// 
using Newtonsoft.Json.Linq;

namespace JTraverso.LinodeCSharpAPI.Core.Payloads
{
    class LinodeListPayload : IResponsePayload
    {
        public int TOTALXFER { get; set; }
        public int BACKUPSENABLED { get; set; }
        public int WATCHDOG { get; set; }
        public string LPM_DISPLAYGROUP { get; set; }
        public int ALERT_BWQUOTA_ENABLED { get; set; }
        public int STATUS { get; set; }
        public int TOTALRAM { get; set; }
        public int ALERT_DISKIO_THRESHOLD { get; set; }
        public int BACKUPWINDOW { get; set; }
        public int ALERT_BWOUT_ENABLED { get; set; }
        public int ALERT_BWOUT_THRESHOLD { get; set; }
        public string LABEL { get; set; }
        public int ALERT_CPU_ENABLED { get; set; }
        public int ALERT_BWQUOTA_THRESHOLD { get; set; }
        public int ALERT_BWIN_THRESHOLD { get; set; }
        public int BACKUPWEEKLYDAY { get; set; }
        public int DATACENTERID { get; set; }
        public int ALERT_CPU_THRESHOLD { get; set; }
        public int TOTALHD { get; set; }
        public int ALERT_DISKIO_ENABLED { get; set; }
        public int ALERT_BWIN_ENABLED { get; set; }
        public int LINODEID { get; set; }
        public string CREATE_DT { get; set; }

        public void Deserialize(JToken token)
        {
            this.TOTALXFER = token["TOTALXFER"].ToObject<int>();
            this.BACKUPSENABLED = token["BACKUPSENABLED"].ToObject<int>();
            this.WATCHDOG = token["WATCHDOG"].ToObject<int>();
            this.LPM_DISPLAYGROUP = token["LPM_DISPLAYGROUP"].ToObject<string>();
            this.ALERT_BWQUOTA_ENABLED = token["ALERT_BWQUOTA_ENABLED"].ToObject<int>();
            this.STATUS = token["STATUS"].ToObject<int>();
            this.TOTALRAM = token["TOTALRAM"].ToObject<int>();
            this.ALERT_DISKIO_THRESHOLD = token["ALERT_DISKIO_THRESHOLD"].ToObject<int>();
            this.BACKUPWINDOW = token["BACKUPWINDOW"].ToObject<int>();
            this.ALERT_BWOUT_ENABLED = token["ALERT_BWOUT_ENABLED"].ToObject<int>();
            this.ALERT_BWOUT_THRESHOLD = token["ALERT_BWOUT_THRESHOLD"].ToObject<int>();
            this.LABEL = token["LABEL"].ToObject<string>();
            this.ALERT_CPU_ENABLED = token["ALERT_CPU_ENABLED"].ToObject<int>();
            this.ALERT_BWQUOTA_THRESHOLD = token["ALERT_BWQUOTA_THRESHOLD"].ToObject<int>();
            this.ALERT_BWIN_THRESHOLD = token["ALERT_BWIN_THRESHOLD"].ToObject<int>();
            this.BACKUPWEEKLYDAY = token["BACKUPWEEKLYDAY"].ToObject<int>();
            this.DATACENTERID = token["DATACENTERID"].ToObject<int>();
            this.ALERT_CPU_THRESHOLD = token["ALERT_CPU_THRESHOLD"].ToObject<int>();
            this.TOTALHD = token["TOTALHD"].ToObject<int>();
            this.ALERT_DISKIO_ENABLED = token["ALERT_DISKIO_ENABLED"].ToObject<int>();
            this.ALERT_BWIN_ENABLED = token["ALERT_BWIN_ENABLED"].ToObject<int>();
            this.LINODEID = token["LINODEID"].ToObject<int>();
            this.CREATE_DT = token["CREATE_DT"].ToObject<string>();

        }
    }
}
