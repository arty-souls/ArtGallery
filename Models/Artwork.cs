using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ArtGallery.Models
{
    public class Artwork
    {
        [Key]
        public int ArtworkId { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Display(Name = "Artwork Name")]
        public string ArtworkName { get; set; }


        [Column(TypeName = "nvarchar(4000)")]
        [Required(ErrorMessage = "Please enter Artwork Description")]
        [Display(Name = "Artwork Description")]
        public string ArtworkDesc { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "Please enter Artist Name")]
        [Display(Name = "Artist Name")]
        public string ArtistName { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "Please enter Artist Ig Id")]
        [Display(Name = "Artist Ig Id")]
        public string ArtistIg { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "Please enter Artwork Reference")]
        [Display(Name = "Reference")]
        public string Reference { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        [Required(ErrorMessage = "Please enter Artwork Collection name")]
        [Display(Name = "Collection")]
        public string Collection { get; set; }

      
        [Required(ErrorMessage = "Please enter Price")]
        [Display(Name = "price")]
        public double Price { get; set; }


        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Image Name")]
        public string ImageName { get; set; }

        [Column(TypeName = "varbinary(max)")]
        [NotMapped]
        [Required(ErrorMessage = "Please choose Artwork Image")]
        public IFormFile ArtworkPicture { get; set; }

     
    }
}
