using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArtGallery.Models
{
  
    public class Artist
    {
        [Key]
        public int ArtistId { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "Please enter Artist name")]
        [Display(Name = "Artist Name")]     
        public string ArtistName { get; set; }


        [Column(TypeName = "nvarchar(4000)")]
        [Required(ErrorMessage = "Please enter Artist Description")]
        [Display(Name = "Artist Description")]      
        public string ArtistDesc { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "Please enter Artist City")]
        [Display(Name = "Artist City")]
        public string ArtistCity { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "Please enter Artist Ig Id")]
        [Display(Name = "Artist Ig Id")]
        public string ArtistIg { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Display(Name ="Image Name")]
        public string ImageName { get; set; }

        [Column(TypeName = "varbinary(max)")]
        [NotMapped]
        [Required(ErrorMessage = "Please choose Artist Image")]
        public IFormFile ArtistPicture { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Artwork Name")]
        public string ArtworkName { get; set; }

        [Column(TypeName = "varbinary(max)")]
        [NotMapped]
        public IFormFile ArtistArtwork { get; set; }



    }
}
