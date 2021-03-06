﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace Sochckr.Web.Models
{
    public enum ResolutionReasonType
    {
        None,
        Edited,
        EphemeralSite
    }

    public class BrokenLink
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Link { get; set; }
        [DisplayName("Status Code")]
        public int StatusCode { get; set; }
        public virtual Post Post { get; set; }
        public bool IsResolved { get; set; }

        private ResolutionReasonType _resolutionReason;

        public ResolutionReasonType ResolutionReason
        {
            get => _resolutionReason;
            set
            {
                _resolutionReason = value;
                IsResolved = (value != ResolutionReasonType.None);
            }
        }

    }
}