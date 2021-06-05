﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ArtGallery.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the ArtGalleryUser class
    public class ArtGalleryUser : IdentityUser
    {
        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string StreetAddress { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string City { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string State { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string PostalCode { get; set; }

    }
}
